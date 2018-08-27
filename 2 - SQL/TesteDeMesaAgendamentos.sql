-- teste de mesa para agendamentos

declare 
	@dataInicio datetime = '27/08/2018 08:00',
	@dataFim datetime = '27/08/2018 10:00',
	@idDentista varchar(1) = '1'

 Select * from view_agendamento  where 
 	 ( id_dentista = @idDentista and DataFim <> @dataInicio and @dataInicio between DataInicio and DataFim )  or 
	 ( id_dentista = @idDentista and DataInicio <> @dataFim and @dataFim between DataInicio and DataFim ) ;
 
 Select * from view_agendamento ;

