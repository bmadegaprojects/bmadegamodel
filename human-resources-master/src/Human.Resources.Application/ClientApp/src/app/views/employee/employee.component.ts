import { Component, OnInit, ViewChild } from '@angular/core';
import { EmployeeService } from '../../shared/services/employee.service';
import * as moment from 'moment';
import { Table } from 'primeng/table';
import { SkillService } from 'src/app/shared/services/skill.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html'
})
export class EmployeeComponent implements OnInit {

  public employees: any[];
  skills: any[];
  genders: any[];
  skillsSelected: any[];
  cols: any[];
  loading = false;
  inputDate: Date;
  isActiveFilter;
  genderFilter;

  @ViewChild('dt', { static: false }) temployee: Table;

  constructor(
    private employeeService: EmployeeService,
    private skillService: SkillService
  ) {
  }

  loadHeader() {
    this.cols = [
      { field: 'isActive', header: 'Ativo' },
      { field: 'name', header: 'Nome' },
      { field: 'birthDate', header: 'Data de Nasc.' },
      { field: 'age', header: 'Idade' },
      { field: 'email', header: 'Email' },
      { field: 'gender.name', header: 'Sexo' },
      { field: 'skills', header: 'Habilidades' },
      { field: 'empty', header: '' },
    ];
  }

  loadEmployees() {
    this.loading = true;
    this.employeeService.get()
      .subscribe(result => {
        this.loading = false;
        if (result.success) {
          this.employees = result.data;
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

  changeStatus(employee) {
    employee.isActive = !employee.isActive;
    this.employeeService.putStatus(employee)
      .subscribe(result => {
        this.loading = false;
        if (result.success) {
        }
      }, error => {
        this.loading = false;
        console.error(error);
      });
  }

  resolveCellGrid(cell: any, str: any) {
    const resolve = function (cells: any, strs: any, i = 0) {
      if (cells[strs.split('.')[i]]) {
        if ((strs.split('.').length - 1) > i) {
          return resolve(cells[strs.split('.')[i]], strs, ++i);
        }
        return cells[strs.split('.')[i]];
      }
      return '';
    };
    return resolve(cell, str);
  }

  filterDate(date) {
    if (date.length === 10) {
      const d = date.split('/');
      const dateString = d[1] + '/' + d[0] + '/' + d[2];
      const dateIso = moment(new Date(dateString).setUTCHours(0, 0, 0, 0)).toISOString().split('.')[0];

      this.temployee.filter(dateIso, 'birthDate', 'contains');
    }

    if (date.length === 9) {
      this.loadEmployees();
    }
  }

  filterSkills() {
    this.temployee.filter(this.skillsSelected, 'skills', 'contains');
  }

  filterIsActive() {
    this.temployee.filter(this.isActiveFilter, 'isActive', 'contains');
  }

  filterGender() {
    this.temployee.filter(this.genderFilter, 'gender.id', 'contains');
  }

  ngOnInit() {
    this.loadEmployees();
    this.loadHeader();
    this.loadSkills();
  }
}
