import { Component, OnInit } from '@angular/core';
import { AuctionService } from 'src/app/services/auction.service';
import { CategoryService } from 'src/app/services/category.service';
import { Auction } from 'src/app/models/auction';
import { Router } from '@angular/router';
import jwt_decode from 'jwt-decode';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import { Category } from 'src/app/models/category';

@Component({
  selector: 'app-add-auction',
  templateUrl: './add-auction.component.html',
  styleUrls: ['./add-auction.component.css']
})
export class AddAuctionComponent implements OnInit {
  categories: Category[];
  auction: Auction = {
    name: '',
    categoryId: null,
    userId: jwt_decode(localStorage.getItem('token'))['nameid'],
    description: '',
    price: null,
    city: ''
  };
  photo: File = null;
  auctionId: number;

  formGroup: FormGroup;

  onFileSelected(event) {
    this.photo = event.target.files[0];
  }

  constructor(
    private categoryService: CategoryService, 
    private auctionService: AuctionService, 
    private router: Router
    ){}

  ngOnInit(): void {
    this.getCategories();    

    this.formGroup = new FormGroup({
      name: new FormControl('', [
        Validators.required
      ]),
      city: new FormControl('', [
        Validators.required
      ]),
      category: new FormControl('', [
        Validators.required
      ]),
      price: new FormControl('', [
        Validators.required
      ]),
      description: new FormControl('', [
        Validators.required
      ]),
      image: new FormControl('', [
        Validators.required
      ]),
    });
  }

  onSubmit(){    
    this.addAuction(this.auction);
  }

  getCategories(){
    this.categoryService.getCategories().subscribe(response => this.categories = response);
  }
  
  addAuction(auction: Auction){
    this.auctionService.addAuction(auction)
      .subscribe(response => {
        const formData = new FormData();
        formData.append('File', this.photo);
        this.addPhoto(formData, response['id']);
        this.router.navigate(['']);
      });
  }

  addPhoto(formData: FormData, auctionId: number){
    this.auctionService.addPhoto(formData, auctionId)
      .subscribe();
  }
}
