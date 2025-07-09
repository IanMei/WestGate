
export default ({ service, request, serviceForMock, requestForMock, mock, faker, tools }) => ({
  CHOOSEUS_INDEX (data = {}) {
    // 分页查询
    return request({
      url: '/ChooseUs/index',
      method: 'get',
      params: data
    })
  },
  CHOOSEUS_LIST (data = {}) {
    // 分页查询
    return request({
      url: '/ChooseUs/GetPagedList',
      method: 'get',
      params: data
    })
  },
  CHOOSEUS_GET (data = {}) {
    // 获取单条数据
    return request({
      url: '/ChooseUs/get',
      method: 'get',
      params: data
    })
  },
  CHOOSEUS_UPDATE (data = {}) {
    // 更新单条数据
    return request({
      url: '/ChooseUs/UpdateData',
      method: 'post',
      data
    })
  },
  CHOOSEUS_DELETE (data = {}) {
    // 设置状态
    console.log(data)
    return request({
      url: '/ChooseUs/Delete',
      method: 'get',
      params: data
    })
  }
})
