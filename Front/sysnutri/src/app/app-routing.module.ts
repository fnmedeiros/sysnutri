import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProfissionaisComponent } from './profissionais/profissionais.component';
import { ProfissionaisDetalheComponent } from './profissionais-detalhe/profissionais-detalhe.component';
import { ProfissionaisNovoComponent } from './profissionais-novo/profissionais-novo.component';
import { ProfissionaisEditarComponent } from './profissionais-editar/profissionais-editar.component';

const routes: Routes = [
  {
    path: 'profissionais',
    component: ProfissionaisComponent,
    data: { title: 'Lista de Profissionais' }
  },
  {
    path: 'profissionais-detalhe/:id',
    component: ProfissionaisDetalheComponent,
    data: { title: 'Detalhe do Profissionais' }
  },
  {
    path: 'profissionais-novo',
    component: ProfissionaisNovoComponent,
    data: { title: 'Adicionar Profissionais' }
  },
  {
    path: 'profissionais-editar/:id',
    component: ProfissionaisEditarComponent,
    data: { title: 'Editar o Profissionais' }
  },
  { path: '',
    redirectTo: '/profissionais',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
