export interface Registro {
  registroId: number;
  fechaRegistro: string;
  conferencia: {
    conferenciaId: number;
    nombre: string;
    fecha: string;
    ubicacion: string;
  };
  asistente: {
    asistenteId: number;
    nombre: string;
    apellido: string;
    email: string;
  };
}