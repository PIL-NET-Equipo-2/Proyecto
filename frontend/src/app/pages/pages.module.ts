import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './index/index.component';
import { PortfolioComponent } from './portfolio/portfolio.component';
import { CotizacionesComponent } from './cotizaciones/cotizaciones.component';
import { DesarrolladoresComponent } from './desarrolladores/desarrolladores.component';
import { LandingComponent } from './landing/landing.component';
import { RegistroComponent } from './registro/registro.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';




@NgModule({
  declarations: [
    IndexComponent,
    PortfolioComponent,
    CotizacionesComponent,
    DesarrolladoresComponent,
    LandingComponent,
    RegistroComponent,
    LoginComponent,
    DashboardComponent,
    
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    RouterModule
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
