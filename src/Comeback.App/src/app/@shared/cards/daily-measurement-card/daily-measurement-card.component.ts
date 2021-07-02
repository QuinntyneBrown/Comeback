import { Component, Input, OnInit } from '@angular/core';
import { DailyMeasurement } from '@api';

@Component({
  selector: 'app-daily-measurement-card',
  templateUrl: './daily-measurement-card.component.html',
  styleUrls: ['./daily-measurement-card.component.scss']
})
export class DailyMeasurementCardComponent {


  @Input() public dailyMeasurement: DailyMeasurement;
}
