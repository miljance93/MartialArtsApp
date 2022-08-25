import React from "react";
import { Button, Container, Menu } from "semantic-ui-react";

export default function NavBar() {
  return (
    <Menu inverted fixed="top">
      <Container>
        <Menu.Item header>
          <img
            src="/assets/martialArtLogo.jpg"
            alt="logo"
            style={{ marginRight: 10 }}
          />
          Martial Arts
        </Menu.Item>
        <Menu.Item name="Marial Art" />
        <Menu.Item>
          <Button positive content="Create Martial Art" />
        </Menu.Item>
      </Container>
    </Menu>
  );
}
