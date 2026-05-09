import getIcmcApiClient from '@http/getIcmcClient';
import { StorageLocation } from '../common/enums';
import type {
  AddHelmetRequest,
  HelmetDto,
  UpdateHelmetRequest,
} from './helmetsTypes';

export const getHelmet = async (id: number): Promise<HelmetDto> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.get(`/helmets/${id}`);
  return result.data;
};

export const getHelmets = async (
  storageLocation: StorageLocation
): Promise<HelmetDto[]> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.get(
    `/helmets/?storageLocation=${storageLocation}`
  );
  return result.data;
};

export const addHelmet = async (request: AddHelmetRequest): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.post(`helmets`, request);
  return result.data;
};

export const deleteHelmet = async (id: number): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.delete(`helmets/${id}`);
  return result.data;
};

export const updateHelmet = async (
  id: number,
  request: UpdateHelmetRequest
): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.patch(`helmets/${id}`, request);
  return result.data;
};
