# 🎬📚 Catálogo de Filmes e Livros - Web Service (.NET + React)

Este projeto é o back-end da aplicação SPA desenvolvida em React, agora integrada com um Web Service em C# usando .NET. O sistema permite que usuários cadastrem, consultem, editem e removam informações sobre **filmes assistidos** e **livros lidos**, oferecendo uma maneira simples de manter seu histórico cultural organizado.

---

## 🧩 Funcionalidades

- ✅ Cadastrar livros e filmes com título, autor/diretor, ano de lançamento e capa do filme.
- 🔍 Listar todos os itens cadastrados.
- 📝 Editar informações existentes.
- ❌ Remover registros.
- 💾 Dados persistidos em memória (In-Memory Database).
- 🌐 Integração total com a SPA em React.

---

## 🛠️ Tecnologias Utilizadas

### Backend (.NET)
- C# com .NET 8
- ASP.NET Core Web API
- SQLite
- RESTful API

### Frontend (SPA)
- React
- Axios
- React Router
- ⁠Typescript 
- Tailwind

### Outros
- Git & GitHub
- Docker (com Dockerfile incluído)
---

## 🚀 Como utilizar

### 📦 Back-End (API + Banco de Dados)

O back-end está containerizado com Docker, incluindo a API e um banco de dados SQLite. Isso significa que não é necessário instalar dependências manualmente — basta rodar o Docker e tudo estará pronto para uso.

#### Requisitos

- [Docker](https://www.docker.com/) instalado

#### Instruções
# Clone o repositório
git clone https://github.com/fernandascarcela/Catalogo-Back-End.git
cd Catalogo-Back-End/CatalogoApi
docker-composse up --build

## 💻 Front-End
### Requisitos

- [Node.js](https://nodejs.org/) (versão 18 ou superior)
- npm

### Instruções
# Acesse a pasta do front-end
cd ../catalogo

# Instale as dependências
npm install

# Inicie o servidor de desenvolvimento
npm run dev


## Imagens do Back end
<img width="1337" height="608" alt="Captura de tela 2025-08-03 104051" src="https://github.com/user-attachments/assets/44578869-a952-443c-8b57-b9166a0f622f" />
<img width="1334" height="596" alt="Captura de tela 2025-08-03 104059" src="https://github.com/user-attachments/assets/83edda47-b080-4ab8-baa9-9c0efed0901c" />
<img width="1337" height="413" alt="Captura de tela 2025-08-03 104108" src="https://github.com/user-attachments/assets/8f125e02-c6ed-4bb8-811b-210554f72c23" />
<img width="1142" height="599" alt="Captura de tela 2025-08-03 104122" src="https://github.com/user-attachments/assets/70670f1f-6c59-487a-aa58-f49c4f725073" />





