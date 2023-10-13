import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxPaginationModule } from 'ngx-pagination';
import { ToastrModule } from 'ngx-toastr';

import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { FooterComponent } from './components/footer/footer.component';
import { AppComponent } from './app.component';

import { ProductService } from './services/product.service';
import { HomeComponent } from './components/home/home.component';



@NgModule({

  declarations: [

    AppComponent,
    FooterComponent,
    NavBarComponent,
    HomeComponent

  ],

  imports: [

    BrowserModule,

    BrowserAnimationsModule,

    FormsModule,

    HttpClientModule,

    NgxPaginationModule,

    RouterModule,

    AppRoutingModule,

    ReactiveFormsModule,

    ToastrModule.forRoot({}),

    NoopAnimationsModule,

    BrowserAnimationsModule

  ],

  providers: [ProductService],

  bootstrap: [AppComponent]

})

export class AppModule { }