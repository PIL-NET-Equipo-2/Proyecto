import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable, map, take, tap } from 'rxjs';
import { AuthService } from './auth.service';
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(
    private _authService: AuthService,
    private router: Router
  ) {

    
  }


  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> { //
    
    
    return this._authService.isUserLoginOn.pipe(
      take(1),
      map((isUserLoginon) => {
        if ( !sessionStorage.getItem('isUserLoginOn')) {
          this.router.navigate(['/login']);
          isUserLoginon = false;
        } else{
          isUserLoginon = true
        }
        
        console.log(isUserLoginon);
        return isUserLoginon;
      }));
  }
}