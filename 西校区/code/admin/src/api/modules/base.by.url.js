
export default ({ service, request, serviceForMock, requestForMock, mock, faker, tools }) => ({
  /**
   * @description 登录
   * @param {Object} data 登录携带的信息
   */
  GET (url) {
    // 模拟数据
    return request({
      url: url,
      method: 'get'
    })
  },
  POST (url, data = {}) {
    // 更新单条数据
    return request({
      url: url,
      method: 'post',
      data
    })
  }
})
