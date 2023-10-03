import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { PizzaComponent } from './pizza/pizza.component';
import { PizzaDetailsComponent } from './pizza-details/pizza-details.component';
import { HomepageComponent } from './homepage/homepage.component';
import { SouvlakiComponent } from './souvlaki/souvlaki.component';
import { SouvlakiDetailsComponent } from './souvlaki-details/souvlaki-details.component';
import { ContactUsComponent } from './contact-us/contact-us.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    PizzaComponent,
    PizzaDetailsComponent,
    HomepageComponent,
    SouvlakiComponent,
    ContactUsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomepageComponent, pathMatch: 'full' },
      { path: 'pizza', component: PizzaComponent },
      { path: 'souvlaki', component: SouvlakiComponent },
      { path: 'pizza-details/:pizzaId', component: PizzaDetailsComponent },
      { path: 'souvlaki-details/:souvlakiId', component: SouvlakiDetailsComponent },
      { path: 'contact-us', component: ContactUsComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
