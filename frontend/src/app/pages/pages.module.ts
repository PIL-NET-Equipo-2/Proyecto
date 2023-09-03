import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './index/index.component';
import { PortfolioComponent } from './portfolio/portfolio.component';
import { CotizacionesComponent } from './cotizaciones/cotizaciones.component';
import { DesarrolladoresComponent } from './desarrolladores/desarrolladores.component';
import { LandingComponent } from './landing/landing.component';
import { RegistroComponent } from './registro/registro.component';



@NgModule({
  declarations: [
    IndexComponent,
    PortfolioComponent,
    CotizacionesComponent,
    DesarrolladoresComponent,
    LandingComponent,
    RegistroComponent
  ],
  imports: [
    CommonModule
  ]
})
export class PagesModule { }
