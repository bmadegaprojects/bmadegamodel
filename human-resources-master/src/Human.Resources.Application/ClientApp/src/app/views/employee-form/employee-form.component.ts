import { Component, OnInit } from '@angular/core';
import { EmployeeModel } from 'src/app/model/employee/employee.model';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from 'src/app/shared/services/employee.service';
import { SkillService } from 'src/app/shared/services/skill.service';
import { GenderService } from 'src/app/shared/services/gender.service';
import * as moment from 'moment';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html'
})
export class EmployeeFormComponent implements OnInit {

  employee = new EmployeeModel();
  skills;
  genders;
  loading: boolean;

  constructor(
    private route: ActivatedRoute,
    private employeeService: EmployeeService,
    private skillService: SkillService,
    private genderService: GenderService,
    private router: Router,
    private toastr: ToastrService
  ) {
    this.route.params.subscribe(res => this.employee.id = !!res.id ? res.id : 0);
    console.log(this.employee.id);
  }

  loadEmployee() {
    this.loading = true;
    this.employeeService.getById(this.employee.id)
      .subscribe(result => {
        this.loading = false;
        if (result.success) {
          result.data.birthDate = moment(result.data.birthDate).format('DD/MM/YYYY');
          this.employee = result.data;
        }
      }, error => {
        this.loading = false;
        console.error(error);
      });
  }

  loadSkills() {
    this.skillService.get()
      .subscribe(result => {
        if (result.success) {
          this.skills = [...result.data];
        }
      }, error => {
        console.error(error);
      });
  }

  loadGenders() {
    this.genderService.get()
      .subscribe(result => {
        if (result.success) {
          this.genders = [...result.data];
        }
      }, error => {
        console.error(error);
      });
  }

  registerEmployee() {
    if (!this.employee.birthDate) {
      this.toastr.error('', 'Necessário preencher todos os campos obrigatórios.', { progressBar: true });
      return;
    }
    const d = this.employee.birthDate.split('/');
    const dateString = d[1] + '/' + d[0] + '/' + d[2];
    this.employee.birthDate = moment(new Date(dateString).setUTCHours(0, 0, 0, 0)).toISOString();

    if (this.employee.id > 0) {
      this.updateEmployee();
      return;
    }
    this.insertEmployee();
  }

  insertEmployee() {
    this.loading = true;
    this.employeeService.post(this.employee)
      .subscribe(result => {
        this.loading = false;
        if (result.success) {
          this.router.navigate(['']);
        }
      }, error => {
        this.loading = false;
        if (error && error.error) {
          error.error.forEach(e => this.toastr.error('', e.Message, { progressBar: true }));
          return;
        }
        this.toastr.error('', 'Erro ao salvar, contate o administrador.', { progressBar: true });
      });
  }

  updateEmployee() {
    this.loading = true;
    this.employeeService.put(this.employee)
      .subscribe(result => {
        this.loading = false;
        if (result.success) {
          this.router.navigate(['']);
        }
      }, error => {
        this.loading = false;
        if (error && error.error) {
          error.error.forEach(e => this.toastr.error('', e.Message, { progressBar: true }));
          return;
        }
        this.toastr.error('', 'Erro ao salvar, contate o administrador.', { progressBar: true });
      });
  }

  async ngOnInit() {
    if (this.employee.id > 0) {
      await this.loadEmployee();
    }
    this.loadGenders();
    this.loadSkills();
  }
}
