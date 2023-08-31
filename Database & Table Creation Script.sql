-- TODO: Add logins & permissions,
-- Stored Procedures
-- Overvej, at oprette generelle Ingredient- og Drink_Type tabeller for at reducere antallet af tabeller i databasen.
-- Kig på flere CHECKS.
-- Lids 1:1 med cup_size, da de selvfølgelig skal passe sammen.
-- Indfør mellemtabel mellem Orders og Service_Items (M:N) ?
-- Hvad sker der, hvis databasen allerede eksisterer?

-- checks if database exists, creates database if not
IF db_id('Storage') IS NULL
	USE [master]
	CREATE DATABASE [Storage]

GO

USE [Storage]

-- INGREDIENT BIT
CREATE TABLE Meat (
	meat_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	meat_type VARCHAR(50) NOT NULL,
	amount INT NOT NULL
);

CREATE TABLE Cheese (
	cheese_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	cheese_type VARCHAR(50) NOT NULL,
	amount INT NOT NULL
);

CREATE TABLE Bread (
	bread_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	bread_type VARCHAR(50) NOT NULL,
	amount INT NOT NULL
);

CREATE TABLE Dressing_And_Dip (
	dad_id TINYINT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	dad_type VARCHAR(50) NOT NULL,
	amount INT NOT NULL
);

CREATE TABLE Salad (
	salad_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	salad_type VARCHAR(50) NOT NULL,
	amount INT NOT NULL
);

CREATE TABLE Fruit_And_Veg (
	fav_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	fav_type VARCHAR(50) NOT NULL,
	amount INT NOT NULL
);

CREATE TABLE Ingredients (
	ingredient_id TINYINT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	meat TINYINT FOREIGN KEY REFERENCES Meat(meat_id),
	cheese TINYINT FOREIGN KEY REFERENCES Cheese(cheese_id),
	bread TINYINT FOREIGN KEY REFERENCES Bread(bread_id),
	dad TINYINT FOREIGN KEY REFERENCES Dressing_And_Dip(dad_id),
	salad TINYINT FOREIGN KEY REFERENCES Salad(salad_id),
	fav TINYINT FOREIGN KEY REFERENCES Fruit_And_Veg(fav_id),
	amount INT NOT NULL
);

-- DRINKS BIT
CREATE TABLE Water (
	water_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	amount INT NOT NULL,
	brand VARCHAR(50) NOT NULL
);

CREATE TABLE Juice (
	juice_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	flavour VARCHAR(50) NOT NULL,
	litres DECIMAL (6, 2) NOT NULL,
	CHECK (litres >= 0)
);

CREATE TABLE Soda (
	soda_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	flavour VARCHAR(50) NOT NULL,
	litres DECIMAL (6, 2) NOT NULL,
	CHECK (litres >= 0)
);

CREATE TABLE Frappe (
	frappe_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	flavour VARCHAR(50) NOT NULL,
	litres DECIMAL (6, 2) NOT NULL,
	CHECK (litres >= 0)
);

CREATE TABLE Milkshake (
	milkshake_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	flavour VARCHAR(50) NOT NULL,
	litres DECIMAL (6, 2) NOT NULL,
	CHECK (litres >= 0)
);

CREATE TABLE Coffee (
	coffee_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	coffee_type VARCHAR(50) NOT NULL,
	litres DECIMAL (6, 2) NOT NULL,
	CHECK (litres >= 0)
);

CREATE TABLE Alcohol (
	alcohol_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	name VARCHAR(50) NOT NULL,
	litres DECIMAL (6, 2) NOT NULL,
	CHECK (litres >= 0)
);

CREATE TABLE Drinks (
	drink_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	water_id TINYINT FOREIGN KEY REFERENCES Water(water_id),
	juice_id TINYINT FOREIGN KEY REFERENCES Juice(juice_id),
	soda_id TINYINT FOREIGN KEY REFERENCES Soda(soda_id),
	frappe_id TINYINT FOREIGN KEY REFERENCES Frappe(frappe_id),
	milkshake_id TINYINT FOREIGN KEY REFERENCES Milkshake(milkshake_id),
	coffee_id TINYINT FOREIGN KEY REFERENCES Coffee(coffee_id),
	alcohol_id TINYINT FOREIGN KEY REFERENCES Alcohol(alcohol_id)
);


-- MISCELLANEOUS
CREATE TABLE Sides (
	side_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	name VARCHAR(50) NOT NULL,
	amount INT NOT NULL
);

-- Size: Small, Medium, Large
CREATE TABLE Bags (
	bag_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	bag_size VARCHAR(8) NOT NULL
);

CREATE TABLE Cups (
	cup_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	cup_size VARCHAR(8) NOT NULL
);

CREATE TABLE Lids (
	lid_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	lid_size VARCHAR(8) NOT NULL
);

