import { Time } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { PizzaService } from '../api/services/pizza.service';
import { Pizza, FoodType } from '../api/models';

@Component({
  selector: 'app-pizza',
  templateUrl: './pizza.component.html',
  styleUrls: ['./pizza.component.css']
})
export class PizzaComponent implements OnInit {


  allPizza: Pizza[] = []

  constructor(private pizzaService: PizzaService) { }

  ngOnInit(): void {
    this.search()
  }

  search() {
    this.pizzaService.searchPizza({})
      .subscribe(response => this.allPizza = response,
        this.handleError)
  }

  private handleError(err: any) {
    console.log("Response Error. Status: ", err.status)
    console.log("Response Error. Status Text: ", err.statusText)
    console.log(err)
  }

}
