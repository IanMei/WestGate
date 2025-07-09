<template>
  <d2-container>
    <el-form :inline="true"
             :model="formSearch"
             class="demo-form-inline"
             size="mini"
             slot="header">
      <el-row>
        <el-col :span="8"
                style="height:25px;">
        </el-col>
        <el-col :span="16"
                style="height:25px;text-align:right;">
          <el-form-item>
            <cms-button text="导出"
                        type="primary"
                        icon="el-icon-download"
                        v-on:click="doExport"
                        authcode="400020030"></cms-button>

          </el-form-item>
        </el-col>
      </el-row>
    </el-form>
    <el-table ref="multipleTable"
              :data="list"
              :border="true"
              v-loading="loading"
              tooltip-effect="dark"
              style="width: 100%"
              v-on:selection-change="handleSelectionChange">
      <el-table-column prop="nick_name"
                       width="150"
                       label="姓名">
      </el-table-column>
      <el-table-column prop="company"
                       width="180"
                       label="单位">
      </el-table-column>
      <el-table-column prop="position"
                       width="120"
                       label="职务">
      </el-table-column>
      <el-table-column prop="title"
                       width="280"
                       show-overflow-tooltip
                       label="问题">
      </el-table-column>
      <el-table-column prop="school_name"
                       width="280"
                       show-overflow-tooltip
                       label="学校">
      </el-table-column>
      <el-table-column prop="reason"
                       show-overflow-tooltip
                       label="原因">
      </el-table-column>
    </el-table>
  </d2-container>
</template>

<script>
import util from '@/libs/util'
export default {
  name: 'activity',
  data () {
    return {
      loading: true,
      list: [],
      formSearch: {
        page: 1,
        size: 15,
        total: 0,
        title: ''
      },
      idArray: ''
    }
  },
  mounted () {
    this.GetData()
  },
  methods: {
    doExport: function () {
      const that = this
      // console.log(process.env)
      var url = process.env.VUE_APP_API.replace('/api/admin/', '/Export/questionnaire/')
      util.open(url + that.$route.params.id)
    },
    doAdd () {
      // 新增
      const that = this
      that.$refs.editForm.show(-1)
    },
    doDelete () {},
    handleEdit (index, row) {
      // 编辑row
      const that = this
      that.$refs.editForm.show(row.id)
    },
    handleItem (index, row) {
      // 编辑row
      const that = this
      that.$refs.itemForm.show(row.id)
    },

    handleDelete (index, row) {
      // 删除row
      const that = this
      that
        .$confirm('确认删除?', '提示', {
          confirmButtonText: '确定',
          cancelButtonText: '取消',
          type: 'warning'
        })
        .then(() => {
          that.idArray = row.id
          that.doDeleteData()
        })
        .catch(() => {})
    },
    handleSelectionChange (val) {
      // 勾选checkbox变更
      const that = this
      let str = ''
      for (let i = 0; i < val.length; i++) {
        str += val[i].id + ','
      }
      if (str.length > 0) {
        str = str.substr(0, str.length - 1)
      }
      that.idArray = str
    },
    GetData () {
      const that = this
      that.loading = true
      that.$api
        .QUESTIONNAIRE_RESULT({ id: that.$route.params.id })
        .then(function (res) {
          that.list = res
          setTimeout(function () {
            that.loading = false
          }, 300)
        })
        .catch(function (error) {
          that.loading = false
          console.log(error)
        })
    },
    doDeleteData () {
      const that = this
      that.loading = true
      that.$api
        .QUESTIONNAIRE_DELETE({
          ids: that.idArray
        })
        .then(function (res) {
          that.GetData()
          setTimeout(function () {
            that.loading = false
          }, 300)
        })
        .catch(function (error) {
          console.log(error)
          that.loading = false
          that.$message({
            type: 'info',
            message: ''
          })
        })
    },
    async handlePaginationChange (val) {
      this.formSearch.page = val.current
      this.formSearch.size = val.size
      this.formSearch.total = val.total
      this.GetData()
    }
  }
}
</script>
