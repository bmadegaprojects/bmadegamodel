import { HttpClient } from '@angular/common/http';
import { BaseService } from './base';
import { EmployeeModel } from '../../model/employee/employee.model';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class EmployeeService extends BaseService<EmployeeModel, EmployeeModel> {
  constructor(
    public http: HttpClient
  ) {
    super(http);
    this.endpoint = 'api/employee';
  }

  get(): Observable<any> {
    return this.getRequest<any>();
  }

  getById(id: Number): Observable<any> {
    return this.http.get(`${environment.api}${this.endpoint}/${id}`);
  }

  post(model: any): Observable<any> {
    return this.http.post<any>(`${environment.api}${this.endpoint}`, model, {});
  }

  put(model: any): Observable<any> {
    return this.http.put<any>(`${environment.api}${this.endpoint}`, model, {});
  }

  putStatus(model: any): Observable<any> {
    return this.http.put<any>(`${environment.api}${this.endpoint}/status`, model, {});
  }
}
