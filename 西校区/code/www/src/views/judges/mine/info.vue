<template>
  <div class="houtai_right_mid ">
    <div class="tou_gai pc">
      <div class="touer">
        <span>头像修改</span>
        <div class="tou_kuang">
          <el-avatar :size="122"
                     :src="info.file_path">
            <img src="https://cube.elemecdn.com/e/fd/0fc7d20532fdaf769a25683617711png.png" />
          </el-avatar>
          <el-upload :action="IMAGE_UPLOAD"
                     :show-file-list="false"
                     :on-success="handleAvatarSuccess"
                     :before-upload="beforeAvatarUpload">

            <a class="tou_kuang_a"
               style="width: 100px; margin-left:10px"
               href="javascript:;">上传头像</a>
          </el-upload>
        </div>
        <a href="javascript:;"
           @click="update"
           class="qrxg">确认修改</a>
      </div>
      <div class="ps">
        <p>注：头像要求为评委本人正式着装照片，分辨率不小于400*400，支持jpeg/png格式，参考如下样式。</p>
        <img src="/static/images/renxiang.jpg"
             class="fang" />
        <img src="/static/images/renxiang.jpg"
             class="yuan" />
        <img src="/static/images/chang.png"
             class="chang" />
      </div>
    </div>

    <div class="houtai wap">
      <div class="azhetou">
        <a href="javascript:;">
          <dd style="line-height: 60px;">头像</dd>
          <el-upload :action="IMAGE_UPLOAD"
                     style="float:right"
                     :show-file-list="false"
                     :on-success="handleAvatarSuccess"
                     :before-upload="beforeAvatarUpload">
            <img :src="info.file_path">
          </el-upload>
        </a>
      </div>
    </div>

    <div class="rongyu">
      <span>职业履历</span>
      <el-row>
        <el-col :span="6"
                style="font-size:15px;">年份</el-col>
        <el-col :span="14"
                style="font-size:15px">职位
        </el-col>
        <el-col :span="3"
                style="font-size:15px">
          <!-- <a href="javascript:;"
             @click="addResume" style="float:left"
             class="rongyu_a">添加</a> -->
          <el-button icon="el-icon-plus"
                     size="mini"
                     type="success"
                     @click="addResume"
                     style="margin-left:10px"
                     circle></el-button>
        </el-col>
      </el-row>
      <el-row style="margin-top:15px;"
              v-for="(item,index) in info.resume"
              :key="item.id">
        <el-col :span="6">
          <el-input maxlength="4"
                    v-model="item.honor_year"
                    style="width:95%"
                    placeholder="如：2020"
                    size="small"></el-input>
        </el-col>
        <el-col :span="14">
          <el-input maxlength="200"
                    v-model="item.honor_desc"
                    style="width:100%"
                    auto-complete="off"
                    placeholder="中文"
                    size="small"></el-input>
        </el-col>
        <el-col :span="3">
          <el-button type="danger"
                     size="mini"
                     @click="removeResume(index)"
                     icon="el-icon-delete"
                     style="margin-left:10px"
                     circle></el-button>
        </el-col>
      </el-row>
    </div>

    <div class="rongyu">
      <span>荣誉奖项</span>
      <el-row>
        <el-col :span="6"
                style="font-size:15px;">年份</el-col>
        <el-col :span="14"
                style="font-size:15px">荣誉奖项
        </el-col>
        <el-col :span="3"
                style="font-size:15px">
          <el-button icon="el-icon-plus"
                     size="mini"
                     type="success"
                     @click="addHonor"
                     style="margin-left:10px"
                     circle></el-button>
        </el-col>
      </el-row>
      <el-row style="margin-top:15px;"
              v-for="(item,index) in info.honors"
              :key="item.id">
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
                    style="width:100%"
                    auto-complete="off"
                    placeholder="中文"
                    size="small"></el-input>
        </el-col>
        <el-col :span="3">
          <el-button type="danger"
                     size="mini"
                     @click="removeHonor(index)"
                     icon="el-icon-delete"
                     style="margin-left:10px"
                     circle></el-button>
        </el-col>
      </el-row>
    </div>
    <div class="dizhi pc">
      <span>通讯地址</span>
      <el-form ref="form"
               style="margin-top:20px;"
               :model="info"
               label-width="80px"
               size="small">
        <el-row>
          <el-row>
            <el-col :span="12">
              <el-form-item label="收件人">
                <el-input v-model="info.link_man"
                          maxlength="20"></el-input>
              </el-form-item>
            </el-col>
            <el-col :span="12">
              <el-form-item label="收件电话">
                <el-input v-model="info.link_tel"
                          maxlength="20"></el-input>
              </el-form-item>
            </el-col>
          </el-row>
          <el-col :span="12">
            <el-form-item label="省/市">
              <el-cascader v-model="info.arrayarea"
                           :options="options"
                           style="width:100%"
                           @change="handleChange"></el-cascader>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="街道">
              <el-input v-model="info.address"
                        style="width:100%"
                        maxlength="50"
                        placeholder="区县+街道/门牌号"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="12">
            <el-form-item label="电子邮箱">
              <el-input v-model="info.email"
                        maxlength="20"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="微信">
              <el-input v-model="info.wechat"
                        maxlength="20"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <a class="dizhi_save"
           href="javascript:;"
           @click="update">保存</a>
      </el-form>
    </div>

    <div class="dizhi wap"
         style="margin-top:20px;">
      <span>通讯地址</span>
      <el-form ref="form"
               style="margin-top:20px;"
               :model="info"
               label-width="70px"
               size="small">
        <el-form-item label="收件人">
          <el-input v-model="info.link_man"
                    maxlength="20"></el-input>
        </el-form-item>
        <el-form-item label="收件电话">
          <el-input v-model="info.link_tel"
                    maxlength="20"></el-input>
        </el-form-item>
        <el-form-item label="电子邮箱">
          <el-input v-model="info.email"
                    placeholder="@"
                    maxlength="20"></el-input>
        </el-form-item>

        <el-form-item label="微信">
          <el-input v-model="info.wechat"
                    maxlength="20"></el-input>
        </el-form-item>

        <el-form-item label="省/市">
          <el-cascader v-model="info.arrayarea"
                       :options="options"
                       @change="handleChange"></el-cascader>
        </el-form-item>
        <el-form-item label="街道">
          <el-input v-model="info.address"
                    style="width:100%"
                    maxlength="50"
                    placeholder="区县+街道/门牌号"></el-input>
        </el-form-item>

        <a class="dizhi_save"
           style="padding-top: 3px;padding-bottom: 3px;"
           href="javascript:;"
           @click="update">保存</a>
      </el-form>
    </div>
  </div>
</template>
<script>
import api from '@/api'
export default {
  data () {
    return {
      info: {},
      options: [],
      IMAGE_UPLOAD: process.env.BASE_UPLOAD
    }
  },
  created () {
    this.$store.commit('setJudgesTab', 1)
    let self = this
    api
      .GET('/Judges/Info')
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
  },
  methods: {
    addResume () {
      let self = this
      var emptyRow = self.info.resume.filter((a) => {
        return a.honor_year === '' || a.honor_desc === ''
      })
      if (emptyRow && emptyRow.length > 0) {
        self.$message({
          message: '存在未填写完成的履历，不能继续添加',
          type: 'error'
        })
        return
      }
      self.info.resume.push({
        honor_year: '',
        honor_desc: ''
      })
    },
    removeResume (index) {
      let self = this
      if (index >= 0) {
        self.info.resume.splice(index, 1)
      }
    },
    addHonor () {
      let self = this
      var emptyRow = self.info.honors.filter((a) => {
        return a.honor_year === '' || a.honor_desc === ''
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
    update () {
      const that = this
      api
        .POST('/Judges/update', that.info)
        .then(function (res) {
          that.$store.commit('setJudges', that.info)
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
