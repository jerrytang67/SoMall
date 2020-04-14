
<template>
   <view>
      orders
   </view>
</template>

<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";

@Component({})
export default class About extends Vue {
   get name() {
      return "TT";
   }

   created() {
      console.log("created");
   }
}
</script>

<style lang="scss" scoped>
</style>