import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SupplierRootComponent } from './supplier-root/supplier-root.component';

const routes: Routes = [{ path: '', component: SupplierRootComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SupplierRoutingModule {
  static components = [SupplierRootComponent];
}
