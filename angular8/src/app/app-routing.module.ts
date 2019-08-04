import { CarListComponent } from './components/car-list/car-list.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { NewCarFormComponent } from './components/new-car-form/new-car-form.component';
import { DetailsComponent } from './components/details/details.component';

const routes: Routes = [{ path: 'home', component: HomeComponent },
{ path: 'newcarform',      component: NewCarFormComponent },
{ path: 'editcarform/:id',      component: NewCarFormComponent },
{ path: 'details/:id',      component: DetailsComponent },

{ path: 'carlist',      component: CarListComponent },

{ path: '',
  redirectTo: '/home',
  pathMatch: 'full'
},
{ path: '**', component: PageNotFoundComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
