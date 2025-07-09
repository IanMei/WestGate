<template>

  <d2-container>
    <el-form :model="dataForm"
             ref="dataForm"
             size="mini"
             label-width="80px"
             style="width:1000px; padding:0px 10px;">
      <el-tabs v-model="activeName"
               :tab-click="handleClick">
        <el-tab-pane label="基本信息"
                     name="first">
          <el-form-item label="网站名称"
                        prop="setup_name"
                        :rules="[{ required: true, message: '不能空', trigger: 'blur' }]">
            <el-input v-model="dataForm.setup_name"
                      maxlength="20"
                      style="width:250px"> </el-input>
          </el-form-item>
          <el-form-item label="联系人"
                        prop="link_man">
            <el-input v-model="dataForm.link_man"
                      maxlength="20"
                      style="width:250px"> </el-input>
          </el-form-item>
          <el-form-item label="电子邮箱"
                        prop="email">
            <el-input v-model="dataForm.email"
                      maxlength="20"
                      style="width:250px"></el-input>
          </el-form-item>
          <el-form-item label="服务热线"
                        prop="service_tel"
                        :rules="[{ required: true, message: '不能空', trigger: 'blur' }]">
            <el-input v-model="dataForm.service_tel"
                      maxlength="50"
                      style="width:250px"></el-input>
          </el-form-item>
          <el-form-item label="公司地址"
                        prop="company"
                        :rules="[{ required: true, message: '不能空', trigger: 'blur' }]">
            <el-input v-model="dataForm.company"
                      maxlength="50"
                      style="width:250px"></el-input>
          </el-form-item>
          <el-form-item label="备案号"
                        prop="record"
                        :rules="[{ required: true, message: '不能空', trigger: 'blur' }]">
            <el-input v-model="dataForm.record"
                      maxlength="20"
                      style="width:250px"></el-input>
          </el-form-item>
          <el-form-item label="页面版权"
                        prop="copyright"
                        :rules="[{ required: true, message: '不能空', trigger: 'blur' }]">
            <el-input v-model="dataForm.copyright"
                      maxlength="200"
                      style="width:500px"></el-input>
          </el-form-item>
          <el-form-item label="搜索标签" v-show="false">
            <cms-tags ref="tags"
                      v-model="dataForm.tags"></cms-tags>
          </el-form-item>
          <el-form-item label="平台简介"
                        prop="description">
            <el-input type="textarea"
                      v-model="dataForm.description"
                      maxlength="200"
                      :show-word-limit="true"
                      :autosize="{ minRows: 6, maxRows: 12 }"
                      placeholder="描述"></el-input>
          </el-form-item>
        </el-tab-pane>
        <el-tab-pane label="图片信息"
                     name="second">
          <el-form-item label="Logo">
            <cms-upload tips="高宽比列 321 : 100"
                        ref="image_id"
                        :imgid="dataForm.image_id"
                        :vw="321"
                        :vh="100"></cms-upload>
          </el-form-item>
          <el-form-item label="底部图" v-show="false">
            <cms-upload tips="高宽比列 321 : 100"
                        :imgid="dataForm.image_id1"
                        ref="image_id1"
                        :vw="321"
                        :vh="100"></cms-upload>
          </el-form-item>
          <el-form-item label="二维码">
            <cms-upload tips="高宽比列 100 : 100"
                        :imgid="dataForm.qr_id"
                        ref="qr_id"
                        :vw="100"
                        :vh="100"></cms-upload>
          </el-form-item>
        </el-tab-pane>
        <el-tab-pane label="合作伙伴"
                     name="third">
          <template v-for="(item,index) in dataForm.details">
            <el-form-item label="Logo"
                          :key="index">
              <el-col :span="6"
                      style="padding-left:0px;">
                <cms-upload tips="高宽比列 321 : 100"
                            ref="imageLogo"
                            :imgid="item.image_id"
                            :vw="160"
                            @select-change="a=> changeImage(a,item)"
                            :vh="50"></cms-upload>
              </el-col>
              <el-col :span="6"
                      style="padding-left:0px;">
                <el-input placeholder="机构名称"
                          @change="LinkChange(item)"
                          v-model="item.link_name"
                          maxlength="20"
                          autocomplete="off"></el-input>
              </el-col>
              <el-col class="line"
                      :span="2"
                      style="text-align: right;padding-right:10px;">地址</el-col>
              <el-col :span="6"
                      style="padding-left:0px;">
                <el-input placeholder="链接地址"
                          @change="LinkChange(item)"
                          v-model="item.link_url"
                          maxlength="200"
                          autocomplete="off"></el-input>
              </el-col>
              <el-col :span="2"
                      style="padding-left:10px;">
                <el-button type="danger"
                           v-on:click="doDel(item, index)"
                           :loading="loading">－</el-button>
              </el-col>
            </el-form-item>
          </template>
        </el-tab-pane>
        <el-tab-pane label="问卷调查"
                     name="questionnaire">
          <el-form-item label="调查问卷">
            <el-switch style="display: block;margin-top:2px;"
                       v-model="dataForm.questionnaire"
                       active-color="#13ce66"
                       inactive-color="#ff4949"
                       active-text="开启"
                       inactive-text="关闭">
            </el-switch>
          </el-form-item>
          <el-form-item label="问卷标题"
                        prop="questionnaire_title">
            <el-input v-model="dataForm.questionnaire_title"
                      maxlength="100" :disabled="!dataForm.questionnaire"
                      style="width:450px"> </el-input>
          </el-form-item>
          <el-form-item label="截止时间"
                        prop="questionnaire_end">
            <el-date-picker v-model="dataForm.questionnaire_end"
                            type="datetime" :disabled="!dataForm.questionnaire"
                            placeholder="选择日期时间">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="问卷说明" v-show="dataForm.questionnaire"
                        prop="questionnaire_content">
            <cms-editor v-model="dataForm.questionnaire_content" id="questionnaireContent"
                        style="height:400px;" :disabled="!dataForm.questionnaire"
                        ref="question_answer"></cms-editor>
          </el-form-item>

        </el-tab-pane>
      </el-tabs>
      <div style="margin-left:92px;">
        <el-button type="primary"
                   size="mini"
                   v-on:click="Update('dataForm')"
                   :loading="loading">保 存</el-button>
        <el-button type="success"
                   size="mini"
                   v-if="activeName === 'third'"
                   v-on:click="doAdd()"
                   :loading="loading">添加友情链接</el-button>
      </div>
    </el-form>
  </d2-container>
