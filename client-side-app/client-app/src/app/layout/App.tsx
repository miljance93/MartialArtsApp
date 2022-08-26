import axios from "axios";
import { useEffect, useState } from "react";
import { Container } from "semantic-ui-react";
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

  function handleFormOpen(id?: string) {
    id ? handleSelectMartialArt(id) : handleCancelSelectMartialArt();
    setEditMode(true);
  }

  function handleFormClose() {
    setEditMode(false);
  }

  return (
    <>
      <NavBar openForm={handleFormOpen} />
      <Container style={{ margin: "7em" }}>
        <MartialArtDashboard
          martialArts={martialArts}
          selectedMartialArt={selectedMartialArt}
          selectMartialArt={handleSelectMartialArt}
          cancelSelectMartialArt={handleCancelSelectMartialArt}
          editMode={editMode}
          openForm={handleFormOpen}
          closeForm={handleFormClose}
        />
      </Container>
    </>
  );
}

export default App;
