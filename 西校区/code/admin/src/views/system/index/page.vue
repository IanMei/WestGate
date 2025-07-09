<template>
  <d2-container>
    <div style="width:100%">
      <img src="./image/home.jpg"
           width="100%">
      <!-- <el-card style="width:100%;height:180px;background-color: rgb(89 116 138);">
        <panel-group @handleSetLineChartData="handleSetLineChartData" />
      </el-card> -->
      <!-- <el-row :gutter="20" style="margin-top:20px;">
        <el-col :span="8">
          <el-card style="width:100%;">
            <ve-bar :data="chartData1" ></ve-bar>
          </el-card>
        </el-col>
        <el-col :span="8">
          <el-card style="width:100%;">
            <ve-pie :data="chartData1" ></ve-pie>
          </el-card>
        </el-col>
        <el-col :span="8">
          <el-card style="width:100%;">
            <ve-histogram :data="chartData1"></ve-histogram>
          </el-card>
        </el-col>
      </el-row> -->
    </div>
  </d2-container>
</template>

<script>
// import PanelGroup from './components/PanelGroup'
export default {
  name: 'DashboardAdmin',
  data () {
    return {
      chartData: {
        columns: ['日期', '访问用户', '下单用户', '下单率'],
        rows: [
          { 日期: '1/1', 访问用户: 1393, 下单用户: 1093, 下单率: 0.32 },
          { 日期: '1/2', 访问用户: 3530, 下单用户: 3230, 下单率: 0.26 },
          { 日期: '1/3', 访问用户: 2923, 下单用户: 2623, 下单率: 0.76 },
          { 日期: '1/4', 访问用户: 1723, 下单用户: 1423, 下单率: 0.49 },
          { 日期: '1/5', 访问用户: 3792, 下单用户: 3492, 下单率: 0.323 },
          { 日期: '1/6', 访问用户: 4593, 下单用户: 4293, 下单率: 0.78 }
        ]
      },
      chartData1: {
        columns: ['日期', '访问用户', '下单用户', '下单率'],
        rows: [
          { 日期: '1/1', 访问用户: 1393, 下单用户: 1093, 下单率: 0.32 },
          { 日期: '1/2', 访问用户: 3530, 下单用户: 3230, 下单率: 0.26 },
          { 日期: '1/3', 访问用户: 2923, 下单用户: 2623, 下单率: 0.76 },
          { 日期: '1/4', 访问用户: 1723, 下单用户: 1423, 下单率: 0.49 },
          { 日期: '1/5', 访问用户: 3792, 下单用户: 3492, 下单率: 0.323 },
          { 日期: '1/6', 访问用户: 4593, 下单用户: 4293, 下单率: 0.78 }
        ]
      }
    }
  },
  components: {
    // PanelGroup
  },
  methods: {
    handleSetLineChartData (type) { }
  }
}
</script>
