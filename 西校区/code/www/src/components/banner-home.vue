<template>
  <div>
    <div id="banner_tabs"
         v-loading="loading"
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
          <div class="flex_words_main">
            <div class="flex_words_left">
              <span>{{item.banner_title}}</span>
              <dd v-html="item.content">
              </dd>
            </div>
          </div>
        </el-carousel-item>
      </el-carousel>
      <div class="flex_words">
        <div class="flex_words_right">
          <span>寻找名校</span>
          <input type="text"
                 maxlength="20"
                 placeholder="省份"
                 v-model="search.province" />
          <input type="text"
                 maxlength="20"
                 placeholder="城市"
                 v-model="search.city" />
          <router-link :to="'/school?p='+search.province+'&c='+search.city">搜索</router-link>
        </div>
      </div>
    </div>
    <div class="clearfloat wap"
         v-loading="loading">
      <el-carousel height="276px"
                   :interval="5000">
        <el-carousel-item v-for="item in banners"
                          :key="item.banner_id">
          <a><img width="100%"
                 height="276px"
                 :style="'background:url('+ item.file_path +') no-repeat center;'"
                 :src="item.file_path "></a>
          <div class="flex_words_main">
            <div class="flex_words_left">
              <span>{{item.banner_title}}</span>
              <dd v-html="item.content">
              </dd>
            </div>
          </div>
        </el-carousel-item>
      </el-carousel>
    </div>
  </div>
</template>
<script>
import api from '@/api'
export default {
  data () {
    return {
      loading: true,
      search: {
        province: '',
        city: ''
      },
      banners: []
    }
  },
  mounted () {
    let self = this
    api
      .GET('/Home/Banners?type=01')
      .then((res) => {
        self.banners = res
        setTimeout(() => {
          self.loading = false
        }, 500)
      })
      .catch(function (error) {
        console.log(error)
      })
  }
}
</script>
