<template>
  <div>
    <div class="houtai_right_mid pc">
      <div class="tx_gai ">
        <span>头像修改</span>
        <div class="tx_kuang">
          <el-avatar :size="122"
                     :src="info.head_path">
            <img src="https://cube.elemecdn.com/e/fd/0fc7d20532fdaf769a25683617711png.png" />
          </el-avatar>
          <el-upload class="avatar-uploader"
                     :action="IMAGE_UPLOAD"
                     :show-file-list="false"
                     :on-success="handleAvatarSuccess"
                     :before-upload="beforeAvatarUpload">
            <a style="width:122px;"
               href="javascript:;">上传头像</a>
          </el-upload>
        </div>
        <!-- <a href="javascript:;"
           @click="update"
           class="qrxg">确认修改</a> -->
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
          <dd>再次输入新密码：</dd>
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
      <div class="phone_gai">
        <span>绑定手机修改</span>
        <div class="yh_name">
          <dd>原手机号码验证</dd>
          <div class="hjh">
            <dd>+86 {{phone5}}</dd><input type="text"
                   maxlength="6"
                   v-model="phone6" />
            <p>输入原手机后6位验证</p>
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
    <div class="wap">
      <div class="houtai_real_top">
        <el-upload class="avatar-uploader"
                   :action="IMAGE_UPLOAD"
                   :show-file-list="false"
                   :on-success="handleAvatarSuccess"
                   :before-upload="beforeAvatarUpload">
          <el-avatar :size="100"
                     style="margin: 0 auto;"
                     :src="info.head_path">
            <img src="https://cube.elemecdn.com/e/fd/0fc7d20532fdaf769a25683617711png.png" />
          </el-avatar>
        </el-upload>
        <span>您好，{{info.nick_name}}</span>
        <p>{{info.school_name}}</p>
      </div>
      <div class="my_file_phone">
        <div class="someone">
          <ul>
            <li class="xz">
              <router-link to="/user/wap/account">账号管理</router-link>
            </li>
          </ul>
        </div>
        <div class="someone">
          <ul>
            <li>
              <router-link to="/user/wap/change">变更手机</router-link>
            </li>
          </ul>
        </div>
        <div class="someone">
          <ul>
            <li>
              <router-link to="/user/mine/info">信息维护</router-link>
            </li>
          </ul>
        </div>
        <div class="someone">
          <ul>

            <li>
              <router-link to="/user/mine/files">素材管理</router-link>
            </li>
          </ul>
        </div>
        <div class="someone">
          <ul>
            <li>
              <router-link to="/user/wap/help">帮助中心</router-link>
            </li>
          </ul>
        </div>
        <div class="someone">
          <ul>
            <li>
              <router-link to="/user/wap/feedback">意见反馈</router-link>
            </li>
          </ul>
        </div>
      </div>
      <a href="javascript:;"
         @click="logout"
         class="zhuxiao">退出登录</a>
    </div>
  </div>
</template>
<script>
import api from '@/api'
import util from '@/libs/util'
export default {
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
    this.$store.commit('setMemberTab', 0)
  },

  mounted () {
    let self = this
    api
      .GET('/Member/Info')
      .then(function (res) {
        self.info = res
      })
      .catch(function (error) {
        console.log(error)
        self.loading = false
      })
  },
  methods: {
    logout () {
      let self = this
      this.$confirm('即将退出登录, 是否继续?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning',
        customClass: 'el-message-rr'
      })
        .then(() => {
          util.cookies.remove('m-sessionid')
          setTimeout(() => {
            self.$router.push('/')
          }, 300)
        })
        .catch(() => {})
    },
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
    },
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
    },
    update () {
      const that = this
      api
        .POST('/Member/update', that.info)
        .then(function (res) {
          that.$store.commit('setMember', that.info)
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
    },
    handleAvatarSuccess (res, file) {
      this.info.head_id = res[0].fileid
      this.info.head_path = res[0].filepath
      this.update()
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
