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

import { Pizza } from '../models/pizza';

@Injectable({
  providedIn: 'root',
})
export class PizzaService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation searchPizza
   */
  static readonly SearchPizzaPath = '/Pizza';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `searchPizza$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  searchPizza$Plain$Response(params?: {
  }): Observable<StrictHttpResponse<Array<Pizza>>> {

    const rb = new RequestBuilder(this.rootUrl, PizzaService.SearchPizzaPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<Pizza>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `searchPizza$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  searchPizza$Plain(params?: {
  }): Observable<Array<Pizza>> {

    return this.searchPizza$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<Pizza>>) => r.body as Array<Pizza>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `searchPizza()` instead.
   *
   * This method doesn't expect any request body.
   */
  searchPizza$Response(params?: {
  }): Observable<StrictHttpResponse<Array<Pizza>>> {

    const rb = new RequestBuilder(this.rootUrl, PizzaService.SearchPizzaPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<Pizza>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `searchPizza$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  searchPizza(params?: {
  }): Observable<Array<Pizza>> {

    return this.searchPizza$Response(params).pipe(
      map((r: StrictHttpResponse<Array<Pizza>>) => r.body as Array<Pizza>)
    );
  }

  /**
   * Path part for operation findPizza
   */
  static readonly FindPizzaPath = '/Pizza/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `findPizza$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  findPizza$Plain$Response(params: {
    id: string;
  }): Observable<StrictHttpResponse<Pizza>> {

    const rb = new RequestBuilder(this.rootUrl, PizzaService.FindPizzaPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Pizza>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `findPizza$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  findPizza$Plain(params: {
    id: string;
  }): Observable<Pizza> {

    return this.findPizza$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Pizza>) => r.body as Pizza)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `findPizza()` instead.
   *
   * This method doesn't expect any request body.
   */
  findPizza$Response(params: {
    id: string;
  }): Observable<StrictHttpResponse<Pizza>> {

    const rb = new RequestBuilder(this.rootUrl, PizzaService.FindPizzaPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Pizza>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `findPizza$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  findPizza(params: {
    id: string;
  }): Observable<Pizza> {

    return this.findPizza$Response(params).pipe(
      map((r: StrictHttpResponse<Pizza>) => r.body as Pizza)
    );
  }

}
