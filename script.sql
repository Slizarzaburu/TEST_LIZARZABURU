
USE [master];
GO

CREATE DATABASE [MasGlobalTEST];
GO

USE [MasGlobalTEST];
GO


CREATE TABLE EMPLOYEE ( 
             id                 INT PRIMARY KEY IDENTITY , 
             first_name         VARCHAR(20) NOT NULL , 
             last_name          VARCHAR(20) NULL , 
             gender             CHAR(1) NULL , 
             identification     VARCHAR(20) NOT NULL , 
             district_residence VARCHAR(20) NOT NULL , 
             address_residence  VARCHAR(100) NULL , 
             email_address      VARCHAR(100) NULL , 
             phone_number       VARCHAR(10) NULL , 
             date_birth         DATE NULL , 
             occupation         VARCHAR(50) NULL , 
             register_date      DATETIME NULL , 
             hourly_contract    MONEY NULL , 
             monthly_contract   MONEY NULL , 
             type_contract      INT NULL
                      );
    GO


INSERT INTO EMPLOYEE ( first_name , last_name , gender , identification , district_residence , address_residence , email_address , phone_number , date_birth , occupation , register_date , hourly_contract , monthly_contract , type_contract
                     ) 
VALUES ( 'LUCIA' , 'HERNANDEZ' , 'F' , '17201111' , 'SAN ISIDRO' , '' , 'luciaestrella99@gmail.com' , '932943822' , CAST(N'1979-11-20' AS DATE) , 'STUDENT' , GETDATE() , 20 , 1000 , 3
       );
    GO

    INSERT INTO EMPLOYEE ( first_name , last_name , gender , identification , district_residence , address_residence , email_address , phone_number , date_birth , occupation , register_date , hourly_contract , monthly_contract , type_contract
                     ) 
VALUES ( 'STEVEN' , 'LIZARZABURU' , 'M' , '70111286' , 'CARABAYLLO' , '' , 'lizarzaburupezua@gmail.com' , '972555506' , CAST(N'1979-11-20' AS DATE) , 'PROGRAMMER' , GETDATE() , 10 , 500 , 1
       );
    GO

    INSERT INTO EMPLOYEE ( first_name , last_name , gender , identification , district_residence , address_residence , email_address , phone_number , date_birth , occupation , register_date , hourly_contract , monthly_contract , type_contract
                     ) 
VALUES ( 'FRANCIS' , 'VELAZCO' , 'M' , '45455555' , 'SAN MARTIN DE PORRES' , '' , 'francis@gmail.com' , '914555406' , CAST(N'1979-11-20' AS DATE) , 'DOCTOR' , GETDATE() , 5 , 1500 , 2
       );
    GO
                  


CREATE TABLE [dbo].[BUSINESSPARAM] ( 
             [id]                  INT PRIMARY KEY IDENTITY , 
             [name_value]          VARCHAR(40) NULL , 
             [description_value]   VARCHAR(50) NULL , 
             [first_value_int]     [INT] NULL , 
             [second_value_int]    INT NULL , 
             [third_value_int]     INT NULL , 
             [fourth_value_int]    INT NULL , 
             [fifth_value_int]     INT NULL , 
             [first_value_string]  VARCHAR(50) NULL , 
             [second_value_string] VARCHAR(50) NULL , 
             [third_value_string]  VARCHAR(50) NULL , 
             [fourth_value_string] VARCHAR(50) NULL , 
             [fifth_value_string]  VARCHAR(50) NULL
                                   );
    GO

INSERT INTO BUSINESSPARAM ( [name_value] , [description_value] , [first_value_int] , [second_value_int]
                          ) 
VALUES ( 'FORMULA' , 'Hourly Salary ' , 120 , 12
       );
    GO

INSERT INTO BUSINESSPARAM ( [name_value] , [description_value] , [first_value_int]
                          ) 
VALUES ( 'FORMULA' , 'Monthly Contract.' , 12
       );
    GO
    

CREATE PROCEDURE MASGLOBAL_GET_EMPLOYEE 
                 @P_IDEMPLOYEE INT
AS
    BEGIN
        SELECT ID, 
        first_name , 
        last_name ,
        CASE
        WHEN Gender = 'M'
        THEN 'MASCULINO'
        ELSE 'FEMENINO'
        END AS Gender , 
        identification , 
        district_residence , 
        address_residence , 
        email_address , 
        phone_number , 
        date_birth , 
        occupation , 
        register_date , 
        hourly_contract , 
        monthly_contract , 
        type_contract
        FROM EMPLOYEE
        WHERE ID = IIF(@P_IDEMPLOYEE = 0 , ID , @P_IDEMPLOYEE);
    END;
GO


CREATE PROCEDURE MASGLOBAL_CALCULATE_HOURLYSALARY 
                 @HOURLY_SALARY MONEY
AS
    BEGIN
        SELECT ROUND(first_value_int * @HOURLY_SALARY * first_value_int , 2) AS HOURLYSALARY
        FROM BUSINESSPARAM
        WHERE ID = 1;
    END; -- Hourly Salary
GO

CREATE PROCEDURE MASGLOBAL_CALCULATE_MONTHLYSALARY 
                 @MONTHLYSALARY MONEY
AS
    BEGIN
        SELECT ROUND(@MONTHLYSALARY * first_value_int , 2) AS MONTHLYSALARY
        FROM BUSINESSPARAM
        WHERE ID = 2;
    END; -- Monthly Contract
GO

	                                                                                                                                                                                                                  