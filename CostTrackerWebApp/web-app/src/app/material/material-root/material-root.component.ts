import { Component, OnInit } from '@angular/core';
import { MaterialService } from 'src/app/core/services/material.service';
import { CreateUpdateComponent } from 'src/app/shared/create-update/create-update.component';
import { MaterialModel } from 'src/app/shared/models/material.model';
import { TableColumn } from 'src/app/shared/models/table-column';

@Component({
  selector: 'app-material-root',
  templateUrl: './material-root.component.html',
  styleUrls: ['./material-root.component.css'],
})
export class MaterialRootComponent
  extends CreateUpdateComponent<MaterialModel>
  implements OnInit
{
  title: string = 'Materials';
  columns: Array<TableColumn> = [
    {
      title: 'Name',
      dataIndex: 'name',
      editable: true,
    },
    {
      title: 'Price',
      dataIndex: 'price',
      editable: true,
      dataType: 'number',
      min: 0,
    },
  ];
  emptyRow = {
    id: 0,
    name: '',
    price: 0,
  };

  constructor(materialService: MaterialService) {
    super(materialService);
  }

  ngOnInit(): void {
    super.ngOnInit();
  }
}
