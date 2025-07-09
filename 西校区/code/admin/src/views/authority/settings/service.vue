<template>

  <d2-container>
    <el-form :model="dataForm"
             ref="dataForm"
             size="mini"
             label-width="80px"
             style="width:1000px; padding:0px 10px;">
      <el-form-item
                    prop="questionnaire_content">
        <cms-editor v-model="dataForm.service_clause" id="service_clause"
                    style="height:400px;"
                    ref="service_clause"></cms-editor>
      </el-form-item>
      <div style="margin-left:92px;">
        <el-button type="primary"
                   size="mini"
                   v-on:click="Update('dataForm')"
                   :loading="loading">保 存</el-button>
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
      that.dataForm.service_clause = that.$refs.service_clause.getContent()
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
