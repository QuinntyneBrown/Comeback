import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateDailyMeasurementComponent } from './create-daily-measurement.component';

describe('CreateDailyMeasurementComponent', () => {
  let component: CreateDailyMeasurementComponent;
  let fixture: ComponentFixture<CreateDailyMeasurementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateDailyMeasurementComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateDailyMeasurementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
