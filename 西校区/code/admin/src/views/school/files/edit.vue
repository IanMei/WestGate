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
      <el-form-item label="图片/封面">
        <cms-upload tips="点击 ‘ + ’ 上传"
                    ref="imgUpload"
                    :imgid="dataForm.image_id"
                    :vw="200"
                    :vh="150"></cms-upload>
      </el-form-item>
      <el-form-item label="类型"
                    prop="file_type"
                    :rules="[{ required: true, message: '不能空', trigger: 'blur' }]">
        <el-radio-group v-model="dataForm.file_type">
          <el-radio-button label="01">图片</el-radio-button>
          <el-radio-button label="02">视频链接</el-radio-button>
        </el-radio-group>
      </el-form-item>
      <el-form-item label="学校"
                    prop="school_no">
        <cms-select v-model="dataForm.school_no"
                    ref="level1"
                    v-bind:action="'/School/Select'"
                    @select-change="selectOption" />
      </el-form-item>

      <el-form-item label="标题"
                    prop="title"
                    :rules="[{ required: true, message: '不能空', trigger: 'blur' }]">
        <el-input v-model="dataForm.title"
                  maxlength="50"
                  placeholder="最多50字符"></el-input>
      </el-form-item>
      <el-form-item label="视频链接"
                    v-show="dataForm.file_type === '02'"
                    prop="video_url">
        <el-input v-model="dataForm.video_url"
                  maxlength="200"
                  placeholder="最多200字符"></el-input>
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
        .SCHOOL_FILE_GET({ id: that.id })
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
      that.dataForm.image_id = that.$refs.imgUpload.val()
      that.$refs.dataForm.validate((valid) => {
        if (valid) {
          that.$api
            .SCHOOL_FILE_UPDATE(that.dataForm)
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
