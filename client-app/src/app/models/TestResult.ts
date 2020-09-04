export interface ITestResult {
  id: string;
  studentTestId: string;
  testId: string;
  answerId: string;
  Comment: string;
}

export class TestResultClass implements ITestResult {
  id: string = "";
  studentTestId: string = "";
  testId: string = "";
  answerId: string = "";
  Comment: string = "";
  constructor(init?: TestResultClass) {
    Object.assign(this, init);
  }
}
