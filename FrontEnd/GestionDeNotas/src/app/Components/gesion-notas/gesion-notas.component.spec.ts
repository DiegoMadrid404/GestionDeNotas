import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GesionNotasComponent } from './gesion-notas.component';

describe('GesionNotasComponent', () => {
  let component: GesionNotasComponent;
  let fixture: ComponentFixture<GesionNotasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GesionNotasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GesionNotasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
