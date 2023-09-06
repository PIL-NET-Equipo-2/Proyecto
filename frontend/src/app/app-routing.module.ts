import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { IndexComponent } from './pages/index/index.component';
import { PortfolioComponent } from './pages/portfolio/portfolio.component';
import { CotizacionesComponent } from './pages/cotizaciones/cotizaciones.component';
import { LoginComponent } from './pages/login/login.component';
import { AuthGuard } from './Services/auth.guard';

const routes: Routes = [
  { 
    path: '',
    title: 'child b',
    component: IndexComponent },
  { 
    path: 'portfolio',
    title: 'Portfolio',
    component: PortfolioComponent},
    {path:'login', component: LoginComponent},
  {path:'cotizaciones', component: CotizacionesComponent, canActivate:[AuthGuard]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {  }
