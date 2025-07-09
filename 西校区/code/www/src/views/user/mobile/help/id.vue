<template>
  <div>
    <div class="goback">
      <router-link to="/user/wap/help"><img src="/static/images/goback.png" /></router-link>
    </div>
    <div class="my_file_phone" style="margin:10px;" v-html="info.content">

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
