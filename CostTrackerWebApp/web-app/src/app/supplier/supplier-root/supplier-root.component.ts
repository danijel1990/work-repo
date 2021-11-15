import { Component, OnInit } from '@angular/core';
import { SupplierService } from 'src/app/core/services/supplier.service';
import { CreateUpdateComponent } from 'src/app/shared/create-update/create-update.component';
import { SupplierModel } from 'src/app/shared/models/supplier.model';
import { TableColumn } from 'src/app/shared/models/table-column';

@Component({
  selector: 'app-supplier-root',
  templateUrl: './supplier-root.component.html',
  styleUrls: ['./supplier-root.component.css'],
})
export class SupplierRootComponent
  extends CreateUpdateComponent<SupplierModel>
  implements OnInit
{
  title: string = 'Suppliers';
  columns: Array<TableColumn> = [
    {
      title: 'Name',
      dataIndex: 'name',
      editable: true,
    },
    {
      title: 'Address',
      dataIndex: 'address',
      editable: true,
    },
    {
      title: 'Phone number',
      dataIndex: 'phoneNumber',
      editable: true,
    },
  ];
  emptyRow = {
    id: 0,
    name: '',
    address: '',
    phoneNumber: '',
  };

  constructor(supplierService: SupplierService) {
    super(supplierService);
  }

  ngOnInit(): void {
    super.ngOnInit();
  }
}
