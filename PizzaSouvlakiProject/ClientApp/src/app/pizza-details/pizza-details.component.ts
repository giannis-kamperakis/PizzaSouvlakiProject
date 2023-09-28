import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PizzaService } from './../api/services/pizza.service';
import { Pizza } from '../api/models';

@Component({
  selector: 'app-pizza-details',
  templateUrl: './pizza-details.component.html',
  styleUrls: ['./pizza-details.component.css']
})
export class PizzaDetailsComponent implements OnInit {

  constructor(private route: ActivatedRoute,
    private router: Router,
    private pizzaService: PizzaService) { }

  pizzaId: string = 'not loaded'
  detailedPizza: Pizza = {}

  ngOnInit(): void {
    this.route.paramMap
      .subscribe(p => this.findFlight(p.get("pizzaId")))
  }

  private findFlight = (flightId: string | null) => {
    this.pizzaId = flightId ?? 'not passed';

    this.pizzaService.findPizza({ id: this.pizzaId })
      .subscribe(flight => this.detailedPizza = flight)
  }
}
