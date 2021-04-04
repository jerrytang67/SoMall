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
      skipCount?: number;
      /**  */
      maxResultCount?: number;
      /**  */
      sorting?: string;
    } = {} as any
  ): Observable<AddressDtoPagedResultDto> {
    let url = '/api/mall/address/get-list';
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
    let url = '/api/mall/address/set-default';
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
  getPublishList(): Observable<AppDefinition[]> {
    let url = '/api/app/app/get-publish-list';
    let options: any = {
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<AppDefinition[]>;
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
      skipCount?: number;
      /**  */
      maxResultCount?: number;
      /**  */
      sorting?: string;
    } = {} as any
  ): Observable<AppDtoPagedResultDto> {
    let url = '/api/app/app/get-list';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<AppDtoPagedResultDto>;
  }
}

@Injectable({ providedIn: 'root' })
export class AuditFlowProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  getForEdit(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<AuditFlowCreateOrEditDtoGetForEditOutput> {
    let url = '/api/audit/audit-flow/get-for-edit';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<AuditFlowCreateOrEditDtoGetForEditOutput>;
  }
  /**
   *
   */
  create(
    params: {
      /** requestBody */
      body?: AuditFlowCreateOrEditDto;
    } = {} as any
  ): Observable<AuditFlowDto> {
    let url = '/api/audit/audit-flow/create';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<AuditFlowDto>;
  }
  /**
   *
   */
  update(
    params: {
      /**  */
      id?: string;
      /** requestBody */
      body?: AuditFlowCreateOrEditDto;
    } = {} as any
  ): Observable<AuditFlowDto> {
    let url = '/api/audit/audit-flow/update';
    let options: any = {
      params: { id: params.id },
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<AuditFlowDto>;
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
    let url = '/api/audit/audit-flow/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<AuditFlowDto> {
    let url = '/api/audit/audit-flow/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<AuditFlowDto>;
  }
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
  ): Observable<AuditFlowDtoPagedResultDto> {
    let url = '/api/audit/audit-flow/get-list';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<AuditFlowDtoPagedResultDto>;
  }
}

