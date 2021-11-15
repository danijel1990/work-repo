import { NgModule } from '@angular/core';
import { SupplierRootComponent } from './supplier-root/supplier-root.component';
import { SupplierRoutingModule } from './supplier-routing.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [SupplierRootComponent],
  imports: [SupplierRoutingModule, SharedModule],
})
export class SupplierModule {}
