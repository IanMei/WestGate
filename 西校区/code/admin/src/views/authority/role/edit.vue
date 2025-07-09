<template>
  <el-drawer :title="title" :size="size" :wrapperClosable="false"
             :visible.sync="drawer" :show-close="false"
             :direction="direction">
    <el-form :model="roleForm"
             ref="roleForm"
             label-width="80px"
             size="mini"
             style="margin-top:10px;padding:15px;overflow-y:auto;height:calc(100vh - 100px);">
      <el-form-item label="角色名称"
                    prop="rolename"
                    :rules="[{ required: true, message: '请输入角色名称', trigger: 'blur' }]">
        <el-input v-model="roleForm.rolename"
                  maxlength="20"
                  placeholder="角色名称"></el-input>
      </el-form-item>
      <el-form-item label="角色状态">
        <el-switch v-model="roleForm.isenabled"></el-switch>
      </el-form-item>
      <el-form-item label="备注"
                    prop="remark">
        <el-input type="textarea"
                  v-model="roleForm.remark"
                  maxlength="200"
                  :show-word-limit="true"
                  :autosize="{ minRows: 3, maxRows: 6 }"
                  placeholder="备注"></el-input>
      </el-form-item>
      <el-form-item label="拥有权限">
        <div>
          <div v-for="(item, index) in roleForm.modules"
               :key="index">
            <div style="margin-bottom: 10px;color: blue;font-size: 16px;">
              <el-checkbox :label="item.name"
                           :title="item.code"
                           v-model="item.selected"
                           v-on:change="handleCheckedAll(item)"
                           size="mini"
                           border></el-checkbox>
            </div>
            <el-form ref="form"
                     label-width="120px"
                     size="small"
                     :disabled="loading">
              <el-form-item :label="page.name"
                            :title="page.code"
                            v-for="(page,index) in item.pages"
                            :key="index">
                <el-checkbox style="margin-right: 0px;"
                             border
                             :title="operation.code"
                             size="mini"
                             v-on:change="handleChecked(item,page,operation)"
                             :label="operation.name"
                             v-model="operation.selected"
                             v-for="(operation,index) in page.operations"
                             :key="index">{{operation.name}}</el-checkbox>
              </el-form-item>
            </el-form>
          </div>
        </div>
      </el-form-item>
    </el-form>
    <template #title >
     <span class="texs">{{title}}</span>
      <div>
         <el-button type="primary" size="mini"
                   @click="doSave"
                   :loading="loading">确 定</el-button>
        <el-button v-on:click="doCancel()" size="mini"
                   :loading="loading">取 消</el-button>
      </div>
    </template>
  </el-drawer>
</template>
<script>
import { mapActions } from 'vuex'
export default {
  name: 'role.edit',
  data () {
    return {
      title: '编辑角色',
      drawer: false,
      size: '600px',
      direction: 'rtl',
      roleForm: {},
      loading: false,
      id: -1
    }
  },
  methods: {
    ...mapActions('d2admin/page', ['close', 'setTitle']),
    show (id) {
      const that = this
      that.id = id
      that.title = '编辑角色'
      if (id === -1) {
        that.title = '新增角色'
        that.$nextTick(function () {
          try {
            that.$refs.roleForm.clearValidate()
          } catch {

          }
        })
      }
      that.drawer = true
      that.loading = true
      that.$api
        .SYS_ROLE_GET({ id: that.id })
        .then(function (res) {
          that.roleForm = res
          setTimeout(function () {
            that.loading = false
          }, 300)
        })
        .catch(function (error) {
          console.log(error)
        })
    },
    handleCheckedAll (item) {
      // console.log(item)
      for (var i in item.pages) {
        item.pages[i].selected = item.selected
        for (var j in item.pages[i].operations) {
          var op = item.pages[i].operations[j]
          op.selected = item.selected
        }
      }
    },
    handleChecked (model, page, operation) {
      if (operation.selected === true) {
        page.selected = true
        model.selected = true
      } else {
        var pcked = page.operations.find((a) => a.selected)
        if (!pcked) {
          page.selected = false
        }
        var cked = model.pages.find((a) => a.selected)
        if (!cked) {
          model.selected = false
        }
      }
    },
    doCancel () {
      this.drawer = false
    },
    doSave (formName) {
      const that = this
      that.$refs.roleForm.validate((valid) => {
        if (valid) {
          that.$api
            .SYS_ROLE_UPDATE(that.roleForm)
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
