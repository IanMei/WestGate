<template>
  <d2-container>

    <el-form :inline="true"
             :model="formSearch"
             class="demo-form-inline"
             size="mini"
             slot="header">
      <el-row>
        <el-col :span="6"
                style="height:25px;">
          <el-form-item>
            <cms-button type="success"
                        icon="el-icon-edit"
                        v-on:click="doAdd"
                        authcode="300005031"
                        text="新增"></cms-button>
            <cms-button type="danger"
                        icon="el-icon-delete"
                        v-on:click="doDelete"
                        authcode="300005033"
                        text="批量删除"></cms-button>
          </el-form-item>
        </el-col>
        <el-col :span="18"
                style="height:25px;text-align:right;">
          <el-form-item>
            <el-form-item>
              <el-input v-model="formSearch.title"
                        v-on:keyup.enter.native="doSearch()"
                        placeholder="模糊检索"></el-input>
            </el-form-item>
            <cms-button text="搜索"
                        type="primary"
                        icon="el-icon-search"
                        v-on:click="doSearch"
                        authcode="300005030"></cms-button>

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
      <el-table-column prop="nick_name"
                       label="昵称"
                       show-overflow-tooltip>
        <template slot-scope="scope">
          {{ scope.row.nick_name}}
        </template>
      </el-table-column>
      <el-table-column width="380"
                       label="地址"
                       show-overflow-tooltip>
        <template slot-scope="scope">
          {{ scope.row.province_name}}
          {{ scope.row.city_name}}
          {{ scope.row.address}}
        </template>
      </el-table-column>
      <el-table-column prop="company"
                       width="200"
                       label="工作单位"
                       show-overflow-tooltip>
      </el-table-column>
      <el-table-column prop="position"
                       width="100"
                       label="职务"
                       show-overflow-tooltip>
      </el-table-column>
      <el-table-column label="记录时间"
                       width="140"
                       show-overflow-tooltip>
        <template slot-scope="scope">
          {{ scope.row.create_time | formatDate }}
        </template>
      </el-table-column>
      <el-table-column label="状态"
                       width="60">
        <template slot-scope="scope">
          <cms-state ref="comswitch"
                     v-model="scope.row.enabled"
                     v-bind:action="'/judgesservice/state?recordId=' + scope.row.id"></cms-state>
        </template>
      </el-table-column>
      <el-table-column label="主审"
                       width="60">
        <template slot-scope="scope">
          <cms-state ref="comswitch"
                     v-model="scope.row.main"
                     v-bind:action="'/judgesservice/main?recordId=' + scope.row.id"></cms-state>
        </template>
      </el-table-column>
      <el-table-column label="特邀"
                       width="60">
        <template slot-scope="scope">
          <cms-state ref="comswitch"
                     v-model="scope.row.special"
                     v-bind:action="'/judgesservice/Special?recordId=' + scope.row.id"></cms-state>
        </template>
      </el-table-column>

      <el-table-column label="操作"
                       width="260">
        <template slot-scope="scope">
          <el-button icon="el-icon-edit"
                     size="mini"
                     type="primary"
                     v-on:click="handleEdit(scope.$index, scope.row)"></el-button>
          <el-button size="mini"
                     type="success"
                     v-on:click="handleResume(scope.$index, scope.row)">履历</el-button>
          <el-button size="mini"
                     type="primary"
                     v-on:click="handleHonor(scope.$index, scope.row)">荣誉</el-button>
          <el-button icon="el-icon-delete"
                     size="mini"
                     type="danger"
                     v-on:click="handleDelete(scope.$index, scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>

    <edit ref="editForm"
          @success="GetData" />

    <honor ref="honorForm"
           @success="GetData" />
    <resume ref="resumeForm"
           @success="GetData" />

    <cms-pager slot="footer"
               :current="formSearch.page"
               :size="formSearch.size"
               :total="formSearch.total"
               @change="handlePaginationChange" />
  </d2-container>
</template>

<script>
import Edit from './edit.vue'
import Honor from './honor.vue'
import resume from './resume.vue'
export default {
  name: 'school',
  components: {
    Edit,
    Honor,
    resume
  },
  data () {
    return {
      loading: true,
      list: [],
      subjectArr: [],
      formSearch: {
        page: 1,
        size: 15,
        total: 0,
        title: '',
        state: ''
      },
      idArray: ''
    }
  },
  mounted () {
    this.GetData()
  },
  methods: {
    changeActive (index) {},
    doSearch: function () {
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
      if (that.idArray.length > 0) {
        that
          .$confirm('确认删除?', '提示', {
            confirmButtonText: '确定',
            cancelButtonText: '取消',
            type: 'warning'
          })
          .then(() => {
            that.doDeleteData()
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
      that.$refs.editForm.show(row.id)
    },
    handleHonor (index, row) {
      // 编辑row
      const that = this
      that.$refs.honorForm.show(row.id)
    },
    handleResume (index, row) {
      // 编辑row
      const that = this
      that.$refs.resumeForm.show(row.id)
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
    handlePoint (index, row) {
      // 删除row
      const that = this
      that.$refs.pointForm.show(row.id)
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
        .JUDGES_LIST(that.formSearch)
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
    doDeleteData () {
      const that = this
      that.loading = true
      that.$api
        .JUDGES_DELETE({
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
