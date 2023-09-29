import { Time } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { SouvlakiService } from '../api/services/souvlaki.service';
import { Souvlaki, FoodType } from '../api/models';

@Component({
  selector: 'app-souvlaki',
  templateUrl: './souvlaki.component.html',
  styleUrls: ['./souvlaki.component.css']
})
export class SouvlakiComponent implements OnInit {


  allSouvlaki: Souvlaki[] = []

  constructor(private pizzaService: SouvlakiService) { }

  ngOnInit(): void {
    this.search()
  }

  search() {
    this.pizzaService.searchSouvlaki({})
      .subscribe(response => this.allSouvlaki = response)
  }
}
