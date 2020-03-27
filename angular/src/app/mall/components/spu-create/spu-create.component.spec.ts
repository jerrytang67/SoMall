import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpuCreateComponent } from './spu-create.component';

describe('SpuCreateComponent', () => {
  let component: SpuCreateComponent;
  let fixture: ComponentFixture<SpuCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpuCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpuCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
