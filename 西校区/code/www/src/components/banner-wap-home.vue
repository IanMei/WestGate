<template>
     <div class="clearfloat">
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
</template>
<script>
import api from '@/api'
export default {
  data () {
    return {
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
        console.log(res)
      })
      .catch(function (error) {
        console.log(error)
      })
  }
}
</script>
