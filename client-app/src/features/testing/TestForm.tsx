import React, { useState, useEffect, useContext } from "react";
import { ITest } from "../../app/models/Test";
import { Form, Radio, Label, Segment } from "semantic-ui-react";
import { IAnswers } from "../../app/models/Answers";
import agent from "../../app/api/agent";
import TestResultStore from "../../app/stores/TestResultStore";

const TestForm: React.FC<{ tes: ITest }> = ({ tes }) => {
  const [answers, setAnswers] = useState<IAnswers[]>([]);

  const testResultStore = useContext(TestResultStore);
  const { testResults } = testResultStore;

  useEffect(() => {
    tes.id != "" &&
      agent.Answers.listByTest(tes.id).then((res) => {
        setAnswers(res);
      });
  }, []);

  const SelectAnswer = (answerId: string) => {
    setSelected(answerId);
    for (var i = 0; i < testResults.length; i++)
      if (testResults[i].testId == tes.id) {
        testResults[i].answerId = answerId;
        testResults[i].Comment = "ответил в " + new Date();
      }
  };

  const [selectedR, setSelected] = useState("");

  return (
    <Segment clearing>
      <Form>
        <Form.Field>{tes.question}</Form.Field>
        {answers.map((a) =>
          testResults.find((b) => b.answerId === a.id) ? (
            <Form.Field key={a.id}>
              <Radio
                label={a.answer}
                name={a.id}
                value={a.id}
                checked={true}
                onChange={() => SelectAnswer(a.id)}
              />
            </Form.Field>
          ) : (
            <Form.Field key={a.id}>
              <Radio
                label={a.answer}
                name={a.id}
                value={a.id}
                checked={a.id === selectedR}
                onChange={() => SelectAnswer(a.id)}
              />
            </Form.Field>
          )
        )}
      </Form>
    </Segment>
  );
};

export default TestForm;
