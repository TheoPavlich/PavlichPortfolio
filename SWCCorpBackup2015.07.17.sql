USE [master]
GO
/****** Object:  Database [SWCCorp]    Script Date: 7/17/2015 12:00:12 PM ******/
CREATE DATABASE [SWCCorp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SWCCorp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\SWCCorp.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SWCCorp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\SWCCorp_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SWCCorp] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SWCCorp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SWCCorp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SWCCorp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SWCCorp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SWCCorp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SWCCorp] SET ARITHABORT OFF 
GO
ALTER DATABASE [SWCCorp] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SWCCorp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SWCCorp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SWCCorp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SWCCorp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SWCCorp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SWCCorp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SWCCorp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SWCCorp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SWCCorp] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SWCCorp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SWCCorp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SWCCorp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SWCCorp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SWCCorp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SWCCorp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SWCCorp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SWCCorp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SWCCorp] SET  MULTI_USER 
GO
ALTER DATABASE [SWCCorp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SWCCorp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SWCCorp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SWCCorp] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SWCCorp] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SWCCorp]
GO
/****** Object:  Table [dbo].[CurrentProducts]    Script Date: 7/17/2015 12:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CurrentProducts](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[RetailPrice] [money] NULL,
	[OriginationDate] [datetime] NULL,
	[ToBeDeleted] [bit] NULL,
	[Category] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 7/17/2015 12:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[EmpID] [int] IDENTITY(15,1) NOT NULL,
	[LastName] [varchar](30) NULL,
	[FirstName] [varchar](20) NULL,
	[HireDate] [datetime] NULL,
	[LocationID] [int] NULL,
	[ManagerID] [int] NULL,
	[Status] [char](12) NULL,
 CONSTRAINT [PK__Employee__AF2DBA796A594775] PRIMARY KEY CLUSTERED 
(
	[EmpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Grant]    Script Date: 7/17/2015 12:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grant](
	[GrantID] [char](3) NOT NULL,
	[GrantName] [nvarchar](50) NOT NULL,
	[EmpID] [int] NULL,
	[Amount] [smallmoney] NULL,
UNIQUE NONCLUSTERED 
(
	[GrantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Location]    Script Date: 7/17/2015 12:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Location](
	[LocationID] [int] NOT NULL,
	[Street] [varchar](30) NULL,
	[City] [varchar](20) NULL,
	[State] [char](2) NULL,
UNIQUE NONCLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MgmtTraining]    Script Date: 7/17/2015 12:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MgmtTraining](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [varchar](50) NOT NULL,
	[ClassDurationHours] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PayRates]    Script Date: 7/17/2015 12:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayRates](
	[EmpID] [int] NOT NULL,
	[YearlySalary] [smallmoney] NULL,
	[MonthlySalary] [smallmoney] NULL,
	[HourlyRate] [smallmoney] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Timesheets]    Script Date: 7/17/2015 12:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Timesheets](
	[TimeID] [int] IDENTITY(1,1) NOT NULL,
	[Hours] [decimal](18, 2) NOT NULL,
	[EmpID] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Timesheets] PRIMARY KEY CLUSTERED 
(
	[TimeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Timesheets]  WITH CHECK ADD  CONSTRAINT [FK_Timesheets_Employee] FOREIGN KEY([EmpID])
REFERENCES [dbo].[Employee] ([EmpID])
GO
ALTER TABLE [dbo].[Timesheets] CHECK CONSTRAINT [FK_Timesheets_Employee]
GO
/****** Object:  StoredProcedure [dbo].[AddTimesheet]    Script Date: 7/17/2015 12:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddTimesheet] (
@Date Date,
@Hours Float,
@EmpID int
) AS
INSERT INTO Timesheets ([Date],[Hours],EmpID)
VALUES (@Date,@Hours, @EmpID)

GO
/****** Object:  StoredProcedure [dbo].[DeleteTimesheet]    Script Date: 7/17/2015 12:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteTimesheet] (
@TimeID int
) AS

DELETE FROM Timesheets
WHERE TimeID = @TimeID

GO
/****** Object:  StoredProcedure [dbo].[GetAllEmployees]    Script Date: 7/17/2015 12:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllEmployees] AS
SELECT * FROM Employee
GO
/****** Object:  StoredProcedure [dbo].[GetAllTimesheets]    Script Date: 7/17/2015 12:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllTimesheets] 
AS
SELECT * FROM Timesheets

GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeById]    Script Date: 7/17/2015 12:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetEmployeeById](
	@EmpID int
	)
	AS
	
	SELECT *
	FROM Employee
	WHERE EmpID = @EmpID



GO
/****** Object:  StoredProcedure [dbo].[GetTimesheetsByEmployeeID]    Script Date: 7/17/2015 12:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTimesheetsByEmployeeID] (
@EmpID int
)
AS

SELECT *
FROM Timesheets
WHERE EmpID=@EmpID


GO
/****** Object:  StoredProcedure [dbo].[InsertEmployee]    Script Date: 7/17/2015 12:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertEmployee]
(
@FirstName varchar(20),
@LastName varchar(30),
@EmpID int output
)
As

BEGIN
	INSERT INTO Employee (FirstName, LastName)
	VALUES (@FirstName, @LastName)

	SET @EmpID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spGetEmployeeLastAndState]    Script Date: 7/17/2015 12:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spGetEmployeeLastAndState]
@eid char(3)
as
select e.Lastname, a.state
from Employee as e inner join Location as a
on e.LocationID = a.LocationID
where e.LocationID = @eid

GO
/****** Object:  StoredProcedure [dbo].[SumTimesheets]    Script Date: 7/17/2015 12:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SumTimesheets](
@EmpId int
)
AS

SELECT Sum([Hours]) --AS HoursSum
FROM Timesheets
WHERE EmpID = @EmpId





GO
USE [master]
GO
ALTER DATABASE [SWCCorp] SET  READ_WRITE 
GO
