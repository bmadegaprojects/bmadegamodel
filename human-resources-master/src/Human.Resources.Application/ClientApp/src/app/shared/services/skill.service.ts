import { HttpClient } from '@angular/common/http';
import { BaseService } from './base';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SkillModel } from 'src/app/model/skill/skill.model';

@Injectable({ providedIn: 'root' })
export class SkillService extends BaseService<SkillModel, SkillModel> {
  constructor(
    public http: HttpClient
  ) {
    super(http);
    this.endpoint = 'api/skill';
  }

  get(): Observable<any> {
    return this.getRequest<any>();
  }
}
