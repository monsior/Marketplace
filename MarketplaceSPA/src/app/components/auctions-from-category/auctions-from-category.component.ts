import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuctionService } from 'src/app/services/auction.service';

@Component({
  selector: 'app-auctions-from-category',
  templateUrl: './auctions-from-category.component.html',
  styleUrls: ['./auctions-from-category.component.css']
})
export class AuctionsFromCategoryComponent implements OnInit {
  id: number;
  auctions: any;

  constructor(private auctionService: AuctionService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = parseInt(params.get("id"))
    })
    this.getAuctionsByCategory(this.id);
  }

  getAuctionsByCategory(categoryId: number) {
    this.auctionService.getAuctionByCategory(categoryId).subscribe(response => this.auctions = response);
  }
}
