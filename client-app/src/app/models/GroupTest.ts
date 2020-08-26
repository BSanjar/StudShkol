export interface IGroupTest {
  id: string;
  name: string;
  // levelTest:string;
  // levelTests:LevelTestClass[];
}

export class GroupTestClass implements IGroupTest {
  id: string = "";
  name: string = "";
  // levelTest:string="";
  // levelTests:LevelTestClass[]=[];
  constructor(init?: GroupTestClass) {
    Object.assign(this, init);
  }
}
