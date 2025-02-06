-- TestDb veritabanýný oluþtur
CREATE DATABASE TestDb;
GO

-- TestDb veritabanýný kullan
USE TestDb;
GO

-- Yazilar tablosunu oluþtur
CREATE TABLE Yazilar (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200),
    Content NVARCHAR(MAX),
    CreatedDate DATETIME DEFAULT GETDATE()
);
GO

-- Kategoriler tablosunu oluþtur
CREATE TABLE Kategoriler (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Description NVARCHAR(500)
);
GO


-- Yazilar tablosu için örnek kayýtlar
INSERT INTO Yazilar (Title, Content)
VALUES 
('Merhaba Dünya', 'Bu, blog uygulamasý için örnek içeriktir.'),
('Yeni Özellikler', 'Blog sistemimize yeni özellikler eklendi. Detaylarý inceleyebilirsiniz.'),
('Teknoloji Haberleri', 'En güncel teknoloji haberlerini bu yazýda bulabilirsiniz.');

-- Kategoriler tablosu için örnek kayýtlar
INSERT INTO Kategoriler (Name, Description)
VALUES 
('Genel', 'Genel konular ve duyurular.'),
('Teknoloji', 'Teknoloji ile ilgili güncel haber ve incelemeler.'),
('Eðlence', 'Film, dizi ve diðer eðlence içerikleri.');