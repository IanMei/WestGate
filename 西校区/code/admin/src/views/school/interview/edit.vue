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

      <el-form-item label="标题"
                    prop="title"
                    :rules="[{ required: true, message: '不能空', trigger: 'blur' }]">
        <el-input v-model="dataForm.title"
                  maxlength="50"
                  placeholder="最多50字符"></el-input>
      </el-form-item>
      <el-form-item label="学校"
                    prop="school_no">
        <cms-select v-model="dataForm.school_no"
                    ref="level1"
                    v-bind:action="'/School/Select'"
                    @select-change="selectOption" />
      </el-form-item>
      <el-form-item label="简述"
                    prop="description">
        <el-input type="textarea"
                  v-model="dataForm.description"
                  maxlength="200"
                  :show-word-limit="true"
                  :autosize="{ minRows: 5, maxRows: 12 }"
                  placeholder="最多200字符"></el-input>
      </el-form-item>
      <el-form-item label="专访内容"
                    prop="content">
        <cms-editor v-model="dataForm.content" id="interviewContent"
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
    selectOption (val) {
      this.dataForm.school_no = val
    },
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
        .INTERVIEW_GET({ id: that.id })
        .then(function (res) {
          that.dataForm = res
          if (that.id < 0) {
            that.dataForm.file_type = '01'
            that.dataForm.school_no = ''
          }
          setTimeout(function () {
            that.loading = false
          }, 300)
        })
        .catch(function (error) {
          console.log(error)
        })
    },
    handleChange (value) {
      console.log(value)
      const that = this
      that.dataForm.arrayarea = value
      if (value.length === 3) {
        that.dataForm.province_no = value[0]
        that.dataForm.city_no = value[1]
        that.dataForm.disyrict_no = value[2]
      }
    },
    doCancel () {
      this.drawer = false
    },
    doSave (formName) {
      const that = this
      //   that.dataForm.image_id = that.$refs.imgUpload.val()
      that.dataForm.content = that.$refs.question_answer.getContent()
      that.$refs.dataForm.validate((valid) => {
        if (valid) {
          that.$api
            .INTERVIEW_UPDATE(that.dataForm)
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
