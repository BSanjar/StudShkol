import { observable, action, runInAction } from "mobx";
import { createContext } from "react";
import { IStudentTest } from "../models/StudentTest";
import agent from "../api/agent";

class StudentTestsStore {
  @observable studentTests: IStudentTest[] = [];
  @observable loadingInitial = false;

  @action LoadStudentTests = async () => {
    this.loadingInitial = true;
    try {
      const studentTests = await agent.StudentTests.list();
      runInAction("loading studentTests", () => {
      this.studentTests = studentTests;
      this.loadingInitial = false;
      })
    } catch (error) {
      console.log(error);
      this.loadingInitial = false;
    }
  };
}
export default createContext(new StudentTestsStore());
