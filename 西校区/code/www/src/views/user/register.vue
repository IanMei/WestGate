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
        <div class="denglu">
          <h5>学校注册</h5>
          <ul>
            <li class="denglu_ul_li">
              <input type="text"
                     v-model="form.school_name"
                     maxlength="50"
                     placeholder="学校名称" />
            </li>

            <li class="denglu_ul_li"><input type="text"
                     v-model="form.referrer"
                     maxlength="20"
                     placeholder="推荐人" /></li>
            <li>
              <dd style="overflow:hidden;text-overflow:ellipsis;white-space:nowrap;">{{uploadstate}}</dd>
              <el-upload class="avatar-uploader"
                         :action="IMAGE_UPLOAD"
                         :show-file-list="false"
                         :on-success="handleAvatarSuccess"
                         :before-upload="beforeAvatarUpload">
                <el-button style="margin-top:7px;margin-left:10px;">点击上传</el-button>
              </el-upload>
            </li>
            <li class="denglu_ul_li"><input type="text"
                     v-model="form.mobile"
                     maxlength="11"
                     placeholder="请输入手机号" /></li>
            <li class="denglu_ul_li"><input type="password"
                     v-model="form.user_pwd"
                     maxlength="20"
                     placeholder="请设置密码" /></li>
            <li class="denglu_ul_li">
              <div class="linshi"><input type="text"
                       v-model="form.checkcode"
                       maxlength="6"
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
                   value="Bike" />已阅读并同意<a href="#">《**服务协议》</a>
          </div>
          <a href="javascript:;"
             @click="doRegister">注册</a>
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
      <h5>学校注册</h5>
      <ul>
        <li class="denglu_ul_li">
          <input type="text"
                 v-model="form.school_name"
                 maxlength="50"
                 placeholder="学校名称" />
        </li>

        <li class="denglu_ul_li"><input type="text"
                 v-model="form.referrer"
                 maxlength="20"
                 placeholder="推荐人" /></li>
        <li>
          <dd style="margin-left:9.5%;width: calc(50% - 15px);overflow:hidden;text-overflow:ellipsis;white-space:nowrap;">{{uploadstate}}</dd>
          <el-upload class="avatar-uploader"
                     :action="IMAGE_UPLOAD"
                     :show-file-list="false"
                     :on-success="handleAvatarSuccess"
                     :before-upload="beforeAvatarUpload">
            <el-button style="margin-top:8px;margin-left:10px;">点击上传</el-button>
          </el-upload>
        </li>
        <li class="denglu_ul_li"><input type="text"
                 v-model="form.mobile"
                 maxlength="11"
                 placeholder="请输入手机号" /></li>
        <li class="denglu_ul_li"><input type="password"
                 v-model="form.user_pwd"
                 maxlength="20"
                 placeholder="请设置密码" /></li>
        <li class="denglu_ul_li">
          <div class="linshi"><input type="text"
                   v-model="form.checkcode"
                   maxlength="6"
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
               v-model="form.remember" />已阅读并同意<a href="#">《**服务协议》</a>
      </div>
      <a href="javascript:;"
         @click="doRegister">注册</a>
    </div>

  </div>
</template>
<script>
import api from '@/api'
export default {
  layout: 'mine',
  data () {
    return {
      IMAGE_UPLOAD: process.env.BASE_UPLOAD,
      countdown: 0,
      showmenu: false,
      uploadstate: '办学许可证',
      form: {
        file_id: -1,
        school_name: '',
        referrer: '',
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
          .POST('/Member/Register', that.form)
          .then(function (res) {
            that.$router.push('/user/login')
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
        .GET('/Member/SendSms', {
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
    },
    handleAvatarSuccess (res, file) {
      this.uploadstate = file.name
      this.form.file_id = res[0].fileid
    },
    beforeAvatarUpload (file) {
      const isJPG = file.type === 'image/jpeg' || file.type === 'image/png'
      const isLt2M = file.size / 1024 / 1024 < 2
      if (!isJPG) {
        this.$message.error('只能是 JPG|PNG 格式!')
      }
      if (!isLt2M) {
        this.$message.error('大小不能超过 2MB!')
      }
      return isJPG && isLt2M
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
<style >
</style>
