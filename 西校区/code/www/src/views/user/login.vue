<template>
  <div>

    <div class="top_register pc">
      <div class="top_register_main">
        <router-link to="/user"
                     class="login_logo"><img :src="'/static/images/logo.png'" /></router-link>
        <router-link to="/"
                     class="login_goback">返回官网</router-link>
      </div>
    </div>

    <div class="register pc">
      <img :src="'/static/images/school.jpg'" />
      <div class="register_gary">
        <div class="denglu2">
          <h5>学校登录</h5>
          <ul>
            <li class="denglu_ul_li"><input type="text"
                     placeholder="手机号"
                     v-model="form.uid"
                     maxlength="20" /></li>
            <li class="denglu_ul_li"><input type="password"
                     placeholder="密码"
                     v-model="form.pwd"
                     @keyup.enter="doLogin"
                     maxlength="20" /></li>
          </ul>
          <div class="jilao">
            <input type="checkbox"
                   v-model="form.remember" />已阅读并同意
            <router-link to="/service">《服务协议》</router-link>
          </div>

          <template v-if="form.remember">
            <a href="javascript:;"
               @click="doLogin"
               v-if="!loading">登录</a>
            <a style="background: #c0c4cc;"
               v-if="loading">登录中...</a>
            <div class="sibaixiu">
              <dd>还未注册？
                <router-link to="/judges/register">立即注册&emsp;&gt;</router-link>
              </dd>
            </div>
          </template>

          <template v-else>
            <a style="background: #c0c4cc;">登录</a>
            <div class="sibaixiu">
              <dd>还未注册？
                <router-link to="/judges/register">立即注册&emsp;&gt;</router-link>
              </dd>
            </div>
          </template>
        </div>
      </div>
    </div>

    <div class="top99 wap">
      <router-link class="top_img"
                   to="/"><img :src="info.file_logo" /></router-link>
      <div class="navv"
           @click="showmenu = !showmenu"><span></span><span></span><span></span><span></span></div>
      <transition name="el-zoom-in-top">
          <div class="top99_nav"
               v-show="showmenu">
            <ul @click="showmenu = !showmenu">
              <li :class="tab === 0 ? 'on':''">
                <router-link to="/">主页</router-link>
              </li>
              <li :class="tab === 1 ? 'on':''">
                <router-link to="/schoolwiki">School-Wiki</router-link>
              </li>
              <li :class="tab === 2 ? 'on':''">
                <router-link to="/school">会员学校</router-link>
              </li>
              <li :class="tab === 3 ? 'on':''"
                  v-show="info.questionnaire">
                <router-link to="/review">会员校长</router-link>
              </li>
              <!--<li><a href="resources.html">学生社团</a></li>-->
              <li :class="tab === 4 ? 'on':''">
                <router-link to="/activity">活动公告</router-link>
              </li>
              <li :class="tab === 5 ? 'on':''">
                <router-link to="/about">关于我们</router-link>
              </li>
              <li :class="tab === 6 ? 'on':''">
                <router-link to="/user/login">用户登录</router-link>
              </li>
              <li :class="tab === 7 ? 'on':''">
                <router-link to="/judges">评委登录</router-link>
              </li>
            </ul>
          </div>
        </transition>
    </div>
    <div class="qishiwu wap"></div>
    <div class="denglu wap">
      <h5>学校登录</h5>
      <ul>
        <li class="denglu_ul_li"><input type="text"
                 placeholder="手机号"
                 v-model="form.uid"
                 maxlength="20" /></li>
        <li class="denglu_ul_li"><input type="password"
                 placeholder="密码"
                 v-model="form.pwd"
                 @keyup.enter="doLogin"
                 maxlength="20" /></li>
      </ul>
      <div class="jilao">
        <input type="checkbox"
               v-model="form.remember" />已阅读并同意
        <router-link to="/service">《服务协议》</router-link>
      </div>
      <template v-if="form.remember">
            <a href="javascript:;"
               @click="doLogin"
               v-if="!loading">登录</a>
            <a style="background: #c0c4cc;"
               v-if="loading">登录中...</a>
            <div class="sibaixiu">
              <dd>还未注册？
                <router-link to="/judges/register">立即注册&emsp;&gt;</router-link>
              </dd>
            </div>
          </template>

          <template v-else>
            <a style="background: #c0c4cc;">登录</a>
            <div class="sibaixiu">
              <dd>还未注册？
                <router-link to="/judges/register">立即注册&emsp;&gt;</router-link>
              </dd>
            </div>
          </template>
    </div>
  </div>
</template>
<script>
import api from '@/api'
import util from '@/libs/util'
export default {
  layout: 'mine',
  data () {
    return {
      showmenu: false,
      loading: false,
      form: {
        uid: '',
        pwd: '',
        remember: false
      }
    }
  },
  created () {
    let self = this
    self.$store.commit('setTab', 6)
    api
      .GET('/member/Online')
      .then(function (res) {
        if (res === 1) {
          self.$router.replace('/user/mine')
        }
      })
      .catch(function (error) {
        console.log(error)
      })
  },
  methods: {
    doLogin () {
      let self = this

      if (!self.form.remember) {
        self.$message.error('请阅读服务条款!')
        return
      }
      self.loading = true
      api
        .POST('/Member/Login', self.form)
        .then(function (res) {
          util.cookies.set('m-sessionid', res)
          setTimeout(function () {
            self.loading = false
            self.$router.push('/user/mine')
          }, 300)
        })
        .catch(function (error) {
          console.log(error)
          self.loading = false
        })
    }
  },
  computed: {
    info () {
      return this.$store.state.home.siteInfo
    },
    tab () {
      return this.$store.state.home.activeTab
    }
  }
}
</script>
