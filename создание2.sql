CREATE DATABASE Praktos123;
GO
USE Praktos123;
GO
--������� "�����"
CREATE TABLE Languages(
	LanguageID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, --��� �����
    LanguageName NVARCHAR(100) NOT NULL, -- �������� �����
    LanguageGroup NVARCHAR(50) NOT NULL, -- �������� ������
    LanguageSystem NVARCHAR(50) NOT NULL -- �������� ������� �����
);
-- ������� "������"
CREATE TABLE Countries (
    CountryID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, -- ��� ������
    CountryName NVARCHAR(100) NOT NULL, -- ���
	Capital NVARCHAR(100) NOT NULL, -- �������
	Continent NVARCHAR(100) NOT NULL, -- ���������
    Populations BIGINT NOT NULL -- ���������
);
-- ������� "���������� ������"
CREATE TABLE Squads (
    SquadsID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, -- ��� �������
    CountryID INT,
    LanguageID INT,
    SpeakersCount BIGINT NOT NULL, -- ���-�� ���������
    FOREIGN KEY (CountryID) REFERENCES Countries(CountryID),
    FOREIGN KEY (LanguageID) REFERENCES Languages(LanguageID)
);
CREATE TABLE Users (
	UsersID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, -- ��� ������������
	UserRole NVARCHAR(50) NOT NULL, -- ����
	UserLogin NVARCHAR(50) NOT NULL, -- �����
	UserPassword NVARCHAR(50) NOT NULL -- ������
);