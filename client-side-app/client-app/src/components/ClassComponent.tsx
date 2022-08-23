import React, { useState, useEffect } from "react";
import axios from "axios";
import { List } from "semantic-ui-react";

export default function ClassComponent() {
  const [classes, setClasses] = useState([]);

  useEffect(() => {
    axios.get("https://localhost:5001/class").then((response) => {
      setClasses(response.data.value);
    });
  }, []);

  return (
    <div>
      <List>
        {classes.map((anyClasses: any) => (
          <List.Item key={anyClasses.id}>{anyClasses.classroom}</List.Item>
        ))}
      </List>
    </div>
  );
}
