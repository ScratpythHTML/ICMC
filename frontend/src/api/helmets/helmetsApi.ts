import { useMutation, useQuery } from '@tanstack/react-query';
import {
  addHelmet,
  deleteHelmet,
  getHelmet,
  getHelmets,
  updateHelmet,
} from './helmetsService';
import type {
  AddHelmetRequest,
  HelmetDto,
  UpdateHelmetRequest,
} from './helmetsTypes';

export function useGetHelmet(id: number) {
  const query = useQuery<HelmetDto>({
    queryKey: ['helmet', id],
    queryFn: () => getHelmet(id),
  });
  return query;
}

export function useGetHelmets(storageLocation: string) {
  const query = useQuery<HelmetDto[]>({
    queryKey: ['helmets', storageLocation],
    queryFn: () => getHelmets(storageLocation),
  });
  return query;
}

export function useAddHelmet() {
  const mutation = useMutation({
    mutationFn: (request: AddHelmetRequest) => addHelmet(request),
  });
  return mutation;
}

export function useDeleteHelmet() {
  const mutation = useMutation({
    mutationFn: (id: number) => deleteHelmet(id),
  });
  return mutation;
}

export function useUpdateHelmet() {
  const mutation = useMutation({
    mutationFn: ({
      id,
      request,
    }: {
      id: number;
      request: UpdateHelmetRequest;
    }) => updateHelmet(id, request),
  });
  return mutation;
}
