<template>
  <div>

    <div class="about_banner">
      <img :src="'/static/images/qixing.jpg'" />
      <h5>中国顶尖国际学校俱乐部</h5>
    </div>

    <div class="about">
      <div class="about_main">
        <div class="about_left">
          <ul>
            <li :class="index === active ?'pres':'' "
                v-for="(item,index) in list"
                :key="item.id"><a href="javascript:;"
                 @click="active = index">{{item.title}}</a></li>
          </ul>
        </div>
        <template v-for="(item,index) in list">
          <div class="about_right"
               :key="item.id"
               v-if="index === active">
            <h5>{{item.title}}</h5>
            <span v-html="item.content"></span>
          </div>
        </template>
      </div>
    </div>
  </div>
</template>
<script>
import api from '@/api'
export default {
  data () {
    return {
      active: 0,
      list: []
    }
  },
  created () {
    this.$store.commit('setTab', 5)
  },
  async mounted () {
    this.list = await api.GET('/Home/AboutUs')
  }
}
</script>
