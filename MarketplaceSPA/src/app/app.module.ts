import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { DatePipe } from '@angular/common'

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FormsModule } from '@angular/forms';
import { JwtModule } from '@auth0/angular-jwt';
import { CategoriesComponent } from './components/categories/categories.component';
import { AddAuctionComponent } from './components/add-auction/add-auction.component';
import { AuctionsFromCategoryComponent } from './components/auctions-from-category/auctions-from-category.component';
import { AuctionDetailsComponent } from './components/auction-details/auction-details.component';

export function tokenGetter(){
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CategoriesComponent,
    AddAuctionComponent,
    AuctionsFromCategoryComponent,
    AuctionDetailsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:44374'],
        disallowedRoutes: ['localhost:44374/api/auth']
      }
    })
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
