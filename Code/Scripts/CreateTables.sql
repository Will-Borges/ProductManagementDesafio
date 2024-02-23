USE autoglass;

-- Crie a tabela provider
CREATE TABLE providers (
    Code BIGINT PRIMARY KEY AUTO_INCREMENT,
    Description VARCHAR(255),
    CNPJ VARCHAR(14)
);

-- Crie a tabela products referenciando a tabela provider
CREATE TABLE products (
    Code BIGINT PRIMARY KEY AUTO_INCREMENT,
    Description VARCHAR(255) NOT NULL,
    Status INT NOT NULL,
    Manufacturing_Date DATETIME,
    Expiration_Date DATETIME,
    Provider_Code BIGINT,
    FOREIGN KEY (Provider_Code) REFERENCES providers(Code)
);

ALTER USER 'root'@'localhost' IDENTIFIED BY '@Will00';