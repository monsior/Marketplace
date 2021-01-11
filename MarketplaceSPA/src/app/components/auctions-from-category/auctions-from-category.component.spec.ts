import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuctionsFromCategoryComponent } from './auctions-from-category.component';

describe('AuctionsFromCategoryComponent', () => {
  let component: AuctionsFromCategoryComponent;
  let fixture: ComponentFixture<AuctionsFromCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuctionsFromCategoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AuctionsFromCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
