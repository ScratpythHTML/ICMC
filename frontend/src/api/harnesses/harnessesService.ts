import getIcmcApiClient from '@http/getIcmcClient';
import { StorageLocation } from '../common/enums';
import type {
  AddHarnessRequest,
  HarnessDto,
  UpdateHarnessRequest,
} from './harnessesTypes';

export const getHarness = async (id: number): Promise<HarnessDto> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.get(`/harnesses/${id}`);
  return result.data;
};

export const getHarnesses = async (
  storageLocation: StorageLocation
): Promise<HarnessDto[]> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.get(
    `/harnesses/?storageLocation=${storageLocation}`
  );
  return result.data;
};

export const addHarness = async (
  request: AddHarnessRequest
): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.post(`harnesses`, request);
  return result.data;
};

export const deleteHarness = async (id: number): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.delete(`harnesses/${id}`);
  return result.data;
};

export const updateHarness = async (
  id: number,
  request: UpdateHarnessRequest
): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.patch(`harnesses/${id}`, request);
  return result.data;
};
