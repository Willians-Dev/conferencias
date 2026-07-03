import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Registro } from '../models/registro';

@Injectable({
  providedIn: 'root'
})
export class RegistroService {

  private apiUrl = 'http://localhost:5013/api/Registros';

  constructor(private http: HttpClient) { }

  obtenerRegistros(): Observable<Registro[]> {
    return this.http.get<Registro[]>(this.apiUrl);
  }

  crearRegistro(data: { conferenciaId: number; asistenteId: number }): Observable<any> {
    return this.http.post<any>(this.apiUrl, data);
  }
}