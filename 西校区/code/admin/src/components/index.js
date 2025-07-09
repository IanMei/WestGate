import Vue from 'vue'

import d2Container from './d2-container'

// 注意 有些组件使用异步加载会有影响
Vue.component('d2-container', d2Container)
Vue.component('d2-icon', () => import('./d2-icon'))
Vue.component('d2-icon-svg', () => import('./d2-icon-svg/index.vue'))
Vue.component('cms-state', () => import('./cms-state/index.vue'))
Vue.component('cms-radio', () => import('./cms-radio/index.vue'))
Vue.component('cms-pager', () => import('./cms-pager/index.vue'))
Vue.component('cms-editor', () => import('./cms-html-edit/index.vue'))
Vue.component('cms-cascader', () => import('./cms-cascader/index.vue'))
Vue.component('cms-upload', () => import('./cms-upload/index.vue'))
Vue.component('cms-upload-list', () => import('./cms-upload-list/index.vue'))
Vue.component('cms-select', () => import('./cms-select/index.vue'))
Vue.component('cms-button', () => import('./cms-button/index.vue'))
Vue.component('cms-tags', () => import('./cms-tags/index.vue'))
Vue.component('cms-layer', () => import('./cms-layer/index.vue'))
