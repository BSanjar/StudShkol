import React from "react";
import LevelTestName from "../../LevelTests/LevelTestName";
import PromocodesForLevel from "../../Promocodes/PromocodesForLevel";
import { Segment } from "semantic-ui-react";
import { IStudentTest } from "../../../app/models/StudentTest";


const LevelTestStudentInfo: React.FC<{ studentTests: IStudentTest[] }> = ({
  studentTests,
}) => {
  return (
    <div>
      {studentTests.map((studentest) => (
        <Segment key={studentest.id} clearing>
          
          <LevelTestName levelTestId={studentest.levelTestId} />
          <PromocodesForLevel codeId={studentest.codeId} />
          
        </Segment>
      ))}
    </div>
  );
};

export default LevelTestStudentInfo;
