import { MemberType } from '../common/enums';

export interface AddUserRequest {
  cid: string;
  email?: string;
  firstName?: string;
  surname?: string;
  isAdmin?: boolean;
  memberType?: MemberType;
}

export interface UpdateUserRequest {
  cid: string;
  email?: string;
  firstName?: string;
  surname?: string;
  isAdmin?: boolean;
  memberType?: MemberType;
}

export interface UserDto {
  cid: string;
  email?: string;
  firstName?: string;
  surname?: string;
  isAdmin?: boolean;
  memberType?: MemberType;
}
