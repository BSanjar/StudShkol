import { observer } from "mobx-react-lite"
import { createContext } from "react"
import { observable } from "mobx";

class ActivateStore {
    @observable selectedLevel = "";
}

export default createContext(ActivateStore);