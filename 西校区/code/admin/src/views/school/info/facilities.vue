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
      <el-form-item label="体育设施">
        <el-checkbox-group v-model="dataForm.facilitiesval1" @change="a=>change(a,dataForm.facilities1)">
          <el-checkbox v-for="(item,index) in dataForm.facilities1"
                       :label="item.title"
                       :key="index">{{item.title}}</el-checkbox>
        </el-checkbox-group>
      </el-form-item>
      <el-form-item label="艺术设施">
          <el-checkbox-group v-model="dataForm.facilitiesval2"  @change="a=>change(a,dataForm.facilities2)">
          <el-checkbox v-for="(item,index) in dataForm.facilities2"
                       :label="item.title"
                       :key="index">{{item.title}}</el-checkbox>
        </el-checkbox-group>
      </el-form-item>
      <el-form-item label="学术设施">
           <el-checkbox-group v-model="dataForm.facilitiesval3"  @change="a=>change(a,dataForm.facilities3)">
          <el-checkbox v-for="(item,index) in dataForm.facilities3"
                       :label="item.title"
                       :key="index">{{item.title}}</el-checkbox>
        </el-checkbox-group>
      </el-form-item>
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
      title: '配套设施',
      drawer: false,
      direction: 'rtl',
      size: '520px',
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
      that.title = '配套设施'
      if (id === -1) {
        that.title = '配套设施'
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
          console.log(res)
          setTimeout(function () {
            that.loading = false
          }, 300)
        })
        .catch(function (error) {
          console.log(error)
        })
    },
    change (values, data) {
      for (var i in data) {
        var ex = values.find(a => {
          return a === data[i].title
        })
        if (ex) {
          data[i].is_enabled = 1
        } else {
          data[i].is_enabled = 0
        }
      }
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
