import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, map, tap, throwError } from 'rxjs';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Registro } from '../interfaces/registro';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  private user = JSON.parse(localStorage.getItem('datos')!);
  private urlApi:string = environment.endpoint + "person/";


  constructor(private http: HttpClient) { }

  getSaldo(id: number):Observable<Registro>  {

    const authUser = this.http.get<Registro>(this.urlApi + id )

    return authUser;
  }
}
