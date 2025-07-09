<template>
  <div>
    <div class="goback">
      <router-link to="/user/mine"><img src="/static/images/goback.png" /></router-link>
    </div>
    <div class="my_file_phone" style="margin-top:10px;">
      <div class="someone">
        <ul>
          <li class="xz"
              v-for="item in list"
              :key="item.id">
              <router-link :to="'/user/wap/help/'+item.id">{{item.title}}</router-link>
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>
<script>
import api from '@/api'
export default {
  layout: 'mine',
  data () {
    return {
      list: []
    }
  },
  async created () {
    let self = this
    self.list = await api.GET('/Member/Help')
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
