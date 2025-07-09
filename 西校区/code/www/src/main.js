// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import api from '@/api/installapi'
import store from '@/store'
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'

// import util from '@/libs/util'

Vue.config.productionTip = false
Vue.use(api)

Vue.use(ElementUI)
/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  store,
  components: { App },
  template: '<App/>',
  mounted () {
    // 持久化用户信息
    // store.dispatch('LoadUser')
    // util.cookies.set('gobackpage', this.$route.name)
  },
  methods: {

  },
  watch: {
    $route (to, from) {
    //   const that = this
    //   var token = util.cookies.get('token')
    //   if (!to.meta.member) {

    //   } else {
    //     if (token === '' || !token) {
    //       if (to.name != null) {
    //         util.cookies.set('gobackpage', to.name)
    //       } else {
    //         util.cookies.set('gobackpage', 'home')
    //       }
    //       setTimeout(() => {
    //         window.location.href = process.env.BASE_DOMAIN + 'OAuth2/UserInfoCallback?t=0'
    //       }, 100)
    //     }
    //   }
    //   if (!to.meta.manage) {
    //   } else {
    //     if (token === '' || !token) {
    //       setTimeout(() => {
    //         window.location.href = process.env.BASE_DOMAIN + 'OAuth2/UserInfoCallback?t=1'
    //       }, 100)
    //     } else {
    //       if (!store.state.account.user || store.state.account.user.manageid === 0) {
    //         that.$router.push('/manage/login?token=' + token)
    //       }
    //     }
    //   }
    }
  }
})
