import queryClient from '@api/queryClient';
import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query';
import {
  addUser,
  deleteUser,
  getUser,
  searchUsers,
  updateUser,
} from './usersService';
import type {
  AddUserRequest,
  SearchUsersRequest,
  UpdateUserRequest,
  UserDto,
} from './usersTypes';

export function getUsersKey(id?: number): any[] {
  return ['users', id];
}

export function useGetUser(id: number) {
  return useQuery<UserDto>({
    queryKey: getUsersKey(id),
    queryFn: () => getUser(id),
  });
}

export function useSearchUsers(request: SearchUsersRequest) {
  return useQuery<UserDto[]>({
    queryKey: ['users', request],
    queryFn: () => searchUsers(request),
    enabled: !!(request.cid || request.fullName || request.email),
  });
}

export function useAddUser() {
  const qc = useQueryClient();
  return useMutation({
    mutationFn: (request: AddUserRequest) => addUser(request),
    onSuccess: () => {
      qc.invalidateQueries({ queryKey: ['users'] });
    },
  });
}

export function useDeleteUser() {
  const qc = useQueryClient();
  return useMutation({
    mutationFn: (id: number) => deleteUser(id),
    onSuccess: () => {
      qc.invalidateQueries({ queryKey: ['users'] });
    },
  });
}

export function useUpdateUser() {
  const qc = useQueryClient();
  return useMutation({
    mutationFn: ({ id, request }: { id: number; request: UpdateUserRequest }) =>
      updateUser(id, request),
    onSuccess: () => {
      qc.invalidateQueries({ queryKey: ['users'] });
      qc.invalidateQueries({ queryKey: ['gear-items'] });
    },
  });
}
