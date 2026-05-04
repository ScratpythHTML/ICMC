import getIcmcApiClient from '@http/getIcmcClient';
import type {
  AddBelayDeviceRequest,
  BelayDeviceDto,
  UpdateBelayDeviceRequest,
} from './belayDevicesTypes';

export const getBelayDevice = async (id: number): Promise<BelayDeviceDto> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.get(`/belay-devices/${id}`);
  return result.data;
};

export const addBelayDevice = async (
  request: AddBelayDeviceRequest
): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.post(`belay-devices`, request);
  return result.data;
};

export const deleteBelayDevice = async (id: number): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.delete(`belay-devices/${id}`);
  return result.data;
};

export const updateBelayDevice = async (
  id: number,
  request: UpdateBelayDeviceRequest
): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.patch(`belay-devices/${id}`, request);
  return result.data;
};
