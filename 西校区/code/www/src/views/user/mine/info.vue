<template>
  <div class="houtai_right_mid">
    <div class="basic">
      <span>基本信息</span>
      <ul>
        <li>
          <dd>学校Logo</dd>
          <div class="losyou">
            <el-image :src="info.file_path"
                      style="margin-bottom: 10px;">
              <div slot="error"
                   class="image-slot">
                <i class="el-icon-picture-outline"
                   style="font-size:25px;padding:20px 40px;"></i>
              </div>
            </el-image>
            <el-upload class="avatar-uploader"
                       :action="IMAGE_UPLOAD"
                       :show-file-list="false"
                       :on-success="handleAvatarSuccess"
                       :before-upload="beforeAvatarUpload">
              <button>上传</button>
            </el-upload>
          </div>
        </li>
      </ul>
      <el-form ref="form"
               class="pc"
               style="margin-top:20px;"
               :model="info"
               label-width="125px"
               size="small">
        <el-row>
          <el-col :span="12">
            <el-form-item label="中文校名">
              <el-input v-model="info.school_name"
                        maxlength="20"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="6">
            <el-form-item label="中文地址">
              <el-cascader v-model="info.arrayarea"
                           :options="options"
                           style="width:100%"
                           @change="handleChange"></el-cascader>
            </el-form-item>
          </el-col>
          <el-col :span="6">
            <el-form-item label-width="10px">
              <el-input v-model="info.address"
                        style="width:100%"
                        maxlength="50"
                        placeholder="街道/门牌号"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="12">
            <el-form-item label="English Names">
              <el-input v-model="info.en_name"
                        maxlength="100"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="English Address">
              <el-input v-model="info.address_en"
                        maxlength="100"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="6">
            <el-form-item label="学生人数">
              <el-input v-model="info.stu_qty"
                        placeholder="正整数"
                        maxlength="9"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="6">
            <el-form-item label="招生人数">
              <el-input v-model="info.recruit_qty"
                        placeholder="正整数"
                        maxlength="9"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="6">
            <el-form-item label="师生配比">
              <el-input v-model="info.tas_rate" style="width:80%"
                        placeholder="1-100%"
                        maxlength="3"></el-input> %
            </el-form-item>
          </el-col>
          <el-col :span="6">
            <el-form-item label="外教占比">
              <el-input v-model="info.ft_qty"
                        placeholder="1-100%" style="width:80%"
                        maxlength="3"></el-input> %
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="6">
            <el-form-item label="录取比率">
              <el-input v-model="info.enroll_rate"
                        placeholder="1-100%" style="width:80%"
                        maxlength="3"></el-input> %
            </el-form-item>
          </el-col>
          <el-col :span="6">
            <el-form-item label="报名人数">
              <el-input v-model="info.enroll_qty"
                        placeholder="正整数"
                        maxlength="9"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="6">
            <el-form-item label="学费CNY">
              <el-input v-model="info.tuition_cny"
                        placeholder="数字"
                        maxlength="9"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="6">
            <el-form-item label="住宿CNY">
              <el-input v-model="info.stay_cny"
                        placeholder="数字"
                        maxlength="9"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="12">
            <el-form-item label="学校网站"
                          prop="home_page">
              <el-input v-model="info.home_page"
                        maxlength="200"
                        placeholder="最多200字符"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="6">
            <el-form-item label="课程体系">
              <el-select v-model="info.especially_course"
                         placeholder="请选择">
                <el-option v-for="item in selectOptions"
                           :key="item.value"
                           :label="item.label"
                           :value="item.value">
                </el-option>
              </el-select>
            </el-form-item>
          </el-col>

        </el-row>
      </el-form>

      <el-form ref="form"
               class="wap"
               style="margin-top:20px;"
               :model="info"
               label-width="75px"
               size="small">
        <el-row>
          <el-col :span="24">
            <el-form-item label="校名">
              <el-input v-model="info.school_name"
                        maxlength="20"></el-input>
            </el-form-item>
          </el-col>

        </el-row>
        <el-row>
          <el-col :span="12">
            <el-form-item label="地址">
              <el-cascader v-model="info.arrayarea"
                           :options="options"
                           style="width:100%"
                           @change="handleChange"></el-cascader>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label-width="10px">
              <el-input v-model="info.address"
                        style="width:100%"
                        maxlength="50"
                        placeholder="街道/门牌号"></el-input>
            </el-form-item>
          </el-col>
        </el-row>

        <el-row>
          <el-col :span="24">
            <el-form-item label="Name">
              <el-input v-model="info.en_name"
                        placeholder="English"
                        maxlength="100"></el-input>
            </el-form-item>
          </el-col>
        </el-row>

        <el-row>
          <el-col :span="24">
            <el-form-item label="Address">
              <el-input v-model="info.address_en"
                        placeholder="English"
                        maxlength="100"></el-input>
            </el-form-item>
          </el-col>
        </el-row>

        <el-row>
          <el-col :span="12">
            <el-form-item label="学生人数">
              <el-input v-model="info.stu_qty"
                        placeholder="正整数"
                        maxlength="9"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="招生人数">
              <el-input v-model="info.recruit_qty"
                        placeholder="正整数"
                        maxlength="9"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="12">
            <el-form-item label="师生配比">
              <el-input v-model="info.tas_rate"
                        placeholder="1-100%" style="width:60px"
                        maxlength="3"></el-input> %
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="外教占比">
              <el-input v-model="info.ft_qty" style="width:60px"
                        placeholder="1-100%"
                        maxlength="3"></el-input> %
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="12">
            <el-form-item label="录取比率">
              <el-input v-model="info.enroll_rate"
                        placeholder="1-100%" style="width:60px"
                        maxlength="3"></el-input> %
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="报名人数">
              <el-input v-model="info.enroll_qty"
                        placeholder="正整数"
                        maxlength="9"></el-input>
            </el-form-item>
          </el-col>

        </el-row>
        <el-row>

          <el-col :span="12">
            <el-form-item label="学费CNY">
              <el-input v-model="info.tuition_cny"
                        placeholder="数字"
                        maxlength="9"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="住宿CNY">
              <el-input v-model="info.stay_cny"
                        placeholder="数字"
                        maxlength="9"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="12">
            <el-form-item label="学校网站"
                          prop="home_page">
              <el-input v-model="info.home_page"
                        maxlength="200"
                        placeholder="最多200字符"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="课程体系">
              <el-select v-model="info.especially_course"
                         placeholder="请选择">
                <el-option v-for="item in selectOptions"
                           :key="item.value"
                           :label="item.label"
                           :value="item.value">
                </el-option>
              </el-select>
            </el-form-item>
          </el-col>

        </el-row>
      </el-form>
    </div>
    <div class="rongyu"
         style="margin-right: 5px;">
      <span>荣誉奖项</span>
      <div>
        <el-row style="margin-bottom: 15px;height: 35px;">
          <el-col :span="6"
                  style="font-size:15px;">年份</el-col>
          <el-col :span="14"
                  style="font-size:15px">荣誉</el-col>
          <el-col :span="4"
                  style="font-size:15px">
            <!-- <a href="javascript:;"
             class="rongyu_a">添加</a> -->
            <el-button icon="el-icon-plus"
                       size="mini"
                       type="success"
                       @click="addHonor"
                       style="margin-left:10px"
                       circle></el-button>
          </el-col>
          <el-col :span="3">&nbsp;</el-col>
        </el-row>
        <template v-for="(item,index) in info.honors">
          <el-row :key="item.id">
            <el-col :span="6">
              <el-input maxlength="4"
                        v-model="item.honor_year"
                        style="width:95%;"
                        placeholder="如：2020"
                        size="small"></el-input>
            </el-col>
            <el-col :span="14">
              <el-input maxlength="200"
                        v-model="item.honor_desc"
                        auto-complete="off"
                        placeholder="中文"
                        size="small"></el-input>
            </el-col>
            <el-col :span="4">
              <el-button type="danger"
                         size="mini"
                         @click="removeHonor(index)"
                         icon="el-icon-delete"
                         style="margin-left:10px"
                         circle></el-button>
            </el-col>
          </el-row>
          <el-row style="margin-bottom: 25px; margin-top:10px"
                  :key="index">
            <el-col :span="20">
              <el-input maxlength="200"
                        type="textarea"
                        v-model="item.honor_en"
                        style="width:100%"
                        auto-complete="off"
                        placeholder="英文"
                        size="small"></el-input>
            </el-col>
          </el-row>
        </template>
      </div>
    </div>
    <div class="ptss">
      <span>配套设施</span>
      <div class="tiyu">
        <p>体育设施</p>
        <div class="baihui">
          <div class="bai">
            <dd>已选</dd>
            <ul>
              <template v-for="(item,index) in info.facilities1">
                <li :key="index"
                    v-if="item.is_enabled === 1">
                  <dt>{{item.title}}</dt><a href="javascript:;"
                     @click="item.is_enabled = 0">×</a>
                </li>
              </template>
            </ul>
          </div>
          <div class="hui">
            <dd>备选</dd>
            <ul>
              <template v-for="(item,index) in info.facilities1">
                <li :key="index"
                    v-if="item.is_enabled === 0">
                  <dt @click="item.is_enabled = 1">{{item.title}}</dt><a href="javascript:;"
                     @click="removefacilities1(item.title)">×</a>
                </li>
              </template>
            </ul>
          </div>
        </div>
        <span>没有对应标签？这里添加新设施</span>
        <div class="add_ss">
          <input type="text"
                 maxlength="10"
                 v-model="newfacilities1" />
          <a href="javascript:;"
             @click="addfacilities1">确定添加</a>
        </div>
      </div>
      <div class="tiyu">
        <p>艺术设施</p>
        <div class="baihui">
          <div class="bai">
            <dd>已选</dd>
            <ul>
              <template v-for="(item,index) in info.facilities2">
                <li :key="index"
                    v-if="item.is_enabled === 1">
                  <dt>{{item.title}}</dt><a href="javascript:;"
                     @click="item.is_enabled = 0">×</a>
                </li>
              </template>
            </ul>
          </div>
          <div class="hui">
            <dd>备选</dd>
            <ul>
              <template v-for="(item,index) in info.facilities2">
                <li :key="index"
                    v-if="item.is_enabled === 0">
                  <dt @click="item.is_enabled = 1">{{item.title}}</dt><a href="javascript:;"
                     @click="removefacilities2(item.title)">×</a>
                </li>
              </template>
            </ul>
          </div>
        </div>
        <span>没有对应标签？这里添加新设施</span>
        <div class="add_ss">
          <input type="text"
                 maxlength="10"
                 v-model="newfacilities2" />
          <a href="javascript:;"
             @click="addfacilities2">确定添加</a>
        </div>
      </div>
      <div class="tiyu">
        <p>学术设施</p>
        <div class="baihui">
          <div class="bai">
            <dd>已选</dd>
            <ul>
              <template v-for="(item,index) in info.facilities3">
                <li :key="index"
                    v-if="item.is_enabled === 1">
                  <dt>{{item.title}}</dt><a href="javascript:;"
                     @click="item.is_enabled = 0">×</a>
                </li>
              </template>
            </ul>
          </div>
          <div class="hui">
            <dd>备选</dd>
            <ul>
              <template v-for="(item,index) in info.facilities3">
                <li :key="index"
                    v-if="item.is_enabled === 0">
                  <dt @click="item.is_enabled = 1">{{item.title}}</dt><a href="javascript:;"
                     @click="removefacilities3(item.title)">×</a>
                </li>
              </template>
            </ul>
          </div>
        </div>
        <span>没有对应标签？这里添加新设施</span>
        <div class="add_ss">
          <input type="text"
                 maxlength="10"
                 v-model="newfacilities3" />
          <a href="javascript:;"
             @click="addfacilities3">确定添加</a>
        </div>
      </div>
      <div class="tiyu"
           style="margin-top:30px;width:100%">
        <el-row style="margin-bottom: 20px;">
          <el-col :span="6"
                  style="font-size:15px;font-weight: bold;">设施名称</el-col>
          <el-col :span="16"
                  style="font-size:15px;font-weight: bold;">FACILITIES NAME</el-col>
        </el-row>
        <template v-for="(item,index) in info.facilities1">
          <el-row :key="index + '03'"
                  style="margin-top:10px;"
                  v-if="item.is_enabled === 1">
            <el-col :span="6">{{item.title}}</el-col>
            <el-col :span="16">
              <el-input maxlength="100"
                        v-model="item.title_en"
                        style="width:100%"
                        auto-complete="off"
                        placeholder=""
                        size="small"></el-input>
            </el-col>
          </el-row>
        </template>
        <template v-for="(item,index) in info.facilities2">
          <el-row :key="index + '04'"
                  style="margin-top:10px;"
                  v-if="item.is_enabled === 1">
            <el-col :span="6">{{item.title}}</el-col>
            <el-col :span="16">
              <el-input maxlength="100"
                        v-model="item.title_en"
                        style="width:100%"
                        auto-complete="off"
                        placeholder=""
                        size="small"></el-input>
            </el-col>
          </el-row>
        </template>
        <template v-for="(item,index) in info.facilities3">
          <el-row :key="index + '05'"
                  style="margin-top:10px;"
                  v-if="item.is_enabled === 1">
            <el-col :span="6">{{item.title}}</el-col>
            <el-col :span="16">
              <el-input maxlength="100"
                        v-model="item.title_en"
                        style="width:100%"
                        auto-complete="off"
                        placeholder=""
                        size="small"></el-input>
            </el-col>
          </el-row>
        </template>
      </div>
    </div>
    <a href="javascript:;"
       class="baoc"
       @click="update">保存信息</a>
  </div>
