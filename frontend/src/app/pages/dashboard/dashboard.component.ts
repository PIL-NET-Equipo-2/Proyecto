import { Component } from '@angular/core';
import { AccionesService } from 'src/app/Services/acciones.service';
import { CotizacionesService } from 'src/app/Services/cotizaciones.service';
import { Acciones, Titulo } from 'src/app/interfaces/acciones';
import { Compra } from 'src/app/interfaces/compra';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  compras: Compra[] = [];
  listaCotizaciones:Titulo[]=[];
  constructor(private _accionesService: AccionesService,
    private _cotizacionesServicio: CotizacionesService) {}

  idPerson:number = 0 ;
  
  ngOnInit() {
   
    const userData = JSON.parse(localStorage.getItem('datos')!);

    if (userData && userData.idPerson) {
     
      this.idPerson = parseInt(userData.idPerson, 10);
    } else {
      
      console.error('El campo idPerson no está definido o no es un número válido');
    }



    this._accionesService.getAccionesPorCuenta(this.idPerson).subscribe((data) => {
      this.compras = data;
      console.log(data);
    });


    this._cotizacionesServicio.obtenerCotizaciones().subscribe({
      next:(data)=>{
        this.listaCotizaciones = data;     
      }
    })
  }

  obtenerPrecioCompraPorSimbolo(simboloBuscado: string): number | null {
    const accion = this.listaCotizaciones.find(titulo => titulo.simbolo === simboloBuscado);
    if (accion && accion.puntas) {
      return accion.puntas.precioVenta;
    }
    return null; // Devuelve null si no se encuentra la acción o si no tiene precio de compra
  }
}
