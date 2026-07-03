import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { RegistroService } from '../../services/registro.service';
import { ConferenciaService } from '../../services/conferencia.service';
import { AsistenteService } from '../../services/asistente.service';

import { Registro } from '../../models/registro';
import { Conferencia } from '../../models/conferencia';
import { Asistente } from '../../models/asistente';

@Component({
  selector: 'app-registros',
  imports: [CommonModule, FormsModule],
  templateUrl: './registros.html',
  styleUrl: './registros.css'
})
export class Registros implements OnInit {

  registros: Registro[] = [];
  conferencias: Conferencia[] = [];
  asistentes: Asistente[] = [];

  nuevoRegistro = {
    conferenciaId: 0,
    asistenteId: 0
  };

  constructor(
    private registroService: RegistroService,
    private conferenciaService: ConferenciaService,
    private asistenteService: AsistenteService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.cargarConferencias();
    this.cargarAsistentes();
    this.cargarRegistros();
  }

  cargarConferencias(): void {
    this.conferenciaService.obtenerConferencias().subscribe({
      next: (data) => {
        this.conferencias = data;
        this.cdr.detectChanges();
      },
      error: (error) => {
        console.error('Error al cargar conferencias:', error);
      }
    });
  }

  cargarAsistentes(): void {
    this.asistenteService.obtenerAsistentes().subscribe({
      next: (data) => {
        this.asistentes = data;
        this.cdr.detectChanges();
      },
      error: (error) => {
        console.error('Error al cargar asistentes:', error);
      }
    });
  }

  cargarRegistros(): void {
    this.registroService.obtenerRegistros().subscribe({
      next: (data) => {
        console.log('Registros recibidos:', data);
        this.registros = data;
        this.cdr.detectChanges();
      },
      error: (error) => {
        console.error('Error al cargar registros:', error);
      }
    });
  }

  guardarRegistro(): void {
    if (this.nuevoRegistro.conferenciaId === 0 || this.nuevoRegistro.asistenteId === 0) {
      alert('Debe seleccionar una conferencia y un asistente');
      return;
    }

    this.registroService.crearRegistro(this.nuevoRegistro).subscribe({
      next: () => {
        alert('Registro realizado correctamente');
        this.limpiarFormulario();
        this.cargarRegistros();
      },
      error: (error) => {
        console.error('Error al registrar asistente:', error);

        if (error.error) {
          alert(error.error);
        } else {
          alert('No se pudo registrar el asistente en la conferencia');
        }
      }
    });
  }

  limpiarFormulario(): void {
    this.nuevoRegistro = {
      conferenciaId: 0,
      asistenteId: 0
    };
  }
}