<template>
  <div>

    <div class="pingwei_banner">
      <img :src="banners[0].file_path"
           class="pw_bg pc"
           v-if="banners.length > 0" />
      <img :src="banners[0].file_path"
           class="pw_bg wap"
           v-if="banners.length > 0" />
      <div class="ayang">
        <img :src="info.file_path"
             class="dtt" />
        <h5>{{info.nick_name}}</h5>
      </div>
    </div>

    <div class="scl">
      <div class="scl_main">
        <div class="honnor" v-if="info.resume.length > 0">
          <span>履历</span>
          <ul>
            <li v-for="item in info.resume" :key="item.id">
              <dd>{{item.honor_year}}</dd>
              <dt>{{item.honor_desc}}</dt>
            </li>
          </ul>
        </div>
        <div class="honnor"  v-if="info.honors.length > 0">
          <span>荣誉</span>
          <ul>
            <li v-for="item in info.honors" :key="item.id">
              <dd>{{item.honor_year}}</dd>
              <dt>{{item.honor_desc}}</dt>
            </li>
          </ul>
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
      banners: [],
      info: {
        honors: [],
        resume: []
      }
    }
  },
  created () {
    this.$store.commit('setTab', 3)
  },
  computed: {
    site () {
      return this.$store.state.home.siteInfo
    }
  },
  async mounted () {
    this.banners = await api.GET('/Home/Banners', { type: '06' })
    this.info = await api.GET('/Home/Judges', { id: this.$route.params.id })
  }
}
</script>
