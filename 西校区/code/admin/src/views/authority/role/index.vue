<template>
  <d2-container>
    <el-form :inline="true"
             :model="formSearch"
             class="demo-form-inline"
             size="mini"
             slot="header">
      <el-row>
        <el-col :span="16"
                style="height:25px;">
          <el-form-item label="角色名称">
            <el-input v-model="formSearch.roleName"
                      v-on:keyup.enter.native="doSearch()"
                      placeholder="角色名称"></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="8"
                style="height:25px;">
          <el-form-item style="float:right">
            <cms-button text="搜索"
                        type="primary"
                        icon="el-icon-search"
                        v-on:click="doSearch"
                        authcode="900010030"></cms-button>
            <cms-button type="success"
                        icon="el-icon-edit"
                        v-on:click="doAdd"
                        authcode="900010031"
                        text="新增"></cms-button>
            <cms-button type="danger"
                        icon="el-icon-delete"
                        v-on:click="doDelete"
                        authcode="900010033"
                        text="删除"></cms-button>
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
      <el-table-column type="selection"
                       width="50"> </el-table-column>
      <el-table-column prop="roleno"
                       label="编号"
                       width="150">
      </el-table-column>
      <el-table-column prop="rolename"
                       label="角色名称"
                       width="200">
      </el-table-column>

      <el-table-column prop="remark"
                       label="备注"
                       show-overflow-tooltip>
      </el-table-column>
      <el-table-column label="状态"
                       width="80" align="center">
        <template slot-scope="scope">
          <cms-state ref="comswitch"
                     v-model="scope.row.isenabled"
                     v-bind:action="'/Role/SetStatus?recordId=' + scope.row.roleid"></cms-state>
        </template>
      </el-table-column>
      <el-table-column label="操作"
                       width="135">
        <template slot-scope="scope">
          <el-button icon="el-icon-edit"
                      size="mini" type="primary"
                     v-on:click="handleEdit(scope.$index, scope.row)"></el-button>
          <el-button icon="el-icon-delete"
                      size="mini" type="danger"
                     v-on:click="handleDelete(scope.$index, scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <edit ref="editForm"
          @success="GetData" />
    <cms-pager slot="footer"
               :current="formSearch.page"
               :size="formSearch.size"
               :total="formSearch.total"
               @change="handlePaginationChange" />
  </d2-container>
</template>

<script>
import Vue from 'vue'
import pluginExport from '@d2-projects/vue-table-export'
import Edit from './edit.vue'
Vue.use(pluginExport)
export default {
  name: 'role',
  components: {
    Edit
  },
  data () {
    return {
      loading: true,
      list: [],
      formSearch: {
        page: 1,
        size: 15,
        total: 0,
        roleName: '',
        roleType: '01'
      },
      roleArray: '',
      exportColumns: [
        { label: '编号', prop: 'roleno' },
        { label: '角色名称', prop: 'rolename' },
        { label: '备注', prop: 'remark' },
        { label: '状态', prop: 'isenabled' }
      ]
    }
  },
  mounted () {
    this.GetData()
  },
  methods: {
    doSearch () {
      const that = this
      that.formSearch.page = 1
      that.GetData()
    },
    doAdd () {
      // 新增
      const that = this
      that.$refs.editForm.show(-1)
    },
    doDelete () {
      // 删除
      const that = this
      if (that.roleArray.length > 0) {
        that
          .$confirm('确认删除选中的角色?', '提示', {
            confirmButtonText: '确定',
            cancelButtonText: '取消',
            type: 'warning'
          })
          .then(() => {
            that.doDeleteRole()
          })
          .catch(() => {})
      } else {
        that.$message({
          type: 'info',
          message: '请选择删除的数据'
        })
      }
    },
    handleEdit (index, row) {
      // 编辑row
      const that = this
      that.$refs.editForm.show(row.roleid)
    },
    handleDelete (index, row) {
      // 删除row
      const that = this
      that
        .$confirm('确认删除该角色?', '提示', {
          confirmButtonText: '确定',
          cancelButtonText: '取消',
          type: 'warning'
        })
        .then(() => {
          that.roleArray = row.roleid
          that.doDeleteRole()
        })
        .catch(() => {})
    },
    handleSelectionChange (val) {
      // 勾选checkbox变更
      const that = this
      let str = ''
      for (let i = 0; i < val.length; i++) {
        str += val[i].roleid + ','
      }
      if (str.length > 0) {
        str = str.substr(0, str.length - 1)
      }
      that.roleArray = str
    },
    GetData () {
      const that = this
      that.loading = true
      that.$api
        .SYS_ROLE_LIST(that.formSearch)
        .then(function (res) {
          that.formSearch.total = res.total
          that.list = res.data
          setTimeout(function () {
            that.loading = false
          }, 300)
        })
        .catch(function (error) {
          that.loading = false
          console.log(error)
        })
    },
    doDeleteRole () {
      const that = this
      that.loading = true
      that.$api
        .SYS_ROLE_DELETE({
          ids: that.roleArray
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
    },
    exportExcel () {
      this.$export
        .excel({
          columns: this.exportColumns,
          data: this.list,
          header: '导出 Excel'
        })
        .then(() => {
          this.$message('导出表格成功')
        })
    }
  }
}
</script>
