export interface ITest{
    id: string;
    question: string;
    levelTestId: string;
}

export class TestClass implements ITest {
    id: string="";
    question: string="";
    levelTestId: string="";
    constructor(init?: ITest) {
      Object.assign(this, init);
    }
  }
