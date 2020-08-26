import React, { useEffect, useState } from "react";
import agent from "../../app/api/agent";
import { ILevelTest, LevelTestClass } from "../../app/models/LevelTest";
import LevelTestNameInfo from "./LevelTestNameInfo";

const LevelTestName: React.FC<any> = (levelTestId) => {
  const [st, setst] = useState<ILevelTest>( new LevelTestClass());
  useEffect(() => {
    agent.LevelTests.details(levelTestId.levelTestId).then((responce) =>
      setst(responce)
    );
  }, []);

  return <LevelTestNameInfo levelTest={st} />;
};

export default LevelTestName;
