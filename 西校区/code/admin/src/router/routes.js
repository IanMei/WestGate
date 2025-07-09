import layoutHeaderAside from '@/layout/header-aside'
// 由于懒加载页面太多的话会造成webpack热更新太慢，所以开发环境不使用懒加载，只有生产环境使用懒加载
const _import = require('@/libs/util.import.' + process.env.NODE_ENV)
/**
 * 在主框架内显示
 */
const frameIn = [
  {
    path: '/',
    redirect: { name: 'index' },
    component: layoutHeaderAside,
    children: [
      // 首页
      {
        path: 'index',
        name: 'index',
        meta: {
          auth: true
        },
        component: _import('system/index')
      },
      // 权限管理
      {
        path: '/RoleManage',
        name: 'RoleManage',
        meta: {
          title: '角色管理',
          auth: true
        },
        component: _import('authority/role/index.vue')
      },

      {
        path: '/UserManage',
        name: 'UserManage',
        meta: {
          title: '用户管理',
          auth: true
        },
        component: _import('authority/user/index.vue')
      },
      {
        path: '/Settings',
        name: 'Settings',
        meta: {
          title: '网站设置',
          auth: true
        },
        component: _import('authority/settings/index.vue')
      },
      {
        path: '/Banners',
        name: 'Banners',
        meta: {
          title: '图片管理',
          auth: true
        },
        component: _import('authority/banners/index.vue')
      },
      {
        path: '/Service',
        name: 'Service',
        meta: {
          title: '服务条款',
          auth: true
        },
        component: _import('authority/settings/service.vue')
      },
      {
        path: '/activity',
        name: 'activity',
        meta: {
          title: '活动管理',
          auth: true
        },
        component: _import('activity/index.vue')
      },
      {
        path: '/enroll',
        name: 'enroll',
        meta: {
          title: '活动管理',
          auth: true
        },
        component: _import('activity/enroll/index.vue')
      },
      {
        path: '/dictionaries',
        name: 'dictionaries',
        meta: {
          title: '数据字典',
          auth: true
        },
        component: _import('basedata/dictionaries/index.vue')
      },

      {
        path: '/chooseus',
        name: 'chooseus',
        meta: {
          title: '选择我们',
          auth: true
        },
        component: _import('basedata/chooseus/index.vue')
      },
      {
        path: '/about',
        name: 'about',
        meta: {
          title: '关于我们',
          auth: true
        },
        component: _import('basedata/about/index.vue')
      },
      {
        path: '/help',
        name: 'help',
        meta: {
          title: '帮助中心',
          auth: true
        },
        component: _import('basedata/help/index.vue')
      },
      {
        path: '/school',
        name: 'school',
        meta: {
          title: '学校管理',
          auth: true
        },
        component: _import('school/info/index.vue')
      },
      {
        path: '/judges',
        name: 'judges',
        meta: {
          title: '评委管理',
          auth: true
        },
        component: _import('judges/info/index.vue')
      },
      {
        path: '/questionnaire',
        name: 'questionnaire',
        meta: {
          title: '问卷调查',
          auth: true
        },
        component: _import('judges/questionnaire/index.vue')
      },
      {
        path: '/questionnaire/result',
        name: 'questionnaire.result',
        meta: {
          title: '问卷调查结果',
          auth: true
        },
        component: _import('judges/questionnaire/result.vue')
      },
      {
        path: '/interview',
        name: 'interview',
        meta: {
          title: '校长专访',
          auth: true
        },
        component: _import('school/interview/index.vue')
      },
      {
        path: '/files',
        name: 'files',
        meta: {
          title: '素材管理',
          auth: true
        },
        component: _import('school/files/index.vue')
      },
      // 系统 前端日志
      {
        path: 'log',
        name: 'log',
        meta: {
          title: '前端日志',
          auth: true
        },
        component: _import('system/log')
      },
      // 刷新页面 必须保留
      {
        path: 'refresh',
        name: 'refresh',
        hidden: true,
        component: _import('system/function/refresh')
      },
      // 页面重定向 必须保留
      {
        path: 'redirect/:route*',
        name: 'redirect',
        hidden: true,
        component: _import('system/function/redirect')
      }

    ]
  }
]

/**
 * 在主框架之外显示
 */
const frameOut = [
  // 登录
  {
    path: '/login',
    name: 'login',
    component: _import('system/login')
  }
]

/**
 * 错误页面
 */
const errorPage = [
  {
    path: '*',
    name: '404',
    component: _import('system/error/404')
  }
]

// 导出需要显示菜单的
export const frameInRoutes = frameIn

// 重新组织后导出
export default [
  ...frameIn,
  ...frameOut,
  ...errorPage
]
