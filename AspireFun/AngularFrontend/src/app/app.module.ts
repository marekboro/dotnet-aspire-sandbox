import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EntryComponent } from './components/entry-component/entry.component';
import { HttpClientModule } from '@angular/common/http';
import { AspireServerApiHttpClient } from './apiHttpClient';
import { NavComponent } from './components/nav/nav.component';


@NgModule({
  declarations: [AppComponent, NavComponent],
  imports: [HttpClientModule, BrowserModule, AppRoutingModule, EntryComponent],
  providers: [AspireServerApiHttpClient],
  bootstrap: [AppComponent, NavComponent],
})
export class AppModule {}
