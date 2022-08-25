import axios from "axios";
import { useEffect, useState } from "react";
import { Container, Header } from "semantic-ui-react";
import MartialArtDashboard from "../../components/MartialArtDashboard";
import { MartialArt } from "../models/martialArt";
import NavBar from "./NavBar";
import "./styles.css";

function App() {
  const [martialArts, setMartialArts] = useState<MartialArt[]>([]);
  const [selectedMartialArt, setSelectedMartialArt] = useState<
    MartialArt | undefined
  >(undefined);
  const [editMode, setEditMode] = useState(false);

  useEffect(() => {
    axios.get("https://localhost:5001/martialart").then((response) => {
      setMartialArts(response.data.value);
    });
  }, []);

  function handleSelectMartialArt(id: string) {
    setSelectedMartialArt(martialArts.find((x) => x.id.toString() === id));
  }

  function handleCancelSelectMartialArt() {
    setSelectedMartialArt(undefined);
  }

  return (
    <>
      <NavBar />
      <Container style={{ margin: "7em" }}>
        <MartialArtDashboard
          martialArts={martialArts}
          selectedMartialArt={selectedMartialArt}
          selectMartialArt={handleSelectMartialArt}
          cancelSelectMartialArt={handleCancelSelectMartialArt}
        />
      </Container>
    </>
  );
}

export default App;
