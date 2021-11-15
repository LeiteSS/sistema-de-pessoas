DELIMITER $$
CREATE PROCEDURE Atualizar_Pessoa(
IN sp_Cpf BIGINT,
IN sp_Nome LONGTEXT,  
IN sp_Logradouro LONGTEXT,
IN sp_Numero INT,
IN sp_Cep INT,
IN sp_Bairro LONGTEXT,
IN sp_Cidade LONGTEXT,
IN sp_Estado LONGTEXT,
IN sp_Tipo LONGTEXT,
IN sp_NumeroTelefone INT,
IN sp_Ddd INT)

BEGIN
UPDATE PESSOA_TELEFONE
INNER JOIN PESSOA ON PESSOA.Id = PESSOA_TELEFONE.PessoaId
INNER JOIN TELEFONE ON TELEFONE.Id = PESSOA_TELEFONE.TelefoneId
INNER JOIN TELEFONE_TIPO ON TELEFONE_TIPO.Id = TELEFONE.TipoTelefoneId
INNER JOIN ENDERECO ON ENDERECO.Id = PESSOA.EnderecoId
SET PESSOA.Nome = sp_Nome,
ENDERECO.Logradouro = sp_Logradouro,
ENDERECO.Numero = sp_Numero,
ENDERECO.Cep = sp_Cep,
ENDERECO.Bairro = sp_Bairro,
ENDERECO.Cidade = sp_Cidade,
ENDERECO.Estado = sp_Estado,
TELEFONE.Numero = sp_NumeroTelefone,
TELEFONE.Ddd = sp_Ddd,
TELEFONE_TIPO.Tipo = sp_Tipo
WHERE PESSOA.Cpf = sp_Cpf;
END $$
DELIMITER ;