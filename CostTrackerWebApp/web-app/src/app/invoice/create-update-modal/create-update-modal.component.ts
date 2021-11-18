import {
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  SimpleChanges,
} from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MaterialService } from 'src/app/core/services/material.service';
import { SupplierService } from 'src/app/core/services/supplier.service';
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
  @Input() handleSave: (record: any) => void;
  @Input() handleClose: () => void;
  @Input() invoice: InvoiceModel;
  form: FormGroup;
  supplierOptions: Array<SupplierModel> = [];
  supplierLoading:boolean = false;
  materialOptions: Array<MaterialModel> = [];
  materialLoading: boolean = false;
  emptyMaterialForm  = () => this.fb.group({
    id: ['', Validators.required],
    quantity: ['', Validators.required],
  });

  get materials() {
    return this.form.controls['materials'] as FormArray;
  }

  addMaterial(): void {
    this.materials.push(this.emptyMaterialForm());
  }

  removeMaterial(index: number): void {
    this.materials.removeAt(index);
  }

  handleOk = (): void => {
     Object.values(this.form.controls).forEach(control => {
       control.markAsDirty({onlySelf: true});
       control.updateValueAndValidity({onlySelf: true});
     });
    if (this.form.valid) {
      const formValue = {
        ...this.form.value,
        supplierId: +this.form.value.supplierId,
        materials: this.form.value.materials.map(m => ({...m, id: +m.id}))
      };
      this.handleSave(formValue);
      this.handleCancel();
    }
  }

  handleCancel = (): void => {
    this.form.reset();
    this.handleClose();
  }

  updateTotalPrice = () => {
    const totalPrice = this.materials.value.map(m => (this.materialOptions.find(o => o.id == m.id)?.price || 0) * m.quantity).reduce((acc, value) => acc + value, 0)
    if(totalPrice){
      this.form.controls['totalPrice'].patchValue(totalPrice);
    }
  }

  validateMaterials(arr: FormArray) {
    return arr.length < 1 || arr.controls.some(c => !c.value.id || !c.value.quantity) ? {invalid: true} : null;
  }

  constructor(private fb: FormBuilder, private supplierService: SupplierService, private materialService: MaterialService) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      id: [''],
      description: ['', Validators.required],
      invoiceDate: ['', Validators.required],
      supplierId: ['', Validators.required],
      totalPrice: ['', Validators.required],
      materials: this.fb.array([this.emptyMaterialForm()], this.validateMaterials),
    });

    this.supplierService.getAll().subscribe({
      next: (data) => {
        this.supplierOptions = data;
      },
      error: () => (this.supplierLoading = false),
      complete: () => (this.supplierLoading = false),
    });

    this.materialService.getAll().subscribe({
      next: (data) => {
        this.materialOptions = data;
      },
      error: () => (this.materialLoading = false),
      complete: () => (this.materialLoading = false),
    });
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes?.visible?.currentValue === true && this.invoice) {
      const formValue = {
        ...this.invoice,
        supplierId: this.invoice.supplierId.toString(),
        materials: this.invoice.materials.map(m => ({...m, id: m.id.toString()}))
      };
      this.form.patchValue(formValue);
    }
  }
}
