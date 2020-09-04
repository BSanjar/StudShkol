import React, { useContext, useEffect, useState, Fragment } from "react";
import { Label, Segment } from "semantic-ui-react";
import StudentTestsStore from "../../app/stores/StudentTestsStore";
import { IGroupTest } from "../../app/models/GroupTest";
import agent from "../../app/api/agent";
import LevelsForChoose from "./LevelsForChoose";

const ChooseLevel: React.FC = () => {
  const studentTestsStore = useContext(StudentTestsStore);

  //временно
  var studentId = studentTestsStore.CurrentStudentTest.studentId;
  useEffect(() => {
    studentTestsStore.LoadStudentTestsByStudent(studentId);
  }, [studentTestsStore]);

  const [st, setst] = useState<IGroupTest[]>([]);
  useEffect(() => {
    agent.GroupTests.list().then((res) => {
      setst(res);
    });
  }, []);

  return (
    <Fragment>
      <Fragment>
        {st.map((a) => (
          <Fragment key={a.id}>
            <Label size="large" color="blue">
              {a.name}
            </Label>
            <Segment>
              <LevelsForChoose studentId={studentId} groupId={a.id} />
            </Segment>
          </Fragment>
        ))}
      </Fragment>
    </Fragment>
  );
};

export default ChooseLevel;
