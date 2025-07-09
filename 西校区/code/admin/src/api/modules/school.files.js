
export default ({ service, request, serviceForMock, requestForMock, mock, faker, tools }) => ({
  SCHOOL_FILE_LIST (data = {}) {
    // 分页查询
    return request({
      url: '/SchoolFile/GetPagedList',
      method: 'get',
      params: data
    })
  },
  SCHOOL_FILE_GET (data = {}) {
    // 获取单条数据
    return request({
      url: '/SchoolFile/get',
      method: 'get',
      params: data
    })
  },
  SCHOOL_FILE_UPDATE (data = {}) {
    // 更新单条数据
    return request({
      url: '/SchoolFile/UpdateData',
      method: 'post',
      data
    })
  },
  SCHOOL_FILE_DELETE (data = {}) {
    // 设置状态
    console.log(data)
    return request({
      url: '/SchoolFile/Delete',
      method: 'get',
      params: data
    })
  }
})
