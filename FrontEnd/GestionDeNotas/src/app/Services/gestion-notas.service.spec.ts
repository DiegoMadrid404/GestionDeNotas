import { TestBed } from '@angular/core/testing';

import { GestionNotasService } from './gestion-notas.service';

describe('GestionNotasService', () => {
  let service: GestionNotasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GestionNotasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
