-- Insert Brands if not exist
SET IDENTITY_INSERT Brands ON;

INSERT INTO Brands (Id, Name, Description)
SELECT 1, 'Toyota', 'Fabricante de automóviles japonés'
WHERE NOT EXISTS (SELECT 1 FROM Brands WHERE Id = 1);

INSERT INTO Brands (Id, Name, Description)
SELECT 2, 'Ford', 'Fabricante de automóviles multinacional estadounidense'
WHERE NOT EXISTS (SELECT 1 FROM Brands WHERE Id = 2);

INSERT INTO Brands (Id, Name, Description)
SELECT 3, 'Honda', 'Fabricante japonés de motocicletas y automóviles.'
WHERE NOT EXISTS (SELECT 1 FROM Brands WHERE Id = 3);

SET IDENTITY_INSERT Brands OFF;

-- Insert Models if not exist
SET IDENTITY_INSERT Models ON;

INSERT INTO Models (Id, Name, Description, BrandId)
SELECT 1, 'Camry', 'modelo de auto de tamaño mediano', 1
WHERE NOT EXISTS (SELECT 1 FROM Models WHERE Id = 1);

INSERT INTO Models (Id, Name, Description, BrandId)
SELECT 2, 'Civic', 'modelo de coche compacto', 3
WHERE NOT EXISTS (SELECT 1 FROM Models WHERE Id = 2);

SET IDENTITY_INSERT Models OFF;

-- Insert FuelTypes if not exist
SET IDENTITY_INSERT FuelTypes ON;

INSERT INTO FuelTypes (Id, Name, Description)
SELECT 1, 'Gasolina', 'Tipo de combustible de gasolina estándar'
WHERE NOT EXISTS (SELECT 1 FROM FuelTypes WHERE Id = 1);

INSERT INTO FuelTypes (Id, Name, Description)
SELECT 2, 'Gas', 'Tipo de gas estándar'
WHERE NOT EXISTS (SELECT 1 FROM FuelTypes WHERE Id = 2);

SET IDENTITY_INSERT FuelTypes OFF;

-- Insert CreditCards if not exist
SET IDENTITY_INSERT CreditCards ON;

INSERT INTO CreditCards (Id, Number, HolderName_FirstName, HolderName_LastName, ExpirationDate, Cvv)
SELECT 1, '1234567891011121', 'John', 'Doe', '2025-12-31', '123'
WHERE NOT EXISTS (SELECT 1 FROM CreditCards WHERE Id = 1);

INSERT INTO CreditCards (Id, Number, HolderName_FirstName, HolderName_LastName, ExpirationDate, Cvv)
SELECT 2, '9876543210987654', 'Jane', 'Smith', '2024-10-31', '456'
WHERE NOT EXISTS (SELECT 1 FROM CreditCards WHERE Id = 2);

SET IDENTITY_INSERT CreditCards OFF;

-- Insert Persons if not exist
SET IDENTITY_INSERT Persons ON;

INSERT INTO Persons (Id, Name_FirstName, Name_LastName, Identification_Id)
SELECT 1, 'John', 'Doe', '12345678901'
WHERE NOT EXISTS (SELECT 1 FROM Persons WHERE Id = 1);

INSERT INTO Persons (Id, Name_FirstName, Name_LastName, Identification_Id)
SELECT 2, 'Jane', 'Smith', '34264578890'
WHERE NOT EXISTS (SELECT 1 FROM Persons WHERE Id = 2);

INSERT INTO Persons (Id, Name_FirstName, Name_LastName, Identification_Id)
SELECT 3, 'Mike', 'Wazowski', '12332112332'
WHERE NOT EXISTS (SELECT 1 FROM Persons WHERE Id = 3);

INSERT INTO Persons (Id, Name_FirstName, Name_LastName, Identification_Id)
SELECT 4, 'Autumn', 'Theobald', '73543234343'
WHERE NOT EXISTS (SELECT 1 FROM Persons WHERE Id = 4);

SET IDENTITY_INSERT Persons OFF;

-- Insert Clients if not exist
SET IDENTITY_INSERT Clients ON;

INSERT INTO Clients (Id, PersonId, CreditCardId, CreditLimit, PersonType)
SELECT 1, 1, 1, 5000.00, 1
WHERE NOT EXISTS (SELECT 1 FROM Clients WHERE Id = 1);

INSERT INTO Clients (Id, PersonId, CreditCardId, CreditLimit, PersonType)
SELECT 2, 2, 2, 7000.00, 2
WHERE NOT EXISTS (SELECT 1 FROM Clients WHERE Id = 2);

SET IDENTITY_INSERT Clients OFF;

