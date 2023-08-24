<template>
  <div>
    <v-row>
      <v-col>
        <Signin @signIn="signIn" />
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <h2 class="text-xl">Tabelle</h2>
        <p> Diese Tabellen-Ansicht gibt Ihnen einen direkten Zugriff auf die Daten. Sie können die Tabelle
          durchsuchen/filtern
          <Hint :tip="tip_filter" /> und gruppieren
          <Hint :tip="tip_group" />.
          Bitte beachten Sie: Die Tabelle zeigt alle Datensätze an - aufgrund der Tabellengröße ist die horizonale und
          vertikal Darstellung beschnitten. Sie können mit dem Mausrad horizontal und vertikal scrollen
          <Hint :tip="tip_scroll" />. Außerdem erscheinen Scroll-Leisten, wenn Sie die Maus an den unteren bzw. rechten
          Rand bewegen.
        </p>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <DxDataGrid id="grid" ref="grid" :data-source="dataSource" :column-auto-width="true" :allow-column-resizing="true"
          :allow-column-reordering="true" height="600">
          <DxFilterRow :visible="true" />
          <DxColumn v-for="c in schema" :key="c" :data-field="c.dataField" :caption="c.caption" :allow-fixing="true" />
          <DxColumnChooser :enabled="true" mode="select" />
          <DxSorting mode="multiple" />
          <DxScrolling mode="virtual" />
          <DxGrouping :context-menu-enabled="true" />
          <DxGroupPanel :visible="true" />
        </DxDataGrid>
      </v-col>
    </v-row>
  </div>
</template>
    
<script>
import 'devextreme/dist/css/dx.material.blue.light.compact.css';
import { DxDataGrid, DxColumn, DxFilterRow, DxColumnChooser, DxSorting, DxScrolling, DxGrouping, DxGroupPanel } from 'devextreme-vue/data-grid';

import Hint from '~/components/hint.vue';

import auth from "../korapJsClient/auth.js";

export default {
  name: "ViewGrid",
  components: {
    DxDataGrid,
    DxColumn,
    DxFilterRow,
    DxColumnChooser,
    DxSorting,
    DxScrolling,
    DxGrouping,
    DxGroupPanel,

    Hint
  },
  data() {
    return {
      schema: [],
      dataSource: {
        store: []
      },
      tip_filter: "Unterhalb jedes Spaltenkopfs finden Sie eine Eingabebox (siehe Lupen-Symbol).<br/>Sie können nach einem Wert suchen, indem Sie diesen Wert in das entsprechende Feld eingeben.<br/>Mit einem Klick auf das Lupen-Symbol können Sie verschiedene Suchoperatoren auswählen.",
      tip_group: "Sie können die Tabelle nach einer Spalte gruppieren, indem Sie die Spalte in den Bereich oberhalb der Tabelle ziehen.<br/>Sie können die Gruppierung aufheben, indem Sie die Spalte aus dem oberen Bereich erneut auf die Tabelle ziehen.",
      tip_scroll: "Fast jede modern Maus verfügt über eine vertikale und horizontale Scroll-Funktion.<br/>Für das vertikale Scrollen tippen Sie ggf. das Mausrat von rechts nach links (bzw. umgekehrt) an."
    };
  },
  mounted() {
    if ((new auth()).isSignedIn)
      this.signIn();
    else
      fetch('/schema.json')
        .then(response => response.json())
        .then(schema => {
          this.schema = schema;
          fetch('/data.json')
            .then(response => response.json())
            .then(data => {
              this.dataSource = {
                store: data
              };
            });
        });
  },
  methods: {
    signIn() {
      var key = this.$config.public.dataKey;
      fetch(`/${key}/schema.json`)
        .then(response => response.json())
        .then(schema => {
          this.schema = schema;
          fetch(`/${key}/data.json`)
            .then(response => response.json())
            .then(data => {
              this.dataSource = {
                store: data
              };
            });
        });
    }
  }
};
</script>

<style scoped>.dx-scrollable-scroll {
  visibility: visible !important;

}</style>