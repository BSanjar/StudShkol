export interface ILevelTest
{
    id:string;
    name:string;
    groupTestId:string;
    groupTest:string;
    test:string;
    studentTest:string;
    timeToTest: string;
}

export class LevelTestClass implements ILevelTest {
  id:string="";
  name:string="";
  groupTestId:string="";
  groupTest:string="";
  test:string="";
  studentTest:string="";
  timeToTest: string="";
    constructor(init?: LevelTestClass) {
      Object.assign(this, init);
    }
  }