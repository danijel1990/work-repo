import {
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  SimpleChanges,
} from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { InvoiceModel } from 'src/app/shared/models/invoice.model';
import { MaterialModel } from 'src/app/shared/models/material.model';
import { SupplierModel } from 'src/app/shared/models/supplier.model';

@Component({
  selector: 'app-create-update-modal',
  templateUrl: './create-update-modal.component.html',
  styleUrls: ['./create-update-modal.component.css'],
})
export class CreateUpdateModalComponent implements OnInit {
  @Input() visible: boolean;
  @Input() handleSave: (record: InvoiceModel) => void;
  @Input() handleClose: () => void;
  @Input() invoice: InvoiceModel;
  form: FormGroup;
  supplierOptions: Array<SupplierModel> = [];
  materialOptions: Array<MaterialModel> = [];

  get materials() {
    return this.form.controls['materials'] as FormArray;
  }

  handleOk(): void {
    this.handleSave(this.invoice);
    this.handleClose();
  }

  handleCancel(): void {
    this.form.reset();
    this.handleClose();
  }

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      description: ['', Validators.required],
      invoiceDate: ['', Validators.required],
      supplierId: ['', Validators.required],
      totalPrice: ['', Validators.required],
      materials: this.fb.array([]),
    });
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes?.visible?.currentValue === true) {
      this.form.patchValue(this.invoice);
    }
  }
}
