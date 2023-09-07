import { Component } from '@angular/core';
import { SidebarService } from 'src/app/Services/sidebar.service';
import { Router } from '@angular/router';
@Component({
  selector: 'sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {

  /**
   * switchWidth
   */
  
  public get isNarrow() : boolean {
    return this._sideBarService.isNarrow;
  }
  

  public switchWidth() {
    this._sideBarService.switchWidth()
 
    
  }

  constructor(private _sideBarService: SidebarService,
    private router:Router){
  }

  cerrarSesion(){
    sessionStorage.removeItem('isUserLoginOn');
    this.router.navigate(['/landing']);
  }
}
