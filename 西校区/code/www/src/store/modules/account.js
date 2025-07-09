
// import api from '@/api'
// import util from '@/libs/util'
const account = {
  state: {
    membertab: 0,
    memberInfo: {head_path: ''}
  },
  mutations: {
    setMemberTab (state, tab) {
      state.membertab = tab
    },
    setMember (state, info) {
      state.memberInfo = info
    }
  }

}
export default account
