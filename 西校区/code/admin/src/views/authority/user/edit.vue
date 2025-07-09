<template>
  <el-drawer :title="title" :size="size" :wrapperClosable="false"
             :visible.sync="drawer" :show-close="false"
             :direction="direction">
    <el-form :model="userForm"
             ref="userForm"
             label-width="80px"
             size="mini"
             style="margin-top:10px;padding:15px">
      <el-form-item label="用户账号"
                    prop="user_code"
                    :rules="[{ required: true, message: '请输入', trigger: 'blur' }]">
        <el-input v-model="userForm.user_code"
                  maxlength="20"
                  placeholder="用户账号"

                  :disabled="disInput"></el-input>
      </el-form-item>
      <el-form-item label="用户密码"  :rules="[{ required: true, message: '请输入', trigger: 'blur' }]"
                    prop="user_pwd">
        <el-input v-model="userForm.user_pwd"
                  maxlength="12"
                  placeholder="用户密码"
                  ></el-input>
      </el-form-item>
      <el-form-item label="姓名"
                    prop="user_name"
                    :rules="[{ required: true, message: '请输入', trigger: 'blur' }]">
        <el-input v-model="userForm.user_name"
                  maxlength="20"
                  placeholder="不能空"
                  ></el-input>
      </el-form-item>
      <el-form-item label="手机号"
                    prop="mobile"
                    :rules="[{ required: true, message: '请输入', trigger: 'blur' }]">
        <el-input v-model="userForm.mobile"
                  maxlength="20"
                  placeholder="手机号"
                  ></el-input>
      </el-form-item>
      <el-form-item label="邮件地址"
                    prop="email">
        <el-input v-model="userForm.email"
                  maxlength="20"
                  placeholder="邮件地址"
                  ></el-input>
      </el-form-item>
      <el-form-item label="角色"
                    prop="role_no"
                    :rules="[{ required: true, message: '请选择', trigger: 'blur' }]">
        <cms-radio :val="userForm.role_no"
                   v-bind:action="'/User/Radios'"
                   @select-change="selectRole" />
      </el-form-item>
      <el-form-item label="备注"
                    prop="desc">
        <el-input type="textarea"
                  v-model="userForm.remark"
                  maxlength="200"
                  :show-word-limit="true"
                  :autosize="{ minRows: 3, maxRows: 6 }"
                  placeholder="备注"></el-input>
      </el-form-item>
      <!-- <el-form-item label="附件1"
                    prop="desc"
                    v-if="false">
        <cms-upload-list ref="f1"
                         :fileNo="userForm.user_code"></cms-upload-list>
      </el-form-item>
      <el-form-item label="附件2"
                    prop="desc"
                    v-if="false">
        <cms-upload-list ref="f2"
                         :fileNo="userForm.email"></cms-upload-list>
      </el-form-item> -->
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
  name: 'UserManage.edit',
  data () {
    return {
      title: '编辑用户',
      drawer: false,
      direction: 'rtl',
      size: '500px',
      disInput: false,
      userForm: {},
      loading: false,
      id: -1
    }
  },
  methods: {
    ...mapActions('d2admin/page', [
      'close',
      'setTitle'
    ]),
    selectOrgan (val) {
      this.userForm.organ_code = val
    },
    selectRole (val) {
      console.log(111)
      this.userForm.role_no = val
    },
    show (id) {
      const that = this
      that.title = '编辑用户'
      if (id === -1) {
        that.title = '新增用户'
        try {
          that.$nextTick(function () {
            that.$refs.userForm.clearValidate()
          })
        } catch {}
      }
      that.id = id
      that.drawer = true
      that.loading = true
      that.$api.SYS_USER_GET({ id: that.id }).then(function (res) {
        that.userForm = res
        setTimeout(function () { that.loading = false }, 300)
      }).catch(function (error) {
        console.log(error)
      })
    },
    doCancel () {
      this.drawer = false
    },
    doSave (formName) {
      const that = this
      that.$refs.userForm.validate((valid) => {
        if (valid) {
          // that.$refs.f1.Upload()
          // that.$refs.f2.Upload()
          that.$api.SYS_USER_UPDATE(that.userForm).then(function (res) {
            that.$message({
              message: '操作成功',
              type: 'success'
            })
            that.drawer = false
            that.$emit('success', res)
          }).catch(function (error) {
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
