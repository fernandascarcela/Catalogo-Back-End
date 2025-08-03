import { createContext, useState, useEffect, type ReactNode, useCallback } from 'react';
import apiClient from '../api/apiClient';
import { jwtDecode } from 'jwt-decode';

interface User {
  name: string;
  email: string;
}

interface AuthContextType {
  user: User | null;
  token: string | null;
  login: (token: string) => void;
  logout: () => void;
  isLoading: boolean;
}

export const AuthContext = createContext<AuthContextType | null>(null);

export const AuthProvider = ({ children }: { children: ReactNode }) => {
  const [user, setUser] = useState<User | null>(null);
  const [token, setToken] = useState<string | null>(() => localStorage.getItem('authToken'));
  const [isLoading, setIsLoading] = useState(true);

  const logout = useCallback(() => {
    setUser(null);
    setToken(null);
    localStorage.removeItem('authToken');
  }, []);

  useEffect(() => {
    if (token) {
      try {
        const decodedToken: { name: string, email: string, exp: number } = jwtDecode(token);

        if (decodedToken.exp * 1000 < Date.now()) {
          logout();
        } else {
          setUser({ name: decodedToken.name, email: decodedToken.email });
        }
      } catch (error) {
        console.error("Token inválido:", error);
        logout();
      }
    }
    setIsLoading(false);
  }, [token, logout]);
  
  const login = (newToken: string) => {
    localStorage.setItem('authToken', newToken);
    setToken(newToken);
  };

  return (
    <AuthContext.Provider value={{ user, token, login, logout, isLoading }}>
      {children}
    </AuthContext.Provider>
  );
};