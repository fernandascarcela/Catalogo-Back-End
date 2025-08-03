import apiClient from './apiClient';
import type { Filme, CreateFilmeDto, UpdateFilmeDto } from '../types';

export const getFilmes = async (): Promise<Filme[]> => {
  const response = await apiClient.get<Filme[]>('/filmes');
  return response.data;
};

export const getFilmeById = async (id: number): Promise<Filme> => {
  const response = await apiClient.get<Filme>(`/filmes/${id}`);
  return response.data;
};
export const createFilme = async (filmeData: CreateFilmeDto): Promise<Filme> => {
  const response = await apiClient.post<Filme>('/filmes', filmeData);
  return response.data;
};

export const updateFilme = async (id: number, filmeData: UpdateFilmeDto): Promise<Filme> => {
  const response = await apiClient.put<Filme>(`/filmes/${id}`, filmeData);
  return response.data;
};

export const deleteFilme = async (id: number): Promise<void> => {
  await apiClient.delete(`/filmes/${id}`);
};