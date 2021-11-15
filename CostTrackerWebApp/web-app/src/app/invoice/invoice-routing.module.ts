import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InvoiceRootComponent } from './invoice-root/invoice-root.component';

const routes: Routes = [{ path: '', component: InvoiceRootComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class InvoiceRoutingModule {
  static components = [InvoiceRootComponent];
}
