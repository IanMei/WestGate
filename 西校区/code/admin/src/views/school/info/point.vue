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
      <el-form-item label="胡润评分"
                    prop="point"
                    :rules="[{ required: true, message: '不能空', trigger: 'blur' }]">
        <el-input v-model="dataForm.point"
                  maxlength="10"
                  style="width:120px;"
                  placeholder="数字1-100"></el-input>
      </el-form-item>

      <el-form-item label="招生对象"
                    prop="recruit_type"
                    :rules="[{ required: true, message: '请输入', trigger: 'blur' }]">
        <cms-select v-model="dataForm.recruit_type"
                    ref="level1"
                    v-bind:action="'/Dictionary/Select?indexCode=01'"
                    @select-change="selectOption" />
      </el-form-item>
      <el-row>
        <el-col :span="12">
          <el-form-item label="学费CNY"
                        :rules="[{ required: true, message: '不能空', trigger: 'blur' }]"
                        prop="tuition_cny">
            <el-input v-model="dataForm.tuition_cny"
                      maxlength="10" style="width:100px"
                      placeholder="数字"></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="学费USD"
                        prop="tuition_usd">
            <el-input v-model="dataForm.tuition_usd"
                      maxlength="10" style="width:100px"
                      placeholder="数字"></el-input>
          </el-form-item>
        </el-col>
      </el-row>

      <el-row>
        <el-col :span="12">
          <el-form-item label="住宿CNY"
                        :rules="[{ required: true, message: '不能空', trigger: 'blur' }]"
                        prop="stay_cny">
            <el-input v-model="dataForm.stay_cny"
                      maxlength="10" style="width:100px"
                      placeholder="数字"></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="住宿USD"
                        prop="stay_usd">
            <el-input v-model="dataForm.stay_usd"
                      maxlength="10" style="width:100px"
                      placeholder="数字"></el-input>
          </el-form-item>
        </el-col>
      </el-row>
    </el-form>
    <div slot="title"
         style="">
      {{ title }}
      <div style="float:right;">
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
