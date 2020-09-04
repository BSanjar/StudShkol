export interface IAnswers {
    id: string;
    answer: string;
    testId: string;
    score: string;
  }
  

  export class AnswersClass implements IAnswers {
    id: string="";
    answer: string="";
    testId: string="";
    score: string="";
    constructor(init?: AnswersClass) {
      Object.assign(this, init);
    }
  }