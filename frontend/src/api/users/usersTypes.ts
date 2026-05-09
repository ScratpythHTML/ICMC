export interface AddUserRequest {
  CID: number;
  FirstName?: string;
  SecondName?: string;
  UserEmail?: string;
  IsAdmin?: boolean;
}

export interface UpdateUserRequest {
  CID: number;
  FirstName?: string;
  SecondName?: string;
  UserEmail?: string;
  IsAdmin?: boolean;
}

export interface UserDto {
  CID: number;
  FirstName?: string;
  SecondName?: string;
  UserEmail?: string;
  IsAdmin?: boolean;
}
