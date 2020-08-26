import React, { useContext, Fragment } from "react";
import { Label } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import GroupTestStore from "../../../app/stores/GroupTestStore";
import StudentTests from "./StudentTests";
const GroupTestsStudent: React.FC<any> = (studentID) => {
  const groupsStore = useContext(GroupTestStore);
  const { grouptestsStudent } = groupsStore;
  return (
    <Fragment>
      {grouptestsStudent.map((gr) => (
        <Fragment key={gr.id}>
          <Label size="large" color="blue">
            {gr.name}
          </Label>
          <StudentTests groupId={gr.id} studentId={studentID.studentID} />
        </Fragment>
      ))}
    </Fragment>
  );
};

export default observer(GroupTestsStudent);
