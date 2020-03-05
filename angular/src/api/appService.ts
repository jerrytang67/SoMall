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
    return this.http.request('get', url, options) as Observable<ApplicationApiDescriptionModel>;
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
    return this.http.request('get', url, options) as Observable<ApplicationConfigurationDto>;
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
    return this.http.request('get', url, options) as Observable<any>;
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
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<any>;
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
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<any>;
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
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<FindTenantResultDto>;
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
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<FindTenantResultDto>;
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
      body: params,
      method: 'post'
    };
    return this.http.request('post', url, options) as Observable<IdentityUserDto>;
  }
}

@Injectable({ providedIn: 'root' })
export class FeaturesProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  features(
    params: {
      /**  */
      providerName?: string;
      /**  */
      providerKey?: string;
    } = {} as any
  ): Observable<FeatureListDto> {
    let url = '/api/abp/features';
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<FeatureListDto>;
  }
  /**
   *
   */
  features1(
    params: {
      /**  */
      providerName?: string;
      /**  */
      providerKey?: string;
      /** requestBody */
      body?: UpdateFeaturesDto;
    } = {} as any
  ): Observable<any> {
    let url = '/api/abp/features';
    let options: any = {
      body: params,
      method: 'put'
    };
    return this.http.request('put', url, options) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class PermissionsProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  permissions(
    params: {
      /**  */
      providerName?: string;
      /**  */
      providerKey?: string;
    } = {} as any
  ): Observable<GetPermissionListResultDto> {
    let url = '/api/abp/permissions';
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<GetPermissionListResultDto>;
  }
  /**
   *
   */
  permissions1(
    params: {
      /**  */
      providerName?: string;
      /**  */
      providerKey?: string;
      /** requestBody */
      body?: UpdatePermissionsDto;
    } = {} as any
  ): Observable<any> {
    let url = '/api/abp/permissions';
    let options: any = {
      body: params,
      method: 'put'
    };
    return this.http.request('put', url, options) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class ProductCategoryProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  productCategory(
    params: {
      /**  */
      id: string;
    } = {} as any
  ): Observable<ProductCategoryDto> {
    let url = '/api/app/productCategory/';
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<ProductCategoryDto>;
  }
  /**
   *
   */
  productCategory1(
    params: {
      /**  */
      id: string;
      /** requestBody */
      body?: CreateUpdateCategoryDto;
    } = {} as any
  ): Observable<ProductCategoryDto> {
    let url = '/api/app/productCategory/';
    let options: any = {
      body: params,
      method: 'put'
    };
    return this.http.request('put', url, options) as Observable<ProductCategoryDto>;
  }
  /**
   *
   */
  productCategory2(
    params: {
      /**  */
      id: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/app/productCategory/';
    let options: any = {
      body: params,
      method: 'delete'
    };
    return this.http.request('delete', url, options) as Observable<any>;
  }
  /**
   *
   */
  productCategory3(
    params: {
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<ProductCategoryDtoPagedResultDto> {
    let url = '/api/app/productCategory';
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<ProductCategoryDtoPagedResultDto>;
  }
  /**
   *
   */
  productCategory4(
    params: {
      /** requestBody */
      body?: CreateUpdateCategoryDto;
    } = {} as any
  ): Observable<ProductCategoryDto> {
    let url = '/api/app/productCategory';
    let options: any = {
      body: params,
      method: 'post'
    };
    return this.http.request('post', url, options) as Observable<ProductCategoryDto>;
  }
}

@Injectable({ providedIn: 'root' })
export class ProductSkuProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  productSku(
    params: {
      /**  */
      id: string;
    } = {} as any
  ): Observable<ProductSkuDto> {
    let url = '/api/app/productSku/';
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<ProductSkuDto>;
  }
  /**
   *
   */
  productSku1(
    params: {
      /**  */
      id: string;
      /** requestBody */
      body?: CreateUpdateSkuDto;
    } = {} as any
  ): Observable<ProductSkuDto> {
    let url = '/api/app/productSku/';
    let options: any = {
      body: params,
      method: 'put'
    };
    return this.http.request('put', url, options) as Observable<ProductSkuDto>;
  }
  /**
   *
   */
  productSku2(
    params: {
      /**  */
      id: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/app/productSku/';
    let options: any = {
      body: params,
      method: 'delete'
    };
    return this.http.request('delete', url, options) as Observable<any>;
  }
  /**
   *
   */
  productSku3(
    params: {
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<ProductSkuDtoPagedResultDto> {
    let url = '/api/app/productSku';
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<ProductSkuDtoPagedResultDto>;
  }
  /**
   *
   */
  productSku4(
    params: {
      /** requestBody */
      body?: CreateUpdateSkuDto;
    } = {} as any
  ): Observable<ProductSkuDto> {
    let url = '/api/app/productSku';
    let options: any = {
      body: params,
      method: 'post'
    };
    return this.http.request('post', url, options) as Observable<ProductSkuDto>;
  }
}

@Injectable({ providedIn: 'root' })
export class ProductSpuProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  productSpu(
    params: {
      /**  */
      id: string;
    } = {} as any
  ): Observable<ProductSpuDto> {
    let url = '/api/app/productSpu/';
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<ProductSpuDto>;
  }
  /**
   *
   */
  productSpu1(
    params: {
      /**  */
      id: string;
      /** requestBody */
      body?: CreateUpdateSpuDto;
    } = {} as any
  ): Observable<ProductSpuDto> {
    let url = '/api/app/productSpu/';
    let options: any = {
      body: params,
      method: 'put'
    };
    return this.http.request('put', url, options) as Observable<ProductSpuDto>;
  }
  /**
   *
   */
  productSpu2(
    params: {
      /**  */
      id: string;
    } = {} as any
  ): Observable<any> {
    let url = '/api/app/productSpu/';
    let options: any = {
      body: params,
      method: 'delete'
    };
    return this.http.request('delete', url, options) as Observable<any>;
  }
  /**
   *
   */
  productSpu3(
    params: {
      /**  */
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<ProductSpuDtoPagedResultDto> {
    let url = '/api/app/productSpu';
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<ProductSpuDtoPagedResultDto>;
  }
  /**
   *
   */
  productSpu4(
    params: {
      /** requestBody */
      body?: CreateUpdateSpuDto;
    } = {} as any
  ): Observable<ProductSpuDto> {
    let url = '/api/app/productSpu';
    let options: any = {
      body: params,
      method: 'post'
    };
    return this.http.request('post', url, options) as Observable<ProductSpuDto>;
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
    return this.http.request('get', url, options) as Observable<ProfileDto>;
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
      body: params,
      method: 'put'
    };
    return this.http.request('put', url, options) as Observable<ProfileDto>;
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
      body: params,
      method: 'post'
    };
    return this.http.request('post', url, options) as Observable<any>;
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
      sorting?: string;
      /**  */
      skipCount?: number;
      /**  */
      maxResultCount?: number;
    } = {} as any
  ): Observable<IdentityRoleDtoPagedResultDto> {
    let url = '/api/identity/roles';
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<IdentityRoleDtoPagedResultDto>;
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
      body: params,
      method: 'post'
    };
    return this.http.request('post', url, options) as Observable<IdentityRoleDto>;
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
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<IdentityRoleDto>;
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
      body: params,
      method: 'put'
    };
    return this.http.request('put', url, options) as Observable<IdentityRoleDto>;
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
      body: params,
      method: 'delete'
    };
    return this.http.request('delete', url, options) as Observable<any>;
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
      id: string;
    } = {} as any
  ): Observable<TenantDto> {
    let url = '/api/multi-tenancy/tenants/';
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<TenantDto>;
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
      body: params,
      method: 'put'
    };
    return this.http.request('put', url, options) as Observable<TenantDto>;
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
      body: params,
      method: 'delete'
    };
    return this.http.request('delete', url, options) as Observable<any>;
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
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<TenantDtoPagedResultDto>;
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
      body: params,
      method: 'post'
    };
    return this.http.request('post', url, options) as Observable<TenantDto>;
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
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<string>;
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
      body: params,
      method: 'put'
    };
    return this.http.request('put', url, options) as Observable<any>;
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
      body: params,
      method: 'delete'
    };
    return this.http.request('delete', url, options) as Observable<any>;
  }
}

