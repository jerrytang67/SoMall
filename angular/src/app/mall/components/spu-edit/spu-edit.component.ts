import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SpuCreateOrUpdateDto, ProductSpuProxyService, SkuCreateOrUpdateDto } from 'src/api/appService';
import { FormArray, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NzUploadFile } from 'ng-zorro-antd/upload';
import { NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { TranslatorService } from '@core/translator/translator.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-spu-edit',
  styleUrls: ["spu-edit.component.scss"],
  templateUrl: './spu-edit.component.html'
})
export class SpuEditComponent implements OnInit {

  spuId: string;
  categoryId: string;
  title: string;
  public skus: FormArray;
  public validateForm: FormGroup;

  form: SpuCreateOrUpdateDto = {
    name: "",
    code: "",
    shopId: "",
    categoryId: "",
    purchaseNotesCommon: "",
    descCommon: "",
    skus: []
  };


  constructor(
    private api: ProductSpuProxyService,
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private message: NzMessageService,
    private translate: TranslateService
  ) { }

  guid = '00000000-0000-0000-0000-000000000000';
  optionList: any[];
  shopList: any[];
  apps: any[] = [];

  ngOnInit(): void {


    this.validateForm = this.fb.group({
      shopId: null,
      categoryId: null,
      name: [null, [Validators.required, Validators.minLength(2), Validators.maxLength(64)]],
      code: [null, [Validators.required, Validators.minLength(5), Validators.maxLength(32)]],
      purchaseNotesCommon: "",
      descCommon: "",
      skus: this.fb.array([])
    });
    this.route.paramMap.subscribe((params: any) => {
      console.log(params)
      this.title = params.params.id ? "编辑产品" : "添加产品"
      this.spuId = params.params.id || this.guid;

      this.api.getForEdit({ id: this.spuId }).subscribe(
        res => {
          this.form = res.data;
          this.optionList = res.schema.categoryId;
          this.shopList = res.schema.shopId;
          this.form.skus.forEach(item => {
            this.skus = this.validateForm.get('skus') as FormArray;
            this.skus.push(this.createItem(item));
          })
          this.validateForm.setValue({
            shopId: this.form.shopId,
            categoryId: this.form.categoryId,
            name: this.form.name,
            code: this.form.code,
            purchaseNotesCommon: this.form.purchaseNotesCommon,
            descCommon: this.form.descCommon,
            skus: this.form.skus
          })

          this.apps = res.schema.apps.map(p => {
            return {
              label: this.translate.instant(p.value),
              value: p.value,
              checked: res.data.appProductSpus.filter(x => x.appName === p.value).length > 0
            }
          })
        }
      )
    });
  }

  createItem(item: SkuCreateOrUpdateDto = {}): FormGroup {
    return this.fb.group({
      "id": item.id,
      "coverImageUrls": [],
      "spuId": item.spuId,
      "price": [item.price, [Validators.required, Validators.min(0)]],
      "vipPrice": item.vipPrice,
      "originPrice": item.originPrice,
      "unit": [item.unit, [Validators.maxLength(32)]],
      "name": [item.name, [Validators.required, Validators.minLength(2), Validators.maxLength(64)]],
      "code": [item.code, [Validators.maxLength(32)]],
      "desc": item.desc,
      "purchaseNotes": item.purchaseNotes,
      "dateTimeStart": item.dateTimeStart,
      "dateTimeEnd": item.dateTimeEnd,
      "soldCount": [item.soldCount, [Validators.required, Validators.min(0)]],
      "stockCount": item.stockCount,
      "limitBuyCount": item.limitBuyCount,
      "commissionEnable": item.commissionEnable,
      "commissionPrice": item.commissionPrice
    });
  }

  onSubmit() {
    console.log(this.validateForm.value)
    console.log(this.spuId)
    if (this.validateForm.valid) {
      if (this.spuId !== this.guid)
        this.api.update({
          id: this.spuId,
          body: Object.assign({}, this.validateForm.value, { apps: this.apps })
        }).subscribe(res => {
          if (res.id) { this.router.navigate(['/mall/spus']) }
        })
      else
        this.api.create({
          body: this.validateForm.value
        }).subscribe(res => {
          if (res.id) { this.router.navigate(['/mall/spus']) }
        })
    }
    else {
      this.message.error("请检查表单")
    }
  }
  addSku() {
    this.skus = this.validateForm.get('skus') as FormArray;
    this.skus.push(this.createItem());
  }

  deleteSku(index) {

    this.skus = this.validateForm.get('skus') as FormArray;
    if (this.skus.length > 1) {
      this.skus.removeAt(index);
    }
    else {
      this.message.warning("至少要保留一个商品信息")
    }
  }

  updateSingleChecked(event) {
    console.log(event)
  }



}