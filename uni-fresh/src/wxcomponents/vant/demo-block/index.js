Component({

  options: {
    multipleSlots: true // 在组件定义时的选项中启用多slot支持
  },
  properties: {
    more: null,
    title: String,
    padding: Boolean,
    line: Boolean
  },
  externalClasses: ['custom-class']
});