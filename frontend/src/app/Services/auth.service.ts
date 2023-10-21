import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, tap, throwError } from 'rxjs';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private urlApi:string = environment.endpoint + "persona/";
  currentUserLoginOn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  constructor(private http: HttpClient) { }

  login(request: any): Observable<any> {
    console.log(request);
    return this.http.get(this.urlApi, request)
      .pipe(
        tap((token) => {
         
            sessionStorage.setItem('isUserLoginOn', 'true'),
        
          console.log("se logueo");
        
        catchError(this.handleError)
        }));
  }

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
