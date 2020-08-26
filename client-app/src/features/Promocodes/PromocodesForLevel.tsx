import React, { useEffect, useState } from "react";
import { Item, Segment, Label } from "semantic-ui-react";
import agent from "../../app/api/agent";
import { IPromocode, PromocodeClass } from "../../app/models/Promocode";

const PromocodesForLevel: React.FC<any> = (codeId) => {
  const [st, setst] = useState<IPromocode>(new PromocodeClass());
  useEffect(() => {
    agent.Promocodes.details(codeId.codeId).then((responce) => setst(responce));
  }, []);

  var status = "";
  var startTimeTest = "";
  var endTimeTest = "";

  if (st.status === "wait") {
    status = "В ожидании";
    startTimeTest = "";
    endTimeTest = "";
  }
  if (st.status === "in process") {
    status = "В процессе";

    startTimeTest =
      "Время начало: " + st.dateStartUsing.toString().split("T")[1];
    endTimeTest = "Время завершения: - ";
  }

  if (st.status === "processed") {
    status = "Завершен";
    startTimeTest =
      "Время начало: " + st.dateStartUsing.toString().split("T")[1];
    endTimeTest =
      "Время завершения: " + st.dateFinishUsing.toString().split("T")[1];
  }

  return (
    <Segment clearing>
      <Label color="blue" as="a">
        {status}
      </Label>

      <Item.Content>
        Дата регистрации: {st.dateCreate.toString().split("T")[0]}{" "}
      </Item.Content>
      <Item.Content>
        <Label>{startTimeTest}</Label>
        <Label>{endTimeTest}</Label>
      </Item.Content>
    </Segment>
  );
};

export default PromocodesForLevel;
