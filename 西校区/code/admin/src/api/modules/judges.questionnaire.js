
export default ({ service, request, serviceForMock, requestForMock, mock, faker, tools }) => ({
  QUESTIONNAIRE_LIST (data = {}) {
    // 分页查询
    return request({
      url: '/QuestionnaireService/GetPagedList',
      method: 'get',
      params: data
    })
  },
  QUESTIONNAIRE_GET (data = {}) {
    // 获取单条数据
    return request({
      url: '/QuestionnaireService/get',
      method: 'get',
      params: data
    })
  },
  QUESTIONNAIRE_RESULT (data = {}) {
    // 获取单条数据
    return request({
      url: '/QuestionnaireService/Result',
      method: 'get',
      params: data
    })
  },
  QUESTIONNAIRE_UPDATE (data = {}) {
    // 更新单条数据
    return request({
      url: '/QuestionnaireService/UpdateData',
      method: 'post',
      data
    })
  },
  QUESTIONNAIRE_DELETE (data = {}) {
    // 设置状态
    console.log(data)
    return request({
      url: '/QuestionnaireService/Delete',
      method: 'get',
      params: data
    })
  }
})
