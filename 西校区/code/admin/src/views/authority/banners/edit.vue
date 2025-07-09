<template>
  <el-drawer :size="size"
             :show-close="false"
             :visible.sync="drawer"
             :wrapperClosable="false"
             :direction="direction">
    <el-form :model="dataForm"
             ref="dataForm"
             label-width="80px"
             size="mini"
             style="margin-top:10px;padding:15px;overflow-y:auto;height:calc(100vh - 100px);">
      <el-form-item label="排序"
                    prop="seq_no">
        <el-input v-model="dataForm.seq_no"
                  style="width: 100px;"
                  placeholder="数字，越小排名越靠前"
                  onkeyup="value=value.replace(/[^\d]/g,'')"></el-input>
      </el-form-item>
      <el-form-item label="标题"
                    prop="banner_title"
                    :rules="[{ required: true, message: '不能空', trigger: 'blur' }]">
        <el-input v-model="dataForm.banner_title"
                  maxlength="50"
                  placeholder="最多50字符"></el-input>
      </el-form-item>
      <el-form-item label="位置">
        <cms-select v-model="dataForm.banner_type"
                    v-bind:action="'/banner/Types'"
                    @select-change="selectOption" />
      </el-form-item>
      <el-form-item label="缩略图">
        <cms-upload tips="图片最佳尺寸 400 * 400"
                    ref="imgUpload"
                    :imgid="dataForm.image_id"
                    :vw="400"
                    :vh="400"></cms-upload>
      </el-form-item>
      <el-form-item label="图名称"
                    prop="picture_name">
        <el-input v-model="dataForm.picture_name"
                  maxlength="50"
                  placeholder="最多50字符"></el-input>
      </el-form-item>
      <el-form-item label="url地址"
                    prop="html_url">
        <el-input v-model="dataForm.html_url"
                  maxlength="200"
                  placeholder="最多100字符"></el-input>
      </el-form-item>

      <el-form-item label="介绍"
                    prop="content">
        <cms-editor v-model="dataForm.content" id="bannerContent"
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
  name: 'article.type.edit',
  data () {
    return {
      rad: Math.random(),
      datespan: [],
      title: '编辑',
      drawer: false,
      direction: 'rtl',
      size: '30%',
      dataForm: {},
      loading: false,
      inputVisible: false,
      inputValue: '',
      id: -1
    }
  },
  methods: {
    selectOption: function (val) {
      const that = this
      that.dataForm.banner_type = val
    },
    show (id) {
      const that = this
      that.rad = Math.random()
      that.title = '编辑'
      that.id = id
      if (id === -1) {
        that.title = '新增'
        that.$nextTick(function () {
          that.$refs.dataForm.clearValidate()
        })
      }
      that.drawer = true
      that.loading = true
      that.$api
        .BANNER_GET({ id: that.id })
        .then(function (res) {
          that.dataForm = res
          if (res.date_play) {
            that.datespan = [res.date_play, res.date_end]
          } else {
            that.datespan = []
          }
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
      that.dataForm.image_id = that.$refs.imgUpload.val()
      that.dataForm.content = that.$refs.question_answer.getContent()
      that.$refs.dataForm.validate((valid) => {
        if (valid) {
          that.$api
            .BANNER_UPDATE(that.dataForm)
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
