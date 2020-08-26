import { observable, action, runInAction } from "mobx";
import { createContext } from "react";
import { ILevelTest, LevelTestClass } from "../models/LevelTest";
import agent from "../api/agent";

class LeveltestStore {
  @observable submitting = false;
  @observable loadingInitial = false;
  @observable leveltest: ILevelTest = new LevelTestClass();
  @observable leveltests: ILevelTest[] = [];

  @action loadLevelTest = async (id: string) => {
    try {
      this.loadingInitial = true;
      const levelTest = await agent.LevelTests.details(id);
      runInAction("getting levelTest by id", () => {
        this.leveltest = levelTest;
        this.loadingInitial = false;
      });
    } catch (error) {
      runInAction("getting levelTest by id error", () => {
        this.loadingInitial = false;
      });
      console.log(error);
    }
  };

  @action loadAllLevelTests = async () => {
    try {
      this.loadingInitial = true;
      const levelTests = await agent.LevelTests.list();
      runInAction("getting levelTests", () => {
        this.leveltests = levelTests;
        this.loadingInitial = false;
      });
    } catch (error) {
      runInAction("getting levelTest by id error", () => {});
      this.loadingInitial = false;
      console.log(error);
    }
  };

  @action loadAllLevelTestsByGroupAndStudent = async (GroupId: string,StudentId: string) => {
    try {
      this.loadingInitial = true;
      const levelTests = await agent.LevelTests.ListLevelsStudent(GroupId,StudentId);
      runInAction("getting levelTests student", () => {
        this.leveltests = levelTests;
        this.loadingInitial = false;
      });
    } catch (error) {
      runInAction("getting levelTests student", () => {});
      this.loadingInitial = false;
      console.log(error);
    }
  };
}

export default createContext(new LeveltestStore());
