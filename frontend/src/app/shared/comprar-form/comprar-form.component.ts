import { Component, Input } from '@angular/core';
import { registerLocaleData } from '@angular/common';

import localeEsAr from '@angular/common/locales/es-AR';
import { CotizacionesService } from 'src/app/Services/cotizaciones.service';

registerLocaleData(localeEsAr, 'es-Ar');


@Component({
  selector: 'comprar-form',
  templateUrl: './comprar-form.component.html',
  styleUrls: ['./comprar-form.component.css']
})
export class ComprarFormComponent {
  listaCotizaciones:any[]=[];
  accion = {
    simbolo: '',
    puntas:{
      precioVenta: 0
    }

  }

  constructor(private _cotizacionesServicio: CotizacionesService){}


  @Input()
  public nombreAccion: string = ""


  private cargarCotizacion() {
    this._cotizacionesServicio.obtenerCotizaciones().subscribe({
      next:(data)=>{
        this.listaCotizaciones = data
        console.log(this.listaCotizaciones);
        this.accion = this.listaCotizaciones.filter((accion)=>accion.simbolo == this.nombreAccion)[0];
        this.calcularTotal();
      }
    })
    
  }



  public cantidad: number = 1

  public isOpen: boolean = false;

  public total:number = (this.accion.puntas.precioVenta * this.cantidad) ;

  public switchModal():void{
    if(!this.isOpen)this.cargarCotizacion()
    this.isOpen = !this.isOpen
  }

  public stopPropagation(e:Event){
    e.stopPropagation()
  }

  public increaseNumber():void{
    this.cantidad = this.cantidad + 1
    this.calcularTotal();
    
  }

  public decreaseNumber():void{
    if( this.cantidad === 1 ) return
    this.cantidad = this.cantidad - 1
    this.calcularTotal();
    
  }

  public onComprar():void{
    this.cantidad = 1;
    this.total = this.accion.puntas.precioVenta;
    this.switchModal()

  }

  private calcularTotal() {
    this.total = this.cantidad * this.accion.puntas.precioVenta
  }

  

}
