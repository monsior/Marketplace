import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ValueComponent } from './components/value/value.component';
import { AddAuctionComponent } from './components/add-auction/add-auction.component';
import { CategoriesComponent } from './components/categories/categories.component';

const routes: Routes = [
  { path: '', component: CategoriesComponent }, 
  { path: 'values', component: ValueComponent },
  { path: 'add-auction', component: AddAuctionComponent}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
