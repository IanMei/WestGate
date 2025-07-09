<template>

  <div>
    <div class="top_houtai pc">
      <div class="top_houtai_main">
        <a href="index.html"
           class="houtai_logo"><img :src="'/static/images/logo.png'" /></a>
        <h5>评审系统</h5>
      </div>
    </div>

    <div class="houtai_left pc">
      <ul>
        <li :class="tab===0?'xo':'' ">
          <router-link to="/judges/mine">登录信息</router-link>
        </li>
        <li :class="tab===1?'xo':'' ">
          <router-link to="/judges/mine/info">评委信息</router-link>
        </li>
        <li :class="tab===2?'xo':'' ">
          <router-link to="/judges/mine/questionnaire">问卷评审</router-link>
        </li>
      </ul>
      <div class="houtai_bottom ">
        <a href="javascript:;"
           @click="logout"
           class="message"><img :src="'/static/images/xinfeng.png'" />
          <!-- <div class="redpoint"></div> -->
        </a>
        <a href="javascript:;"
           @click="logout"
           class="tuichu">退出登录</a>
      </div>
    </div>

    <div class="houtai_right pc">
      <router-view />
      <div class="houtai_real_right">
        <div class="houtai_real_top">
          <el-avatar :size="136" :src="info.file_path"
                     style="margin-left:40px;"
                     >
            <img src="https://cube.elemecdn.com/e/fd/0fc7d20532fdaf769a25683617711png.png" />
          </el-avatar>
          <span>早上好，{{info.nick_name}}</span>
          <p>{{info.position}}</p>
        </div>
        <div class="help">
          <span>帮助中心</span>
          <router-link :to="'/judges/mine/help/'+item.id"
                       v-for="item in helps"
                       :key="item.id">{{item.title}}</router-link>
        </div>
        <div class="feedback">
          <span>意见反馈</span>
          <textarea placeholder="请输入您的意见，我们将尽快解决..."
                    v-model="feedback.message"
                    maxlength="200"></textarea>
          <button @click="doFeedback">提交</button>
        </div>
      </div>
    </div>
    <div class="top99 wap" v-if="tab === 0">
      <router-link class="top_img"
                   to="/"><img :src="sinfo.file_logo" /></router-link>
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
    <div class="goback wap" v-else>
      <router-link to="/judges/mine"><img src="/static/images/goback.png" /></router-link>
    </div>
    <div class="qishiwu wap" v-if="tab === 0"></div>
    <div class="wap"> <router-view /></div>
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
      helps: [],
      feedback: {
        message: ''
      }
    }
  },
  created () {
    let self = this
    api
      .GET('/Judges/Info')
      .then(function (res) {
        self.$store.commit('setJudges', res)
      })
      .catch(function (error) {
        console.log(error)
        self.loading = false
      })
  },
  async mounted () {
    this.helps = await api.GET('/Member/Help')
  },

  computed: {
    tab () {
      return this.$store.state.judges.judgestab
    },
    info () {
      return this.$store.state.judges.judgesInfo
    },
    sinfo () {
      return this.$store.state.home.siteInfo
    }
  },
  methods: {
    logout () {
      let self = this
      this.$confirm('即将退出登录, 是否继续?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      })
        .then(() => {
          util.cookies.remove('j-sessionid')
          setTimeout(() => {
            self.$router.push('/')
          }, 300)
        })
        .catch(() => {})
    },
    doFeedback () {
      let self = this
      self.loading = true
      api
        .POST('/Judges/Feedback', self.feedback)
        .then(function (res) {
          self.feedback.message = ''
          self.loading = false
          setTimeout(() => {
            self.$message({
              message: '提交成功',
              type: 'success'
            })
          }, 10)
        })
        .catch(function (error) {
          console.log(error)
          self.loading = false
        })
    }
  }
}
</script>
