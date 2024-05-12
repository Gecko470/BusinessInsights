import { Component } from '@angular/core';
import { GameService } from '../../../services/game.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styles: `
  .background{
    background-image: url('../../../../assets/img/einstein2.jpg');
    background-size: cover;
    background-repeat: no-repeat;
    background-position: center center;
  }
  `
})
export class InicioComponent {
  public numero: number = 0;
  public num: string = '';
  public resp: string = '';
  public jugadas: number = 0;
  public limNumero: number = 0;
  public mensaje: string = '';
  public valido: boolean = false;

  myForm: FormGroup = this.fb.group({
    limite: ['', [Validators.required]]
  });


  constructor(private gameService: GameService, private fb: FormBuilder) { }

  campoEsValido(campo: string) {
    return (this.myForm.controls[campo].value == '');
  }

  public setLimite() {
      if(this.myForm.controls['limite'].value == '-' || isNaN(this.myForm.controls['limite'].value)){
        this.mensaje = "Eso no es un número entero válido..";
        this.valido = false;
      }
      else{
        this.limNumero = parseInt(this.myForm.controls['limite'].value);
        if (this.limNumero <= 0) {
          this.mensaje = "Introduce un número entero mayor que 0..";
          this.valido = false;
        }
        else{
          this.mensaje = '';
          this.valido = true;
        }
      }
  }

  public Jugar() {
    this.jugadas++;

    this.numero = Math.floor(Math.random() * (this.limNumero - 1 + 1)) + 1;

    this.gameService.jugar(this.numero).subscribe({
      next: (response) => {
        this.num = response.numero.toString();
        this.resp = response.res;
        console.log(response.res, response.numero)
      },
      error: (response) => {
        if (response.status == 400) {

        }
      }
    });
  }
}
