<template>
  <div>
    <banner-activity />
    <div class="news">
      <div class="news_main">
        <h5>{{info.activity_name}}</h5>
        <dt>活动时间：{{info.activity_date}}</dt>
        <dt>活动地点：{{info.activity_address}}</dt>
        <dt>活动人数：{{info.activity_qty}}人</dt>
        <a href="javascript:;"
           class="kuaia"
           @click="enroll=true">活动报名</a>
        <div class="rel_news">
          <img :src="info.file_path" />
          <dt v-html="info.content">
          </dt>
        </div>
      </div>
    </div>

    <div class="huidi"
         v-show="enroll"
         @click="enroll=false">
      <div class="huidi_main"
           style="z-index:2;"
           @click.stop="enroll=enroll">
        <div class="dingwei">
          <span>活动报名</span>
          <input type="text"
                 placeholder="姓名"
                 v-model="enrollForm.user_name"
                 maxlength="20" />
          <input type="text"
                 placeholder="单位"
                 v-model="enrollForm.company"
                 maxlength="30" />
          <input type="text"
                 placeholder="职务"
                 v-model="enrollForm.position"
                 maxlength="20" />
          <input type="text"
                 placeholder="手机号码"
                 v-model="enrollForm.mobile"
                 maxlength="11" />
          <button @click="doEnroll"
                  v-if="!loading">提交</button>
          <button style="background: #5e5b5b;"
                  v-if="loading">提交报名信息...</button>
        </div>
        <a  @click="enroll=false" href="javascript:;">点击关闭</a>
      </div>
    </div>
  </div>
</template>
<script>
import api from '@/api'
import BannerActivity from '@/components/banner-activity.vue'
export default {
  components: {
    BannerActivity
  },
  data () {
    return {
      info: {},
      enroll: false,
      loading: false,
      enrollForm: {
        user_name: '',
        company: '',
        position: '',
        mobile: '',
        id: this.$route.params.id
      }
    }
  },
  created () {
    this.$store.commit('setTab', 4)
  },

  async mounted () {
    this.info = await api.GET('/Home/Activity', { id: this.$route.params.id })
  },
  methods: {
    doEnroll () {
      let self = this
      self.loading = true
      api.POST('/Home/Enroll', self.enrollForm)
        .then(function (res) {
          self.$notify({
            title: '提示',
            message: '报名成功',
            type: 'success'
          })
          setTimeout(function () {
            self.loading = false
            self.enroll = false
            self.enrollForm = {
              user_name: '',
              company: '',
              position: '',
              mobile: '',
              id: self.$route.params.id
            }
          }, 300)
        })
        .catch(function (error) {
          console.log(error)
          self.loading = false
        })
    }
  }
}
</script>
