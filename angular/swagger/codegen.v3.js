const { codegen } = require('swagger-angular-codegen');

codegen({
  methodNameMode: 'path',
  remoteUrl: 'http://127.0.0.1:44340/swagger/v1/swagger.json',
  outputDir: './src/api',
  fileName: 'appService.ts',
  useStaticMethod: false,
  strictNullChecks: false,
  modelMode: 'interface',
  serviceNameSuffix: 'ProxyService',
  exclude: [
    'AbpApplicationConfigurationScript',
    'AbpServiceProxyScript',
    'AbpApiDefinition',
    'AbpLanguages',
    'AbpApplicationConfiguration',
    'Tenant',
    'Profile',
    'Permissions',
    'Features',
    'AbpTenantProxy',
    'Account',
  ],
});
