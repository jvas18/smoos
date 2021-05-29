import { Injectable, EventEmitter } from '@angular/core';
import { environment } from '../../../environments/environment';
import { ToastrService } from 'ngx-toastr';
import { FormArray, FormGroup, AbstractControl, FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';
import { SessionUser } from 'src/app/shared/models/session-user';
import { UserProfile } from 'src/app/shared/enums/user-profile.enum';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor(
    private toastrService: ToastrService) {
    this.forms = new CustomFormsService();
    this.toastr = new CustomToastrService(this.toastrService);
    this.dateUtils = new DateUtils();
  }

  public readonly ignoreStatusCodesHeaderKey = 'x-status-codes-to-ignore';

  forms: CustomFormsService;
  toastr: CustomToastrService;
  dateUtils: DateUtils;

  private _sessionUser: SessionUser;

  public get sessionUser(): SessionUser {
    if (!this._sessionUser) {
      let jsonUserData = localStorage.getItem(environment.localStore.user);
      this._sessionUser = jsonUserData ? JSON.parse(jsonUserData) : null;
    }
    return this._sessionUser;
  }

  sessionUserEvent = new EventEmitter<SessionUser>();

  storeUser(sessionUser: SessionUser) {
    this._sessionUser = sessionUser;
    this.sessionUserEvent.next(sessionUser);
    localStorage.setItem(environment.localStore.user, JSON.stringify(sessionUser));
  }

  removeUser() {
    localStorage.removeItem(environment.localStore.user);
    this._sessionUser = null;
    this.sessionUserEvent.next(null);
  }

  get accessToken(): string {
    return localStorage.getItem(environment.localStore.token);
  }

  storeAccessToken = (token: string) => localStorage.setItem(environment.localStore.token, token);

  removeAccessToken = () => localStorage.removeItem(environment.localStore.token);

  onFileChange($event, formGroup: any) {
    this.toBase64($event.target as HTMLInputElement).pipe().subscribe(resp => {
      if (formGroup && this.verifyExtension(resp.fileName)) {
        formGroup.get('name').setValue(resp.fileName);
        formGroup.get('buffer').setValue(resp.buffer);
        formGroup.get('contentType').setValue(resp.contentType);
      }
    });
  }

  private toBase64(file: HTMLInputElement): Observable<any> {
    const reader = new FileReader();
    const fileName = file.files[0].name;
    const contentType = file.files[0].type;

    reader.readAsBinaryString(file.files[0]);
    reader.onload = () => console.log(btoa(reader.result as string));

    return Observable.create(observer => {
      reader.onload = () => {
        observer.next({
          fileName,
          buffer: btoa(reader.result as string),
          contentType
        });
      }
      reader.onerror = error => observer.error(error);
    });
  }

  private verifyExtension(fileName: string) {
    const permitedExtensions = ['jpg', 'png', 'jpeg'];
    const extension = fileName.toLowerCase().split('.').pop();

    if (typeof permitedExtensions.find(
      function (ext) { return extension == ext; }) == 'undefined') {
      this.toastr.error(`Extensão ${extension} não permitida`);
      return false;
    }
    else { return true; }
  }

  order(array: any[], prop: string) {
    let aux = [...array];
    return array.sort(function (a, b) {
      let x = a[prop];
      let y = b[prop];

      if (typeof x == "string") {
        x = ("" + x).toLowerCase();
      }
      if (typeof y == "string") {
        y = ("" + y).toLowerCase();
      }

      return ((x < y) ? -1 : ((x > y) ? 1 : 0));
    });
  }

  validateProfile(profiles: UserProfile[]): boolean {
    if (this.sessionUser == null) { return false; }
    return profiles.indexOf(this.sessionUser.profile) >= 0;
  }

  copyToClipboard(value: string) {
    const selBox = document.createElement('textarea');
    selBox.style.position = 'fixed';
    selBox.style.left = '0';
    selBox.style.top = '0';
    selBox.style.opacity = '0';
    selBox.value = value;
    document.body.appendChild(selBox);
    selBox.focus();
    selBox.select();
    document.execCommand('copy');
    document.body.removeChild(selBox);
  }

  randomId = () => `${Math.random().toString(36).substring(2)}`;

  newUuid = () => {
    const d0 = Math.random() * 0xffffffff | 0;
    const d1 = Math.random() * 0xffffffff | 0;
    const d2 = Math.random() * 0xffffffff | 0;
    const d3 = Math.random() * 0xffffffff | 0;
    const lut = []; for (let i = 0; i < 256; i++) { lut[i] = (i < 16 ? '0' : '') + (i).toString(16); }
    return lut[d0 & 0xff] + lut[d0 >> 8 & 0xff] + lut[d0 >> 16 & 0xff] + lut[d0 >> 24 & 0xff] + '-' +
      lut[d1 & 0xff] + lut[d1 >> 8 & 0xff] + '-' + lut[d1 >> 16 & 0x0f | 0x40] + lut[d1 >> 24 & 0xff] + '-' +
      lut[d2 & 0x3f | 0x80] + lut[d2 >> 8 & 0xff] + '-' + lut[d2 >> 16 & 0xff] + lut[d2 >> 24 & 0xff] +
      lut[d3 & 0xff] + lut[d3 >> 8 & 0xff] + lut[d3 >> 16 & 0xff] + lut[d3 >> 24 & 0xff];
  }

  imgUrlNoCache(src?: string) {
    if (!src) { return null; }
    return `${src}?random=${this.randomId()}`;
  }

  getHttpHeaderIgnore(...statusCodesToIgnore: string[]): HttpHeaders {
    let data= {};
    data[this.ignoreStatusCodesHeaderKey] = statusCodesToIgnore.map(x => x).join(',');
    return new HttpHeaders(data);
  }


  retrieveFilterGrid(key: string, form?: FormGroup) {
    const serializedFilter = localStorage.getItem(key);
    const filter = serializedFilter != null ? JSON.parse(serializedFilter) : null;
    if (form && filter) form.patchValue(filter);
    return {
      ...filter || {},
      pageIndex: filter?.pageIndex ? parseInt(filter.pageIndex) : 1
    };
  }

  removeFilterGrid(key: string) {
    localStorage.removeItem(key);
  }

}

