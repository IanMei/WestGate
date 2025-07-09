
// import api from '@/api'
// import util from '@/libs/util'
const home = {
  state: {
    activeTab: {},
    siteInfo: {}
  },
  mutations: {
    setTab: (state, tab) => {
      state.activeTab = tab
    },
    setSiteInfo: (state, info) => {
      state.siteInfo = info
    }
  }
}
export default home
