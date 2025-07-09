
export default ({ service, request, serviceForMock, requestForMock, mock, faker, tools }) => ({
  BANNER_LIST (data = {}) {
    // 分页查询
    return request({
      url: '/Banner/List',
      method: 'get',
      params: data
    })
  },
  BANNER_GET (data = {}) {
    // 获取单条数据
    return request({
      url: '/Banner/Get',
      method: 'get',
      params: data
    })
  },
  BANNER_UPDATE (data = {}) {
    // 更新单条数据
    return request({
      url: '/Banner/UpdateData',
      method: 'post',
      data
    })
  },
  BANNER_DELETE (data = {}) {
    // 设置状态
    return request({
      url: '/Banner/Delete',
      method: 'get',
      params: data
    })
  },
  BANNER_TYPES (data = {}) {
    // 获取分类
    return request({
      url: '/Banner/Types',
      method: 'get',
      params: data
    })
  }
})
