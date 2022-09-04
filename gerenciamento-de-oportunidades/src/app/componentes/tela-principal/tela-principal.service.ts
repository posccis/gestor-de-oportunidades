import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Usuario } from './tela-principal.component';

@Injectable({
  providedIn: 'root',
})
export class TelaPrincipalService {

  baseUrl: string = 'https://localhost:7000/api/'
  constructor(private http: HttpClient) { }

  inserirUsuario(usuario: Usuario){
    this.http.post(this.baseUrl + 'usuario', usuario)
  }
}