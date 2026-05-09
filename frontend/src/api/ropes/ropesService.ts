import getIcmcApiClient from '@http/getIcmcClient';
import { StorageLocation } from '../common/enums';
import type {
  AddRopeRequest,
  RopeDto,
  UpdateRopeRequest,
} from './ropesTypes';

export const getRope = async (id: number): Promise<RopeDto> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.get(`/ropes/${id}`);
  return result.data;
};

export const getRopes = async (
  storageLocation: StorageLocation
): Promise<RopeDto[]> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.get(
    `/ropes/?storageLocation=${storageLocation}`
  );
  return result.data;
};

export const addRope = async (request: AddRopeRequest): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.post(`ropes`, request);
  return result.data;
};

export const deleteRope = async (id: number): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.delete(`ropes/${id}`);
  return result.data;
};

export const updateRope = async (
  id: number,
  request: UpdateRopeRequest
): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.patch(`ropes/${id}`, request);
  return result.data;
};
