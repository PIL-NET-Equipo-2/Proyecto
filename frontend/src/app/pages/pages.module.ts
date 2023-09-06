import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './index/index.component';
import { PortfolioComponent } from './portfolio/portfolio.component';
import { CotizacionesComponent } from './cotizaciones/cotizaciones.component';
import { DesarrolladoresComponent } from './desarrolladores/desarrolladores.component';
import { LandingComponent } from './landing/landing.component';

import { SharedModule } from '../shared/shared.module';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';




@NgModule({
  declarations: [
    IndexComponent,
    PortfolioComponent,
    CotizacionesComponent,
    DesarrolladoresComponent,
    LandingComponent,
    LoginComponent,
    
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule
  ],
  exports: [
    IndexComponent,
    LandingComponent,
    PortfolioComponent,
    FormsModule,
    ReactiveFormsModule

  ]
})
export class PagesModule { }
