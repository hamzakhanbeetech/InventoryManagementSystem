import { Component, NgModule } from '@angular/core';

import { RouterModule, Routes } from '@angular/router';

import { BrowserModule } from '@angular/platform-browser';

import { FormsModule } from '@angular/forms';
import { HomeComponent } from './components/home/home.component';




const routes: Routes = [

  {path: '', component: HomeComponent },
  
  { path: 'sales', loadChildren: () => import('./modules/sales/sales.module').then(m => m.SalesModule) },

  { path: 'purchase', loadChildren: () => import('./modules/purchase/purchase.module').then(m => m.PurchaseModule) }

]




@NgModule({

  imports: [BrowserModule,

    FormsModule,

    RouterModule.forRoot(routes)

  ],

  exports: [RouterModule]

})

export class AppRoutingModule { }