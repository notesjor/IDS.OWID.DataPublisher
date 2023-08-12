<template>
  <div>
    <ejs-grid ref="grid" :columns="schema" :dataSource="data" :allowSorting="true" :allowGrouping="true"
      :allowFiltering="true" :allowPaging="true" :allowResizing="true" :pageSettings="pageSettings">
    </ejs-grid>
  </div>
</template>
    
<script>
import { GridComponent, ColumnsDirective, ColumnDirective, Sort, Group, Filter, Page, Resize } from '@syncfusion/ej2-vue-grids';

export default {
  name: "ViewGrid",
  provide: {
    grid: [Sort, Group, Filter, Page, Resize],
  },
  components: {
    'ejs-grid': GridComponent,
    'e-columns': ColumnsDirective,
    'e-column': ColumnDirective
  },
  data() {
    return {
      schema: [],
      data: [],
      pageSettings: { pageSize: 15, pageSizes: ['10', '15', '20', '25', '50', '100', '250', '500', '1000', 'All'] }
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
    
<style>
@import "@syncfusion/ej2-base/styles/material.css";
@import "@syncfusion/ej2-inputs/styles/material.css";
@import "@syncfusion/ej2-buttons/styles/material.css";
@import "@syncfusion/ej2-dropdowns/styles/material.css";
@import "@syncfusion/ej2-lists/styles/material.css";
@import "@syncfusion/ej2-popups/styles/material.css";
@import "@syncfusion/ej2-popups/styles/material.css";
@import "@syncfusion/ej2-navigations/styles/material.css";
@import "@syncfusion/ej2-grids/styles/material.css";
</style>