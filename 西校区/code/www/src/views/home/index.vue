<template>
  <div>
    <banner-review v-if="info.loaded" />
    <banner-home v-else />
    <div class="why">
      <span>为什么选择我们</span>
      <div class="why_main">
        <ul>
          <li v-for="item in chooseUs"
              :key="item.id">
            <img :src="item.file_path" />
            <div class="ewli">
              <dd>{{item.title}}</dd>
              <p>合作发榜</p>
              <dt>
                {{item.description}}
              </dt>
            </div>
          </li>

        </ul>
      </div>
    </div>
    <div class="activities">
      <span>近期活动</span>
      <div class="activities_main">
        <div class="activities_left"
             v-if="activitys.length > 0">
         <router-link :to="'/activity/'+activitys[0].id">
            <img :src="activitys[0].file_path" />
            <div class="wenan">
              <dd>{{activitys[0].activity_name}}</dd>
              <dt>2021.09.01&emsp;Sat.&emsp;苏州.<br />
                活动人数&emsp;{{activitys[0].activity_qty}}人<br /><br />
                <p>{{activitys[0].description}}</p>
                <br />
                活动报名与须知&emsp;&emsp;&emsp;&gt;&gt;&gt;
              </dt>
            </div>
         </router-link>
        </div>
        <div class="activities_right">
          <ul>
            <template v-for="(item,index) in activitys">
              <li :key="item.id"
                  v-if="index < 3 && index >0">
                <router-link :to="'/activity/'+item.id">
                  <img :src="item.file_path" />
                  <dd>{{item.activity_name}}</dd>
                </router-link>
              </li>
            </template>
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import api from '@/api'

import BannerHome from '@/components/banner-home.vue'
import BannerReview from '@/components/banner-review.vue'
import BannerWap from '@/components/banner-wap-home.vue'

export default {
  data () {
    return {
      chooseUs: [],
      activitys: [],
      info: {}
    }
  },
  components: {
    BannerReview,
    BannerHome,
    BannerWap
  },
  created () {
    this.$store.commit('setTab', 0)
    let self = this
    api
      .GET('/judges/QuestionnaireInfo')
      .then(function (res) {
        self.info = res
      })
      .catch(function (error) {
        console.log(error)
      })
  },

  computed: {
    site () {
      return this.$store.state.home.siteInfo
    }
  },
  async mounted () {
    this.chooseUs = await api.GET('/Home/ChooseUs')
    this.activitys = await api.GET('/Home/Activitys')
  }
}
</script>
