import { useMutation, useQuery } from '@tanstack/react-query';
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
  const mutation = useMutation({
    mutationFn: (request: AddGearItemRequest) => addGearItem(request),
  });
  return mutation;
}

export function useDeleteGearItem() {
  const mutation = useMutation({
    mutationFn: (id: number) => deleteGearItem(id),
  });
  return mutation;
}

export function useUpdateGearItem() {
  const mutation = useMutation({
    mutationFn: ({
      id,
      request,
    }: {
      id: number;
      request: UpdateGearItemRequest;
    }) => updateGearItem(id, request),
  });
  return mutation;
}
