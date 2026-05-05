import getIcmcApiClient from '@http/getIcmcClient';
import type {
  AddCrashpadRequest,
  CrashpadDto,
  UpdateCrashpadRequest,
} from './crashpadsTypes';

export const getCrashpad = async (id: number): Promise<CrashpadDto> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.get(`/crashpads/${id}`);
  return result.data;
};

export const addCrashpad = async (
  request: AddCrashpadRequest
): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.post(`crashpads`, request);
  return result.data;
};

export const deleteCrashpad = async (id: number): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.delete(`crashpads/${id}`);
  return result.data;
};

export const updateCrashpad = async (
  id: number,
  request: UpdateCrashpadRequest
): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.patch(`crashpads/${id}`, request);
  return result.data;
};
