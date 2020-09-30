import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetallesCarroComponent } from './detalles-carro.component';

describe('DetallesCarroComponent', () => {
  let component: DetallesCarroComponent;
  let fixture: ComponentFixture<DetallesCarroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetallesCarroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetallesCarroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
