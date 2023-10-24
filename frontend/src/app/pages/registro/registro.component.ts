import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { RegistroService } from 'src/app/Services/registro.service';
@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent {
  formularioRegistro:FormGroup;
  ocultarPass:boolean = true;
  errorMessage:string = '';

  constructor(
    private fb:FormBuilder,
    private  service:RegistroService,
    private router:Router
  ) {
    this.formularioRegistro=this.fb.group({
      name:['',Validators.required],
      lastname:['',Validators.required],
      gender:['',Validators.required],
      dni:['',Validators.required],
      state:['',],
      city:['',],
      address:['',],
      mail:['',[Validators.required, Validators.email]],
      password:['',[Validators.required, Validators.minLength(8)]]
    });

  }
  get name(){
    return this.formularioRegistro.controls.name;
  }
  get lastname(){
    return this.formularioRegistro.controls.lastname;
  }
  get gender(){
    return this.formularioRegistro.controls.gender;
  }
  get dni(){
    return this.formularioRegistro.controls.dni;
  }

  get mail(){
    return this.formularioRegistro.controls.mail;
  }
  get pass(){
    return this.formularioRegistro.controls.password;
  }


  registrar(){
    this.service.registry(this.formularioRegistro.value).subscribe({

      next: (user) => {
        // console.log(user);
        sessionStorage.setItem('isUserLoginOn', 'true');
        localStorage.setItem('datos', JSON.stringify(user));

        this.router.navigate(['/']);
      },
      error: (error) => {
        console.log(error);
        this.errorMessage = 'Hubo un error en el registro.'

      }
    }
    )

  }
}
