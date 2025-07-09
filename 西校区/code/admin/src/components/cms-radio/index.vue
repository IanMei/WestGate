<template>
  <el-radio-group v-model="value">
    <el-radio style="margin:5px;"
              :label="item.key"
              @change="handleChange"
              v-for="item in options"
              :key="item.key">{{item.text}}</el-radio>
  </el-radio-group>
</template>

<script>
export default {
  name: 'cms-radio',
  data: function () {
    return {
      value: '',
      options: []
    }
  },
  props: {
    action: {
      type: String,
      default: '',
      required: true
    },
    val: {
      type: String,
      default: '',
      required: true
    }
  },
  created () {
    this.value = this.state
    this.LoadOptions()
  },
  methods: {
    handleChange (val) {
      this.$emit('select-change', val)
    },
    LoadOptions (val) {
      const that = this
      that.$api.GET(that.action).then(function (res) {
        that.options = res
      }).catch(function (error) {
        console.log(error)
      })
    },
    v () {
      return this.value
    }
  },
  watch: {
    val (val) {
      this.value = val
    }
  }
}
</script>
