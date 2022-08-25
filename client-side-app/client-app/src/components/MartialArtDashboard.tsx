import { useState, useEffect } from "react";
import axios from "axios";
import { Grid, List } from "semantic-ui-react";
import { MartialArt } from "../app/models/martialArt";
import MartialArtList from "./MartialArtList";
import MartialArtDetail from "../app/details/MartialArtDetail";
import MartialArtForm from "./form/MartialArtForm";

interface Props {
  martialArts: MartialArt[];
  selectedMartialArt: MartialArt | undefined;
  selectMartialArt: (id: string) => void;
  cancelSelectMartialArt: () => void;
}

export default function MartialArtDashboard({
  martialArts,
  selectedMartialArt,
  selectMartialArt,
  cancelSelectMartialArt,
}: Props) {
  return (
    <Grid>
      <Grid.Column width="10">
        <MartialArtList
          martialArts={martialArts}
          selectMartialArt={selectMartialArt}
        />
      </Grid.Column>
      <Grid.Column width="6">
        {selectedMartialArt && (
          <MartialArtDetail
            martialArt={selectedMartialArt}
            cancelSelectMartialArt={cancelSelectMartialArt}
          />
        )}
        <MartialArtForm />
      </Grid.Column>
    </Grid>
  );
}
