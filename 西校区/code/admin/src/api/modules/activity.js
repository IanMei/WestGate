
export default ({ service, request, serviceForMock, requestForMock, mock, faker, tools }) => ({

  ACTIVITY_LIST (data = {}) {
    // 分页查询
    return request({
      url: '/Activity/GetPagedList',
      method: 'get',
      params: data
    })
  },
  ACTIVITY_GET (data = {}) {
    // 获取单条数据
    return request({
      url: '/Activity/get',
      method: 'get',
      params: data
    })
  },
  ACTIVITY_UPDATE (data = {}) {
    // 更新单条数据
    return request({
      url: '/Activity/UpdateData',
      method: 'post',
      data
    })
  },
  ACTIVITY_DELETE (data = {}) {
    // 设置状态
    console.log(data)
    return request({
      url: '/Activity/Delete',
      method: 'get',
      params: data
    })
  }
})
