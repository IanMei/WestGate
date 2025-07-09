
<template>
  <div>
    <div class="week_banner pc">
      <img :src="'/static/images/qixing_1920.jpg'" />
      <h5>每周名校</h5>
      <span>{{interview.school_name}}</span>
    </div>
    <div class="about_banner wap">
      <img src="/static/images/qixing.jpg">
      <h5>每周名校</h5>
      <span>{{interview.school_name}}</span>
    </div>
    <div class="week">
      <div class="week_main">
        <h5>校长专访</h5>
        <div class="week_left"
             v-html="interview.content">
        </div>
        <div class="week_right">
          <div class="week_words">
            <div class="week_chaierman">
              <img :src="interview.file_path" />
              <dd>常务校长</dd>
              <dt>Mark Bishop</dt>
            </div>
            <div class="school_mid">
              <span>{{interview.school_name}}</span>
              <div class="score">
                <dd>胡润评分</dd>
                <p>{{interview.point}}</p>
              </div>
              <div class="score">
                <dd>招生对象</dd>
                <dt>{{interview.type_name}}</dt>
              </div>
            </div>
            <div class="week_others">
              <ul>
                <li>
                  <dd>学校地址：</dd>
                  <dt>{{interview.address}}</dt>
                </li>
                <li>
                  <dd>招生规模：</dd>
                  <dt>{{interview.recruit_qty}} 名/年</dt>
                </li>
                <li>
                  <dd>住宿标准：</dd>
                  <dt>{{interview.stay_cny}} CNY / {{interview.stay_usd}} USD</dt>
                </li>
                <li>
                  <dd>每年学费：</dd>
                  <dt>{{interview.tuition_cny}} CNY / {{interview.tuition_usd}} USD</dt>
                </li>
                <li>
                  <dd>配套设施：</dd>
                  <dt> {{interview.facilities}}</dt>
                </li>
              </ul>
            </div>
          </div>
          <a href="javascript:;"
             @click="show=true"
             class="zj">寻求专家意见</a>
          <router-link :to="'/school/'+interview.school_id">
            点击前往详情
          </router-link>
        </div>
      </div>
    </div>
    <div class="huidi"
         v-show="show"
         @click="show=false">
      <div class="huidi_main">
        <div class="dingwei">
          <div class="huidi_left">
            <span>{{interview.link_man}}</span>
            <div class="contact">
              <dd>TEL</dd>
              <dt>{{interview.service_tel}}</dt>
            </div>
            <div class="contact">
              <dd>MAIL</dd>
              <dt>{{interview.email}}</dt>
            </div>
          </div>
          <img src="/static/images/renxiang.jpg" />
        </div>
        <a href="javascript:;"
           @click="show=false">点击空白处返回</a>
      </div>
    </div>
  </div>
</template>
<script>
import api from '@/api'
export default {
  data () {
    return {
      show: false,
      interview: {}
    }
  },
  created () {
    this.$store.commit('setTab', 2)
  },
  async mounted () {
    this.interview = await api.GET('/Home/Interview')
  }
}
</script>
