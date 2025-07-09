<template>
  <div>
    <div id="banner_tabs"
         class="flexslider pc"
         style="height:400px;">
      <el-carousel height="400px"
                   :interval="5000">
        <el-carousel-item v-for="item in banners"
                          :key="item.banner_id">
          <a ><img width="100%"
                 height="400px"
                 :style="'background:url('+ item.file_path +') no-repeat center;'"
                 :src="item.file_path "></a>
          <div class="flex_words_main_sec">
            <div class="flex_words_left_sec">
              <span>热门活动</span>
              <dd>{{item.banner_title}}</dd>
            </div>
            <div class="flex_words_right_sec">
              <dd v-html="item.content">
              </dd>
            </div>
          </div>
        </el-carousel-item>
      </el-carousel>
    </div>
    <el-carousel height="200px" class="wap"
                 :interval="5000">
      <el-carousel-item v-for="item in banners"
                        :key="item.banner_id">
        <a><img width="100%"
               height="200px"
               :style="'background:url('+ item.file_path +') no-repeat center;'"
               :src="item.file_path "></a>
        <div class="flex_words_main_sec">
          <div class="flex_words_left_sec">
            <span>热门活动</span>
            <dd>{{item.banner_title}}</dd>
          </div>
          <!-- <div class="flex_words_right_sec">
            <dd v-html="item.content">
            </dd>
          </div> -->
        </div>

      </el-carousel-item>
    </el-carousel>
  </div>

</template>
<script>
import api from '@/api'
export default {
  data () {
    return {
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
      .GET('/Home/Banners?type=02')
      .then((res) => {
        self.banners = res
      })
      .catch(function (error) {
        console.log(error)
      })
  }
}
</script>
