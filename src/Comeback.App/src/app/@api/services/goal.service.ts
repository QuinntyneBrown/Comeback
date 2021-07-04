import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Goal } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class GoalService implements IPagableService<Goal> {

  uniqueIdentifierName: string = "goalId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Goal>> {
    return this._client.get<EntityPage<Goal>>(`${this._baseUrl}api/goal/page/${options.pageSize}/${options.pageIndex}`)
  }

  public getToday(): Observable<Goal> {
    return this._client.get<{ goal: Goal }>(`${this._baseUrl}api/goal/today`)
      .pipe(
        map(x => x.goal)
      );
  }

  public get(): Observable<Goal[]> {
    return this._client.get<{ goals: Goal[] }>(`${this._baseUrl}api/goal`)
      .pipe(
        map(x => x.goals)
      );
  }

  public getById(options: { goalId: string }): Observable<Goal> {
    return this._client.get<{ goal: Goal }>(`${this._baseUrl}api/goal/${options.goalId}`)
      .pipe(
        map(x => x.goal)
      );
  }

  public remove(options: { goal: Goal }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/goal/${options.goal.goalId}`);
  }

  public create(options: { goal: Goal }): Observable<{ goal: Goal }> {
    return this._client.post<{ goal: Goal }>(`${this._baseUrl}api/goal`, { goal: options.goal });
  }

  public update(options: { goal: Goal }): Observable<{ goal: Goal }> {
    return this._client.put<{ goal: Goal }>(`${this._baseUrl}api/goal`, { goal: options.goal });
  }
}
