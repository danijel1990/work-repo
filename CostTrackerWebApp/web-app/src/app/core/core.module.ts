import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { InvoiceService } from './services/invoice.service';
import { MaterialService } from './services/material.service';
import { SupplierService } from './services/supplier.service';

@NgModule({
  declarations: [HomeComponent],
  imports: [CommonModule],
  providers: [InvoiceService, MaterialService, SupplierService],
})
export class CoreModule {}
