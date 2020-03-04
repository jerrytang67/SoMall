import { AuthConfig } from 'angular-oauth2-oidc';

export const authConfig: AuthConfig = {

    issuer: 'https://localhost:44380',
    clientId: 'SoMall_App',
    dummyClientSecret: '1q2w3e*',
    // responseType: 'implicit',
    redirectUri: window.location.origin + '/',
    postLogoutRedirectUri: window.location.origin + '/index.html',
    //silentRefreshRedirectUri: window.location.origin + '/silent-refresh.html',
    scope: 'address email openid phone profile role SoMall',
    silentRefreshTimeout: 500000, // For faster testing
    timeoutFactor: 0.25, // For faster testing
    showDebugInformation: true, // Also requires enabling "Verbose" level in devtools
    clearHashAfterLogin: false, // https://github.com/manfredsteyer/angular-oauth2-oidc/issues/457#issuecomment-431807040
}