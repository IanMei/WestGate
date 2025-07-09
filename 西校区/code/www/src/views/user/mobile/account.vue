<template>
  <div>
    <div class="goback">
      <router-link to="/user/mine"><img src="/static/images/goback.png" /></router-link>
    </div>
    <div class="login_gai">
      <span>登录信息修改</span>
      <div class="yh_name">
        <dd>昵称：</dd>
        <input type="text"
               autocomplete="false"
               v-model="info.nick_name"
               maxlength="20" />
      </div>
      <div class="yh_name">
        <dd>新密码：</dd>
        <input type="password"
               maxlength="20"
               autocomplete="off"
               readonly
               onfocus="this.removeAttribute('readonly')"
               v-model="info.npwd" />
        <p>支持英文大小写/数字/下划线</p>
      </div>
      <div class="yh_name">
        <dd>确认新密码：</dd>
        <input type="password"
               maxlength="20"
               autocomplete="off"
               readonly
               onfocus="this.removeAttribute('readonly')"
               v-model="info.cpwd" />
      </div>
      <a href="javascript:;"
         @click="updatePassword">确认修改</a>
    </div>
  </div>
</template>
<script>
import api from '@/api'
export default {
  layout: 'mine',
  data () {
    return {
      info: {}
    }
  },
  created () {
    let self = this
    api
      .GET('/Member/Info')
      .then(function (res) {
        self.info = res
        self.loading = false
      })
      .catch(function (error) {
        console.log(error)
        self.loading = false
      })
  },
  methods: {
    updatePassword () {
      const that = this
      if (that.info.npwd === '') {
        that.$message.error('新密码不能空!')
        return
      }
      if (that.info.cpwd === '') {
        that.$message.error('再次输入新密码!')
        return
      }
      if (that.info.cpwd !== that.info.npwd) {
        that.$message.error('两次密码不一致!')
        return
      }
      api
        .POST('/Member/update', that.info)
        .then(function (res) {
          that.$store.commit('setMember', that.info)
          that.info.cpwd = ''
          that.info.npwd = ''
          setTimeout(() => {
            that.$message({
              message: '更新成功',
              type: 'success'
            })
          }, 10)
        })
        .catch(function (err) {
          console.log(err)
        })
    }
  }
}
</script>
