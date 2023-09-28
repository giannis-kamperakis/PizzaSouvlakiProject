/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { Souvlaki } from '../models/souvlaki';

@Injectable({
  providedIn: 'root',
})
export class SouvlakiService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation searchSouvlaki
   */
  static readonly SearchSouvlakiPath = '/Souvlaki';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `searchSouvlaki$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  searchSouvlaki$Plain$Response(params?: {
  }): Observable<StrictHttpResponse<Array<Souvlaki>>> {

    const rb = new RequestBuilder(this.rootUrl, SouvlakiService.SearchSouvlakiPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<Souvlaki>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `searchSouvlaki$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  searchSouvlaki$Plain(params?: {
  }): Observable<Array<Souvlaki>> {

    return this.searchSouvlaki$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<Souvlaki>>) => r.body as Array<Souvlaki>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `searchSouvlaki()` instead.
   *
   * This method doesn't expect any request body.
   */
  searchSouvlaki$Response(params?: {
  }): Observable<StrictHttpResponse<Array<Souvlaki>>> {

    const rb = new RequestBuilder(this.rootUrl, SouvlakiService.SearchSouvlakiPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<Souvlaki>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `searchSouvlaki$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  searchSouvlaki(params?: {
  }): Observable<Array<Souvlaki>> {

    return this.searchSouvlaki$Response(params).pipe(
      map((r: StrictHttpResponse<Array<Souvlaki>>) => r.body as Array<Souvlaki>)
    );
  }

  /**
   * Path part for operation findSouvlaki
   */
  static readonly FindSouvlakiPath = '/Souvlaki/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `findSouvlaki$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  findSouvlaki$Plain$Response(params: {
    id: string;
  }): Observable<StrictHttpResponse<Souvlaki>> {

    const rb = new RequestBuilder(this.rootUrl, SouvlakiService.FindSouvlakiPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Souvlaki>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `findSouvlaki$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  findSouvlaki$Plain(params: {
    id: string;
  }): Observable<Souvlaki> {

    return this.findSouvlaki$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Souvlaki>) => r.body as Souvlaki)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `findSouvlaki()` instead.
   *
   * This method doesn't expect any request body.
   */
  findSouvlaki$Response(params: {
    id: string;
  }): Observable<StrictHttpResponse<Souvlaki>> {

    const rb = new RequestBuilder(this.rootUrl, SouvlakiService.FindSouvlakiPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Souvlaki>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `findSouvlaki$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  findSouvlaki(params: {
    id: string;
  }): Observable<Souvlaki> {

    return this.findSouvlaki$Response(params).pipe(
      map((r: StrictHttpResponse<Souvlaki>) => r.body as Souvlaki)
    );
  }

}
