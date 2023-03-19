// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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

