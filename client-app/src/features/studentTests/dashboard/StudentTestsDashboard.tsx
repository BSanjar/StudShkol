import React, { useContext, useEffect } from "react";
import { Grid } from "semantic-ui-react";
import StudentTestList from "./StudentTestList";
import { observer } from "mobx-react-lite";
import StudentTestsStore from "../../../app/stores/StudentTestsStore";
import LoadingComponent from "../../../app/layout/LoadingComponent";

const StudentTestsDashboard: React.FC = () => {
  const studentTestsStore = useContext(StudentTestsStore);
  useEffect(() => {
    studentTestsStore.LoadStudentTests();
  }, [studentTestsStore]);

  if (studentTestsStore.loadingInitial)
    return <LoadingComponent content="Идет загрузка тестов..." />;
  return (
    <Grid>
      <Grid.Column width={8}>
        <StudentTestList studentTests={studentTestsStore.studentTests} />
      </Grid.Column>
      <Grid.Column width={8}></Grid.Column>
    </Grid>
  );
};

export default observer(StudentTestsDashboard);
