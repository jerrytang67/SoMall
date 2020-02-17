
<template>
   <view>
      Hello {{name}}
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
   }
}
</script>

<style lang="scss" scoped>
</style>