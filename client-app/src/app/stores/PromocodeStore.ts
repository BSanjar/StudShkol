import { observable, action, runInAction } from "mobx";
import { createContext } from "react";
import { IPromocode, PromocodeClass } from "../models/Promocode";
import agent from "../api/agent";

class PromocodeStore {
  @observable submitting = false;
  @observable finded = false;
  @observable findedMessageColor = "grey";
  @observable findedMessage = "Введите промокод";
  @observable loadingInitial = false;
  @observable promocode: IPromocode = new PromocodeClass();

  @action createPromocode = async (promocode: IPromocode) => {
    this.submitting = true;
    try {
      await agent.Promocodes.create(promocode);
    } catch (error) {
      console.log(error);
    }
  };

  @action checkPromocode = async (code: string) => {
    try {
      if(code.length>5){
        const promocode = await agent.Promocodes.detailsbyCode(code);
        runInAction("getting promocode by code", () => {
          this.promocode = promocode;
          this.finded = true;
          this.findedMessageColor="green";
          this.findedMessage = "Промокод найден, нажмите на кнопку 'далее'";
          //console.log(this.promocode);
        });
      }
      else{
        this.finded = false;
        this.findedMessageColor="grey"
        this.findedMessage = "Введите промокод";
      }
     
    } catch (error) {
      this.finded = false;
      this.findedMessageColor="red"
      this.findedMessage = "Не удалось найти промокод, попробуйте еще раз";
      //console.log(error.response);
    }
  };

  @action loadPromocode = async (id: string) => {
    try {
      const promocode = await agent.Promocodes.details(id);
      runInAction("getting promocode by id", () => {
        this.promocode = promocode;
        this.loadingInitial = false;
      });
    } catch (error) {
      runInAction("getting promocode by id error", () => {
        this.loadingInitial = false;
      });
      console.log(error);
    }
  };
}

export default createContext(new PromocodeStore());
