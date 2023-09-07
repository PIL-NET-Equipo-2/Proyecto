import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SidebarService {

  public isNarrow:boolean = false;

  constructor() { }

  public switchWidth():void{
    this.isNarrow = !this.isNarrow;
  }
}
