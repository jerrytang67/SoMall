const {
  codegen
} = require('swagger-angular-codegen')

codegen({
  methodNameMode: 'path',
  remoteUrl: 'http://localhost:44340/swagger/v1/swagger.json',
  outputDir: './src/api',
  fileName: 'appService.ts',
  useStaticMethod: false,
  strictNullChecks: false,
  modelMode: 'interface',
  serviceNameSuffix:'ProxyService'
})
