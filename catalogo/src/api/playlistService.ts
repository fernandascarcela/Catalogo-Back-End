import apiClient from './apiClient';
import type { Playlist, CreatePlaylistDto, AddItemToPlaylistDto } from '../types';

export const getPlaylists = async (): Promise<Playlist[]> => {
  const response = await apiClient.get<Playlist[]>('/playlists');
  return response.data;
};

export const getPlaylistById = async (playlistId: number): Promise<Playlist> => {
  const response = await apiClient.get<Playlist>(`/playlists/${playlistId}`);
  return response.data;
};

export const createPlaylist = async (playlistData: CreatePlaylistDto): Promise<Playlist> => {
  const response = await apiClient.post<Playlist>('/playlists', playlistData);
  return response.data;
};

export const deletePlaylist = async (playlistId: number): Promise<void> => {
  await apiClient.delete(`/playlists/${playlistId}`);
};

export const addItemToPlaylist = async (playlistId: number, itemData: AddItemToPlaylistDto): Promise<void> => {
  await apiClient.post(`/playlists/${playlistId}/items`, itemData);
};

export const removeItemFromPlaylist = async (
  playlistId: number,
  itemType: string,
  itemId: number
): Promise<void> => {
  await apiClient.delete(`/playlists/${playlistId}/items/${itemType}/${itemId}`);
};