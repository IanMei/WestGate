
export default ({ service, request, serviceForMock, requestForMock, mock, faker, tools }) => ({
  DICTIONARY_INDEX (data = {}) {
    // 分页查询
    return request({
      url: '/Dictionary/index',
      method: 'get',
      params: data
    })
  },
  DICTIONARY_LIST (data = {}) {
    // 分页查询
    return request({
      url: '/Dictionary/GetPagedList',
      method: 'get',
      params: data
    })
  },
  DICTIONARY_GET (data = {}) {
    // 获取单条数据
    return request({
      url: '/Dictionary/get',
      method: 'get',
      params: data
    })
  },
  DICTIONARY_UPDATE (data = {}) {
    // 更新单条数据
    return request({
      url: '/Dictionary/UpdateData',
      method: 'post',
      data
    })
  },
  DICTIONARY_DELETE (data = {}) {
    // 设置状态
    console.log(data)
    return request({
      url: '/Dictionary/Delete',
      method: 'get',
      params: data
    })
  }
})
