// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ChangeDetectionStrategy, Component, ElementRef, forwardRef, inject, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PushModule } from '@ngrx/component';
import { AbstractControl, ControlValueAccessor, FormGroup, NG_VALIDATORS, NG_VALUE_ACCESSOR, ReactiveFormsModule, ValidationErrors, Validator } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatMomentDateModule } from '@angular/material-moment-adapter';
import { MatFormFieldModule } from '@angular/material/form-field';
import { fromEvent, Subject, takeUntil, tap } from 'rxjs';

@Component({
  selector: 'app-daily-measurement-editor',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './daily-measurement-editor.component.html',
  styleUrls: ['./daily-measurement-editor.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => DailyMeasurementEditorComponent),
      multi: true
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => DailyMeasurementEditorComponent),
      multi: true
    }       
  ],
  imports: [
    CommonModule, 
    PushModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatMomentDateModule    
  ]
})
export class DailyMeasurementEditorComponent implements ControlValueAccessor, Validator, OnDestroy {

  private readonly _destroyed$: Subject<void> = new Subject();
  
  private readonly _elementRef = inject(ElementRef<HTMLElement>);

  validate(control: AbstractControl): ValidationErrors | any {
    return this.form.valid 
    ? null
    : Object.keys(this.form.controls).reduce((accumulatedErrors,formControlName) => { 
      const errors = {...accumulatedErrors} as any;
      
      const controlErrors = this.form.controls[formControlName].errors;

      if (controlErrors) {
        errors[formControlName] = controlErrors;
      }
      
      return errors;
    }, { });      
  }

  public form = new FormGroup<any>({

  });

  writeValue(obj: any): void {
    if(obj) {
      this.form.patchValue(obj);
    }
  }

  registerOnChange(fn: any): void {
    this.form.valueChanges
    .pipe(
      takeUntil(this._destroyed$)
    )
    .subscribe(fn);
  }

  registerOnTouched(fn: any): void {  
    this._elementRef.nativeElement.querySelectorAll("*").forEach(
      (element: HTMLElement) => {
        fromEvent(element,"blur")
        .pipe(
          takeUntil(this._destroyed$),
          tap(x => fn())
        ).subscribe();
      }
    )    
  }

  setDisabledState?(isDisabled: boolean): void {
    isDisabled ? this.form.disable() : this.form.enable();
  }

  ngOnDestroy() {
    this._destroyed$.next();
    this._destroyed$.complete();
  }
}
