// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  SERVER_URL: ``,
  production: false,
  useHash: false,
  hmr: false,

  application: {
    name: 'SoMall',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'http://127.0.0.1:44380',
    clientId: 'SoMall_App',
    dummyClientSecret: '1q2w3e*',
    scope: 'SoMall',
    showDebugInformation: true,
    oidc: true,
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'http://127.0.0.1:44340',
    },
  },
  localization: {
    defaultResourceName: 'SoMall',
  }
};





/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
