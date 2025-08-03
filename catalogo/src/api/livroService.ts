import apiClient from './apiClient';
import type { Livro, CreateLivroDto, UpdateLivroDto } from '../types';

export const getLivros = async (): Promise<Livro[]> => {
  const response = await apiClient.get<Livro[]>('/livros');
  return response.data;
};

export const getLivroById = async (id: number): Promise<Livro> => {
  const response = await apiClient.get<Livro>(`/livros/${id}`);
  return response.data;
};

export const createLivro = async (livroData: CreateLivroDto): Promise<Livro> => {
  const response = await apiClient.post<Livro>('/livros', livroData);
  return response.data;
};

export const updateLivro = async (id: number, livroData: UpdateLivroDto): Promise<Livro> => {
  const response = await apiClient.put<Livro>(`/livros/${id}`, livroData);
  return response.data;
};

export const deleteLivro = async (id: number): Promise<void> => {
  await apiClient.delete(`/livros/${id}`);
};