import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuctionService {
  baseUrl = environment.apiUrl + 'auctions/';

  constructor(private http: HttpClient) { }

  addAuction(auction: any) {
    return this.http.post(this.baseUrl, auction);
  }

  getAuctionByCategory(categoryId: number) {
    return this.http.get(this.baseUrl + `category/${categoryId}`);
  }

  getAuction(auctionId: number) {
    return this.http.get(this.baseUrl + `${auctionId}`);
  }

  addPhoto(photo: FormData, auctionId: number) {
    return this.http.post(this.baseUrl + `${auctionId}/photos`, photo); 
  }

}
