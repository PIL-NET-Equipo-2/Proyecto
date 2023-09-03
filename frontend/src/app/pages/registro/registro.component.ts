import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormsModule } from '@angular/forms';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent {
  formularioRegistro:FormGroup;
  ocultarPass:boolean = true;
  constructor(
    private fb:FormBuilder
  ) {
    this.formularioRegistro=this.fb.group({
      nombre:['',Validators.required],
      apellido:['',Validators.required],
      sexo:['',Validators.required],
      dni:['',Validators.required],
      provincia:['',],
      ciudad:['',],
      domicilio:['',],
      email:['',[Validators.required, Validators.email]],
      password:['',Validators.required]
    });
    
  }
  registrar(){
    console.log(this.formularioRegistro.value);
    //Aca Va el codigo una vez que se tenga la api para registrarse
  }
}
