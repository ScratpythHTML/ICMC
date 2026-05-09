import { MemberType } from '../common/enums';

export interface AddUserRequest {
  cid: number;
  email?: string;
  firstName?: string;
  surname?: string;
  isAdmin?: boolean;
  memberType?: MemberType;
}

export interface UpdateUserRequest {
  cid: number;
  email?: string;
  firstName?: string;
  surname?: string;
  isAdmin?: boolean;
  memberType?: MemberType;
}

export interface UserDto {
  cid: number;
  email?: string;
  firstName?: string;
  surname?: string;
  isAdmin?: boolean;
  memberType?: MemberType;
}
