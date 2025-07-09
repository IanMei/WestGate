<template>
  <el-cascader v-model="value"
               :clearable="clearable"
               :options="options"
               :props="expandTrigger"
               v-on:change="handleChange"></el-cascader>
</template>

<script>
export default {
  data: function () {
    return {
      value: [],
      options: [],
      loading: false,
      loadCompleted: false
    }
  },
  props: {
    sv: {
      type: Array,
      default: () => { return [] }
    },
    mode: { // editor编辑模式 view查询浏览模式
      type: String,
      default: 'editor'
    },
    action: {
      type: String,
      default: ''
    },
    recordid: {
      type: Number,
      default: -1
    },
    clearable: {
      type: Boolean,
      default: false
    }
  },
  mounted () {
    const that = this
    that.loading = true
    var ops = []
    var act = ''
    if (that.action === '') {
      that.loading = false
      return
    } else {
      if (that.mode === 'editor') {
        if (that.action.indexOf('?') >= 0) {
          act = that.action + '&id=' + that.recordid
        } else {
          act = that.action + '?id=' + that.recordid
        }
        ops.push({ value: '000000', label: '--- 根目录 ---' })
        that.value = ['000000']
      } else if (that.mode === 'view') {
        ops.splice({ value: '', label: '--- 全部 ---' })
        if (that.action.indexOf('?') >= 0) {
          act = that.action + '&leaf=3'
        } else {
          act = that.action + '?leaf=3'
        }
      }
    }
    that.$api.GET(act).then(function (res) {
      that.options = [...ops, ...res]
      that.value = that.sv
      that.loadCompleted = true
      setTimeout(function () { that.loading = false }, 300)
    }).catch(function (error) {
      console.log(error)
      setTimeout(function () { that.loading = false }, 300)
    })
  },
  methods: {
    handleChange (val) {
      this.value = val
      this.$emit('select-change', val)
    },
    val () {
      return this.value
    }
  },
  computed: {
    expandTrigger () {
      if (this.mode === 'editor') {
        return { expandTrigger: 'hover', checkStrictly: true }
      } else {
        return { expandTrigger: 'hover' }
      }
    }
  },
  watch: {
    sv: {
      handler (val, oldVal) {
        console.log(val + '|' + oldVal)
        if (val && this.loadCompleted) {
          this.value = val
        }
      },
      deep: true
    }
  }
}
</script>
