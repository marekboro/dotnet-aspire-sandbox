import { Injectable, inject } from '@angular/core';
import { combineLatest, map, Observable, timer } from 'rxjs';
import { AspireServerApiHttpClient } from '../apiHttpClient';
import { TestResponse } from '../models/testResponse';

@Injectable({ providedIn: 'root' })
export class ServerService {
  private aspireHttpClient = inject(AspireServerApiHttpClient);
  delayByMiliseconds$ = timer(1500);

  public getData1 = (): Observable<TestResponse> => {
    const data$ = this.aspireHttpClient.get('/api/get-test-one');

    return combineLatest([data$, this.delayByMiliseconds$]).pipe(
      map(([data, _]) => data),
    );
  };

  public getData2 = (): Observable<TestResponse> => {
    const data$ = this.aspireHttpClient.get('/api/get-test-two');

    return combineLatest([data$, this.delayByMiliseconds$]).pipe(
      map(([data, _]) => data),
    );
  };
}
