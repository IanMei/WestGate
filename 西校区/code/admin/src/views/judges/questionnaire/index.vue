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
          <el-form-item>
            <cms-button type="success"
                        icon="el-icon-edit"
                        v-on:click="doAdd"
                        authcode="400020031"
                        text="新增"></cms-button>
            <cms-button type="danger"
                        icon="el-icon-delete"
                        v-on:click="doDelete"
                        authcode="400020033"
                        text="批量删除"></cms-button>
          </el-form-item>
        </el-col>
        <el-col :span="16"
                style="height:25px;text-align:right;">
          <el-form-item>
            <el-form-item>
              <el-input v-model="formSearch.title"
                        clearable
                        v-on:keyup.enter.native="doSearch()"
                        placeholder="模糊检索"></el-input>
            </el-form-item>
            <cms-button text="搜索"
                        type="primary"
                        icon="el-icon-search"
                        v-on:click="doSearch"
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
      <el-table-column type="selection"
                       width="50"> </el-table-column>
      <el-table-column prop="questionnaire_title"
                       label="问卷名称">
      </el-table-column>
      <el-table-column prop="questionnaire_start"
                       label="时间"
                       width="300">
        <template slot-scope="scope">
          {{ scope.row.questionnaire_start | formatDate }} 至 {{ scope.row.questionnaire_end | formatDate }}
        </template>
      </el-table-column>
      <el-table-column label="状态"
                       width="60">
        <template slot-scope="scope">
          <cms-state ref="comswitch"
                     v-model="scope.row.enabled"
                     v-bind:action="'/QuestionnaireService/state?recordId=' + scope.row.id"></cms-state>
        </template>
      </el-table-column>
      <el-table-column label="记录时间"
                       width="140"
                       show-overflow-tooltip>
        <template slot-scope="scope">
          {{ scope.row.create_time | formatDate }}
        </template>
      </el-table-column>
      <el-table-column label="操作"
                       width="290">
        <template slot-scope="scope">
          <el-button icon="el-icon-edit"
                     size="mini"
                     type="primary"
                     v-on:click="handleEdit(scope.$index, scope.row)"></el-button>
          <el-button size="mini"
                     type="success"
                     v-on:click="handleItem(scope.$index, scope.row)">调查项</el-button>
          <el-button size="mini"
                     v-on:click="handleResult(scope.$index, scope.row)">调查结果</el-button>
          <el-button icon="el-icon-delete"
                     size="mini"
                     type="danger"
                     v-on:click="handleDelete(scope.$index, scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <edit ref="editForm"
          @success="GetData" />
    <item ref="itemForm"
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
import item from './item.vue'
export default {
  name: 'activity',
  components: {
    Edit,
    item
  },
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
    handleItem (index, row) {
      // 编辑row
      const that = this
      that.$refs.itemForm.show(row.id)
    },
    handleResult (index, row) {
      // 编辑row
      const that = this
      that.$router.push({
        name: 'questionnaire.result',
        params: {
          id: row.id
        }
      })
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
        .QUESTIONNAIRE_LIST(that.formSearch)
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
