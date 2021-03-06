DELIMITER $$
CREATE PROCEDURE Consultar_Pessoa(IN sp_Cpf BIGINT)

BEGIN
SELECT PESSOA.Nome, 
ENDERECO.Logradouro, 
ENDERECO.Numero, 
ENDERECO.Cep, 
ENDERECO.Bairro, 
ENDERECO.Cidade, 
ENDERECO.Estado, 
TELEFONE.Numero, 
TELEFONE.Ddd, 
TELEFONE_TIPO.Tipo
FROM PESSOA_TELEFONE
INNER JOIN PESSOA ON PESSOA.Id = PESSOA_TELEFONE.PessoaId
INNER JOIN TELEFONE ON TELEFONE.Id = PESSOA_TELEFONE.TelefoneId
INNER JOIN TELEFONE_TIPO ON TELEFONE_TIPO.Id = TELEFONE.TipoTelefoneId
INNER JOIN ENDERECO ON ENDERECO.Id = PESSOA.EnderecoId
WHERE PESSOA.Cpf = sp_Cpf;
END $$
DELIMITER ;