create view view_agendamento
as
select
	Tratamento.id_tratamento,
	Tratamento.id_paciente,
	Paciente.Nome as NomePaciente,
	Paciente.Celular as Celular,
	Tipo_Servico.id_servico,
	Tipo_Servico.Des_servico as NomeServico,
	Tipo_Servico.Tempo_Atendimento,
	Tratamento.id_dentista,
	Funcionario.Nome as NomeDentista,
	Tratamento.data as DataInicio,
	Tratamento.data + convert(datetime, Tipo_Servico.Tempo_Atendimento) as DataFim
from tratamento
inner join Paciente on Paciente.id_Paciente=Tratamento.id_paciente 
inner join Tipo_Servico on Tipo_Servico.id_servico=Tratamento.id_servico_FK
inner join Funcionario  on Funcionario.id_funcionario  =Tratamento.id_dentista 
 go
 --- REFERENCIA PARA FUNCAO CAST E CONVERT DO SQL
--- https://docs.microsoft.com/pt-br/sql/t-sql/functions/cast-and-convert-transact-sql?view=sql-server-2017
 --declare @dt datetime = convert(datetime, '31/12/2018 23:59', 103)
 --select @dt

 --select * from Tratamento
 select * from view_agendamento