const {
  codegen
} = require('swagger-vue-codegen')
// const { codegen } = require('../../dist/index.js')

codegen({
  methodNameMode: 'path',
  //   source: require('../swagger3.json'),
  remoteUrl: 'http://localhost:21021/swagger/v1/swagger.json',
  outputDir: './src/api',
  fileName: 'appService.ts',
  useStaticMethod: true,
  strictNullChecks: false,
  modelMode: 'interface'
})
