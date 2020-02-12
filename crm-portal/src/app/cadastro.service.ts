import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Cliente } from './cliente';

@Injectable({
  providedIn: 'root'
})
export class CadastroService {

  private clienteUrl = 'api/cliente';

  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  addCliente(cliente: Cliente): Observable<Cliente> {
    return this.http.post<Cliente>(this.clienteUrl, cliente, this.httpOptions).pipe(
      tap(_ => console.log('post cliente')),
      catchError(this.handleError<Cliente>('addCliente'))
    );
  }

  updateCliente(cliente: Cliente): Observable<any> {
    return this.http.put<Cliente>(this.clienteUrl, cliente, this.httpOptions).pipe(
      tap(_ => console.log('put cliente')),
      catchError(this.handleError('updateCliente'))
    );
  }

  removeCliente(id: number): Observable<any> {
    return this.http.delete(this.clienteUrl + '/' + id).pipe(
      tap(_ => console.log('delete cliente')),
      catchError(this.handleError('removeCliente'))
    );
  }

  getCliente(id: number): Observable<Cliente> {
    return this.http.get<Cliente>(this.clienteUrl + '/' + id);
  }

  getClientes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.clienteUrl);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      console.log('${operation} failed: ${error.message}');

      return of(result as T);
    };
  }
}
