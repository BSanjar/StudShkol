import { observable} from "mobx";
import { createContext } from "react";


class TestingStore {
  @observable studentId = "";
  @observable startTest = false;
  @observable SelectedLevelTestId = "";

}
export default createContext(new TestingStore());
