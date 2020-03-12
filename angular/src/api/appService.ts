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
export class AbpApiDefinitionProxyService {
  constructor(private http: HttpClient) {}

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
  constructor(private http: HttpClient) {}

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
  constructor(private http: HttpClient) {}

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
  constructor(private http: HttpClient) {}

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
  constructor(private http: HttpClient) {}

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
export class AccountProxyService {
  constructor(private http: HttpClient) {}

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
export class FeaturesProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  get(
    params: {
      /**  */
      providerName?: string;
      /**  */
      providerKey?: string;
    } = {} as any
  ): Observable<FeatureListDto> {
    let url = '/api/abp/features/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<FeatureListDto>;
  }
  /**
   *
   */
  update(
    params: {
      /**  */
      providerName?: string;
      /**  */
      providerKey?: string;
      /** requestBody */
      body?: UpdateFeaturesDto;
    } = {} as any
  ): Observable<any> {
    let url = '/api/abp/features/update';
    let options: any = {
      params: params,
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class OssProxyService {
  constructor(private http: HttpClient) {}

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
export class PermissionsProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  get(
    params: {
      /**  */
      providerName?: string;
      /**  */
      providerKey?: string;
    } = {} as any
  ): Observable<GetPermissionListResultDto> {
    let url = '/api/abp/permissions/get';
    const _copy: any = { ...params };
    let options: any = {
      params: new HttpParams({ fromObject: _copy }),
      method: 'get'
    };
    return (this.http.request('get', url, options) as any) as Observable<GetPermissionListResultDto>;
  }
  /**
   *
   */
  update(
    params: {
      /**  */
      providerName?: string;
      /**  */
      providerKey?: string;
      /** requestBody */
      body?: UpdatePermissionsDto;
    } = {} as any
  ): Observable<any> {
    let url = '/api/abp/permissions/update';
    let options: any = {
      params: params,
      body: params.body,
      method: 'put'
    };
    return (this.http.request('put', url, options) as any) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class ProductCategoryProxyService {
  constructor(private http: HttpClient) {}

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
      skipCount?: number;
      /**  */
      maxResultCount?: number;
      /**  */
      sorting?: string;
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
      skipCount?: number;
      /**  */
      maxResultCount?: number;
      /**  */
      sorting?: string;
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
      skipCount?: number;
      /**  */
      maxResultCount?: number;
      /**  */
      sorting?: string;
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
  constructor(private http: HttpClient) {}

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
  constructor(private http: HttpClient) {}

  /**
   *
   */
  roles(
    params: {
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
      /**  */
      sorting?: string;
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
  constructor(private http: HttpClient) {}

  /**
   *
   */
  tenants(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<TenantDto> {
    let url = '/api/multi-tenancy/tenants';
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
  tenants2(
    params: {
      /**  */
      id?: string;
      /** requestBody */
      body?: TenantUpdateDto;
    } = {} as any
  ): Observable<TenantDto> {
    let url = '/api/multi-tenancy/tenants';
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
  tenants3(
    params: {
      /**  */
      id?: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/multi-tenancy/tenants';
    let options: any = {
      params: { id: params.id },
      method: 'delete'
    };
    return (this.http.request('delete', url, options) as any) as Observable<any>;
  }
  /**
   *
   */
  tenants4(
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
  tenants5(
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
  tenants6(
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

export interface TenantCreateDto {
  /**  */
  name?: string;
}

export interface TenantUpdateDto {
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
