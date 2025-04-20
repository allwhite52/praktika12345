CREATE DATABASE Praktos123;
GO
USE Praktos123;
GO
--“аблица "языки"
CREATE TABLE Languages(
	LanguageID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, --код €зыка
    LanguageName NVARCHAR(100) NOT NULL, -- название €зыка
    LanguageGroup NVARCHAR(50) NOT NULL, -- €зыкова€ группа
    LanguageSystem NVARCHAR(50) NOT NULL -- знакова€ система €зыка
);
-- “аблица "—траны"
CREATE TABLE Countries (
    CountryID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, -- код страны
    CountryName NVARCHAR(100) NOT NULL, -- им€
	Capital NVARCHAR(100) NOT NULL, -- столица
	Continent NVARCHAR(100) NOT NULL, -- континент
    Populations BIGINT NOT NULL -- население
);
-- “аблица "Ётнический состав"
CREATE TABLE Squads (
    SquadsID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, -- код состава
    CountryID INT,
    LanguageID INT,
    SpeakersCount BIGINT NOT NULL, -- кол-во говор€щих
    FOREIGN KEY (CountryID) REFERENCES Countries(CountryID),
    FOREIGN KEY (LanguageID) REFERENCES Languages(LanguageID)
);
CREATE TABLE Users (
	UsersID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, -- код пользовател€
	UserRole NVARCHAR(50) NOT NULL, -- роль
	UserLogin NVARCHAR(50) NOT NULL, -- логин
	UserPassword NVARCHAR(50) NOT NULL -- пароль
);