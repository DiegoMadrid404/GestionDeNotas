import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'
import { ToastrService } from 'ngx-toastr';
import { Notas } from 'src/app/Models/Notas';
import { GestionNotasService } from 'src/app/Services/gestion-notas.service';

@Component({
  selector: 'app-notas',
  templateUrl: './notas.component.html',
  styleUrls: ['./notas.component.css']
})
export class NotasComponent implements OnInit {

  form: FormGroup;

  constructor(private formBuilder: FormBuilder, private gestionNotasService: GestionNotasService, private toastr:ToastrService) {
    this.form = this.formBuilder.group({
      id: 0,
      materia: ['', [Validators.required]],
      alumno: ['', [Validators.required]],

      calificacion: ['', [Validators.required, Validators.pattern(/^-?\d*[.,]?\d{0,2}$/), Validators.min(0), Validators.max(5)]]

    });
  }

  ngOnInit(): void {
  }
  guardarRegitro() {

    const nota: Notas = {
      IdAlumno: this.form.get('alumno').value,
      IdMateria: this.form.get('materia').value,
      Calificacion: this.form.get('calificacion').value,
    }
    this.gestionNotasService.guardarRegitro(nota).subscribe(data => {
      this.toastr.success('La calificación fue registrada','Gestión de notas');
      this.form.reset();
    })
  }
}


