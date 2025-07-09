<template>
  <el-select filterable
             clearable
             :disabled="disabled"
             v-model="currentValue"
             @change="handleChange"
             placeholder="请选择">
    <el-option v-for="item in options"
               :key="item.value"
               :label="item.label"
               :value="item.value">
    </el-option>
  </el-select>
</template>
<script>
export default {
  props: {
    value: {
      default: ''
    },
    action: {
      default: ''
    },
    disabled: {
      default: false
    }
  },
  data () {
    return {
      currentValue: '',
      options: []
    }
  },
  watch: {
    value: {
      handler (val) {
        // console.log(231)
        this.currentValue = val
      },
      immediate: true
    },
    action: {
      handler (val) {
        this.LoadOptions()
      },
      immediate: true
    }
  },
  created () {
    this.currentValue = this.value
    this.LoadOptions()
  },
  methods: {
    handleChange (val) {
      this.$emit('select-change', val)
    },
    Clear () {
      this.currentValue = ''
      this.value = ''
    },
    LoadOptions (val) {
      const that = this
      that.$api.GET(that.action).then(function (res) {
        var arr = []
        // if (that.all !== '') {
        //   arr.push({ label: that.all, value: '' })
        // }
        that.options = [...arr, ...res]
      }).catch(function (error) {
        console.log(error)
      })
    }
  }
}
</script>
