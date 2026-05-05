import { useMutation, useQuery } from '@tanstack/react-query';
import {
  addHarness,
  deleteHarness,
  getHarness,
  updateHarness,
} from './harnessesService';
import type {
  AddHarnessRequest,
  HarnessDto,
  UpdateHarnessRequest,
} from './harnessesTypes';

export function useGetHarness(id: number) {
  const query = useQuery<HarnessDto>({
    queryKey: ['harnesses', id],
    queryFn: () => getHarness(id),
  });
  return query;
}

export function useAddHarness() {
  const mutation = useMutation({
    mutationFn: (request: AddHarnessRequest) => addHarness(request),
  });
  return mutation;
}

export function useDeleteHarness() {
  const mutation = useMutation({
    mutationFn: (id: number) => deleteHarness(id),
  });
  return mutation;
}

export function useUpdateHarness() {
  const mutation = useMutation({
    mutationFn: ({
      id,
      request,
    }: {
      id: number;
      request: UpdateHarnessRequest;
    }) => updateHarness(id, request),
  });
  return mutation;
}
