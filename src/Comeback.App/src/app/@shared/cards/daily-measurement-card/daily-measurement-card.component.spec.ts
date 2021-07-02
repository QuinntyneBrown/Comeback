import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DailyMeasurementCardComponent } from './daily-measurement-card.component';

describe('DailyMeasurementCardComponent', () => {
  let component: DailyMeasurementCardComponent;
  let fixture: ComponentFixture<DailyMeasurementCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DailyMeasurementCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DailyMeasurementCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
