import { StudentTestClass } from "./StudentTest";

export interface ILevelTest
{
    id:string;
    name:string;
    groupTestId:string;
    groupTest:string;
    test:string;
    studentTestId:string;
    studentTest:string;
    timeToTest: string;
    students:StudentTestClass[];
}

export class LevelTestClass implements ILevelTest {
  id:string="";
  name:string="";
  groupTestId:string="";
  groupTest:string="";
  test:string="";
  studentTestId:string="";
  studentTest:string="";
  timeToTest: string="";
  students:StudentTestClass[]=[];
    constructor(init?: LevelTestClass) {
      Object.assign(this, init);
    }
  }