import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PesquisanotasComponent } from './pesquisanotas.component';

describe('PesquisanotasComponent', () => {
  let component: PesquisanotasComponent;
  let fixture: ComponentFixture<PesquisanotasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PesquisanotasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PesquisanotasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
