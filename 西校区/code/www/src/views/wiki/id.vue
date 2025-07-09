<template>
  <div>

    <div class="school_top">
      <div class="school_top_main">
        <img :src="'/static/images/school.jpg'" />
        <div class="xx_mid">
          <h5>{{school.school_name}}<br />
            {{school.en_name}}</h5>
          <dd>{{school.address}}</dd>
          <dd>{{school.address_en}}</dd>
        </div>
        <div class="mark">
          <div class="mark_main">
            <span>{{school.point}}</span>
            <dd>Hurun score</dd>
          </div>
          <a href="javascript:;"
             @click="show=true"
             class="zhaocha">Need advice</a>
          <a :href="school.home_page"
             target="_blank">website &emsp;&emsp;&gt;&gt;&gt;</a>
        </div>
      </div>
    </div>

    <div class="huidi"
         v-show="show"
         @click="show=false">
      <div class="huidi_main">
        <div class="dingwei">
          <div class="huidi_left">
            <span>{{school.link_man}}</span>
            <div class="contact">
              <dd>TEL</dd>
              <dt>{{school.service_tel}}</dt>
            </div>
            <div class="contact">
              <dd>MAIL</dd>
              <dt>{{school.email}}</dt>
            </div>
          </div>
          <img :src="'/static/images/renxiang.jpg'" />
        </div>
        <a href="javascript:;"
           @click="show=false">close</a>
      </div>
    </div>

    <div class="schol">
      <div class="schol_main">
        <span>Data</span>
        <ul>
          <li>
            <img :src="'/static/images/xues.png'" />
            <div class="xx_sli">
              <p>Student</p>
              <div class="xx_sli_next">
                <dd>Total</dd>
                <dt>{{school.stu_qty}}</dt>
              </div>
              <div class="xx_sli_next">
                <dd>Plan</dd>
                <dt>{{school.recruit_qty}}</dt>
              </div>
            </div>
          </li>
          <li>
            <img :src="'/static/images/jiaoshi.png'" />
            <div class="xx_sli">
              <p>Teacher</p>
              <div class="xx_sli_next">
                <dd>Matching</dd>
                <dt>{{school.tas_rate}}%</dt>
              </div>
              <div class="xx_sli_next">
                <dd>Foreign Teacher</dd>
                <dt>{{school.ft_qty}}%</dt>
              </div>
            </div>
          </li>
          <li>
            <img :src="'/static/images/xuefei.png'" />
            <div class="xx_sli">
              <p>Cost</p>
              <div class="xx_sli_next">
                <dd>Tuition</dd>
                <dt>{{school.tuition_cny}}&nbsp;CNY<br />{{school.tuition_usd}}&nbsp;USD</dt>
              </div>
              <div class="xx_sli_next">
                <dd>Dormitory</dd>
                <dt>{{school.stay_cny}}&nbsp;CNY<br />{{school.stay_usd}}&nbsp;USD</dt>
              </div>
            </div>
          </li>
          <li>
            <img :src="'/static/images/luqu.png'" />
            <div class="xx_sli">
              <p>Enroll</p>
              <div class="xx_sli_next">
                <dd>Matching</dd>
                <dt>{{school.enroll_rate}}%</dt>
              </div>
              <div class="xx_sli_next">
                <dd>Registration</dd>
                <dt>{{school.enroll_qty}}</dt>
              </div>
            </div>
          </li>
        </ul>
      </div>
    </div>

    <div class="scl">
      <div class="scl_main">
        <div class="honnor">
          <span>Honorary award</span>
          <ul>
            <li v-for="item in school.honors"
                :key="item.id">
              <dd>{{item.honor_year}}</dd>
              <dt>{{item.honor_en}}</dt>
            </li>
          </ul>
        </div>
        <div class="shebei">
          <span>Supporting facilities</span>
          <ul>
            <li v-if="school.facilities1.length > 0">
              <dd>Sports</dd>
              <dt v-for="(item,index) in school.facilities1"
                  :key="index">{{item}}</dt>
            </li>
            <li v-if="school.facilities2.length > 0">
              <dd>Art</dd>
              <dt v-for="(item,index) in school.facilities2"
                  :key="index">{{item}}</dt>
            </li>
            <li v-if="school.facilities3.length > 0">
              <dd>Academic</dd>
              <dt v-for="(item,index) in school.facilities3"
                  :key="index">{{item}}</dt>
            </li>
          </ul>
        </div>
      </div>
    </div>
    <!-- <div class="xxzs">
      <div class="xxzs_main">
        <span>学校综述</span>
        <p v-html="school.content"></p>
      </div>
    </div> -->
  </div>
</template>
<script>
import api from '@/api'
export default {
  data () {
    return {
      show: false,
      school: {
        facilities1: [],
        facilities2: [],
        facilities3: []
      }
    }
  },
  created () {
    this.$store.commit('setTab', 1)
  },

  async mounted () {
    this.school = await api.GET('/Home/School', { id: this.$route.params.id, l: 'en' })
  }
}
</script>
