import axios, { AxiosError } from 'axios';
import { HttpRequestError } from '../types';

const axiosInstance = axios.create({ baseURL: process.env.API_URL });

const getNormalizedError = (axiosError: AxiosError): HttpRequestError => {
  const data = axiosError.response || { data: {}, status: -1 };
  return {
    notified: false,
    code: data.status,
    data: data.data as object | undefined,
    innerException: axiosError,
  };
};

const errorResponseHandler = (originalError: AxiosError): Promise<AxiosError> =>
  Promise.reject(getNormalizedError(originalError));

axiosInstance.interceptors.response.use(response => response, errorResponseHandler);

export default axiosInstance;
