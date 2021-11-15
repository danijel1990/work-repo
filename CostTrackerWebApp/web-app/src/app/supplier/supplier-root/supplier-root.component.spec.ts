import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SupplierRootComponent } from './supplier-root.component';

describe('SupplierRootComponent', () => {
  let component: SupplierRootComponent;
  let fixture: ComponentFixture<SupplierRootComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SupplierRootComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SupplierRootComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
