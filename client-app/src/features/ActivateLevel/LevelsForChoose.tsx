import React, { useState, useEffect, useContext } from "react";
import { ILevelTest } from "../../app/models/LevelTest";
import agent from "../../app/api/agent";
import { Step, Confirm } from "semantic-ui-react";
import { IStudentTest } from "../../app/models/StudentTest";
import { history } from "../..";
import { observer } from "mobx-react-lite";
import StudentTestsStore from "../../app/stores/StudentTestsStore";
import { v4 as uuid } from "uuid";

const LevelsForChoose: React.FC<{ studentId: string; groupId: string }> = ({
  studentId,
  groupId,
}) => {
  const [studentTests, SetStudentTests] = useState<IStudentTest[]>([]);
  useEffect(() => {
    agent.StudentTests.listByStudent(studentId).then((res) => {
      SetStudentTests(res);
    });
  }, [studentId]);

  const [levelsGroup, SetLevelsGroup] = useState<ILevelTest[]>([]);
  useEffect(() => {
    agent.LevelTests.listByGroup(groupId).then((res) => {
      SetLevelsGroup(res);
    });
  }, []);
  var newLevel = false;
  const [activeLevelId, setactiveLevelId] = useState("");
  const [confirmOpen, setconfirmOpen] = useState(false);
  const [selectedLevel, setselectedLevel] = useState("");
  const [selectedLevelTimeToTest, setselectedLevelTimeToTest] = useState(0);

  const studentTestsStore = useContext(StudentTestsStore);

  const handleLoadTests = () => {
    studentTestsStore.CurrentStudentTest.levelTestId = selectedLevel;
    studentTestsStore.CurrentStudentTest.id = uuid();
    studentTestsStore.timeToTest = selectedLevelTimeToTest;
    agent.StudentTests.create(studentTestsStore.CurrentStudentTest);
    history.push("/testing");
  };

  return (
    <Step.Group>
      <Confirm
        open={confirmOpen}
        onCancel={() => setconfirmOpen(false)}
        onConfirm={() => handleLoadTests()}
      />
      {levelsGroup.map((levelTest) =>
        studentTests.find((a) => a.levelTestId === levelTest.id) ? (
          <Step
            active={activeLevelId === levelTest.id}
            icon="flag"
            link
            onClick={() => {
              setactiveLevelId(levelTest.id);
              setconfirmOpen(true);
              setselectedLevel(levelTest.id);
              setselectedLevelTimeToTest(parseInt(levelTest.timeToTest))
            }}
            title={levelTest.name}
            key={levelTest.id}
            description="Доступно"
          />
        ) : newLevel === false ? (
          ((newLevel = true),
          (
            <Step
              active={activeLevelId === levelTest.id}
              icon="flag outline"
              link
              key={levelTest.id}
              onClick={() => {
                setactiveLevelId(levelTest.id);
                setconfirmOpen(true);
                setselectedLevel(levelTest.id);
                setselectedLevelTimeToTest(parseInt(levelTest.timeToTest))
              }}
              title={levelTest.name}
              description="Доступно (новый уровень)"
            />
          ))
        ) : (
          <Step
            active={false}
            icon="flag outline"
            link
            key={levelTest.id}
            title={levelTest.name}
            disabled={true}
            description="не доступно"
          />
        )
      )}
    </Step.Group>
  );
};

export default observer(LevelsForChoose);
