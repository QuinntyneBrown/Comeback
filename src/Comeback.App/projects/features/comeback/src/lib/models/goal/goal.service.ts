// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BASE_URL } from '../../constants';
import { map, Observable } from 'rxjs';
import { Goal } from './goal';
import { IPagableService } from '../../kernel/ipagable-service';
import { EntityPage } from '../../kernel/entity-page';

@Injectable({
  providedIn: 'root'
})
export class GoalService implements IPagableService<Goal> {

  uniqueIdentifierName = "gaolId";

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Goal>> {
    return this._client.get<EntityPage<Goal>>(`${this._baseUrl}api/1.0/goal/page/${options.pageSize}/${options.pageIndex}`)
  }

  public getToday(): Observable<Goal> {
    return this._client.get<{ goal: Goal }>(`${this._baseUrl}api/1.0/goal/today`)
      .pipe(
        map(x => x.goal)
      );
  }

  public get(): Observable<Array<Goal>> {
    return this._client.get<{ goals: Array<Goal> }>(`${this._baseUrl}api/1.0/goal`)
      .pipe(
        map(x => x.goals)
      );
  }

  public getById(options: { goalId: string }): Observable<Goal> {
    return this._client.get<{ goal: Goal }>(`${this._baseUrl}api/1.0/goal/${options.goalId}`)
      .pipe(
        map(x => x.goal)
      );
  }

  public delete(options: { goal: Goal }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/1.0/goal/${options.goal.goalId}`);
  }

  public create(options: { goal: Goal }): Observable<{ goalId: string  }> {    
    return this._client.post<{ goalId: string }>(`${this._baseUrl}api/1.0/goal`, options.goal);
  }

  public update(options: { goal: Goal }): Observable<{ goalId: string }> {    
    return this._client.post<{ goalId: string }>(`${this._baseUrl}api/1.0/goal`, options.goal);
  }
}
