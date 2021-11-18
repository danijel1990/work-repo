import { Component, OnInit } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { BaseModel } from '../models/base.model';

@Component({
  selector: 'app-create-update',
  templateUrl: './create-update.component.html',
  styleUrls: ['./create-update.component.css'],
})
export class CreateUpdateComponent<T extends BaseModel> implements OnInit {
  tableData: T[] = [];
  loading: boolean = false;
  emptyRow: T;

  constructor(private service: BaseService<T>) {}

  ngOnInit(): void {
    this.reloadData();
  }

  reloadData = (): void => {
    this.loading = true;
    this.service.getAll().subscribe({
      next: (data) => {
        this.tableData = data;
      },
      error: () => (this.loading = false),
      complete: () => (this.loading = false),
    });
  }

  handleSave = (record: T): void => {
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

  handleAdd = (record: T): void => {
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
}
