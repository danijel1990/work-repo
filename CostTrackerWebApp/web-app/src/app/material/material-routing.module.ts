import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MaterialRootComponent } from './material-root/material-root.component';

const routes: Routes = [{ path: '', component: MaterialRootComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MaterialRoutingModule {
  static components = [MaterialRootComponent];
}
