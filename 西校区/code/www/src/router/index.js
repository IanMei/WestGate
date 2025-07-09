import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

const originalPush = Router.prototype.push
const originalReplace = Router.prototype.replace
Router.prototype.push = function push (location, onResolve, onReject) {
  if (onResolve || onReject) return originalPush.call(this, location, onResolve, onReject)
  return originalPush.call(this, location).catch(err => err)
}
Router.prototype.replace = function push (location, onResolve, onReject) {
  if (onResolve || onReject) return originalReplace.call(this, location, onResolve, onReject)
  return originalReplace.call(this, location).catch(err => err)
}

// scrollBehavior:
// - only available in html5 history mode
// - defaults to no scroll behavior
// - return false to prevent scroll
const scrollBehavior = (to, from, savedPosition) => {
  if (savedPosition) {
    // savedPosition is only available for popstate navigations.
    return savedPosition
  } else {
    const position = {}
    // new navigation.
    // scroll to anchor by returning the selector
    if (to.hash) {
      position.selector = to.hash
    }
    // check if any matched route config has meta that requires scrolling to top
    if (to.matched.some(m => m.meta.scrollToTop)) {
      // cords will be used if no selector is provided,
      // or if the selector didn't match any element.
      position.x = 0
      position.y = 0
    }
    // if the returned position is falsy or an empty object,
    // will retain current scroll position.

    position.x = 0
    position.y = 0

    return position
  }
}

