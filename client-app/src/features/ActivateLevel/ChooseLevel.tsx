import React, { useContext, useEffect, useState } from "react";
import { Step } from "semantic-ui-react";
import LevelTestStore from "../../app/stores/LevelTestStore";
import StudentTestsStore from "../../app/stores/StudentTestsStore";

const ChooseLevel: React.FC = () => {
  const studentTestsStore = useContext(StudentTestsStore);
  const levelTestsStore = useContext(LevelTestStore);

  const [activeLevelId, setactiveLevelId] = useState("");

  //временно
  var studentId = "CDAF04D0-C2ED-4896-B297-1877E6C3F150";
  useEffect(() => {
    studentTestsStore.LoadStudentTestsByStudent(studentId);
  }, [studentTestsStore]);

  const { leveltests } = levelTestsStore;
  var newLevel = false;

  return (
    <Step.Group>
      {leveltests.map((levelTest) =>
        studentTestsStore.studentTests.find(
          (a) => a.levelTestId === levelTest.id
        ) ? (
          <Step
            active={activeLevelId === levelTest.id}
            icon="flag"
            link
            onClick={() => {
              setactiveLevelId(levelTest.id);
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
            //onClick={this.handleClick}
            title={levelTest.name}
            disabled={true}
            description="не доступно"
          />
        )
      )}
    </Step.Group>
  );
};

export default ChooseLevel;
