'use strict'
const merge = require('webpack-merge')
const prodEnv = require('./prod.env')

module.exports = merge(prodEnv, {
  NODE_ENV: '"development"',
  BASE_DOMAIN: '"http://localhost:2927/"',
  BASE_URL: '"http://localhost:2927/api/WebSite/"',
  BASE_UPLOAD: '"http://localhost:2927/api/admin/upload/ImageUpload/"',
  BASE_IMAGE: '"http://localhost:2927/api/admin/upload/GetImage/"',
  VUE_APP_VERSION: '"v1.0000"'
})
