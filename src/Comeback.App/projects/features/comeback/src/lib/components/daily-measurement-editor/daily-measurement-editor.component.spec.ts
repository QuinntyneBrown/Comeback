// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DailyMeasurementEditorComponent } from './daily-measurement-editor.component';

describe('DailyMeasurementEditorComponent', () => {
  let component: DailyMeasurementEditorComponent;
  let fixture: ComponentFixture<DailyMeasurementEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ DailyMeasurementEditorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DailyMeasurementEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

