<template>
  <div>
    <div class="goback">
      <router-link to="/user/mine"><img src="/static/images/goback.png" /></router-link>
    </div>
    <div class="login_gai">
      <span>绑定手机修改</span>
      <div class="yh_name">
        <dd>原手机验证</dd>
        <div class="hjh">
          <dd>+86 {{phone5}}</dd><input type="text"
                 maxlength="6"
                 v-model="phone6" />
          <p>后6位</p>
        </div>
      </div>
      <div class="yh_name">
        <dd>新手机号码：</dd>
        <div class="xhm">
          <input type="text"
                 v-model="changeForm.mobile" />
        </div>
      </div>
      <div class="yh_name">
        <dd>短信验证码：</dd>
        <div class="yzm">
          <input type="text"
                 maxlength="6"
                 v-model="changeForm.checkcode" />
          <a href="javascript:;"
             v-on:click="sendSms"
             v-if="countdown === 0">发送验证码</a>
          <a href="javascript:;"
             style="background: #dcdee0;color:rgb(82 76 76)"
             v-else>{{ countdown }} s 后重发</a>
        </div>
      </div>
        <a href="javascript:;"
           @click="changeMobile">确认修改</a>
    </div>
  </div>
</template>
<script>
import api from '@/api'
export default {
  layout: 'mine',
  data () {
    return {
      info: {},
      IMAGE_UPLOAD: process.env.BASE_UPLOAD,
      countdown: 0,
      phone6: '',
      changeForm: {
        old: '',
        mobile: '',
        sms: '',
        checkcode: ''
      }
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
    sendSms () {
      const that = this
      that.changeForm.old = this.phone5 + this.phone6
      api
        .GET('/Member/SendChangeMobileSms', that.changeForm)
        .then(function (res) {
          that.changeForm.sms = res.data
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
    },
    changeMobile () {
      const that = this
      api
        .POST('/Member/ChangeMobile', that.changeForm)
        .then(function (res) {
          that.info.mobile = that.changeForm.mobile
          that.$store.commit('setMember', that.info)
          that.phone6 = ''
          that.changeForm.mobile = ''
          that.changeForm.checkcode = ''
          setTimeout(() => {
            that.$message({
              message: '修改成功',
              type: 'success'
            })
          }, 10)
        })
        .catch(function (err) {
          console.log(err)
        })
    }
  },
  computed: {
    phone5 () {
      var mobile = this.info.mobile
      if (mobile > 5) {
        return mobile.substr(0, 5)
      } else {
        return '格式错误'
      }
    }
  }
}
</script>
