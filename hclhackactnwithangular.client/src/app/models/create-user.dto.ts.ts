export interface UserDataDto {
  firstName: string;
  lastName: string;
  staffRole: string;
  department: string;
  email: string;
  phoneNumber: string;
  weeklyShiftLimit: number;
  hireDate: string; // Use string for dates when posting from Angular
  isActive: boolean;
}

export interface CreateUserDto {
  username: string;
  passwordHash: string;
  role: string;
  userData: UserDataDto;
}
