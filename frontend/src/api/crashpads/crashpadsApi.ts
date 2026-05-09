import { useMutation, useQuery } from '@tanstack/react-query';
import { StorageLocation } from '../common/enums';
import {
  addCrashpad,
  deleteCrashpad,
  getCrashpad,
  getCrashpads,
  updateCrashpad,
} from './crashpadsService';
import type {
  AddCrashpadRequest,
  CrashpadDto,
  UpdateCrashpadRequest,
} from './crashpadsTypes';

export function useGetCrashpad(id: number) {
  const query = useQuery<CrashpadDto>({
    queryKey: ['crashpad', id],
    queryFn: () => getCrashpad(id),
  });
  return query;
}

export function useGetCrashpads(storageLocation: StorageLocation) {
  const query = useQuery<CrashpadDto[]>({
    queryKey: ['crashpads', storageLocation],
    queryFn: () => getCrashpads(storageLocation),
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
