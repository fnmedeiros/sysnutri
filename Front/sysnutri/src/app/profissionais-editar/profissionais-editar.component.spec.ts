import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfissionaisEditarComponent } from './profissionais-editar.component';

describe('ProfissionaisEditarComponent', () => {
  let component: ProfissionaisEditarComponent;
  let fixture: ComponentFixture<ProfissionaisEditarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfissionaisEditarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfissionaisEditarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
