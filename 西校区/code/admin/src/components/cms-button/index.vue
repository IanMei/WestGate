<template>
  <el-button size="mini"
             v-on:click="handleClick()"
            :type="type" :icon="icon" v-if="auth" :loading="loading"
            >{{text}}</el-button>
</template>

<script>
import { mapState } from 'vuex'
export default {
  data: function () {
    return {
    }
  },
  props: {
    authcode: { // 权限编号
      type: String,
      default: ''
    },
    text: { // 显示文本
      type: String,
      default: '按钮'
    },
    type: { // 类型 primary|success|info|warning|danger
      type: String,
      default: 'none'
    },
    icon: { // 图标
      type: String,
      default: ''
    }

  },
  mounted () {
  },
  methods: {
    handleClick () {
      this.$emit('click')
    }
  },
  computed: {
    ...mapState('d2admin/user', [
      'menus'
    ]),
    ...mapState('d2admin/page', [
      'loading'
    ]),
    auth () {
      if (this.authcode === '') {
        return false
      }
      if (!this.menus || this.menus.length === 0) {
        return false
      }
      return this.menus.indexOf(this.authcode) >= 0
    }
  }
}
</script>
