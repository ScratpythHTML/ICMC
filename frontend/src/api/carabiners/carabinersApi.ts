import { useMutation, useQuery } from '@tanstack/react-query';
import {
  addCarabiner,
  deleteCarabiner,
  getCarabiner,
  updateCarabiner,
} from './carabinersService';
import type {
  AddCarabinerRequest,
  CarabinerDto,
  UpdateCarabinerRequest,
} from './carabinersTypes';

export function useGetCarabiner(id: number) {
  const query = useQuery<CarabinerDto>({
    queryKey: ['carabiners', id],
    queryFn: () => getCarabiner(id),
  });
  return query;
}

export function useAddCarabiner() {
  const mutation = useMutation({
    mutationFn: (request: AddCarabinerRequest) => addCarabiner(request),
  });
  return mutation;
}

export function useDeleteCarabiner() {
  const mutation = useMutation({
    mutationFn: (id: number) => deleteCarabiner(id),
  });
  return mutation;
}

export function useUpdateCarabiner() {
  const mutation = useMutation({
    mutationFn: ({
      id,
      request,
    }: {
      id: number;
      request: UpdateCarabinerRequest;
    }) => updateCarabiner(id, request),
  });
  return mutation;
}
