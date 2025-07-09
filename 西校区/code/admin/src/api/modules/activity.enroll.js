
export default ({ service, request, serviceForMock, requestForMock, mock, faker, tools }) => ({

  ENROLL_LIST (data = {}) {
    // 分页查询
    return request({
      url: '/ActivityEnroll/GetPagedList',
      method: 'get',
      params: data
    })
  },
  ENROLL_GET (data = {}) {
    // 获取单条数据
    return request({
      url: '/ActivityEnroll/get',
      method: 'get',
      params: data
    })
  },
  ENROLL_DELETE (data = {}) {
    // 设置状态
    console.log(data)
    return request({
      url: '/ActivityEnroll/Delete',
      method: 'get',
      params: data
    })
  }
})
