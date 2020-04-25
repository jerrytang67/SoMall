/** Generate by swagger-axios-codegen */
// tslint:disable
/* eslint-disable */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';

export class IList<T> extends Array<T> {}
export class List<T> extends Array<T> {}

export interface IListResult<T> {
  items?: T[];
}

export class ListResultDto<T> implements IListResult<T> {
  items?: T[];
}

export interface IPagedResult<T> extends IListResult<T> {
  totalCount: number;
}

export class PagedResultDto<T> implements IPagedResult<T> {
  totalCount!: number;
}

// customer definition
// empty

@Injectable({ providedIn: 'root' })
export class AbpTenantProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  byName(
    params: {
      /**  */
      name: string;
    } = {} as any
  ): Observable<FindTenantResultDto> {
    let url = '/api/abp/multi-tenancy/tenants/by-name/';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<FindTenantResultDto>;
  }
  /**
   *
   */
  byId(
    params: {
      /**  */
      id: string;
    } = {} as any
  ): Observable<FindTenantResultDto> {
    let url = '/api/abp/multi-tenancy/tenants/by-id/';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<FindTenantResultDto>;
  }
}

@Injectable({ providedIn: 'root' })
export class AddressProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  getList(
    params: {
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<AddressDtoPagedResultDto> {
    let url = '/api/mall/address/getList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<AddressDtoPagedResultDto>;
  }
  /**
   *
   */
  create(
    params: {
      /** requestBody */
      body?: AddressCreateOrUpdateDto;
    } = {} as any
  ): Observable<AddressDto> {
    let url = '/api/mall/address/create';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<AddressDto>;
  }
  /**
   *
   */
  update(
    params: {
      /**  */
      id?: string;
      /** requestBody */
      body?: AddressCreateOrUpdateDto;
    } = {} as any
  ): Observable<AddressDto> {
    let url = '/api/mall/address/update';
    let options: any = {
      params: { id: params.id },
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<AddressDto>;
  }
  /**
   *
   */
  delete(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/mall/address/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  setDefault(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/mall/address/setDefault';
    let options: any = {
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<AddressDto> {
    let url = '/api/mall/address/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<AddressDto>;
  }
}

@Injectable({ providedIn: 'root' })
export class AppProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<AppDto> {
    let url = '/api/app/app/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<AppDto>;
  }
  /**
   *
   */
  getList(
    params: {
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<AppDtoPagedResultDto> {
    let url = '/api/app/app/getList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<AppDtoPagedResultDto>;
  }
  /**
   *
   */
  create(
    params: {
      /** requestBody */
      body?: AppCreateOrUpdateDto;
    } = {} as any
  ): Observable<AppDto> {
    let url = '/api/app/app/create';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<AppDto>;
  }
  /**
   *
   */
  update(
    params: {
      /**  */
      id?: string;
      /** requestBody */
      body?: AppCreateOrUpdateDto;
    } = {} as any
  ): Observable<AppDto> {
    let url = '/api/app/app/update';
    let options: any = {
      params: { id: params.id },
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<AppDto>;
  }
  /**
   *
   */
  delete(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/app/app/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class ClientProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  init(
    params: {
      /** requestBody */
      body?: ClientInitRequestDto;
    } = {} as any
  ): Observable<any> {
    let url = '/api/mall/client/init';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  miniAuth(
    params: {
      /** requestBody */
      body?: WeChatMiniProgramAuthenticateModel;
    } = {} as any
  ): Observable<any> {
    let url = '/api/mall/client/miniAuth';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  getUserAddressList(): Observable<AddressDtoListResultDto> {
    let url = '/api/mall/client/getUserAddressList';
    let options: any = {
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<AddressDtoListResultDto>;
  }
  /**
   *
   */
  sumbitOrder(
    params: {
      /** requestBody */
      body?: ProductOrderRequestDto;
    } = {} as any
  ): Observable<any> {
    let url = '/api/mall/client/sumbitOrder';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  payNotifyUrl(
    params: {
      /** requestBody */
      body?: TenPayNotifyXml;
    } = {} as any
  ): Observable<any> {
    let url = '/api/mall/client/payNotifyUrl';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class CouponProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  getPublishList(
    params: {
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      appName?: string;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<CouponDtoListResultDto> {
    let url = '/api/mall/coupon/getPublishList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<CouponDtoListResultDto>;
  }
  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<CouponDto> {
    let url = '/api/mall/coupon/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<CouponDto>;
  }
  /**
   *
   */
  getList(
    params: {
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      appName?: string;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<CouponDtoPagedResultDto> {
    let url = '/api/mall/coupon/getList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<CouponDtoPagedResultDto>;
  }
  /**
   *
   */
  create(
    params: {
      /** requestBody */
      body?: CouponCreateOrUpdateDto;
    } = {} as any
  ): Observable<CouponDto> {
    let url = '/api/mall/coupon/create';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<CouponDto>;
  }
  /**
   *
   */
  update(
    params: {
      /**  */
      id?: string;
      /** requestBody */
      body?: CouponCreateOrUpdateDto;
    } = {} as any
  ): Observable<CouponDto> {
    let url = '/api/mall/coupon/update';
    let options: any = {
      params: { id: params.id },
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<CouponDto>;
  }
  /**
   *
   */
  delete(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/mall/coupon/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class FormProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  getList(): Observable<FormDtoListResultDto> {
    let url = '/api/Visitor/form/getList';
    let options: any = {
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<FormDtoListResultDto>;
  }
  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<FormDto> {
    let url = '/api/Visitor/form/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<FormDto>;
  }
  /**
   *
   */
  create(
    params: {
      /** requestBody */
      body?: FormCreateOrEditDto;
    } = {} as any
  ): Observable<FormDto> {
    let url = '/api/Visitor/form/create';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<FormDto>;
  }
  /**
   *
   */
  update(
    params: {
      /**  */
      id?: string;
      /** requestBody */
      body?: FormCreateOrEditDto;
    } = {} as any
  ): Observable<FormDto> {
    let url = '/api/Visitor/form/update';
    let options: any = {
      params: { id: params.id },
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<FormDto>;
  }
  /**
   *
   */
  delete(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/Visitor/form/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  getShops(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<VisitorShopDto[]> {
    let url = '/api/Visitor/form/getShops';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<VisitorShopDto[]>;
  }
  /**
   *
   */
  getShopForm(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/Visitor/form/getShopForm';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  addShop(
    params: {
      /** requestBody */
      body?: FormAddShopRequestDto;
    } = {} as any
  ): Observable<any> {
    let url = '/api/Visitor/form/addShop';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class MallShopProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<MallShopDto> {
    let url = '/api/mall/mallShop/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<MallShopDto>;
  }
  /**
   *
   */
  getList(): Observable<MallShopDtoListResultDto> {
    let url = '/api/mall/mallShop/getList';
    let options: any = {
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<MallShopDtoListResultDto>;
  }
  /**
   *
   */
  shopSync(
    params: {
      /** requestBody */
      body?: ShopSyncRequestDto;
    } = {} as any
  ): Observable<any> {
    let url = '/api/mall/mallShop/shopSync';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class MallUserProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<MallUserDto> {
    let url = '/api/mall/mallUser/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<MallUserDto>;
  }
  /**
   *
   */
  getList(
    params: {
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<MallUserDtoPagedResultDto> {
    let url = '/api/mall/mallUser/getList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<MallUserDtoPagedResultDto>;
  }
  /**
   *
   */
  create(
    params: {
      /** requestBody */
      body?: MallUserDto;
    } = {} as any
  ): Observable<MallUserDto> {
    let url = '/api/mall/mallUser/create';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<MallUserDto>;
  }
  /**
   *
   */
  update(
    params: {
      /**  */
      id?: string;
      /** requestBody */
      body?: MallUserDto;
    } = {} as any
  ): Observable<MallUserDto> {
    let url = '/api/mall/mallUser/update';
    let options: any = {
      params: { id: params.id },
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<MallUserDto>;
  }
  /**
   *
   */
  delete(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/mall/mallUser/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class OssProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  getConfig(): Observable<any> {
    let url = '/api/app/oss/getConfig';
    let options: any = {
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  getSignature(
    params: {
      /**  */
      data?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/app/oss/getSignature';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  test(): Observable<any> {
    let url = '/api/app/oss/test';
    let options: any = {
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class PartnerProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  get(
    params: {
      /**  */
      userId: string;
    } = {} as any
  ): Observable<PartnerDto> {
    let url = '/api/mall/partner/get/';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<PartnerDto>;
  }
  /**
   *
   */
  getList(
    params: {
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      appName?: string;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<PartnerDtoPagedResultDto> {
    let url = '/api/mall/partner/getList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<PartnerDtoPagedResultDto>;
  }
}

@Injectable({ providedIn: 'root' })
export class PayOrderProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
      /**  */
      billNo?: string;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      appName?: string;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<PayOrderDto> {
    let url = '/api/mall/payOrder/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<PayOrderDto>;
  }
  /**
   *
   */
  getList(
    params: {
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      appName?: string;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<PayOrderDtoPagedResultDto> {
    let url = '/api/mall/payOrder/getList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<PayOrderDtoPagedResultDto>;
  }
  /**
   *
   */
  getPublicList(
    params: {
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      appName?: string;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<PayOrderDtoPagedResultDto> {
    let url = '/api/mall/payOrder/getPublicList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<PayOrderDtoPagedResultDto>;
  }
}

@Injectable({ providedIn: 'root' })
export class ProductCategoryProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  getForEdit(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<CategoryCreateOrUpdateDtoGetForEditOutput> {
    let url = '/api/mall/productCategory/getForEdit';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<CategoryCreateOrUpdateDtoGetForEditOutput>;
  }
  /**
   *
   */
  update(
    params: {
      /**  */
      id?: string;
      /** requestBody */
      body?: CategoryCreateOrUpdateDto;
    } = {} as any
  ): Observable<ProductCategoryDto> {
    let url = '/api/mall/productCategory/update';
    let options: any = {
      params: { id: params.id },
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<ProductCategoryDto>;
  }
  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<ProductCategoryDto> {
    let url = '/api/mall/productCategory/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<ProductCategoryDto>;
  }
  /**
   *
   */
  getList(
    params: {
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      appName?: string;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<ProductCategoryDtoPagedResultDto> {
    let url = '/api/mall/productCategory/getList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<ProductCategoryDtoPagedResultDto>;
  }
  /**
   *
   */
  create(
    params: {
      /** requestBody */
      body?: CategoryCreateOrUpdateDto;
    } = {} as any
  ): Observable<ProductCategoryDto> {
    let url = '/api/mall/productCategory/create';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<ProductCategoryDto>;
  }
  /**
   *
   */
  delete(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/mall/productCategory/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class ProductOrderProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<ProductOrderDto> {
    let url = '/api/mall/productOrder/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<ProductOrderDto>;
  }
  /**
   *
   */
  getList(
    params: {
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      appName?: string;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<ProductOrderDtoPagedResultDto> {
    let url = '/api/mall/productOrder/getList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<ProductOrderDtoPagedResultDto>;
  }
  /**
   *
   */
  create(
    params: {
      /** requestBody */
      body?: ProductOrderCreateOrUpdateDto;
    } = {} as any
  ): Observable<ProductOrderDto> {
    let url = '/api/mall/productOrder/create';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<ProductOrderDto>;
  }
  /**
   *
   */
  pay(
    params: {
      /** requestBody */
      body?: OrderPayRequestDto;
    } = {} as any
  ): Observable<any> {
    let url = '/api/mall/productOrder/pay';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  getPublicList(
    params: {
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      appName?: string;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<ProductOrderDtoPagedResultDto> {
    let url = '/api/mall/productOrder/getPublicList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<ProductOrderDtoPagedResultDto>;
  }
  /**
   *
   */
  update(
    params: {
      /**  */
      id?: string;
      /** requestBody */
      body?: ProductOrderCreateOrUpdateDto;
    } = {} as any
  ): Observable<ProductOrderDto> {
    let url = '/api/mall/productOrder/update';
    let options: any = {
      params: { id: params.id },
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<ProductOrderDto>;
  }
  /**
   *
   */
  delete(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/mall/productOrder/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class ProductSkuProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<ProductSkuDto> {
    let url = '/api/mall/productSku/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<ProductSkuDto>;
  }
  /**
   *
   */
  getList(
    params: {
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      appName?: string;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<ProductSkuDtoPagedResultDto> {
    let url = '/api/mall/productSku/getList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<ProductSkuDtoPagedResultDto>;
  }
  /**
   *
   */
  create(
    params: {
      /** requestBody */
      body?: SkuCreateOrUpdateDto;
    } = {} as any
  ): Observable<ProductSkuDto> {
    let url = '/api/mall/productSku/create';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<ProductSkuDto>;
  }
  /**
   *
   */
  update(
    params: {
      /**  */
      id?: string;
      /** requestBody */
      body?: SkuCreateOrUpdateDto;
    } = {} as any
  ): Observable<ProductSkuDto> {
    let url = '/api/mall/productSku/update';
    let options: any = {
      params: { id: params.id },
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<ProductSkuDto>;
  }
  /**
   *
   */
  delete(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/mall/productSku/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class ProductSpuProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<ProductSpuDto> {
    let url = '/api/mall/productSpu/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<ProductSpuDto>;
  }
  /**
   *
   */
  create(
    params: {
      /** requestBody */
      body?: SpuCreateOrUpdateDto;
    } = {} as any
  ): Observable<ProductSpuDto> {
    let url = '/api/mall/productSpu/create';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<ProductSpuDto>;
  }
  /**
   *
   */
  update(
    params: {
      /**  */
      id?: string;
      /** requestBody */
      body?: SpuCreateOrUpdateDto;
    } = {} as any
  ): Observable<ProductSpuDto> {
    let url = '/api/mall/productSpu/update';
    let options: any = {
      params: { id: params.id },
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<ProductSpuDto>;
  }
  /**
   *
   */
  getForEdit(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<SpuCreateOrUpdateDtoGetForEditOutput> {
    let url = '/api/mall/productSpu/getForEdit';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<SpuCreateOrUpdateDtoGetForEditOutput>;
  }
  /**
   *
   */
  getList(
    params: {
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      appName?: string;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<ProductSpuDtoPagedResultDto> {
    let url = '/api/mall/productSpu/getList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<ProductSpuDtoPagedResultDto>;
  }
  /**
   *
   */
  delete(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/mall/productSpu/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class PublicProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  getCurrentUser(): Observable<UserProfileInput> {
    let url = '/api/app/public/getCurrentUser';
    let options: any = {
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<UserProfileInput>;
  }
  /**
   *
   */
  updateUserProfile(
    params: {
      /** requestBody */
      body?: UserProfileInput;
    } = {} as any
  ): Observable<any> {
    let url = '/api/app/public/updateUserProfile';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class RealNameInfoProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  getList(
    params: {
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<RealNameInfoDtoPagedResultDto> {
    let url = '/api/app/realNameInfo/getList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<RealNameInfoDtoPagedResultDto>;
  }
}

@Injectable({ providedIn: 'root' })
export class RoleProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  all(): Observable<IdentityRoleDtoListResultDto> {
    let url = '/api/identity/roles/all';
    let options: any = {
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<IdentityRoleDtoListResultDto>;
  }
  /**
   *
   */
  roles(
    params: {
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<IdentityRoleDtoPagedResultDto> {
    let url = '/api/identity/roles';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<IdentityRoleDtoPagedResultDto>;
  }
  /**
   *
   */
  roles1(
    params: {
      /** requestBody */
      body?: IdentityRoleCreateDto;
    } = {} as any
  ): Observable<IdentityRoleDto> {
    let url = '/api/identity/roles';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<IdentityRoleDto>;
  }
  /**
   *
   */
  roles2(
    params: {
      /**  */
      id: string;
    } = {} as any
  ): Observable<IdentityRoleDto> {
    let url = '/api/identity/roles/';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<IdentityRoleDto>;
  }
  /**
   *
   */
  roles3(
    params: {
      /**  */
      id: string;
      /** requestBody */
      body?: IdentityRoleUpdateDto;
    } = {} as any
  ): Observable<IdentityRoleDto> {
    let url = '/api/identity/roles/';
    let options: any = {
      params: { id: params.id },
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<IdentityRoleDto>;
  }
  /**
   *
   */
  roles4(
    params: {
      /**  */
      id: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/identity/roles/';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class ShopProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  getList(
    params: {
      /**  */
      maxResultCount?: number;
      /**  */
      skipCount?: number;
    } = {} as any
  ): Observable<ShopDtoPagedResultDto> {
    let url = '/api/app/shop/getList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<ShopDtoPagedResultDto>;
  }
  /**
   *
   */
  getByShortName(
    params: {
      /**  */
      shortName?: string;
    } = {} as any
  ): Observable<ShopDto> {
    let url = '/api/app/shop/getByShortName';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<ShopDto>;
  }
  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<ShopDto> {
    let url = '/api/app/shop/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<ShopDto>;
  }
  /**
   *
   */
  create(
    params: {
      /** requestBody */
      body?: VisitorShopCreateOrEditDto;
    } = {} as any
  ): Observable<ShopDto> {
    let url = '/api/app/shop/create';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<ShopDto>;
  }
  /**
   *
   */
  update(
    params: {
      /**  */
      id?: string;
      /** requestBody */
      body?: VisitorShopCreateOrEditDto;
    } = {} as any
  ): Observable<ShopDto> {
    let url = '/api/app/shop/update';
    let options: any = {
      params: { id: params.id },
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<ShopDto>;
  }
  /**
   *
   */
  delete(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/app/shop/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class SwiperProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  getPublishList(
    params: {
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      appName?: string;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<SwiperDtoListResultDto> {
    let url = '/api/mall/swiper/getPublishList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<SwiperDtoListResultDto>;
  }
  /**
   *
   */
  getForEdit(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<SwiperCreateOrUpdateDtoGetForEditOutput> {
    let url = '/api/mall/swiper/getForEdit';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<SwiperCreateOrUpdateDtoGetForEditOutput>;
  }
  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<SwiperDto> {
    let url = '/api/mall/swiper/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<SwiperDto>;
  }
  /**
   *
   */
  getList(
    params: {
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      appName?: string;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<SwiperDtoPagedResultDto> {
    let url = '/api/mall/swiper/getList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<SwiperDtoPagedResultDto>;
  }
  /**
   *
   */
  create(
    params: {
      /** requestBody */
      body?: SwiperCreateOrUpdateDto;
    } = {} as any
  ): Observable<SwiperDto> {
    let url = '/api/mall/swiper/create';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<SwiperDto>;
  }
  /**
   *
   */
  update(
    params: {
      /**  */
      id?: string;
      /** requestBody */
      body?: SwiperCreateOrUpdateDto;
    } = {} as any
  ): Observable<SwiperDto> {
    let url = '/api/mall/swiper/update';
    let options: any = {
      params: { id: params.id },
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<SwiperDto>;
  }
  /**
   *
   */
  delete(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/mall/swiper/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class UserProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  users(
    params: {
      /**  */
      id: string;
    } = {} as any
  ): Observable<IdentityUserDto> {
    let url = '/api/identity/users/';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<IdentityUserDto>;
  }
  /**
   *
   */
  users1(
    params: {
      /**  */
      id: string;
      /** requestBody */
      body?: IdentityUserUpdateDto;
    } = {} as any
  ): Observable<IdentityUserDto> {
    let url = '/api/identity/users/';
    let options: any = {
      params: { id: params.id },
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<IdentityUserDto>;
  }
  /**
   *
   */
  users2(
    params: {
      /**  */
      id: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/identity/users/';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  users3(
    params: {
      /**  */
      filter?: string;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<IdentityUserDtoPagedResultDto> {
    let url = '/api/identity/users';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<IdentityUserDtoPagedResultDto>;
  }
  /**
   *
   */
  users4(
    params: {
      /** requestBody */
      body?: IdentityUserCreateDto;
    } = {} as any
  ): Observable<IdentityUserDto> {
    let url = '/api/identity/users';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<IdentityUserDto>;
  }
  /**
   *
   */
  roles(
    params: {
      /**  */
      id: string;
    } = {} as any
  ): Observable<IdentityRoleDtoListResultDto> {
    let url = '/api/identity/users//roles';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<IdentityRoleDtoListResultDto>;
  }
  /**
   *
   */
  roles1(
    params: {
      /**  */
      id: string;
      /** requestBody */
      body?: IdentityUserUpdateRolesDto;
    } = {} as any
  ): Observable<any> {
    let url = '/api/identity/users//roles';
    let options: any = {
      params: { id: params.id },
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  byUsername(
    params: {
      /**  */
      username: string;
    } = {} as any
  ): Observable<IdentityUserDto> {
    let url = '/api/identity/users/by-username/';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<IdentityUserDto>;
  }
  /**
   *
   */
  byEmail(
    params: {
      /**  */
      email: string;
    } = {} as any
  ): Observable<IdentityUserDto> {
    let url = '/api/identity/users/by-email/';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<IdentityUserDto>;
  }
}

@Injectable({ providedIn: 'root' })
export class UserCouponProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  getList(
    params: {
      /**  */
      couponId?: string;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      appName?: string;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<UserCouponDtoPagedResultDto> {
    let url = '/api/mall/userCoupon/getList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<UserCouponDtoPagedResultDto>;
  }
  /**
   *
   */
  getPublicList(
    params: {
      /**  */
      couponId?: string;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      appName?: string;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<UserCouponDtoListResultDto> {
    let url = '/api/mall/userCoupon/getPublicList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<UserCouponDtoListResultDto>;
  }
  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<UserCouponDto> {
    let url = '/api/mall/userCoupon/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<UserCouponDto>;
  }
  /**
   *
   */
  create(
    params: {
      /** requestBody */
      body?: UserCouponCreateOrUpdateDto;
    } = {} as any
  ): Observable<UserCouponDto> {
    let url = '/api/mall/userCoupon/create';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<UserCouponDto>;
  }
  /**
   *
   */
  update(
    params: {
      /**  */
      id?: string;
      /** requestBody */
      body?: UserCouponCreateOrUpdateDto;
    } = {} as any
  ): Observable<UserCouponDto> {
    let url = '/api/mall/userCoupon/update';
    let options: any = {
      params: { id: params.id },
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<UserCouponDto>;
  }
  /**
   *
   */
  delete(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/mall/userCoupon/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class UserLookupProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  lookup(
    params: {
      /**  */
      id: string;
    } = {} as any
  ): Observable<UserData> {
    let url = '/api/identity/users/lookup/';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<UserData>;
  }
  /**
   *
   */
  byUsername(
    params: {
      /**  */
      userName: string;
    } = {} as any
  ): Observable<UserData> {
    let url = '/api/identity/users/lookup/by-username/';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<UserData>;
  }
}

@Injectable({ providedIn: 'root' })
export class VisitorLogProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  getList(
    params: {
      /**  */
      formId?: string;
      /**  */
      shopId?: string;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<VisitorLogDtoPagedResultDto> {
    let url = '/api/Visitor/visitorLog/getList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<VisitorLogDtoPagedResultDto>;
  }
  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<VisitorLogDto> {
    let url = '/api/Visitor/visitorLog/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<VisitorLogDto>;
  }
  /**
   *
   */
  delete(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/Visitor/visitorLog/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  formSubmit(
    params: {
      /** requestBody */
      body?: VisitorFormSumbitRequest;
    } = {} as any
  ): Observable<any> {
    let url = '/api/Visitor/visitorLog/formSubmit';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  leave(
    params: {
      /** requestBody */
      body?: VisitorLogDto;
    } = {} as any
  ): Observable<any> {
    let url = '/api/Visitor/visitorLog/leave';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class WechatUserProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  getList(
    params: {
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<WechatUserinfoPagedResultDto> {
    let url = '/api/app/wechatUser/getList';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<WechatUserinfoPagedResultDto>;
  }
}

@Injectable({ providedIn: 'root' })
export class WeixinProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  code2Session(
    params: {
      /** requestBody */
      body?: WeChatMiniProgramAuthenticateModel;
    } = {} as any
  ): Observable<any> {
    let url = '/api/app/weixin/code2Session';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  getAccessToken(
    params: {
      /**  */
      appid?: string;
    } = {} as any
  ): Observable<string> {
    let url = '/api/app/weixin/getAccessToken';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<string>;
  }
  /**
   *
   */
  miniAuth(
    params: {
      /**  */
      appName?: string;
      /** requestBody */
      body?: WeChatMiniProgramAuthenticateModel;
    } = {} as any
  ): Observable<any> {
    let url = '/api/app/weixin/miniAuth';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  checkLogin(
    params: {
      /**  */
      dbCheck?: boolean;
    } = {} as any
  ): Observable<any> {
    let url = '/api/app/weixin/checkLogin';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  getUnLimitQr(
    params: {
      /**  */
      scene?: string;
      /**  */
      page?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/app/weixin/getUnLimitQr';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  getPhone(
    params: {
      /** requestBody */
      body?: WeChatMiniProgramAuthenticateModel;
    } = {} as any
  ): Observable<any> {
    let url = '/api/app/weixin/getPhone';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<any>;
  }
}

export interface ControllerInterfaceApiDescriptionModel {
  /**  */
  type?: string;
}

export interface MethodParameterApiDescriptionModel {
  /**  */
  name?: string;

  /**  */
  typeAsString?: string;

  /**  */
  type?: string;

  /**  */
  typeSimple?: string;

  /**  */
  isOptional?: boolean;

  /**  */
  defaultValue?: object;
}

export interface ParameterApiDescriptionModel {
  /**  */
  nameOnMethod?: string;

  /**  */
  name?: string;

  /**  */
  type?: string;

  /**  */
  typeSimple?: string;

  /**  */
  isOptional?: boolean;

  /**  */
  defaultValue?: object;

  /**  */
  constraintTypes?: string[];

  /**  */
  bindingSourceId?: string;

  /**  */
  descriptorName?: string;
}

export interface ReturnValueApiDescriptionModel {
  /**  */
  type?: string;

  /**  */
  typeSimple?: string;
}

export interface ActionApiDescriptionModel {
  /**  */
  uniqueName?: string;

  /**  */
  name?: string;

  /**  */
  httpMethod?: string;

  /**  */
  url?: string;

  /**  */
  supportedVersions?: string[];

  /**  */
  parametersOnMethod?: MethodParameterApiDescriptionModel[];

  /**  */
  parameters?: ParameterApiDescriptionModel[];

  /**  */
  returnValue?: ReturnValueApiDescriptionModel;
}

export interface ControllerApiDescriptionModel {
  /**  */
  controllerName?: string;

  /**  */
  type?: string;

  /**  */
  interfaces?: ControllerInterfaceApiDescriptionModel[];

  /**  */
  actions?: object;
}

export interface ModuleApiDescriptionModel {
  /**  */
  rootPath?: string;

  /**  */
  remoteServiceName?: string;

  /**  */
  controllers?: object;
}

export interface PropertyApiDescriptionModel {
  /**  */
  name?: string;

  /**  */
  type?: string;

  /**  */
  typeSimple?: string;
}

export interface TypeApiDescriptionModel {
  /**  */
  baseType?: string;

  /**  */
  isEnum?: boolean;

  /**  */
  enumNames?: string[];

  /**  */
  enumValues?: object[];

  /**  */
  properties?: PropertyApiDescriptionModel[];
}

export interface ApplicationApiDescriptionModel {
  /**  */
  modules?: object;

  /**  */
  types?: object;
}

export interface LanguageInfo {
  /**  */
  cultureName?: string;

  /**  */
  uiCultureName?: string;

  /**  */
  displayName?: string;

  /**  */
  flagIcon?: string;
}

export interface DateTimeFormatDto {
  /**  */
  calendarAlgorithmType?: string;

  /**  */
  dateTimeFormatLong?: string;

  /**  */
  shortDatePattern?: string;

  /**  */
  fullDateTimePattern?: string;

  /**  */
  dateSeparator?: string;

  /**  */
  shortTimePattern?: string;

  /**  */
  longTimePattern?: string;
}

export interface CurrentCultureDto {
  /**  */
  displayName?: string;

  /**  */
  englishName?: string;

  /**  */
  threeLetterIsoLanguageName?: string;

  /**  */
  twoLetterIsoLanguageName?: string;

  /**  */
  isRightToLeft?: boolean;

  /**  */
  cultureName?: string;

  /**  */
  name?: string;

  /**  */
  nativeName?: string;

  /**  */
  dateTimeFormat?: DateTimeFormatDto;
}

export interface ApplicationLocalizationConfigurationDto {
  /**  */
  values?: object;

  /**  */
  languages?: LanguageInfo[];

  /**  */
  currentCulture?: CurrentCultureDto;
}

export interface ApplicationAuthConfigurationDto {
  /**  */
  policies?: object;

  /**  */
  grantedPolicies?: object;
}

export interface ApplicationSettingConfigurationDto {
  /**  */
  values?: object;
}

export interface CurrentUserDto {
  /**  */
  isAuthenticated?: boolean;

  /**  */
  id?: string;

  /**  */
  tenantId?: string;

  /**  */
  userName?: string;
}

export interface ApplicationFeatureConfigurationDto {
  /**  */
  values?: object;
}

export interface MultiTenancyInfoDto {
  /**  */
  isEnabled?: boolean;
}

export interface CurrentTenantDto {
  /**  */
  id?: string;

  /**  */
  name?: string;

  /**  */
  isAvailable?: boolean;
}

export interface ApplicationConfigurationDto {
  /**  */
  localization?: ApplicationLocalizationConfigurationDto;

  /**  */
  auth?: ApplicationAuthConfigurationDto;

  /**  */
  setting?: ApplicationSettingConfigurationDto;

  /**  */
  currentUser?: CurrentUserDto;

  /**  */
  features?: ApplicationFeatureConfigurationDto;

  /**  */
  multiTenancy?: MultiTenancyInfoDto;

  /**  */
  currentTenant?: CurrentTenantDto;
}

export interface FindTenantResultDto {
  /**  */
  success?: boolean;

  /**  */
  tenantId?: string;

  /**  */
  name?: string;
}

export interface RegisterDto {
  /**  */
  userName?: string;

  /**  */
  emailAddress?: string;

  /**  */
  password?: string;

  /**  */
  appName?: string;
}

export interface IdentityUserDto {
  /**  */
  tenantId?: string;

  /**  */
  userName?: string;

  /**  */
  name?: string;

  /**  */
  surname?: string;

  /**  */
  email?: string;

  /**  */
  emailConfirmed?: boolean;

  /**  */
  phoneNumber?: string;

  /**  */
  phoneNumberConfirmed?: boolean;

  /**  */
  twoFactorEnabled?: boolean;

  /**  */
  lockoutEnabled?: boolean;

  /**  */
  lockoutEnd?: Date;

  /**  */
  concurrencyStamp?: string;

  /**  */
  isDeleted?: boolean;

  /**  */
  deleterId?: string;

  /**  */
  deletionTime?: Date;

  /**  */
  lastModificationTime?: Date;

  /**  */
  lastModifierId?: string;

  /**  */
  creationTime?: Date;

  /**  */
  creatorId?: string;

  /**  */
  id?: string;

  /**  */
  extraProperties?: object;
}

export interface RemoteServiceValidationErrorInfo {
  /**  */
  message?: string;

  /**  */
  members?: string[];
}

export interface RemoteServiceErrorInfo {
  /**  */
  code?: string;

  /**  */
  message?: string;

  /**  */
  details?: string;

  /**  */
  validationErrors?: RemoteServiceValidationErrorInfo[];
}

export interface RemoteServiceErrorResponse {
  /**  */
  error?: RemoteServiceErrorInfo;
}

export interface MallUserDto {
  /**  */
  id?: string;

  /**  */
  tenantId?: string;

  /**  */
  userName?: string;

  /**  */
  name?: string;

  /**  */
  email?: string;

  /**  */
  emailConfirmed?: boolean;

  /**  */
  phoneNumber?: string;

  /**  */
  phoneNumberConfirmed?: boolean;

  /**  */
  extraProperties?: object;
}

export interface AddressDto {
  /**  */
  realName?: string;

  /**  */
  phone?: string;

  /**  */
  locationLable?: string;

  /**  */
  locationAddress?: string;

  /**  */
  nickName?: string;

  /**  */
  isDefault?: boolean;

  /**  */
  datetimeLast?: Date;

  /**  */
  lat?: number;

  /**  */
  lng?: number;

  /**  */
  locationType?: LocationType;

  /**  */
  creatorId?: string;

  /**  */
  mallUser?: MallUserDto;

  /**  */
  id?: string;
}

export interface AddressDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: AddressDto[];
}

export interface AddressCreateOrUpdateDto {
  /**  */
  realName?: string;

  /**  */
  phone?: string;

  /**  */
  locationLable?: string;

  /**  */
  locationAddress?: string;

  /**  */
  nickName?: string;

  /**  */
  lat?: number;

  /**  */
  lng?: number;

  /**  */
  locationType?: LocationType;
}

export interface AppDto {
  /**  */
  name?: string;

  /**  */
  clientName?: string;

  /**  */
  value?: object;

  /**  */
  providerName?: string;

  /**  */
  providerKey?: string;

  /**  */
  id?: string;
}

export interface AppDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: AppDto[];
}

export interface AppCreateOrUpdateDto {
  /**  */
  name?: string;

  /**  */
  clientName?: string;

  /**  */
  providerName?: string;

  /**  */
  providerKey?: string;
}

export interface ICurrentUser {
  /**  */
  isAuthenticated?: boolean;

  /**  */
  id?: string;

  /**  */
  userName?: string;

  /**  */
  phoneNumber?: string;

  /**  */
  phoneNumberVerified?: boolean;

  /**  */
  email?: string;

  /**  */
  emailVerified?: boolean;

  /**  */
  tenantId?: string;

  /**  */
  roles?: string[];
}

export interface ClientInitRequestDto {
  /**  */
  systemInfo?: object;

  /**  */
  currentUser?: ICurrentUser;

  /**  */
  shopId?: string;
}

export interface WeChatMiniProgramAuthenticateModel {
  /**  */
  code?: string;

  /**  */
  encryptedData?: string;

  /**  */
  iv?: string;

  /**  */
  session_key?: string;

  /**  */
  appid?: string;
}

export interface AddressDtoListResultDto {
  /**  */
  items?: AddressDto[];
}

export interface ShopDto {
  /**  */
  name?: string;

  /**  */
  shortName?: string;

  /**  */
  logoImage?: string;

  /**  */
  coverImage?: string;

  /**  */
  description?: string;

  /**  */
  isDeleted?: boolean;

  /**  */
  deleterId?: string;

  /**  */
  deletionTime?: Date;

  /**  */
  lastModificationTime?: Date;

  /**  */
  lastModifierId?: string;

  /**  */
  creationTime?: Date;

  /**  */
  creatorId?: string;

  /**  */
  id?: string;
}

export interface ProductSpuDtoBase {
  /**  */
  id?: string;

  /**  */
  name?: string;

  /**  */
  code?: string;

  /**  */
  dateTimeStart?: Date;

  /**  */
  dateTimeEnd?: Date;

  /**  */
  stockCount?: number;

  /**  */
  soldCount?: number;

  /**  */
  limitBuyCount?: number;

  /**  */
  skus?: ProductSkuDto[];
}

export interface AppProductCategoryDto {
  /**  */
  appName?: string;

  /**  */
  productCategoryId?: string;

  /**  */
  productCategoryName?: string;

  /**  */
  sort?: number;
}

export interface ProductCategoryDto {
  /**  */
  name?: string;

  /**  */
  code?: string;

  /**  */
  logoImageUrl?: string;

  /**  */
  redirectUrl?: string;

  /**  */
  sort?: number;

  /**  */
  isGlobal?: boolean;

  /**  */
  shop?: ShopDto;

  /**  */
  spus?: ProductSpuDtoBase[];

  /**  */
  totalCount?: number;

  /**  */
  appProductCategories?: AppProductCategoryDto[];

  /**  */
  lastModificationTime?: Date;

  /**  */
  lastModifierId?: string;

  /**  */
  creationTime?: Date;

  /**  */
  creatorId?: string;

  /**  */
  id?: string;
}

export interface MallShopDto {
  /**  */
  name?: string;

  /**  */
  shortName?: string;

  /**  */
  logoImage?: string;

  /**  */
  coverImage?: string;

  /**  */
  description?: string;

  /**  */
  id?: string;
}

export interface ProductSpuDto {
  /**  */
  category?: ProductCategoryDto;

  /**  */
  shop?: MallShopDto;

  /**  */
  shopId?: string;

  /**  */
  skus?: ProductSkuDto[];

  /**  */
  name?: string;

  /**  */
  code?: string;

  /**  */
  descCommon?: string;

  /**  */
  purchaseNotesCommon?: string;

  /**  */
  dateTimeStart?: Date;

  /**  */
  dateTimeEnd?: Date;

  /**  */
  stockCount?: number;

  /**  */
  soldCount?: number;

  /**  */
  limitBuyCount?: number;

  /**  */
  lastModificationTime?: Date;

  /**  */
  lastModifierId?: string;

  /**  */
  creationTime?: Date;

  /**  */
  creatorId?: string;

  /**  */
  id?: string;
}

export interface ProductSkuDto {
  /**  */
  spuId?: string;

  /**  */
  name?: string;

  /**  */
  code?: string;

  /**  */
  price?: number;

  /**  */
  desc?: string;

  /**  */
  purchaseNotes?: string;

  /**  */
  originPrice?: number;

  /**  */
  vipPrice?: number;

  /**  */
  coverImageUrls?: string[];

  /**  */
  dateTimeStart?: Date;

  /**  */
  dateTimeEnd?: Date;

  /**  */
  stockCount?: number;

  /**  */
  soldCount?: number;

  /**  */
  limitBuyCount?: number;

  /**  */
  unit?: string;

  /**  */
  num?: number;

  /**  */
  comment?: string;

  /**  */
  shopId?: string;

  /**  */
  spuName?: string;

  /**  */
  spu?: ProductSpuDto;

  /**  */
  lastModificationTime?: Date;

  /**  */
  lastModifierId?: string;

  /**  */
  creationTime?: Date;

  /**  */
  creatorId?: string;

  /**  */
  id?: string;
}

export interface ProductOrderRequestDto {
  /**  */
  address?: AddressDto;

  /**  */
  skus?: ProductSkuDto[];

  /**  */
  comment?: string;
}

export interface TenPayNotifyXml {
  /**  */
  appid?: string;

  /**  */
  mch_id?: string;

  /**  */
  device_info?: string;

  /**  */
  nonce_str?: string;

  /**  */
  sign?: string;

  /**  */
  result_code?: string;

  /**  */
  err_code?: string;

  /**  */
  err_code_des?: string;

  /**  */
  trade_type?: string;

  /**  */
  bank_type?: string;

  /**  */
  is_subscribe?: string;

  /**  */
  openid?: string;

  /**  */
  total_fee?: string;

  /**  */
  settlement_total_fee?: number;

  /**  */
  fee_type?: string;

  /**  */
  cash_fee?: string;

  /**  */
  cash_fee_type?: string;

  /**  */
  transaction_id?: string;

  /**  */
  out_trade_no?: string;

  /**  */
  time_end?: string;

  /**  */
  return_code?: string;

  /**  */
  return_msg?: string;
}

export interface CouponDto {
  /**  */
  amount?: number;

  /**  */
  name?: string;

  /**  */
  code?: string;

  /**  */
  desc?: string;

  /**  */
  count?: number;

  /**  */
  totalCount?: number;

  /**  */
  useType?: UseType;

  /**  */
  state?: number;

  /**  */
  dateTimeEnable?: Date;

  /**  */
  dateTimeStart?: Date;

  /**  */
  datetimeEnd?: Date;

  /**  */
  useCount?: number;

  /**  */
  id?: string;
}

export interface CouponDtoListResultDto {
  /**  */
  items?: CouponDto[];
}

export interface CouponDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: CouponDto[];
}

export interface CouponCreateOrUpdateDto {
  /**  */
  amount?: number;

  /**  */
  name?: string;

  /**  */
  code?: string;

  /**  */
  desc?: string;

  /**  */
  count?: number;

  /**  */
  totalCount?: number;

  /**  */
  useType?: UseType;

  /**  */
  state?: number;

  /**  */
  dateTimeEnable?: Date;

  /**  */
  dateTimeStart?: Date;

  /**  */
  datetimeEnd?: Date;
}

export interface IValueValidator {
  /**  */
  name?: string;

  /**  */
  properties?: object;
}

export interface IStringValueType {
  /**  */
  name?: string;

  /**  */
  properties?: object;

  /**  */
  validator?: IValueValidator;
}

export interface FeatureDto {
  /**  */
  name?: string;

  /**  */
  displayName?: string;

  /**  */
  value?: string;

  /**  */
  description?: string;

  /**  */
  valueType?: IStringValueType;

  /**  */
  depth?: number;

  /**  */
  parentName?: string;
}

export interface FeatureListDto {
  /**  */
  features?: FeatureDto[];
}

export interface UpdateFeatureDto {
  /**  */
  name?: string;

  /**  */
  value?: string;
}

export interface UpdateFeaturesDto {
  /**  */
  features?: UpdateFeatureDto[];
}

export interface SelectionItem {
  /**  */
  label?: string;

  /**  */
  value?: string;

  /**  */
  isChecked?: boolean;
}

export interface FormItemDto {
  /**  */
  type?: FormItemType;

  /**  */
  sort?: number;

  /**  */
  label?: string;

  /**  */
  key?: string;

  /**  */
  placeHolder?: string;

  /**  */
  defaultValue?: string;

  /**  */
  errorText?: string;

  /**  */
  isRequired?: boolean;

  /**  */
  isDisable?: boolean;

  /**  */
  isMulti?: boolean;

  /**  */
  saveToLocal?: boolean;

  /**  */
  value?: string;

  /**  */
  selections?: SelectionItem[];
}

export interface FormDto {
  /**  */
  id?: string;

  /**  */
  title?: string;

  /**  */
  description?: string;

  /**  */
  theme?: FormTheme;

  /**  */
  formItems?: FormItemDto[];
}

export interface FormDtoListResultDto {
  /**  */
  items?: FormDto[];
}

export interface FormItemCreateOrEditDto {
  /**  */
  itemId?: string;

  /**  */
  formId?: string;

  /**  */
  type?: FormItemType;

  /**  */
  sort?: number;

  /**  */
  label?: string;

  /**  */
  key?: string;

  /**  */
  placeHolder?: string;

  /**  */
  defaultValue?: string;

  /**  */
  errorText?: string;

  /**  */
  isRequired?: boolean;

  /**  */
  isDisable?: boolean;

  /**  */
  isMulti?: boolean;

  /**  */
  saveToLocal?: boolean;

  /**  */
  selections?: SelectionItem[];
}

export interface FormCreateOrEditDto {
  /**  */
  title?: string;

  /**  */
  description?: string;

  /**  */
  theme?: FormTheme;

  /**  */
  formItems?: FormItemCreateOrEditDto[];
}

export interface VisitorShopDto {
  /**  */
  name?: string;

  /**  */
  shortName?: string;

  /**  */
  logoImage?: string;

  /**  */
  coverImage?: string;

  /**  */
  description?: string;

  /**  */
  id?: string;
}

export interface FormAddShopRequestDto {
  /**  */
  fromId?: string;

  /**  */
  shopIds?: string[];
}

export interface MallShopDtoListResultDto {
  /**  */
  items?: MallShopDto[];
}

export interface ShopSyncRequestDto {
  /**  */
  shopIds?: string[];
}

export interface MallUserDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: MallUserDto[];
}

export interface PartnerDetail {
  /**  */
  noticeContent?: string;

  /**  */
  openid?: string;

  /**  */
  unionid?: string;

  /**  */
  weixin?: string;

  /**  */
  introducting?: string;
}

export interface PartnerDto {
  /**  */
  updateDate?: Date;

  /**  */
  state?: PartnerState;

  /**  */
  totalWithdrawals?: number;

  /**  */
  lastLoginDate?: Date;

  /**  */
  lat?: number;

  /**  */
  lng?: number;

  /**  */
  locationLabel?: string;

  /**  */
  locationAddress?: string;

  /**  */
  detail?: PartnerDetail;

  /**  */
  realName?: string;

  /**  */
  phone?: string;

  /**  */
  nickname?: string;

  /**  */
  headImageUrl?: string;

  /**  */
  avblBalance?: number;

  /**  */
  unavblBalance?: number;
}

export interface PartnerDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: PartnerDto[];
}

export interface PayOrderDto {
  /**  */
  id?: string;

  /**  */
  totalPrice?: number;

  /**  */
  body?: string;

  /**  */
  billNo?: string;

  /**  */
  appName?: string;

  /**  */
  openId?: string;

  /**  */
  mchId?: string;

  /**  */
  state?: PayState;

  /**  */
  type?: OrderType;

  /**  */
  shopId?: string;

  /**  */
  creationTime?: Date;

  /**  */
  payType?: PayType;

  /**  */
  isSuccessPay?: boolean;

  /**  */
  successPayTime?: Date;

  /**  */
  isRefund?: boolean;

  /**  */
  refundTime?: Date;

  /**  */
  refundComplateTime?: Date;

  /**  */
  refundPrice?: number;

  /**  */
  shareFromUserId?: string;

  /**  */
  partnerId?: string;
}

export interface PayOrderDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: PayOrderDto[];
}

export interface ProviderInfoDto {
  /**  */
  providerName?: string;

  /**  */
  providerKey?: string;
}

export interface PermissionGrantInfoDto {
  /**  */
  name?: string;

  /**  */
  displayName?: string;

  /**  */
  parentName?: string;

  /**  */
  isGranted?: boolean;

  /**  */
  allowedProviders?: string[];

  /**  */
  grantedProviders?: ProviderInfoDto[];
}

export interface PermissionGroupDto {
  /**  */
  name?: string;

  /**  */
  displayName?: string;

  /**  */
  permissions?: PermissionGrantInfoDto[];
}

export interface GetPermissionListResultDto {
  /**  */
  entityDisplayName?: string;

  /**  */
  groups?: PermissionGroupDto[];
}

export interface UpdatePermissionDto {
  /**  */
  name?: string;

  /**  */
  isGranted?: boolean;
}

export interface UpdatePermissionsDto {
  /**  */
  permissions?: UpdatePermissionDto[];
}

export interface CategoryCreateOrUpdateDto {
  /**  */
  name?: string;

  /**  */
  code?: string;

  /**  */
  logoImageUrl?: string;

  /**  */
  shopId?: string;

  /**  */
  redirectUrl?: string;

  /**  */
  sort?: number;

  /**  */
  isGlobal?: boolean;

  /**  */
  appProductCategories?: AppProductCategoryDto[];

  /**  */
  apps?: object[];
}

export interface CategoryCreateOrUpdateDtoGetForEditOutput {
  /**  */
  data?: CategoryCreateOrUpdateDto;

  /**  */
  schema?: any | null;
}

export interface ProductCategoryDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: ProductCategoryDto[];
}

export interface ProductOrderItemDto {
  /**  */
  spuId?: string;

  /**  */
  skuId?: string;

  /**  */
  num?: number;

  /**  */
  skuPrice?: number;

  /**  */
  spuName?: string;

  /**  */
  skuName?: string;

  /**  */
  skuUnit?: string;

  /**  */
  skuCoverImageUrl?: string;

  /**  */
  discount?: number;

  /**  */
  comment?: string;
}

export interface ProductOrderDto {
  /**  */
  payOrderId?: string;

  /**  */
  billNo?: string;

  /**  */
  pricePaidIn?: number;

  /**  */
  priceOriginal?: number;

  /**  */
  state?: OrderState;

  /**  */
  type?: ProductOrderType;

  /**  */
  payType?: PayType;

  /**  */
  comment?: string;

  /**  */
  buyerId?: string;

  /**  */
  addressId?: string;

  /**  */
  addressRealName?: string;

  /**  */
  addressNickName?: string;

  /**  */
  addressPhone?: string;

  /**  */
  addressLocationLable?: string;

  /**  */
  addressLocationAddress?: string;

  /**  */
  manId?: string;

  /**  */
  printCount?: number;

  /**  */
  shopId?: string;

  /**  */
  shop?: MallShopDto;

  /**  */
  creationTime?: Date;

  /**  */
  orderItems?: ProductOrderItemDto[];

  /**  */
  id?: string;
}

export interface ProductOrderDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: ProductOrderDto[];
}

export interface ProductOrderCreateOrUpdateDto {}

export interface OrderPayRequestDto {
  /**  */
  orderId?: string;

  /**  */
  client?: string;

  /**  */
  openid?: string;
}

export interface ProductSkuDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: ProductSkuDto[];
}

export interface SkuCreateOrUpdateDto {
  /**  */
  id?: string;

  /**  */
  spuId?: string;

  /**  */
  name?: string;

  /**  */
  code?: string;

  /**  */
  price?: number;

  /**  */
  originPrice?: number;

  /**  */
  vipPrice?: number;

  /**  */
  desc?: string;

  /**  */
  purchaseNotes?: string;

  /**  */
  coverImageUrls?: string[];

  /**  */
  dateTimeStart?: Date;

  /**  */
  dateTimeEnd?: Date;

  /**  */
  stockCount?: number;

  /**  */
  soldCount?: number;

  /**  */
  limitBuyCount?: number;

  /**  */
  unit?: string;
}

export interface SpuCreateOrUpdateDto {
  /**  */
  shopId?: string;

  /**  */
  categoryId?: string;

  /**  */
  name?: string;

  /**  */
  code?: string;

  /**  */
  descCommon?: string;

  /**  */
  purchaseNotesCommon?: string;

  /**  */
  dateTimeStart?: Date;

  /**  */
  dateTimeEnd?: Date;

  /**  */
  stockCount?: number;

  /**  */
  soldCount?: number;

  /**  */
  limitBuyCount?: number;

  /**  */
  skus?: SkuCreateOrUpdateDto[];
}

export interface SpuCreateOrUpdateDtoGetForEditOutput {
  /**  */
  data?: SpuCreateOrUpdateDto;

  /**  */
  schema?: any | null;
}

export interface ProductSpuDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: ProductSpuDto[];
}

export interface ProfileDto {
  /**  */
  userName?: string;

  /**  */
  email?: string;

  /**  */
  name?: string;

  /**  */
  surname?: string;

  /**  */
  phoneNumber?: string;

  /**  */
  extraProperties?: object;
}

export interface UpdateProfileDto {
  /**  */
  userName?: string;

  /**  */
  email?: string;

  /**  */
  name?: string;

  /**  */
  surname?: string;

  /**  */
  phoneNumber?: string;

  /**  */
  extraProperties?: object;
}

export interface ChangePasswordInput {
  /**  */
  currentPassword?: string;

  /**  */
  newPassword?: string;
}

export interface UserProfileInput {
  /**  */
  isAuthenticated?: boolean;

  /**  */
  userName?: string;

  /**  */
  name?: string;

  /**  */
  surname?: string;

  /**  */
  phoneNumber?: string;

  /**  */
  phoneNumberConfirmed?: boolean;

  /**  */
  email?: string;

  /**  */
  password?: string;

  /**  */
  passwordConfirm?: string;

  /**  */
  nickname?: string;

  /**  */
  headImgUrl?: string;

  /**  */
  tenantId?: string;

  /**  */
  id?: string;
}

export interface RealNameInfoDto {
  /**  */
  realName?: string;

  /**  */
  phone?: string;

  /**  */
  phoneBackup?: string;

  /**  */
  type?: RealNameInfoType;

  /**  */
  idCardFrontUrl?: string;

  /**  */
  idCardBackUrl?: string;

  /**  */
  idCardHandUrl?: string;

  /**  */
  businessLicenseUrl?: string;

  /**  */
  state?: RealNameInfoState;

  /**  */
  id?: string;
}

export interface RealNameInfoDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: RealNameInfoDto[];
}

export interface IdentityRoleDto {
  /**  */
  name?: string;

  /**  */
  isDefault?: boolean;

  /**  */
  isStatic?: boolean;

  /**  */
  isPublic?: boolean;

  /**  */
  concurrencyStamp?: string;

  /**  */
  id?: string;

  /**  */
  extraProperties?: object;
}

export interface IdentityRoleDtoListResultDto {
  /**  */
  items?: IdentityRoleDto[];
}

export interface IdentityRoleDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: IdentityRoleDto[];
}

export interface IdentityRoleCreateDto {
  /**  */
  name?: string;

  /**  */
  isDefault?: boolean;

  /**  */
  isPublic?: boolean;

  /**  */
  extraProperties?: object;
}

export interface IdentityRoleUpdateDto {
  /**  */
  concurrencyStamp?: string;

  /**  */
  name?: string;

  /**  */
  isDefault?: boolean;

  /**  */
  isPublic?: boolean;

  /**  */
  extraProperties?: object;
}

export interface ShopDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: ShopDto[];
}

export interface VisitorShopCreateOrEditDto {
  /**  */
  name?: string;

  /**  */
  shortName?: string;

  /**  */
  logoImage?: string;

  /**  */
  coverImage?: string;

  /**  */
  description?: string;
}

export interface SwiperDto {
  /**  */
  groupName?: string;

  /**  */
  appName?: string;

  /**  */
  coverImageUrl?: string;

  /**  */
  name?: string;

  /**  */
  redirectUrl?: string;

  /**  */
  state?: number;

  /**  */
  sort?: number;

  /**  */
  shopId?: string;

  /**  */
  id?: string;
}

export interface SwiperDtoListResultDto {
  /**  */
  items?: SwiperDto[];
}

export interface SwiperCreateOrUpdateDto {
  /**  */
  groupName?: string;

  /**  */
  appName?: string;

  /**  */
  coverImageUrl?: string;

  /**  */
  name?: string;

  /**  */
  redirectUrl?: string;

  /**  */
  state?: number;

  /**  */
  sort?: number;

  /**  */
  shopId?: string;
}

export interface SwiperCreateOrUpdateDtoGetForEditOutput {
  /**  */
  data?: SwiperCreateOrUpdateDto;

  /**  */
  schema?: any | null;
}

export interface SwiperDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: SwiperDto[];
}

export interface TenantDto {
  /**  */
  name?: string;

  /**  */
  id?: string;

  /**  */
  extraProperties?: object;
}

export interface TenantUpdateDto {
  /**  */
  name?: string;

  /**  */
  extraProperties?: object;
}

export interface TenantDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: TenantDto[];
}

export interface TenantCreateDto {
  /**  */
  adminEmailAddress?: string;

  /**  */
  adminPassword?: string;

  /**  */
  name?: string;

  /**  */
  extraProperties?: object;
}

export interface IdentityUserUpdateDto {
  /**  */
  password?: string;

  /**  */
  concurrencyStamp?: string;

  /**  */
  userName?: string;

  /**  */
  name?: string;

  /**  */
  surname?: string;

  /**  */
  email?: string;

  /**  */
  phoneNumber?: string;

  /**  */
  twoFactorEnabled?: boolean;

  /**  */
  lockoutEnabled?: boolean;

  /**  */
  roleNames?: string[];

  /**  */
  extraProperties?: object;
}

export interface IdentityUserDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: IdentityUserDto[];
}

export interface IdentityUserCreateDto {
  /**  */
  password?: string;

  /**  */
  userName?: string;

  /**  */
  name?: string;

  /**  */
  surname?: string;

  /**  */
  email?: string;

  /**  */
  phoneNumber?: string;

  /**  */
  twoFactorEnabled?: boolean;

  /**  */
  lockoutEnabled?: boolean;

  /**  */
  roleNames?: string[];

  /**  */
  extraProperties?: object;
}

export interface IdentityUserUpdateRolesDto {
  /**  */
  roleNames?: string[];
}

export interface UserCouponDto {
  /**  */
  couponId?: string;

  /**  */
  ownerUserId?: string;

  /**  */
  couponName?: string;

  /**  */
  couponAmount?: number;

  /**  */
  paymentId?: string;

  /**  */
  usedTime?: Date;

  /**  */
  usedOrderId?: string;

  /**  */
  usedOrderType?: OrderType;

  /**  */
  coupon?: CouponDto;

  /**  */
  id?: string;
}

export interface UserCouponDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: UserCouponDto[];
}

export interface UserCouponDtoListResultDto {
  /**  */
  items?: UserCouponDto[];
}

export interface UserCouponCreateOrUpdateDto {
  /**  */
  couponId?: string;

  /**  */
  ownerUserId?: string;
}

export interface UserData {
  /**  */
  id?: string;

  /**  */
  tenantId?: string;

  /**  */
  userName?: string;

  /**  */
  name?: string;

  /**  */
  surname?: string;

  /**  */
  email?: string;

  /**  */
  emailConfirmed?: boolean;

  /**  */
  phoneNumber?: string;

  /**  */
  phoneNumberConfirmed?: boolean;
}

export interface CredentialDto {
  /**  */
  type?: CredentialType;

  /**  */
  data?: string;
}

export interface VisitorLogDto {
  /**  */
  id?: string;

  /**  */
  formId?: string;

  /**  */
  formJson?: FormItemDto[];

  /**  */
  credentialId?: string;

  /**  */
  credential?: CredentialDto;

  /**  */
  creationTime?: Date;

  /**  */
  lat?: number;

  /**  */
  lng?: number;

  /**  */
  leaveTime?: Date;

  /**  */
  html?: string;
}

export interface VisitorLogDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: VisitorLogDto[];
}

export interface VisitorFormSumbitRequest {
  /**  */
  formItems?: FormItemDto[];

  /**  */
  form?: FormDto;

  /**  */
  shop?: VisitorShopDto;
}

export interface WechatUserinfo {
  /**  */
  appid?: string;

  /**  */
  openid?: string;

  /**  */
  unionid?: string;

  /**  */
  nickname?: string;

  /**  */
  headimgurl?: string;

  /**  */
  city?: string;

  /**  */
  province?: string;

  /**  */
  country?: string;

  /**  */
  sex?: number;

  /**  */
  fromClient?: ClientType;

  /**  */
  appName?: string;

  /**  */
  creationTime?: Date;

  /**  */
  creatorId?: string;
}

export interface WechatUserinfoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: WechatUserinfo[];
}

export enum LocationType {
  'bd09' = 'bd09',
  'gcj02' = 'gcj02',
  'wgs84' = 'wgs84'
}

export enum UseType {
  '全场通用' = '全场通用',
  '指定分类' = '指定分类',
  '指定商品' = '指定商品'
}

export enum FormTheme {
  'red' = 'red',
  'black' = 'black',
  'green' = 'green'
}

export enum FormItemType {
  'Input' = 'Input',
  'TextArea' = 'TextArea',
  'Radio' = 'Radio',
  'Checkbox' = 'Checkbox',
  'Image' = 'Image',
  'File' = 'File'
}

export enum PartnerState {
  '待审核' = '待审核',
  '驳回' = '驳回',
  '成功' = '成功'
}

export enum PayState {
  '取消' = '取消',
  '未支付' = '未支付',
  '已支付' = '已支付',
  '待退款' = '待退款'
}

export enum OrderType {
  'Default' = 'Default',
  'Product' = 'Product'
}

export enum PayType {
  'UnPay' = 'UnPay',
  '微信' = '微信',
  '微信扫码' = '微信扫码',
  '支付宝' = '支付宝',
  '银联' = '银联',
  '用户余额' = '用户余额'
}

export enum OrderState {
  '已取消' = '已取消',
  '未完成' = '未完成',
  '正在派送' = '正在派送',
  '派送完成' = '派送完成',
  '完成' = '完成'
}

export enum ProductOrderType {
  '未标记' = '未标记',
  '零售' = '零售',
  '外送' = '外送',
  '自提' = '自提',
  '跑腿' = '跑腿',
  '美团' = '美团',
  '快递' = '快递'
}

export enum RealNameInfoType {
  '个人' = '个人',
  '企业' = '企业'
}

export enum RealNameInfoState {
  '未认证' = '未认证',
  '个人认证' = '个人认证',
  '企业认证' = '企业认证'
}

export enum CredentialType {
  'Default' = 'Default',
  'Code' = 'Code',
  'Image' = 'Image',
  'IdCard' = 'IdCard'
}

export enum ClientType {
  'Default' = 'Default',
  'Mini' = 'Mini',
  'Mp' = 'Mp',
  'Qy' = 'Qy'
}
