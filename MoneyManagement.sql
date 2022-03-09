CREATE TABLE user_ (
    id_no VARCHAR (50) PRIMARY KEY,
    name VARCHAR (25) DEFAULT NULL,
    password VARCHAR (70) NOT NULL,
);

Create Table transaction_(
transaction_id INT IDENTITY(1,1) PRIMARY KEY,
id_no VARCHAR (50),
amount INT,
transaction_type VARCHAR (50),
FOREIGN KEY (id_no) REFERENCES user_ (id_no)
);