@Injectable({ providedIn: 'root' })
export class AuditLogProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  getAuditLogs(
    params: {
      /**  */
      startDate?: string;
      /**  */
      endDate?: string;
      /**  */
      userName?: string;
      /**  */
      serviceName?: string;
      /**  */
      methodName?: string;
      /**  */
      browserInfo?: string;
      /**  */
      hasException?: boolean;
      /**  */
      minExecutionDuration?: number;
      /**  */
      maxExecutionDuration?: number;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<AuditLogListDtoPagedResultDto> {
    let url = '/api/app/audit-log/get-audit-logs';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<AuditLogListDtoPagedResultDto>;
  }
}

@Injectable({ providedIn: 'root' })
export class AuditManagementProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  getAll(): Observable<AuditDefinition[]> {
    let url = '/api/audit/audit-management/get-all';
    let options: any = {
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<AuditDefinition[]>;
  }
  /**
   *
   */
  get(
    params: {
      /**  */
      name?: string;
      /**  */
      providerName?: string;
    } = {} as any
  ): Observable<string> {
    let url = '/api/audit/audit-management/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<string>;
  }
}

@Injectable({ providedIn: 'root' })
export class CmsCategoryProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  create(
    params: {
      /** requestBody */
      body?: CategoryCreateOrUpdate;
    } = {} as any
  ): Observable<CategoryDto> {
    let url = '/api/cms/cms-category/create';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<CategoryDto>;
  }
  /**
   *
   */
  getForEdit(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<CategoryCreateOrUpdateGetForEditOutput> {
    let url = '/api/cms/cms-category/get-for-edit';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<CategoryCreateOrUpdateGetForEditOutput>;
  }
  /**
   *
   */
  dianZan(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/cms/cms-category/dian-zan';
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
  update(
    params: {
      /**  */
      id?: string;
      /** requestBody */
      body?: CategoryCreateOrUpdate;
    } = {} as any
  ): Observable<CategoryDto> {
    let url = '/api/cms/cms-category/update';
    let options: any = {
      params: { id: params.id },
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<CategoryDto>;
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
    let url = '/api/cms/cms-category/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<CategoryDto> {
    let url = '/api/cms/cms-category/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<CategoryDto>;
  }
  /**
   *
   */
  getList(
    params: {
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
      /**  */
      sorting?: string;
    } = {} as any
  ): Observable<CategoryDtoPagedResultDto> {
    let url = '/api/cms/cms-category/get-list';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<CategoryDtoPagedResultDto>;
  }
}

@Injectable({ providedIn: 'root' })
export class CommentProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  create(
    params: {
      /** requestBody */
      body?: CommentCreateOrUpdateDto;
    } = {} as any
  ): Observable<CommentDto> {
    let url = '/api/mall/comment/create';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<CommentDto>;
  }
  /**
   *
   */
  update(
    params: {
      /**  */
      id?: string;
      /** requestBody */
      body?: CommentCreateOrUpdateDto;
    } = {} as any
  ): Observable<CommentDto> {
    let url = '/api/mall/comment/update';
    let options: any = {
      params: { id: params.id },
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<CommentDto>;
  }
  /**
   *
   */
  getList(
    params: {
      /**  */
      state?: number;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      spuId?: string;
      /**  */
      skuId?: string;
      /**  */
      appName?: string;
      /**  */
      locationType?: LocationType;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<CommentDtoPagedResultDto> {
    let url = '/api/mall/comment/get-list';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<CommentDtoPagedResultDto>;
  }
  /**
   *
   */
  getPublishList(
    params: {
      /**  */
      state?: number;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      spuId?: string;
      /**  */
      skuId?: string;
      /**  */
      appName?: string;
      /**  */
      locationType?: LocationType;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<CommentDtoPagedResultDto> {
    let url = '/api/mall/comment/get-publish-list';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<CommentDtoPagedResultDto>;
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
    let url = '/api/mall/comment/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<CommentDto> {
    let url = '/api/mall/comment/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<CommentDto>;
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
      state?: number;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      spuId?: string;
      /**  */
      skuId?: string;
      /**  */
      appName?: string;
      /**  */
      locationType?: LocationType;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<CouponDtoListResultDto> {
    let url = '/api/mall/coupon/get-publish-list';
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
      state?: number;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      spuId?: string;
      /**  */
      skuId?: string;
      /**  */
      appName?: string;
      /**  */
      locationType?: LocationType;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<CouponDtoPagedResultDto> {
    let url = '/api/mall/coupon/get-list';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<CouponDtoPagedResultDto>;
  }
}

@Injectable({ providedIn: 'root' })
export class FormProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  getList(): Observable<FormDtoListResultDto> {
    let url = '/api/Visitor/form/get-list';
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
    let url = '/api/Visitor/form/get-shops';
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
    let url = '/api/Visitor/form/get-shop-form';
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
    let url = '/api/Visitor/form/add-shop';
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
    let url = '/api/mall/mall-shop/get';
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
    let url = '/api/mall/mall-shop/get-list';
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
    let url = '/api/mall/mall-shop/shop-sync';
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
  create(
    params: {
      /** requestBody */
      body?: MallUserDto;
    } = {} as any
  ): Observable<MallUserDto> {
    let url = '/api/mall/mall-user/create';
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
    let url = '/api/mall/mall-user/update';
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
    let url = '/api/mall/mall-user/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<MallUserDto> {
    let url = '/api/mall/mall-user/get';
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
      skipCount?: number;
      /**  */
      maxResultCount?: number;
      /**  */
      sorting?: string;
    } = {} as any
  ): Observable<MallUserDtoPagedResultDto> {
    let url = '/api/mall/mall-user/get-list';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<MallUserDtoPagedResultDto>;
  }
}

@Injectable({ providedIn: 'root' })
export class OssProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  getConfig(): Observable<any> {
    let url = '/api/app/oss/get-config';
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
    let url = '/api/app/oss/get-signature';
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
      state?: number;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      spuId?: string;
      /**  */
      skuId?: string;
      /**  */
      appName?: string;
      /**  */
      locationType?: LocationType;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<PartnerDtoPagedResultDto> {
    let url = '/api/mall/partner/get-list';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<PartnerDtoPagedResultDto>;
  }
  /**
   *
   */
  getCurrent(): Observable<PartnerCreateOrUpdateDto> {
    let url = '/api/mall/partner/get-current';
    let options: any = {
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<PartnerCreateOrUpdateDto>;
  }
  /**
   *
   */
  publicEdit(
    params: {
      /** requestBody */
      body?: PartnerCreateOrUpdateDto;
    } = {} as any
  ): Observable<any> {
    let url = '/api/mall/partner/public-edit';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<any>;
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
      state?: number;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      spuId?: string;
      /**  */
      skuId?: string;
      /**  */
      appName?: string;
      /**  */
      locationType?: LocationType;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<PayOrderDto> {
    let url = '/api/mall/pay-order/get';
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
      state?: number;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      spuId?: string;
      /**  */
      skuId?: string;
      /**  */
      appName?: string;
      /**  */
      locationType?: LocationType;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<PayOrderDtoPagedResultDto> {
    let url = '/api/mall/pay-order/get-list';
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
      state?: number;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      spuId?: string;
      /**  */
      skuId?: string;
      /**  */
      appName?: string;
      /**  */
      locationType?: LocationType;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<PayOrderDtoPagedResultDto> {
    let url = '/api/mall/pay-order/get-public-list';
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
    let url = '/api/mall/product-category/get-for-edit';
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
    let url = '/api/mall/product-category/update';
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
  create(
    params: {
      /** requestBody */
      body?: CategoryCreateOrUpdateDto;
    } = {} as any
  ): Observable<ProductCategoryDto> {
    let url = '/api/mall/product-category/create';
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
    let url = '/api/mall/product-category/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
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
    let url = '/api/mall/product-category/get';
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
      state?: number;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      spuId?: string;
      /**  */
      skuId?: string;
      /**  */
      appName?: string;
      /**  */
      locationType?: LocationType;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<ProductCategoryDtoPagedResultDto> {
    let url = '/api/mall/product-category/get-list';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<ProductCategoryDtoPagedResultDto>;
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
    let url = '/api/mall/product-order/get';
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
      state?: number;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      spuId?: string;
      /**  */
      skuId?: string;
      /**  */
      appName?: string;
      /**  */
      locationType?: LocationType;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<ProductOrderDtoPagedResultDto> {
    let url = '/api/mall/product-order/get-list';
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
    let url = '/api/mall/product-order/create';
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
    let url = '/api/mall/product-order/pay';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  refund(
    params: {
      /** requestBody */
      body?: RefundRequestDto;
    } = {} as any
  ): Observable<any> {
    let url = '/api/mall/product-order/refund';
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
      state?: number;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      spuId?: string;
      /**  */
      skuId?: string;
      /**  */
      appName?: string;
      /**  */
      locationType?: LocationType;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<ProductOrderDtoPagedResultDto> {
    let url = '/api/mall/product-order/get-public-list';
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
    let url = '/api/mall/product-order/update';
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
    let url = '/api/mall/product-order/delete';
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
  create(
    params: {
      /** requestBody */
      body?: SkuCreateOrUpdateDto;
    } = {} as any
  ): Observable<ProductSkuDto> {
    let url = '/api/mall/product-sku/create';
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
    let url = '/api/mall/product-sku/update';
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
    let url = '/api/mall/product-sku/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<ProductSkuDto> {
    let url = '/api/mall/product-sku/get';
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
      state?: number;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      spuId?: string;
      /**  */
      skuId?: string;
      /**  */
      appName?: string;
      /**  */
      locationType?: LocationType;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<ProductSkuDtoPagedResultDto> {
    let url = '/api/mall/product-sku/get-list';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<ProductSkuDtoPagedResultDto>;
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
    let url = '/api/mall/product-spu/get';
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
    let url = '/api/mall/product-spu/create';
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
    let url = '/api/mall/product-spu/update';
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
    let url = '/api/mall/product-spu/get-for-edit';
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
      state?: number;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      spuId?: string;
      /**  */
      skuId?: string;
      /**  */
      appName?: string;
      /**  */
      locationType?: LocationType;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<ProductSpuDtoPagedResultDto> {
    let url = '/api/mall/product-spu/get-list';
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
  getQr(
    params: {
      /** requestBody */
      body?: MallRequestDto;
    } = {} as any
  ): Observable<QrDetail> {
    let url = '/api/mall/product-spu/get-qr';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<QrDetail>;
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
    let url = '/api/mall/product-spu/delete';
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
    let url = '/api/app/public/get-current-user';
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
    let url = '/api/app/public/update-user-profile';
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
      skipCount?: number;
      /**  */
      maxResultCount?: number;
      /**  */
      sorting?: string;
    } = {} as any
  ): Observable<RealNameInfoDtoPagedResultDto> {
    let url = '/api/app/real-name-info/get-list';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<RealNameInfoDtoPagedResultDto>;
  }
}

@Injectable({ providedIn: 'root' })
export class RefundLogProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  create(
    params: {
      /** requestBody */
      body?: RefundLogDto;
    } = {} as any
  ): Observable<RefundLogDto> {
    let url = '/api/mall/refund-log/create';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<RefundLogDto>;
  }
  /**
   *
   */
  update(
    params: {
      /**  */
      id?: string;
      /** requestBody */
      body?: RefundLogDto;
    } = {} as any
  ): Observable<RefundLogDto> {
    let url = '/api/mall/refund-log/update';
    let options: any = {
      params: { id: params.id },
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<RefundLogDto>;
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
    let url = '/api/mall/refund-log/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  startAudit(
    params: {
      /** requestBody */
      body?: RefundLogDto;
    } = {} as any
  ): Observable<any> {
    let url = '/api/mall/refund-log/start-audit';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  agree(): Observable<any> {
    let url = '/api/mall/refund-log/agree';
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
  ): Observable<RefundLogDto> {
    let url = '/api/mall/refund-log/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<RefundLogDto>;
  }
  /**
   *
   */
  getList(
    params: {
      /**  */
      state?: number;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      spuId?: string;
      /**  */
      skuId?: string;
      /**  */
      appName?: string;
      /**  */
      locationType?: LocationType;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<RefundLogDtoPagedResultDto> {
    let url = '/api/mall/refund-log/get-list';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<RefundLogDtoPagedResultDto>;
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
      filter?: string;
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
    let url = '/api/app/shop/get-list';
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
    let url = '/api/app/shop/get-by-short-name';
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
      state?: number;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      spuId?: string;
      /**  */
      skuId?: string;
      /**  */
      appName?: string;
      /**  */
      locationType?: LocationType;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<SwiperDtoListResultDto> {
    let url = '/api/mall/swiper/get-publish-list';
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
    let url = '/api/mall/swiper/get-for-edit';
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
      state?: number;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      spuId?: string;
      /**  */
      skuId?: string;
      /**  */
      appName?: string;
      /**  */
      locationType?: LocationType;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<SwiperDtoPagedResultDto> {
    let url = '/api/mall/swiper/get-list';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<SwiperDtoPagedResultDto>;
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
  assignableRoles(): Observable<IdentityRoleDtoListResultDto> {
    let url = '/api/identity/users/assignable-roles';
    let options: any = {
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<IdentityRoleDtoListResultDto>;
  }
  /**
   *
   */
  byUsername(
    params: {
      /**  */
      userName: string;
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
      state?: number;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      spuId?: string;
      /**  */
      skuId?: string;
      /**  */
      appName?: string;
      /**  */
      locationType?: LocationType;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<UserCouponDtoPagedResultDto> {
    let url = '/api/mall/user-coupon/get-list';
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
      state?: number;
      /**  */
      keywords?: string;
      /**  */
      shopId?: string;
      /**  */
      spuId?: string;
      /**  */
      skuId?: string;
      /**  */
      appName?: string;
      /**  */
      locationType?: LocationType;
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<UserCouponDtoListResultDto> {
    let url = '/api/mall/user-coupon/get-public-list';
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
  create(
    params: {
      /** requestBody */
      body?: UserCouponCreateOrUpdateDto;
    } = {} as any
  ): Observable<UserCouponDto> {
    let url = '/api/mall/user-coupon/create';
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
    let url = '/api/mall/user-coupon/update';
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
    let url = '/api/mall/user-coupon/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
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
    let url = '/api/mall/user-coupon/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<UserCouponDto>;
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
  /**
   *
   */
  search(
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
  ): Observable<UserDataListResultDto> {
    let url = '/api/identity/users/lookup/search';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<UserDataListResultDto>;
  }
  /**
   *
   */
  count(
    params: {
      /**  */
      filter?: string;
    } = {} as any
  ): Observable<number> {
    let url = '/api/identity/users/lookup/count';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<number>;
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
    let url = '/api/Visitor/visitor-log/get-list';
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
    let url = '/api/Visitor/visitor-log/get';
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
    let url = '/api/Visitor/visitor-log/delete';
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
    let url = '/api/Visitor/visitor-log/form-submit';
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
    let url = '/api/Visitor/visitor-log/leave';
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
      skipCount?: number;
      /**  */
      maxResultCount?: number;
      /**  */
      sorting?: string;
    } = {} as any
  ): Observable<WechatUserinfoPagedResultDto> {
    let url = '/api/app/wechat-user/get-list';
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
  getAccessToken(
    params: {
      /**  */
      appid?: string;
    } = {} as any
  ): Observable<string> {
    let url = '/api/app/weixin/get-access-token';
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
    let url = '/api/app/weixin/mini-auth';
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
    let url = '/api/app/weixin/check-login';
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
    let url = '/api/app/weixin/get-un-limit-qr';
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
    let url = '/api/app/weixin/get-phone';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  getJssdk(
    params: {
      /**  */
      url?: string;
      /**  */
      appName?: string;
    } = {} as any
  ): Observable<JssdkResultDto> {
    let url = '/api/app/weixin/get-jssdk';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<JssdkResultDto>;
  }
  /**
   *
   */
  getOAuth(
    params: {
      /**  */
      code?: string;
      /**  */
      appName?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/app/weixin/get-oAuth';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<any>;
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
  defaultValue?: any | null;
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
  defaultValue?: any | null;

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

  /**  */
  isRequired?: boolean;
}

export interface TypeApiDescriptionModel {
  /**  */
  baseType?: string;

  /**  */
  isEnum?: boolean;

  /**  */
  enumNames?: string[];

  /**  */
  enumValues?: any | null[];

  /**  */
  genericArguments?: string[];

  /**  */
  properties?: PropertyApiDescriptionModel[];
}

export interface ApplicationApiDescriptionModel {
  /**  */
  modules?: object;

  /**  */
  types?: object;
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
  data?: object;

  /**  */
  validationErrors?: RemoteServiceValidationErrorInfo[];
}

export interface RemoteServiceErrorResponse {
  /**  */
  error?: RemoteServiceErrorInfo;
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

export interface NameValue {
  /**  */
  name?: string;

  /**  */
  value?: string;
}

export interface ApplicationLocalizationConfigurationDto {
  /**  */
  values?: object;

  /**  */
  languages?: LanguageInfo[];

  /**  */
  currentCulture?: CurrentCultureDto;

  /**  */
  defaultResourceName?: string;

  /**  */
  languagesMap?: object;

  /**  */
  languageFilesMap?: object;
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

  /**  */
  name?: string;

  /**  */
  surName?: string;

  /**  */
  email?: string;

  /**  */
  emailVerified?: boolean;

  /**  */
  phoneNumber?: string;

  /**  */
  phoneNumberVerified?: boolean;

  /**  */
  roles?: string[];
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

export interface IanaTimeZone {
  /**  */
  timeZoneName?: string;
}

export interface WindowsTimeZone {
  /**  */
  timeZoneId?: string;
}

export interface TimeZone {
  /**  */
  iana?: IanaTimeZone;

  /**  */
  windows?: WindowsTimeZone;
}

export interface TimingDto {
  /**  */
  timeZone?: TimeZone;
}

export interface ClockDto {
  /**  */
  kind?: string;
}

export interface LocalizableStringDto {
  /**  */
  name?: string;

  /**  */
  resource?: string;
}

export interface ExtensionPropertyApiGetDto {
  /**  */
  isAvailable?: boolean;
}

export interface ExtensionPropertyApiCreateDto {
  /**  */
  isAvailable?: boolean;
}

export interface ExtensionPropertyApiUpdateDto {
  /**  */
  isAvailable?: boolean;
}

export interface ExtensionPropertyApiDto {
  /**  */
  onGet?: ExtensionPropertyApiGetDto;

  /**  */
  onCreate?: ExtensionPropertyApiCreateDto;

  /**  */
  onUpdate?: ExtensionPropertyApiUpdateDto;
}

export interface ExtensionPropertyUiTableDto {
  /**  */
  isVisible?: boolean;
}

export interface ExtensionPropertyUiFormDto {
  /**  */
  isVisible?: boolean;
}

export interface ExtensionPropertyUiLookupDto {
  /**  */
  url?: string;

  /**  */
  resultListPropertyName?: string;

  /**  */
  displayPropertyName?: string;

  /**  */
  valuePropertyName?: string;

  /**  */
  filterParamName?: string;
}

export interface ExtensionPropertyUiDto {
  /**  */
  onTable?: ExtensionPropertyUiTableDto;

  /**  */
  onCreateForm?: ExtensionPropertyUiFormDto;

  /**  */
  onEditForm?: ExtensionPropertyUiFormDto;

  /**  */
  lookup?: ExtensionPropertyUiLookupDto;
}

export interface ExtensionPropertyAttributeDto {
  /**  */
  typeSimple?: string;

  /**  */
  config?: object;
}

export interface ExtensionPropertyDto {
  /**  */
  type?: string;

  /**  */
  typeSimple?: string;

  /**  */
  displayName?: LocalizableStringDto;

  /**  */
  api?: ExtensionPropertyApiDto;

  /**  */
  ui?: ExtensionPropertyUiDto;

  /**  */
  attributes?: ExtensionPropertyAttributeDto[];

  /**  */
  configuration?: object;

  /**  */
  defaultValue?: any | null;
}

export interface EntityExtensionDto {
  /**  */
  properties?: object;

  /**  */
  configuration?: object;
}

export interface ModuleExtensionDto {
  /**  */
  entities?: object;

  /**  */
  configuration?: object;
}

export interface ExtensionEnumFieldDto {
  /**  */
  name?: string;

  /**  */
  value?: any | null;
}

export interface ExtensionEnumDto {
  /**  */
  fields?: ExtensionEnumFieldDto[];

  /**  */
  localizationResource?: string;
}

export interface ObjectExtensionsDto {
  /**  */
  modules?: object;

  /**  */
  enums?: object;
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

  /**  */
  timing?: TimingDto;

  /**  */
  clock?: ClockDto;

  /**  */
  objectExtensions?: ObjectExtensionsDto;
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

export interface SendPasswordResetCodeDto {
  /**  */
  email?: string;

  /**  */
  appName?: string;

  /**  */
  returnUrl?: string;

  /**  */
  returnUrlHash?: string;
}

export interface ResetPasswordDto {
  /**  */
  userId?: string;

  /**  */
  resetToken?: string;

  /**  */
  password?: string;
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
  locationLabel?: string;

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
  locationLabel?: string;

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

export interface ILocalizableString {}

export interface AppDefinition {
  /**  */
  name?: string;

  /**  */
  clientName?: string;

  /**  */
  defaultValues?: object;

  /**  */
  clientType?: string;

  /**  */
  providers?: string[];

  /**  */
  displayName?: ILocalizableString;
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

export interface AuditNodeCreateOrEditDto {
  /**  */
  id?: string;

  /**  */
  desc?: string;

  /**  */
  userName?: string;

  /**  */
  userId?: string;

  /**  */
  index?: number;

  /**  */
  auditFlowId?: string;
}

export interface AuditFlowCreateOrEditDto {
  /**  */
  auditName?: string;

  /**  */
  enable?: boolean;

  /**  */
  providerName?: string;

  /**  */
  providerKey?: string;

  /**  */
  auditNodes?: AuditNodeCreateOrEditDto[];
}

export interface AuditFlowCreateOrEditDtoGetForEditOutput {
  /**  */
  data?: AuditFlowCreateOrEditDto;

  /**  */
  schema?: any | null;
}

export interface AuditNodeDto {
  /**  */
  desc?: string;

  /**  */
  userName?: string;

  /**  */
  userId?: string;

  /**  */
  index?: number;

  /**  */
  auditFlowId?: string;

  /**  */
  creationTime?: Date;

  /**  */
  creatorId?: string;

  /**  */
  id?: string;
}

export interface AuditFlowDto {
  /**  */
  auditName?: string;

  /**  */
  enable?: boolean;

  /**  */
  providerName?: string;

  /**  */
  providerKey?: string;

  /**  */
  auditNodes?: AuditNodeDto[];

  /**  */
  creationTime?: Date;

  /**  */
  creatorId?: string;

  /**  */
  id?: string;
}

export interface AuditFlowDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: AuditFlowDto[];
}

export interface EntityPropertyChange {
  /**  */
  tenantId?: string;

  /**  */
  entityChangeId?: string;

  /**  */
  newValue?: string;

  /**  */
  originalValue?: string;

  /**  */
  propertyName?: string;

  /**  */
  propertyTypeFullName?: string;

  /**  */
  id?: string;
}

export interface EntityChange {
  /**  */
  auditLogId?: string;

  /**  */
  tenantId?: string;

  /**  */
  changeTime?: Date;

  /**  */
  changeType?: EntityChangeType;

  /**  */
  entityTenantId?: string;

  /**  */
  entityId?: string;

  /**  */
  entityTypeFullName?: string;

  /**  */
  propertyChanges?: EntityPropertyChange[];

  /**  */
  extraProperties?: object;

  /**  */
  id?: string;
}

export interface AuditLogAction {
  /**  */
  tenantId?: string;

  /**  */
  auditLogId?: string;

  /**  */
  serviceName?: string;

  /**  */
  methodName?: string;

  /**  */
  parameters?: string;

  /**  */
  executionTime?: Date;

  /**  */
  executionDuration?: number;

  /**  */
  extraProperties?: object;

  /**  */
  id?: string;
}

export interface AuditLogListDto {
  /**  */
  applicationName?: string;

  /**  */
  userId?: string;

  /**  */
  userName?: string;

  /**  */
  tenantId?: string;

  /**  */
  tenantName?: string;

  /**  */
  impersonatorUserId?: string;

  /**  */
  impersonatorTenantId?: string;

  /**  */
  executionTime?: Date;

  /**  */
  executionDuration?: number;

  /**  */
  clientIpAddress?: string;

  /**  */
  clientName?: string;

  /**  */
  clientId?: string;

  /**  */
  correlationId?: string;

  /**  */
  browserInfo?: string;

  /**  */
  httpMethod?: string;

  /**  */
  url?: string;

  /**  */
  exceptions?: string;

  /**  */
  comments?: string;

  /**  */
  httpStatusCode?: number;

  /**  */
  entityChanges?: EntityChange[];

  /**  */
  actions?: AuditLogAction[];
}

export interface AuditLogListDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: AuditLogListDto[];
}

export interface AuditDefinition {
  /**  */
  name?: string;

  /**  */
  defaultValue?: string;

  /**  */
  providers?: string[];

  /**  */
  displayName?: ILocalizableString;
}

export interface ICurrentUser {
  /**  */
  isAuthenticated?: boolean;

  /**  */
  id?: string;

  /**  */
  userName?: string;

  /**  */
  name?: string;

  /**  */
  surName?: string;

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
  systemInfo?: any | null;

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

export interface AppProductSpuDto {
  /**  */
  appName?: string;

  /**  */
  productSpuId?: string;
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
  appProductSpus?: AppProductSpuDto[];

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

export interface QrDetail {
  /**  */
  appName?: string;

  /**  */
  eventName?: string;

  /**  */
  eventKey?: string;

  /**  */
  params?: object;

  /**  */
  viewCount?: number;

  /**  */
  tenantId?: string;

  /**  */
  path?: string;

  /**  */
  qrImageUrl?: string;

  /**  */
  creationTime?: Date;

  /**  */
  creatorId?: string;

  /**  */
  id?: string;
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

export interface CategoryCreateOrUpdate {
  /**  */
  name?: string;
}

export interface CategoryDto {
  /**  */
  name?: string;

  /**  */
  zan?: number;

  /**  */
  id?: string;
}

export interface CategoryCreateOrUpdateGetForEditOutput {
  /**  */
  data?: CategoryCreateOrUpdate;

  /**  */
  schema?: any | null;
}

export interface CategoryDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: CategoryDto[];
}

export interface CommentCreateOrUpdateDto {
  /**  */
  content?: string;

  /**  */
  spuId?: string;

  /**  */
  skuId?: string;

  /**  */
  shopId?: string;
}

export interface CommentDto {
  /**  */
  buyerName?: string;

  /**  */
  buyerAvatar?: string;

  /**  */
  content?: string;

  /**  */
  level?: number;

  /**  */
  status?: number;

  /**  */
  spuId?: string;

  /**  */
  skuId?: string;

  /**  */
  shopId?: string;

  /**  */
  creationTime?: Date;

  /**  */
  creatorId?: string;

  /**  */
  id?: string;
}

export interface CommentDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: CommentDto[];
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

export interface CouponDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: CouponDto[];
}

export interface FeatureProviderDto {
  /**  */
  name?: string;

  /**  */
  key?: string;
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
  provider?: FeatureProviderDto;

  /**  */
  description?: string;

  /**  */
  valueType?: IStringValueType;

  /**  */
  depth?: number;

  /**  */
  parentName?: string;
}

export interface FeatureGroupDto {
  /**  */
  name?: string;

  /**  */
  displayName?: string;

  /**  */
  features?: FeatureDto[];
}

export interface GetFeatureListResultDto {
  /**  */
  groups?: FeatureGroupDto[];
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
  weixin?: string;

  /**  */
  introducting?: string;
}

export interface PartnerDto {
  /**  */
  backupPhone?: string;

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
  locationType?: LocationType;

  /**  */
  detail?: PartnerDetail;

  /**  */
  realName?: string;

  /**  */
  phone?: string;

  /**  */
  headImgUrl?: string;

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

export interface PartnerCreateOrUpdateDto {
  /**  */
  realName?: string;

  /**  */
  phone?: string;

  /**  */
  phoneBackup?: string;

  /**  */
  lat?: number;

  /**  */
  lng?: number;

  /**  */
  locationLabel?: string;

  /**  */
  locationAddress?: string;

  /**  */
  locationType?: LocationType;

  /**  */
  introducting?: string;
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
  apps?: any | null[];
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
  addressLocationLabel?: string;

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

export interface RefundRequestDto {
  /**  */
  orderId?: string;

  /**  */
  refundPrice?: number;

  /**  */
  reason?: string;
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

  /**  */
  commissionEnable?: boolean;

  /**  */
  commissionPrice?: number;
}

export interface ProductSkuDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: ProductSkuDto[];
}

export interface AppProductCategory {
  /**  */
  appName?: string;

  /**  */
  productCategoryId?: string;

  /**  */
  sort?: number;

  /**  */
  tenantId?: string;

  /**  */
  productCategory?: ProductCategory;

  /**  */
  creationTime?: Date;

  /**  */
  creatorId?: string;
}

export interface ProductCategory {
  /**  */
  name?: string;

  /**  */
  code?: string;

  /**  */
  logoImageUrl?: string;

  /**  */
  redirectUrl?: string;

  /**  */
  spuList?: ProductSpu[];

  /**  */
  tenantId?: string;

  /**  */
  shopId?: string;

  /**  */
  sort?: number;

  /**  */
  isGlobal?: boolean;

  /**  */
  appProductCategories?: AppProductCategory[];

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
  extraProperties?: object;

  /**  */
  concurrencyStamp?: string;

  /**  */
  id?: string;
}

export interface ProductSku {
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
  tenantId?: string;

  /**  */
  shopId?: string;

  /**  */
  commissionPrice?: number;

  /**  */
  commissionEnable?: boolean;

  /**  */
  spu?: ProductSpu;

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
  extraProperties?: object;

  /**  */
  concurrencyStamp?: string;

  /**  */
  id?: string;
}

export interface ProductSpu {
  /**  */
  categoryId?: string;

  /**  */
  tenantId?: string;

  /**  */
  shopId?: string;

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
  limitBuyCount?: number;

  /**  */
  soldCount?: number;

  /**  */
  category?: ProductCategory;

  /**  */
  skus?: ProductSku[];

  /**  */
  appProductSpus?: AppProductSpu[];

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
  extraProperties?: object;

  /**  */
  concurrencyStamp?: string;

  /**  */
  id?: string;
}

export interface AppProductSpu {
  /**  */
  appName?: string;

  /**  */
  productSpuId?: string;

  /**  */
  tenantId?: string;

  /**  */
  productSpu?: ProductSpu;

  /**  */
  creationTime?: Date;

  /**  */
  creatorId?: string;
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

  /**  */
  appProductSpus?: AppProductSpu[];

  /**  */
  apps?: any | null[];
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

export interface MallRequestDto {
  /**  */
  state?: number;

  /**  */
  keywords?: string;

  /**  */
  shopId?: string;

  /**  */
  spuId?: string;

  /**  */
  skuId?: string;

  /**  */
  appName?: string;

  /**  */
  locationType?: LocationType;

  /**  */
  sorting?: string;

  /**  */
  skipCount?: number;

  /**  */
  maxResultCount?: number;
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
  isExternal?: boolean;

  /**  */
  hasPassword?: boolean;

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

export interface RefundLogDto {
  /**  */
  billNo?: string;

  /**  */
  payOrderType?: OrderType;

  /**  */
  userId?: string;

  /**  */
  reason?: string;

  /**  */
  price?: number;

  /**  */
  isSuccess?: boolean;

  /**  */
  successTime?: Date;

  /**  */
  shopId?: string;

  /**  */
  auditFlowId?: string;

  /**  */
  audit?: number;

  /**  */
  auditStatus?: number;

  /**  */
  isAudited?: boolean;

  /**  */
  auditFlow?: AuditFlowDto;

  /**  */
  currentAuditNodes?: AuditNodeDto[];

  /**  */
  creationTime?: Date;

  /**  */
  creatorId?: string;

  /**  */
  id?: string;
}

export interface RefundLogDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: RefundLogDto[];
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

export interface UserDataListResultDto {
  /**  */
  items?: UserData[];
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

export interface JssdkResultDto {
  /**  */
  appId?: string;

  /**  */
  timestamp?: string;

  /**  */
  nonceStr?: string;

  /**  */
  signature?: string;
}

export type LocationType = 0 | 1 | 2;

export type EntityChangeType = 0 | 1 | 2;

export type UseType = 0 | 1 | 2;

export type FormTheme = 0 | 1 | 2;

export type FormItemType = 0 | 1 | 2 | 3 | 6 | 7;

export type PartnerState = 0 | 10 | -1;

export type PayState = 0 | 1 | 2 | 3 | 4 | -1;

export type OrderType = 0 | 1;

export type PayType = 0 | 1 | 2 | 3 | 4 | 10;

export type OrderState = 0 | 2 | 4 | 9 | 11 | 12 | 13 | -1;

export type ProductOrderType = 0 | 1 | 2 | 3 | 4 | 5 | 6;

export type RealNameInfoType = 0 | 1;

export type RealNameInfoState = 0 | 1 | 2;

export type CredentialType = 0 | 1 | 2;

export type ClientType = 0 | 1 | 2 | 4;
