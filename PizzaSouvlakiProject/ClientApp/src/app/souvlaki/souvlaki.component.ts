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
  expandedSouvlakiRows: Set<string> = new Set();

  constructor(private souvlakiService: SouvlakiService) { }

  ngOnInit(): void {
    this.search()
  }

  search() {
    this.souvlakiService.searchSouvlaki({})
      .subscribe(response => this.allSouvlaki = response)
  }

  isExpanded(souvlakiId: string | null | undefined): boolean {
    return !!souvlakiId && this.expandedSouvlakiRows.has(souvlakiId);
  }

  toggleDetails(souvlaki: any) {
    const souvlakiId = souvlaki.id.toString();

    if (this.isExpanded(souvlakiId)) {
      this.expandedSouvlakiRows.delete(souvlakiId);
    } else {
      this.expandedSouvlakiRows.add(souvlakiId);
    }
  }

  private handleError(err: any) {
    console.log("Response Error. Status: ", err.status)
    console.log("Response Error. Status Text: ", err.statusText)
    console.log(err)
  }
}
