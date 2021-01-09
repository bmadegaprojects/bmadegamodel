import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

export abstract class BaseService<TResult, TInput> {
  public endpoint: string;
  constructor(public http: HttpClient) { }

  get(): Observable<TResult[]> {
    return this.getRequest<TResult>();
  }

  protected getRequest<T>() {
    return this.http.get<T[]>(`${environment.api}${this.endpoint}`);
  }

  getById(id: Number): Observable<TResult> {
    return this.http.get<TResult>(`${environment.api}${this.endpoint}/${id}`);
  }

  post(model: TInput): Observable<TResult> {
    return this.http.post<TResult>(`${environment.api}${this.endpoint}`, model, {});
  }

  put(model: TInput): Observable<TResult> {
    return this.http.put<TResult>(`${environment.api}${this.endpoint}`, model, {});
  }
}
