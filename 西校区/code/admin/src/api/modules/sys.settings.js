
export default ({ service, request, serviceForMock, requestForMock, mock, faker, tools }) => ({
  SYS_SETTINGS_GET (data = {}) {
    // 获取单条数据
    return request({
      url: '/Settings/GetInfo',
      method: 'get',
      params: data
    })
  },
  SYS_SETTINGS_UPDATE (data = {}) {
    // 更新单条数据
    return request({
      url: '/Settings/Update',
      method: 'post',
      data
    })
  }
})
