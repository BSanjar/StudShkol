import React, { useEffect, useState } from "react";
import { Segment } from "semantic-ui-react";
import { IStudentTest } from "../../../app/models/StudentTest";
import agent from "../../../app/api/agent";
import LevelTestStudentInfo from "./LevelTestStudentInfo";

const StudentTests: React.FC<{ groupId: string; studentId: string }> = ({
  groupId,
  studentId,
}) => {
  const [st, setst] = useState<IStudentTest[]>([]);
  useEffect(() => {
    agent.StudentTests.ListByGroupAndStudent(
      studentId,
      groupId
    ).then((responce) => setst(responce));
  }, []);
  return (
    <Segment.Group>
      <LevelTestStudentInfo studentTests={st} />
    </Segment.Group>
  );
};

export default StudentTests;
