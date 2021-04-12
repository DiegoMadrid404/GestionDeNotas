import { Component, OnInit } from '@angular/core';
import { GestionNotasService } from 'src/app/Services/gestion-notas.service';

@Component({
  selector: 'app-promedio-notas-list',
  templateUrl: './promedio-notas-list.component.html',
  styleUrls: ['./promedio-notas-list.component.css']
})
export class PromedioNotasListComponent implements OnInit {

  constructor(public GestionNotasService: GestionNotasService) { }

  ngOnInit(): void {
    this.GestionNotasService.obterNotasPromedio();
  }

}
