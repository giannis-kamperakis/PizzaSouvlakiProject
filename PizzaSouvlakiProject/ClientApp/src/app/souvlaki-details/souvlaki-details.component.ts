import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SouvlakiService } from './../api/services/souvlaki.service';
import { Souvlaki } from '../api/models';

@Component({
  selector: 'app-souvlaki-details',
  templateUrl: './souvlaki-details.component.html',
  styleUrls: ['./souvlaki-details.component.css']
})
export class SouvlakiDetailsComponent implements OnInit {

  constructor(private route: ActivatedRoute,
    private router: Router,
    private souvlakiService: SouvlakiService) { }

  souvlakiId: string = 'not loaded'
  detailedSouvlaki: Souvlaki = {}

  ngOnInit(): void {
    this.route.paramMap
      .subscribe(p => this.findFlight(p.get("souvlakiId")))
  }

  private findFlight = (flightId: string | null) => {
    this.souvlakiId = flightId ?? 'not passed';

    this.souvlakiService.findSouvlaki({ id: this.souvlakiId })
      .subscribe(flight => this.detailedSouvlaki = flight)
  }
}
