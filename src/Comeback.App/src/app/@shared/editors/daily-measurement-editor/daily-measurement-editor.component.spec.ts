import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DailyMeasurementEditorComponent } from './daily-measurement-editor.component';

describe('DailyMeasurementEditorComponent', () => {
  let component: DailyMeasurementEditorComponent;
  let fixture: ComponentFixture<DailyMeasurementEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DailyMeasurementEditorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DailyMeasurementEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
