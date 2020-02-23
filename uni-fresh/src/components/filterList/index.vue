<template name="cate-filter">
   <view>
      <!-- grace filter start -->
      <view class="grace-filter" :style="{'position': fixed?'fixed':'relative','top':top}" id="grace-filter-header">
         <view class="items" :class="activeIndex==index?'text-red':'text-grey'" v-for="(item, index) in filters" :key="index" :data-index="index" @tap="changeSort">
            <text class="text-df" v-if="item.filterType!=2">{{ item.title }}</text>
            <text class="text-df" v-else>{{ activeOption && activeOption.name || item.title }}</text>
            <text class="grace-iconfont icon-arrow-down" v-if="item.filterType==2"></text>
            <text class="grace-iconfont" v-else-if="item.filterType==0"></text>
            <image src="/static/img/sort0.png" mode="widthFix" v-else-if="activeIndex!=index"></image>
            <image src="/static/img/sort2.png" mode="widthFix" v-else-if="activeIndex==index && activeAscState"></image>
            <image src="/static/img/sort1.png" mode="widthFix" v-else-if="activeIndex==index"></image>
         </view>
         <view class="text-xxl padding-lr margin-top-sm" @tap="changeShape" v-if="showShape">
            <text :class="['text-red', curShapeValue == 2 ? 'cuIcon-apps' : 'cuIcon-list']"></text>
         </view>
         <!-- 下拉选项 -->
         <template v-if="activeIndex == index && showOption">
            <view class='grace-filter-options' v-for="(item, index) in filters" :key="index">
               <view :class="[activeOption && (opt.value ===  activeOption.value) ? 'option current' : 'option']" :data-index="index" :data-optindex="optIndex" v-for="(opt, optIndex) in item.options||[]" :key="optIndex+100000" @tap="changeSort">
                  {{opt.name}}<text class="cuIcon-right text-gray"></text>
               </view>
            </view>
         </template>
      </view>
   </view>
</template>

<script lang="ts">
import {
   Component,
   Vue,
   Inject,
   Prop,
   Watch,
   Ref
} from "vue-property-decorator";
import api from "@/utils/api";
@Component({})
export default class FilterList extends Vue {
   @Prop({ default: false }) fixed!: boolean;

   @Prop({ default: "0upx" }) top!: string; // 固定至顶部时离顶部的距离

   @Prop({ required: true }) filters!: any[];

   @Prop({ default: 0 }) initIndex!: number;

   @Prop({ default: 2 }) shapeValue!: number; // 显示的模板类型值，1：为单列，2：为多列

   @Prop({ default: true }) showShape!: boolean; // 是否显示模板类型选择

   activeIndex = 0;
   // 默认升序
   activeAscState = true;
   //默认两列布局图标
   curShapeValue = 2;
   showOption = false;
   activeOption: any = null;

   created() {
      this.curShapeValue = this.shapeValue;
      this.activeIndex = this.initIndex;
   }

   private changeSort(e: any) {
      const index = parseInt(e.currentTarget.dataset.index);
      const optIndex = e.currentTarget.dataset.optindex;
      const options = this.filters[index].options;
      let option = null;
      if (options && optIndex) {
         option = options[parseInt(optIndex)];
      }

      const curActiveItem = this.filters[index];
      const filterType = curActiveItem.filterType || 0;
      // 点击索引等于自身
      if (this.activeIndex == index) {
         //禁用升降序，则直接返回无需处理
         if (curActiveItem.filterType == 0) return;
      }

      // 升降序
      if (curActiveItem.filterType == 1) {
         if (this.activeIndex == index) {
            //排序顺序颠倒
            this.activeAscState = !this.activeAscState;
         } else {
            this.activeAscState = curActiveItem.initAscState || false;
         }
      }
      // 下拉选项
      else if (curActiveItem.filterType == 2) {
         console.log("curActiveItem.filterType:", curActiveItem.filterType);
         if (this.activeIndex != index) {
            // 点击的不是本列
            this.showOption = true;
            //this.activeOption=null
         } else if (this.activeIndex == index && option == null) {
            // 点击的本列下拉箭头，则切换显示状态并返回
            this.showOption = !this.showOption;
            return;
         } else {
            // 点击了选项，则关闭显示以便显示查询结果
            this.showOption = false;
            this.activeOption = option;
            console.log("this.activeOption:", this.activeOption);
         }
      }
      this.activeIndex = index;
      if (curActiveItem.filterType == 2 && this.showOption) {
         // 下拉显示面板，不进行过滤
         return;
      }
      const sortField =
         curActiveItem.value !== undefined ? curActiveItem.value : index;
      var data = {
         sort: sortField,
         order: this.activeAscState ? 1 : -1,
         option: (this.activeOption && this.activeOption.value) || null
      };
      //console.log("this.activeOption",data)
      this.$emit("sortChanged", data);
   }

   private changeShape() {
      this.curShapeValue = this.curShapeValue == 1 ? 2 : 1;
      this.$emit("shapeChanged", this.curShapeValue);
   }
}
</script>

<style lang="scss" scoped>
@import "../../graceUI/graceUI.css";
@import "../../colorui/icon.css";
</style>
