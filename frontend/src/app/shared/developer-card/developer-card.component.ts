import { Component, Input } from '@angular/core';
import { Developer } from 'src/app/interfaces/developer.interfaces';

@Component({
  selector: 'developer-card',
  templateUrl: './developer-card.component.html',
  styleUrls: ['./developer-card.component.css']
})
export class DeveloperCardComponent {

  @Input() developer: Developer | undefined;

  constructor(){
   
    
  }

}
