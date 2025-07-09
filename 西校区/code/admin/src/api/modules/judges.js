
export default ({ service, request, serviceForMock, requestForMock, mock, faker, tools }) => ({
  JUDGES_LIST (data = {}) {
    // 分页查询
    return request({
      url: '/JudgesService/GetPagedList',
      method: 'get',
      params: data
    })
  },
  JUDGES_GET (data = {}) {
    // 获取单条数据
    return request({
      url: '/JudgesService/get',
      method: 'get',
      params: data
    })
  },
  JUDGES_UPDATE (data = {}) {
    // 更新单条数据
    return request({
      url: '/JudgesService/UpdateData',
      method: 'post',
      data
    })
  },
  JUDGES_DELETE (data = {}) {
    // 设置状态
    console.log(data)
    return request({
      url: '/JudgesService/Delete',
      method: 'get',
      params: data
    })
  }
})
