import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CadastroService } from '../cadastro.service';
import { Cliente } from '../cliente';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {

  clientes: Cliente[];

  columnDefs = [
    { headerName: 'ID', field: 'id', flex: 1, sortable: true },
    { headerName: 'Nome', field: 'nome', flex: 4, sortable: true }
  ];

  constructor(private router: Router, private cadastroService: CadastroService) { }

  ngOnInit(): void {
    this.loadClientes();
  }

  loadClientes(): void {
    this.cadastroService.getClientes()
      .subscribe(clientes => this.clientes = clientes);
  }

  onNovoClicked(): void {
    this.router.navigateByUrl('clientes/0');
  }
}