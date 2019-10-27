export const environment = {
  production: false,
  hmr: false,
  application: {
    name: 'SoMall',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44352',
    clientId: 'SoMall_App',
    dummyClientSecret: '1q2w3e*',
    scope: 'SoMall',
    showDebugInformation: true,
    oidc: false,
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44352',
    },
  },
  localization: {
    defaultResourceName: 'SoMall',
  },
};
