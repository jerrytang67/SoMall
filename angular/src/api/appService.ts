/** Generate by swagger-axios-codegen */
// tslint:disable
/* eslint-disable */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';

export class IList<T> extends Array<T> { }
export class List<T> extends Array<T> { }

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
export class AbpApiDefinitionProxyService {
  constructor(private http: HttpClient) { }

  /**
   *
   */
  apiDefinition(): Observable<ApplicationApiDescriptionModel> {
    let url = '/api/abp/api-definition';
    let options: any = {
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<ApplicationApiDescriptionModel>;
  }
}

@Injectable({ providedIn: 'root' })
export class AbpApplicationConfigurationProxyService {
  constructor(private http: HttpClient) { }

  /**
   *
   */
  applicationConfiguration(): Observable<ApplicationConfigurationDto> {
    let url = '/api/abp/application-configuration';
    let options: any = {
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<ApplicationConfigurationDto>;
  }
}

@Injectable({ providedIn: 'root' })
export class AbpApplicationConfigurationScriptProxyService {
  constructor(private http: HttpClient) { }

  /**
   *
   */
  applicationConfigurationScript(): Observable<any> {
    let url = '/Abp/ApplicationConfigurationScript';
    let options: any = {
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class AbpLanguagesProxyService {
  constructor(private http: HttpClient) { }

  /**
   *
   */
  switch(
    params: {
      /**  */
      culture?: string;
      /**  */
      uiCulture?: string;
      /**  */
      returnUrl?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/Abp/Languages/Switch';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class AbpServiceProxyScriptProxyService {
  constructor(private http: HttpClient) { }

  /**
   *
   */
  serviceProxyScript(
    params: {
      /**  */
      type?: string;
      /**  */
      useCache?: boolean;
      /**  */
      modules?: string;
      /**  */
      controllers?: string;
      /**  */
      actions?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/Abp/ServiceProxyScript';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class AbpTenantProxyService {
  constructor(private http: HttpClient) { }

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
export class AccountProxyService {
  constructor(private http: HttpClient) { }

  /**
   *
   */
  register(
    params: {
      /** requestBody */
      body?: RegisterDto;
    } = {} as any
  ): Observable<IdentityUserDto> {
    let url = '/api/account/register';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<IdentityUserDto>;
  }
}

@Injectable({ providedIn: 'root' })
export class FormProxyService {
  constructor(private http: HttpClient) { }

  /**
   *
   */
  getList(): Observable<FormDtoListResultDto> {
    let url = '/api/app/form/getList';
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
    let url = '/api/app/form/get';
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
    let url = '/api/app/form/create';
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
    let url = '/api/app/form/update';
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
    let url = '/api/app/form/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class LoginProxyService {
  constructor(private http: HttpClient) { }

  /**
   *
   */
  login(
    params: {
      /** requestBody */
      body?: UserLoginInfo;
    } = {} as any
  ): Observable<AbpLoginResult> {
    let url = '/api/account/login';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<AbpLoginResult>;
  }
  /**
   *
   */
  logout(): Observable<any> {
    let url = '/api/account/logout';
    let options: any = {
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  checkPassword(
    params: {
      /** requestBody */
      body?: UserLoginInfo;
    } = {} as any
  ): Observable<AbpLoginResult> {
    let url = '/api/account/checkPassword';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<AbpLoginResult>;
  }
}

@Injectable({ providedIn: 'root' })
export class OssProxyService {
  constructor(private http: HttpClient) { }

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
}


@Injectable({ providedIn: 'root' })
export class ProductCategoryProxyService {
  constructor(private http: HttpClient) { }

  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<ProductCategoryDto> {
    let url = '/api/app/productCategory/get';
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
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<ProductCategoryDtoPagedResultDto> {
    let url = '/api/app/productCategory/getList';
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
      body?: CreateUpdateCategoryDto;
    } = {} as any
  ): Observable<ProductCategoryDto> {
    let url = '/api/app/productCategory/create';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<ProductCategoryDto>;
  }
  /**
   *
   */
  update(
    params: {
      /**  */
      id?: string;
      /** requestBody */
      body?: CreateUpdateCategoryDto;
    } = {} as any
  ): Observable<ProductCategoryDto> {
    let url = '/api/app/productCategory/update';
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
  delete(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/app/productCategory/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class ProductSkuProxyService {
  constructor(private http: HttpClient) { }

  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<ProductSkuDto> {
    let url = '/api/app/productSku/get';
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
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<ProductSkuDtoPagedResultDto> {
    let url = '/api/app/productSku/getList';
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
      body?: CreateUpdateSkuDto;
    } = {} as any
  ): Observable<ProductSkuDto> {
    let url = '/api/app/productSku/create';
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
      body?: CreateUpdateSkuDto;
    } = {} as any
  ): Observable<ProductSkuDto> {
    let url = '/api/app/productSku/update';
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
    let url = '/api/app/productSku/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class ProductSpuProxyService {
  constructor(private http: HttpClient) { }

  /**
   *
   */
  get(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<ProductSpuDto> {
    let url = '/api/app/productSpu/get';
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
  getList(
    params: {
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<ProductSpuDtoPagedResultDto> {
    let url = '/api/app/productSpu/getList';
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
  create(
    params: {
      /** requestBody */
      body?: CreateUpdateSpuDto;
    } = {} as any
  ): Observable<ProductSpuDto> {
    let url = '/api/app/productSpu/create';
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
      body?: CreateUpdateSpuDto;
    } = {} as any
  ): Observable<ProductSpuDto> {
    let url = '/api/app/productSpu/update';
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
  delete(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/app/productSpu/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class ProfileProxyService {
  constructor(private http: HttpClient) { }

  /**
   *
   */
  myProfile(): Observable<ProfileDto> {
    let url = '/api/identity/my-profile';
    let options: any = {
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<ProfileDto>;
  }
  /**
   *
   */
  myProfile1(
    params: {
      /** requestBody */
      body?: UpdateProfileDto;
    } = {} as any
  ): Observable<ProfileDto> {
    let url = '/api/identity/my-profile';
    let options: any = {
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<ProfileDto>;
  }
  /**
   *
   */
  changePassword(
    params: {
      /** requestBody */
      body?: ChangePasswordInput;
    } = {} as any
  ): Observable<any> {
    let url = '/api/identity/my-profile/change-password';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class RoleProxyService {
  constructor(private http: HttpClient) { }

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
  constructor(private http: HttpClient) { }

  /**
   *
   */
  getList(): Observable<ShopDtoListResultDto> {
    let url = '/api/app/shop/getList';
    let options: any = {
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<ShopDtoListResultDto>;
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
      body?: CreateShopDto;
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
      body?: UpdateShopDto;
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
export class TenantProxyService {
  constructor(private http: HttpClient) { }

  /**
   *
   */
  tenants(
    params: {
      /**  */
      id: string;
    } = {} as any
  ): Observable<TenantDto> {
    let url = '/api/multi-tenancy/tenants/';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<TenantDto>;
  }
  /**
   *
   */
  tenants1(
    params: {
      /**  */
      id: string;
      /** requestBody */
      body?: TenantUpdateDto;
    } = {} as any
  ): Observable<TenantDto> {
    let url = '/api/multi-tenancy/tenants/';
    let options: any = {
      params: { id: params.id },
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<TenantDto>;
  }
  /**
   *
   */
  tenants2(
    params: {
      /**  */
      id: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/multi-tenancy/tenants/';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  tenants3(
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
  ): Observable<TenantDtoPagedResultDto> {
    let url = '/api/multi-tenancy/tenants';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<TenantDtoPagedResultDto>;
  }
  /**
   *
   */
  tenants4(
    params: {
      /** requestBody */
      body?: TenantCreateDto;
    } = {} as any
  ): Observable<TenantDto> {
    let url = '/api/multi-tenancy/tenants';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<TenantDto>;
  }
  /**
   *
   */
  defaultConnectionString(
    params: {
      /**  */
      id: string;
    } = {} as any
  ): Observable<string> {
    let url = '/api/multi-tenancy/tenants//default-connection-string';
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
  defaultConnectionString1(
    params: {
      /**  */
      id: string;
      /**  */
      defaultConnectionString?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/multi-tenancy/tenants//default-connection-string';
    let options: any = {
      params: { id: params.id },
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  defaultConnectionString2(
    params: {
      /**  */
      id: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/multi-tenancy/tenants//default-connection-string';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class UserProxyService {
  constructor(private http: HttpClient) { }

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
export class UserLookupProxyService {
  constructor(private http: HttpClient) { }

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
  constructor(private http: HttpClient) { }

  /**
   *
   */
  getList(): Observable<VisitorLogDtoListResultDto> {
    let url = '/api/app/visitorLog/getList';
    let options: any = {
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<VisitorLogDtoListResultDto>;
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
    let url = '/api/app/visitorLog/get';
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
  create(
    params: {
      /** requestBody */
      body?: CreateVisitorLogDto;
    } = {} as any
  ): Observable<VisitorLogDto> {
    let url = '/api/app/visitorLog/create';
    let options: any = {
      body: params.body,
      method: 'post'
    };
    return (this.http.request('post', url, options) as any) as Observable<VisitorLogDto>;
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
    let url = '/api/app/visitorLog/delete';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class WeixinProxyService {
  constructor(private http: HttpClient) { }

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
}

export interface ControllerInterfaceApiDescriptionModel {
  /**  */
  typeAsString?: string;
}

export interface MethodParameterApiDescriptionModel {
  /**  */
  name?: string;

  /**  */
  typeAsString?: string;

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
  typeAsString?: string;

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
  typeAsString?: string;
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
  typeAsString?: string;

  /**  */
  interfaces?: ControllerInterfaceApiDescriptionModel[];

  /**  */
  actions?: object;
}

export interface ModuleApiDescriptionModel {
  /**  */
  rootPath?: string;

  /**  */
  controllers?: object;
}

export interface ApplicationApiDescriptionModel {
  /**  */
  modules?: object;
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
  selections?: SelectionItem[];
}

export interface FormDto {
  /**  */
  title?: string;

  /**  */
  description?: string;

  /**  */
  theme?: FormTheme;

  /**  */
  formItems?: FormItemDto[];

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

export interface FormDtoListResultDto {
  /**  */
  items?: FormDto[];
}

export interface FormItemCreateOrEditDto {
  /**  */
  itemId?: string;

  /**  */
  fromId?: string;

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

export interface UserLoginInfo {
  /**  */
  userNameOrEmailAddress?: string;

  /**  */
  password?: string;

  /**  */
  rememberMe?: boolean;

  /**  */
  tenanId?: string;
}

export interface AbpLoginResult {
  /**  */
  result?: LoginResultType;

  /**  */
  description?: string;
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

export interface ProductCategoryDto {
  /**  */
  name?: string;

  /**  */
  code?: string;

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

export interface ProductCategoryDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: ProductCategoryDto[];
}

export interface CreateUpdateCategoryDto {
  /**  */
  name?: string;

  /**  */
  code?: string;
}

export interface ProductSpuDto {
  /**  */
  name?: string;

  /**  */
  code?: string;

  /**  */
  desc?: string;

  /**  */
  category?: ProductCategoryDto;

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

export interface ProductSkuDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: ProductSkuDto[];
}

export interface CreateUpdateSkuDto {
  /**  */
  spuId?: string;

  /**  */
  name?: string;

  /**  */
  code?: string;

  /**  */
  price?: number;
}

export interface ProductSpuDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: ProductSpuDto[];
}

export interface CreateUpdateSpuDto {
  /**  */
  categoryId?: string;

  /**  */
  name?: string;

  /**  */
  code?: string;

  /**  */
  desc?: string;
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
}

export interface ChangePasswordInput {
  /**  */
  currentPassword?: string;

  /**  */
  newPassword?: string;
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

export interface ShopDtoListResultDto {
  /**  */
  items?: ShopDto[];
}

export interface CreateShopDto {
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

export interface UpdateShopDto {
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

export interface TenantDto {
  /**  */
  name?: string;

  /**  */
  id?: string;
}

export interface TenantUpdateDto {
  /**  */
  name?: string;
}

export interface TenantDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: TenantDto[];
}

export interface TenantCreateDto {
  /**  */
  name?: string;
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
}

export interface IdentityRoleDtoListResultDto {
  /**  */
  items?: IdentityRoleDto[];
}

export interface IdentityUserUpdateRolesDto {
  /**  */
  roleNames?: string[];
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
  formId?: string;

  /**  */
  formJson?: string;

  /**  */
  credentialId?: string;

  /**  */
  credential?: CredentialDto;
}

export interface VisitorLogDtoListResultDto {
  /**  */
  items?: VisitorLogDto[];
}

export interface CreateVisitorLogDto { }

export interface WeChatMiniProgramAuthenticateModel {
  /**  */
  code?: string;

  /**  */
  encryptedData?: string;

  /**  */
  iv?: string;

  /**  */
  session_key?: string;
}

export interface Version {
  /**  */
  major?: number;

  /**  */
  minor?: number;

  /**  */
  build?: number;

  /**  */
  revision?: number;

  /**  */
  majorRevision?: number;

  /**  */
  minorRevision?: number;
}

export interface StringStringIEnumerableKeyValuePair {
  /**  */
  key?: string;

  /**  */
  value?: string[];
}

export interface HttpContent {
  /**  */
  headers?: StringStringIEnumerableKeyValuePair[];
}

export interface HttpMethod {
  /**  */
  method?: string;
}

export interface HttpRequestMessage {
  /**  */
  version?: Version;

  /**  */
  content?: HttpContent;

  /**  */
  method?: HttpMethod;

  /**  */
  requestUri?: string;

  /**  */
  headers?: StringStringIEnumerableKeyValuePair[];

  /**  */
  properties?: object;
}

export interface HttpResponseMessage {
  /**  */
  version?: Version;

  /**  */
  content?: HttpContent;

  /**  */
  statusCode?: HttpStatusCode;

  /**  */
  reasonPhrase?: string;

  /**  */
  headers?: StringStringIEnumerableKeyValuePair[];

  /**  */
  trailingHeaders?: StringStringIEnumerableKeyValuePair[];

  /**  */
  requestMessage?: HttpRequestMessage;

  /**  */
  isSuccessStatusCode?: boolean;
}

export interface IntPtr { }

export interface RuntimeMethodHandle {
  /**  */
  value?: IntPtr;
}

export interface ModuleHandle {
  /**  */
  mdStreamVersion?: number;
}

export interface CustomAttributeTypedArgument {
  /**  */
  argumentType?: Type;

  /**  */
  value?: object;
}

export interface MemberInfo {
  /**  */
  memberType?: MemberTypes;

  /**  */
  declaringType?: Type;

  /**  */
  reflectedType?: Type;

  /**  */
  name?: string;

  /**  */
  module?: Module;

  /**  */
  customAttributes?: CustomAttributeData[];

  /**  */
  isCollectible?: boolean;

  /**  */
  metadataToken?: number;
}

export interface CustomAttributeNamedArgument {
  /**  */
  memberInfo?: MemberInfo;

  /**  */
  typedValue?: CustomAttributeTypedArgument;

  /**  */
  memberName?: string;

  /**  */
  isField?: boolean;
}

export interface CustomAttributeData {
  /**  */
  attributeType?: Type;

  /**  */
  constructor?: ConstructorInfo;

  /**  */
  constructorArguments?: CustomAttributeTypedArgument[];

  /**  */
  namedArguments?: CustomAttributeNamedArgument[];
}

export interface Module {
  /**  */
  assembly?: Assembly;

  /**  */
  fullyQualifiedName?: string;

  /**  */
  name?: string;

  /**  */
  mdStreamVersion?: number;

  /**  */
  moduleVersionId?: string;

  /**  */
  scopeName?: string;

  /**  */
  moduleHandle?: ModuleHandle;

  /**  */
  customAttributes?: CustomAttributeData[];

  /**  */
  metadataToken?: number;
}

export interface ConstructorInfo {
  /**  */
  memberType?: MemberTypes;

  /**  */
  attributes?: MethodAttributes;

  /**  */
  methodImplementationFlags?: MethodImplAttributes;

  /**  */
  callingConvention?: CallingConventions;

  /**  */
  isAbstract?: boolean;

  /**  */
  isConstructor?: boolean;

  /**  */
  isFinal?: boolean;

  /**  */
  isHideBySig?: boolean;

  /**  */
  isSpecialName?: boolean;

  /**  */
  isStatic?: boolean;

  /**  */
  isVirtual?: boolean;

  /**  */
  isAssembly?: boolean;

  /**  */
  isFamily?: boolean;

  /**  */
  isFamilyAndAssembly?: boolean;

  /**  */
  isFamilyOrAssembly?: boolean;

  /**  */
  isPrivate?: boolean;

  /**  */
  isPublic?: boolean;

  /**  */
  isConstructedGenericMethod?: boolean;

  /**  */
  isGenericMethod?: boolean;

  /**  */
  isGenericMethodDefinition?: boolean;

  /**  */
  containsGenericParameters?: boolean;

  /**  */
  methodHandle?: RuntimeMethodHandle;

  /**  */
  isSecurityCritical?: boolean;

  /**  */
  isSecuritySafeCritical?: boolean;

  /**  */
  isSecurityTransparent?: boolean;

  /**  */
  name?: string;

  /**  */
  declaringType?: Type;

  /**  */
  reflectedType?: Type;

  /**  */
  module?: Module;

  /**  */
  customAttributes?: CustomAttributeData[];

  /**  */
  isCollectible?: boolean;

  /**  */
  metadataToken?: number;
}

export interface ParameterInfo {
  /**  */
  attributes?: ParameterAttributes;

  /**  */
  member?: MemberInfo;

  /**  */
  name?: string;

  /**  */
  parameterType?: Type;

  /**  */
  position?: number;

  /**  */
  isIn?: boolean;

  /**  */
  isLcid?: boolean;

  /**  */
  isOptional?: boolean;

  /**  */
  isOut?: boolean;

  /**  */
  isRetval?: boolean;

  /**  */
  defaultValue?: object;

  /**  */
  rawDefaultValue?: object;

  /**  */
  hasDefaultValue?: boolean;

  /**  */
  customAttributes?: CustomAttributeData[];

  /**  */
  metadataToken?: number;
}

export interface ICustomAttributeProvider { }

export interface MethodInfo {
  /**  */
  memberType?: MemberTypes;

  /**  */
  returnParameter?: ParameterInfo;

  /**  */
  returnType?: Type;

  /**  */
  returnTypeCustomAttributes?: ICustomAttributeProvider;

  /**  */
  attributes?: MethodAttributes;

  /**  */
  methodImplementationFlags?: MethodImplAttributes;

  /**  */
  callingConvention?: CallingConventions;

  /**  */
  isAbstract?: boolean;

  /**  */
  isConstructor?: boolean;

  /**  */
  isFinal?: boolean;

  /**  */
  isHideBySig?: boolean;

  /**  */
  isSpecialName?: boolean;

  /**  */
  isStatic?: boolean;

  /**  */
  isVirtual?: boolean;

  /**  */
  isAssembly?: boolean;

  /**  */
  isFamily?: boolean;

  /**  */
  isFamilyAndAssembly?: boolean;

  /**  */
  isFamilyOrAssembly?: boolean;

  /**  */
  isPrivate?: boolean;

  /**  */
  isPublic?: boolean;

  /**  */
  isConstructedGenericMethod?: boolean;

  /**  */
  isGenericMethod?: boolean;

  /**  */
  isGenericMethodDefinition?: boolean;

  /**  */
  containsGenericParameters?: boolean;

  /**  */
  methodHandle?: RuntimeMethodHandle;

  /**  */
  isSecurityCritical?: boolean;

  /**  */
  isSecuritySafeCritical?: boolean;

  /**  */
  isSecurityTransparent?: boolean;

  /**  */
  name?: string;

  /**  */
  declaringType?: Type;

  /**  */
  reflectedType?: Type;

  /**  */
  module?: Module;

  /**  */
  customAttributes?: CustomAttributeData[];

  /**  */
  isCollectible?: boolean;

  /**  */
  metadataToken?: number;
}

export interface EventInfo {
  /**  */
  memberType?: MemberTypes;

  /**  */
  attributes?: EventAttributes;

  /**  */
  isSpecialName?: boolean;

  /**  */
  addMethod?: MethodInfo;

  /**  */
  removeMethod?: MethodInfo;

  /**  */
  raiseMethod?: MethodInfo;

  /**  */
  isMulticast?: boolean;

  /**  */
  eventHandlerType?: Type;

  /**  */
  name?: string;

  /**  */
  declaringType?: Type;

  /**  */
  reflectedType?: Type;

  /**  */
  module?: Module;

  /**  */
  customAttributes?: CustomAttributeData[];

  /**  */
  isCollectible?: boolean;

  /**  */
  metadataToken?: number;
}

export interface RuntimeFieldHandle {
  /**  */
  value?: IntPtr;
}

export interface FieldInfo {
  /**  */
  memberType?: MemberTypes;

  /**  */
  attributes?: FieldAttributes;

  /**  */
  fieldType?: Type;

  /**  */
  isInitOnly?: boolean;

  /**  */
  isLiteral?: boolean;

  /**  */
  isNotSerialized?: boolean;

  /**  */
  isPinvokeImpl?: boolean;

  /**  */
  isSpecialName?: boolean;

  /**  */
  isStatic?: boolean;

  /**  */
  isAssembly?: boolean;

  /**  */
  isFamily?: boolean;

  /**  */
  isFamilyAndAssembly?: boolean;

  /**  */
  isFamilyOrAssembly?: boolean;

  /**  */
  isPrivate?: boolean;

  /**  */
  isPublic?: boolean;

  /**  */
  isSecurityCritical?: boolean;

  /**  */
  isSecuritySafeCritical?: boolean;

  /**  */
  isSecurityTransparent?: boolean;

  /**  */
  fieldHandle?: RuntimeFieldHandle;

  /**  */
  name?: string;

  /**  */
  declaringType?: Type;

  /**  */
  reflectedType?: Type;

  /**  */
  module?: Module;

  /**  */
  customAttributes?: CustomAttributeData[];

  /**  */
  isCollectible?: boolean;

  /**  */
  metadataToken?: number;
}

export interface PropertyInfo {
  /**  */
  memberType?: MemberTypes;

  /**  */
  propertyType?: Type;

  /**  */
  attributes?: PropertyAttributes;

  /**  */
  isSpecialName?: boolean;

  /**  */
  canRead?: boolean;

  /**  */
  canWrite?: boolean;

  /**  */
  getMethod?: MethodInfo;

  /**  */
  setMethod?: MethodInfo;

  /**  */
  name?: string;

  /**  */
  declaringType?: Type;

  /**  */
  reflectedType?: Type;

  /**  */
  module?: Module;

  /**  */
  customAttributes?: CustomAttributeData[];

  /**  */
  isCollectible?: boolean;

  /**  */
  metadataToken?: number;
}

export interface StructLayoutAttribute {
  /**  */
  value?: LayoutKind;

  /**  */
  typeId?: object;
}

export interface RuntimeTypeHandle {
  /**  */
  value?: IntPtr;
}

export interface TypeInfo {
  /**  */
  genericTypeParameters?: Type[];

  /**  */
  declaredConstructors?: ConstructorInfo[];

  /**  */
  declaredEvents?: EventInfo[];

  /**  */
  declaredFields?: FieldInfo[];

  /**  */
  declaredMembers?: MemberInfo[];

  /**  */
  declaredMethods?: MethodInfo[];

  /**  */
  declaredNestedTypes?: TypeInfo[];

  /**  */
  declaredProperties?: PropertyInfo[];

  /**  */
  implementedInterfaces?: Type[];

  /**  */
  isInterface?: boolean;

  /**  */
  memberType?: MemberTypes;

  /**  */
  namespace?: string;

  /**  */
  assemblyQualifiedName?: string;

  /**  */
  fullName?: string;

  /**  */
  assembly?: Assembly;

  /**  */
  module?: Module;

  /**  */
  isNested?: boolean;

  /**  */
  declaringType?: Type;

  /**  */
  declaringMethod?: MethodBase;

  /**  */
  reflectedType?: Type;

  /**  */
  underlyingSystemType?: Type;

  /**  */
  isTypeDefinition?: boolean;

  /**  */
  isArray?: boolean;

  /**  */
  isByRef?: boolean;

  /**  */
  isPointer?: boolean;

  /**  */
  isConstructedGenericType?: boolean;

  /**  */
  isGenericParameter?: boolean;

  /**  */
  isGenericTypeParameter?: boolean;

  /**  */
  isGenericMethodParameter?: boolean;

  /**  */
  isGenericType?: boolean;

  /**  */
  isGenericTypeDefinition?: boolean;

  /**  */
  isSZArray?: boolean;

  /**  */
  isVariableBoundArray?: boolean;

  /**  */
  isByRefLike?: boolean;

  /**  */
  hasElementType?: boolean;

  /**  */
  genericTypeArguments?: Type[];

  /**  */
  genericParameterPosition?: number;

  /**  */
  genericParameterAttributes?: GenericParameterAttributes;

  /**  */
  attributes?: TypeAttributes;

  /**  */
  isAbstract?: boolean;

  /**  */
  isImport?: boolean;

  /**  */
  isSealed?: boolean;

  /**  */
  isSpecialName?: boolean;

  /**  */
  isClass?: boolean;

  /**  */
  isNestedAssembly?: boolean;

  /**  */
  isNestedFamANDAssem?: boolean;

  /**  */
  isNestedFamily?: boolean;

  /**  */
  isNestedFamORAssem?: boolean;

  /**  */
  isNestedPrivate?: boolean;

  /**  */
  isNestedPublic?: boolean;

  /**  */
  isNotPublic?: boolean;

  /**  */
  isPublic?: boolean;

  /**  */
  isAutoLayout?: boolean;

  /**  */
  isExplicitLayout?: boolean;

  /**  */
  isLayoutSequential?: boolean;

  /**  */
  isAnsiClass?: boolean;

  /**  */
  isAutoClass?: boolean;

  /**  */
  isUnicodeClass?: boolean;

  /**  */
  isCOMObject?: boolean;

  /**  */
  isContextful?: boolean;

  /**  */
  isEnum?: boolean;

  /**  */
  isMarshalByRef?: boolean;

  /**  */
  isPrimitive?: boolean;

  /**  */
  isValueType?: boolean;

  /**  */
  isSignatureType?: boolean;

  /**  */
  isSecurityCritical?: boolean;

  /**  */
  isSecuritySafeCritical?: boolean;

  /**  */
  isSecurityTransparent?: boolean;

  /**  */
  structLayoutAttribute?: StructLayoutAttribute;

  /**  */
  typeInitializer?: ConstructorInfo;

  /**  */
  typeHandle?: RuntimeTypeHandle;

  /**  */
  guid?: string;

  /**  */
  baseType?: Type;

  /**  */
  isSerializable?: boolean;

  /**  */
  containsGenericParameters?: boolean;

  /**  */
  isVisible?: boolean;

  /**  */
  name?: string;

  /**  */
  customAttributes?: CustomAttributeData[];

  /**  */
  isCollectible?: boolean;

  /**  */
  metadataToken?: number;
}

export interface Assembly {
  /**  */
  definedTypes?: TypeInfo[];

  /**  */
  exportedTypes?: Type[];

  /**  */
  codeBase?: string;

  /**  */
  entryPoint?: MethodInfo;

  /**  */
  fullName?: string;

  /**  */
  imageRuntimeVersion?: string;

  /**  */
  isDynamic?: boolean;

  /**  */
  location?: string;

  /**  */
  reflectionOnly?: boolean;

  /**  */
  isCollectible?: boolean;

  /**  */
  isFullyTrusted?: boolean;

  /**  */
  customAttributes?: CustomAttributeData[];

  /**  */
  escapedCodeBase?: string;

  /**  */
  manifestModule?: Module;

  /**  */
  modules?: Module[];

  /**  */
  globalAssemblyCache?: boolean;

  /**  */
  hostContext?: number;

  /**  */
  securityRuleSet?: SecurityRuleSet;
}

export interface Type {
  /**  */
  isInterface?: boolean;

  /**  */
  memberType?: MemberTypes;

  /**  */
  namespace?: string;

  /**  */
  assemblyQualifiedName?: string;

  /**  */
  fullName?: string;

  /**  */
  assembly?: Assembly;

  /**  */
  module?: Module;

  /**  */
  isNested?: boolean;

  /**  */
  declaringType?: Type;

  /**  */
  declaringMethod?: MethodBase;

  /**  */
  reflectedType?: Type;

  /**  */
  underlyingSystemType?: Type;

  /**  */
  isTypeDefinition?: boolean;

  /**  */
  isArray?: boolean;

  /**  */
  isByRef?: boolean;

  /**  */
  isPointer?: boolean;

  /**  */
  isConstructedGenericType?: boolean;

  /**  */
  isGenericParameter?: boolean;

  /**  */
  isGenericTypeParameter?: boolean;

  /**  */
  isGenericMethodParameter?: boolean;

  /**  */
  isGenericType?: boolean;

  /**  */
  isGenericTypeDefinition?: boolean;

  /**  */
  isSZArray?: boolean;

  /**  */
  isVariableBoundArray?: boolean;

  /**  */
  isByRefLike?: boolean;

  /**  */
  hasElementType?: boolean;

  /**  */
  genericTypeArguments?: Type[];

  /**  */
  genericParameterPosition?: number;

  /**  */
  genericParameterAttributes?: GenericParameterAttributes;

  /**  */
  attributes?: TypeAttributes;

  /**  */
  isAbstract?: boolean;

  /**  */
  isImport?: boolean;

  /**  */
  isSealed?: boolean;

  /**  */
  isSpecialName?: boolean;

  /**  */
  isClass?: boolean;

  /**  */
  isNestedAssembly?: boolean;

  /**  */
  isNestedFamANDAssem?: boolean;

  /**  */
  isNestedFamily?: boolean;

  /**  */
  isNestedFamORAssem?: boolean;

  /**  */
  isNestedPrivate?: boolean;

  /**  */
  isNestedPublic?: boolean;

  /**  */
  isNotPublic?: boolean;

  /**  */
  isPublic?: boolean;

  /**  */
  isAutoLayout?: boolean;

  /**  */
  isExplicitLayout?: boolean;

  /**  */
  isLayoutSequential?: boolean;

  /**  */
  isAnsiClass?: boolean;

  /**  */
  isAutoClass?: boolean;

  /**  */
  isUnicodeClass?: boolean;

  /**  */
  isCOMObject?: boolean;

  /**  */
  isContextful?: boolean;

  /**  */
  isEnum?: boolean;

  /**  */
  isMarshalByRef?: boolean;

  /**  */
  isPrimitive?: boolean;

  /**  */
  isValueType?: boolean;

  /**  */
  isSignatureType?: boolean;

  /**  */
  isSecurityCritical?: boolean;

  /**  */
  isSecuritySafeCritical?: boolean;

  /**  */
  isSecurityTransparent?: boolean;

  /**  */
  structLayoutAttribute?: StructLayoutAttribute;

  /**  */
  typeInitializer?: ConstructorInfo;

  /**  */
  typeHandle?: RuntimeTypeHandle;

  /**  */
  guid?: string;

  /**  */
  baseType?: Type;

  /**  */
  isSerializable?: boolean;

  /**  */
  containsGenericParameters?: boolean;

  /**  */
  isVisible?: boolean;

  /**  */
  name?: string;

  /**  */
  customAttributes?: CustomAttributeData[];

  /**  */
  isCollectible?: boolean;

  /**  */
  metadataToken?: number;
}

export interface MethodBase {
  /**  */
  attributes?: MethodAttributes;

  /**  */
  methodImplementationFlags?: MethodImplAttributes;

  /**  */
  callingConvention?: CallingConventions;

  /**  */
  isAbstract?: boolean;

  /**  */
  isConstructor?: boolean;

  /**  */
  isFinal?: boolean;

  /**  */
  isHideBySig?: boolean;

  /**  */
  isSpecialName?: boolean;

  /**  */
  isStatic?: boolean;

  /**  */
  isVirtual?: boolean;

  /**  */
  isAssembly?: boolean;

  /**  */
  isFamily?: boolean;

  /**  */
  isFamilyAndAssembly?: boolean;

  /**  */
  isFamilyOrAssembly?: boolean;

  /**  */
  isPrivate?: boolean;

  /**  */
  isPublic?: boolean;

  /**  */
  isConstructedGenericMethod?: boolean;

  /**  */
  isGenericMethod?: boolean;

  /**  */
  isGenericMethodDefinition?: boolean;

  /**  */
  containsGenericParameters?: boolean;

  /**  */
  methodHandle?: RuntimeMethodHandle;

  /**  */
  isSecurityCritical?: boolean;

  /**  */
  isSecuritySafeCritical?: boolean;

  /**  */
  isSecurityTransparent?: boolean;

  /**  */
  memberType?: MemberTypes;

  /**  */
  name?: string;

  /**  */
  declaringType?: Type;

  /**  */
  reflectedType?: Type;

  /**  */
  module?: Module;

  /**  */
  customAttributes?: CustomAttributeData[];

  /**  */
  isCollectible?: boolean;

  /**  */
  metadataToken?: number;
}

export interface Exception {
  /**  */
  targetSite?: MethodBase;

  /**  */
  stackTrace?: string;

  /**  */
  message?: string;

  /**  */
  data?: object;

  /**  */
  innerException?: Exception;

  /**  */
  helpLink?: string;

  /**  */
  source?: string;

  /**  */
  hResult?: number;
}

export interface TokenResponse {
  /**  */
  accessToken?: string;

  /**  */
  identityToken?: string;

  /**  */
  tokenType?: string;

  /**  */
  refreshToken?: string;

  /**  */
  errorDescription?: string;

  /**  */
  expiresIn?: number;

  /**  */
  httpResponse?: HttpResponseMessage;

  /**  */
  raw?: string;

  /**  */
  json?: object;

  /**  */
  exception?: Exception;

  /**  */
  isError?: boolean;

  /**  */
  errorType?: ResponseErrorType;

  /**  */
  httpStatusCode?: HttpStatusCode;

  /**  */
  httpErrorReason?: string;

  /**  */
  error?: string;
}

export type FormTheme = 0 | 1 | 2;

export type FormItemType = 0 | 1;

export type LoginResultType = 1 | 2 | 3 | 4 | 5;

export type CredentialType = 0 | 1 | 2 | 2;

export type HttpStatusCode =
  | 100
  | 101
  | 102
  | 103
  | 200
  | 201
  | 202
  | 203
  | 204
  | 205
  | 206
  | 207
  | 208
  | 226
  | 300
  | 300
  | 301
  | 301
  | 302
  | 302
  | 303
  | 303
  | 304
  | 305
  | 306
  | 307
  | 307
  | 308
  | 400
  | 401
  | 402
  | 403
  | 404
  | 405
  | 406
  | 407
  | 408
  | 409
  | 410
  | 411
  | 412
  | 413
  | 414
  | 415
  | 416
  | 417
  | 421
  | 422
  | 423
  | 424
  | 426
  | 428
  | 429
  | 431
  | 451
  | 500
  | 501
  | 502
  | 503
  | 504
  | 505
  | 506
  | 507
  | 508
  | 510
  | 511;

export type MethodAttributes =
  | 0
  | 0
  | 1
  | 2
  | 3
  | 4
  | 5
  | 6
  | 7
  | 8
  | 16
  | 32
  | 64
  | 128
  | 256
  | 256
  | 512
  | 1024
  | 2048
  | 4096
  | 8192
  | 16384
  | 32768
  | 53248;

export type MethodImplAttributes = 0 | 0 | 1 | 2 | 3 | 3 | 4 | 4 | 8 | 16 | 32 | 64 | 128 | 256 | 512 | 4096 | 65535;

export type CallingConventions = 1 | 2 | 3 | 32 | 64;

export type MemberTypes = 1 | 2 | 4 | 8 | 16 | 32 | 64 | 128 | 191;

export type EventAttributes = 0 | 512 | 1024 | 1024;

export type ParameterAttributes = 0 | 1 | 2 | 4 | 8 | 16 | 4096 | 8192 | 16384 | 32768 | 61440;

export type FieldAttributes =
  | 0
  | 1
  | 2
  | 3
  | 4
  | 5
  | 6
  | 7
  | 16
  | 32
  | 64
  | 128
  | 256
  | 512
  | 1024
  | 4096
  | 8192
  | 32768
  | 38144;

export type PropertyAttributes = 0 | 512 | 1024 | 4096 | 8192 | 16384 | 32768 | 62464;

export type GenericParameterAttributes = 0 | 1 | 2 | 3 | 4 | 8 | 16 | 28;

export type TypeAttributes =
  | 0
  | 0
  | 0
  | 0
  | 1
  | 2
  | 3
  | 4
  | 5
  | 6
  | 7
  | 7
  | 8
  | 16
  | 24
  | 32
  | 32
  | 128
  | 256
  | 1024
  | 2048
  | 4096
  | 8192
  | 16384
  | 65536
  | 131072
  | 196608
  | 196608
  | 262144
  | 264192
  | 1048576
  | 12582912;

export type LayoutKind = 0 | 2 | 3;

export type SecurityRuleSet = 0 | 1 | 2;

export type ResponseErrorType = 0 | 1 | 2 | 3 | 4;
