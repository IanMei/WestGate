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
       <el-row>
        <el-col :span="12">
          <el-form-item label="昵称"
                        :rules="[{ required: true, message: '不能空', trigger: 'blur' }]"
                        prop="nick_name">
            <el-input v-model="dataForm.nick_name"
                      maxlength="20"
                      placeholder="最多20字符"></el-input>
          </el-form-item>
        </el-col>

      </el-row>
      <el-row>
        <el-col :span="12">
          <el-form-item label="用户名"
                        :rules="[{ required: true, message: '不能空', trigger: 'blur' }]"
                        prop="mobile">
            <el-input v-model="dataForm.mobile"
                      maxlength="20"
                      placeholder="手机号"></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="密码"
                        :rules="[{ required: true, message: '不能空', trigger: 'blur' }]"
                        prop="user_pwd">
            <el-input v-model="dataForm.user_pwd"
                      maxlength="20"
                      placeholder="最多20字符"></el-input>
          </el-form-item>
        </el-col>
      </el-row>
      <el-row>
        <el-col :span="12">
          <el-form-item label="工作单位"   :rules="[{ required: true, message: '不能空', trigger: 'blur' }]"
                        prop="company">
            <el-input v-model="dataForm.company"
                      maxlength="50"
                      placeholder="最多50字符"></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="职位"   :rules="[{ required: true, message: '不能空', trigger: 'blur' }]"
                        prop="position">
            <el-input v-model="dataForm.position"
                      maxlength="20"
                      placeholder="最多20字符"></el-input>
          </el-form-item>
        </el-col>
      </el-row>
      <el-row>
        <el-col :span="12">
          <el-form-item label="省市"
                        :rules="[{ required: true, message: '不能空', trigger: 'blur' }]"
                        prop="city_no">
            <el-cascader v-model="dataForm.arrayarea"
                         :options="options"
                         style="width:100%"
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
     <el-row>
        <el-col :span="12">
          <el-form-item label="联系人"
                        prop="link_man">
            <el-input v-model="dataForm.link_man"
                      maxlength="20"
                      placeholder="最多20字符"></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="联系电话"
                        prop="link_tel">
            <el-input v-model="dataForm.link_tel"
                      maxlength="20"
                      placeholder="最多20字符"></el-input>
          </el-form-item>
        </el-col>
      </el-row>
        <el-row>
        <el-col :span="12">
          <el-form-item label="电子邮件"
                        prop="email">
            <el-input v-model="dataForm.email"
                      maxlength="20"
                      placeholder="最多20字符"></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="微信"
                        prop="wechat">
            <el-input v-model="dataForm.wechat"
                      maxlength="20"
                      placeholder="最多20字符"></el-input>
          </el-form-item>
        </el-col>
      </el-row>
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
      size: '550px',
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
        .JUDGES_GET({ id: that.id })
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
      that.$refs.dataForm.validate((valid) => {
        if (valid) {
          that.$api
            .JUDGES_UPDATE(that.dataForm)
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
