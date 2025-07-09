<template>
  <div>
    <div class="goback">
      <router-link to="/judges/mine"><img src="/static/images/goback.png" /></router-link>
    </div>
    <div class="my_file_phone">
      <div class="my_file_phone_main">
        <div class="file_phone_right">
          <div class="feedback">
            <textarea maxlength="200" v-model="feedback.message" placeholder="请输入您的问题，200字"></textarea>
            <button @click="doFeedback">提交</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import api from '@/api'
export default {
  layout: 'mine',
  data () {
    return {
      loading: false,
      feedback: {
        message: ''
      }
    }
  },
  methods: {
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
