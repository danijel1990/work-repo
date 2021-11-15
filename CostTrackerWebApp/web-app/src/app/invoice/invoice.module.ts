import { NgModule } from '@angular/core';
import { InvoiceRootComponent } from './invoice-root/invoice-root.component';
import { InvoiceRoutingModule } from './invoice-routing.module';
import { SharedModule } from '../shared/shared.module';
import { CreateUpdateModalComponent } from './create-update-modal/create-update-modal.component';

@NgModule({
  declarations: [InvoiceRootComponent, CreateUpdateModalComponent],
  imports: [InvoiceRoutingModule, SharedModule],
})
export class InvoiceModule {}
