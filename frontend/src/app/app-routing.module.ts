import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { IndexComponent } from './pages/index/index.component';
import { PortfolioComponent } from './pages/portfolio/portfolio.component';
import { CotizacionesComponent } from './pages/cotizaciones/cotizaciones.component';
import { LoginComponent } from './pages/login/login.component';
import { AuthGuard } from './Services/auth.guard';
import { AuthGuardIndex } from "./Services/authindex.guard";
import { DesarrolladoresComponent } from './pages/desarrolladores/desarrolladores.component';
import { LandingComponent } from './pages/landing/landing.component';
import { RegistroComponent } from './pages/registro/registro.component';

const routes: Routes = [
  { 
    path: '',
    component: IndexComponent, canActivate:[AuthGuardIndex] },
    {path: 'landing', component: LandingComponent},
    {path:'login', component: LoginComponent},
    {path:'registro', component: RegistroComponent},
    {path:'cotizaciones', component: CotizacionesComponent, canActivate:[AuthGuard]},
    {path:'portfolio', component: PortfolioComponent, canActivate:[AuthGuard]},
    {path: 'nosotros', component: DesarrolladoresComponent, canActivate:[AuthGuard]}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {  }
