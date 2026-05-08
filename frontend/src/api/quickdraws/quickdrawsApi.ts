import { useMutation, useQuery } from '@tanstack/react-query';
import {
  addQuickdraw,
  deleteQuickdraw,
  getQuickdraw,
  getQuickdraws,
  updateQuickdraw,
} from './quickdrawsService';
import type {
  AddQuickdrawRequest,
  QuickdrawDto,
  UpdateQuickdrawRequest,
} from './quickdrawsTypes';

export function useGetQuickdraw(id: number) {
  const query = useQuery<QuickdrawDto>({
    queryKey: ['quickdraw', id],
    queryFn: () => getQuickdraw(id),
  });
  return query;
}

export function useGetQuickdraws(storageLocation: string) {
  const query = useQuery<QuickdrawDto[]>({
    queryKey: ['quickdraws', storageLocation],
    queryFn: () => getQuickdraws(storageLocation),
  });
  return query;
}

export function useAddQuickdraw() {
  const mutation = useMutation({
    mutationFn: (request: AddQuickdrawRequest) => addQuickdraw(request),
  });
  return mutation;
}

export function useDeleteQuickdraw() {
  const mutation = useMutation({
    mutationFn: (id: number) => deleteQuickdraw(id),
  });
  return mutation;
}

export function useUpdateQuickdraw() {
  const mutation = useMutation({
    mutationFn: ({
      id,
      request,
    }: {
      id: number;
      request: UpdateQuickdrawRequest;
    }) => updateQuickdraw(id, request),
  });
  return mutation;
}
