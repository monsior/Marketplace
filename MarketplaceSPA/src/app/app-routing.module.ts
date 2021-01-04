import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ValueComponent } from './components/value/value.component';

const routes: Routes = [
  { path: '', redirectTo: '', pathMatch: 'full' }, 
  { path: 'values', component: ValueComponent },
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
