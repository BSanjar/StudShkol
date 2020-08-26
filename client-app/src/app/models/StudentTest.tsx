export interface IStudentTest{
    id:string;
    studentId:string;
    levelTestId:string;
    codeId:string;
}

export class StudentTestClass implements IStudentTest {
    id:string="";
    studentId:string="";
    levelTestId:string="";
    codeId:string="";
    constructor(init?: StudentTestClass) {
      Object.assign(this, init);
    }
  }