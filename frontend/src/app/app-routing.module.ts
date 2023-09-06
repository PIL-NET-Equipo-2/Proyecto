import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CotizacionesComponent } from './pages/cotizaciones/cotizaciones.component';
import { LoginComponent } from './pages/login/login.component';
import { AuthGuard } from './Services/auth.guard';
import { PortfolioComponent } from './pages/portfolio/portfolio.component';

const routes: Routes = [
  {path:'', component:LoginComponent},
  {path:'login', component: LoginComponent},
  {path:'cotizaciones', component: CotizacionesComponent, canActivate:[AuthGuard]},
  {path:'portfolio', component: PortfolioComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {  }
