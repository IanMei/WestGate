<template>
  <div class="tinymce-container editor-container"
       :class="{fullscreen:fullscreen}">
    <textarea class="tinymce-textarea"
              :id="tinymceId"></textarea>
  </div>
</template>
<script>
// 富文本
// eslint-disable-next-line no-unused-vars
import tinymce from 'tinymce/tinymce'
// import Editor from '@tinymce/tinymce-vue'
import 'tinymce/themes/silver' // 主题
// 富文本插件 更多插件参考：https://www.tiny.cloud/docs/plugins/
import 'tinymce/plugins/advlist' // 高级列表
import 'tinymce/plugins/autolink'// 自动链接
import 'tinymce/plugins/autosave'// 自动存稿
import 'tinymce/plugins/autoresize'// 编辑器自适应
import 'tinymce/plugins/code'// 源代码插件
import 'tinymce/plugins/charmap' // 特殊字符
import 'tinymce/plugins/contextmenu'// 上下文菜单
import 'tinymce/plugins/codesample' // 代码示例
import 'tinymce/plugins/directionality'// 文字方向
import 'tinymce/plugins/fullscreen' // 全屏
import 'tinymce/plugins/hr'
import 'tinymce/plugins/insertdatetime'// 插入日期时间
import 'tinymce/plugins/imagetools'// 图片编辑工具
import 'tinymce/plugins/image'// 插入上传图片插件1
import 'tinymce/plugins/lists'// 列表插件1
import 'tinymce/plugins/link' // 超链接
import 'tinymce/plugins/media'// 媒体插件1
import 'tinymce/plugins/nonbreaking'// 插入不间断空格
import 'tinymce/plugins/pagebreak'// 分页插件
import 'tinymce/plugins/paste' // 粘贴
import 'tinymce/plugins/preview' // 预览
import 'tinymce/plugins/searchreplace' // 查找替换
import 'tinymce/plugins/table'// 插入表格插件1
import 'tinymce/plugins/template'// 内容模板
import 'tinymce/plugins/textcolor'// 文字颜色
import 'tinymce/plugins/textpattern'// 快速排版
import 'tinymce/plugins/visualblocks'// 显示元素范围
import 'tinymce/plugins/visualchars'// 显示不可见字符
import 'tinymce/plugins/wordcount'// 字数统计插件1
import 'tinymce/icons/default'
export default {
  name: 'TinymceEditor',
  props: {
    id: {
      type: String
    },
    value: {
      type: String,
      default: ''
    },
    menubar: {
      default: 'file edit insert view format table'
    },
    height: {
      type: Number,
      default: 400
    },
    isInit: {
      type: Boolean,
      default: false
    }
  },
  components: {
    // Editor
  },
  data () {
    return {
      editorKey: 1,
      editorValue: this.value,
      hasChange: false,
      hasInit: false,
      tinymceId: this.id || 'vue-tinymce',
      fullscreen: false,
      IMAGE_UPLOAD: process.env.VUE_APP_API + 'UpLoad/ImageUpload'
    }
  },
  watch: {
    value (newVal) {
      if (this.hasInit) {
        this.$nextTick(() =>
          window.tinymce.get(this.tinymceId).setContent(newVal || ''))
      }
    },
    width (newVal) {
      if (newVal && newVal > 0) {
        this.restart()
      }
    }
  },
  mounted () {
    // if (this.width > 0) {
    this.initTinymce()
    // }
  },
  activated () {
    if (window.tinymce) {
      this.initTinymce()
    }
  },
  deactivated () {
    this.destroyTinymce()
  },
  beforeDestroy () {
    this.destroyTinymce()
  },
  destroyed () {
    // this.destroyTinymce()
  },
  methods: {
    initTinymce () {
      const _this = this
      window.tinymce.init({
        selector: `#${this.tinymceId}`,
        language_url: '/tinymce/langs/zh_CN.js', // 语言包的路径
        language: 'zh_CN', // 语言
        skin_url: './tinymce/skins/ui/oxide', // skin路径
        height: this.height,
        browser_spellcheck: true, // 拼写检查
        branding: false, // 去水印
        elementpath: true, // 禁用编辑器底部的状态栏
        statusbar: true, // 隐藏编辑器底部的状态栏
        paste_data_images: true, // 是否允许粘贴图像
        menubar: false, // 隐藏最上方menu
        contextmenu: 'selected table image', // 右键上下文菜单
        file_picker_types: 'image',
        images_upload_credentials: true,
        plugins: 'link lists image code table wordcount',
        toolbar: 'code link unlink image | alignleft aligncenter alignright alignjustify | bullist numlist | bold italic underline strikethrough | fontsizeselect | forecolor backcolor  | outdent indent blockquote | undo redo | removeformat',
        paste_enable_default_filters: false, // 设置粘贴过滤器 默认为true
        paste_retain_style_properties: 'color font-size border border-style',
        powerpaste_word_import: 'merge', // 参数可以是propmt, merge, clear，效果自行切换对比
        powerpaste_html_import: 'merget', // propmt, merge, clear
        powerpaste_allow_local_images: true,
        paste_postprocess: function (plugin, args) {
          const tablesNode = args.node.getElementsByTagName('table')
          for (let i = 0; i < tablesNode.length; i++) {
            tablesNode[i].style.marginLeft = 0
            tablesNode[i].style.marginRight = 0
            const tdNodes = tablesNode[i].getElementsByTagName('td') // 过滤掉excel粘贴后文本不能换行导致拖拽边框失效
            for (let j = 0; j < tdNodes.length; j++) {
              tdNodes[j].style.whiteSpace = 'normal'
              console.log(tdNodes[j].style)
            }
          }
        },
        init_instance_callback: editor => {
          if (_this.value) {
            editor.setContent(_this.value)
          }
          this.hasInit = true
          editor.on('NodeChange Change KeyUp SetContent', () => {
            _this.hasChange = true
            // 返回tinymceId 以便父组件正确赋值
            const data = {
              content: editor.getContent(),
              editorId: this.tinymceId
            }
            _this.$emit('changeValue', data)
          })
        },
        setup: function (editor) { // 自定义工具栏按钮
          editor.on('NodeChange', () => {
            // 返回tinymceId 以便父组件正确赋值
            const data = {
              content: editor.getContent(),
              editorId: this.tinymceId
            }
            _this.$emit('changeValue', data)
          })
        },
        images_upload_handler: (blobInfo, success, failure) => {
          //   const base64 = 'data:image/png;base64,' + blobInfo.base64()
          //   // 编辑器的上传图片内容被处理为<img src="success方法里面的参数" />
          //   success(base64)
          var xhr, formData
          var file = blobInfo.blob()// 转化为易于理解的file对象
          xhr = new XMLHttpRequest()
          xhr.withCredentials = false
          xhr.open('POST', this.IMAGE_UPLOAD)
          xhr.onload = function () {
            var json
            if (xhr.status !== 200) {
              failure('HTTP Error: ' + xhr.status)
              return
            }
            json = JSON.parse(xhr.responseText)
            console.log(json)
            if (!json || json.length === 0) {
              failure('Invalid JSON: ' + xhr.responseText)
              return
            }
            success(json[0].filepath)
          }
          formData = new FormData()
          formData.append('file', file, file.name)// 此处与源文档不一样
          xhr.send(formData)
        }
      }).then(res => {
        window.tinymce.activeEditor.undoManager.clear()
      })
    },
    destroyTinymce () {
      const tinymce = window.tinymce.get(this.tinymceId)
      if (tinymce) {
        try {
          window.tinymce.remove(tinymce)
        } catch (e) {
          console.log(e)
        }
      }
    },
    setContent (value) {
      window.tinymce.get(this.tinymceId).setContent(value)
    },
    getContent () {
      return window.tinymce.get(this.tinymceId).getContent()
    },
    restart () {
      this.destroyTinymce()
      this.initTinymce()
      console.log('重新初始化')
    },
    clearHistory () {
      window.tinymce.activeEditor.undoManager.clear() // 清除历史记录
    }
  }
}
</script>
<style lang="scss">
// 处理富文本下拉框在dialog中被挡住的问题
.tox-tinymce-aux {
  z-index: 3000 !important;
}
</style>
