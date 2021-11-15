import { BaseModel } from './base.model';
import { InvoiceMaterialModel } from './invoice-material.model';

export interface InvoiceModel extends BaseModel {
  description: string;
  invoiceDate: Date;
  supplierId: number;
  supplierName: string;
  totalPrice: number;
  materials: InvoiceMaterialModel;
}
