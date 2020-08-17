import React, {Fragment } from "react";
import { Container } from "semantic-ui-react";
import NavBar from "../../features/nav/NavBar";
import StudentTestsDashboard from "../../features/studentTests/dashboard/StudentTestsDashboard";
import { observer } from "mobx-react-lite";
import { Route, Switch } from "react-router-dom";
import InputPromocode from "../../features/Promocodes/Form/InputPromocode";
import HomePage from "../../features/home/HomePage";
import NotFoundComponent from "../../app/layout/NotFoundComponent";
import { ToastContainer } from "react-toastify";

const App = () => {
  return (
    <Fragment>
      <ToastContainer position="bottom-right" />
      <Route exact path="/" component={HomePage} />
      <Route
        path={"/(.+)"}
        render={() => (
          <Fragment>
            <NavBar />
            <Container style={{ marginTop: "7em" }}>
              <Switch>
                <Route path="/inputPromocode" component={InputPromocode} />
                <Route path="/mytests" component={StudentTestsDashboard} />
                {/* <Route path="/raiting" component={StudentTestsDashboard} /> */}
                <Route component={NotFoundComponent} />
              </Switch>
              {/* <StudentTestsDashboard studentTests={studentTestsStore.studentTests} /> */}
            </Container>
          </Fragment>
        )}
      />
    </Fragment>
  );
};

export default observer(App);
