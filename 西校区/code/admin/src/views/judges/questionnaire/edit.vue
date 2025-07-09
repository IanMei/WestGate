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
      <el-form-item label="问卷标题"
                    prop="questionnaire_title"
                    :rules="[{ required: true, message: '不能空', trigger: 'blur' }]">
        <el-input v-model="dataForm.questionnaire_title"
                  maxlength="50"
                  placeholder="最多50字符"></el-input>
      </el-form-item>
      <el-form-item label="时间"
                    prop="span"
                    :rules="[{ required: true, message: '不能空', trigger: 'blur' }]">
        <el-date-picker v-model="dataForm.span"
                        type="datetimerange"
                        align="right"
                        start-placeholder="开始日期"
                        end-placeholder="结束日期"
                        :default-time="['00:00:00', '23:59:59']">
        </el-date-picker>
      </el-form-item>

      <el-form-item label="详情"
                    prop="content">
        <cms-editor v-model="dataForm.questionnaire_content"
                    style="height:400px;"
                    id="activityContent"
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
  name: 'activity.edit',
  data () {
    return {
      title: '编辑',
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
        .QUESTIONNAIRE_GET({ id: that.id })
        .then(function (res) {
          that.dataForm = res
          setTimeout(function () {
            that.loading = false
          }, 300)
        })
        .catch(function (error) {
          console.log(error)
        })
    },
    doCancel () {
      this.drawer = false
    },
    doSave (formName) {
      const that = this
      //   that.dataForm.picture_mini = that.$refs.imgUpload.val()
      that.dataForm.questionnaire_content = that.$refs.question_answer.getContent()
      // console.log(that.$refs.question_answer)
      that.$refs.dataForm.validate((valid) => {
        if (valid) {
          that.$api
            .QUESTIONNAIRE_UPDATE(that.dataForm)
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
    },
    handleClick (tab, event) {
      console.log(tab, event)
    },
    handleClose (tag) {
      this.dataForm.tags.splice(this.dataForm.tags.indexOf(tag), 1)
    },
    showInput () {
      this.inputVisible = true
      this.$nextTick((_) => {
        this.$refs.saveTagInput.$refs.input.focus()
      })
    },
    handleInputConfirm () {
      const inputValue = this.inputValue
      if (inputValue) {
        this.dataForm.tags.push(inputValue)
      }
      this.inputVisible = false
      this.inputValue = ''
    }
  }
}
</script>
