
<template>
   <view>
      Hello {{name}}
   </view>
</template>

<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";

@Component
export default class Shop extends Vue {
   async onload(query: any) {
      console.log(query);
   }

   get name() {
      return "TT";
   }

   created() {}
}
</script>

<style lang="scss" scoped>
</style>