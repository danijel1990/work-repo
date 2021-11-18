import { Component, OnInit } from '@angular/core';
import { endOfMonth, isWithinInterval, startOfMonth } from 'date-fns';
import { InvoiceService } from 'src/app/core/services/invoice.service';
import { CreateUpdateComponent } from 'src/app/shared/create-update/create-update.component';
import { InvoiceModel } from 'src/app/shared/models/invoice.model';
import { TableColumn } from 'src/app/shared/models/table-column';

@Component({
  selector: 'app-invoice-root',
  templateUrl: './invoice-root.component.html',
  styleUrls: ['./invoice-root.component.css'],
})
export class InvoiceRootComponent implements OnInit {
  title: string = 'Invoices';
  columns: Array<TableColumn> = [
    {
      title: 'Description',
      dataIndex: 'description',
    },
    {
      title: 'Invoice date',
      dataIndex: 'invoiceDate',
      dataType: "date"
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
  loading: boolean = false;
  tableData: Array<InvoiceModel> = [];
  filteredData: Array<InvoiceModel> = [];
  modalVisible: boolean = false;
  selectedInvoice: InvoiceModel = null;
  showTable: boolean = true;
  selectedDate: Date = new Date();

  constructor(private service: InvoiceService) {
  }

  openModal = (record: InvoiceModel) => {
    this.selectedInvoice = record;
    this.modalVisible = true;
  };

  closeModal = () => {
    this.modalVisible = false;
  };

  saveData = (record: InvoiceModel) => {
    this.selectedInvoice = null;
    if (record.id) {
      this.handleSave(record);
    }
    else {
      this.handleAdd(record);
    }
  };

  filterData = () => {
    this.filteredData = [...this.tableData
      .filter(record => isWithinInterval(new Date(record.invoiceDate), {start: startOfMonth(this.selectedDate), end: endOfMonth(this.selectedDate)}))];
  }

  reloadData = (): void => {
    this.loading = true;
    this.service.getAll().subscribe({
      next: (data) => {
        this.tableData = data;
        this.filterData();
      },
      error: () => (this.loading = false),
      complete: () => (this.loading = false),
    });
  }

  handleSave = (record: InvoiceModel): void => {
    this.loading = true;

    this.service.update(record).subscribe({
      error: () => {
        this.reloadData();
        this.loading = false;
      },
      complete: () => {
        this.tableData = this.tableData.map((x) => {
          if (x.id === record.id) return record;
          else return x;
        });

        this.reloadData();
        this.loading = false;
      },
    });
  }

  handleAdd = (record: InvoiceModel): void => {
    this.loading = true;

    this.service.create(record).subscribe({
      next: () => {},
      error: () => {
        this.loading = false;
      },
      complete: () => {
        this.tableData.push(record);
        this.reloadData();
        this.loading = false;
      },
    });
  }

  ngOnInit(): void {
    this.reloadData();
  }
}
