CREATE TABLE countries (
    country_id INT AUTO_INCREMENT PRIMARY KEY,
    country_name VARCHAR(100) NOT NULL UNIQUE
);
 
CREATE TABLE economic_data (
    id INT AUTO_INCREMENT PRIMARY KEY,
    country_id INT NOT NULL,
    year INT NOT NULL,
    gdp_growth FLOAT NOT NULL,
    inflation FLOAT NOT NULL,
 
 
    FOREIGN KEY (country_id)REFERENCES countries(country_id)
);
 
CREATE TABLE demographic_data (
    id INT AUTO_INCREMENT PRIMARY KEY,
    country_id INT NOT NULL,
    year INT NOT NULL,
    population INT NOT NULL,
  
    FOREIGN KEY (country_id)REFERENCES countries(country_id)
);