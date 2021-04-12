import { Component, OnInit } from '@angular/core';
import { GestionNotasService } from 'src/app/Services/gestion-notas.service';


@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.css']
})
export class ListaComponent implements OnInit {


  constructor(public GestionNotasService: GestionNotasService) { }

  ngOnInit(): void {
    this.GestionNotasService.obterNotas();
  }

}
