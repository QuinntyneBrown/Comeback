// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComebackComponent } from './comeback.component';

describe('ComebackComponent', () => {
  let component: ComebackComponent;
  let fixture: ComponentFixture<ComebackComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ ComebackComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ComebackComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

