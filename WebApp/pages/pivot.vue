<template>
  <div>
    <v-row>
      <v-col>
        <Signin @signIn="signIn" />
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <h2 class="text-xl">Pivot-Tabelle</h2>
        <p> Die Pivot-Tabelle erlaubt einen interaktiven Auswertung und Kreuz-Vergleiche.
          Für das Datenset wurden folgende Beispiel-Analysen hinterlegt:
          Die Visualisierung ist direkt mit der oben angezeigten Pivot-Tabelle verknüpft. Sie können zudem die
          Darstellungsmodi wie folgt ändern:</p>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <v-chip v-for="(profile, i) in pivotProfiles" :key="i" style="margin-right: 10px;" @click="setProfile(i)">
          {{ profile.label }}
        </v-chip>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <p> Alternativ können Sie aufch auf das Einstellungs-Symbol
          (
        <p class="dx-icon dx-icon-columnchooser" style="font-size: 11pt;"></p>)
        oben links in der Pivot-Tabelle klicken und eigene Vergleiche und Fitlerungen vorzunehmen.</p>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <DxPivotGrid id="pivotgrid" ref="grid" :data-source="dataSource" :allow-sorting-by-summary="true"
          :allow-filtering="true" :show-borders="true" :show-column-grand-totals="true" :show-row-grand-totals="true"
          :show-row-totals="false" :show-column-totals="false">
          <DxFieldChooser :enabled="true" :height="400" />
        </DxPivotGrid>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <h2 class="text-xl">Visualisierung</h2>
        <p>Die Visualisierung ist direkt mit der oben angezeigten Pivot-Tabelle verknüpft. Sie können zudem die
          Darstellungsmodi wie folgt ändern:</p>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <v-combobox label="Darstellungsmodus" variant="outlined" :items="vizModes" v-model="vizMode"></v-combobox>
        <p style="font-size: 9pt; margin-top: -15px;">Bitte beachten Sie: Nicht alle Darstellungsmodi funktionieren für
          alle Datenkombinationen. Probieren Sie ggf. verschiedene Settings aus.</p>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <DxChart ref="chart">
          <DxTooltip :enabled="true" :customize-tooltip="customizeTooltip" />
          <DxAdaptiveLayout :width="450" />
          <DxSize :height="600" />
          <DxCommonSeriesSettings :type="vizMode.value" />
          <DxExport :enabled="true" :printing-enabled="false" />
        </DxChart>
      </v-col>
    </v-row>
  </div>
</template>
<script>
import 'devextreme/dist/css/dx.material.blue.light.compact.css';

import auth from "../korapJsClient/auth.js";

import {
  DxChart,
  DxAdaptiveLayout,
  DxCommonSeriesSettings,
  DxSize,
  DxTooltip,
  DxExport
} from 'devextreme-vue/chart';

import {
  DxPivotGrid,
  DxFieldChooser
} from 'devextreme-vue/pivot-grid';

export default {
  created() {
  },
  components: {
    DxChart,
    DxAdaptiveLayout,
    DxCommonSeriesSettings,
    DxSize,
    DxTooltip,
    DxPivotGrid,
    DxFieldChooser,
    DxExport
  },
  data() {
    return {
      vizMode: { title: "Balken", value: "bar" },
      vizModes: [
        { title: "Balken", value: "bar" },
        { title: "Linien", value: "line" },
        { title: "Flächen", value: "area" },
        { title: "Scatter", value: "scatter" },
        { title: "Bubble", value: "bubble" },
        { title: "Balken (gestapelt)", value: "stackedbar" },
        { title: "Linien (gestapelt)", value: "stackedline" },
        { title: "Flächen (gestapelt)", value: "stackedarea" },
        { title: "Balken (auf 100%)", value: "fullstackedbar" },
        { title: "Linien (auf 100%)", value: "fullstackedline" },
        { title: "Flächen (auf 100%)", value: "fullstackedarea" },
      ],
      dataSource: {
        fields: [],
        store: []
        ,
      },
      customizeTooltip(args) {
        return {
          html: `${args.argumentText} / ${args.seriesName}: ${args.originalValue}`,
        };
      },
    };
  },
  mounted() {
    if ((new auth()).isSignedIn)
      this.signIn();
    else
      this.loadData("");
  },
  computed: {
    pivotProfiles() {
      return this.$config.public.pivotProfiles;
    },
  },
  methods: {
    signIn() {
      this.loadData("/" + this.$config.public.dataKey);
    },
    setProfile(id) {
      var self = this;
      var query = JSON.parse(this.$config.public.pivotProfiles[id].query);

      var ds = self.$data.dataSource;
      var fields = ds.fields;

      console.log("original");
      console.log(fields);

      var tmp = [];
      query.forEach(q => {
        for (var i = 0; i < fields.length; i++) {
          var field = fields[i];
          if (q.dataField == field.dataField) {
            tmp.push({...field, ...q});
            fields.splice(i, 1);
            break;
          }
        }
      });

      console.log("mod")
      console.log(tmp);
      console.log(fields);

      tmp = tmp.concat(fields);
      ds.fields = tmp;

      console.log("final");
      console.log(ds);

      self.$data.dataSource = ds;
    },
    loadData(basePath) {
      if (basePath == undefined)
        basePath = "";

      var self = this;
      fetch(`${basePath}/schema.json`)
        .then(response => response.json())
        .then(schema => {
          fetch(`${basePath}/data.json`)
            .then(response => response.json())
            .then(data => {
              self.$data.dataSource = {
                fields: schema,
                store: data
              };

              const pivotGrid = self.$refs.grid.instance;
              const chart = self.$refs.chart.instance;
              pivotGrid.bindChart(chart, {
                dataFieldsDisplayMode: 'splitPanes',
                alternateDataFields: false,
              });
              self.setProfile(0);
            });
        });
    }
  }
};
</script>
<style>
#pivotgrid {
  margin-top: 20px;
}

.currency {
  text-align: center;
}
</style>