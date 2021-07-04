import { Component, Input, OnInit } from '@angular/core';
import { DailyMeasurement, Goal } from '@api';

@Component({
  selector: 'app-goal-by-date-card',
  templateUrl: './goal-by-date-card.component.html',
  styleUrls: ['./goal-by-date-card.component.scss']
})
export class GoalByDateCardComponent {

  @Input() public goal: Goal;

  @Input() public dailyMeasurement: DailyMeasurement;

}
