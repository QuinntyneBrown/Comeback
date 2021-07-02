import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingComponent } from './landing.component';
import { MatButtonModule } from '@angular/material/button';

const routes: Routes = [{ path: '', component: LandingComponent }];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    MatButtonModule
  ],
  exports: [RouterModule]
})
export class LandingRoutingModule { }
