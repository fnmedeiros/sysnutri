import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfissionaisNovoComponent } from './profissionais-novo.component';

describe('ProfissionaisNovoComponent', () => {
  let component: ProfissionaisNovoComponent;
  let fixture: ComponentFixture<ProfissionaisNovoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfissionaisNovoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfissionaisNovoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
