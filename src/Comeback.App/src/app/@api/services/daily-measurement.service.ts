import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { DailyMeasurement } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class DailyMeasurementService implements IPagableService<DailyMeasurement> {

  uniqueIdentifierName: string = "dailyMeasurementId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  public getToday(): Observable<DailyMeasurement> {
    return this._client.get<{ dailyMeasurement: DailyMeasurement }>(`${this._baseUrl}api/dailyMeasurement/today`)
      .pipe(
        map(x => x.dailyMeasurement)
      );
  }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<DailyMeasurement>> {
    return this._client.get<EntityPage<DailyMeasurement>>(`${this._baseUrl}api/dailyMeasurement/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<DailyMeasurement[]> {
    return this._client.get<{ dailyMeasurements: DailyMeasurement[] }>(`${this._baseUrl}api/dailyMeasurement`)
      .pipe(
        map(x => x.dailyMeasurements)
      );
  }

  public getById(options: { dailyMeasurementId: string }): Observable<DailyMeasurement> {
    return this._client.get<{ dailyMeasurement: DailyMeasurement }>(`${this._baseUrl}api/dailyMeasurement/${options.dailyMeasurementId}`)
      .pipe(
        map(x => x.dailyMeasurement)
      );
  }

  public remove(options: { dailyMeasurement: DailyMeasurement }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/dailyMeasurement/${options.dailyMeasurement.dailyMeasurementId}`);
  }

  public create(options: { dailyMeasurement: DailyMeasurement }): Observable<{ dailyMeasurement: DailyMeasurement }> {
    return this._client.post<{ dailyMeasurement: DailyMeasurement }>(`${this._baseUrl}api/dailyMeasurement`, { dailyMeasurement: options.dailyMeasurement });
  }

  public update(options: { dailyMeasurement: DailyMeasurement }): Observable<{ dailyMeasurement: DailyMeasurement }> {
    return this._client.put<{ dailyMeasurement: DailyMeasurement }>(`${this._baseUrl}api/dailyMeasurement`, { dailyMeasurement: options.dailyMeasurement });
  }
}
