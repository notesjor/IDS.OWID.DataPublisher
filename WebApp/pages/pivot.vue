<template>
  <div>
    <v-row>
      <v-col>
        <Signin @signIn="signIn" />
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <h2 class="text-xl">{{ $t('pivot') }}</h2>
        <p> {{ $t('pivot_profile_info') }} </p>
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
        <p> {{ $t('pivot_table_info_1') }}
          (
        <p class="dx-icon dx-icon-columnchooser" style="font-size: 11pt;"></p>)
        {{ $t('pivot_table_info_2') }}</p>
      </v-col>
    </v-row>
    <v-row style="margin-top: -30px;">
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
        <h2 class="text-xl">{{ $t('visualization') }}</h2>
        <p>{{ $t('visualization_info') }}</p>
      </v-col>
    </v-row>
    <v-row style="margin-top: -10px;">
      <v-col cols="4">
        <v-combobox :label="$t('visualization_mode')" variant="outlined" :items="vizModes"
          v-model="vizMode"></v-combobox>
      </v-col>
      <v-col>
        <p style="font-size: 9pt; margin-top: 15px;">{{ $t('visualization_mode_info') }}</p>
      </v-col>
    </v-row>
    <v-row style="margin-top: -30px;">
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
    <v-row>
      <v-col>
        <br>
        <hr />
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <Cite />
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

import Chart from "devextreme/viz/chart";

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
    DxExport,
    Chart
  },
  data() {
    return {
      vizMode: {},
      vizModes: [],
      fieldsOriginal: [],
      dataSource: {
        fields: [],
        store: [],
      },
      customizeTooltip(args) {
        return {
          html: `${args.argumentText} / ${args.seriesName}: ${args.originalValue}`,
        };
      },
    };
  },
  mounted() {
    this.$data.vizModes = [
      { title: this.$t("visualization_chart_bars"), value: "bar" },
      { title: this.$t("visualization_chart_line"), value: "line" },
      { title: this.$t("visualization_chart_area"), value: "area" },
      { title: this.$t("visualization_chart_scatter"), value: "scatter" },
      { title: this.$t("visualization_chart_bubble"), value: "bubble" },
      { title: this.$t("visualization_chart_bars_stacked"), value: "stackedbar" },
      { title: this.$t("visualization_chart_line_stacked"), value: "stackedline" },
      { title: this.$t("visualization_chart_area_stacked"), value: "stackedarea" },
      { title: this.$t("visualization_chart_bars_percent"), value: "fullstackedbar" },
      { title: this.$t("visualization_chart_line_percent"), value: "fullstackedline" },
      { title: this.$t("visualization_chart_area_percent"), value: "fullstackedarea" },
    ];
    this.$data.vizMode = { title: this.$t("visualization_chart_bars"), value: "bar" };

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
      this.loadData(this.$config.public.dataKey);
    },
    setProfile(id) {
      var self = this;
      var query = this.$config.public.pivotProfiles[id].query;

      var fields = JSON.parse(JSON.stringify(self.$data.fieldsOriginal));

      var tmp = [];
      query.forEach(q => {
        for (var i = 0; i < fields.length; i++) {
          var field = fields[i];
          if (q.dataField == field.dataField) {
            tmp.push({ ...field, ...q });
            fields.splice(i, 1);
            break;
          }
        }
      });

      self.$data.dataSource = {
        fields: tmp.concat(fields),
        store: self.$data.dataSource.store
      };
    },
    loadData(basePath) {
      if (basePath == undefined)
        basePath = "";

      var self = this;
      var appURL = this.$config.public.appURL;

      fetch(`${appURL}/${basePath}/schema.json`)
        .then(response => response.json())
        .then(schema => {
          fetch(`${appURL}/${basePath}/data.json`)
            .then(response => response.json())
            .then(data => {
              self.$data.fieldsOriginal = schema;
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