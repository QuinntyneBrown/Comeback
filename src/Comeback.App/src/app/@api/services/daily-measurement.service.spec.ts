import { TestBed } from '@angular/core/testing';

import { DailyMeasurementService } from './daily-measurement.service';

describe('DailyMeasurementService', () => {
  let service: DailyMeasurementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DailyMeasurementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
