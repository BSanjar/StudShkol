import React, { useContext } from "react";
import { Item } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import GroupTestStore from "../../app/stores/GroupTestStore";

const GrTestName: React.FC = () => {
  const groupTestStore = useContext(GroupTestStore);
const {grouptest} = groupTestStore;
  return <Item.Header as="a">fdf{grouptest.name}</Item.Header>;
};

export default observer(GrTestName);
