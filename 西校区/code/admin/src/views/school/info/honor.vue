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
      <template v-for="(item,index) in dataForm.honors">
        <el-form-item label="年份"
                      :key="index">
          <el-col :span="6"
                  style="padding-left:0px;">
            <el-input placeholder="年份"
                      @change="LinkChange(item)"
                      v-model="item.honor_year"
                      maxlength="20" style="width:80%"
                      autocomplete="off"></el-input>
          </el-col>
          <el-col :span="14"
                  style="padding-left:0px;">
             <el-input type="textarea"
                  v-model="item.honor_desc"
                  maxlength="200"   @change="LinkChange(item)"
                  :show-word-limit="true"
                  :autosize="{ minRows: 5, maxRows: 12 }"
                  placeholder="荣誉说明"></el-input>
          </el-col>
          <el-col :span="4"
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
                   :loading="loading">增加荣誉</el-button>
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
      title: '荣誉',
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
      that.title = '招生信息'
      if (id === -1) {
        that.title = '招生信息'
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
    },
    LinkChange (row) {
      if (row.curmodel === 4 || row.curmodel === 2) {
        row.curmodel = 2
      }
    },
    doAdd () {
      const that = this
      var data = that.dataForm.honors
      if (data && data.length > 19) {
        that.$message({
          showClose: true,
          message: '最多只能20个荣誉',
          type: 'warning'
        })
      } else {
        data.push({
          curmodel: 1,
          school_no: that.dataForm.school_no,
          honor_year: '',
          honor_desc: '',
          remark: ''
        })
      }
    },
    doDel (row, index) {
      const that = this
      var idx = that.dataForm.honors.indexOf(row)
      that.dataForm.honors.splice(idx, 1)
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
