import { Routes } from '@angular/router';
import { Conferencias } from './pages/conferencias/conferencias';
import { Asistentes } from './pages/asistentes/asistentes';
import { Registros } from './pages/registros/registros';

export const routes: Routes = [
  { path: '', redirectTo: 'conferencias', pathMatch: 'full' },
  { path: 'conferencias', component: Conferencias },
  { path: 'asistentes', component: Asistentes },
  { path: 'registros', component: Registros }
];