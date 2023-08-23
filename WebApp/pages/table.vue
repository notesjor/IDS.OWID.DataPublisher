<template>
  <div>
    <div id="output" style="margin: 30px;"></div>
  </div>
</template>
    
<script>
export default {
  name: "ViewGrid",
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
