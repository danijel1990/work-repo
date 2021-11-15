import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { InvoiceModel } from 'src/app/shared/models/invoice.model';
import { BaseService } from './base.service';

@Injectable()
export class InvoiceService extends BaseService<InvoiceModel> {
  controllerName: string = 'Invoice';

  constructor(private client: HttpClient) {
    super(client);
  }
}
