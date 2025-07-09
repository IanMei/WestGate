<template>
  <el-drawer :title="title"
             size="500px" :show-close="false"
             v-model="value"
             ref="dialog"
             direction="rtl">
    <div class="texs">
      <slot></slot>
    </div>
    <template #title >
     <span class="texs">{{title}}</span>
      <div>
        <el-button type="primary"
                   @click="confirm">确认</el-button>
        <el-button @click="close">取消</el-button>
      </div>
    </template>
  </el-drawer>
</template>

<script>
export default {
  props: {
    value: {
      type: Boolean,
      default: false,
      required: true
    },
    title: {
      type: String,
      default: '弹出框'
    }
  },
  methods: {
    close () {
      this.value = false
    },
    confirm () {
      this.emit('confirm')
    }
  }

}
</script>

<style lang="scss" scoped>
.texs {
  text-align: left;
}
</style>
