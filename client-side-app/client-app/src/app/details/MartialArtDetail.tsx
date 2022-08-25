import React from "react";
import { Button, Card, Icon, Image } from "semantic-ui-react";
import { MartialArt } from "../models/martialArt";

interface Props {
  martialArt: MartialArt;
  cancelSelectMartialArt: () => void;
}

export default function ClassroomDetail({
  martialArt,
  cancelSelectMartialArt,
}: Props) {
  return (
    <Card fluid>
      <Image src={`/assets/categoryImages/muayThai.jpeg`} />

      <Card.Content extra>
        <Card.Header>{martialArt.name}</Card.Header>
        <Card.Description>{martialArt.longDescription}</Card.Description>
        <Button.Group>
          <Button basic color="blue" content="Edit" />
          <Button
            onClick={cancelSelectMartialArt}
            basic
            color="grey"
            content="Cancel"
          />
        </Button.Group>
      </Card.Content>
    </Card>
  );
}
