<template>
  <div>
    <el-tag :key="index"
            v-for="(tag,index) in tags"
            closable
            :disable-transitions="false"
            v-on:close="handleClose(tag)">
      {{tag}}
    </el-tag>
    <el-input class="input-new-tag"
              v-if="inputVisible"
              v-model="inputValue"
              ref="saveTagInput"
              size="small"
              v-on:keyup.enter.native="handleInputConfirm"
              v-on:blur="handleInputConfirm">
    </el-input>
    <el-button v-else
               class="button-new-tag"
               size="small"
               v-on:click="showInput">+ 增加</el-button>
  </div>
</template>
<style scoped>
.el-tag + .el-tag {
  margin-left: 10px;
}

.button-new-tag {
  margin-left: 10px;
  height: 32px;
  line-height: 30px;
  padding-top: 0;
  padding-bottom: 0;
}

.input-new-tag {
  width: 90px;
  margin-left: 10px;
  vertical-align: bottom;
}
</style>
<script>
export default {
  data: function () {
    return {
      tags: this.value,
      inputVisible: false,
      inputValue: ''
    }
  },
  props: {
    value: {
      type: Array,
      default: function () { return [] }
    }

  },
  watch: {
    value (val) {
      this.tags = val
    }
  },
  methods: {
    val () {
      return this.tags
    },
    handleClick (tab, event) {
      console.log(tab, event)
    },
    handleClose (tag) {
      this.tags.splice(this.tags.indexOf(tag), 1)
    },
    showInput () {
      this.inputVisible = true
      this.$nextTick((_) => {
        this.$refs.saveTagInput.$refs.input.focus()
      })
    },
    handleInputConfirm () {
      const inputValue = this.inputValue
      if (inputValue) {
        this.tags.push(inputValue)
      }
      this.inputVisible = false
      this.inputValue = ''
    }
  }
}
</script>
