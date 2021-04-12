import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'
import { ToastrService } from 'ngx-toastr';
import { Alumnos } from 'src/app/Models/Alumnos';
import {  Materias } from 'src/app/Models/Materias';
import { Notas } from 'src/app/Models/Notas';
import { GestionNotasService } from 'src/app/Services/gestion-notas.service';



@Component({
  selector: 'app-notas',
  templateUrl: './notas.component.html',
  styleUrls: ['./notas.component.css']
})
export class NotasComponent implements OnInit {

  form: FormGroup;

  constructor(private formBuilder: FormBuilder, private gestionNotasService: GestionNotasService, private toastr: ToastrService) {
    this.form = this.formBuilder.group({
      id: 0,
      materia: ['', [Validators.required]],
      alumno: ['', [Validators.required]],

      calificacion: ['', [Validators.required, Validators.pattern(/^-?\d*[.,]?\d{0,2}$/), Validators.min(0), Validators.max(5)]]

    });
  }

  ngOnInit(): void {
    this.cargarCombos();
  }
  materiasList: Materias[];
  alumnoList: Alumnos[];

 
  cargarCombos() {

    this.gestionNotasService.obtenerMaterias().subscribe((respuesta) => {
      this.materiasList = respuesta;
      console.log(respuesta);
    });
    this.gestionNotasService.obtenerAlumnos().subscribe((respuesta) => {
      this.alumnoList = respuesta;
      console.log(respuesta);
    });

  }

  guardarRegitro() {
    const nota: Notas = {
      idAlumno: this.form.get('alumno').value,
      idMateria: this.form.get('materia').value,
      calificacion: this.form.get('calificacion').value.toString().trim().replace(",", ".")
    }
    this.gestionNotasService.guardarRegitro(nota).subscribe(data => {
      this.toastr.success('La calificación fue registrada', 'Gestión de notas');
      this.gestionNotasService.obterNotasPromedio();
      this.gestionNotasService.obterNotas();
      this.form.reset();
    })
  }
}



