import { uniqueId } from 'lodash'

/**
 * @description 给菜单数据补充上 path 字段
 * @description https://github.com/d2-projects/d2-admin/issues/209
 * @param {Array} menu 原始的菜单数据
 */

export function checkMenus (menus) {
  var strs = menus.split('|')
  var arr = menuAside.filter(function (item, index) {
    return strs.indexOf(item.code) >= 0 || item.code === 'root'
  })
  for (var i in arr) {
    var m = arr[i].children
    if (m && m.length > 0) {
      m = m.filter(function (item, index) {
        return strs.indexOf(item.code) >= 0 || item.code === 'root'
      })
      arr[i].children = m
    }
  }
  return supplementPath(arr)
}
export function checkHeaderMenus (menus) {
  var strs = menus.split('|')
  var arr = menuHeader.filter(function (item, index) {
    return strs.indexOf(item.code) >= 0 || item.code === 'root'
  })
  for (var i in arr) {
    var m = arr[i].children
    if (m && m.length > 0) {
      m = m.filter(function (item, index) {
        return strs.indexOf(item.code) >= 0 || item.code === 'root'
      })
      arr[i].children = m
    }
  }
  return supplementPath(arr)
}

function supplementPath (menu) {
  return menu.map(e => ({
    ...e,
    path: e.path || uniqueId('d2-menu-empty-'),
    ...e.children ? {
      children: supplementPath(e.children)
    } : {}
  }))
}

export const menuHeader = [
  { code: 'root', path: '/index', title: '首页', icon: 'home' }
]

const menuAside = [
  {
    code: '100000010',
    title: '活动中心',
    icon: 'grav',
    children: [
      { code: '100010020', path: '/activity', title: '活动详情', icon: 'object-ungroup' },
      { code: '100020020', path: '/enroll', title: '活动报名', icon: 'id-card' }
    ]
  },
  {
    code: '300000010',
    title: '学校管理',
    icon: 'university',
    children: [
      { code: '300005020', path: '/school', title: '学校信息', icon: 'address-card-o' },
      { code: '300010020', path: '/files', title: '素材管理', icon: 'picture-o' },
      { code: '300010020', path: '/interview', title: '校长专访', icon: 'binoculars' }
    ]
  },
  {
    code: '400000010',
    title: '评委中心',
    icon: 'university',
    children: [
      { code: '400010020', path: '/judges', title: '评委管理', icon: 'picture-o' },
      { code: '400010020', path: '/questionnaire', title: '问卷调查', icon: 'binoculars' }
    ]
  },
  {
    code: '200000010',
    title: '信息中心',
    icon: 'file-text-o',
    children: [
      { code: '200005020', path: '/dictionaries', title: '数据字典', icon: 'sitemap' },
      { code: '200010020', path: '/chooseus', title: '选择我们', icon: 'asterisk' },
      { code: '200020020', path: '/about', title: '关于我们', icon: 'book' },
      { code: '200030020', path: '/help', title: '帮助中心', icon: 'question-circle' }
    ]
  },

  {
    code: '900000010',
    title: '系统管理',
    icon: 'gg',
    children: [
      { code: '900010020', path: '/RoleManage', title: '角色管理', icon: 'id-card-o' },
      { code: '900020020', path: '/UserManage', title: '用户管理', icon: 'user' },
      { code: '900030020', path: '/Settings', title: '网站设置', icon: 'newspaper-o' },
      { code: '900030020', path: '/Service', title: '服务条款', icon: 'stumbleupon-circle' },
      { code: '900040020', path: '/Banners', title: '图片管理', icon: 'image' }
    ]
  }
]
