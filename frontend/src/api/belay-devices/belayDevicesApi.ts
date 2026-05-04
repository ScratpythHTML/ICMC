import { useMutation, useQuery } from '@tanstack/react-query';
import {
  addBelayDevice,
  deleteBelayDevice,
  getBelayDevice,
  updateBelayDevice,
} from './belayDevicesService';
import type {
  AddBelayDeviceRequest,
  BelayDeviceDto,
  UpdateBelayDeviceRequest,
} from './belayDevicesTypes';

export function useGetBelayDevice(id: number) {
  const query = useQuery<BelayDeviceDto>({
    queryKey: ['belay-devices', id],
    queryFn: () => getBelayDevice(id),
  });
  return query;
}

export function useAddBelayDevice() {
  const mutation = useMutation({
    mutationFn: (request: AddBelayDeviceRequest) => addBelayDevice(request),
  });
  return mutation;
}

export function useDeleteBelayDevice() {
  const mutation = useMutation({
    mutationFn: (id: number) => deleteBelayDevice(id),
  });
  return mutation;
}

export function useUpdateBelayDevice() {
  const mutation = useMutation({
    mutationFn: ({
      id,
      request,
    }: {
      id: number;
      request: UpdateBelayDeviceRequest;
    }) => updateBelayDevice(id, request),
  });
  return mutation;
}
