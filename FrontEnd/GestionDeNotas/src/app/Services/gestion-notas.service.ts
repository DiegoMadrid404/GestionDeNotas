import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Alumnos } from '../Models/Alumnos';
import {  Materias } from '../Models/Materias';
import { Notas } from '../Models/Notas';
import { PromedioNotasList } from '../Models/PromedioNotasList';

@Injectable({
  providedIn: 'root'
})
export class GestionNotasService {
  myAppUrl = 'https://localhost:44346/';
  apiNota = 'api/nota/';
  apiMateria = 'api/Materia/';
  apiAlumno = 'api/Alumno/';
  PromedioNotasList: PromedioNotasList[];
  NotasList: Notas[];
  MateriasList: Materias[];

  constructor(private http: HttpClient) { }

  guardarRegitro(Notas: Notas): Observable<Notas> {
    return this.http.post<Notas>(this.myAppUrl + this.apiNota, Notas);
  }
  obterNotasPromedio() {
    this.http.get(this.myAppUrl + this.apiNota + 'GETNotaPromedio').toPromise().then(
      data => {
        this.PromedioNotasList = data as PromedioNotasList[];
      });
  }
  obterNotas() {
    this.http.get(this.myAppUrl + this.apiNota).toPromise().then(
      data => {
        this.NotasList = data as Notas[];
      });
  }
  obtenerMaterias(): Observable<Materias[]> {
    return this.http.get<Materias[]>(this.myAppUrl + this.apiMateria);
  }
  obtenerAlumnos(): Observable<Alumnos[]> {
    return this.http.get<Alumnos[]>(this.myAppUrl + this.apiAlumno);
  }
}