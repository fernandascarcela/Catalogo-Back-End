
export interface Filme {
  id: number;
  titulo: string;
  ano: number;
  diretor: string;
  urlCapa: string;
}

export interface Livro {
  id: number;
  titulo: string;
  ano: number;
  autor: string;
  urlCapa: string;
}

export interface PlaylistItem {
  tipo: 'Filme' | 'Livro';
  filme?: Filme;
  livro?: Livro;
}

export interface Playlist {
  id: number;
  nome: string;
  itens: PlaylistItem[];
}

export interface LoginDto {
  email: string;
  senha?: string;
}

export interface RegisterDto {
  nome: string;
  email: string;
  senha: string;
}

export interface CreateFilmeDto {
  titulo: string;
  ano: number;
  diretor: string;
  urlCapa: string;
}

export interface UpdateFilmeDto {
  titulo: string;
  ano: number;
  diretor: string;
  urlCapa: string;
}

export interface CreateLivroDto {
  titulo: string;
  ano: number;
  autor: string;
  urlCapa: string;
}

export interface UpdateLivroDto {
  titulo: string;
  ano: number;
  autor: string;
  urlCapa: string;
}

export interface CreatePlaylistDto {
    nome: string;
}

export interface AddItemToPlaylistDto {
    itemId: number;
    tipo: 'Filme' | 'Livro';
}