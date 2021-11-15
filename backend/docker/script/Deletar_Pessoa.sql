DELIMITER $$
CREATE PROCEDURE Deletar_Pessoa(
IN sp_Cpf BIGINT)

BEGIN
DELETE PESSOA, TELEFONE, TELEFONE_TIPO, ENDERECO FROM PESSOA_TELEFONE
INNER JOIN PESSOA ON PESSOA.Id = PESSOA_TELEFONE.PessoaId
INNER JOIN TELEFONE ON TELEFONE.Id = PESSOA_TELEFONE.TelefoneId
INNER JOIN TELEFONE_TIPO ON TELEFONE_TIPO.Id = TELEFONE.TipoTelefoneId
INNER JOIN ENDERECO ON ENDERECO.Id = PESSOA.EnderecoId
WHERE PESSOA.Cpf = sp_Cpf;
END $$
DELIMITER ;