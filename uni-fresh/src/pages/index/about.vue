
<template>
   <view class="appContainer">
      Hello {{name}}
   </view>
</template>

<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import { BaseView } from "../baseView";
import api from "../../utils/api";

@Component
export default class About extends BaseView {
   get name() {
      return "TT";
   }

   created() {}
}
</script>

<style lang="scss" scoped>
</style>