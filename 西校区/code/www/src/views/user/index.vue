<template>
  <div>
    <div class="top_register">
      <div class="top_register_main">
        <router-link to="/" class="login_logo"><img :src="'/static/images/logo.png'" /></router-link>
        <router-link to="/" class="login_goback">返回官网</router-link>
      </div>
    </div>
    <div class="register">
      <img :src="'/static/images/school.jpg'" />
      <div class="register_gary">
        <div class="rg">
          <span>学校用户登录入口</span>
          <dd>
            加入EIE League/EIE中国国际学校俱乐部，即刻获得俱乐部会员权益。<br />
            及时更新学校数据，获取学生家长/外教师资/排行评委的青睐与关注。
          </dd>
          <router-link to="/user/login">注册/登录</router-link>
        </div>
      </div>
    </div>
  </div>

</template>
<script>
import api from '@/api'
export default {
  layout: 'mine',
  created () {
    let self = this
    self.$store.commit('setTab', 6)
    api.GET('/Member/Online').then(function (res) {
      if (res === 1) {
        self.$router.replace('/user/mine')
      }
    }).catch(function (error) {
      console.log(error)
    })
  },
  mounted () {}
}
</script>
