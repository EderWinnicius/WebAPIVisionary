# VISIONARY

Aqui está uma versão resumida e descritiva para o **README.md**:

---

# API de Gestão de Playlists

Esta API foi desenvolvida em **C#** utilizando **Entity Framework** para gerenciar playlists, usuários, conteúdos e criadores. O objetivo principal é permitir que os usuários criem playlists personalizadas com conteúdos diversos, mantendo um relacionamento claro entre criadores e suas respectivas obras.

## Funcionalidades

A API oferece as seguintes operações **CRUD** para as principais entidades:

- **Usuário**: Cadastrar, listar, atualizar e remover usuários.
- **Playlist**: Criar, gerenciar, atualizar e excluir playlists associadas a um usuário.
- **Conteúdo**: Adicionar, atualizar e remover conteúdos (vídeos, músicas, etc.), cada um vinculado a um criador.
- **Criador**: Gerenciar dados de criadores de conteúdo.
- **Itens de Playlist**: Associar ou remover conteúdos dentro de playlists específicas.

## Relacionamentos

A API lida com as seguintes relações no banco de dados **SQL**:
- **Usuário-Playlist**: Um usuário pode criar várias playlists.
- **Playlist-Item de Playlist**: Relaciona playlists e conteúdos, permitindo que múltiplos conteúdos sejam adicionados a uma playlist.
- **Conteúdo-Criador**: Cada conteúdo é associado a um criador.

## Tecnologias Utilizadas

- **C#** com **ASP.NET Core** para o desenvolvimento da API.
- **Entity Framework** para o ORM.
- **SQL Server** para o banco de dados.

## Instalação e Execução

1. Clone o repositório.
   ```bash
   git clone <url-do-repositorio>
   ```
2. Configure a conexão com o banco de dados no `appsettings.json`.
3. Execute as migrações do Entity Framework.
   ```bash
   dotnet ef database update
   ```
4. Inicie a aplicação.
   ```bash
   dotnet run
   ```

## Licença

Este projeto está licenciado sob a [MIT License](https://opensource.org/licenses/MIT).

Copyright (c) 2024 Eder Oliveira

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

---

Este texto descreve de forma resumida as funcionalidades da API e os relacionamentos entre os dados, além das tecnologias utilizadas no desenvolvimento.