</template>
<script>
import api from '@/api'
export default {
  data () {
    return {
      newfacilities1: '',
      newfacilities2: '',
      newfacilities3: '',
      info: {},
      options: [],
      selectOptions: [],
      IMAGE_UPLOAD: process.env.BASE_UPLOAD
    }
  },
  created () {
    this.$store.commit('setMemberTab', 1)
    let self = this
    api
      .GET('/Member/Info')
      .then(function (res) {
        self.info = res
      })
      .catch(function (error) {
        console.log(error)
      })
    api
      .GET('/home/arealist')
      .then(function (res) {
        self.options = res
      })
      .catch(function (error) {
        console.log(error)
      })
    api
      .GET('/home/Dictionarys?code=05')
      .then(function (res) {
        self.selectOptions = res
      })
      .catch(function (error) {
        console.log(error)
      })
  },
  methods: {
    addHonor () {
      let self = this
      var emptyRow = self.info.honors.filter((a) => {
        return a.honor_year === '' || a.honor_desc === '' || a.honor_en === ''
      })
      if (emptyRow && emptyRow.length > 0) {
        self.$message({
          message: '存在未填写完成的荣誉，不能继续添加',
          type: 'error'
        })
        return
      }
      self.info.honors.push({
        honor_year: '',
        honor_desc: '',
        honor_en: ''
      })
    },
    removeHonor (index) {
      let self = this
      if (index >= 0) {
        self.info.honors.splice(index, 1)
      }
    },
    addfacilities1 () {
      let self = this
      if (self.newfacilities1 !== '') {
        var ex = self.info.facilities1.filter((a) => {
          return a.title === self.newfacilities1
        })
        if (ex && ex.length > 0) {
          self.$message({
            message: self.newfacilities1 + ' 已存在',
            type: 'error'
          })
          return
        }
        self.info.facilities1.push({
          facilities_type: '02',
          school_no: self.info.school_no,
          title: self.newfacilities1,
          is_enabled: 1
        })
        self.newfacilities1 = ''
      } else {
        self.$message({
          message: '设施名称不能空',
          type: 'error'
        })
      }
    },
    removefacilities1 (title) {
      let self = this
      var index = self.info.facilities1.findIndex((a) => {
        return a.title === title
      })
      if (index >= 0) {
        self.info.facilities1.splice(index, 1)
      }
    },
    addfacilities2 () {
      let self = this
      if (self.newfacilities2 !== '') {
        var ex = self.info.facilities2.filter((a) => {
          return a.title === self.newfacilities2
        })
        if (ex && ex.length > 0) {
          self.$message({
            message: self.newfacilities2 + ' 已存在',
            type: 'error'
          })
          return
        }
        self.info.facilities2.push({
          facilities_type: '03',
          school_no: self.info.school_no,
          title: self.newfacilities2,
          is_enabled: 1
        })
        self.newfacilities2 = ''
      } else {
        self.$message({
          message: '设施名称不能空',
          type: 'error'
        })
      }
    },
    removefacilities2 (title) {
      let self = this
      var index = self.info.facilities2.findIndex((a) => {
        return a.title === title
      })
      if (index >= 0) {
        self.info.facilities2.splice(index, 1)
      }
    },
    addfacilities3 () {
      let self = this
      if (self.newfacilities3 !== '') {
        var ex = self.info.facilities3.filter((a) => {
          return a.title === self.newfacilities3
        })
        if (ex && ex.length > 0) {
          self.$message({
            message: self.newfacilities3 + ' 已存在',
            type: 'error'
          })
          return
        }
        self.info.facilities3.push({
          facilities_type: '04',
          school_no: self.info.school_no,
          title: self.newfacilities3,
          is_enabled: 1
        })
        self.newfacilities3 = ''
      } else {
        self.$message({
          message: '设施名称不能空',
          type: 'error'
        })
      }
    },
    removefacilities3 (title) {
      let self = this
      var index = self.info.facilities3.findIndex((a) => {
        return a.title === title
      })
      if (index >= 0) {
        self.info.facilities3.splice(index, 1)
      }
    },
    update () {
      const that = this
      api
        .POST('/Member/update', that.info)
        .then(function (res) {
          that.$store.commit('setMember', that.info)
          setTimeout(() => {
            that.$message({
              message: '更新成功',
              type: 'success'
            })
          }, 10)
        })
        .catch(function (err) {
          console.log(err)
        })
    },
    handleChange (val) {
      const that = this
      that.info.arrayarea = val
      console.log(val)
      if (val.length === 2) {
        that.info.province_no = val[0]
        that.info.city_no = val[1]
      }
    },
    handleAvatarSuccess (res, file) {
      this.info.image_id = res[0].fileid
      this.info.file_path = res[0].filepath
    },
    beforeAvatarUpload (file) {
      const isJPG = file.type === 'image/jpeg' || file.type === 'image/png'
      const isLt2M = file.size / 1024 / 1024 < 2
      if (!isJPG) {
        this.$message.error('只能是 JPG|PNG 格式!')
      }
      if (!isLt2M) {
        this.$message.error('大小不能超过 2MB!')
      }
      return isJPG && isLt2M
    }
  }
}
</script>
