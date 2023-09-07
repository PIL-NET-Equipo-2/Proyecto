import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from './sidebar/sidebar.component';
import { RouterLink } from '@angular/router';
import { DeveloperCardComponent } from './developer-card/developer-card.component';
import { ComprarFormComponent } from './comprar-form/comprar-form.component';
import { FooterComponent } from './footer/footer.component';



@NgModule({
  declarations: [
    SidebarComponent,
    DeveloperCardComponent,
    ComprarFormComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    RouterLink
  ],
  exports: [
    SidebarComponent,
    DeveloperCardComponent,
    ComprarFormComponent,
    FooterComponent

  ]
})
export class SharedModule { }
