import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginFormGroup: FormGroup;
  submit = false;

  constructor(private formbuilder: FormBuilder, private router: Router) {
    this.loginFormGroup = this.formbuilder.group({
      userName: ['', [Validators.required]],
      password: ['', [Validators.required]]
    })
  }

  getFormControl(formControlName: string) {
    return this.loginFormGroup.get(formControlName)
  }

  //login() {
  //  this.submit = true;
  //  if (this.loginFormGroup.valid && this.submit) {
  //    this.studentService.login(this.loginFormGroup.value).subscribe((data: any) => {
  //      this.saveToken(data.response)
  //      this.router.navigate(['/app-dashboard'])
  //      alert("Login successfully");
  //    })
  //  }
  //  else {
  //    alert("Form is not valid.");
  //  }

  //}
}
