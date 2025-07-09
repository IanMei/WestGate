
export default ({ service, request, tools }) => ({

  LOGIN (data = {}) {
    // 登录
    return request({
      url: '/Member/Login',
      method: 'post',
      data: data
    })
  },
  GET_INFO (data = {}) {
    // 获取用户信息
    return request({
      url: '/Member/GetInfo',
      method: 'get',
      params: data
    })
  },
  UNREAD_MESSAGE (data = {}) {
    // 获取用户信息
    return request({
      url: '/Member/UnReadMessage',
      method: 'get',
      params: data
    })
  },
  SEND_SMS (data = {}) {
    // 登录
    return request({
      url: '/Member/SendCheckCode',
      method: 'post',
      data: data
    })
  },
  CHECK_SMS (data = {}) {
    // 登录
    return request({
      url: '/Member/CheckSms',
      method: 'post',
      data: data
    })
  },
  READ_MESSAGE (data = {}) {
    // 登录
    return request({
      url: '/Member/ReadMessage',
      method: 'get',
      params: data
    })
  },
  MESSAGE_LIST (data = {}) {
    return request({
      url: '/Member/MessageList',
      method: 'get',
      params: data
    })
  },
  ORDER_LIST (data = {}) {
    return request({
      url: '/Member/OrderList',
      method: 'get',
      params: data
    })
  },
  TEST_LIST (data = {}) {
    return request({
      url: '/Member/TestList',
      method: 'get',
      params: data
    })
  },
  TEST_INFO (data = {}) {
    return request({
      url: '/Member/TestInfo',
      method: 'get',
      params: data
    })
  },
  WX_SDK (data = {}) {
    return request({
      url: '/Member/getSDK',
      method: 'get',
      params: data
    })
  },
  PRODUCT_LIST (data = {}) {
    return request({
      url: '/Member/getProducts',
      method: 'get',
      params: data
    })
  },
  TEST (data = {}) {
    return request({
      url: '/Member/SetTest',
      method: 'get',
      params: data
    })
  },
  DO_TEST (data = {}) {
    return request({
      url: '/Member/getTest',
      method: 'get',
      params: data
    })
  },
  GET_SERVICE (data = {}) {
    return request({
      url: '/Member/getService',
      method: 'get',
      params: data
    })
  },
  PRODUCT_INFO (data = {}) {
    return request({
      url: '/Member/getProduct',
      method: 'get',
      params: data
    })
  },

  SET_ORDER (data = {}) {
    // 登录
    return request({
      url: '/Member/setOrder',
      method: 'post',
      data: data
    })
  },
  RESET_ORDER (data = {}) {
    // 登录
    return request({
      url: '/Member/ResetOrder',
      method: 'post',
      data: data
    })
  }
})
