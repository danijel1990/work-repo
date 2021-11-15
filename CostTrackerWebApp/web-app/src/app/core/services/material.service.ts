import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MaterialModel } from 'src/app/shared/models/material.model';
import { BaseService } from './base.service';

@Injectable()
export class MaterialService extends BaseService<MaterialModel> {
  controllerName: string = 'Material';

  constructor(private client: HttpClient) {
    super(client);
  }
}
