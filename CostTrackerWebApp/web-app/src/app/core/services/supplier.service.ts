import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SupplierModel } from 'src/app/shared/models/supplier.model';
import { BaseService } from './base.service';

@Injectable()
export class SupplierService extends BaseService<SupplierModel> {
  controllerName: string = 'Supplier';

  constructor(private client: HttpClient) {
    super(client);
  }
}
