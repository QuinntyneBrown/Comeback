import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class NavigationService {

  constructor(
    private readonly _router: Router
  ) { }

  public redirectToDefault() {
    this._router.navigate(['/']);
  }
}
