
export default ({ service, request, serviceForMock, requestForMock, mock, faker, tools }) => ({
  SCHOOL_LIST (data = {}) {
    // 分页查询
    return request({
      url: '/School/GetPagedList',
      method: 'get',
      params: data
    })
  },
  SCHOOL_GET (data = {}) {
    // 获取单条数据
    return request({
      url: '/School/get',
      method: 'get',
      params: data
    })
  },
  SCHOOL_UPDATE (data = {}) {
    // 更新单条数据
    return request({
      url: '/School/UpdateData',
      method: 'post',
      data
    })
  },
  SCHOOL_DELETE (data = {}) {
    // 设置状态
    console.log(data)
    return request({
      url: '/School/Delete',
      method: 'get',
      params: data
    })
  },
  AREA_LIST (data = {}) {
    // 省市区
    console.log(data)
    return request({
      url: '/School/AreaList',
      method: 'get',
      params: data
    })
  }
})
