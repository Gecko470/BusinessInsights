import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InicioComponent } from './pages/inicio/inicio.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    InicioComponent
  ],
  exports:[
    InicioComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ]
})
export class GameModule { }
