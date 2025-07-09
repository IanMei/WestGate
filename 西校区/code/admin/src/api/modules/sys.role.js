
export default ({ service, request, serviceForMock, requestForMock, mock, faker, tools }) => ({

  SYS_ROLE_LIST (data = {}) {
    // 分页查询
    return request({
      url: '/role/GetPagedList',
      method: 'get',
      params: data
    })
  },
  SYS_ROLE_GET (data = {}) {
    // 获取单条数据
    return request({
      url: '/role/get',
      method: 'get',
      params: data
    })
  },
  SYS_ROLE_UPDATE (data = {}) {
    // 更新单条数据
    return request({
      url: '/role/UpdateData',
      method: 'post',
      data
    })
  },
  SYS_ROLE_DELETE (data = {}) {
    // 设置状态
    console.log(data)
    return request({
      url: '/role/Delete',
      method: 'get',
      params: data
    })
  }

})
