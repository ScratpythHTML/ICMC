import getIcmcApiClient from '@http/getIcmcClient';
import { StorageLocation } from '../common/enums';
import type {
  AddCarabinerRequest,
  CarabinerDto,
  UpdateCarabinerRequest,
} from './carabinersTypes';

export const getCarabiner = async (id: number): Promise<CarabinerDto> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.get(`/carabiners/${id}`);
  return result.data;
};

export const getCarabiners = async (
  storageLocation: StorageLocation
): Promise<CarabinerDto[]> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.get(
    `/carabiners/?storageLocation=${storageLocation}`
  );
  return result.data;
};

export const addCarabiner = async (
  request: AddCarabinerRequest
): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.post(`carabiners`, request);
  return result.data;
};

export const deleteCarabiner = async (id: number): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.delete(`carabiners/${id}`);
  return result.data;
};

export const updateCarabiner = async (
  id: number,
  request: UpdateCarabinerRequest
): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.patch(`carabiners/${id}`, request);
  return result.data;
};