</template>
<script>
export default {
  name: 'settings',
  data () {
    return {
      activeName: 'first',
      loading: false,
      dataForm: {
        link_man: '',
        link_tel: '',
        keywords: '',
        conceal: '隐私条款',
        agress: '服务条款',
        about: '关于我们'
      },
      inputVisible: false,
      inputValue: ''
    }
  },
  created: function () {
    const that = this
    that.GetData()
  },
  mounted: function () {},
  methods: {
    changeImage (id, row) {
      row.image_id = id
      if (row.curmodel === 4 || row.curmodel === 2) {
        row.curmodel = 2
      }
    },
    handleClick (tab, event) {
      console.log(tab, event)
    },
    GetData () {
      const that = this
      that.loading = true
      that.$api
        .SYS_SETTINGS_GET()
        .then(function (res) {
          that.dataForm = res
          setTimeout(function () {
            that.loading = false
          }, 300)
        })
        .catch(function (error) {
          console.log(error)
          setTimeout(function () {
            that.loading = false
          }, 300)
        })
    },
    LinkChange (row) {
      if (row.curmodel === 4 || row.curmodel === 2) {
        row.curmodel = 2
      }
    },
    doAdd () {
      const that = this
      var data = that.dataForm.details
      if (data && data.length > 9) {
        that.$message({
          showClose: true,
          message: '最多只能10个链接',
          type: 'warning'
        })
      } else {
        data.push({
          curmodel: 1,
          link_id: 0,
          link_name: '',
          link_url: '',
          remark: ''
        })
      }
    },
    doDel (row, index) {
      const that = this
      var idx = that.dataForm.details.indexOf(row)
      that.dataForm.details.splice(idx, 1)
    },
    Update (formName) {
      const that = this
      that.dataForm.image_id = that.$refs.image_id.val()
      that.dataForm.image_id1 = that.$refs.image_id1.val()
      that.dataForm.qr_id = that.$refs.qr_id.val()
      that.dataForm.questionnaire_content = that.$refs.question_answer.getContent()
      console.log(that.dataForm)
      for (let i = 0; i < that.dataForm.details.length; i++) {
        var currRow = that.dataForm.details[i]
        if (currRow.curmodel === 1) {
          if (currRow.link_name === '' || currRow.link_url === '') {
            that.$message.error({
              showClose: true,
              message: '友情链接必填',
              type: 'error'
            })
            return false
          }
        } else if (currRow.curmodel === 2) {
          if (currRow.link_name === '' || currRow.link_url === '') {
            that.$message.error({
              showClose: true,
              message: '友情链接必填',
              type: 'error'
            })
            return false
          }
        }
      }
      that.$refs.dataForm.validate((valid) => {
        if (valid) {
          that.loading = true
          that.$api
            .SYS_SETTINGS_UPDATE(that.dataForm)
            .then(function (res) {
              that.$message({
                message: '更新成功',
                type: 'success'
              })
              that.GetData()
              setTimeout(function () {
                that.loading = false
              }, 300)
            })
            .catch(function (error) {
              console.log(error)
              setTimeout(function () {
                that.loading = false
              }, 300)
            })
        } else {
          return false
        }
      })
    }
  }
}
</script>
