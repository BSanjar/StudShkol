import axios, { AxiosResponse } from "axios";
import { IGroupTest } from "../models/GroupTest";
import { history } from "../..";
import { toast } from "react-toastify";
import { ILevelTest } from "../models/LevelTest";
import { IPromocode } from "../models/Promocode";
import { IStudentTest } from "../models/StudentTest";
import { ITest } from "../models/Test";
import { ITestResult } from "../models/TestResult";
import { IAnswers } from "../models/Answers";

axios.defaults.baseURL = "http://localhost:5000/api";

axios.interceptors.response.use(undefined, (error) => {
  if (error.message === "Network Error" && !error.response) {
    toast.error("Network error - make sure API is running!");
  }
  const { status, data, config } = error.response;
  //console.log(status);
  // if (status === 404) {
  //   history.push("/notfound");
  // }
  if (
    status === 400 &&
    config.method === "get" &&
    data.errors.hasOwnProperty("id")
  ) {
    history.push("/notfound");
  }
  if (status === 500) {
    toast.error("Server error - check the terminal for more info!");
  }
  throw error;
});

const responceBody = (responce: AxiosResponse) => responce.data;

const sleep = (ms: number) => (responce: AxiosResponse) =>
  new Promise<AxiosResponse>((resolve) =>
    setTimeout(() => resolve(responce), ms)
  );

const requests = {
  get: (url: string) => axios.get(url).then(sleep(1000)).then(responceBody),
  post: (url: string, body: {}) =>
    axios.post(url, body).then(sleep(1000)).then(responceBody),
  put: (url: string, body: {}) =>
    axios.put(url, body).then(sleep(1000)).then(responceBody),
  del: (url: string) => axios.delete(url).then(sleep(1000)).then(responceBody),
};

const GroupTests = {
  list: (): Promise<IGroupTest[]> => requests.get("/GroupTests/List"),
  studentGroups: (id: string): Promise<IGroupTest[]> =>
    requests.get(`/GroupTests/GoupsStudent/${id}`),
  details: (id: string) => requests.get(`/GroupTests/Details/${id}`),
  create: (grouptest: IGroupTest) =>
    requests.post("/GroupTests/Create", grouptest),
  update: (grouptest: IGroupTest) =>
    requests.put(`/GroupTests/update/${grouptest.id}`, grouptest),
  delete: (id: string) => requests.del(`/GroupTests/Delete/${id}`),
};

const LevelTests = {
  list: (): Promise<ILevelTest[]> => requests.get("/LevelTests/List"),
  listByGroup: (groupId: string): Promise<ILevelTest[]> =>
    requests.get(`/LevelTests/ListByGroup/${groupId}`),
  ListLevelsStudent: (
    groupId: string,
    studentId: string
  ): Promise<ILevelTest[]> =>
    requests.get(
      `/LevelTests/ListLevelsStudent?groupID=${groupId}&studentId=${studentId}`
    ),
  details: (id: string) => requests.get(`/LevelTests/Details/${id}`),
  create: (leveltest: ILevelTest) =>
    requests.post("/LevelTests/Create", leveltest),
  update: (leveltest: ILevelTest) =>
    requests.put(`/LevelTests/update/${leveltest.id}`, leveltest),
  delete: (id: string) => requests.del(`/LevelTests/Delete/${id}`),
};

const Promocodes = {
  list: (): Promise<IPromocode[]> => requests.get("/Promocodes/List"),
  details: (id: string) => requests.get(`/Promocodes/Details/${id}`),
  detailsbyCode: (code?: string) =>
    requests.get(`/Promocodes/DetailsByCode/${code}`),
  create: (promocode: IPromocode) =>
    requests.post("/Promocodes/Create", promocode),
  update: (promocode: IPromocode) =>
    requests.put(`/Promocodes/Edit${promocode.id}`, promocode),
  delete: (id: string) => requests.del(`/Promocodes/Delete${id}`),
};

const StudentTests = {
  list: (): Promise<IStudentTest[]> => requests.get("/StudentsTest/List"),
  listByStudent: (studentId: string): Promise<IStudentTest[]> =>
    requests.get(`/StudentsTest/ListByStudent/${studentId}`),
  ListByGroupAndStudent: (
    studentId: string,
    groupId: string
  ): Promise<IStudentTest[]> =>
    requests.get(
      `/StudentsTest/ListByGroupAndStudent?groupID=${groupId}&studentId=${studentId}`
    ),

  details: (id: string) => requests.get(`/StudentsTest/Details/${id}`),
  create: (studentTest: IStudentTest) =>
    requests.post("/StudentsTest/Create", studentTest),
  update: (studentTest: IStudentTest) =>
    requests.put(`/StudentsTest/Update/${studentTest.id}`, studentTest),
  delete: (id: string) => requests.del(`/StudentsTest/Delete/${id}`),
};
const Tests = {
  list: (): Promise<ITest[]> => requests.get("/Tests/list"),
  listByLevel: (levelId: string): Promise<ITest[]> =>
    requests.get(`/Tests/listByLevel/${levelId}`),
  details: (id: string) => requests.get(`/Tests/Details/${id}`),
  create: (test: ITest) => requests.post("/Tests/Create", test),
  update: (test: ITest) => requests.put(`/Tests/Update/${test.id}`, test),
  delete: (id: string) => requests.del(`/Tests/Delete/${id}`),
};

const TestResults = {
  list: (): Promise<ITestResult[]> => requests.get("/TestsResults/list"),
  //listByLevel: (levelId:string): Promise<ITest[]> => requests.get(`/Tests/listByLevel/${levelId}`),
  details: (id: string) => requests.get(`/TestsResults/Details/${id}`),
  create: (testres: ITestResult) =>
    requests.post("/TestsResults/Create", testres),
  update: (testres: ITestResult) =>
    requests.put(`/TestsResults/Update/${testres.id}`, testres),
  delete: (id: string) => requests.del(`/TestsResults/Delete/${id}`),
};

const Answers = {
  list: (): Promise<ITestResult[]> => requests.get("/Answers/list"),
  listByTest: (test:string): Promise<IAnswers[]> => requests.get(`/Answers/listByTest/${test}`),
  details: (id: string) => requests.get(`/Answers/Details/${id}`),
  create: (answer: IAnswers) => requests.post("/Answers/Create", answer),
  update: (answer: IAnswers) =>
    requests.put(`/Answers/Update/${answer.id}`, answer),
  delete: (id: string) => requests.del(`/Answers/Delete/${id}`),
};

export default {
  GroupTests,
  LevelTests,
  Promocodes,
  StudentTests,
  Tests,
  TestResults,
  Answers,
};
