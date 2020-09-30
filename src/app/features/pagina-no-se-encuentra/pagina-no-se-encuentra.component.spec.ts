import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PaginaNoSeEncuentraComponent } from './pagina-no-se-encuentra.component';

describe('PaginaNoSeEncuentraComponent', () => {
  let component: PaginaNoSeEncuentraComponent;
  let fixture: ComponentFixture<PaginaNoSeEncuentraComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PaginaNoSeEncuentraComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PaginaNoSeEncuentraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
