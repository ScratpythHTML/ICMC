export interface AddUserRequest {
  cid: number;
  firstName?: string;
  secondName?: string;
  userEmail?: string;
  isAdmin?: boolean;
}

export interface UpdateUserRequest {
  cid: number;
  firstName?: string;
  secondName?: string;
  userEmail?: string;
  isAdmin?: boolean;
}

export interface UserDto {
  cid: number;
  firstName?: string;
  secondName?: string;
  userEmail?: string;
  isAdmin?: boolean;
}
