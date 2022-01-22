import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { DailyMeasurement } from '@api';
import { DailyMeasurementService } from '@api/services';
import { NavigationService } from '@core';
import { combineLatest, of, Subject } from 'rxjs';
import { map, startWith, switchMap, tap } from 'rxjs/operators';

@Component({
  selector: 'app-daily-measurement',
  templateUrl: './daily-measurement.component.html',
  styleUrls: ['./daily-measurement.component.scss']
})
export class CreateDailyMeasurementComponent  {
  
  private readonly _cancelSubject: Subject<void> = new Subject();

  private readonly _cancel$ = this._cancelSubject.asObservable();

  private readonly _saveSubject: Subject<DailyMeasurement> = new Subject();

  private readonly _save$ = this._saveSubject.asObservable();

  readonly formControl = new FormControl();

  readonly vm$ = combineLatest([
    this._activatedRoute.paramMap,
    this._cancel$.pipe(tap(_ => this._navigationService.redirectToDefault()), startWith(null)),
    this._save$.pipe(switchMap(d => this._handleSave(d)), startWith(null))    
  ]) 
  .pipe(
    map(([paramMap]) => paramMap.get("id")),
    switchMap(dailyMeasurementId => dailyMeasurementId ? this._dailyMeasurementService.getById({ dailyMeasurementId }) : of(null)),
    map(dailyMeasurement => {
      return {
        formControl: new FormControl(dailyMeasurement,[])
      }
    })
  )

  constructor(
    private readonly _dailyMeasurementService: DailyMeasurementService,
    private readonly _navigationService: NavigationService,
    private readonly _activatedRoute: ActivatedRoute
  ) { }

  private _handleSave(dailyMeasurement: DailyMeasurement) {
    const obs$ = dailyMeasurement.dailyMeasurementId
    ? this._dailyMeasurementService.update({ dailyMeasurement})
    : this._dailyMeasurementService.create({
      dailyMeasurement
    });

    return obs$
    .pipe(
      tap(_ => this._navigationService.redirectToDefault())
    )
  }

  save(dailyMeasurement: DailyMeasurement) {
    this._saveSubject.next(dailyMeasurement);
  }

  cancel() {
    this._cancelSubject.next();
  }
}
