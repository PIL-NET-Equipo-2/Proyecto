import { Component } from '@angular/core';
import { FormBuilder, FormGroup,Validators } from '@angular/forms';
import { AuthService } from 'src/app/Services/auth.service';
import { Router } from '@angular/router';
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
      email:['eve.holt@reqres.in',[Validators.required, Validators.email]],
      password:['cityslicka',[Validators.required]]
    })
  }
  get email(){
    return this.formularioLogin.controls.email;
  }
  get pass(){
    return this.formularioLogin.controls.password;
  }

  login(){
    console.log(this.formularioLogin.value);
    this._authService.login(this.formularioLogin.value).subscribe(
      {
        next:(data)=>{
          console.log(data);
          this.router.navigate(['/']);
        },
        error:(e)=>{
          this.error = e;
          console.log(this.error);
        }
      }
    )
  }


}
