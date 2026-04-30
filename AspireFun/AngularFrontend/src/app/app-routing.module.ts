import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EntryComponent } from './components/entry-component/entry.component';
import { LandingComponent } from './components/landing/landing.component';
import { AppComponent } from './app.component';

const routes: Routes = [
  { path: '', component: LandingComponent },
  // { path: 'entry', component: EntryComponent },
  {
    path: 'entry',
    loadComponent: () =>
      import('./components/entry-component/entry.component').then(
        (c) => c.EntryComponent,
      ),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
