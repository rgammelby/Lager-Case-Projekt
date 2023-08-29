-- checks if database exists, creates database if not
IF db_id('Storage') IS NULL
	USE [master]
	CREATE DATABASE [Storage]

GO

USE [Storage]

-- INGREDIENT BIT
CREATE TABLE Meat (
	meat_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	meat_type VARCHAR(50) NOT NULL
);

CREATE TABLE Cheese (
	cheese_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	cheese_type VARCHAR(50) NOT NULL
);

CREATE TABLE Bread (
	bread_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	bread_type VARCHAR(50) NOT NULL
);

CREATE TABLE Dressing_And_Dip (
	dad_id TINYINT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	dad_type VARCHAR(50) NOT NULL
);

CREATE TABLE Salad (
	salad_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	salad_type VARCHAR(50) NOT NULL
);

CREATE TABLE Fruit_And_Veg (
	fav_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	fav_type VARCHAR(50) NOT NULL
);


CREATE TABLE Ingredients (
	ingredient_id TINYINT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	meat TINYINT FOREIGN KEY REFERENCES Meat(meat_id),
	cheese TINYINT FOREIGN KEY REFERENCES Cheese(cheese_id),
	bread TINYINT FOREIGN KEY REFERENCES Bread(bread_id),
	dad TINYINT FOREIGN KEY REFERENCES Dressing_And_Dip(dad_id),
	salad TINYINT FOREIGN KEY REFERENCES Salad(salad_id),
	fav TINYINT FOREIGN KEY REFERENCES Fruit_And_Veg(fav_id)
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
	amount INT NOT NULL,
	CHECK (amount >= 0)
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
	water_id TINYINT FOREIGN KEY REFERENCES Water(water_id) NOT NULL,
	juice_id TINYINT FOREIGN KEY REFERENCES Juice(juice_id) NOT NULL,
	soda_id TINYINT FOREIGN KEY REFERENCES Soda(soda_id) NOT NULL,
	frappe_id TINYINT FOREIGN KEY REFERENCES Frappe(frappe_id) NOT NULL,
	milkshake_id TINYINT FOREIGN KEY REFERENCES Milkshake(milkshake_id) NOT NULL,
	coffee_id TINYINT FOREIGN KEY REFERENCES Coffee(coffee_id) NOT NULL,
	alcohol_id TINYINT FOREIGN KEY REFERENCES Alcohol(alcohol_id) NOT NULL
);

-- MISCELLANEOUS
CREATE TABLE Sides (
	side_id TINYINT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	name VARCHAR(50) NOT NULL,
	amount INT NOT NULL
);

-- Size: Small, Large
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
	order_id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	ingredient_id TINYINT FOREIGN KEY REFERENCES Ingredients(ingredient_id) NOT NULL,
	drink_id TINYINT FOREIGN KEY REFERENCES Drinks(drink_id) NOT NULL,
	side_id TINYINT FOREIGN KEY REFERENCES Sides(side_id) NOT NULL,
	item_id TINYINT FOREIGN KEY REFERENCES Service_Items(item_id) NOT NULL
);
