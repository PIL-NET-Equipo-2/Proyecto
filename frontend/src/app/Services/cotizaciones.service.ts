import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import {Observable} from 'rxjs'
@Injectable({
  providedIn: 'root'
})
export class CotizacionesService {
  urlApi:string = "http://localhost:3000/"
  constructor(
    private http:HttpClient
  ) { }

  obtenerCotizaciones():Observable<any>{
    return this.http.get(`${this.urlApi}titulos`);
  }

}
