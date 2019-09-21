USE Hotel

ALTER TABLE Payments
ALTER COLUMN TaxRate DECIMAL(15,2)

UPDATE Payments
SET TaxRate -= TaxRate * 0.03

SELECT TaxRate FROM Payments