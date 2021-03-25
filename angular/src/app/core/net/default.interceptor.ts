import { Injectable, Injector } from '@angular/core';
import { Router } from '@angular/router';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpErrorResponse,
  HttpEvent,
  HttpResponseBase,
} from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { mergeMap, catchError } from 'rxjs/operators';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { environment } from '@env/environment';
import { getStore } from '@shared';
import { User } from 'oidc-client';
import { AuthService } from 'src/store/auth/auth.service';

const CODEMESSAGE = {
  200: '服务器成功返回请求的数据。',
  201: '新建或修改数据成功。',
  202: '一个请求已经进入后台排队（异步任务）。',
  204: '删除数据成功。',
  400: '发出的请求有错误，服务器没有进行新建或修改数据的操作。',
  401: '用户没有权限（令牌、用户名、密码错误）。',
  403: '用户得到授权，但是访问是被禁止的。',
  404: '发出的请求针对的是不存在的记录，服务器没有进行操作。',
  406: '请求的格式不可得。',
  410: '请求的资源被永久删除，且不会再得到的。',
  422: '当创建一个对象时，发生一个验证错误。',
  500: '服务器发生错误，请检查服务器。',
  502: '网关错误。',
  503: '服务不可用，服务器暂时过载或维护。',
  504: '网关超时。',
};

/**
 * 默认HTTP拦截器，其注册细节见 `app.module.ts`
 */
@Injectable()
export class DefaultInterceptor implements HttpInterceptor {
  constructor(private injector: Injector, private authService: AuthService) { }

  private get notification(): NzNotificationService {
    return this.injector.get(NzNotificationService);
  }

  private goTo(url: string) {
    setTimeout(() => this.injector.get(Router).navigateByUrl(url));
  }

  private checkStatus(ev: HttpResponseBase) {
    if ((ev.status >= 200 && ev.status < 300) || ev.status === 401) {
      return;
    }
    let errortext = CODEMESSAGE[ev.status] || ev.statusText;
    if (ev.status === 403) {
      //@ts-ignore
      if (ev.error && ev.error.error && ev.error.error.message) {
        //@ts-ignore
        this.notification.error(ev.error.error.message, `请求错误 ${ev.status}`);
        return;
      }
    }
    this.notification.error(`请求错误 ${ev.status}: ${ev.url}`, errortext);
  }

  private handleData(ev: HttpResponseBase): Observable<any> {
    // 可能会因为 `throw` 导出无法执行 `_HttpClient` 的 `end()` 操作
    // if (ev.status > 0) {
    //   this.injector.get(HttpClient).end();
    // }
    this.checkStatus(ev);
    // 业务处理：一些通用操作
    switch (ev.status) {
      case 200:
        break;
      case 401:
        this.notification.error(`未登录或登录已过期，请重新登录。`, ``);
        // 清空 token 信息
        break;
      case 403:
      case 404:
      case 500:
        // this.goTo(`/exception/${ev.status}`);
        break;
      default:
        if (ev instanceof HttpErrorResponse) {
          console.warn('未可知错误，大部分是由于后端不支持CORS或无效配置引起', ev);
        }
        break;
    }
    if (ev instanceof HttpErrorResponse) {
      return throwError(ev);
    } else {
      return of(ev);
    }
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    let token = "";
    let __tenant = "";
    // let __tenant = `4df058f8-fb18-6524-a154-39f49f58a925`;
    if (getStore<User>("auth"))
      token = getStore<User>("auth").access_token
    let headers = req.headers.set("Authorization", `Bearer ${token}`);

    // 统一加上服务端前缀
    let url = req.url;
    if (!url.startsWith('https://') && !url.startsWith('http://')) {
      if (url.startsWith('/api/'))
        url = environment.apis.default.url + url;
    }

    const clonedRequest: HttpRequest<any> = req.clone({ headers, url, });

    //统一加上服务端前缀
    // let url = req.url;
    // if (!url.startsWith('https://') && !url.startsWith('http://')) {
    //   url = environment.SERVER_URL + url;
    // }
    // const newReq = req.clone({ url, headers });

    return next.handle(clonedRequest).pipe(
      mergeMap((event: any) => {
        // 允许统一对请求错误处理
        if (event instanceof HttpResponseBase) return this.handleData(event);
        // 若一切都正常，则后续操作
        return of(event);
      }),
      catchError((err: HttpErrorResponse) => this.handleData(err)),
    );
  }
}
