import {
  NzTableFilterFn,
  NzTableFilterList,
  NzTableSortFn,
  NzTableSortOrder,
} from 'ng-zorro-antd/table';

export interface TableColumn {
  title: string;
  dataIndex: string;
  editable?: boolean;
  dataType?: string;
  width?: string;
  dateFormat?: string;
  options?: { label: string; value: any }[];
  onOptionChange?: (event: any[]) => void;
  loading?: boolean;
  min?: number;
  max?: number;
  filterType?: string;
  filterFn?: NzTableFilterFn;
  filterSortFn?: (a: any, b: any) => number;
  listOfFilter?: NzTableFilterList;
  filterMultiple?: boolean;
  sortOrder?: NzTableSortOrder;
  sortFn?: NzTableSortFn;
  sortPriority?: number | boolean;
  disabledDate?: (current: Date) => boolean;
}
