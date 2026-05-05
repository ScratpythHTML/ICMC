import getIcmcApiClient from '@http/getIcmcClient';
import type {
  AddUserRequest,
  UpdateUserRequest,
  UserDto,
} from './usersTypes';

export const getUser = async (id: string): Promise<UserDto> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.get(`/users/${id}`);
  return result.data;
};

export const addUser = async (request: AddUserRequest): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.post(`users`, request);
  return result.data;
};

export const deleteUser = async (id: string): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.delete(`users/${id}`);
  return result.data;
};

export const updateUser = async (
  id: string,
  request: UpdateUserRequest
): Promise<void> => {
  const icmcClient = await getIcmcApiClient();
  const result = await icmcClient.patch(`users/${id}`, request);
  return result.data;
};
