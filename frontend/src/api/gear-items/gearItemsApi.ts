import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query';
import {
  addGearItem,
  deleteGearItem,
  getGearItem,
  getGearItems,
  updateGearItem,
} from './gearItemsService';
import type {
  AddGearItemRequest,
  GearItemDto,
  GetGearItemsRequest,
  UpdateGearItemRequest,
} from './gearItemsTypes';

export function useGetGearItem(id: number) {
  const query = useQuery<GearItemDto>({
    queryKey: ['gear-item', id],
    queryFn: () => getGearItem(id),
  });
  return query;
}

export function useGetGearItems(request: GetGearItemsRequest) {
  const query = useQuery<GearItemDto[]>({
    queryKey: ['gear-items', request.gearCategory, request.storageLocation],
    queryFn: () => getGearItems(request),
  });
  return query;
}

export function useAddGearItem() {
  const queryClient = useQueryClient();
  const mutation = useMutation({
    mutationFn: (request: AddGearItemRequest) => addGearItem(request),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['gear-items'] });
    },
  });
  return mutation;
}

export function useDeleteGearItem() {
  const queryClient = useQueryClient();
  const mutation = useMutation({
    mutationFn: (id: number) => deleteGearItem(id),
    onSuccess: (_, id) => {
      queryClient.invalidateQueries({ queryKey: ['gear-item', id] });
      queryClient.invalidateQueries({ queryKey: ['gear-items'] });
    },
  });
  return mutation;
}

export function useUpdateGearItem() {
  const queryClient = useQueryClient();
  const mutation = useMutation({
    mutationFn: ({
      id,
      request,
    }: {
      id: number;
      request: UpdateGearItemRequest;
    }) => updateGearItem(id, request),
    onSuccess: (_, variables) => {
      queryClient.invalidateQueries({ queryKey: ['gear-item', variables.id] });
      queryClient.invalidateQueries({ queryKey: ['gear-items'] });
    },
  });
  return mutation;
}
