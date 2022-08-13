USE [NerdStore]

INSERT INTO Produtos (Id, CategoriaId, Nome, Descricao, Ativo, Valor, DataCadastro, Imagem, QuantidadeEstoque, Altura, Largura, Profundidade) 
VALUES (NEWID(), 'EE374BB3-5C2D-4000-A51C-7B1084B58FFA', 'Caneca No Coffee No Code', 'Caneca de porcelana com impressão térmica.', 1, 10.00, GETDATE(), 'caneca4.jpg', 5, 12, 8, 5)

INSERT INTO Produtos (Id, CategoriaId, Nome, Descricao, Ativo, Valor, DataCadastro, Imagem, QuantidadeEstoque, Altura, Largura, Profundidade) 
VALUES (NEWID(), '65B28A0B-C996-40C1-98BA-C024931BCD0C', 'Camiseta Debugar Preta', 'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, 110.00, GETDATE(), 'camiseta4.jpg', 23, 5, 5, 5)

INSERT INTO Produtos (Id, CategoriaId, Nome, Descricao, Ativo, Valor, DataCadastro, Imagem, QuantidadeEstoque, Altura, Largura, Profundidade) 
VALUES (NEWID(), 'EE374BB3-5C2D-4000-A51C-7B1084B58FFA', 'Caneca Turn Coffee in Code', 'Caneca de porcelana com impressão térmica.', 1, 20.00, GETDATE(), 'caneca3.jpg', 5, 12, 8, 5)

INSERT INTO Produtos (Id, CategoriaId, Nome, Descricao, Ativo, Valor, DataCadastro, Imagem, QuantidadeEstoque, Altura, Largura, Profundidade) 
VALUES (NEWID(), '65B28A0B-C996-40C1-98BA-C024931BCD0C', 'Camiseta Code Life Preta', 'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, 90.00, GETDATE(), 'camiseta2.jpg', 3, 5, 5, 5)

INSERT INTO Produtos (Id, CategoriaId, Nome, Descricao, Ativo, Valor, DataCadastro, Imagem, QuantidadeEstoque, Altura, Largura, Profundidade) 
VALUES (NEWID(), '65B28A0B-C996-40C1-98BA-C024931BCD0C', 'Camiseta Software Developer', 'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, 100.00, GETDATE(), 'camiseta1.jpg', 8, 5, 5, 5)

INSERT INTO Produtos (Id, CategoriaId, Nome, Descricao, Ativo, Valor, DataCadastro, Imagem, QuantidadeEstoque, Altura, Largura, Profundidade) 
VALUES (NEWID(), '65B28A0B-C996-40C1-98BA-C024931BCD0C', 'Camiseta Code Life Cinza', 'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, 80.00, GETDATE(), 'camiseta3.jpg', 15, 5, 5, 5)

INSERT INTO Produtos (Id, CategoriaId, Nome, Descricao, Ativo, Valor, DataCadastro, Imagem, QuantidadeEstoque, Altura, Largura, Profundidade) 
VALUES (NEWID(), 'EE374BB3-5C2D-4000-A51C-7B1084B58FFA', 'Caneca Star Bugs Coffee', 'Caneca de porcelana com impressão térmica.', 1, 20.00, GETDATE(), 'caneca1.jpg', 5, 12, 8, 5)

INSERT INTO Produtos (Id, CategoriaId, Nome, Descricao, Ativo, Valor, DataCadastro, Imagem, QuantidadeEstoque, Altura, Largura, Profundidade) 
VALUES (NEWID(), 'EE374BB3-5C2D-4000-A51C-7B1084B58FFA', 'Caneca Programmer Code', 'Caneca de porcelana com impressão térmica.', 1, 15.00, GETDATE(), 'caneca2.jpg', 8, 12, 8, 5)

SELECT * FROM [Produtos]