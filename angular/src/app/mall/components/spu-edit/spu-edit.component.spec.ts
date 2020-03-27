import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpuEditComponent } from './spu-edit.component';

describe('SpuEditComponent', () => {
  let component: SpuEditComponent;
  let fixture: ComponentFixture<SpuEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpuEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpuEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
