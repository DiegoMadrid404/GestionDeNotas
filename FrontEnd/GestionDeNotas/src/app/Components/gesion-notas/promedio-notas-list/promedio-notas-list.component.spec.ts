import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PromedioNotasListComponent } from './promedio-notas-list.component';

describe('PromedioNotasListComponent', () => {
  let component: PromedioNotasListComponent;
  let fixture: ComponentFixture<PromedioNotasListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PromedioNotasListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PromedioNotasListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
