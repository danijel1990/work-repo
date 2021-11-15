import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvoiceRootComponent } from './invoice-root.component';

describe('InvoiceRootComponent', () => {
  let component: InvoiceRootComponent;
  let fixture: ComponentFixture<InvoiceRootComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InvoiceRootComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InvoiceRootComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
