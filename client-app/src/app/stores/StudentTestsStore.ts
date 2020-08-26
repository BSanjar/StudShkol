import { observable, action, runInAction } from "mobx";
import { createContext } from "react";
import { IStudentTest, StudentTestClass } from "../models/StudentTest";
import agent from "../api/agent";

class StudentTestsStore {
  @observable studentTests: IStudentTest[] = [];
  @observable studentTest: IStudentTest = new StudentTestClass();
  @observable loadingInitial = false;

  @action LoadStudentTests = async () => {
    this.loadingInitial = true;
    try {
      const studentTests = await agent.StudentTests.list();
      runInAction("loading studentTests", () => {
        this.studentTests = studentTests;
        this.loadingInitial = false;
      });
    } catch (error) {
      console.log(error);
      this.loadingInitial = false;
    }
  };

  

  @action LoadStudentTestsByStudent = async (studentId: string) => {
    try {
      const studentTests = await agent.StudentTests.listByStudent(studentId);
      runInAction("loading studentTests by student", () => {
        this.studentTests = studentTests;
      });
    } catch (error) {
      console.log(error);
    }
  };

  @action LoadStudentTestsByStudentAndGroup = async (studentId: string, groupId:string) => {
    try {
      const studentTests = await agent.StudentTests.ListByGroupAndStudent(studentId,groupId);
      runInAction("loading studentTests by student and group", () => {
        this.studentTests = studentTests;
      });
    } catch (error) {
      console.log(error);
    }
  };

  @action LoadStudentTestById = async (Id: string) => {
    try {
      const studentTest = await agent.StudentTests.details(Id);
      runInAction("loading studentTests by id", () => {
        this.studentTest = studentTest;
      });
    } catch (error) {
      console.log(error);
    }
  };
}
export default createContext(new StudentTestsStore());