@Injectable({ providedIn: 'root' })
export class TestProxyService {
  constructor(private http: HttpClient) {}

  /**
   *
   */
  test(): Observable<TestModel[]> {
    let url = '/api/test';
    let options: any = {
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<TestModel[]>;
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
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<IdentityUserDto>;
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
      body: params,
      method: 'put'
    };
    return this.http.request('put', url, options) as Observable<IdentityUserDto>;
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
      body: params,
      method: 'delete'
    };
    return this.http.request('delete', url, options) as Observable<any>;
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
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<IdentityUserDtoPagedResultDto>;
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
      body: params,
      method: 'post'
    };
    return this.http.request('post', url, options) as Observable<IdentityUserDto>;
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
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<IdentityRoleDtoListResultDto>;
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
      body: params,
      method: 'put'
    };
    return this.http.request('put', url, options) as Observable<any>;
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
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<IdentityUserDto>;
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
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<IdentityUserDto>;
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
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<UserData>;
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
    let options: any = {
      params: new HttpParams({ fromObject: params }),
      method: 'get'
    };
    return this.http.request('get', url, options) as Observable<UserData>;
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

export interface CreateUpdateCategoryDto {
  /**  */
  name?: string;

  /**  */
  code?: string;
}

export interface ProductCategoryDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: ProductCategoryDto[];
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

export interface ProductSkuDtoPagedResultDto {
  /**  */
  totalCount?: number;

  /**  */
  items?: ProductSkuDto[];
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

export interface TestModel {
  /**  */
  name?: string;

  /**  */
  birthDate?: Date;
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
