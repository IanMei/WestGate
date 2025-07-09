<template>
  <div>
    <div id="banner_tabs"
         class="flexslider pc"
         style="height:940px;">
      <el-carousel height="940px"
                   :interval="5000">
        <el-carousel-item v-for="item in banners"
                          :key="item.banner_id">
          <a><img width="100%"
                 height="940px"
                 :style="'background:url('+ item.file_path +') no-repeat center;'"
                 :src="item.file_path "></a>
        </el-carousel-item>
      </el-carousel>
      <div class="flex_pingshen"
           style="z-index: 22;">
        <div class="flex_pingshen_mid">
          <h5>{{info.questionnaire_title}}</h5>
          <span>评选阶段启动</span>
          <p>{{info.reciewdate}}</p>
          <dd>
            尊敬的各位评委先生/女士您好，诚邀您加入《{{info.questionnaire_title}}》评审活动，并烦请您担任本年排名的评委。通过以下链接即可前往信息登记与问卷领取网址。<br>
            我们承诺评委关键个人信息保密和调研问卷保密，确保排名公正性。
          </dd>
          <router-link to="/judges">评委入口</router-link>
        </div>
      </div>
    </div>
     <div  class="wap"
         style="height:274px;">
      <el-carousel height="274px"
                   :interval="5000">
        <el-carousel-item v-for="item in banners"
                          :key="item.banner_id">
          <a><img width="100%"
                 height="274px"
                 :style="'background:url('+ item.file_path +') no-repeat center;'"
                 :src="item.file_path "></a>
        </el-carousel-item>
      </el-carousel>
      <div class="flex_pingshen"
           style="z-index: 22;">
        <div class="flex_pingshen_mid">
          <h5>{{info.questionnaire_title}}</h5>
          <span>评选阶段启动</span>
          <p>{{info.reciewdate}}</p>
          <router-link to="/judges">评委入口</router-link>
        </div>
      </div>
    </div>
    <!-- <el-carousel height="276px" class="wap"
                 :interval="5000">
      <el-carousel-item v-for="item in banners"
                        :key="item.banner_id">
        <a><img width="100%"
               height="276px"
               :style="'background:url('+ item.file_path +') no-repeat center;'"
               :src="item.file_path "></a>
      </el-carousel-item>
    </el-carousel> -->
  </div>
</template>
<script>
import api from '@/api'
export default {
  data () {
    return {
      loading: true,
      info: {},
      banners: [
        {
          banner_id: 1,
          html_url: '',
          file_path: '/static/images/school.jpg',
          content:
            '建于2007年,是由包氏家族，为纪念包玉刚先生对中国教育的无私奉献以及在香港回归过程中所起的重要作用，而捐资创建的一所私立双语国际学校。<br /><br />《2020胡润百学·中国国际学校百强》第一名。<br /><br />本期内容：常务校长 Mark Bishop 专访&emsp;&emsp;&emsp;&gt;&gt;&gt;',
          banner_title: '上海民办包玉刚实验学校'
        }
      ]
    }
  },
  mounted () {
    let self = this
    api
      .GET('/Home/Banners?type=03')
      .then((res) => {
        self.banners = res
        setTimeout(() => {
          self.loading = false
        }, 100)
      })
      .catch(function (error) {
        console.log(error)
      })

    api
      .GET('/judges/QuestionnaireInfo')
      .then(function (res) {
        self.info = res
      })
      .catch(function (error) {
        console.log(error)
      })
  }
}
</script>
