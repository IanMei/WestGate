<template>
  <div class="houtai_right_mid">
    <div class="bbwom">
      <span>{{info.title}}</span>
      <dd v-html="info.content">
      </dd>
    </div>
  </div>
</template>
<script>
import api from '@/api'
export default {
  data () {
    return {
      info: {}
    }
  },
  async created () {
    this.info = await api.GET('/Member/Helpinfo', { id: this.$route.params.id })
  },
  watch: {
    '$route' (to, from) {
      let self = this
      api.GET('/Member/Helpinfo', { id: to.params.id }).then(function (res) {
        self.info = res
      })
        .catch(function (error) {
          console.log(error)
          self.loading = false
        })
    }
  }
}
</script>
