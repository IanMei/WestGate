
// import api from '@/api'
// import util from '@/libs/util'
const account = {
  state: {
    judgestab: 0,
    judgesInfo: {nick_name: '', position: '', file_path: ''}
  },
  mutations: {
    setJudgesTab (state, tab) {
      state.judgestab = tab
    },
    setJudges (state, info) {
      state.judgesInfo = info
    }
  }

}
export default account
