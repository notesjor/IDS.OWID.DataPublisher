<template>
      <ejs-pivotview ref="pivotGrid" :height="height" :width="width" :dataSourceSettings="dataSourceSettings"
    :showFieldList="showFieldList" :showGroupingBar="showGroupingBar" :allowCalculatedField="allowCalculatedField">
  </ejs-pivotview>
</template>

<script>
import { PivotViewComponent, FieldList, GroupingBar, CalculatedField } from "@syncfusion/ej2-vue-pivotview";

export default {
  name: "App",
  // Declaring component and its directives.
  components: {
    "ejs-pivotview": PivotViewComponent,
    "ejs-pivotfieldlist": FieldList,
  },
  // Bound properties declaration.
  data() {
    return {
      dataSourceSettings: [],
      showFieldList: true,
      showGroupingBar: true,
      allowCalculatedField: true,
      height: '650px',
      width: '100%',
      renderMode: 'Fixed',
    };
  },
  provide: {
        pivotview: [GroupingBar, FieldList, GroupingBar, CalculatedField]
    },

  mounted() {
    var self = this;
    fetch('/pivot.schema')
      .then(response => response.json())
      .then(schema => {
        fetch('/public.json')
          .then(response => response.json())
          .then(data => {
            self.$data.dataSourceSettings = {
              values: schema,
              dataSource: data,
              expandAll: false,
              columns: [{ name: 'c20', caption: 'Land' }],
              values: [{ name: 'c01', caption: 'Match' }],
              rows: [{ name: 'c19', caption: 'Jahr' }],
            };
          });
      });
  },
};
</script>

<style>
@import "../node_modules/@syncfusion/ej2-base/styles/material.css";
@import "../node_modules/@syncfusion/ej2-inputs/styles/material.css";
@import "../node_modules/@syncfusion/ej2-buttons/styles/material.css";
@import "../node_modules/@syncfusion/ej2-dropdowns/styles/material.css";
@import "../node_modules/@syncfusion/ej2-lists/styles/material.css";
@import "../node_modules/@syncfusion/ej2-popups/styles/material.css";
@import "../node_modules/@syncfusion/ej2-navigations/styles/material.css";
@import "../node_modules/@syncfusion/ej2-grids/styles/material.css";
@import "../node_modules/@syncfusion/ej2-vue-pivotview/styles/material.css";

#pivotFields {
  width: 400px;
  margin-top: 20px;
}
</style>