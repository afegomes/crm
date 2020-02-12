import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Endereco } from './endereco';

@Injectable({
  providedIn: 'root'
})
export class CepService {

  constructor() { }

  getEndereco(cep: string): Observable<Endereco> {
    var endereco = {
      logradouro: "Rua João Fregadolli",
      bairro: "Jd Dias I",
      localidade: "Maringá",
      uf: "PR"
    };

    return of(endereco);
  }
}
