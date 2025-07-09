<template>
  <el-drawer :title="title" :show-close="false"
             :size="size" :wrapperClosable="false"
             :visible.sync="drawer"
             :direction="direction">
    <el-form :model="dataForm"
             ref="dataForm"
             label-width="80px"
             size="mini"
             style="margin-top:10px;padding:15px">

      <el-form-item label="名称"
                    prop="type_name"
                    :rules="[{ required: true, message: '不能空', trigger: 'blur' }]">
        <el-input v-model="dataForm.type_name"
                  maxlength="20"
                  placeholder="最多2y0字符"></el-input>
      </el-form-item>
      <el-form-item label="所属目录"
                    prop="class_no"
                    :rules="[{ required: true, message: '请输入', trigger: 'blur' }]">
        <cms-select v-model="dataForm.class_no"
                    ref="level1"
                    v-bind:action="'/Dictionary/Index'"
                    @select-change="selectOption" />
      </el-form-item>
      <el-form-item label="EN"
                    prop="remark">
        <el-input type="textarea"
                  v-model="dataForm.remark"
                  maxlength="200"
                  :show-word-limit="true"
                  :autosize="{ minRows: 5, maxRows: 12 }"
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
  name: 'teacher.edit',
  data () {
    return {
      title: '编辑',
      drawer: false,
      direction: 'rtl',
      size: process.env.VUE_DRAWER_SIZE,
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
        .DICTIONARY_GET({ id: that.id })
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
    selectOption (val) {
      this.dataForm.class_no = val
    },
    doCancel () {
      this.drawer = false
    },
    doSave (formName) {
      const that = this
      //   that.dataForm.picture_mini = that.$refs.imgUpload.val()
      that.$refs.dataForm.validate((valid) => {
        if (valid) {
          that.$api
            .DICTIONARY_UPDATE(that.dataForm)
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
