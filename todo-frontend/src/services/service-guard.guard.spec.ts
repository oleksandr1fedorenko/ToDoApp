import { TestBed } from '@angular/core/testing';

import { ServiceGuardGuard } from './service-guard.guard';

describe('ServiceGuardGuard', () => {
  let guard: ServiceGuardGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(ServiceGuardGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
