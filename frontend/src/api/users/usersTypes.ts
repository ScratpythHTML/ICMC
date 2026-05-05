export interface AddUserRequest {
  CID?: string;
  FirstName?: string;
  SecondName?: string;
  UserEmail?: string;
  IsAdmin?: boolean;
}

export interface UpdateUserRequest {
  UserId: string;
  CID?: string;
  FirstName?: string;
  SecondName?: string;
  UserEmail?: string;
  IsAdmin?: boolean;
}

export interface UserDto {
  UserId: string;
  CID?: string;
  FirstName?: string;
  SecondName?: string;
  UserEmail?: string;
  IsAdmin?: boolean;
}
