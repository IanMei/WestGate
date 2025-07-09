<template>
  <el-upload class="avatar-uploader" style="line-height: 2px;"
             :action="IMAGE_UPLOAD"
             :show-file-list="false"
             :on-success="handleAvatarSuccess"
             :before-upload="beforeAvatarUpload">
    <el-image  v-if="imageUrl" style="padding:5px;"
              :src="imageUrl"
              fit="contain"></el-image>
    <div v-else
         v-bind:style="{ width: vw + 'px', height: vh + 'px' }">
      <i :style="'margin-top:calc(('+vh+'px - 100px)/2);'"
         class="el-icon-plus avatar-uploader-icon"></i>
    </div>
    <div v-if="tips === ''"
         style="color:#696161;padding:15px 0;"
         class="el-upload__tip"
         slot="tip">图片最佳效果为：<em style="color:blue">{{vw}} * {{vh}}</em>，只能上传 <em style="color:red">jpg / png</em> 格式图片</div>
    <div v-else
         style="color:#696161;padding: 15px 0;"
         class="el-upload__tip"
         slot="tip">{{tips}}，只能上传 <em style="color:red">jpg / png</em> 格式图片</div>
  </el-upload>
</template>
<style>
.avatar-uploader .el-upload {
  border: 1px dashed #726868;
  border-radius: 6px;
  cursor: pointer;
  position: relative;
  overflow: hidden;
}
.avatar-uploader .el-upload:hover {
  border-color: #409eff;
}
.avatar-uploader-icon {
  font-size: 28px;
  color: #8c939d;
  line-height: 100px;
  text-align: center;
}
.avatar {
  display: block;
}
</style>
<script>
export default {
  data: function () {
    return {
      imageUrl: '',
      imgID: 0,
      loading: false,
      IMAGE_UPLOAD: process.env.VUE_APP_API + 'UpLoad/ImageUpload',
      IMAGE_GET: process.env.VUE_APP_API + 'UpLoad/GetImage/'
    }
  },
  props: {
    imgid: {
      type: Number,
      default: -1
    },
    vw: {
      type: Number,
      default: 100
    },
    vh: {
      type: Number,
      default: 100
    },
    tips: {
      type: String,
      default: ''
    }
  },
  mounted () {
    this.imgID = this.imgid
    if (this.imgid !== -1 && this.imgid !== 0) {
      this.imageUrl = this.IMAGE_GET + this.imgid + '?r=' + Math.random()
    } else {
      this.imageUrl = ''
    }
  },
  methods: {
    handleAvatarSuccess (res, file) {
      this.imageUrl = this.IMAGE_GET + res[0].fileid
      this.imgID = res[0].fileid
      this.$emit('select-change', this.imgID)
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
    val () {
      return this.imgID
    }
  },
  computed: {},
  watch: {
    imgid (val) {
      if (val) {
        this.imgID = val
        if (val > 0) {
          this.imageUrl = this.IMAGE_GET + val + '?r=' + Math.random()
        } else {
          this.imageUrl = ''
        }
      }
    }
  }
}
</script>
