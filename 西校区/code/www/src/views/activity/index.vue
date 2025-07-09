<template>
  <div>
    <banner-activity />
    <div class="threeannouncement">
      <div class="threeannouncement_main">
        <ul>
          <li v-for="item in activitys"
              :key="item.id">
            <router-link :to="'/activity/'+item.id">
              <img :src="item.file_path" />
              <span>{{item.activity_name}}</span>
              <div class="kk">
                <dd>{{item.activity_date}}</dd>
                <dd>{{item.activity_address}}</dd>
                <dt>活动人数&emsp;{{item.activity_qty}}人</dt>
                <p>{{item.description}}</p>
              </div>
            </router-link>
          </li>
        </ul>
      </div>
    </div>

  </div>
</template>
<script>
import api from '@/api'
import BannerActivity from '@/components/banner-activity.vue'
export default {
  data () {
    return {activitys: []}
  },
  components: {
    BannerActivity
  },
  created () {
    this.$store.commit('setTab', 4)
  },
  async mounted () {
    this.activitys = await api.GET('/Home/Activitys?size=3')
  }
}
</script>
