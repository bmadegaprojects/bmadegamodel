import { HttpClient } from '@angular/common/http';
import { BaseService } from './base';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SkillModel } from 'src/app/model/skill/skill.model';
import { GenderModel } from 'src/app/model/gender/gender.model';

@Injectable({ providedIn: 'root' })
export class GenderService extends BaseService<GenderModel, GenderModel> {
  constructor(
    public http: HttpClient
  ) {
    super(http);
    this.endpoint = 'api/gender';
  }

  get(): Observable<any> {
    return this.getRequest<any>();
  }
}
