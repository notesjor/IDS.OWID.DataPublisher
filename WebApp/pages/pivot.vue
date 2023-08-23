<template>

</template>

<script>

export default {
  name: "App",
  // Declaring component and its directives.
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
