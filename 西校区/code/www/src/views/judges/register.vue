<template>
  <div>
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
    <div class="register">
      <img src="/static/images/school.jpg"
           class="pc" />
      <div class="register_gary">
        <div class="denglu">
          <h5>评委注册</h5>
          <ul>
            <li class="denglu_ul_li"><input type="text"
                     placeholder="昵称"
                     v-model="form.nick_name"
                     maxlength="20" /></li>
            <li class="denglu_ul_li"><input type="text"
                     placeholder="工作单位"
                     v-model="form.company"
                     maxlength="30" /></li>
            <li class="denglu_ul_li"><input type="text"
                     placeholder="职位"
                     v-model="form.position"
                     maxlength="20" /></li>
            <li class="denglu_ul_li"><input type="text"
                     placeholder="请输入手机号"
                     v-model="form.mobile"
                     maxlength="11" /></li>
            <li class="denglu_ul_li"><input type="password"
                     placeholder="请设置密码"
                     v-model="form.user_pwd"
                     maxlength="20"
                     autocomplete="off"
                     readonly
                     onfocus="this.removeAttribute('readonly')" /></li>
            <li class="denglu_ul_li">
              <div class="linshi"><input type="text"
                       maxlength="6"
                       v-model="form.checkcode"
                       placeholder="验证码" />
                <a href="javascript:;"
                   class="send"
                   v-on:click="sendSms"
                   v-if="countdown === 0">发送验证码</a>
                <a href="javascript:;"
                   class="send"
                   style="background: #dcdee0;color:rgb(82 76 76)"
                   v-else>{{ countdown }} s 后重发</a>
              </div>
            </li>
          </ul>
          <div class="jilao">
            <input type="checkbox"
                   v-model="form.remember"
                   checked="checked"
                   value="Bike" />已阅读并同意<a href="#">《**服务协议》</a>
          </div>
          <a href="javascript:;"
             @click="doRegister">注册</a>
        </div>

      </div>
    </div>
  </div>

</template>
<script>
import api from '@/api'
export default {
  data () {
    return {
      countdown: 0,
      showmenu: false,
      uploadstate: '办学许可证',
      form: {
        nick_name: '',
        company: '',
        position: '',
        mobile: '',
        user_pwd: '',
        checkcode: '',
        sms: '',
        remember: false
      }
    }
  },
  fetch ({ store, params }) {
    store.commit('setTab', 6)
  },
  methods: {
    doRegister: function () {
      const that = this
      if (!that.form.remember) {
        that.$message({
          message: '请阅读服务条款',
          type: 'error'
        })
      } else {
        api
          .POST('/Judges/Register', that.form)
          .then(function (res) {
            that.$router.push('/Judges')
            setTimeout(() => {
              that.$message({
                message: '注册成功，请登录',
                type: 'success'
              })
            }, 10)
          })
          .catch(function (err) {
            console.log(err)
          })
      }
    },
    sendSms () {
      const that = this
      api
        .GET('/Judges/SendSms', {
          mobile: that.form.mobile
        })
        .then(function (res) {
          that.form.sms = res.data
          that.$message({
            message: '发送成功',
            type: 'success'
          })
          let second = 60
          that.countdown = second
          const timer = setInterval(() => {
            second--
            that.countdown = second
            if (second > 0) {
            } else {
              clearInterval(timer)
            }
          }, 1000)
        })
        .catch(function (err) {
          console.log(err)
        })
    }
  },
  computed: {
    info () {
      return this.$store.state.home.siteInfo
    },
    tab () {
      return this.$store.state.judges.judgestab
    }
  }
}
</script>
