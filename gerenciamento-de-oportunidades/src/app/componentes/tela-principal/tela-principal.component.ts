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
  usuario: Usuario = new Usuario;
  usuarioBuscado: Usuario = new Usuario; 
  oportunidadesBuscado:Oportunidade[] = [] as Oportunidade[];
  oportunidade: Oportunidade = new Oportunidade;
  usuarioForm!: FormGroup;
  buscaForm!: FormGroup;
  oportunidadeForm!: FormGroup;

  constructor(TelaPrincipalService: TelaPrincipalService) { 
    this.telaPrincipalService = TelaPrincipalService;
  }

  ngOnInit(): void {
    this.usuarioForm = new FormGroup({
      nomeForm: new FormControl('', Validators.required),
      emailForm: new FormControl('', Validators.required),
      regiaoForm: new FormControl('', Validators.required)
    });

    this.oportunidadeForm = new FormGroup({
      nomeForm: new FormControl('', Validators.required),
      cnpjForm: new FormControl('', Validators.required),
      valorMonetarioForm: new FormControl('', Validators.required)
    });
    this.buscaForm = new FormGroup({
      emailForm : new FormControl('', Validators.required)
    })
  }

  montarUsuario(){
    this.usuario = {
      nome : this.usuarioForm.get('nomeForm')?.value,
      emailId :this.usuarioForm.get('emailForm')?.value,
      regiao : this.usuarioForm.get('regiaoForm')?.value,
      
    }

  }
  montarOportunidade(){
    this.oportunidade = {
      nome : this.oportunidadeForm.get('nomeForm')?.value,
      cnpj : this.oportunidadeForm.get('cnpjForm')?.value,
      valorMonetario : this.oportunidadeForm.get('valorMonetarioForm')?.value
    }
  
  }

  limparCamposUsuario(){
    this.usuarioForm.get('nomeForm')?.setValue('');
    this.usuarioForm.get('emailForm')?.setValue('');
    this.usuarioForm.get('regiaoForm')?.setValue('');
  }

  limparCamposOportunidade(){

    this.oportunidadeForm.get('nomeForm')?.setValue('');
    this.oportunidadeForm.get('cnpjForm')?.setValue('');
    this.oportunidadeForm.get('valorMonetarioForm')?.setValue('');
  }

  onSubmitUsuario(){
    try {
      if(this.usuarioForm.valid){
        this.montarUsuario();
        console.log(this.usuario);
        this.telaPrincipalService.inserirUsuario(this.usuario).subscribe(
          a => {
            alert("Vendedor cadastrado!");
            this.limparCamposUsuario();
          },
          error => { alert(error)}
        );
        
      }
    } catch (error) {
      
    }
  }
  
  onSubmitOportunidade(){
    try {
      if(this.oportunidadeForm.valid){
        this.montarOportunidade();
        this.telaPrincipalService.inserirOportunidade(this.oportunidade).subscribe(
          a => {
            alert("Oportunidade enviada!");
            this.limparCamposOportunidade();
          },
          error => { alert(error)}
        );
        
      }
    } catch (error) {
      
    }
  }

  onClickBusca(){
    try{
      this.telaPrincipalService.obterUsuarioPorEmail(this.buscaForm.get("emailForm")?.value).subscribe(
        a => {
          this.usuarioBuscado = {
            nome : a.nome,
            emailId: a.emailId,
            regiao: a.regiao,
            oportunidades: a.oportunidades,
            
          }
          this.oportunidadesBuscado = this.usuarioBuscado.oportunidades!;
          console.log(a.oportunidades)
        },
        error => {
          alert(error)
        }
      )
    }
    catch{

    }
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
  nome!: string;
  emailId!: string;
  regiao!: number;
  oportunidades?: Oportunidade[];

}
export class Oportunidade{
  nome!: string;
  cnpj!: string;
  razaoSocial?: string;
  valorMonetario!: number;
  descricaoDeAtividades?: string;
  codEstadoIBGE?: number;

}

