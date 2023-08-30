CREATE TABLE Orders (
	order_id int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	order_date date DEFAULT GETDATE(),
	product varchar(64) NOT NULL,
	amount int NOT NULL
);

CREATE TABLE OrderDetails (
	ordetail_id int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	order_id int FOREIGN KEY REFERENCES Orders(order_id),
	ingredient_id tinyint FOREIGN KEY REFERENCES Ingredients(ingredient_id),
	ingredient_amnt smallint NOT NULL DEFAULT 0,
	drink_id tinyint FOREIGN KEY REFERENCES Drinks(drink_id),
	drink_amnt smallint NOT NULL DEFAULT 0,
	side_id tinyint FOREIGN KEY REFERENCES Sides(side_id),
	side_amnt smallint NOT NULL DEFAULT 0,
	item_id tinyint FOREIGN KEY REFERENCES Service_Items(item_id),
	item_amnt smallint NOT NULL DEFAULT 0
);