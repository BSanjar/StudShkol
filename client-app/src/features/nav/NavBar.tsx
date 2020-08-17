import React from "react";
import { Menu, Container, Button } from "semantic-ui-react";
import { NavLink } from "react-router-dom";
import { observer } from "mobx-react-lite";

const NavBar: React.FC = () => {
  return (
    <Menu fixed="top" inverted>
      <Container>
        <Menu.Item header as={NavLink} exact to="/">
          <img
            src="/assets/logo.png"
            alt="logo"
            style={{ marginRight: "10px" }}
          />
          Студшкол
        </Menu.Item>
        <Menu.Item name="Рейтинг" as={NavLink} to="/raiting" />
        <Menu.Item name="Мои результаты" as={NavLink} to="/mytests" />
        <Menu.Item>
          <Button
            as={NavLink}
            to="/inputPromocode"
            positive
            //onClick={promocodeStore.openCreateForm}
            content="Пройти тест"
          />
        </Menu.Item>
      </Container>
    </Menu>
  );
};

export default observer(NavBar);
