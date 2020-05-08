// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  SERVER_URL: `/admin`,
  production: false,
  useHash: false,
  hmr: false,

  application: {
    name: 'SoMall',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://demo.somall.top',
    clientId: 'SoMall_App',
    dummyClientSecret: '1q2w3e*',
    scope: 'SoMall',
    showDebugInformation: true,
    oidc: true,
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://demo.somall.top',
      signalR : "wss://demo.somall.top/signalR"
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