class CustomToastrService {

  constructor(private toastrService: ToastrService) {

  }

  private readonly defaultTitle: string = 'Atenção';

  success = (message: string, title?: string) => setTimeout(() => this.toastrService.success(message, title || this.defaultTitle));

  error = (message: string, title?: string) => setTimeout(() => this.toastrService.error(message, title || this.defaultTitle));

  info = (message: string, title?: string) => setTimeout(() => this.toastrService.info(message, title || this.defaultTitle));

  warning = (message: string, title?: string) => setTimeout(() => this.toastrService.warning(message, title || this.defaultTitle));

  clear = () => setTimeout(() => this.toastrService.clear());
}


class DateUtils {
  toDate(value?: any) {
    if (!value) return null;
    let dateValue: Date;
    if (!(value instanceof Date)) {
      dateValue = new Date(value);
    }
    return dateValue;
  }

  getUTCJsonData(value?: any) {
    if (!value || value == null) return null;
    let date: Date = (value instanceof Date) ? value : this.toDate(value);
    let utc = new Date(date.getTime() + date.getTimezoneOffset() * 60000);
    return utc.toJSON();
  }


  getJsonData(value?: any): string {
    if (!value) return null;
    let date: Date = value == null ? new Date() : (value instanceof Date) ? value : this.toDate(value);
    return date.toJSON();
  }

  toDateStr(value?: any): string {
    if (!value || value == null) return null;
    let date: Date = (value instanceof Date) ? value : this.toDate(value);
    return date.toISOString().split("T")[0]
  }


}

class CustomFormsService {

  date: DateUtils = new DateUtils();

  clearFormArray(formArray: FormArray) {
    while (formArray.controls.length > 0) {
      formArray.removeAt(0);
    }
  }

  fill(form: FormGroup, data: any) {
    for (let key in form.controls) {
      if (form.controls[key] instanceof FormArray) {
        continue;
      }
      if (form.controls[key] instanceof FormGroup) {
        this.fill(form.controls[key] as FormGroup, data[key]);
      }
      else {
        form.controls[key].setValue(data == null ? null : data[key] == null ? null : data[key]);
      }
    }
  }

  clear(form: FormGroup) {
    for (let key in form.controls) {
      if (form.controls[key] instanceof FormArray) {
        this.clearFormArray(form.controls[key] as FormArray);
        continue;
      }
      if (form.controls[key] instanceof FormGroup) {
        this.clear(form.controls[key] as FormGroup)
      }
      else {
        form.controls[key].setValue(null);
      }
    }
  }

  toJsonDate(form: FormGroup, ...props: string[]) {
    for (let p in props) {
      this.controlValueToJsonDate(form.controls[props[p]]);
    }
  }

  controlValueToJsonDate(control: AbstractControl) {
    control.setValue(this.date.getUTCJsonData(control.value));
  }

  removeValidator(control: AbstractControl) {
    control.setValue('');
    control.clearValidators();
    control.setErrors(null);
    control.setValidators(null);
    control.updateValueAndValidity();
  }

  addValidators(control: AbstractControl, ...validators: any) {
    control.setValidators(validators);
    control.updateValueAndValidity();
  }
}

