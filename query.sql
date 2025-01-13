-- Create the Categories table
INSERT INTO dbo.Categories (Name, Description, CreatedAt)
VALUES
    ('Networking Devices', 'Routers, Switches, Firewalls', GETDATE()),
    ('Storage Devices', 'Hard Drives, Solid State Drives, NAS', GETDATE()),
    ('Peripheral Devices', 'Keyboards, Mice, Printers', GETDATE()),
    ('Mobile Devices', 'Smartphones, Tablets', GETDATE()),
    ('Gaming Devices', 'Consoles, Controllers', GETDATE());

SELECT * FROM dbo.Categories;

-- Create the Devices table
INSERT INTO dbo.Devices (Name, Code, Status, CategoryId, CreatedAt)
VALUES 
    ('Cisco Router', 'CR-001', 1, 1, GETDATE()),
    ('Dell Switch', 'DS-001', 1, 1, GETDATE()),
    ('SonicWall Firewall', 'SF-001', 0, 1, GETDATE()),
    ('Seagate Hard Drive', 'SHD-001', 0, 2, GETDATE()),
    ('Samsung SSD', 'SSD-001', 1, 2, GETDATE()),
    ('Synology NAS', 'NAS-001', 1, 2, GETDATE()),
    ('Logitech Keyboard', 'LK-001', 1, 3, GETDATE()),
    ('Microsoft Mouse', 'MM-001', 1, 3, GETDATE()),
    ('HP Printer', 'HP-001', 0, 3, GETDATE()),
    ('Apple iPhone', 'IP-001', 0, 4, GETDATE()),
    ('Samsung Galaxy Tab', 'SGT-001', 1, 4, GETDATE()),
    ('Sony PlayStation', 'PS-001', 1, 5, GETDATE()),
    ('Microsoft Xbox', 'XB-001', 1, 5, GETDATE());

SELECT * FROM dbo.Devices;

-- Create the Users table
INSERT INTO dbo.Users (Fullname, PhoneNumber, Email, CreatedAt)
VALUES
    ('John Doe', '123-456-7890', 'example@gmail.com', GETDATE()),
    ('Jane Doe', '123-456-7891', 'jane@gmail.com', GETDATE()),
    ('Alice Smith', '123-456-7892', 'smith@gmail.com', GETDATE()),
    ('Bob Johnson', '123-456-7893', 'bob@gmail.com', GETDATE());

SELECT * FROM dbo.Users;