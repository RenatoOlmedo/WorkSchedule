# WorkSchedule

## Objetivo:

O aplicativo WorkSchedule foi desenvolvido para facilitar a gestão de funcionários, cargos e escalas de trabalho.

## Descrição do Projeto:
### Login e Segurança:

Feito com diversos métodos do login, os usuários poderão contar com praticidade e segurança, podendo fazer seu cadastro e login com a conta do Google, Facebook, ou através de um cadastro padrão (usuário e senha), protegido com Google reCaptcha v3.

### Tipos de usuários:

Ao efetuar o cadastro, o usuário será direcionado para uma página onde deverá completar os seus dados, podendo adicionar seu nome, telefone e escolher o tipo de usuário que deseja, sendo gestor ou funcionário de uma empresa.
Após configurar o tipo de usuário, de acordo com a escolha, será possível adicionar uma nova empresa ou se vincular a uma.

### Acessos:

De acordo com o tipo de usuário criado, algumas páginas estarão disponíveis para acessar, sendo elas:
* Empresa e Cargos exclusivas para gestores
* Escalas e perfil disponíveis para todos

### Empresas:

Cada usuário poderá vincular-se somente a uma única empresa por vez, apenas acessos de gestores a administrador (único e configurado diretamente no banco de dados) poderão criar, listar e desativar empresas, no entanto, gestores tem acesso apenas a empresa a qual estão ligados, enquanto o administrador possui acesso geral a tudo.

### Cargos:

Cada usuário deverá possuir somente a um unico cargo, os quais podem ser criados e cofigurados e desativados por gestores ou pelo administrador, cargos necessáriamente são vinculados a uma empresa, sendo assim, os gestores de uma empresa poderão listar ou visualizar os cargos pertencentes a outras empresas, da mesma forma não poderão vincular os funcionários de suas empresas a nenhum deles.

### Escalas:

Apesar de estar disponível para todos os tipos de usuários, a visualização da página é única para cada um, gestores poderão listar todas as escalas vinculadas a sua empresa, além de criar outras novas, escolhendo o mês, tipo de jornada (6 x 1, 5 x 2...), quantos e quais funcionários deseja alocar, gerando visualmente um calendário de escala de trabalho para que possa ser analisado e posteriormente salvo.
Usuários com permissão de funcionários, poderão ver somente as escalas em que estão alocados e os dias que irá trabalhar, sem acesso a escala de outros funcionários.

### Perfil:

A qualquer momento os usuários de quaisquer tipo poderão alterar seus dados de nome completo, telefone e senha, apesar de não ser possível alterar o tipo de perfil ou a empresa vinculada sem desvincular-se antes de todas empresas.

## Tecnologias utilizadas:

* [C#](https://learn.microsoft.com/pt-br/dotnet/csharp/): Linguagem de programação
* [JavaScript](https://www.javascript.com/): Linguagem de programação
* [.NET Core](https://learn.microsoft.com/pt-br/dotnet/core/introduction): Framework C#
* [ASP.NET Core](https://learn.microsoft.com/pt-br/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0): Framework web do .Net Core
* [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-2019): Banco de dados
* [Entity Framework](https://learn.microsoft.com/pt-br/ef/): Mapeador do banco de dados
* [Google reCaptcha v3](https://developers.google.com/recaptcha/docs/v3): Segurança

## Como executar:

### **1. Instale `.NET CORE 6` na sua máquina, por meio [deste link](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)**

### **2. Instale `SQL Server Express` na sua máquina, por meio [deste link](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)**

### **3. Faça um clone [desse repositório](https://github.com/RenatoOlmedo/WorkSchedule.git) na sua máquina:**

* Crie uma pasta no seu computador para esse programa, recomendo colocar o nome **WorkSchedule**
* Abra o `git bash` ou `terminal cmd` dentro dessa pasta
* Copie a [URL](https://github.com/RenatoOlmedo/WorkSchedule.git) do repositório
* Digite `git clone <URL copiada>` e pressione `enter`

### **4. Crie e conecte ao banco de dados:**

* Dentro do SQL Server Expres baixado anteriormente, crie um novo banco de dados seguindo as instruções [deste link](https://learn.microsoft.com/pt-br/sql/relational-databases/databases/create-a-database?view=sql-server-ver16)
* Entre no arquivo `app.settings` e altere a string de conexão do banco de dados com as credenciais do banco criado

### **5. Instale os NuGets:**

* Ao abrir o projeto, diversos erros devem surgir, utilizando o atalho `ctrl + .` algumas soluções devem surgir... instale os pacotes NuGet que forem sugeridos

### **5. Gere as Migrations e crie as tabelas do banco :**

* Abra o o terminal através do atalho `crtl + "`
* Digite `dotnet tool install --global dotnet-ef dotnet ef migrations add <Nome Migration>` e pressione `enter`, substituindo `Nome Migration` por um nome de sua esolha, recomendo colocar o nome **Inicial** como padrão
* Digite `dotnet ef database update` e pressione `enter` novamente

### **6. Configure os logins externos :**
* Google através [deste link](https://learn.microsoft.com/pt-br/aspnet/core/security/authentication/social/google-logins?view=aspnetcore-6.0)
* Facebook através [deste link](https://learn.microsoft.com/pt-br/aspnet/core/security/authentication/social/facebook-logins?view=aspnetcore-6.0)
