import queryClient from '@api/queryClient';
import { type QueryKey, useMutation, useQuery } from '@tanstack/react-query';
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

export function getUsersKey(id?: number): QueryKey {
  return ['users', id];
}

export function useGetUser(id: number) {
  const query = useQuery<UserDto>({
    queryKey: getUsersKey(id),
    queryFn: () => getUser(id),
  });
  return query;
}

export function useSearchUsers(request: SearchUsersRequest) {
  const query = useQuery<UserDto[]>({
    queryKey: getUsersKey(),
    queryFn: () => searchUsers(request),
  });
  return query;
}

export function useAddUser() {
  const mutation = useMutation({
    mutationFn: (request: AddUserRequest) => addUser(request),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: getUsersKey() });
    },
  });
  return mutation;
}

export function useDeleteUser() {
  const mutation = useMutation({
    mutationFn: (id: number) => deleteUser(id),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: getUsersKey() });
    },
  });
  return mutation;
}

export function useUpdateUser() {
  const mutation = useMutation({
    mutationFn: ({ id, request }: { id: number; request: UpdateUserRequest }) =>
      updateUser(id, request),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: getUsersKey() });
    },
  });
  return mutation;
}
