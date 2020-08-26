import { observable, action, runInAction } from "mobx";
import { createContext } from "react";
import { IGroupTest, GroupTestClass } from "../models/GroupTest";
import agent from "../api/agent";

class GroupTestStore {
  @observable submitting = false;
  @observable grouptestsStudent: IGroupTest[] = [];
  @observable loadingInitial = false;
  @observable grouptest: IGroupTest = new GroupTestClass();
  @observable grouptests: IGroupTest[] = [];
  @observable grouptestRegistry = new Map();

  @action loadGroupTest = async (id: string) => {
    try {
      this.loadingInitial = true;
      const groupTest = await agent.GroupTests.details(id);
      runInAction("getting groupTest by id", () => {
        this.grouptest = groupTest;
        this.loadingInitial = false;
      });
    } catch (error) {
      runInAction("getting groupTest by id error", () => {
        this.loadingInitial = false;
      });
      console.log(error);
    }
  };

  @action loadAllGroupTests = async () => {
    try {
      this.loadingInitial = true;
      const groupTests = await agent.GroupTests.list();
      runInAction("getting groupTests", () => {
        this.grouptests = groupTests;
        this.grouptestsStudent = groupTests;
        this.loadingInitial = false;
      });
    } catch (error) {
      runInAction("getting groupTests by id error", () => {});
      this.loadingInitial = false;
      console.log(error);
    }
  };

  @action loadStudentGroupTests = async (studentId: string) => {
    try {
      this.loadingInitial = true;
      const groupTests = await agent.GroupTests.studentGroups(studentId);
      runInAction("getting groupTests", () => {
        groupTests.forEach((element) => {
          this.grouptestRegistry.set(element.id, element);
        });

        this.grouptestsStudent = groupTests;

        this.loadingInitial = false;
      });
    } catch (error) {
      runInAction("getting groupTests by id error", () => {});
      this.loadingInitial = false;
      console.log(error);
    }
  };
}

export default createContext(new GroupTestStore());
