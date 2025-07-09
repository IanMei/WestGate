<template>
  <div>
    <banner-review />
    <div class="zhuren"
         style="zindex:100">
      <div class="zhuren_main">
        <span>主任评委团</span>
        <ul>
          <li v-for="item in mainList"
              :key="item.id">
            <router-link :to="'/review/'+ item.id">
              <img :src="item.file_path" />
              <div class="pingwei_right">
                <dd><strong>{{item.nick_name}}</strong>&nbsp;</dd>
                <dt>{{item.company}}&emsp;{{item.position}}</dt>
              </div>
            </router-link>
          </li>
        </ul>
        <a class="zhankai"
           @click="doMainMove"
           v-if="mainMove">
          点击继续展开
        </a>
        <div class="zhankai"
             v-else>
          没有更多了~
        </div>
      </div>
    </div>

    <div class="zhuren">
      <div class="zhuren_main">
        <span>特邀评委团</span>
        <ul>
          <li v-for="item in specialList"
              :key="item.id">
            <router-link :to="'/review/'+ item.id">
              <img :src="item.file_path" />
              <div class="pingwei_right">
                <dd><strong>{{item.nick_name}}</strong>&nbsp;</dd>
                <dt>{{item.company}}&emsp;{{item.position}}</dt>
              </div>
            </router-link>
          </li>
        </ul>
        <a class="zhankai"
           @click="doSpecialMove"
           v-if="speciaMove">
          点击继续展开
        </a>
        <div class="zhankai"
             v-else>
          没有更多了~
        </div>
      </div>
    </div>

  </div>
</template>
<script>
import BannerReview from '@/components/banner-review.vue'
import api from '@/api'
export default {
  data () {
    return {
      mainPager: {
        page: 1,
        size: 6,
        type: '01'
      },
      specialPager: {
        page: 1,
        size: 6,
        type: '02'
      },
      mainList: [],
      mainMove: false,
      specialList: [],
      speciaMove: false
    }
  },
  components: {
    BannerReview
  },
  created () {
    this.$store.commit('setTab', 3)
  },
  async mounted () {
    var main = await api.GET('/Judges/List', this.mainPager)
    this.mainMove = main.move
    this.mainList = main.data

    var special = await api.GET('/Judges/List', this.specialPager)
    this.speciaMove = special.move
    this.specialList = special.data
  },
  methods: {
    doMainMove () {
      let self = this
      self.mainPager.page++
      api
        .GET('/judges/List', self.mainPager)
        .then(function (res) {
          self.mainMove = res.move
          self.mainList = [...self.mainList, ...res.data]
        })
        .catch(function (error) {
          console.log(error)
        })
    },
    doSpecialMove () {
      let self = this
      self.specialPager.page++
      api
        .GET('/judges/List', self.specialPager)
        .then(function (res) {
          self.speciaMove = res.move
          self.specialList = [...self.specialList, ...res.data]
        })
        .catch(function (error) {
          console.log(error)
        })
    }
  }
}
</script>
