<template>
  <div>
    <div class="membership_banner pc">
      <div class="membership_img">
        <img :src="banners[0].file_path"
             v-if="banners.length > 0" />
        <img :src="'/static/images/qixing_1920.jpg'"
             v-else />
        <div class="membership_word">
          <span>每周名校</span>
          <h5>{{interview.school_name}}</h5>
        </div>
      </div>
      <div class="membership_bg">
        <div class="membership_bg_left">
          <router-link :to="'/school/interview/'+interview.id">
            {{interview.description}}<br /><br />
            点击阅读本期校长专访&emsp;&emsp;&emsp;&gt;&gt;&gt;
          </router-link>
        </div>
      </div>
      <div class="schoolman">
        <img :src="interview.file_path" />
        <dd>常务校长</dd>
        <dt>Mark Bishop</dt>
      </div>
    </div>
    <div class="membership_banner wap">
      <div class="membership_img">
        <img :src="banners[0].file_path"
             v-if="banners.length > 0" />
        <img :src="'/static/images/qixing_1920.jpg'"
             v-else />
      </div>
      <div class="membership_bg">
        <div class="schoolman">
          <img :src="interview.file_path" />
          <dd>常务校长</dd>
          <dt>Mark Bishop</dt>
        </div>
        <div class="membership_bg_left">
          <h5>{{interview.school_name}}</h5>
          <router-link :to="'/school/interview/'+interview.id">
            {{interview.description}}
          </router-link>
        </div>
      </div>
    </div>
    <div class="school">
      <div class="school_main">
        <div class="retrieve">
          <span>名校检索</span>
          <div class="search">
            <img :src="'/static/images/search.png'" />
            <input type="text"
                   maxlength="20"
                   placeholder="输入关键词"
                   v-model="pager.keywords"
                   @keyup.enter="doFilter" />
          </div>
        </div>
        <div class="filtrate">
          <ul class="pc">
            <li>
              <dd>筛选：</dd>
            </li>
            <li>
              <el-dropdown class="filtrate_droplist"
                           trigger="click"  ref="dropdownm"
                           @command="changeArea">
                <span class="el-dropdown-link">
                  {{areaText}}
                  <i v-if="areaText === '所在区域'"
                     class="el-icon-arrow-down el-icon--right"></i>
                </span>
                <el-dropdown-menu slot="dropdown"
                                  style="padding:5px;">
                  <el-cascader-panel :options="areas"
                                     v-model="areavalues"
                                     size="mini"
                                     :props="{ expandTrigger: 'click' }"
                                     @change="changeArea"
                                     is-bordered="false"></el-cascader-panel>
                </el-dropdown-menu>
              </el-dropdown>
              <i v-if="areaText !== '所在区域'"
                 style="margin-left:20px;"
                 class="el-icon-close el-icon--right"
                 @click="changeArea('')"></i>
            </li>
            <li>
              <el-dropdown class="filtrate_droplist"
                           @command="changeSort">
                <span class="el-dropdown-link">
                  {{sortText}}<i class="el-icon-arrow-down el-icon--right"></i>
                </span>
                <el-dropdown-menu slot="dropdown"
                                  style="padding:5px;">
                  <el-dropdown-item command="">清空选择</el-dropdown-item>
                  <el-dropdown-item command="1">由高到低</el-dropdown-item>
                  <el-dropdown-item command="2">由低到高</el-dropdown-item>
                </el-dropdown-menu>
              </el-dropdown>
            </li>
            <li>
              <el-dropdown class="filtrate_droplist"
                           @command="changeType">
                <span class="el-dropdown-link">
                  {{typeText}}<i class="el-icon-arrow-down el-icon--right"></i>
                </span>
                <el-dropdown-menu slot="dropdown"
                                  style="padding:5px;">
                  <el-dropdown-item command="">清空选择</el-dropdown-item>
                  <el-dropdown-item :command="item.value"
                                    v-for="item in types"
                                    :key="item.value">{{item.label}}</el-dropdown-item>
                </el-dropdown-menu>
              </el-dropdown>
            </li>
            <li>
              <el-dropdown class="filtrate_droplist"
                           @command="changeCny">
                <span class="el-dropdown-link">
                  {{cny}} <i class="el-icon-arrow-down el-icon--right"></i>
                </span>

                <el-dropdown-menu slot="dropdown"
                                  style="padding:5px;">
                  <el-dropdown-item command="">清空选择</el-dropdown-item>
                  <el-dropdown-item command="1">0-10万 </el-dropdown-item>
                  <el-dropdown-item command="2">10万-20万 </el-dropdown-item>
                  <el-dropdown-item command="3">20万-30万 </el-dropdown-item>
                  <el-dropdown-item command="4">30万 以上</el-dropdown-item>
                </el-dropdown-menu>
              </el-dropdown>
            </li>
            <li>
              <el-dropdown class="filtrate_droplist"
                           @command="changeCourse">
                <span class="el-dropdown-link">
                  {{courseText}} <i class="el-icon-arrow-down el-icon--right"></i>
                </span>

                <el-dropdown-menu slot="dropdown"
                                  style="padding:5px;">
                  <el-dropdown-item command="">清空选择</el-dropdown-item>
                  <el-dropdown-item :command="item.value"
                                    v-for="item in course"
                                    :key="item.value">{{item.label}}</el-dropdown-item>
                </el-dropdown-menu>
              </el-dropdown>
            </li>
          </ul>
          <ul class="wap scroll2">
            <li>
              <dd>筛选：</dd>
            </li>
            <li>
              <el-dropdown class="filtrate_droplist"
                           trigger="click" ref="dropdown" >
                <span class="el-dropdown-link">
                  {{areaText}}
                  <i v-if="areaText === '所在区域'"
                     class="el-icon-arrow-down el-icon--right"></i>
                </span>
                <el-dropdown-menu slot="dropdown" trigger="click"
                                  style="padding:5px;">
                  <el-cascader-panel :options="areas"
                                     v-model="areavalues"
                                     size="mini"
                                     :props="{ expandTrigger: 'click' }"
                                     @change="changeArea"
                                     is-bordered="false"></el-cascader-panel>
                </el-dropdown-menu>
              </el-dropdown>
              <i v-if="areaText !== '所在区域'"
                 style="margin-left:20px;"
                 class="el-icon-close el-icon--right"
                 @click="changeArea('')"></i>
            </li>
            <li>
              <el-dropdown class="filtrate_droplist" trigger="click"
                           @command="changeSort">
                <span class="el-dropdown-link">
                  {{sortText}}<i class="el-icon-arrow-down el-icon--right"></i>
                </span>
                <el-dropdown-menu slot="dropdown"
                                  style="padding:5px;">
                  <el-dropdown-item command="">清空选择</el-dropdown-item>
                  <el-dropdown-item command="1">由高到低</el-dropdown-item>
                  <el-dropdown-item command="2">由低到高</el-dropdown-item>
                </el-dropdown-menu>
              </el-dropdown>
            </li>
            <li>
              <el-dropdown class="filtrate_droplist" trigger="click"
                           @command="changeType">
                <span class="el-dropdown-link">
                  {{typeText}}<i class="el-icon-arrow-down el-icon--right"></i>
                </span>
                <el-dropdown-menu slot="dropdown"
                                  style="padding:5px;">
                  <el-dropdown-item command="">清空选择</el-dropdown-item>
                  <el-dropdown-item :command="item.value"
                                    v-for="item in types"
                                    :key="item.value">{{item.label}}</el-dropdown-item>
                </el-dropdown-menu>
              </el-dropdown>
            </li>
            <li>
              <el-dropdown class="filtrate_droplist" trigger="click"
                           @command="changeCny">
                <span class="el-dropdown-link">
                  {{cny}} <i class="el-icon-arrow-down el-icon--right"></i>
                </span>

                <el-dropdown-menu slot="dropdown"
                                  style="padding:5px;">
                  <el-dropdown-item command="">清空选择</el-dropdown-item>
                  <el-dropdown-item command="1">0-10万 </el-dropdown-item>
                  <el-dropdown-item command="2">10万-20万 </el-dropdown-item>
                  <el-dropdown-item command="3">20万-30万 </el-dropdown-item>
                  <el-dropdown-item command="4">30万 以上</el-dropdown-item>
                </el-dropdown-menu>
              </el-dropdown>
            </li>
            <li>
              <el-dropdown class="filtrate_droplist" trigger="click"
                           @command="changeCourse">
                <span class="el-dropdown-link">
                  {{courseText}} <i class="el-icon-arrow-down el-icon--right"></i>
                </span>

                <el-dropdown-menu slot="dropdown"
                                  style="padding:5px;">
                  <el-dropdown-item command="">清空选择</el-dropdown-item>
                  <el-dropdown-item :command="item.value"
                                    v-for="item in course"
                                    :key="item.value">{{item.label}}</el-dropdown-item>
                </el-dropdown-menu>
              </el-dropdown>
            </li>
          </ul>
        </div>
        <div class="school_list"
             v-loading="loading">
          <ul>
            <li v-for="item in list"
                :key="item.id">
              <router-link :to="'/school/'+item.id">
                <img :src="item.file_path" />
                <div class="school_mid">
                  <span>{{item.school_name}}</span>
                  <div class="score">
                    <dd>胡润评分</dd>
                    <p>{{item.point}}</p>
                  </div>
                  <div class="score">
                    <dd>招生对象</dd>
                    <dt>{{item.recruit_name}}</dt>
                  </div>
                </div>
                <div class="school_right">
                  <ol>
                    <li>
                      <dd>学校地址：</dd>
                      <dt>{{item.city_name}}{{item.address}}</dt>
                    </li>
                    <li>
                      <dd>招生规模：</dd>
                      <dt>{{item.recruit_qty}}名/年</dt>
                    </li>
                    <li>
                      <dd>课程体系：</dd>
                      <dt>{{item.system_course}}</dt>
                    </li>
                    <li>
                      <dd>住宿标准：</dd>
                      <dt>{{item.stay_cny}} CNY</dt>
                    </li>
                    <li>
                      <dd>每年学费：</dd>
                      <dt>{{item.tuition_cny}} CNY</dt>
                    </li>
                    <li>
                      <dd>配套设施：</dd>
                      <dt>{{item.facilities}}</dt>
                    </li>
                  </ol>
                </div>
              </router-link>
            </li>
          </ul>
          <div class="gengmore"
               @click="doMove"
               v-if="move">
            <dd>点击查看更多</dd>
          </div>
          <div class="gengmore"
               v-else>
            <dd>没有更多了~</dd>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>
