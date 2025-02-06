-- TestDb veritaban�n� olu�tur
CREATE DATABASE TestDb;
GO

-- TestDb veritaban�n� kullan
USE TestDb;
GO

-- Yazilar tablosunu olu�tur
CREATE TABLE Yazilar (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200),
    Content NVARCHAR(MAX),
    CreatedDate DATETIME DEFAULT GETDATE()
);
GO

-- Kategoriler tablosunu olu�tur
CREATE TABLE Kategoriler (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Description NVARCHAR(500)
);
GO


-- Yazilar tablosu i�in �rnek kay�tlar
INSERT INTO Yazilar (Title, Content)
VALUES 
('Merhaba D�nya', 'Bu, blog uygulamas� i�in �rnek i�eriktir.'),
('Yeni �zellikler', 'Blog sistemimize yeni �zellikler eklendi. Detaylar� inceleyebilirsiniz.'),
('Teknoloji Haberleri', 'En g�ncel teknoloji haberlerini bu yaz�da bulabilirsiniz.');

-- Kategoriler tablosu i�in �rnek kay�tlar
INSERT INTO Kategoriler (Name, Description)
VALUES 
('Genel', 'Genel konular ve duyurular.'),
('Teknoloji', 'Teknoloji ile ilgili g�ncel haber ve incelemeler.'),
('E�lence', 'Film, dizi ve di�er e�lence i�erikleri.');