import getIcmcApiClient from '@http/getIcmcClient';
import { StorageLocation } from '../common/enums';
import type {
  AddQuickdrawRequest,
  QuickdrawDto,
  UpdateQuickdrawRequest,
} from './quickdrawsTypes';

export const getQuickdraw = async (id: number): Promise<QuickdrawDto> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.get(`/quickdraws/${id}`);
  return result.data;
};

export const getQuickdraws = async (
  storageLocation: StorageLocation
): Promise<QuickdrawDto[]> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.get(
    `/quickdraws/?storageLocation=${storageLocation}`
  );
  return result.data;
};

export const addQuickdraw = async (
  request: AddQuickdrawRequest
): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.post(`quickdraws`, request);
  return result.data;
};

export const deleteQuickdraw = async (id: number): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.delete(`quickdraws/${id}`);
  return result.data;
};

export const updateQuickdraw = async (
  id: number,
  request: UpdateQuickdrawRequest
): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.patch(`quickdraws/${id}`, request);
  return result.data;
};
