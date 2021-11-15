import { BaseModel } from './base.model';

export interface InvoiceMaterialModel extends BaseModel {
  name: string;
  quantity: number;
}
