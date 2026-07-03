import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ConferenciaService } from '../../services/conferencia.service';
import { Conferencia } from '../../models/conferencia';

@Component({
  selector: 'app-conferencias',
  imports: [CommonModule, FormsModule],
  templateUrl: './conferencias.html',
  styleUrl: './conferencias.css'
})
export class Conferencias implements OnInit {

  conferencias: Conferencia[] = [];

  nuevaConferencia = {
    nombre: '',
    fecha: '',
    ubicacion: '',
    descripcion: ''
  };

  constructor(
    private conferenciaService: ConferenciaService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.cargarConferencias();
  }

  cargarConferencias(): void {
    this.conferenciaService.obtenerConferencias().subscribe({
      next: (data) => {
        console.log('Conferencias recibidas:', data);
        this.conferencias = data;
        this.cdr.detectChanges();
      },
      error: (error) => {
        console.error('Error al cargar conferencias:', error);
      }
    });
  }

  guardarConferencia(): void {
    const conferencia = {
      nombre: this.nuevaConferencia.nombre,
      fecha: this.nuevaConferencia.fecha + 'T00:00:00Z',
      ubicacion: this.nuevaConferencia.ubicacion,
      descripcion: this.nuevaConferencia.descripcion
    };

    this.conferenciaService.crearConferencia(conferencia).subscribe({
      next: () => {
        alert('Conferencia registrada correctamente');
        this.limpiarFormulario();
        this.cargarConferencias();
      },
      error: (error) => {
        console.error('Error al guardar conferencia:', error);
        alert('No se pudo guardar la conferencia');
      }
    });
  }

  limpiarFormulario(): void {
    this.nuevaConferencia = {
      nombre: '',
      fecha: '',
      ubicacion: '',
      descripcion: ''
    };
  }

  eliminarConferencia(id: number): void {
    const confirmar = confirm('¿Está seguro de eliminar esta conferencia?');

    if (!confirmar) {
      return;
    }

    this.conferenciaService.eliminarConferencia(id).subscribe({
      next: () => {
        alert('Conferencia eliminada correctamente');
        this.cargarConferencias();
      },
      error: (error) => {
        console.error('Error al eliminar conferencia:', error);
        alert('No se pudo eliminar la conferencia. Puede tener registros asociados.');
      }
    });
  }
}