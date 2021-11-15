import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditableTableComponent } from './editable-table/editable-table.component';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzFormModule } from 'ng-zorro-antd/form';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzInputNumberModule } from 'ng-zorro-antd/input-number';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzSpaceModule } from 'ng-zorro-antd/space';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzMessageModule } from 'ng-zorro-antd/message';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzSwitchModule } from 'ng-zorro-antd/switch';
import { NzPopconfirmModule } from 'ng-zorro-antd/popconfirm';

@NgModule({
  declarations: [EditableTableComponent],
  imports: [
    CommonModule,
    NzGridModule,
    NzSpaceModule,
    NzInputModule,
    NzInputNumberModule,
    NzFormModule,
    NzSelectModule,
    FormsModule,
    ReactiveFormsModule,
    NzModalModule,
    NzIconModule,
    NzDatePickerModule,
    NzDividerModule,
    NzButtonModule,
    NzToolTipModule,
    NzMessageModule,
    NzTableModule,
    NzSpaceModule,
    NzDropDownModule,
    NzSwitchModule,
    NzPopconfirmModule,
  ],
  exports: [
    CommonModule,
    NzGridModule,
    NzSpaceModule,
    NzInputModule,
    NzInputNumberModule,
    NzFormModule,
    NzSelectModule,
    FormsModule,
    ReactiveFormsModule,
    NzModalModule,
    NzIconModule,
    NzDatePickerModule,
    NzDividerModule,
    NzButtonModule,
    NzToolTipModule,
    NzMessageModule,
    EditableTableComponent,
  ],
})
export class SharedModule {}
