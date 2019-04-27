import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfissionaisDetalheComponent } from './profissionais-detalhe.component';

describe('ProfissionaisDetalheComponent', () => {
  let component: ProfissionaisDetalheComponent;
  let fixture: ComponentFixture<ProfissionaisDetalheComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfissionaisDetalheComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfissionaisDetalheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
