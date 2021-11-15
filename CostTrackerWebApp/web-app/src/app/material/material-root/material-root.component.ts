import { Component, OnInit } from '@angular/core';
import { TableColumn } from 'src/app/shared/models/table-column';

@Component({
  selector: 'app-material-root',
  templateUrl: './material-root.component.html',
  styleUrls: ['./material-root.component.css'],
})
export class MaterialRootComponent implements OnInit {
  title: string = 'Materials';
  columns: Array<TableColumn> = [
    {
      title: 'Name',
      dataIndex: 'name',
    },
  ];
  loading: boolean = false;

  reloadData = () => {};

  constructor() {}

  ngOnInit(): void {}
}
