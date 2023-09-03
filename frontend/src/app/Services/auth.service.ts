import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, tap, throwError } from 'rxjs';
import { BehaviorSubject } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  urlApi: string = "https://reqres.in/api/login"
  currentUserLoginOn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  constructor(private http: HttpClient) { }

  login(request: any): Observable<any> {

    return this.http.post(this.urlApi, request)
      .pipe(
        tap((token) => {
          if (JSON.stringify(token).length != 0) {
            this.currentUserLoginOn.next(true);
            sessionStorage.setItem('isUserLoginOn', 'true')
          }
            console.log(token);
          }),
        catchError(this.handleError)
      );
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
