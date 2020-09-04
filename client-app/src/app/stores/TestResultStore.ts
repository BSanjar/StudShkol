import { observable } from "mobx";
import { createContext } from "react";
import { ITestResult } from "../models/TestResult";

class TestResultStore {
  @observable testResults: ITestResult[] = [];
}
export default createContext(new TestResultStore());
