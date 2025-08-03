import apiClient from './apiClient';
import type { LoginDto, RegisterDto } from '../types';

interface LoginResponse {
  token: string;
}

export const login = async (credentials: LoginDto): Promise<LoginResponse> => {
  const response = await apiClient.post<LoginResponse>('/auth/login', credentials);
  return response.data;
};

export const register = async (userData: RegisterDto): Promise<void> => {
  await apiClient.post('/auth/register', userData);
};