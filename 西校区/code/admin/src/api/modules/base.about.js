
export default ({ service, request, serviceForMock, requestForMock, mock, faker, tools }) => ({
  ABOUT_LIST (data = {}) {
    // 分页查询
    return request({
      url: '/AboutUs/GetPagedList',
      method: 'get',
      params: data
    })
  },
  ABOUT_GET (data = {}) {
    // 获取单条数据
    return request({
      url: '/AboutUs/get',
      method: 'get',
      params: data
    })
  },
  ABOUT_UPDATE (data = {}) {
    // 更新单条数据
    return request({
      url: '/AboutUs/UpdateData',
      method: 'post',
      data
    })
  },
  ABOUT_DELETE (data = {}) {
    // 设置状态
    console.log(data)
    return request({
      url: '/AboutUs/Delete',
      method: 'get',
      params: data
    })
  }
})
