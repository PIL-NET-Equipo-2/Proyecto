import { Component } from '@angular/core';
import { AccionesService } from 'src/app/Services/acciones.service';
import { CotizacionesService } from 'src/app/Services/cotizaciones.service';
import { Compra } from 'src/app/interfaces/compra';

@Component({
  selector: 'app-portfolio',
  templateUrl: './portfolio.component.html',
  styleUrls: ['./portfolio.component.css']
})
export class PortfolioComponent {
  userData: any;
  compras: Compra[] = [];
  


  constructor(private _accionesService: AccionesService,
    private _cotizacionesServicio: CotizacionesService
    ) {}






  idPerson:number = 0 ;
  listaCotizaciones:any[]=[];


  ngOnInit(): void {
  this.userData = JSON.parse(localStorage.getItem('datos')!);
  if (this.userData && this.userData.idPerson) {
     
    this.idPerson = parseInt(this.userData.idPerson, 10);
  } else {
    
    console.error('El campo idPerson no está definido o no es un número válido');
  }

  this._accionesService.getAccionesPorCuenta(this.idPerson).subscribe((data) => {
    this.compras = data;
    console.log(data);
  });

  //cargar cotizaciones
  this._cotizacionesServicio.obtenerCotizaciones().subscribe({
    next:(data)=>{
      this.listaCotizaciones = data;     
    }
  })


  



 }
 clacularValorPortfolio(){
  // traer acciuones de la cuenta
  


  return
 }
  buscarAccionPorSimbolo(data:any , simboloBuscado:string) {
  const accionEncontrada = data.titulos.find((accion: { simbolo: any; }) => accion.simbolo === simboloBuscado);
  return accionEncontrada;
}
}
