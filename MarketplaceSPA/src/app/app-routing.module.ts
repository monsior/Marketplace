import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AddAuctionComponent } from './components/add-auction/add-auction.component';
import { CategoriesComponent } from './components/categories/categories.component';
import { AuctionsFromCategoryComponent } from './components/auctions-from-category/auctions-from-category.component';
import { AuctionDetailsComponent } from './components/auction-details/auction-details.component';

const routes: Routes = [
  { path: '', component: CategoriesComponent }, 
  { path: 'add-auction', component: AddAuctionComponent},
  { path: 'auctions/category/:id', component: AuctionsFromCategoryComponent},
  { path: 'auctions/:id', component: AuctionDetailsComponent}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
