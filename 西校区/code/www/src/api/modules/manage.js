
export default ({ service, request, tools }) => ({

  MANAGE_LOGIN (data = {}) {
    // 登录
    return request({
      url: '/Manage/Login',
      method: 'post',
      data: data
    })
  },
  MANAGE_DETAIL (data = {}) {
    return request({
      url: '/Manage/OrderList',
      method: 'get',
      params: data
    })
  },

  CHECK_ORDER (data = {}) {
    return request({
      url: '/Manage/CheckOrder',
      method: 'get',
      params: data
    })
  }
})
