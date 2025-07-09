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
      <template v-for="(item,index) in dataForm.list">
        <el-form-item :label="(index+1) + '. '"
                      :key="index">
          <el-col :span="20"
                  style="padding-left:0px;">
           <el-input type="textarea"
                        @change="LinkChange(item)"
                        v-model="item.title"
                        maxlength="100"
                        style="width:100%"
                        :show-word-limit="true"
                        :autosize="{ minRows: 5, maxRows: 12 }"
                        placeholder="项目标题,最多100字符"></el-input>
          </el-col>

          <el-col :span="2"
                  style="padding-left:10px;">
            <el-button type="danger"
                       v-on:click="doDel(item, index)"
                       :loading="loading">－</el-button>
          </el-col>
        </el-form-item>
      </template>
    </el-form>
    <div slot="title"
         style="">
      {{ title }}
      <div style="float:right;">

        <el-button type="success"
                   size="mini"
                   v-on:click="doAdd()"
                   :loading="loading">增加项目</el-button>
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
  name: 'school.point',
  data () {
    return {
      title: '招生信息',
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
      that.title = '调查项'
      if (id === -1) {
        that.title = '调查项'
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
    LinkChange (row) {
      if (row.curmodel === 4 || row.curmodel === 2) {
        row.curmodel = 2
      }
    },
    doAdd () {
      const that = this
      var data = that.dataForm.list
      if (data && data.length > 19) {
        that.$message({
          showClose: true,
          message: '最多只能20个',
          type: 'warning'
        })
      } else {
        data.push({
          curmodel: 1,
          questionnaire_no: that.dataForm.questionnaire_no,
          title: '',
          result_max: 5,
          remark: ''
        })
      }
    },
    doDel (row, index) {
      const that = this
      var idx = that.dataForm.list.indexOf(row)
      that.dataForm.list.splice(idx, 1)
    },
    selectOption (val) {
      this.dataForm.recruit_type = val
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
    }
  }
}
</script>
