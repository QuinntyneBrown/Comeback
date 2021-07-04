import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { DailyMeasurement } from '@api';
import { DailyMeasurementService } from '@api/services';
import { NavigationService } from '@core';
import { Subject } from 'rxjs';
import { takeUntil, tap } from 'rxjs/operators';

@Component({
  selector: 'app-create-daily-measurement',
  templateUrl: './create-daily-measurement.component.html',
  styleUrls: ['./create-daily-measurement.component.scss']
})
export class CreateDailyMeasurementComponent implements OnDestroy  {

  private readonly _destoryed$: Subject<void> = new Subject();

  public formControl = new FormControl();

  constructor(
    private readonly _dailyMeasurementService: DailyMeasurementService,
    private readonly _navigationService: NavigationService
  ) { }

  public save(dailyMeasurement: DailyMeasurement): void {
    this._dailyMeasurementService.create({
      dailyMeasurement
    })
    .pipe(
      takeUntil(this._destoryed$),
      tap(_ => this._navigationService.redirectToDefault())
    )
    .subscribe();
  }

  public cancel() {
    this._navigationService.redirectToDefault();
  }

  public ngOnDestroy() {
    this._destoryed$.next();
    this._destoryed$.complete();
  }

}
