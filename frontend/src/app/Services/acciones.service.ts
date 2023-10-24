
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, map, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Compra } from '../interfaces/compra';

@Injectable({
  providedIn: 'root'
})
export class AccionesService {
  private urlApi:string = environment.endpoint + "purchases/";
  constructor(private http: HttpClient) { }

  getAccionesPorCuenta(id: number): Observable<Compra[]> {
    const idString: string = id.toString();
    return this.http.get<Compra[]>(`${this.urlApi}${idString}`);
  }

  enviarCompraAPIServidor(compra: Compra): Observable<any> {
    return this.http.post(this.urlApi, compra);
  }
}
