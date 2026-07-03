import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AsistenteService } from '../../services/asistente.service';
import { Asistente } from '../../models/asistente';

@Component({
  selector: 'app-asistentes',
  imports: [CommonModule, FormsModule],
  templateUrl: './asistentes.html',
  styleUrl: './asistentes.css'
})
export class Asistentes implements OnInit {

  asistentes: Asistente[] = [];

  nuevoAsistente = {
    nombre: '',
    apellido: '',
    email: '',
    telefono: ''
  };

  constructor(
    private asistenteService: AsistenteService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.cargarAsistentes();
  }

  cargarAsistentes(): void {
    this.asistenteService.obtenerAsistentes().subscribe({
      next: (data) => {
        console.log('Asistentes recibidos:', data);
        this.asistentes = data;
        this.cdr.detectChanges();
      },
      error: (error) => {
        console.error('Error al cargar asistentes:', error);
      }
    });
  }

  guardarAsistente(): void {
    this.asistenteService.crearAsistente(this.nuevoAsistente).subscribe({
      next: () => {
        alert('Asistente registrado correctamente');
        this.limpiarFormulario();
        this.cargarAsistentes();
      },
      error: (error) => {
        console.error('Error al guardar asistente:', error);
        alert('No se pudo guardar el asistente');
      }
    });
  }

  limpiarFormulario(): void {
    this.nuevoAsistente = {
      nombre: '',
      apellido: '',
      email: '',
      telefono: ''
    };
  }
}