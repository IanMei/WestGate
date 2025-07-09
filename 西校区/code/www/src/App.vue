<template>
  <div>
    <template v-if='!$route.meta.nonloayout'>
      <div class="top pc">
        <div class="top_2">
          <div class="top_main">
            <div class="top_logo">
              <router-link to="/"><img :src="info.file_logo" /></router-link>
            </div>
            <div class="top_nav">
              <ul>
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
                  <router-link to="/user">用户登录</router-link>
                </li>
                <li :class="tab === 7 ? 'on':''">
                  <router-link to="/judges">评委登录</router-link>
                </li>
              </ul>
            </div>
            <div class="top_login">
              <span>语言</span>
              <div class="flag"><img src="/static/images/e.png" /></div>
              <select>
                <option>
                  <dd>中文CN</dd>
                </option>
              </select>
            </div>
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
      <router-view />
      <div class="foot">
        <div class="foot_main">
          <div class="part">
            <span>战略合作伙伴</span>
            <ul>
              <li v-for="item in info.details"
                  :key="item.id"><a target="_blank"
                   :title="item.link_name"
                   :ref="item.link_name"
                   :href="item.link_url"> <img :src="item.file_path" /></a></li>
            </ul>
          </div>
          <div class="huiyuan">
            <span>优质会员</span>
            <ul>
              <li v-for="item in info.hotschool"
                  :key="item.id">
                <router-link :to="'/school/'+item.id">
                  <dd>{{item.school_name}}</dd>
                </router-link>
              </li>
            </ul>
          </div>
          <div class="lx_rh">
            <span>联系入会</span>
            <div class="lx_left">
              <dd>Tel：{{info.service_tel}}</dd>
              <dd>E-mail：{{info.email}}</dd>
              <dd>Add：{{info.company}}</dd>
            </div>
            <div class="lx_right">
              <img :src="info.file_qr" />
              <dt>微信公众号</dt>
            </div>
          </div>
          <div class="beian"><a href="javascrjpt:;">备案号：{{info.copyright}} {{info.record}} </a></div>
        </div>
      </div>
    </template>
    <router-view v-if='$route.meta.nonloayout'></router-view>
  </div>
</template>
<script>
import api from '@/api'
export default {
  data () {
    return {
      showmenu: false,
      info: {}
    }
  },
  mounted () {
    let self = this
    api
      .GET('/Home/SiteInfo')
      .then((res) => {
        self.info = res
        self.$store.commit('setSiteInfo', res)
      })
      .catch(function (error) {
        console.log(error)
      })
  },
  computed: {
    tab () {
      return this.$store.state.home.activeTab
    }
  }
}
</script>
