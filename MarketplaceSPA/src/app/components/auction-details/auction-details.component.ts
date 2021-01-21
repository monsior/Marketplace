import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuctionService } from 'src/app/services/auction.service';

@Component({
  selector: 'app-auction-details',
  templateUrl: './auction-details.component.html',
  styleUrls: ['./auction-details.component.css']
})
export class AuctionDetailsComponent implements OnInit {
  id: number;
  auction: any;

  constructor(
    private auctionService: AuctionService, 
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = parseInt(params.get("id"))
    })
    this.getAuction(this.id);
  }

  getAuction(auctionId: number) {
    this.auctionService.getAuction(auctionId).subscribe(response => this.auction = response);
  }

}
