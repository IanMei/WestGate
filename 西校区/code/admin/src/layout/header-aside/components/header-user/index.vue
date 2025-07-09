<template>
  <div>
    <el-dropdown size="small"
                 class="d2-mr">
      <span class="btn-text">{{info.name ? `你好 ${info.name}` : '未登录'}}</span>
      <el-dropdown-menu slot="dropdown">
        <el-dropdown-item @click.native="changePw">
          <d2-icon name="key"
                   class="d2-mr-5" />
          修改密码
        </el-dropdown-item>
        <el-dropdown-item @click.native="logOff">
          <d2-icon name="power-off"
                   class="d2-mr-5" />
          注销
        </el-dropdown-item>
      </el-dropdown-menu>
    </el-dropdown>
    <el-dialog title="密码变更"
               :visible.sync="showwd"
               width="500px">
      <el-form size="mini"
               ref="ruleForm"
               :model="form"
               style="width:400px;"
               :rules="rules">
        <el-form-item label="旧密码"
                      label-width="120px"
                      prop="oldpwd">
          <el-input type="password"
                    v-model="form.oldpwd"
                    autocomplete="off"></el-input>
        </el-form-item>
        <el-form-item label="新密码"
                      label-width="120px"
                      prop="newpwd">
          <el-input type="password"
                    v-model="form.newpwd"
                    autocomplete="off"></el-input>
        </el-form-item>
        <el-form-item label="密码确认"
                      label-width="120px"
                      prop="confirmpwd">
          <el-input type="password"
                    v-model="form.confirmpwd"
                    autocomplete="off"></el-input>
        </el-form-item>
      </el-form>
      <div slot="footer"
           class="dialog-footer">
        <el-button @click="showwd = false"
                   size="mini">取 消</el-button>
        <el-button type="primary"
                   @click="submitForm('ruleForm')"
                   size="mini">确 定</el-button>
      </div>
    </el-dialog>
  </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'
export default {
  data () {
    var validatePass = (rule, value, callback) => {
      if (value === '') {
        callback(new Error('请输入密码'))
      } else {
        if (this.form.confirmpwd !== '') {
          this.$refs.ruleForm.validateField('confirmpwd')
        }
        callback()
      }
    }
    var validatePass2 = (rule, value, callback) => {
      if (value === '') {
        callback(new Error('请再次输入密码'))
      } else if (value !== this.form.newpwd) {
        callback(new Error('两次输入密码不一致!'))
      } else {
        callback()
      }
    }
    return {
      form: {
        oldpwd: '',
        newpwd: '',
        confirmpwd: ''
      },
      showwd: false,
      rules: {
        oldpwd: [
          { validator: validatePass, trigger: 'blur' }
        ],
        newpwd: [
          { validator: validatePass, trigger: 'blur' }
        ],
        confirmpwd: [
          { validator: validatePass2, trigger: 'blur' }
        ]
      }
    }
  },
  computed: {
    ...mapState('d2admin/user', [
      'info'
    ])
  },
  methods: {
    ...mapActions('d2admin/account', [
      'logout'
    ]),
    /**
     * @description 登出
     */
    logOff () {
      this.logout({
        confirm: true
      })
    },
    changePw () {
      this.showwd = true
      this.form.oldpwd = ''
      this.form.newpwd = ''
      this.form.confirmpwd = ''
    },
    submitForm (formName) {
      const that = this
      this.$refs[formName].validate((valid) => {
        if (valid) {
          that.$api.SYS_USER_PWD(that.form).then(function (res) {
            that.$message({
              message: '修改成功',
              type: 'success'
            })
            that.showwd = false
            that.logout({
              confirm: false
            })
          }).catch(function (error) {
            console.log(error)
          })
        } else {
          console.log('error submit!!')
          return false
        }
      })
    }
  }
}
</script>
