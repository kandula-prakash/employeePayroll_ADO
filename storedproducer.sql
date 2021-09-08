CREATE PROCEDURE [dbo].[SpAddEmployeeDetails]
(
	@Name VARCHAR(255),
	@BasicPay FLOAT,
	@Start DATE,
	@Gender CHAR(1),
	@PhoneNumber VARCHAR(255),
	@Address VARCHAR(255),
	@Department VARCHAR(255),
	@Deduction FLOAT,
	@TaxablePay FLOAT,
	@IncomeTax FLOAT,
	@NetPay FLOAT
)
AS
BEGIN
	INSERT INTO employee_payroll VALUES
	(@Name,@BasicPay,@Start,@Gender,@PhoneNumber,@Address,@Department,@Deduction,@TaxablePay,@IncomeTax,@NetPay)
END
GO