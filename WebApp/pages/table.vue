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
        <p> Diese Tabellen-Ansicht gibt Ihnen einen direkten Zugriff auf die Daten. Sie können die Tabelle durchsuchen,
          filtern und gruppieren.</p>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <DxDataGrid id="grid" ref="grid" :data-source="dataSource">
          <DxFilterRow :visible="true" />
        </DxDataGrid>
      </v-col>
    </v-row>
  </div>
</template>
    
<script>
import 'devextreme/dist/css/dx.material.blue.light.compact.css';
import { DxDataGrid, DxColumn, DxFilterRow } from 'devextreme-vue/data-grid';

export default {
  name: "ViewGrid",
  components: {
    DxDataGrid,
    DxColumn,
    DxFilterRow
  },
  data() {
    return {
      schema: [],
      dataSource: {
        store: [
          {
            id: 10248,
            region: 'North America',
            country: 'United States of America',
            city: 'New York',
            amount: 1740,
            date: new Date('2013-01-06'),
          }, {
            id: 10249,
            region: 'North America',
            country: 'United States of America',
            city: 'Los Angeles',
            amount: 850,
            date: new Date('2013-01-13'),
          }, {
            id: 10250,
            region: 'North America',
            country: 'United States of America',
            city: 'Denver',
            amount: 2235,
            date: new Date('2013-01-07'),
          }
        ]
      }
    };
  },
  mounted() {
    fetch('/grid.schema')
      .then(response => response.json())
      .then(data => { this.schema = data; });

    fetch('/public.json')
      .then(response => response.json())
      .then(data => { this.data = data; })
      .then(() => { this.$refs.grid.autoFitColumns(); });
  }
};
</script>
