import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Conferencia } from '../models/conferencia';

@Injectable({
  providedIn: 'root'
})
export class ConferenciaService {

  private apiUrl = 'http://localhost:5013/api/Conferencias';

  constructor(private http: HttpClient) { }

  obtenerConferencias(): Observable<Conferencia[]> {
    return this.http.get<Conferencia[]>(this.apiUrl);
  }

  crearConferencia(conferencia: any): Observable<Conferencia> {
    return this.http.post<Conferencia>(this.apiUrl, conferencia);
  }
}