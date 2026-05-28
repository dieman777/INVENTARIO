import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule],
  templateUrl: './login.component.html'//,
  //styleUrls: ['./login.component.css']
})
export class LoginComponent {

  mensaje: string = '';

  UsuariosLoginRequest = {
    usuario: '',
    contrasena: ''
  };

  // Cambie la URL según su backend
  apiUrl = 'https://localhost:7130/auth/login';

  constructor(private http: HttpClient) { }

  loginUsuario() {

    const body = {
      usuario: this.UsuariosLoginRequest.usuario,
      contrasena: this.UsuariosLoginRequest.contrasena
    };

    this.http.post<any>(this.apiUrl, body)
      .subscribe({
        next: (respuesta) => {
          localStorage.setItem('token', respuesta.token);
          this.mensaje = 'Login exitoso';
          console.log(respuesta);
        },
        error: (error) => {
          if (error.status === 401) {
            this.mensaje = 'Usuario o contraseña incorrectos';
          } else {
            this.mensaje = 'Error al conectar con el servidor';
          }
        }
      });
  }
}