<script>
import api from '@/api'
export default {
  data () {
    return {
      loading: true,
      areavalues: [],
      banners: [],
      interview: [],
      areas: [],
      types: [],
      course: [],
      pager: {
        sort: '',
        type: '',
        cny: '',
        keywords: '',
        p: '',
        c: '',
        coutype: '',
        areap: '',
        areac: ''
      },
      move: false,
      list: [],
      money: '',
      type: '',
      sort: '',
      coutype: '',
      p: '',
      c: ''
    }
  },
  created () {
    this.$store.commit('setTab', 2)
    if (this.$route.query.p) {
      this.pager.areap = this.$route.query.p
    }
    if (this.$route.query.c) {
      this.pager.areac = this.$route.query.c
    }
  },
  async mounted () {
    this.banners = await api.GET('/Home/Banners', { type: '04' })
    this.interview = await api.GET('/Home/Interview')
    var pages = await api.GET('/Home/SchoolList', this.pager)
    this.areas = await api.GET('/Home/AreaList')
    this.types = await api.GET('/Home/Dictionarys', { code: '01' })
    this.course = await api.GET('/Home/Dictionarys', { code: '05' })
    this.move = pages.move
    this.list = pages.data
    this.pager = { size: pages.size, page: pages.page }
    this.loading = false
  },
  methods: {
    async doMove () {
      let self = this
      this.loading = true
      this.pager.page++
      const rs = await api.GET('/Home/SchoolList', this.pager)
      this.move = rs.move
      this.list = [...this.list, ...rs.data]
      setTimeout(() => {
        self.loading = false
      }, 200)
    },
    async doFilter () {
      let self = this
      this.loading = true
      this.pager.page = null
      this.pager.size = null
      const rs = await api.GET('/Home/SchoolList', this.pager)
      this.move = rs.move
      this.pager.page = rs.page
      this.pager.size = rs.size
      this.list = rs.data
      setTimeout(() => {
        self.loading = false
      }, 200)
    },
    changeSort (val) {
      this.pager.sort = val
      this.sort = val
      this.doFilter()
    },
    changeType (val) {
      this.pager.type = val
      this.type = val
      this.doFilter()
    },
    changeCny (val) {
      this.pager.cny = val
      this.money = val
      this.doFilter()
    },
    changeCourse (val) {
      this.pager.coutype = val
      this.coutype = val
      this.doFilter()
    },
    changeArea (val) {
      this.$refs.dropdownm.hide()
      this.$refs.dropdown.hide()
      if (val.length === 2) {
        this.pager.p = val[0]
        this.pager.c = val[1]
        this.p = val[0]
        this.c = val[1]
        this.doFilter()
      } else {
        this.pager.p = ''
        this.pager.c = ''
        this.p = ''
        this.c = ''
        this.doFilter()
      }
    }
  },
  computed: {
    cny () {
      if (this.money === '1') {
        return '0-10万'
      } else if (this.money === '2') {
        return '10万-20万'
      } else if (this.money === '3') {
        return '20万-30万'
      } else if (this.money === '4') {
        return '30万以上'
      } else {
        return '学费级别'
      }
    },
    sortText () {
      if (this.sort === '1') {
        return '从高到低'
      } else if (this.sort === '2') {
        return '从低到高'
      } else {
        return '评分排序'
      }
    },
    typeText () {
      var item = this.types.find((a) => {
        return a.value === this.type
      })
      if (item) {
        return item.label
      }
      return '招生对象'
    },
    courseText () {
      var item = this.course.find((a) => {
        return a.value === this.coutype
      })
      if (item) {
        return item.label
      }
      return '课程体系'
    },
    areaText () {
      var item = this.areas.find((a) => {
        return a.value === this.p
      })
      if (item) {
        var citem = item.children.find((x) => {
          return x.value === this.c
        })
        return citem.label
      }
      return '所在区域'
    }
  }
}
</script>
