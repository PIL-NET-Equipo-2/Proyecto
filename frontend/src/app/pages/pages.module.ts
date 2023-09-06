import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './index/index.component';
import { PortfolioComponent } from './portfolio/portfolio.component';
import { CotizacionesComponent } from './cotizaciones/cotizaciones.component';
import { DesarrolladoresComponent } from './desarrolladores/desarrolladores.component';
import { LandingComponent } from './landing/landing.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    IndexComponent,
    PortfolioComponent,
    CotizacionesComponent,
    DesarrolladoresComponent,
    LandingComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    IndexComponent,
    LandingComponent,
    PortfolioComponent
  ]
})
export class PagesModule { }
