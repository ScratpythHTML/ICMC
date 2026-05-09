import getIcmcApiClient from '@http/getIcmcClient';
import type {
  AddGearItemRequest,
  GearItemDto,
  GetGearItemsRequest,
  UpdateGearItemRequest,
} from './gearItemsTypes';

export const getGearItem = async (id: number): Promise<GearItemDto> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.get(`/gear-items/${id}`);
  return result.data;
};

export const getGearItems = async (
  request: GetGearItemsRequest
): Promise<GearItemDto[]> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.get('/gear-items', { params: request });
  return result.data;
};

export const addGearItem = async (
  request: AddGearItemRequest
): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.post('/gear-items', request);
  return result.data;
};

export const deleteGearItem = async (id: number): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.delete(`/gear-items/${id}`);
  return result.data;
};

export const updateGearItem = async (
  id: number,
  request: UpdateGearItemRequest
): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.patch(`/gear-items/${id}`, request);
  return result.data;
};
