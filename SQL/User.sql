CREATE TABLE Users (
    UserID INT PRIMARY KEY AUTO_INCREMENT,
    UserName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    Phone NVARCHAR(20),
    Address NVARCHAR(255)
);

CREATE TABLE Deliveries (
    DeliveryID INT PRIMARY KEY AUTO_INCREMENT,
    UserID INT NOT NULL,
    DeliveryDate DATETIME NOT NULL,
    Status NVARCHAR(50),
    DeliveryAddress NVARCHAR(255),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE Companies (
    CompanyID INT PRIMARY KEY AUTO_INCREMENT,
    CompanyName NVARCHAR(100) NOT NULL,
    ContactEmail NVARCHAR(255),
    ContactPhone NVARCHAR(20),
    HeadquartersAddress NVARCHAR(255)
);

INSERT INTO Users (UserName, Email, Phone, Address) 
VALUES 
('Іван Іванов', 'ivan@example.com', '+380123456789', 'Київ, вул. Шевченка, 10'),
('Марія Петренко', 'maria@example.com', '+380987654321', 'Львів, вул. Франка, 15');

INSERT INTO Deliveries (UserID, DeliveryDate, Status, DeliveryAddress)
VALUES 
(1, '2024-11-22 10:30:00', 'В процесі', 'Київ, вул. Лесі Українки, 5'),
(2, '2024-11-23 14:00:00', 'Доставлено', 'Львів, вул. Січових Стрільців, 20');

INSERT INTO Companies (CompanyName, ContactEmail, ContactPhone, HeadquartersAddress)
VALUES 
('Швидка Пошта', 'info@speedpost.ua', '+380441234567', 'Київ, вул. Грушевського, 30'),
('Нова Доставка', 'support@novadostavka.ua', '+380442345678', 'Одеса, вул. Дерибасівська, 12');