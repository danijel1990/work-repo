import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'invoices',
    loadChildren: () =>
      import('./invoice/invoice.module').then((x) => x.InvoiceModule),
  },
  {
    path: 'materials',
    loadChildren: () =>
      import('./material/material.module').then((x) => x.MaterialModule),
  },
  {
    path: 'suppliers',
    loadChildren: () =>
      import('./supplier/supplier.module').then((x) => x.SupplierModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
