import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { DailyMeasurement } from '@api';
import { DailyMeasurementService } from '@api/services';

@Component({
  selector: 'app-create-daily-measurement',
  templateUrl: './create-daily-measurement.component.html',
  styleUrls: ['./create-daily-measurement.component.scss']
})
export class CreateDailyMeasurementComponent  {

  public formControl = new FormControl();

  constructor(
    private readonly _dailyMeasurementService: DailyMeasurementService
  ) { }

  save(dailyMeasurement: DailyMeasurement): void {

    this._dailyMeasurementService.create({
      dailyMeasurement
    }).subscribe();
  }

}
