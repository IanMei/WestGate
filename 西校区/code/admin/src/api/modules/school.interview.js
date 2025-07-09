
export default ({ service, request, serviceForMock, requestForMock, mock, faker, tools }) => ({
  INTERVIEW_LIST (data = {}) {
    // 分页查询
    return request({
      url: '/Interview/GetPagedList',
      method: 'get',
      params: data
    })
  },
  INTERVIEW_GET (data = {}) {
    // 获取单条数据
    return request({
      url: '/Interview/get',
      method: 'get',
      params: data
    })
  },
  INTERVIEW_UPDATE (data = {}) {
    // 更新单条数据
    return request({
      url: '/Interview/UpdateData',
      method: 'post',
      data
    })
  },
  INTERVIEW_DELETE (data = {}) {
    // 设置状态
    console.log(data)
    return request({
      url: '/Interview/Delete',
      method: 'get',
      params: data
    })
  }
})
