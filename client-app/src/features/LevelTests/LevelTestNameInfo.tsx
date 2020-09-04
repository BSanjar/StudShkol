import React from "react";
import { Segment, Item } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import { ILevelTest } from "../../app/models/LevelTest";

const LevelTestNameInfo: React.FC<{ levelTest: ILevelTest }> = ({
  levelTest,
}) => {
  return (
    <Segment>
      <Item.Group>
        <Item>
          <Item.Header as="a">{levelTest.name}</Item.Header>
        </Item>
      </Item.Group>
    </Segment>
  );
};

export default observer(LevelTestNameInfo);
