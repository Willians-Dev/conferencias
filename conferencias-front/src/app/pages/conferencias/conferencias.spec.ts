import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Conferencias } from './conferencias';

describe('Conferencias', () => {
  let component: Conferencias;
  let fixture: ComponentFixture<Conferencias>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Conferencias],
    }).compileComponents();

    fixture = TestBed.createComponent(Conferencias);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
