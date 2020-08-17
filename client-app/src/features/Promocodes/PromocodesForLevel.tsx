import React, { useEffect, useContext } from "react";
import { Item } from "semantic-ui-react";
import PromocodeStore from "../../app/stores/PromocodeStore";
import { observer } from "mobx-react-lite";

const PromocodesForLevel: React.FC<any> = (PromocodeTestId) => {
  const PromocodesStore = useContext(PromocodeStore);
  useEffect(() => {
    PromocodesStore.loadPromocode(PromocodeTestId.PromocodeTestId);
  }, [PromocodesStore]);

  var status = "";

  if (PromocodesStore.promocode.status === "wait") {
    status = "В ожидании";
  }
  if (PromocodesStore.promocode.status === "in process") status = "В процессе";
  if (PromocodesStore.promocode.status === "processed") status = "Завершен";

  return (
    <div>
      <Item.Meta>{status}</Item.Meta>
      <Item.Description>
        <div>
          {" "}
          Дата регистрации:{" "}
          {PromocodesStore.promocode.dateCreate.toString().split("T")[0]}{" "}
        </div>
        <div>
          {PromocodesStore.promocode.dateStartUsing.toString().split("T")[1]} -{" "}
          {PromocodesStore.promocode.dateFinishUsing.toString().split("T")[1]}
        </div>
      </Item.Description>
    </div>
  );
};

export default observer(PromocodesForLevel);
