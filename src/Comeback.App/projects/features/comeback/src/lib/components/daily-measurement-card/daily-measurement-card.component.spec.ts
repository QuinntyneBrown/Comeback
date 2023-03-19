// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DailyMeasurementCardComponent } from './daily-measurement-card.component';

describe('DailyMeasurementCardComponent', () => {
  let component: DailyMeasurementCardComponent;
  let fixture: ComponentFixture<DailyMeasurementCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ DailyMeasurementCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DailyMeasurementCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

