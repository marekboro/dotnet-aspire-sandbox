import { HttpClient, HttpHandler } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class AspireServerApiHttpClient extends HttpClient {
  public baseUrl: string;

  public constructor(handler: HttpHandler) {
    super(handler);
    this.baseUrl = 'http://localhost:5512';
  }

  public override get(url: string, options?: Object): Observable<any> {
    url = this.baseUrl + url;
    console.log('Url:', url);
    return super.get(url, options);
  }
}
