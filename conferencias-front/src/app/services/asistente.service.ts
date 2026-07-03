import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Asistente } from '../models/asistente';

@Injectable({
  providedIn: 'root'
})
export class AsistenteService {

  private apiUrl = 'http://localhost:5013/api/Asistentes';

  constructor(private http: HttpClient) { }

  obtenerAsistentes(): Observable<Asistente[]> {
    return this.http.get<Asistente[]>(this.apiUrl);
  }

  crearAsistente(asistente: any): Observable<Asistente> {
    return this.http.post<Asistente>(this.apiUrl, asistente);
  }
}