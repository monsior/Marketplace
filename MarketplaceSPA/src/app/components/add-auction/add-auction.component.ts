import { Component, OnInit } from '@angular/core';
import { AuctionService } from 'src/app/services/auction.service';
import { CategoryService } from 'src/app/services/category.service';
import { Auction } from 'src/app/models/auction';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-auction',
  templateUrl: './add-auction.component.html',
  styleUrls: ['./add-auction.component.css']
})
export class AddAuctionComponent implements OnInit {
  categories: any;
  auction: Auction = {
    name: '',
    categoryId: null,
    description: ''
  };

  constructor(
    private categoryService: CategoryService, 
    private auctionService: AuctionService, 
    private router: Router
    ){}

  ngOnInit(): void {
    this.getCategories()
  }

  getCategories(){
    this.categoryService.getCategories().subscribe(response => this.categories = response);
  }
  
  addAuction(auction: Auction){
    this.auctionService.addAuction(auction)
      .subscribe(() => this.router.navigate(['']));;
  }
}
