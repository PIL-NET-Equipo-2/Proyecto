import { Component } from '@angular/core';
import { AccionesService } from 'src/app/Services/acciones.service';
import { CotizacionesService } from 'src/app/Services/cotizaciones.service';
import { UserService } from 'src/app/Services/user.service';

import { Compra } from 'src/app/interfaces/compra';

@Component({
  selector: 'app-portfolio',
  templateUrl: './portfolio.component.html',
  styleUrls: ['./portfolio.component.css']
})
export class PortfolioComponent {
  userData: any;
  compras: Compra[] = [];

  valores = {
    saldo: 0,
    invertido: 0,
    valorActual: 0,
    ganancia: 0,
    portfolio: 0
  };




  constructor(private _accionesService: AccionesService,
    private _cotizacionesServicio: CotizacionesService,
    private _userServicio: UserService

    ) {}






  idPerson:number = 0 ;
  listaCotizaciones:any[]=[];



  ngOnInit() {




  this.userData = JSON.parse(localStorage.getItem('datos')!);
  if (this.userData && this.userData.idPerson) {

    this.idPerson = parseInt(this.userData.idPerson, 10);
  } else {

    console.error('El campo idPerson no está definido o no es un número válido');
  }

  this._userServicio.getSaldo(this.idPerson).subscribe({

    next: (user) => {
      this.valores.saldo = user.accountMoney;
    },
    error: (error) => {
      console.log(error);
    }
  }
  )



  this._accionesService.getAccionesPorCuenta(this.idPerson).subscribe((data) => {
    this.compras = data;
    // console.log(data);
    this.compras.forEach(compra => {

      this.valores.invertido += compra.total;





    })

  });

  //cargar cotizaciones
  this._cotizacionesServicio.obtenerCotizaciones().subscribe({
    next:(data)=>{

      this.listaCotizaciones = data;
      this.compras.forEach(compra => {
        const cantidad: number = compra.quantity;
        const actual = this.obtenerPrecioCompraPorSimbolo(compra.symbol);
        this.valores.valorActual += actual! * cantidad
      })

      this.valores.ganancia = this.valores.valorActual - this.valores.invertido;
      this.valores.portfolio = this.valores.saldo + this.valores.invertido + this.valores.ganancia


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
