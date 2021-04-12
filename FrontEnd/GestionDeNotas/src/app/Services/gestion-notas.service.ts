import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Notas } from '../Models/Notas';

@Injectable({
  providedIn: 'root'
})
export class GestionNotasService {
  myAppUrl = 'https://localhost:44346/';
  myApiUrl = 'api/nota/'


  constructor(private http: HttpClient) { }

  guardarRegitro(Notas: Notas): Observable<Notas> {
    return this.http.post<Notas>(this.myAppUrl + this.myApiUrl, Notas);
  }


}
