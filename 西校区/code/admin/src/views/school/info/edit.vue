<template>
  <el-drawer :title="title"
             :show-close="false"
             :size="size"
             :wrapperClosable="false"
             :visible.sync="drawer"
             :direction="direction">
    <el-form :model="dataForm"
             ref="dataForm"
             label-width="80px"
             size="mini"
             style="margin-top:10px;padding:15px">
      <el-form-item label="logo">
        <cms-upload tips="高宽比列 1 : 1"
                    ref="imgUpload"
                    :imgid="dataForm.image_id"
                    :vw="100"
                    :vh="100"></cms-upload>
      </el-form-item>
      <el-form-item label="中文名"
                    prop="school_name"
                    :rules="[{ required: true, message: '不能空', trigger: 'blur' }]">
        <el-input v-model="dataForm.school_name"
                  maxlength="20"
                  placeholder="最多20字符"></el-input>
      </el-form-item>
      <el-form-item label="英文名"
                    prop="en_name">
        <el-input v-model="dataForm.en_name"
                  maxlength="50"
                  placeholder="最多50字符"></el-input>
      </el-form-item>
      <el-row>
        <el-col :span="12">
          <el-form-item label="省市区"
                        :rules="[{ required: true, message: '不能空', trigger: 'blur' }]"
                        prop="city_no">
            <el-cascader v-model="dataForm.arrayarea"
                         :options="options"
                         @change="handleChange"></el-cascader>
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="街道/门牌"
                        prop="address">
            <el-input v-model="dataForm.address"
                      maxlength="50"
                      placeholder="最多50字符"></el-input>
          </el-form-item>
        </el-col>
      </el-row>
      <el-form-item label="英文地址"
                    prop="address_en">
        <el-input v-model="dataForm.address_en"
                  maxlength="50"
                  placeholder="最多50字符"></el-input>
      </el-form-item>
      <el-form-item label="学校网站"
                    prop="home_page">
        <el-input v-model="dataForm.home_page"
                  maxlength="200"
                  placeholder="最多200字符"></el-input>
      </el-form-item>
      <el-form-item label="课程体系"
                    prop="especially_course"
                    :rules="[{ required: true, message: '请输入', trigger: 'blur' }]">
        <cms-select v-model="dataForm.especially_course"
                    ref="level1"
                    v-bind:action="'/Dictionary/Select?indexCode=05'"
                    @select-change="selectOption" />
      </el-form-item>
      <el-row>
        <el-col :span="8">
          <el-form-item label="用户名"
                        :rules="[{ required: true, message: '不能空', trigger: 'blur' }]"
                        prop="mobile">
            <el-input v-model="dataForm.mobile"
                      maxlength="20"
                      placeholder="手机号"></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="8">
          <el-form-item label="密码"
                        :rules="[{ required: true, message: '不能空', trigger: 'blur' }]"
                        prop="user_pwd">
            <el-input v-model="dataForm.user_pwd"
                      maxlength="20"
                      placeholder="最多20字符"></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="8">
             <el-form-item label="推荐人"
                        prop="referrer">
            <el-input v-model="dataForm.referrer"
                      maxlength="20"
                      placeholder="最多20字符"></el-input>
          </el-form-item>
        </el-col>
      </el-row>

      <el-row>
        <el-col :span="8">
          <el-form-item label="学生人数"
                        prop="stu_qty">
            <el-input v-model="dataForm.stu_qty"
                      maxlength="10"
                      placeholder="数字"></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="8">
          <el-form-item label="招生人数"
                        prop="recruit_qty">
            <el-input v-model="dataForm.recruit_qty"
                      maxlength="10"
                      placeholder="数字"></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="8">
          <el-form-item label="师生配比"
                        prop="tas_rate">
            <el-input v-model="dataForm.tas_rate"
                      maxlength="50"
                      placeholder="0-100"></el-input>
          </el-form-item>
        </el-col>
      </el-row>
      <el-row>
        <el-col :span="8">
          <el-form-item label="外教占比"
                        prop="ft_qty">
            <el-input v-model="dataForm.ft_qty"
                      maxlength="3"
                      placeholder="0-100"></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="8">
          <el-form-item label="录取比率"
                        prop="enroll_rate">
            <el-input v-model="dataForm.enroll_rate"
                      maxlength="10"
                      placeholder="数字"></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="8">
          <el-form-item label="报名人数"
                        prop="enroll_qty">
            <el-input v-model="dataForm.enroll_qty"
                      maxlength="10"
                      placeholder="数字"></el-input>
          </el-form-item>
        </el-col>
      </el-row>
      <el-form-item label="学校介绍"
                    prop="content">
        <cms-editor v-model="dataForm.content" id="schoolContent"
                    style="height:400px;"
                    ref="question_answer"></cms-editor>
      </el-form-item>
    </el-form>
    <div slot="title"
         style="">
      {{ title }}
      <div style="float:right;">
        <el-button type="primary"
                   size="mini"
                   @click="doSave"
                   :loading="loading">确 定</el-button>
        <el-button v-on:click="doCancel()"
                   size="mini"
                   :loading="loading">取 消</el-button>
      </div>
    </div>
  </el-drawer>
</template>

<script>
export default {
  name: 'school.edit',
  data () {
    return {
      value: [],
      title: '编辑',
      options: [],
      drawer: false,
      direction: 'rtl',
      size: '650px',
      dataForm: {},
      loading: false,
      inputVisible: false,
      inputValue: '',
      id: -1
    }
  },
  methods: {
    show (id) {
      const that = this
      that.id = id
      that.title = '编辑'
      if (id === -1) {
        that.title = '新增'
        that.$nextTick(function () {
          try {
            that.$refs.dataForm.clearValidate()
          } catch {}
        })
      }
      that.drawer = true
      that.loading = true
      that.$api
        .SCHOOL_GET({ id: that.id })
        .then(function (res) {
          that.dataForm = res
          setTimeout(function () {
            that.loading = false
          }, 300)
        })
        .catch(function (error) {
          console.log(error)
        })
      that.$api
        .AREA_LIST()
        .then(function (res) {
          that.options = res
        })
        .catch(function (error) {
          console.log(error)
        })
    },
    selectOption (val) {
      this.dataForm.especially_course = val
    },
    handleChange (value) {
      console.log(value)
      const that = this
      that.dataForm.arrayarea = value
      if (value.length === 2) {
        that.dataForm.province_no = value[0]
        that.dataForm.city_no = value[1]
      }
    },
    doCancel () {
      this.drawer = false
    },
    doSave (formName) {
      const that = this
      that.dataForm.image_id = that.$refs.imgUpload.val()
      that.dataForm.content = that.$refs.question_answer.getContent()
      that.$refs.dataForm.validate((valid) => {
        if (valid) {
          that.$api
            .SCHOOL_UPDATE(that.dataForm)
            .then(function (res) {
              that.$message({
                message: '操作成功',
                type: 'success'
              })
              that.drawer = false
              that.$emit('success', res)
            })
            .catch(function (error) {
              console.log(error)
            })
        } else {
          return false
        }
      })
    }
  }
}
</script>
