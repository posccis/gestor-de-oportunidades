import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Oportunidade, Usuario } from './tela-principal.component';

@Injectable({
  providedIn: 'root',
})
export class TelaPrincipalService {

  baseUrl: string = 'https://localhost:7000/api/'
  constructor(private http: HttpClient) { }

  inserirUsuario(usuario: Usuario){
    console.log(usuario);
    return this.http.post(`${this.baseUrl}usuario`, usuario)
  }
  inserirOportunidade(oportunidade: Oportunidade){
    return this.http.post(`${this.baseUrl}oportunidade`, oportunidade)
  }
  obterUsuarioPorEmail(email: string){
    return this.http.get<Usuario>(`${this.baseUrl}usuario/${email}`)
  }
}