import { Location } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CadastroService } from '../cadastro.service';
import { CepService } from '../cep.service';
import { Cliente } from '../cliente';

@Component({
  selector: 'app-cadastro-cliente',
  templateUrl: './cadastro-cliente.component.html',
  styleUrls: ['./cadastro-cliente.component.css']
})
export class CadastroClienteComponent implements OnInit {

  @Input() cliente: Cliente;

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private cadastroService: CadastroService,
    private cepService: CepService
  ) { }

  ngOnInit(): void {
    this.loadCliente();
  }

  loadCliente(): void {
    this.cliente = {
      id: null,
      nome: null,
      dataNascimento: null,
      sexo: null,
      logradouro: null,
      numero: null,
      complemento: null,
      cep: null,
      bairro: null,
      cidade: null,
      estado: null
    };

    // TODO: substituir por um Strategy
    const id = this.getClienteId();

    if (id > 0) {
      this.cadastroService.getCliente(id)
        .subscribe(cliente => this.cliente = cliente);
    }
  }

  onPesquisarClicked(): void {
    if (this.cliente.cep == null) {
      return;
    }

    this.cepService.getEndereco(this.cliente.cep)
      .subscribe(endereco => {
        this.cliente.logradouro = endereco.logradouro;
        this.cliente.numero = null;
        this.cliente.complemento = null;
        this.cliente.bairro = endereco.bairro;
        this.cliente.cidade = endereco.localidade;
        this.cliente.estado = endereco.uf;
      });
  }

  onSalvarClicked(): void {
    // TODO: substituir por um Strategy
    if (this.cliente.id) {
      this.cadastroService.updateCliente(this.cliente)
        .subscribe(result => {
          console.log(result);
          this.location.back();
        });
    }
    else {
      this.cadastroService.addCliente(this.cliente)
        .subscribe(cliente => {
          console.log(cliente);
          this.location.back();
        });
    }
  }

  onCancelarClicked(): void {
    this.location.back();
  }

  onRemoverClicked(): void {
    const id = this.getClienteId();

    this.cadastroService.removeCliente(id)
      .subscribe(result => {
        console.log(result);
        this.location.back();
      });
  }

  getClienteId(): number {
    return +this.route.snapshot.paramMap.get('id');
  }
}
