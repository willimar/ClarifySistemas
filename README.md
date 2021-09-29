![](https://www.clarifysistemas.com.br/wp-content/uploads/2020/07/clarifysistemas-logotipo.png)

### Introdução

Parte do processo seletivo da empresa Clarify Sistemas. Licença limitada. 
O sistema tem por finalidade apresentar a previsão do tempo para cidades selecionadas, também apresenta as três cidades com maiores temperaturas e as três cidades com menores temperaturas.

# Requisitos

- Sistema operacional Windows
- .Net Framework 4.7.2 ou superior
- Servidor de banco de dados SQLServer;

## Banco de dados
Para o banco de dados recomendo o uso do docker evitando a instalação no sistema operacional.

Para uso no docker siga os passos:

1. Para baixar a imagem `docker pull mcr.microsoft.com/mssql/server:2019-latest`
2. Para executar o container `docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=docker@123456" -p 1433:1433 --name sql-server -h sql-server -d mcr.microsoft.com/mssql/server:2019-latest`

**Obs.:** Tenha atenção para o usuário e senha no comando acima.

### Preparando a base de dados

O nome da base de dados é: `ClimaTempoSimples`. Para criar a base execute o comando no SQLServer.

```sql
    create database ClimaTempoSimples COLLATE Latin1_General_CI_AI
```

### Tabelas

Execute o comando abaixo para criação das tabelas:

```sql
create table Estado (
	Id int primary key,
	Nome nvarchar(200) not null,
	UF nvarchar(2) not null
)
GO

create table Cidade (
	Id int primary key,
	Nome nvarchar(200) not null,
	EstadoId int not null,
	constraint fk_cidade_estado foreign key (EstadoId) references Estado (Id)
)
GO

create table PrevisaoClima (
	Id int identity (1, 1) primary key,
	CidadeId int not null,
	DataPrevisao date not null,

	Clima nvarchar(15) not null check (clima in ('ensolarado', 'nublado', 'chuvoso', 'tempestuoso', 'instavel')),

	TemperaturaMinima numeric(3,1),
	TemperaturaMaxima numeric(3,1),

	constraint fk_previsao_cidade foreign key(CidadeId) references Cidade (Id) 
)
GO
```
## Compilando o sistema

Abra o arquivo `ClarifyProcessoSelecao.sln` e faça o build da aplicação.

## Depurando o sistema

1. Certifique-se de que o projeto `ClarifyProcessoSelecao` está marcado como `Startup Project`
2. No arquivo `Web.config` ajuste a connection string para acesso ao banco de dados.

### Exemplo de connection string

```xml
<configuration>
  <connectionStrings>
    <add name="connection" connectionString="Data Source=host.docker.internal; Network Library=DBMSSOCN; Initial Catalog=ClimaTempoSimples; User ID=sa; Password=docker@123456;" />
  </connectionStrings>
</configuration>
```