CREATE TABLE Service_Items (
	item_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	bags TINYINT NOT NULL,
	straws TINYINT NOT NULL,
	trays TINYINT NOT NULL,
	cups TINYINT NOT NULL,
	lids TINYINT NOT NULL
);

CREATE TABLE Orders (
	order_id int PRIMARY KEY NOT NULL,
	order_date date DEFAULT GETDATE(),
	product varchar(64) NOT NULL,
	amount int NOT NULL
);

CREATE TABLE Order_Details (
	ordetail_id int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	order_id int FOREIGN KEY REFERENCES Orders(order_id),
	ingredient_id tinyint FOREIGN KEY REFERENCES Ingredients(ingredient_id),
	drink_id tinyint FOREIGN KEY REFERENCES Drinks(drink_id),
	side_id tinyint FOREIGN KEY REFERENCES Sides(side_id),
	item_id tinyint FOREIGN KEY REFERENCES Service_Items(item_id),
);

GO

INSERT INTO Meat (meat_type)
VALUES ('Beef'),
('Chicken'),
('Fish'),
('Vegan Beef'),
('Vegan Chicken'),
('Bacon');

INSERT INTO Cheese (cheese_type)
VALUES ('Emmentaler Cheese'),
('Cheddar Cheese');

INSERT INTO Bread (bread_type)
VALUES ('Coarse Bun'),
('Brioche Bun'),
('Sesame Bun'),
('Steamed Bun');

INSERT INTO Dressing_And_Dip (dad_type)
VALUES ('Ketchup'),
('Pommes Frites Sauce'),
('Mayo'),
('Cheddar Dip'),
('Garlic Dip'),
('Chili Mayo'),
('Béarnaise Dip'),
('BBQ Dip'),
('Sweet N Sour Dip'),
('Curry Sauce'),
('Mustard Dip'),
('Big Mac Sauce'),
('Cajun Sauce'),
('Tasty Sauce'),
('Tartar Sauce');

INSERT INTO Salad (salad_type)
VALUES ('Iceberg Lettuce');

INSERT INTO Fruit_And_Veg (fav_type)
VALUES ('Tomatoes'),
('Pickles'),
('Red Onions'),
('Pickled Red Onions'),
('White Onions'),
('Minced Onions');

INSERT INTO Water (amount, brand)
VALUES (23, 'Aqua dOr');

INSERT INTO Juice (flavour, litres)
VALUES ('Fuze Tea Peach', 54),
('Tropicana Orange Juice', 38),
('Tropicana Apple Juice', 12),
('Organic Minimilk', 73);

INSERT INTO Soda (flavour, litres)
VALUES ('Coca-Cola', 632),
('Coca-Cola Zero', 321),
('Sprite Zero', 435),
('Fanta Orange', 556);

INSERT INTO Frappe (flavour, litres)
VALUES ('Sour Apple', 133),
('Coffee with Chocolate', 22),
('Coffee with Caramel', 453);

INSERT INTO Milkshake (flavour, litres)
VALUES ('Vanilla', 34),
('Strawberry', 28),
('Chocolate', 36),
('Mango and Passionfruit', 21);

INSERT INTO Coffee (coffee_type, litres)
VALUES ('Cortado', 71),
('Espresso', 84),
('Amerciano', 34),
('Flat White', 57),
('Filtercoffee', 93),
('Cappuccino', 92),
('Cocoa', 294),
('Latte', 32),
('Vanilla Latte', 34),
('Caramel Latte', 92),
('Chai Latte', 12),
('Iced-Latte', 20),
('Iced-Latte Caramel', 120),
('Iced-Latte Honey/Caramel', 78),
('Iced-Latte Vanilla', 71),
('Iced-Latte Chai', 214);

INSERT INTO Sides (name, amount)
VALUES ('Pommes Frites', 214),
('Sharing Frites', 523),
('Chili Cheese Tops', 127),	
('Carrot pieces', 251),
('Apple pieces', 912),
('Chicken McNuggets', 252),
('Hotwings', 344),
('Mixed Team Box', 82),
('McFlurry Smarties', 0),
('McFlurry Daim', 0),
('McFlurry Toms Turtles', 0),
('Sundae', 0),
('Sundae w. Chocolate', 0),
('Sundae w. Caramel', 0),
('Sundae w. Sprinkles', 0),
('Sundae w. Chocolatesauce and Sprinkles', 0),
('Sundae w. Caramelsauce and Sprinkles', 0);

INSERT INTO Bags (bag_size)
VALUES('Small'),
('Large');

INSERT INTO Lids (lid_size)
VALUES ('Small'),
('Medium'),
('Large');

INSERT INTO Alcohol (name, litres)
VALUES ('Light Rum', 62),
('Dark Rum', 212),
('Vodka', 632),
('Whisky', 354),
('Tequila', 0),
('Jägermeister', 21),
('Gin', 30),
('Baileys', 215),
('Malibu', 50),
('Råstof', 0);