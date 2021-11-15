import { BaseModel } from './base.model';

export interface SupplierModel extends BaseModel {
  name: string;
  address: string;
  phoneNumber: string;
}
