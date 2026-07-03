import { TestBed } from '@angular/core/testing';

import { Conferencia } from './conferencia';

describe('Conferencia', () => {
  let service: Conferencia;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Conferencia);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
