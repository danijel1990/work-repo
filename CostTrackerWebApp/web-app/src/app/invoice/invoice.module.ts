import { NgModule } from '@angular/core';
import { InvoiceRootComponent } from './invoice-root/invoice-root.component';
import { InvoiceRoutingModule } from './invoice-routing.module';
import { SharedModule } from '../shared/shared.module';
import { CreateUpdateModalComponent } from './create-update-modal/create-update-modal.component';
import { InvoiceChartComponent } from './invoice-chart/invoice-chart.component';
import { ChartsModule } from 'ng2-charts';

@NgModule({
  declarations: [
    InvoiceRootComponent,
    CreateUpdateModalComponent,
    InvoiceChartComponent,
  ],
  imports: [InvoiceRoutingModule, SharedModule, ChartsModule],
})
export class InvoiceModule {}
