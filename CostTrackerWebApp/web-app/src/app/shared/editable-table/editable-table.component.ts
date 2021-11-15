import {
  AfterViewChecked,
  Component,
  ElementRef,
  Input,
  OnChanges,
  OnInit,
  TemplateRef,
  ViewChild,
  EventEmitter,
  Output,
} from '@angular/core';
import * as _ from 'lodash';
import { NzMessageService } from 'ng-zorro-antd/message';
import { TableColumn } from '../models/table-column';

@Component({
  selector: 'editable-table',
  templateUrl: './editable-table.component.html',
  styleUrls: ['./editable-table.component.css'],
})
export class EditableTableComponent
  implements OnInit, OnChanges, AfterViewChecked
{
  @Input() data: any[] = [];
  @Input() columns: TableColumn[] = [];
  @Input() title: string = '';
  @Input() editable: boolean = true;
  @Input() addOption: boolean = true;
  @Input() deleteOption: boolean = true;
  @Input() emptyRow: any;
  @Input() reloadData: any;
  @Input() loading: boolean = false;
  @Input() validate: Function;
  @Input() addData: Function;
  @Input() saveData: Function;
  @Input() deleteData: (id: any) => void;

  @Output() onEditRow = new EventEmitter<boolean>();
  @ViewChild('editableRow') editableRow: ElementRef;
  _ = _;
  scrolled: boolean = false;
  shouldScroll: boolean = false;

  searchValues = this.columns.map((col) => '');
  visible = this.columns.map((col) => false);
  listOfDisplayData = [...this.data];
  editCache: { id: string; edit: boolean; data: any } = {
    id: '0',
    edit: false,
    data: null,
  };
  nextPage: number = 0;
  pageIndex: number = 1;
  pageSize: number = 10;

  addRow(): void {
    var newPageIndex = (this.data.length + 1) / this.pageSize;
    if (newPageIndex % 1 != 0) {
      this.pageIndex = Math.floor(newPageIndex) + 1;
    } else {
      this.pageIndex = newPageIndex;
    }
    var tmpRow = Object.assign({}, JSON.parse(JSON.stringify(this.emptyRow)));
    this.editCache.edit = true;
    this.editCache.data = tmpRow;
    this.onEditRow.emit(true);
    this.setData([...this.data, tmpRow]);
    this.shouldScroll = true;
  }

  cancelEdit(id: string): void {
    this.editCache = {
      id: '0',
      data: null,
      edit: false,
    };

    this.onEditRow.emit(false);

    if (id == '0') {
      this.data.splice(
        this.data.findIndex((record) => record.id === '0'),
        1
      );
      this.setData(this.data);
    }
    this.shouldScroll = false;

    if (this.nextPage !== 0) {
      this.pageIndex = this.nextPage;
      this.nextPage = 0;
    }
  }

  getListOfFilter(column: TableColumn) {
    var result: any = [];
    this.data.forEach((record) => {
      if (
        result.find((rec: any) => rec.value === record[column.dataIndex]) ==
        undefined
      ) {
        result.push({
          text: record[column.dataIndex],
          value: record[column.dataIndex],
        });
      }
    });

    if (column.filterSortFn) {
      result.sort(column.filterSortFn);
    } else {
      result.sort((a: any, b: any) => a.value - b.value);
    }
    return result;
  }

  reset(): void {
    //reset filter value
    this.searchValues[this.visible.indexOf(true)] = '';
    //hide filter
    this.visible = this.searchValues.map((val) => false);
    this.search();
  }

  saveEdit(id: string): void {
    var message = this.validate(this.editCache.data);
    if (message !== '') {
      this.message.create('error', message);
      return;
    }
    if (id == '0') {
      this.addData(this.editCache.data);
      this.cancelEdit('0');
    } else {
      this.saveData(this.editCache.data);
      const index = this.data.findIndex((item) => item.id === id);
      Object.assign(this.data[index], this.editCache.data);
    }
    this.updateEditCache();
    this.shouldScroll = false;
  }

  search(): void {
    var filters: any[] = [];
    this.searchValues.forEach((value, index) => {
      if (value !== '') {
        filters.push({ value, index });
      }
    });

    this.listOfDisplayData = this.data.filter((item: any) => {
      for (let filter of filters) {
        if (
          item[this.columns[filter.index].dataIndex].indexOf(filter.value) ===
          -1
        ) {
          return false;
        }
      }
      return true;
    });
    //hide filter
    this.visible = this.searchValues.map((val) => false);
  }

  startEdit(id: string): void {
    this.editCache.id = id;
    this.editCache.edit = true;
    this.editCache.data = JSON.parse(
      JSON.stringify(this.data.find((record) => record.id == id))
    );

    this.onEditRow.emit(true);
  }

  setData(data: any) {
    this.data = [...data];
    this.listOfDisplayData = [...data];
    this.columns.forEach((col) => {
      if (col.filterType && col.filterType === 'select') {
        col.listOfFilter = this.getListOfFilter(col);
      }
    });
  }

  updateEditCache(): void {
    this.editCache = {
      id: '0',
      edit: false,
      data: null,
    };

    this.onEditRow.emit(false);
  }

  constructor(private message: NzMessageService) {}

  ngAfterViewChecked(): void {
    if (this.editableRow && this.shouldScroll && !this.scrolled) {
      this.editableRow.nativeElement.scrollIntoView();
      this.scrolled = false;
    }
  }

  ngOnInit(): void {
    this.updateEditCache();
  }

  ngOnChanges(changes: any): void {
    if (changes.data && changes.data.currentValue) {
      this.setData(changes.data.currentValue);
    }
  }
}
