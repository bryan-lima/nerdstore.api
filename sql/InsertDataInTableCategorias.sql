USE [NerdStore]

INSERT INTO Categorias (Id, Nome, Codigo) 
VALUES ('65B28A0B-C996-40C1-98BA-C024931BCD0C', 'Camisetas', 100)

INSERT INTO Categorias (Id, Nome, Codigo) 
VALUES ('EE374BB3-5C2D-4000-A51C-7B1084B58FFA', 'Canecas', 101)

INSERT INTO Categorias (Id, Nome, Codigo) 
VALUES ('85F954F3-E6F2-47E8-AEB2-E5C042AE1643', 'Adesivos', 102)

SELECT * FROM [Categorias]
ORDER BY [Codigo]