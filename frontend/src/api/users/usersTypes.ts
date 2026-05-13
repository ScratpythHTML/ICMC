import type { MemberType } from '@api/common/enums';

export interface AddUserRequest {
  cid: string;
  email?: string;
  fullName?: string;
  isAdmin?: boolean;
  memberType?: MemberType;
}

export interface SearchUsersRequest {
  cid?: string;
  email?: string;
  fullName?: string;
  isAdmin?: boolean;
  memberType?: MemberType;
}

export interface UpdateUserRequest {
  id: number;
  cid?: string;
  email?: string;
  fullName?: string;
  isAdmin?: boolean;
  memberType?: MemberType;
}

export interface UserDto {
  id: number;
  cid?: string;
  email?: string;
  fullName?: string;
  isAdmin?: boolean;
  memberType?: MemberType;
}
