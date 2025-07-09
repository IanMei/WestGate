<template>
  <div>

    <div class="school_top">
      <div class="school_top_main">
        <img :src="'/static/images/school.jpg'" />
        <div class="xx_mid">
          <h5>{{school.school_name}}<br />
            {{school.en_name}}</h5>
          <dd>{{school.address}}</dd>
          <dd>{{school.address_en}}</dd>
        </div>
        <div class="mark">
          <div class="mark_main">
            <span>{{school.point}}</span>
            <dd>胡润评分</dd>
          </div>
          <a href="javascript:;"
             @click="show=true"
             class="zhaocha">寻求建议</a>
          <a :href="school.home_page"
             target="_blank">访问官网&emsp;&gt;</a>
        </div>
      </div>
    </div>

    <div class="huidi"
         v-show="show"
         @click="show=false">
      <div class="huidi_main">
        <div class="dingwei">
          <div class="huidi_left">
            <span>{{school.link_man}}</span>
            <div class="contact">
              <dd>TEL</dd>
              <dt>{{school.service_tel}}</dt>
            </div>
            <div class="contact">
              <dd>MAIL</dd>
              <dt>{{school.email}}</dt>
            </div>
          </div>
          <img :src="school.head_path" />
        </div>
        <a href="javascript:;"
           @click="show=false">点击空白处返回</a>
      </div>
    </div>

    <div class="schol">
      <div class="schol_main">
        <span>数据概览</span>
        <ul>
          <li>
            <img :src="'/static/images/xues.png'" />
            <div class="xx_sli">
              <p>学生</p>
              <div class="xx_sli_next">
                <dd>学生总规模</dd>
                <dt>{{school.stu_qty}}人</dt>
              </div>
              <div class="xx_sli_next">
                <dd>招生计划</dd>
                <dt>{{school.recruit_qty}}人</dt>
              </div>
            </div>
          </li>
          <li>
            <img :src="'/static/images/jiaoshi.png'" />
            <div class="xx_sli">
              <p>教师</p>
              <div class="xx_sli_next">
                <dd>师生配比</dd>
                <dt>{{school.tas_rate}}%</dt>
              </div>
              <div class="xx_sli_next">
                <dd>外教占比</dd>
                <dt>{{school.ft_qty}}%</dt>
              </div>
            </div>
          </li>
          <li>
            <img :src="'/static/images/xuefei.png'" />
            <div class="xx_sli">
              <p>费用</p>
              <div class="xx_sli_next">
                <dd>每年学费</dd>
                <dt>{{school.tuition_cny}}&nbsp;CNY<br />{{school.tuition_usd}}&nbsp;USD</dt>
              </div>
              <div class="xx_sli_next">
                <dd>每年住宿</dd>
                <dt>{{school.stay_cny}}&nbsp;CNY<br />{{school.stay_usd}}&nbsp;USD</dt>
              </div>
            </div>
          </li>
          <li>
            <img :src="'/static/images/luqu.png'" />
            <div class="xx_sli">
              <p>录取</p>
              <div class="xx_sli_next">
                <dd>录取比例</dd>
                <dt>{{school.enroll_rate}}%</dt>
              </div>
              <div class="xx_sli_next">
                <dd>报名人数</dd>
                <dt>{{school.enroll_qty}}人</dt>
              </div>
            </div>
          </li>
        </ul>
      </div>
    </div>

    <div class="scl">
      <div class="scl_main">
        <div class="honnor">
          <span>荣誉奖项</span>
          <ul>
            <li v-for="item in school.honors"
                :key="item.id">
              <dd>{{item.honor_year}}</dd>
              <dt>{{item.honor_desc}}</dt>
            </li>
          </ul>
        </div>
        <div class="shebei">
          <span>配套设施</span>
          <ul>
            <li v-if="school.facilities1.length > 0">
              <dd>体育配套</dd>
              <dt v-for="(item,index) in school.facilities1"
                  :key="index">{{item}}</dt>
            </li>
            <li v-if="school.facilities2.length > 0">
              <dd>艺术配套</dd>
              <dt v-for="(item,index) in school.facilities2"
                  :key="index">{{item}}</dt>
            </li>
            <li v-if="school.facilities3.length > 0">
              <dd>学术配套</dd>
              <dt v-for="(item,index) in school.facilities3"
                  :key="index">{{item}}</dt>
            </li>
          </ul>
        </div>
      </div>
    </div>
    <div class="xxzs">
      <div class="xxzs_main">
        <span>学校综述</span>
        <p v-html="school.content"></p>
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
      school: {
        facilities1: [],
        facilities2: [],
        facilities3: []
      }
    }
  },
  created () {
    this.$store.commit('setTab', 2)
  },

  async mounted () {
    this.school = await api.GET('/Home/School', { id: this.$route.params.id })
  },
  watch: {
    $route () {
      let self = this
      api
        .GET('/Home/School', { id: this.$route.params.id })
        .then(function (res) {
          self.school = res
        })
        .catch(function (error) {
          console.log(error)
          self.loading = false
        })
    }
  }
}
</script>
