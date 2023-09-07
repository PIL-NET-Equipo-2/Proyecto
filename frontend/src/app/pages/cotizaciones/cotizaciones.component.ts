import { Component, OnInit } from '@angular/core';
import { CotizacionesService } from 'src/app/Services/cotizaciones.service';


@Component({
  selector: 'app-cotizaciones',
  templateUrl: './cotizaciones.component.html',
  styleUrls: ['./cotizaciones.component.css']
})
export class CotizacionesComponent implements OnInit  {
  listaCotizaciones:any[]=[];
  listaCotizacionesMostrar:any[]=[];
  paginaActual:number= 1;
  ultimaPagina!:number;
  elementosPorPagina:number = 10;
  cargando:boolean = true;
  constructor(
    private _cotizacionesServicio: CotizacionesService
  ) {
    
    
  }

  ngOnInit(): void {
    this.cargarCotizaciones();

    this.cargando = false;   
  }

  cargarCotizaciones(){
    this._cotizacionesServicio.obtenerCotizaciones().subscribe({
      next:(data)=>{
        this.listaCotizaciones = data;
        this.listaCotizacionesMostrar = this.listaCotizaciones;
        this.ultimaPagina = this.listaCotizacionesMostrar.length / 10;       
      }
    })
  }



  
  obtenerElementosPagina(): any[] {
    const inicio = (this.paginaActual - 1) * this.elementosPorPagina;
    const fin = inicio + this.elementosPorPagina;
    return this.listaCotizacionesMostrar.slice(inicio, fin);
  }

  filtrarDatos(filtro:string) {
    this.cargando = true;
    this.paginaActual = 1;
    this.listaCotizacionesMostrar = this.listaCotizaciones;
   
    const filtroTexto = filtro.toLowerCase();
    this.listaCotizacionesMostrar = this.listaCotizacionesMostrar.filter(dato =>
      dato.simbolo.toLowerCase().includes(filtroTexto)
    );
    this.ultimaPagina = this.listaCotizacionesMostrar.length / 10;
    this.cargando = false;
  }

}
