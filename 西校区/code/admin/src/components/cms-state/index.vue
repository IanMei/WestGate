<template>
  <span slot="reference" style="margin-left:calc((100% - 22px)/2);">
    <i
      v-if="disabled"
      class="fa fa-hourglass-start"
      style="font-size: 14px; line-height: 32px; color: #909399;margin-left:5px; "
    ></i>
    <span @click="handleClick">
      <i
        v-if="!disabled && currentValue"
        aria-hidden="true"
        class="fa fa-check-circle"
        style="font-size: 26px; line-height: 32px; color: rgb(103, 194, 58);"
      ></i>
      <i
        v-if="!disabled && !currentValue"
        aria-hidden="true"
        class="fa fa-times-circle"
        style="font-size: 26px; line-height: 32px; color: rgb(245, 108, 108);"
      ></i>
    </span>
  </span>
</template>

<script>
export default {
  props: {
    value: {
      default: false
    },
    action: {
      default: ''
    }
  },
  data () {
    return {
      currentValue: false,
      disabled: false
    }
  },
  watch: {
    value: {
      handler (val) {
        this.currentValue = val
      },
      immediate: true
    }
  },
  methods: {
    handleClick () {
      // 这里先赋值是为了和 TypeControl 使用一样的 handleChange
      this.currentValue = !this.currentValue
      this.handleChange(this.currentValue)
    },
    handleChange (val) {
      this.disabled = true
      const that = this
      that.$api.GET(that.action).then(function (res) {
        setTimeout(() => {
          that.disabled = false
          that.$emit('change', val)
        }, 300)
      }).catch(function (error) {
        that.disabled = false
        that.currentValue = !that.currentValue
        console.log(error)
      })
    }
  }
}
</script>
