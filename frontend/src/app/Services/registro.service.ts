import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, map, tap, throwError } from 'rxjs';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Registro } from '../interfaces/registro';
@Injectable({
  providedIn: 'root'
})
export class RegistroService {
  private urlApi:string = environment.endpoint + "person/";
  currentUserLoginOn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  constructor(private http: HttpClient) { }

  registry(user:Registro):Observable<Registro>  {

    user.dni = user.dni.toString()

    return this.http.post<Registro>(this.urlApi, user )
  }

  get isUserLoginOn():Observable<boolean>{
    return this.currentUserLoginOn.asObservable();
  }

}
