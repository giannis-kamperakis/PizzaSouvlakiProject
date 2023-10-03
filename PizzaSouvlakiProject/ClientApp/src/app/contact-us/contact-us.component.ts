
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent implements OnInit {
  menuList: Array<string> = [];
  typeList: Array<string> = [];

  constructor() {
    this.menuList = ['Pizza menu', 'Souvlaki menu'];
    this.typeList = ['Vegetarian', 'With Meat', 'Vegan'];
  }

  ngOnInit(): void {
    this.getAllFoodType();
  }

  getAllFoodType() {
    
  }


}
