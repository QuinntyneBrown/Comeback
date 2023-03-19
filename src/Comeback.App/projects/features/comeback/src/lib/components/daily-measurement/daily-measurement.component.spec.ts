// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DailyMeasurementComponent } from './daily-measurement.component';

describe('DailyMeasurementComponent', () => {
  let component: DailyMeasurementComponent;
  let fixture: ComponentFixture<DailyMeasurementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ DailyMeasurementComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DailyMeasurementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

