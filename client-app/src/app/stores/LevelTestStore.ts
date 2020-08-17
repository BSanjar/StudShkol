import { observable, action, runInAction } from "mobx";
import { createContext } from "react";
import { ILevelTest, LevelTestClass } from "../models/LevelTest";
import agent from "../api/agent";

class LeveltestStore {
  @observable submitting = false;
  @observable loadingInitial = false;
  @observable leveltest: ILevelTest = new LevelTestClass();

  @action loadLevelTest = async (id: string) => {
    try {
      const levelTest = await agent.LevelTests.details(id);
      runInAction("getting levelTest by id", () => {
        this.leveltest = levelTest;
        this.loadingInitial = false;
      });
    } catch (error) {
      runInAction("getting levelTest by id error", () => {
        this.loadingInitial = false;
      });
      console.log(error);
    }
  };
}

export default createContext(new LeveltestStore());
