import { useMutation, useQuery } from '@tanstack/react-query';
import { addRope, deleteRope, getRope, getRopes, updateRope } from './ropesService';
import type {
  AddRopeRequest,
  RopeDto,
  UpdateRopeRequest,
} from './ropesTypes';

export function useGetRope(id: number) {
  const query = useQuery<RopeDto>({
    queryKey: ['rope', id],
    queryFn: () => getRope(id),
  });
  return query;
}

export function useGetRopes(storageLocation: string) {
  const query = useQuery<RopeDto[]>({
    queryKey: ['ropes', storageLocation],
    queryFn: () => getRopes(storageLocation),
  });
  return query;
}

export function useAddRope() {
  const mutation = useMutation({
    mutationFn: (request: AddRopeRequest) => addRope(request),
  });
  return mutation;
}

export function useDeleteRope() {
  const mutation = useMutation({
    mutationFn: (id: number) => deleteRope(id),
  });
  return mutation;
}

export function useUpdateRope() {
  const mutation = useMutation({
    mutationFn: ({
      id,
      request,
    }: {
      id: number;
      request: UpdateRopeRequest;
    }) => updateRope(id, request),
  });
  return mutation;
}
