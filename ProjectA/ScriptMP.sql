USE [ProjectA]
GO
/****** Object:  Table [dbo].[Advisor]    Script Date: 05/02/2019 8:36:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advisor](
	[Id] [int] NOT NULL,
	[Designation] [int] NOT NULL,
	[Salary] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Evaluation]    Script Date: 05/02/2019 8:36:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Evaluation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[TotalMarks] [int] NOT NULL,
	[TotalWeightage] [int] NOT NULL,
 CONSTRAINT [PK_Evaluation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Group]    Script Date: 05/02/2019 8:36:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created_On] [date] NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupEvaluation]    Script Date: 05/02/2019 8:36:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupEvaluation](
	[GroupId] [int] NOT NULL,
	[EvaluationId] [int] NOT NULL,
	[ObtainedMarks] [int] NOT NULL,
	[EvaluationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_GroupEvaluation] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[EvaluationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupProject]    Script Date: 05/02/2019 8:36:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupProject](
	[ProjectId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_GroupProject] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC,
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupStudent]    Script Date: 05/02/2019 8:36:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupStudent](
	[GroupId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_GroupStudent] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lookup]    Script Date: 05/02/2019 8:36:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lookup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](100) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Lookup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Person]    Script Date: 05/02/2019 8:36:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NULL,
	[Contact] [varchar](20) NULL,
	[Email] [varchar](30) NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[Gender] [int] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Project]    Script Date: 05/02/2019 8:36:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](max) NULL,
	[Title] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjectAdvisor]    Script Date: 05/02/2019 8:36:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectAdvisor](
	[AdvisorId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[AdvisorRole] [int] NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ProjectAdvisor] PRIMARY KEY CLUSTERED 
(
	[AdvisorId] ASC,
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 05/02/2019 8:36:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] NOT NULL,
	[RegistrationNo] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[ProjectView]    Script Date: 05/02/2019 8:36:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[ProjectView] AS Select Salary, Designation from Advisor where Salary = '120000'
GO
/****** Object:  View [dbo].[Query1]    Script Date: 05/02/2019 8:36:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[Query1] As
Select Concat(FirstName, LastName) As Name ,  Designation from Advisor Join Person On Person.Id = Advisor.Id
 Where Advisor.Id Not in (Select AdvisoriD FROM ProjectAdvisor)
GO
/****** Object:  View [dbo].[Query2]    Script Date: 05/02/2019 8:36:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[Query2] As
Select Concat(FirstName,LastName) as Name, Title from 
(ProjectAdvisor Join Person On ProjectAdvisor.AdvisorId = Person.Id)
Join Project On Project.Id = ProjectAdvisor.ProjectId

GO
/****** Object:  View [dbo].[Query3]    Script Date: 05/02/2019 8:36:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[Query3] As
 Select p1.FirstName AS Advisor_Name,  P2.FirstName As Student_Name from Person as P1
 JOIN Advisor on Advisor.Id = P1.Id
 JOIN ProjectAdvisor ON ProjectAdvisor.AdvisorId = Advisor.Id
 Join GroupProject ON GroupProject.ProjectId = ProjectAdvisor.ProjectId
 JOIN [GroupStudent] ON GroupProject.GroupId = GroupStudent.GroupId
 JOIN Person AS P2 ON P2.Id = GroupStudent.StudentId
GO
/****** Object:  View [dbo].[Query5]    Script Date: 05/02/2019 8:36:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[Query5] As
SElect Concat(FirstName, LastName) as AdvisorName, Count(ProjectId) as Project_Count  from Advisor
JOIN Person ON Person.Id = Advisor.Id
JOIN ProjectAdvisor as P1 ON P1.AdvisorId = Advisor.Id 
JOIN Project ON Project.Id = P1.ProjectId Group BY concat(FirstName,LastName)
GO
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (1, 12, CAST(123 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (2, 7, CAST(120000 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (3, 7, CAST(13000 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (4, 9, CAST(53 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (98, 7, CAST(250000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Evaluation] ON 

INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (42, N'Rida Mahmood', 1100, 65)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (46, N'Rida', 123333, 123)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (48, N'wee', 323, 33)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (49, N'rida mahmood', 1000, 90)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (50, N'Rida Mahmood', 1100, 65)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (51, N'Fatima', 1000, 67)
SET IDENTITY_INSERT [dbo].[Evaluation] OFF
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (2, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (4, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (5, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (6, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (7, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (8, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (9, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (12, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (13, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (14, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (15, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (16, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (18, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (19, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (20, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (21, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (22, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (23, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (24, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (25, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (26, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (27, CAST(N'1900-01-01' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (28, CAST(N'1999-02-01' AS Date))
SET IDENTITY_INSERT [dbo].[Group] OFF
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (1, 42, 321, CAST(N'1900-01-01 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (3, 46, 2890, CAST(N'1999-01-02 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (15, 1, CAST(N'1900-01-01 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (22, 3, CAST(N'1999-01-01 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (24, 2, CAST(N'1999-02-02 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (1, 74, 3, CAST(N'1900-01-01 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (1, 78, 3, CAST(N'1900-01-01 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (2, 74, 3, CAST(N'1900-01-01 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (2, 78, 3, CAST(N'1900-01-01 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Lookup] ON 

INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (1, N'Male', N'GENDER')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (2, N'Female', N'GENDER')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (3, N'Active', N'STATUS')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (4, N'InActive', N'STATUS')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (6, N'Professor', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (7, N'Associate Professor', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (8, N'Assisstant Professor', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (9, N'Lecturer', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (10, N'Industry Professional', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (11, N'Main Advisor', N'ADVISOR_ROLE')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (12, N'Co-Advisror', N'ADVISOR_ROLE')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (14, N'Industry Advisor', N'ADVISOR_ROLE')
SET IDENTITY_INSERT [dbo].[Lookup] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (40, N'rida', N'mahmood', N'1234', N'12@gmail.com', CAST(N'2003-01-02 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (53, N'Rida', N'Mahmood', N'03034347004', N'rida175@gmail.com', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (54, N'rida', N'mahmood', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (55, N'fatima', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (56, N'tayyaba', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (57, N'raheel', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (58, N'adeel', N'mahmood', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (59, N'tooba', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (60, N'tooba', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (61, N'shah', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (62, N'tayyaba noor ', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (63, N'tayyaba noor ', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (64, N'raheel mahmood', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (65, N'qazwsxedc', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (66, N'rida', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (67, N'Rida', N'Mahmood', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (68, N'Rida', N'Mahmood', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (69, N'rida', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (70, N'rida', N'', N'', N'rida12@gmail.com', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (71, N'noor', N'', N'', N'456@gmail.com', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (72, N'rida', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (73, N'rida', N'', N'', N'987@gmail.com', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (74, N'fatima', N'', N'', N'fatima@gmail.com', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (78, N'Rida ', N'Mahmood', N'03034347004', N'rida1732@gmail.com', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (81, N'fatimaaaaa', N'', N'', N'fatima@gmail.com', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (82, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (83, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (84, N'noor', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (85, N'', N'', N'', N'sec@gmail.com', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (86, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (87, N'Saba', N'Arshad', N'03001234567', N'saba@gmail.com', CAST(N'1999-12-01 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (88, N'Tooba', N'Naseer', N'0300', N'tooba@gmail.com', CAST(N'1998-03-06 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (89, N'Rabeya', N'Hamood', N'123455', N'rabi@gmail.com', CAST(N'1997-11-03 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (90, N'Shazia', N'Fahad', N'03134242456', N'shazia@gmail.com', CAST(N'2001-02-05 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (91, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (92, N'', N'', N'', N'abc@gmail.com', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (93, N'', N'', N'', N'abc@gmail.com', CAST(N'2011-02-01 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (94, N'Shazia', N'', N'', N'abc@gmail.com', CAST(N'2011-02-01 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (95, N'Shazia', N'', N'', N'abcd@gmail.com', CAST(N'2011-02-01 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (98, N'Rida', N'Mahmood', N'03004198605', N'rida@gmail.com', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (99, N'fatima', N'jAVED', N'0300123355', N'fatima@gmail.com', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (100, N'fatima', N'Javed', N'030001234', N'fatima@gmail.com', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (101, N'fatima', N'', N'', N'fatima@gmail.com', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (102, N'fatima', N'', N'', N'fatima@gmail.com', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (103, N'', N'', N'', N'sec@gmail.com', CAST(N'1900-01-01 00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (15, N'this is a project', N'KinderGarten Management System')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (16, N'It is my homeland', N'Pakistan')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (22, N'IT IS GOOD', N'GOOD')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (23, N'IT IS BAD', N'BAD')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (24, N'IT IS DATABASE', N'DATABASE')
SET IDENTITY_INSERT [dbo].[Project] OFF
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (1, 15, 11, CAST(N'1900-01-01 00:00:00.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (2, 15, 11, CAST(N'2019-01-02 00:00:00.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (3, 24, 14, CAST(N'1999-02-01 00:00:00.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (4, 22, 11, CAST(N'1999-01-02 00:00:00.000' AS DateTime))
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (74, N'21')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (78, N'4')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (85, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (87, N'77')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (88, N'72')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (89, N'81')
ALTER TABLE [dbo].[Advisor]  WITH CHECK ADD  CONSTRAINT [FK_Advisor_Lookup] FOREIGN KEY([Designation])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[Advisor] CHECK CONSTRAINT [FK_Advisor_Lookup]
GO
ALTER TABLE [dbo].[GroupEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_GroupEvaluation_Evaluation] FOREIGN KEY([EvaluationId])
REFERENCES [dbo].[Evaluation] ([Id])
GO
ALTER TABLE [dbo].[GroupEvaluation] CHECK CONSTRAINT [FK_GroupEvaluation_Evaluation]
GO
ALTER TABLE [dbo].[GroupEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_GroupEvaluation_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[GroupEvaluation] CHECK CONSTRAINT [FK_GroupEvaluation_Group]
GO
ALTER TABLE [dbo].[GroupProject]  WITH CHECK ADD  CONSTRAINT [FK_GroupProject_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[GroupProject] CHECK CONSTRAINT [FK_GroupProject_Group]
GO
ALTER TABLE [dbo].[GroupProject]  WITH CHECK ADD  CONSTRAINT [FK_GroupProject_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[GroupProject] CHECK CONSTRAINT [FK_GroupProject_Project]
GO
ALTER TABLE [dbo].[GroupStudent]  WITH CHECK ADD  CONSTRAINT [FK_GroupStudents_Lookup] FOREIGN KEY([Status])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[GroupStudent] CHECK CONSTRAINT [FK_GroupStudents_Lookup]
GO
ALTER TABLE [dbo].[GroupStudent]  WITH CHECK ADD  CONSTRAINT [FK_ProjectStudents_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[GroupStudent] CHECK CONSTRAINT [FK_ProjectStudents_Group]
GO
ALTER TABLE [dbo].[GroupStudent]  WITH CHECK ADD  CONSTRAINT [FK_ProjectStudents_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[GroupStudent] CHECK CONSTRAINT [FK_ProjectStudents_Student]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Lookup] FOREIGN KEY([Gender])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Lookup]
GO
ALTER TABLE [dbo].[ProjectAdvisor]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAdvisor_Lookup] FOREIGN KEY([AdvisorRole])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[ProjectAdvisor] CHECK CONSTRAINT [FK_ProjectAdvisor_Lookup]
GO
ALTER TABLE [dbo].[ProjectAdvisor]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAdvisor_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[ProjectAdvisor] CHECK CONSTRAINT [FK_ProjectAdvisor_Project]
GO
ALTER TABLE [dbo].[ProjectAdvisor]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTeachers_Teacher] FOREIGN KEY([AdvisorId])
REFERENCES [dbo].[Advisor] ([Id])
GO
ALTER TABLE [dbo].[ProjectAdvisor] CHECK CONSTRAINT [FK_ProjectTeachers_Teacher]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Person] FOREIGN KEY([Id])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Person]
GO
/****** Object:  StoredProcedure [dbo].[Proc1]    Script Date: 05/02/2019 8:36:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create Procedure [dbo].[Proc1]
 @GroupId int
  AS SELECT Name AS EvaluationTitle , TotalMarks, ObtainedMarks
  from Evaluation JOIN GroupEvaluation ON GroupEvaluation.GroupId = Evaluation.Id
  WHERE GroupEvaluation.GroupId = @GroupId
GO
/****** Object:  StoredProcedure [dbo].[Proc2]    Script Date: 05/02/2019 8:36:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create Procedure [dbo].[Proc2]
 @AdvisorName int
 AS select Student.Id , FirstName AS StudentName , [GROUP].Id
 From Person JOIN Advisor ON Person.Id = Advisor.Id
 JOIN ProjectAdvisor ON ProjectAdvisor.AdvisorId = Advisor.Id
 JOIN Project ON Project.Id = ProjectAdvisor.ProjectId
 JOIN GroupProject ON GroupProject.ProjectId = Project.Id
 JOIN [Group] ON [Group].Id = GroupProject.GroupId
 JOIN GroupStudent ON GroupStudent.GroupId = [Group].Id
 JOIN Student ON Student.Id= GroupStudent.StudentId
 WHERE FirstName= @AdvisorName and GroupStudent.Status = 3
GO
