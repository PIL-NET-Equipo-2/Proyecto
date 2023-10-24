import { Component } from '@angular/core';
import { FormBuilder, FormGroup,Validators } from '@angular/forms';
import { AuthService } from 'src/app/Services/auth.service';
import { Router } from '@angular/router';
import { Login } from 'src/app/interfaces/login';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  formularioLogin:FormGroup;
  
  ocultarPassword:boolean=true;
  error?:string ="";
  constructor(private fb:FormBuilder,
   private  _authService:AuthService,
   private router:Router
    ) {
    
    this.formularioLogin = this.fb.group({
      usuario:['',[Validators.required, Validators.email]],
      contrasenia:['',[Validators.required]]
    })
  }
  get usuario(){
    return this.formularioLogin.controls.usuario;
  }
  get contrasenia(){
    return this.formularioLogin.controls.contrasenia;
  }

  login(){

    const formData: Login = this.formularioLogin.value;
    console.log(formData);
    this._authService.login(formData).subscribe(
      (response) => {
        
        localStorage.setItem('datos', JSON.stringify(response));
       
        this.router.navigate(['/']);
      },
      (error) => {
        this.error = error;
          console.log(this.error);
      }
    );
  }


  
}
