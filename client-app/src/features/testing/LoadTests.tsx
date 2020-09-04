import React, { useContext, useState, useEffect } from "react";
import { ITest, TestClass } from "../../app/models/Test";
import agent from "../../app/api/agent";
import { observer } from "mobx-react-lite";
import TestForm from "./TestForm";
import { Segment, Label, Button, Progress } from "semantic-ui-react";
import { TestResultClass } from "../../app/models/TestResult";
import TestResultStore from "../../app/stores/TestResultStore";
import StudentTestsStore from "../../app/stores/StudentTestsStore";

const LoadTests: React.FC = () => {
  const [tests, setTests] = useState<ITest[]>([]);
  const [currTest, setcurrTest] = useState<ITest>(new TestClass());
  const [countTest, setcountTest] = useState(0);
  const [currTestIndex, setcurrTestIndex] = useState(0);
  const testResultStore = useContext(TestResultStore);

  var testResult = new TestResultClass();
  const studentTestsStore = useContext(StudentTestsStore);

  useEffect(() => {
    studentTestsStore.CurrentStudentTest.levelTestId !== "" &&
      agent.Tests.listByLevel(
        studentTestsStore.CurrentStudentTest.levelTestId
      ).then((res) => {
        setTests(res);
        setcountTest(res.length);

        setcurrTest(res.length > 0 ? res[0] : new TestClass());

        res.map((t) => {
          testResult = new TestResultClass();
          testResult.Comment = "не ответил(а)";
          testResult.answerId = "";
          testResult.id = "";
          testResult.studentTestId = "";
          testResult.testId = t.id;
          testResultStore.testResults.push(testResult);
        });
      });
  }, []);

  const [seconds, setSeconds] = useState(studentTestsStore.timeToTest);
  const [testFinish, settestFinish] = useState(false);

  useEffect(() => {
    seconds > 0 &&
      !testFinish &&
      setTimeout(() => setSeconds(seconds - 1), 1000);
  }, [seconds]);

  const FinishTest = () => {
    settestFinish(true);
  };

  const ChangeTest = (iter: number) => {
    if (iter === 0) {
      if (currTestIndex > 0) {
        setcurrTest(tests[currTestIndex - 1]);
        setcurrTestIndex(currTestIndex - 1);
      }
    } else {
      if (currTestIndex < countTest - 1) {
        setcurrTest(tests[currTestIndex + 1]);
        setcurrTestIndex(currTestIndex + 1);
      }
    }
  };

  if (studentTestsStore.CurrentStudentTest.levelTestId === "")
    return <Label>Тесты не найдены</Label>;
  if (countTest === 0) return <Label>Тесты не найдены</Label>;

  return (
    <Segment>
      <Label floating color="teal" size="big">
        {seconds}
      </Label>
      <TestForm key={currTest.id} tes={currTest} />
      <Button
        content="Предыдущий"
        icon="left arrow"
        disabled={testFinish}
        labelPosition="left"
        onClick={() => {
          ChangeTest(0);
        }}
      />

      <Button
        labelPosition="right"
        icon="right arrow"
        disabled={testFinish}
        content="Следующий"
        onClick={() => {
          ChangeTest(1);
        }}
      />

      <Button
        //labelPosition="right"
        //icon="right arrow"
        floated="right"
        disabled={(currTestIndex !== countTest - 1 && seconds > 0) || testFinish}
        content={testFinish ? "Тест завершен" : "Завершить тест"}
        onClick={() => {
          FinishTest();
        }}
      />

      <Segment clearing>
        <Progress
          content={
            countTest !== 0
              ? (((currTestIndex + 1) / countTest) * 100)
                  .toFixed(2)
                  .toString() + "%"
              : "0%"
          }
          percent={
            countTest !== 0
              ? (((currTestIndex + 1) / countTest) * 100).toFixed(2)
              : 0
          }
        />
      </Segment>
    </Segment>
  );
};

export default observer(LoadTests);
