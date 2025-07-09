<template>
  <el-upload ref="upload"
             class="upload-demo"
             :action=IMAGE_UPLOAD
             :on-remove="handleRemove"
             :before-upload="beforeAvatarUpload"
             :on-preview="handlePictureCardPreview"
             :on-change="handleChange"
             :file-list="fileList"
             :auto-upload="true">
    <el-button size="mini"
               type="primary">选择文件</el-button>
    <!-- <el-button style="margin-left: 10px;" size="small" type="success" @click="submitUpload">上传到服务器</el-button> -->
    <div slot="tip"
         class="el-upload__tip">
      单个文件大小不能超过 2MB
    </div>
  </el-upload>
</template>
<script>
import util from '@/libs/util.js'
export default {
  data: function () {
    return {
      fs: [],
      fileList: [],
      loading: false,
      IMAGE_UPLOAD: process.env.VUE_APP_API + 'UpLoad/ImageUpload',
      IMAGE_GET: process.env.VUE_APP_API + 'UpLoad/GetImage/'
    }
  },
  props: {
    fileNo: {
      type: String,
      default: ''
    }
  },
  mounted () {
    const that = this
    that.loadFiles()
  },
  beforeDestroy () {
    // this.Upload()
  },
  methods: {
    beforeAvatarUpload (file) {
      // const isJPG = file.type === 'image/jpeg' || file.type === 'image/png'
      const isLt2M = file.size / 1024 / 1024 < 2
      // if (!isJPG) {
      //   this.$message.error('只能是 JPG|PNG 格式 !')
      // }
      if (!isLt2M) {
        this.$message.error('大小不能超过 2MB!')
      }
      return isLt2M
    },
    handleRemove (file, fileList) {
      this.setList(fileList)
    },
    handleChange (file, fileList) {
      this.setList(fileList)
    },
    handlePictureCardPreview (file) {
      console.log(file)
      if (file.url) {
        util.open(file.url)
      } else if (file.response && file.response.length > 0) {
        var url =
          'http://ckw.chengkongwang.com/api/Admin/UpLoad/DownloadFile?fileName=' +
          file.response[0].FileNames
        util.open(url)
      }
    },
    loadFiles () {
      const that = this
      const urlAction = '/file/list?ref_no=' + that.fileNo
      that.$api
        .GET(urlAction)
        .then(function (res) {
          that.fs = res
          that.fileList = res
          console.log(that.fileNo, res)
        })
        .catch(function (error) {
          console.log(error)
        })
    },
    setList (fileList) {
      const self = this
      self.fs = []
      for (var i in fileList) {
        console.log(fileList)
        var response = fileList[i].response
        if (response && response.length > 0) {
          console.log(response)
          self.fs.push({
            file_name: response[0].FileNames,
            name: fileList[i].name,
            url:
              'http://ckw.chengkongwang.com/api/Admin/UpLoad/DownloadFile?fileName=' +
              response[0].FileNames,
            file_desc: fileList[i].name
          })
        } else {
          if (fileList[i].id && fileList[i].id > 0) {
            self.fs.push(fileList[i])
          }
        }
      }
    },
    Upload () {
      const self = this
      const urlAction = '/file/update'
      self.$api
        .POST(urlAction, {
          ref_no: self.fileNo,
          list: self.fs
        })
        .then(function (res) { })
        .catch(function (error) {
          console.log(error)
        })
    }
  },
  watch: {
    fileNo (val) {
      if (val) {
        this.loadFiles()
      }
    }
  }
}
</script>
