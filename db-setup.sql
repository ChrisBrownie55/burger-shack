-- CREATE TABLE burgers (
--   id int NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   price DECIMAL NOT NULL,
--   PRIMARY KEY(id)
-- );

-- INSERT INTO burgers (name, description, price) VALUES ("The Plain Jane", "Burger on a bun", 7.99);

-- ALTER TABLE burgers MODIFY COLUMN price DECIMAL(10, 2);

-- UPDATE burgers SET price = 7.99 WHERE id = 1;

-- CREATE TABLE smoothies (
--   id int NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   price DECIMAL NOT NULL,
--   PRIMARY KEY(id)
-- );

-- INSERT INTO smoothies (name, description, price) VALUES ("The Plain Jane", "It is just fruit, not even blended", 7.99);

-- ALTER TABLE smoothies MODIFY COLUMN price DECIMAL(10, 2);

-- UPDATE smoothies SET price = 7.99 WHERE id = 1;


-- User Table Creation
CREATE TABLE users (
  id VARCHAR(255) NOT NULL,
  name VARCHAR(20) NOT NULL,
  email VARCHAR(255) NOT NULL,
  hash VARCHAR(255) NOT NULL,
  PRIMARY KEY (id),
  UNIQUE KEY email (email)
);

-- Favorites Table
CREATE TABLE userburgers (
  id int NOT NULL AUTO_INCREMENT,
  burgerId int NOT NULL,
  userId VARCHAR(255) NOT NULL,
  PRIMARY KEY (id),
  INDEX (userId),
  FOREIGN KEY (userId) REFERENCES users(id) ON DELETE CASCADE,
  FOREIGN KEY (burgerId) REFERENCES burgers(id) ON DELETE CASCADE
);