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
      password:['',[Validators.required, Validators.minLength(8)]]
    });
    
  }
  get nombre(){
    return this.formularioRegistro.controls.nombre;
  }
  get apellido(){
    return this.formularioRegistro.controls.apellido;
  }
  get sexo(){
    return this.formularioRegistro.controls.sexo;
  }
  get dni(){
    return this.formularioRegistro.controls.dni;
  }
  
  get email(){
    return this.formularioRegistro.controls.email;
  }
  get pass(){
    return this.formularioRegistro.controls.password;
  }


  registrar(){
    console.log(this.formularioRegistro.value);
    //Aca Va el codigo una vez que se tenga la api para registrarse
  }
}
