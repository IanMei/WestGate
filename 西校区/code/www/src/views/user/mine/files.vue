<template>
  <div class="houtai_right_mid">
    <div class="tuku">
      <span>图片（{{info.img.length}} 张）</span>
      <div class="tuku_main">
        <div class="tuku_title">
          <el-upload class="avatar-uploader"
                     style="float:left"
                     :action="IMAGE_UPLOAD"
                     :show-file-list="false"
                     :on-success="handleAvatarSuccess"
                     :before-upload="beforeAvatarUpload">

            <a href="javascript:;"
               class="upload">上传新图片</a>
          </el-upload>
          <a href="javascript:;"
             @click="DeleteImage('01')"
             class="delete">删除已选</a>
        </div>
        <div class="pic">
          <ul>
            <li :class="item.ischecked? 'xz':''"
                v-for="item in info.img"
                :key="item.id"
                @click="item.ischecked = !item.ischecked">
              <!-- <div class="baik"></div> -->
              <img :src="item.file_path" />
              <dd>{{item.title}}</dd>
            </li>
          </ul>
        </div>
      </div>
    </div>
    <div class="tuku">
      <span>视频链接（{{info.video.length}} 条）</span>
      <div class="tuku_main">
        <div class="tuku_title">
          <a href="javascript:;"
             @click="dialogFormVisible = true"
             class="upload">添加新链接</a>
          <a href="javascript:;" @click="DeleteImage('02')"
             class="delete">删除已选</a>
        </div>
        <div class="pic">
          <ul>
            <li :class="item.ischecked? 'xz':''"
                v-for="item in info.video"
                :key="item.id"
                @click="item.ischecked = !item.ischecked">
              <img :src="item.file_path" />
              <dd>{{item.title}}</dd>
            </li>
          </ul>
        </div>
      </div>
    </div>
    <el-dialog title="新增视频链接"
               size="mini"
               :width="dialogWidth()"
               :label-width="'80px'"
               :visible.sync="dialogFormVisible">
      <el-form :model="form"
               ref="videoForm"
               :label-position="'left'">
        <el-form-item>
          <el-upload class="avatar-uploader"
                     :action="IMAGE_UPLOAD"
                     :show-file-list="false"
                     :on-success="handleAvatarSuccess1"
                     :before-upload="beforeAvatarUpload">
            <el-image :src="form.file_path"
                      style="margin-bottom: 10px;">
              <div slot="error"
                   class="image-slot">
                <i style="font-size:18px;padding:40px 60px;">封面</i>
              </div>
            </el-image>
          </el-upload>
        </el-form-item>
        <el-form-item label="标题">
          <el-input v-model="form.title"
                    placeholder="最多20字符"
                    size="small"
                    maxlength="20"
                    autocomplete="off"></el-input>
        </el-form-item>
        <el-form-item label="视频链接">
          <el-input v-model="form.video_url"
                    placeholder="http:// ****"
                    size="small"
                    maxlength="100"
                    autocomplete="off"></el-input>
        </el-form-item>

      </el-form>
      <div slot="footer"
           style="height:30px;"
           class="dialog-footer">
        <a href="javascript:;"
           style="float:right;"
           @click="updateVideo"
           class="upload">确 定</a>
      </div>
    </el-dialog>
  </div>
</template>
<script>
import api from '@/api'
export default {
  data () {
    return {
      imageUrl: '',
      dialogFormVisible: false,
      IMAGE_UPLOAD: process.env.BASE_UPLOAD,
      form: {
        file_type: '02',
        title: '',
        video_url: '',
        file_path: '',
        image_id: ''
      },
      info: {
        img: [],
        video: []
      }
    }
  },
  created () {
    this.$store.commit('setMemberTab', 2)
    this.load()
  },
  methods: {
    load () {
      let self = this
      api
        .GET('/Member/Files')
        .then(function (res) {
          self.info = res
        })
        .catch(function (error) {
          console.log(error)
        })
    },
    updateVideo () {
      const that = this
      that.$refs.videoForm.validate((valid) => {
        if (valid) {
          api
            .POST('/Member/updateFile', that.form)
            .then(function (res) {
              that.dialogFormVisible = false
              that.load()
              setTimeout(() => {
                that.$message({
                  message: '新增成功',
                  type: 'success'
                })
              }, 10)
            })
            .catch(function (err) {
              console.log(err)
            })
        } else {
          return false
        }
      })
    },
    DeleteImage (type) {
      let self = this
      var ids = ''
      var data = []
      if (type === '01') {
        data = self.info.img
      } else if (type === '02') {
        data = self.info.video
      }
      for (let index = 0; index < data.length; index++) {
        const element = data[index]
        if (element.ischecked) {
          ids += element.id + ','
        }
      }
      api
        .GET('/Member/DeleteFile', { ids: ids })
        .then(function (res) {
          self.load()
          setTimeout(() => {
            self.$message({
              message: '删除成功',
              type: 'success'
            })
          }, 1)
        })
        .catch(function (error) {
          console.log(error)
        })
    },
    handleAvatarSuccess (res, file) {
      var image = {
        file_type: '01',
        title: file.name,
        image_id: res[0].fileid,
        remark: res[0].filepath
      }
      const that = this
      api
        .POST('/Member/UpdateFile', image)
        .then(function (res) {
          that.load()
          setTimeout(() => {
            that.$message({
              message: '上传成功',
              type: 'success'
            })
          }, 1)
        })
        .catch(function (err) {
          console.log(err)
        })
    },
    handleAvatarSuccess1 (res, file) {
      this.form.image_id = res[0].fileid
      this.form.file_path = res[0].filepath
    },
    beforeAvatarUpload (file) {
      const isJPG = file.type === 'image/jpeg' || file.type === 'image/png'
      const isLt2M = file.size / 1024 / 1024 < 2
      if (!isJPG) {
        this.$message.error('只能是 JPG|PNG 格式!')
      }
      if (!isLt2M) {
        this.$message.error('大小不能超过 2MB!')
      }
      return isJPG && isLt2M
    },
    dialogWidth () {
      let flag = navigator.userAgent.match(/(phone|pad|pod|iPhone|iPod|ios|iPad|Android|Mobile|BlackBerry|IEMobile|MQQBrowser|JUC|Fennec|wOSBrowser|BrowserNG|WebOS|Symbian|Windows Phone)/i)
      if (flag) {
        return '80%'
      } else {
        return '500px'
      }
    }
  }
}
</script>
