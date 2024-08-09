<template>
  <div>
    <v-row>
      <v-col>
        <Signin @signIn="signIn" />
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <h2 class="text-xl">{{ $t('table') }}</h2>
        <p> 
          {{ $t('table_info_1') }}
          <Hint :tip="tip_filter"></Hint>. {{ $t('table_info_2') }}
          <Hint :tip="tip_group"></Hint>. {{ $t('table_info_3') }}
          <Hint :tip="tip_scroll" />. {{ $t('table_info_4') }} 
          (<p class="dx-icon dx-icon-columnchooser" style="font-size: 11pt;"></p>)
          {{ $t('table_info_5') }}
        </p>
      </v-col>
    </v-row>
    <v-row v-if="showAllBtn">
      <v-col>
        <v-btn prepend-icon="mdi-table" @click="showAll">{{ $t('table_show_all_data') }}</v-btn>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <DxDataGrid id="grid" ref="grid" :data-source="dataSource" :column-auto-width="true" :allow-column-resizing="true"
          :allow-column-reordering="true" height="600">

          <DxColumn v-for="c in schema" :key="c" :data-field="c.dataField" :caption="c.caption" :allow-fixing="true"
            :alignment="c.align == undefined ? 'left' : c.align" />

          <DxFilterRow :visible="true" />
          <DxColumnChooser :enabled="true" mode="select" />
          <DxSorting mode="multiple" />
          <DxScrolling mode="virtual" />
          <DxGrouping :context-menu-enabled="true" />
          <DxGroupPanel :visible="true" />
        </DxDataGrid>
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
      showAllBtn: false,
      tip_filter: "",
      tip_group: "",
      tip_scroll: ""
    };
  },
  mounted() {
    this.$data.tip_filter = this.$t('table_tip_filter');
    this.$data.tip_group = this.$t('table_tip_group');
    this.$data.tip_scroll = this.$t('table_tip_scroll');

    if ((new auth()).isSignedIn)
      this.signIn();
    else
      this.loadData();
  },
  methods: {
    signIn() {
      this.loadData(this.$config.public.dataKey);
    },
    loadData(basePath) {
      if (basePath == undefined)
        basePath = "";

      var self = this;
      var appURL = this.$config.public.appURL;

      fetch(`${appURL}/${basePath}/schema.json`)
        .then(response => response.json())
        .then(schema => {
          self.schema = schema;
          fetch(`${appURL}/${basePath}/data.json`)
            .then(response => response.json())
            .then(data => {
              self.dataSource = {
                store: data
              };
            })
            .then(() => {
              self.applyFilter();
            })
        });
    },
    applyFilter() {
      const queries = new URLSearchParams(window.location.search);
      var column = "";
      if (queries.has("column"))
        column = queries.get("column");
      var value = "";
      if (queries.has("value"))
        value = queries.get("value");

      var dataField = this.schema.find(x => x.caption == column).dataField;

      if (column == "" || value == "")
        return;

      this.dataSource = {
        store: this.dataSource.store,
        filter: [dataField, "=", value]
      }
      this.showAllBtn = true;
    },
    showAll() {
      this.dataSource = {
        store: this.dataSource.store,
        filter: null
      }
      this.showAllBtn = false;
    }
  }
};
</script>

<style scoped>
.dx-scrollable-scroll {
  visibility: visible !important;

}
</style>