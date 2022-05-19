import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";


export class UserData {
    email: string = '';
    password: string = '';
    gender: string = 'Male';
    age: number = 0;
    userId: number = 0;
    roleId: number = 0;
    reservationCount: number = 0;
    
}