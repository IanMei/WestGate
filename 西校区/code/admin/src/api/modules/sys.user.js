import util from '@/libs/util.js'

export default ({ service, request, serviceForMock, requestForMock, mock, faker, tools }) => ({
  /**
   * @description 密码变更
   * @param {Object}
   */
  SYS_USER_PWD (data = {}) {
    // 模拟数据
    return request({
      url: '/User/ChangePassWord',
      method: 'post',
      data
    })
  },
  /**
   * @description 登录
   * @param {Object} data 登录携带的信息
   */
  SYS_USER_LOGIN (data = {}) {
    // 模拟数据
    return request({
      url: '/account/login',
      method: 'post',
      data
    })
  },
  SYS_USER_MENUS (data = {}) {
    var uuid = util.cookies.get('uuid')
    // 模拟数据
    return request({
      url: '/account/UserMenus?uuid=' + uuid,
      method: 'get'
    })
  },
  SYS_USER_LIST (data = {}) {
    // 分页查询
    return request({
      url: '/user/GetPagedList',
      method: 'get',
      params: data
    })
  },
  SYS_USER_GET (data = {}) {
    // 获取单条数据
    return request({
      url: '/user/get',
      method: 'get',
      params: data
    })
  },
  SYS_USER_UPDATE (data = {}) {
    // 更新单条数据
    return request({
      url: '/user/UpdateData',
      method: 'post',
      data
    })
  },
  SYS_USER_DELETE (data = {}) {
    // 设置状态
    console.log(data)
    return request({
      url: '/user/Delete',
      method: 'get',
      params: data
    })
  }
})
