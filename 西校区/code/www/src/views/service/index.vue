<template>
  <div>
    <div class="top_zhengce pc">
      <div class="top_register_main">
        <router-link to="/"
                     class="login_logo"><img :src="'/static/images/logo.png'" /></router-link>
        <router-link to="/"
                     class="login_goback">返回官网</router-link>
      </div>
    </div>
    <div class="goback wap">
      <a href="javascript:;" @click="doback"><img src="/static/images/goback.png" /></a>
    </div>
    <div class="tezhi pc">
      <div class="tezhi_main">
        <div class="hanzi">
          <h1>服务协议</h1>
          <span>为更好地让您了解我们对个人信息的处理方式，我们制定了《服务条款》相关文件。 </span>
        </div>
      </div>
      <img src="/static/images/tz.jpg" />
    </div>
    <div class="guanyu_nav pc">
      <ul>
        <li class="on"><a href="javascript:;">服务协议</a></li>
      </ul>
    </div>
    <div class="zhengwen pc">
      <div class="zw_main"
           v-html="html">
      </div>
    </div>
    <div class="zhengwen wap">
      <div class="zw_main" style="padding:8px;"
           v-html="html">
      </div>
    </div>
  </div>
</template>
<script>
import api from '@/api'
export default {
  data () {
    return {
      html: ''
    }
  },
  created () {
    let self = this
    self.$store.commit('setTab', 6)
    api
      .GET('/Home/service')
      .then(function (res) {
        self.html = res
      })
      .catch(function (error) {
        console.log(error)
      })
  },
  mounted () {},
  methods: {
    doback () {
      console.log(this.$router)
      this.$router.go(-1)
      // console.log(rs)
    }
  }
}
</script>