-- Insert Employees if not exist
SET IDENTITY_INSERT Employees ON;

INSERT INTO Employees (Id, PersonId, WorkShift, CommissionPercentage, EntryDate)
SELECT 1, 3, 1, 5.0, '2022-01-15'
WHERE NOT EXISTS (SELECT 1 FROM Employees WHERE Id = 1);

INSERT INTO Employees (Id, PersonId, WorkShift, CommissionPercentage, EntryDate)
SELECT 2, 4, 4, 7.5, '2023-03-01'
WHERE NOT EXISTS (SELECT 1 FROM Employees WHERE Id = 2);

SET IDENTITY_INSERT Employees OFF;

-- Insert VehicleTypes if not exist
SET IDENTITY_INSERT VehicleTypes ON;

INSERT INTO VehicleTypes (Id, Name, Description)
SELECT 1, 'Sedan', 'Tipo de vehículo sedán estándar'
WHERE NOT EXISTS (SELECT 1 FROM VehicleTypes WHERE Id = 1);

INSERT INTO VehicleTypes (Id, Name, Description)
SELECT 2, 'Compact', 'Tipo de vehículo compacto'
WHERE NOT EXISTS (SELECT 1 FROM VehicleTypes WHERE Id = 2);

SET IDENTITY_INSERT VehicleTypes OFF;

-- Insert Vehicles if not exist
SET IDENTITY_INSERT Vehicles ON;

INSERT INTO Vehicles (Id, Description, Chassis, Motor, Plate, VehicleTypeId, BrandId, ModelId, FuelTypeId)
SELECT 1, 'Sedan', 'ABC12345', 'XYZ67890', 'ABC-123', 1, 1, 1, 1
WHERE NOT EXISTS (SELECT 1 FROM Vehicles WHERE Id = 1);

INSERT INTO Vehicles (Id, Description, Chassis, Motor, Plate, VehicleTypeId, BrandId, ModelId, FuelTypeId)
SELECT 2, 'Auto compacto', 'DEF56789', 'UVW45678', 'DEF-456', 1, 2, 2, 1
WHERE NOT EXISTS (SELECT 1 FROM Vehicles WHERE Id = 2);

SET IDENTITY_INSERT Vehicles OFF;

-- Insert Inspections if not exist
SET IDENTITY_INSERT Inspections ON;

INSERT INTO Inspections (Id, VehicleId, HaveScratches, Fuel, HasSpareWheel, HasSpareJack, HasBrokenGlass,
  IsLeftFrontWheelDamaged, IsRightFrontWheelDamaged, IsLeftRearWheelDamaged, IsRightRearWheelDamaged,
  Date, EmployeeId, Comment)
SELECT 1, 1, 0, 'Full', 1, 1, 0, 0, 0, 0, 0, '2023-03-10', 1, 'No se encontraron problemas'
WHERE NOT EXISTS (SELECT 1 FROM Inspections WHERE Id = 1);

INSERT INTO Inspections (Id, VehicleId, HaveScratches, Fuel, HasSpareWheel, HasSpareJack, HasBrokenGlass,
  IsLeftFrontWheelDamaged, IsRightFrontWheelDamaged, IsLeftRearWheelDamaged, IsRightRearWheelDamaged,
  Date, EmployeeId, Comment)
SELECT 2, 2, 1, 'Medio', 0, 1, 1, 0, 1, 0, 1, '2023-03-12', 2, 'Daños menores observados'
WHERE NOT EXISTS (SELECT 1 FROM Inspections WHERE Id = 2);

SET IDENTITY_INSERT Inspections OFF;

-- Insert Rents if not exist
SET IDENTITY_INSERT Rents ON;

INSERT INTO Rents (Id, TransactionId, EmployeeId, VehicleId, ClientId, RentDate, ReturnDate, PricePerDay, Days, ExtraordinaryDays, Comment)
SELECT 1, NEWID(), 1, 1, 1, '2023-04-05', '2023-04-10', 50.00, 5, 0, 'Experiencia de alquiler fluida'
WHERE NOT EXISTS (SELECT 1 FROM Rents WHERE Id = 1);

INSERT INTO Rents (Id, TransactionId, EmployeeId, VehicleId, ClientId, RentDate, ReturnDate, PricePerDay, Days, ExtraordinaryDays, Comment)
SELECT 2, NEWID(), 2, 2, 2, '2023-05-15', '2023-05-20', 60.00, 5, 0, 'Alquiler satisfactorio'
WHERE NOT EXISTS (SELECT 1 FROM Rents WHERE Id = 2);

SET IDENTITY_INSERT Rents OFF;