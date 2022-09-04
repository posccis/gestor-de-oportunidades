import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TelaPrincipalService } from './tela-principal.service';

@Component({
  selector: 'app-tela-principal',
  templateUrl: './tela-principal.component.html',
  styleUrls: ['./tela-principal.component.css']
})
export class TelaPrincipalComponent implements OnInit {

  telaPrincipalService: TelaPrincipalService;
  telaInicialOn : boolean = true;
  telaCadastroOn : boolean = false;
  telaOportunidadesOn: boolean = false;
  telaBuscaOn: boolean = false;
  usuarioForm!: FormGroup;
  constructor(TelaPrincipalService: TelaPrincipalService) { 
    this.telaPrincipalService = TelaPrincipalService;
  }

  ngOnInit(): void {
    this.usuarioForm = new FormGroup({
      nomeForm: new FormControl('', Validators.required),
      emailForm: new FormControl('', Validators.required),
      regiaoForm: new FormControl('', Validators.required)
    });
  }

  clickTelaCadastro(){
    this.telaInicialOn = false;
    this.telaCadastroOn = true;
    this.telaOportunidadesOn = false;
    this.telaBuscaOn = false;
    
  }

  clickTelaOportunidade(){
    this.telaOportunidadesOn = true;
    this.telaInicialOn = false;
    this.telaCadastroOn = false;
    this.telaBuscaOn = false;

  }

  clickTelaDeBusca(){
    this.telaBuscaOn = true;
    this.telaOportunidadesOn = false;
    this.telaInicialOn = false;
    this.telaCadastroOn = false;

  }

  telaOn(){
    if (this.telaBuscaOn){
      return "TelaBuscas"
    }
    else if (this.telaCadastroOn){
      return "TelaCadastro"
    }
    else if (this.telaOportunidadesOn){
      return "TelaOportunidades"
    }
    else if (this.telaInicialOn){
      return "TelaInicial"
    }
    return ""
  }

}

export class Usuario{
  Nome!: string;
  Email!: string;
  Regiao!: number;
  Oportunidades!: Oportunidade[];

}
export class Oportunidade{
  Nome!: string;
  Cnpj!: string;
  RazaoSocial!: string;
  ValorMonetario!: number;
  DescricaoDeAtividades!: string;
  CodIBGE!: number;

}
