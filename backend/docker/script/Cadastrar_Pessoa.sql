DELIMITER $$

CREATE PROCEDURE Cadastrar_Pessoa(
IN sp_Nome LONGTEXT, 
IN sp_Cpf BIGINT, 
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
INSERT INTO ENDERECO (Logradouro, Numero, Cep, Bairro, Cidade, Estado) VALUES (sp_Logradouro, sp_Numero, sp_Cep, sp_Bairro, sp_Cidade, sp_Estado);
SELECT LAST_INSERT_ID() INTO @endereco_id;
INSERT INTO PESSOA (Nome, Cpf, EnderecoId) VALUES (sp_Nome, sp_Cpf, @endereco_id);
SELECT LAST_INSERT_ID() INTO @pessoa_id;
INSERT INTO TELEFONE_TIPO (Tipo) VALUES (sp_Tipo); SELECT LAST_INSERT_ID() INTO @telefone_tipo_id;
INSERT INTO TELEFONE (Numero, Ddd, TipoTelefoneId) VALUES (sp_NumeroTelefone, sp_Ddd, @telefone_tipo_id);
SELECT LAST_INSERT_ID() INTO @telefone_id;
INSERT INTO PESSOA_TELEFONE (PessoaId, TelefoneId) VALUES (@pessoa_id, @telefone_id);
END $$
DELIMITER ;