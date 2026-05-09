import { useMutation, useQuery } from '@tanstack/react-query';
import { addUser, deleteUser, getUser, updateUser } from './usersService';
import type {
  AddUserRequest,
  UpdateUserRequest,
  UserDto,
} from './usersTypes';

export function useGetUser(id: number) {
  const query = useQuery<UserDto>({
    queryKey: ['users', id],
    queryFn: () => getUser(id),
  });
  return query;
}

export function useAddUser() {
  const mutation = useMutation({
    mutationFn: (request: AddUserRequest) => addUser(request),
  });
  return mutation;
}

export function useDeleteUser() {
  const mutation = useMutation({
    mutationFn: (id: number) => deleteUser(id),
  });
  return mutation;
}

export function useUpdateUser() {
  const mutation = useMutation({
    mutationFn: ({
      id,
      request,
    }: {
      id: number;
      request: UpdateUserRequest;
    }) => updateUser(id, request),
  });
  return mutation;
}
