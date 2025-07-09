<template>
  <div>
    <div class="houtai_right_mid"
         v-if="info.loaded">
      <div class="wenjuan">
        <span>{{info.questionnaire_title}}<br />调查问卷</span>
        <!-- <dd>
          尊敬的 <strong> {{judges.nick_name}}</strong> 评委先生/女士:<br /><br />

        </dd> -->
      </div>
      <p v-html="info.questionnaire_content"
         style="margin-bottom: 30px; padding:7px; "></p>
      <div class="index_l" >
        <span>从这里选出你认为最好的学校，每个区域不超过5所！</span>
        <div class="yidao"
             v-for="(item,index) in info.list"
             :key="index">
          <dd>{{index + 1}}.{{item.title}}</dd>
          <ul>
            <li>
              <dd>学校名称</dd>
              <dt>推荐理由</dt>
            </li>
            <li v-for="(rs,i) in item.result" :key="i">
                <input type="text"
                     maxlength="50"
                     v-model="rs.school_name"
                     class="schoolname" />
              <input type="text"
                     maxlength="200"
                     v-model="rs.reason"
                     class="reaseon" />
            </li>

          </ul>
        </div>
        <button v-if="info.loaded !== true">已结束</button>
        <button v-else @click="submit">点击提交</button>
      </div>
      <div class="redwords"
           v-if="info.loaded">问卷提交截止时间剩余：{{info.surplus}}</div>
    </div>
    <div v-else
         style="margin-top: 20px; margin-left: 20px;font-size: 16px;">
      筹划中...
    </div>
  </div>
</template>
<script>
import api from '@/api'
export default {
  data () {
    return {
      info: {
        loaded: false
      }
    }
  },
  created () {
    let self = this
    this.$store.commit('setJudgesTab', 2)
    api
      .GET('/judges/QuestionnaireInfo')
      .then(function (res) {
        self.info = res
      })
      .catch(function (error) {
        console.log(error)
      })
  },
  methods: {
    submit () {
      let self = this
      api
        .POST('/judges/Questionnaire', self.info)
        .then(function (res) {
          setTimeout(() => {
            self.$message({
              message: '提交成功',
              type: 'success'
            })
          }, 10)
        })
        .catch(function (error) {
          console.log(error)
        })
    }
  },
  computed: {
    judges () {
      return this.$store.state.judges.judgesInfo
    }
  }
}
</script>
