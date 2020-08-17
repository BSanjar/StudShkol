import React, { useEffect, useContext } from "react";
import { Item } from "semantic-ui-react";
import LeveltestStore from "../../app/stores/LevelTestStore";
import { observer } from "mobx-react-lite";

const LevelTestName: React.FC<any> = (levelTestId) => {
  const levelTestStore = useContext(LeveltestStore);
  useEffect(() => {
    levelTestStore.loadLevelTest(levelTestId.levelTestId);
  }, [levelTestStore]);
  return (
    <div>
      <Item.Header as="a">{levelTestStore.leveltest.name}</Item.Header>
    </div>
  );
};

export default observer(LevelTestName);
