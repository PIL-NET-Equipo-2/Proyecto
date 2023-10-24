import { Component, Input } from '@angular/core';
import { registerLocaleData } from '@angular/common';

import localeEsAr from '@angular/common/locales/es-AR';
import { CotizacionesService } from 'src/app/Services/cotizaciones.service';
import { Compra } from 'src/app/interfaces/compra';
import { AccionesService } from 'src/app/Services/acciones.service';

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
  idPerson!: number;
  constructor(private _cotizacionesServicio: CotizacionesService,
    private _accionesService: AccionesService){
    const userData = JSON.parse(localStorage.getItem('datos')!);

    if (userData && userData.idPerson) {
     
      this.idPerson = parseInt(userData.idPerson, 10);
    } else {
      
      console.error('El campo idPerson no está definido o no es un número válido');
    }
    console.log(this.compra);
  }


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
  compra: Compra = {
    idPurchase: null,
    purchaseDate: null,
    quantity: 0,
    total: 0,
    idPerson: 0,
    symbol: ''
  };
  public onComprar():void{
    this.compra = {
      idPurchase: null,
      purchaseDate: null,
      quantity: this.cantidad,
      total: this.total,
      idPerson: this.idPerson,
      symbol: this.nombreAccion,
    }
    const userData = JSON.parse(localStorage.getItem('datos')!);

    if (userData && userData.idPerson) {
     
      this.idPerson = parseInt(userData.idPerson, 10);
    } else {
      
      console.error('El campo idPerson no está definido o no es un número válido');
    }
    console.log(this.compra);

    this._accionesService.registrarCompra(this.compra).subscribe(   
    );

  }

  private calcularTotal() {
    return this.total = (this.cantidad * this.accion.puntas.precioVenta) *1.015;
  }


}
