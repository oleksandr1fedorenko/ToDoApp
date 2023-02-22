import {NgModule} from "@angular/core";
import {HeaderComponent} from "./header/header.component";
import {FooterComponent} from "./footer/footer.component";
import {ContentComponent} from "./content/content.component";
import {CommonModule} from "@angular/common";
import {RouterLink, RouterLinkActive} from "@angular/router";
import {FormsModule} from "@angular/forms";

@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    ContentComponent
  ],
  imports:[
    CommonModule,
    RouterLinkActive,
    RouterLink,
    FormsModule
  ],

  exports: [
    HeaderComponent,
    FooterComponent,
    ContentComponent,
  ]

})
export class CoreModule {
}
