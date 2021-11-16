import { Component, OnInit } from '@angular/core';
import { InvoiceService } from 'src/app/core/services/invoice.service';
import { CreateUpdateComponent } from 'src/app/shared/create-update/create-update.component';
import { CustomOption } from 'src/app/shared/models/custom-option';
import { InvoiceModel } from 'src/app/shared/models/invoice.model';
import { TableColumn } from 'src/app/shared/models/table-column';

@Component({
  selector: 'app-invoice-root',
  templateUrl: './invoice-root.component.html',
  styleUrls: ['./invoice-root.component.css'],
})
export class InvoiceRootComponent
  extends CreateUpdateComponent<InvoiceModel>
  implements OnInit
{
  title: string = 'Invoices';
  columns: Array<TableColumn> = [
    {
      title: 'Description',
      dataIndex: 'description',
    },
    {
      title: 'Invoice date',
      dataIndex: 'invoiceDate',
    },
    {
      title: 'Supplier',
      dataIndex: 'supplierName',
    },
    {
      title: 'Total price',
      dataIndex: 'totalPrice',
    },
  ];
  modalVisible: boolean = false;
  selectedInvoice: InvoiceModel = null;
  showTable: boolean = true;

  constructor(invoiceService: InvoiceService) {
    super(invoiceService);
  }

  ngOnInit(): void {
    super.ngOnInit();
  }

  openModal = (record: InvoiceModel) => {
    this.selectedInvoice = record;
    this.modalVisible = true;
  };

  closeModal = () => {
    this.modalVisible = false;
  };

  saveData = (record: InvoiceModel) => {};
}
