import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, map, tap, throwError } from 'rxjs';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Login } from '../interfaces/login';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private urlApi:string = environment.endpoint + "person/login/";
  currentUserLoginOn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  constructor(private http: HttpClient) { }

  login(request:Login) {
    const usuarioEncoded = encodeURIComponent(request.usuario);
    const contraseniaEncoded = encodeURIComponent(request.contrasenia);

    const loginUrl = `${this.urlApi}${usuarioEncoded},${contraseniaEncoded}`;
    return this.http.get(loginUrl).pipe(
      map((response: any) => {
        console.log(response);
         if (response === 200) {         
          sessionStorage.setItem('isUserLoginOn', 'true'); 
          return response; 
        } else {  
          console.log(response);
          throw new Error('Error en las credenciales');
        } 
      }),
      catchError((error) => {  
        console.log(error);
        return this.handleError(error);
      })
    );}



  get isUserLoginOn():Observable<boolean>{
    return this.currentUserLoginOn.asObservable();
  }


  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('An error occurred:', error.error);
    } else {
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    return throwError(() => new Error('Algo paso, reintentelo nuevamente...'));
  } 


}
