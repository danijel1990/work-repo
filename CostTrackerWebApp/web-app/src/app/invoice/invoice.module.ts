import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InvoiceRootComponent } from './invoice-root/invoice-root.component';
import { InvoiceRoutingModule } from './invoice-routing.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [InvoiceRootComponent],
  imports: [InvoiceRoutingModule, SharedModule],
})
export class InvoiceModule {}
