import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DailyMeasurement } from '@api';

@Component({
  selector: 'app-daily-measurement-card',
  templateUrl: './daily-measurement-card.component.html',
  styleUrls: ['./daily-measurement-card.component.scss']
})
export class DailyMeasurementCardComponent {

  @Output() readonly delete: EventEmitter<DailyMeasurement> = new EventEmitter();

  @Output() readonly edit: EventEmitter<DailyMeasurement> = new EventEmitter();

  @Input() dailyMeasurement: DailyMeasurement;
}
