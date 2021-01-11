import { Component, OnInit } from '@angular/core';
import { AuctionService } from 'src/app/services/auction.service';

@Component({
  selector: 'app-auctions-from-category',
  templateUrl: './auctions-from-category.component.html',
  styleUrls: ['./auctions-from-category.component.css']
})
export class AuctionsFromCategoryComponent implements OnInit {

  constructor(auctionService: AuctionService) { }

  ngOnInit(): void {
  }

}
