import React from "react";
import { Item, Segment } from "semantic-ui-react";
import { IStudentTest } from "../../../app/models/StudentTest";
import LevelTestName from "../../LevelTests/LevelTestName";
import PromocodesForLevel from "../../Promocodes/PromocodesForLevel";
import { observer } from "mobx-react-lite";

interface IProps {
  studentTests: IStudentTest[];
}
var key=0;
const StudentTestList: React.FC<IProps> = ({ studentTests }) => {
  return (
    <Segment clearing>
      <Item.Group divided>
        {studentTests.map((studentTest) => (
          key=key+1,
          <Item key={key}>
            <Item.Content>
              <LevelTestName levelTestId={studentTest.levelTestId} />
              <PromocodesForLevel PromocodeTestId={studentTest.codeId} />
            </Item.Content>
          </Item>
          
        ))}
      </Item.Group>
    </Segment>
  );
};

export default observer(StudentTestList);
