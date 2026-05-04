import localConfig from '@config/config';
import axios from 'axios';

const getIcmcApiClient = async () => {
  const icmcClient = axios.create({ baseURL: localConfig.EndpointConfig.Api });
  return icmcClient;
};

export default getIcmcApiClient;
