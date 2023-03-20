// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BASE_URL } from '../../constants';
import { map, Observable } from 'rxjs';
import { DailyMeasurement } from './daily-measurement';

@Injectable({
  providedIn: 'root'
})
export class DailyMeasurementService {

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  public getToday(): Observable<DailyMeasurement> {
    return this._client.get<{ dailyMeasurement: DailyMeasurement }>(`${this._baseUrl}api/1.0/dailyMeasurement/today`)
      .pipe(
        map(x => x.dailyMeasurement)
      );
  }  

  public get(): Observable<Array<DailyMeasurement>> {
    return this._client.get<{ dailyMeasurements: Array<DailyMeasurement> }>(`${this._baseUrl}api/1.0/dailyMeasurement`)
      .pipe(
        map(x => x.dailyMeasurements)
      );
  }

  public getById(options: { dailyMeasurementId: string }): Observable<DailyMeasurement> {
    return this._client.get<{ dailyMeasurement: DailyMeasurement }>(`${this._baseUrl}api/1.0/dailyMeasurement/${options.dailyMeasurementId}`)
      .pipe(
        map(x => x.dailyMeasurement)
      );
  }

  public delete(options: { dailyMeasurement: DailyMeasurement }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/1.0/dailyMeasurement/${options.dailyMeasurement.dailyMeasurementId}`);
  }

  public create(options: { dailyMeasurement: DailyMeasurement }): Observable<{ dailyMeasurementId: string  }> {    
    return this._client.post<{ dailyMeasurementId: string }>(`${this._baseUrl}api/1.0/dailyMeasurement`,  options.dailyMeasurement);
  }

  public update(options: { dailyMeasurement: DailyMeasurement }): Observable<{ dailyMeasurementId: string }> {    
    return this._client.post<{ dailyMeasurementId: string }>(`${this._baseUrl}api/1.0/dailyMeasurement`, options.dailyMeasurement);
  }
}
