import { NgModule } from '@angular/core';
import { MaterialRootComponent } from './material-root/material-root.component';
import { MaterialRoutingModule } from './material-routing.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [MaterialRootComponent],
  imports: [MaterialRoutingModule, SharedModule],
})
export class MaterialModule {}
