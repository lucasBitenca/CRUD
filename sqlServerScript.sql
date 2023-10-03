use db_ESTUDO
go

Create Table tb_TipoCliente (
ID int identity,
Descricao nvarchar(100),
constraint PK_TB_TipoCliente primary key (ID)
)
go
insert into tb_TipoCliente values ('Tipo A')
insert into tb_TipoCliente values ('Tipo B')
insert into tb_TipoCliente values ('Tipo C')

Create Table tb_SituacaoCliente (
ID int identity,
Descricao nvarchar(100),
constraint PK_TB_SituacaoCliente primary key (ID)
)
go
insert into tb_SituacaoCliente values ('Contrato Ativo')
insert into tb_SituacaoCliente values ('Contrato Inativo')

Create Table tb_Cliente (
	Nome nvarchar(200) not null,
	CPF nvarchar(11) not null,
	TipoCliente int null,
	Sexo nvarchar(50) not null,
	SituacaoCliente int null,
	constraint PK_TB_Cliente primary key (CPF),
	constraint FK_TB_TipoCliente_Cliente foreign key (TipoCliente)
	references tb_TipoCliente (ID),
	constraint FK_TB_SituacaoCliente_Cliente foreign key (SituacaoCliente)
	references tb_SituacaoCliente (ID)
)
go

create procedure sp_InsertCliente (@nome nvarchar(200), @cpf nvarchar(11), @tipoCliente int, @sexo nvarchar(50), @situacaoCliente int)
as
begin
	declare @insertedCliente table (CPF nvarchar(11))
	insert into tb_Cliente (Nome, CPF, TipoCliente, Sexo, SituacaoCliente) 
		output inserted.CPF into @insertedCliente 
		values (@nome, @cpf, @tipoCliente, @sexo, @situacaoCliente)
	select CPF from @insertedCliente
end
go

create procedure sp_UpdateCliente (@nome nvarchar(200),@cpf nvarchar(11), @tipoCliente int, @sexo nvarchar(50), @situacaoCliente int)
as
begin
	declare @insertedCliente table (CPF nvarchar(11))
	update tb_Cliente set Nome = @nome, TipoCliente = @tipoCliente, Sexo = @sexo, SituacaoCliente = @situacaoCliente 
		output inserted.CPF into @insertedCliente from tb_Cliente
		where tb_Cliente.CPF = @cpf
	select CPF from @insertedCliente
end
go

create procedure sp_DeleteCliente (@cpf nvarchar(11))
as
begin
	declare @deletedCliente table (CPF nvarchar(11))
	delete from tb_Cliente output deleted.CPF into @deletedCliente where CPF = @cpf
	select CPF from @deletedCliente
end
go