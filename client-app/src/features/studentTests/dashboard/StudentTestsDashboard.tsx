import React, { useContext, useEffect } from "react";
import { Grid } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import GroupTestStore from "../../../app/stores/GroupTestStore";
import GroupTestsStudent from "./GroupTestsStudent";

const StudentTestsDashboard: React.FC = () => {
  const student = "CDAF04D0-C2ED-4896-B297-1877E6C3F150";
  
  
  const groupsStore = useContext(GroupTestStore);
  useEffect(() => {
    groupsStore.loadStudentGroupTests(student);
  }, [groupsStore]);

  return (
    <Grid>
      <Grid.Column width={8}>
        <GroupTestsStudent studentID={student} />
      </Grid.Column>
      <Grid.Column width={8}></Grid.Column>
    </Grid>
  );
};

export default observer(StudentTestsDashboard);
