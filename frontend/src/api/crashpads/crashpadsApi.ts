import { useMutation, useQuery } from '@tanstack/react-query';
import {
  addCrashpad,
  deleteCrashpad,
  getCrashpad,
  updateCrashpad,
} from './crashpadsService';
import type {
  AddCrashpadRequest,
  CrashpadDto,
  UpdateCrashpadRequest,
} from './crashpadsTypes';

export function useGetCrashpad(id: number) {
  const query = useQuery<CrashpadDto>({
    queryKey: ['crashpads', id],
    queryFn: () => getCrashpad(id),
  });
  return query;
}

export function useAddCrashpad() {
  const mutation = useMutation({
    mutationFn: (request: AddCrashpadRequest) => addCrashpad(request),
  });
  return mutation;
}

export function useDeleteCrashpad() {
  const mutation = useMutation({
    mutationFn: (id: number) => deleteCrashpad(id),
  });
  return mutation;
}

export function useUpdateCrashpad() {
  const mutation = useMutation({
    mutationFn: ({
      id,
      request,
    }: {
      id: number;
      request: UpdateCrashpadRequest;
    }) => updateCrashpad(id, request),
  });
  return mutation;
}
