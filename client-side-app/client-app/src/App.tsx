import { Header, List } from "semantic-ui-react";
import "./App.css";
import ClassComponent from "./components/ClassComponent";

function App() {
  return (
    <div>
      <Header as="h2" icon="users" content="Classrooms" />
      <ClassComponent />
    </div>
  );
}

export default App;
