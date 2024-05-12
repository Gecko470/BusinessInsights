import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { respJuego } from '../../../interfaces/respJuego.interface';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  constructor(private http: HttpClient) { }

  public jugar(numero: number): Observable<respJuego>{
    return this.http.get<respJuego>(`https://localhost:7242/api/einstein/inicio/${numero}`);
  }
}
