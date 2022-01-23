import { Component, ElementRef, forwardRef, Input, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { AbstractControl, ControlValueAccessor, FormArray, FormControl, FormGroup, NG_VALIDATORS, NG_VALUE_ACCESSOR, ValidationErrors, Validator, Validators } from '@angular/forms';
import { takeUntil, tap } from 'rxjs/operators';
import { fromEvent, Subject } from 'rxjs';

@Component({
  selector: 'app-daily-measurement-editor',
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
  ]
})
export class DailyMeasurementEditorComponent implements ControlValueAccessor,  Validator, OnDestroy  {
  private readonly _destroyed$: Subject<void> = new Subject();

  readonly form = new FormGroup({
    dailyMeasurementId: new FormControl(null, []),
    date: new FormControl(null, [Validators.required]),
    weight: new FormControl(null, [Validators.required]),
  });

  constructor(
    private readonly _elementRef: ElementRef
  ) { }

  validate(control: AbstractControl): ValidationErrors | null {
      return this.form.valid ? null
      : Object.keys(this.form.controls).reduce(
          (accumulatedErrors, formControlName) => {
            const errors: ValidationErrors = { ...accumulatedErrors };

            const controlErrors = this.form.controls[formControlName].errors;

            if (controlErrors) {
              errors[formControlName] = controlErrors;
            }

            return errors;
          },
          {}
        );
  }

  writeValue(obj: any): void {
    if(obj == null) {
      this.form.reset();
    }
    else {
        this.form.patchValue(obj, { emitEvent: false });
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
    this._elementRef.nativeElement
      .querySelectorAll("*")
      .forEach((element: HTMLElement) => {
        fromEvent(element, "focus")
          .pipe(
            takeUntil(this._destroyed$),
            tap(x => fn())
          )
          .subscribe();
      });
  }

  setDisabledState?(isDisabled: boolean): void {
    isDisabled ? this.form.disable() : this.form.enable();
  }

  ngOnDestroy() {
    this._destroyed$.next();
    this._destroyed$.complete();
  }
}