export default new Router({
  scrollBehavior,
  routes: [
    {
      // 默认
      path: '/',
      redirect: '/home'
    },
    {
      path: '/home',
      name: 'home',
      component: resolve => require(['@/views/home/index.vue'], resolve),
      meta: {
        title: '首页',
        keepAlive: true
      }
    },
    {
      path: '/about',
      name: 'about',
      component: resolve => require(['@/views/about/index.vue'], resolve),
      meta: {
        title: '关于我们',
        keepAlive: true
      }
    },
    {
      path: '/activity',
      name: 'activity',
      component: resolve => require(['@/views/activity/index.vue'], resolve),
      meta: {
        title: '活动公告',
        keepAlive: true
      }
    },
    {
      path: '/activity/:id',
      name: 'activity.info',
      component: resolve => require(['@/views/activity/id.vue'], resolve),
      meta: {
        title: '活动详情',
        keepAlive: true
      }
    },
    {
      path: '/school',
      name: 'school',
      component: resolve => require(['@/views/school/index.vue'], resolve),
      meta: {
        title: '会员学校',
        keepAlive: true
      }
    },
    {
      path: '/schoolwiki',
      name: 'schoolwiki',
      component: resolve => require(['@/views/wiki/index.vue'], resolve),
      meta: {
        title: 'SchoolWiki',
        keepAlive: true
      }
    },
    {
      path: '/schoolwiki/:id',
      name: 'schoolwikiinfo',
      component: resolve => require(['@/views/wiki/id.vue'], resolve),
      meta: {
        title: 'SchoolWikiinfo',
        keepAlive: true
      }
    },
    {
      path: '/school/:id',
      name: 'school.info',
      component: resolve => require(['@/views/school/id.vue'], resolve),
      meta: {
        title: '学校详情',
        keepAlive: true
      }
    },
    {
      path: '/school/interview/:id',
      name: 'school.interview',
      component: resolve => require(['@/views/school/interview.vue'], resolve),
      meta: {
        title: '每周专访',
        keepAlive: true
      }
    },
    {
      path: '/review',
      name: 'review',
      component: resolve => require(['@/views/review/index.vue'], resolve),
      meta: {
        title: '会员校长',
        keepAlive: true
      }
    },
    {
      path: '/review/:id',
      name: 'review',
      component: resolve => require(['@/views/review/id.vue'], resolve),
      meta: {
        title: '校长详情',
        keepAlive: true
      }
    },
    {
      path: '/judges',
      name: 'judges',
      component: resolve => require(['@/views/judges/login.vue'], resolve),
      meta: {
        title: '评委登录',
        keepAlive: true,
        nonloayout: true
      }
    },
    {
      path: '/judges/register',
      name: 'judges.register',
      component: resolve => require(['@/views/judges/register.vue'], resolve),
      meta: {
        title: '评委注册',
        keepAlive: true,
        nonloayout: true
      }
    },
    {
      path: '/judges/mine',
      redirect: '/judges/mine/index',
      component: resolve => require(['@/views/judges/mine.vue'], resolve),
      children: [
        {
          path: '/judges/mine/index',
          name: 'judges.mine.index',
          component: resolve => require(['@/views/judges/mine/index.vue'], resolve),
          meta: {
            title: '会员中心',
            keepAlive: true,
            nonloayout: true
          }
        },
        {
          path: '/judges/mine/info',
          name: 'judges.mine.info',
          component: resolve => require(['@/views/judges/mine/info.vue'], resolve),
          meta: {
            title: '评委信息',
            keepAlive: true,
            nonloayout: true
          }
        },
        {
          path: '/judges/mine/questionnaire',
          name: 'judges.mine.questionnaire',
          component: resolve => require(['@/views/judges/mine/questionnaire.vue'], resolve),
          meta: {
            title: '问卷评审',
            keepAlive: true,
            nonloayout: true
          }
        },
        {
          path: '/judges/mine/help/:id',
          name: 'judges.mine.help',
          component: resolve => require(['@/views/user/mine/help/id.vue'], resolve),
          meta: {
            title: '帮助中心',
            keepAlive: true,
            nonloayout: true
          }
        }]
    },
    {
      path: '/user',
      name: 'user',
      component: resolve => require(['@/views/user/index.vue'], resolve),
      meta: {
        title: '会员校长',
        keepAlive: true,
        nonloayout: true
      }
    },
    {
      path: '/user/login',
      name: 'user.login',
      component: resolve => require(['@/views/user/login.vue'], resolve),
      meta: {
        title: '会员登录',
        keepAlive: true,
        nonloayout: true
      }
    },
    {
      path: '/user/register',
      name: 'user.register',
      component: resolve => require(['@/views/user/register.vue'], resolve),
      meta: {
        title: '会员注册',
        keepAlive: true,
        nonloayout: true
      }
    },
    {
      path: '/user/mine',
      redirect: '/user/mine/index',
      component: resolve => require(['@/views/user/mine.vue'], resolve),
      children: [
        {
          path: '/user/mine/index',
          name: 'user.mine.index',
          component: resolve => require(['@/views/user/mine/index.vue'], resolve),
          meta: {
            title: '会员中心',
            keepAlive: true,
            nonloayout: true
          }
        },
        {
          path: '/user/mine/info',
          name: 'user.mine.info',
          component: resolve => require(['@/views/user/mine/info.vue'], resolve),
          meta: {
            title: '信息维护',
            keepAlive: true,
            nonloayout: true
          }
        },
        {
          path: '/user/mine/files',
          name: 'user.mine.files',
          component: resolve => require(['@/views/user/mine/files.vue'], resolve),
          meta: {
            title: '素材管理',
            keepAlive: true,
            nonloayout: true
          }
        },
        {
          path: '/user/mine/help/:id',
          name: 'user.mine.help',
          component: resolve => require(['@/views/user/mine/help/id.vue'], resolve),
          meta: {
            title: '素材管理',
            keepAlive: true,
            nonloayout: true
          }
        }
      ]
    },
    {
      path: '/service',
      name: 'service',
      component: resolve => require(['@/views/service/index.vue'], resolve),
      meta: {
        title: '服务条款',
        keepAlive: true,
        nonloayout: true
      }
    },
    {
      path: '/user/wap/account',
      name: 'user.wap.info',
      component: resolve => require(['@/views/user/mobile/account.vue'], resolve),
      meta: {
        title: '账号信息',
        keepAlive: true,
        nonloayout: true
      }
    },
    {
      path: '/user/wap/change',
      name: 'user.wap.change',
      component: resolve => require(['@/views/user/mobile/changebind.vue'], resolve),
      meta: {
        title: '变更手机',
        keepAlive: true,
        nonloayout: true
      }
    },
    {
      path: '/user/wap/feedback',
      name: 'user.wap.feedback',
      component: resolve => require(['@/views/user/mobile/feedback.vue'], resolve),
      meta: {
        title: '意见反馈',
        keepAlive: true,
        nonloayout: true
      }
    },
    {
      path: '/user/wap/help',
      name: 'user.wap.help',
      component: resolve => require(['@/views/user/mobile/help/index.vue'], resolve),
      meta: {
        title: '帮助中心',
        keepAlive: true,
        nonloayout: true
      }
    },
    {
      path: '/user/wap/help/:id',
      name: 'user.wap.help.info',
      component: resolve => require(['@/views/user/mobile/help/id.vue'], resolve),
      meta: {
        title: '帮助详情',
        keepAlive: true,
        nonloayout: true
      }
    },
    {
      path: '/judges/wap/account',
      name: 'judges.wap.info',
      component: resolve => require(['@/views/judges/mobile/account.vue'], resolve),
      meta: {
        title: '账号信息',
        keepAlive: true,
        nonloayout: true
      }
    },
    {
      path: '/judges/wap/change',
      name: 'judges.wap.change',
      component: resolve => require(['@/views/judges/mobile/changebind.vue'], resolve),
      meta: {
        title: '变更手机',
        keepAlive: true,
        nonloayout: true
      }
    },
    {
      path: '/judges/wap/feedback',
      name: 'judges.wap.feedback',
      component: resolve => require(['@/views/judges/mobile/feedback.vue'], resolve),
      meta: {
        title: '意见反馈',
        keepAlive: true,
        nonloayout: true
      }
    },
    {
      path: '/judges/wap/help',
      name: 'judges.wap.help',
      component: resolve => require(['@/views/judges/mobile/help/index.vue'], resolve),
      meta: {
        title: '帮助中心',
        keepAlive: true,
        nonloayout: true
      }
    },
    {
      path: '/judges/wap/help/:id',
      name: 'judges.wap.help.info',
      component: resolve => require(['@/views/judges/mobile/help/id.vue'], resolve),
      meta: {
        title: '帮助详情',
        keepAlive: true,
        nonloayout: true
      }
    }
  ]
})
