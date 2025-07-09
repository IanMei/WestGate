
export default ({ service, request, serviceForMock, requestForMock, mock, faker, tools }) => ({
  HELP_LIST (data = {}) {
    // 分页查询
    return request({
      url: '/Help/GetPagedList',
      method: 'get',
      params: data
    })
  },
  HELP_GET (data = {}) {
    // 获取单条数据
    return request({
      url: '/Help/get',
      method: 'get',
      params: data
    })
  },
  HELP_UPDATE (data = {}) {
    // 更新单条数据
    return request({
      url: '/Help/UpdateData',
      method: 'post',
      data
    })
  },
  HELP_DELETE (data = {}) {
    // 设置状态
    console.log(data)
    return request({
      url: '/Help/Delete',
      method: 'get',
      params: data
    })
  }
})
