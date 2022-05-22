USE [FlightBooking]
GO
/****** Object:  Table [dbo].[Airlines]    Script Date: 22-05-2022 19:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airlines](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AirlineName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Airlines] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 22-05-2022 19:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[PNRNo] [nvarchar](max) NOT NULL,
	[FlightID] [bigint] NOT NULL,
	[UserID] [bigint] NOT NULL,
	[BookedSeats] [bigint] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[Total] [decimal](18, 5) NOT NULL,
	[AppliedCoupenCode] [bigint] NULL,
	[IsCoupenApplied] [bit] NOT NULL,
	[IsCancelled] [bit] NOT NULL,
	[Meal] [nvarchar](50) NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CoupenCode]    Script Date: 22-05-2022 19:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoupenCode](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_CoupenCode] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 22-05-2022 19:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[StartPoint] [nvarchar](max) NOT NULL,
	[EndPoint] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 5) NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[IsDiscountAvailable] [bit] NOT NULL,
	[AirlineName] [nvarchar](max) NOT NULL,
	[ContactName] [nvarchar](max) NULL,
	[ContactNumber] [nvarchar](max) NULL,
	[SeatAvaibility] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[ScheduledDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMastertbl]    Script Date: 22-05-2022 19:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMastertbl](
	[RoleID] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RoleMastertbl] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceCity]    Script Date: 22-05-2022 19:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceCity](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ServiceCity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 22-05-2022 19:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMaster](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleID] [bigint] NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NULL,
	[CreatedOn] [nvarchar](max) NULL,
	[UpdatedOn] [nvarchar](max) NULL,
	[Gender] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[Token] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserMaster] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Airlines] ON 
GO
INSERT [dbo].[Airlines] ([Id], [AirlineName]) VALUES (1, N'AirAsia India')
GO
INSERT [dbo].[Airlines] ([Id], [AirlineName]) VALUES (2, N'Air India')
GO
INSERT [dbo].[Airlines] ([Id], [AirlineName]) VALUES (3, N'Air India Express')
GO
INSERT [dbo].[Airlines] ([Id], [AirlineName]) VALUES (4, N'Akasa Air')
GO
INSERT [dbo].[Airlines] ([Id], [AirlineName]) VALUES (5, N'Go First')
GO
INSERT [dbo].[Airlines] ([Id], [AirlineName]) VALUES (6, N'IndiGo')
GO
INSERT [dbo].[Airlines] ([Id], [AirlineName]) VALUES (7, N'SpiceJet')
GO
INSERT [dbo].[Airlines] ([Id], [AirlineName]) VALUES (8, N'Vistara')
GO
INSERT [dbo].[Airlines] ([Id], [AirlineName]) VALUES (9, N'Jet Airways')
GO
SET IDENTITY_INSERT [dbo].[Airlines] OFF
GO
SET IDENTITY_INSERT [dbo].[Bookings] ON 
GO
INSERT [dbo].[Bookings] ([ID], [PNRNo], [FlightID], [UserID], [BookedSeats], [CreatedOn], [UpdatedOn], [Total], [AppliedCoupenCode], [IsCoupenApplied], [IsCancelled], [Meal]) VALUES (2, N'f77941b5-7ba6-4a41-8924-53851eab8b59', 1, 1, 2, CAST(N'2022-05-06T20:16:42.293' AS DateTime), CAST(N'2022-05-06T20:16:44.120' AS DateTime), CAST(200.00000 AS Decimal(18, 5)), NULL, 0, 0, NULL)
GO
INSERT [dbo].[Bookings] ([ID], [PNRNo], [FlightID], [UserID], [BookedSeats], [CreatedOn], [UpdatedOn], [Total], [AppliedCoupenCode], [IsCoupenApplied], [IsCancelled], [Meal]) VALUES (3, N'd9267413-df8c-44ea-bbe0-6cd01ab1b8f7', 1, 1, 1, CAST(N'2022-05-15T19:05:42.130' AS DateTime), CAST(N'2022-05-15T19:05:44.103' AS DateTime), CAST(5000.00000 AS Decimal(18, 5)), 0, 1, 1, N'Non-Veg')
GO
INSERT [dbo].[Bookings] ([ID], [PNRNo], [FlightID], [UserID], [BookedSeats], [CreatedOn], [UpdatedOn], [Total], [AppliedCoupenCode], [IsCoupenApplied], [IsCancelled], [Meal]) VALUES (4, N'6240041f-4173-491f-bce1-9f0c10e9363d', 1, 1, 3, CAST(N'2022-05-15T21:03:48.677' AS DateTime), CAST(N'2022-05-15T21:03:50.543' AS DateTime), CAST(15000.00000 AS Decimal(18, 5)), 0, 1, 1, N'')
GO
INSERT [dbo].[Bookings] ([ID], [PNRNo], [FlightID], [UserID], [BookedSeats], [CreatedOn], [UpdatedOn], [Total], [AppliedCoupenCode], [IsCoupenApplied], [IsCancelled], [Meal]) VALUES (5, N'fb4ba68a-cf8f-4775-ad1f-570949e7cf3a', 1, 6, 2, CAST(N'2022-05-16T09:14:03.957' AS DateTime), CAST(N'2022-05-16T09:14:03.957' AS DateTime), CAST(10000.00000 AS Decimal(18, 5)), 0, 1, 1, N'Non-Veg')
GO
INSERT [dbo].[Bookings] ([ID], [PNRNo], [FlightID], [UserID], [BookedSeats], [CreatedOn], [UpdatedOn], [Total], [AppliedCoupenCode], [IsCoupenApplied], [IsCancelled], [Meal]) VALUES (6, N'a32aea4b-7ae9-4358-939f-d4024629ea18', 1, 7, 2, CAST(N'2022-05-16T10:24:26.103' AS DateTime), CAST(N'2022-05-16T10:24:26.103' AS DateTime), CAST(10000.00000 AS Decimal(18, 5)), 0, 1, 1, N'Non-Veg')
GO
INSERT [dbo].[Bookings] ([ID], [PNRNo], [FlightID], [UserID], [BookedSeats], [CreatedOn], [UpdatedOn], [Total], [AppliedCoupenCode], [IsCoupenApplied], [IsCancelled], [Meal]) VALUES (7, N'e0f9619f-9100-4a33-90bf-fbdffa92a27f', 3, 8, 1, CAST(N'2022-05-16T10:26:24.610' AS DateTime), CAST(N'2022-05-16T10:26:24.610' AS DateTime), CAST(3000.00000 AS Decimal(18, 5)), 0, 1, 1, N'Veg')
GO
INSERT [dbo].[Bookings] ([ID], [PNRNo], [FlightID], [UserID], [BookedSeats], [CreatedOn], [UpdatedOn], [Total], [AppliedCoupenCode], [IsCoupenApplied], [IsCancelled], [Meal]) VALUES (8, N'747a7fdd-339b-45a7-badb-0a0564ddf39b', 7, 6, 3, CAST(N'2022-05-20T09:59:53.313' AS DateTime), CAST(N'2022-05-20T09:59:53.317' AS DateTime), CAST(1500.00000 AS Decimal(18, 5)), 0, 1, 1, N'Veg')
GO
INSERT [dbo].[Bookings] ([ID], [PNRNo], [FlightID], [UserID], [BookedSeats], [CreatedOn], [UpdatedOn], [Total], [AppliedCoupenCode], [IsCoupenApplied], [IsCancelled], [Meal]) VALUES (9, N'e3d20831-4ac5-4e5a-85cf-094f1190c006', 1, 6, 2, CAST(N'2022-05-20T11:20:56.950' AS DateTime), CAST(N'2022-05-20T11:20:56.950' AS DateTime), CAST(10000.00000 AS Decimal(18, 5)), 0, 1, 1, N'Veg')
GO
SET IDENTITY_INSERT [dbo].[Bookings] OFF
GO
SET IDENTITY_INSERT [dbo].[Inventory] ON 
GO
INSERT [dbo].[Inventory] ([ID], [StartPoint], [EndPoint], [Price], [IsAvailable], [IsDiscountAvailable], [AirlineName], [ContactName], [ContactNumber], [SeatAvaibility], [CreatedDate], [UpdatedDate], [ScheduledDate]) VALUES (1, N'Ahmedabad', N'Mumbai', CAST(5000.00000 AS Decimal(18, 5)), 1, 1, N'AirAsia India', N'Admin', N'1234567', 0, CAST(N'2022-05-15T18:16:42.520' AS DateTime), CAST(N'2022-05-15T18:16:42.520' AS DateTime), CAST(N'2022-05-18T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Inventory] ([ID], [StartPoint], [EndPoint], [Price], [IsAvailable], [IsDiscountAvailable], [AirlineName], [ContactName], [ContactNumber], [SeatAvaibility], [CreatedDate], [UpdatedDate], [ScheduledDate]) VALUES (3, N'Mumbai', N'Pune', CAST(3000.00000 AS Decimal(18, 5)), 1, 1, N'AirAsia India', N'Admin', N'1234567', 100, CAST(N'2022-05-15T18:16:42.520' AS DateTime), CAST(N'2022-05-15T18:16:42.520' AS DateTime), CAST(N'2022-05-18T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Inventory] ([ID], [StartPoint], [EndPoint], [Price], [IsAvailable], [IsDiscountAvailable], [AirlineName], [ContactName], [ContactNumber], [SeatAvaibility], [CreatedDate], [UpdatedDate], [ScheduledDate]) VALUES (4, N'Banglore', N'Ahmedabad', CAST(5000.00000 AS Decimal(18, 5)), 1, 1, N'AirAsia India', N'Admin', N'122345', 100, CAST(N'2022-05-15T18:16:42.520' AS DateTime), CAST(N'2022-05-15T18:16:42.520' AS DateTime), CAST(N'2022-05-18T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Inventory] ([ID], [StartPoint], [EndPoint], [Price], [IsAvailable], [IsDiscountAvailable], [AirlineName], [ContactName], [ContactNumber], [SeatAvaibility], [CreatedDate], [UpdatedDate], [ScheduledDate]) VALUES (5, N'ahmedabad', N'Delhi', CAST(400.00000 AS Decimal(18, 5)), 1, 1, N'AirAsia India', N'Admin', N'1234232', 0, CAST(N'2022-05-16T12:07:46.837' AS DateTime), CAST(N'2022-05-16T12:07:44.847' AS DateTime), CAST(N'2022-05-18T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Inventory] ([ID], [StartPoint], [EndPoint], [Price], [IsAvailable], [IsDiscountAvailable], [AirlineName], [ContactName], [ContactNumber], [SeatAvaibility], [CreatedDate], [UpdatedDate], [ScheduledDate]) VALUES (6, N'Kerala', N'Ahmedabad', CAST(4000.00000 AS Decimal(18, 5)), 1, 1, N'AirAsia India', N'Admin', N'1234', 0, CAST(N'2022-05-17T08:55:08.397' AS DateTime), CAST(N'2022-05-17T08:55:06.820' AS DateTime), CAST(N'2022-05-18T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Inventory] ([ID], [StartPoint], [EndPoint], [Price], [IsAvailable], [IsDiscountAvailable], [AirlineName], [ContactName], [ContactNumber], [SeatAvaibility], [CreatedDate], [UpdatedDate], [ScheduledDate]) VALUES (7, N'Kolkata', N'Tirumalai', CAST(500.00000 AS Decimal(18, 5)), 1, 1, N'Jet Airways', N'Admin', N'123456', 20, CAST(N'2022-05-20T09:59:03.790' AS DateTime), CAST(N'2022-05-20T09:59:03.790' AS DateTime), CAST(N'2022-05-20T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Inventory] OFF
GO
SET IDENTITY_INSERT [dbo].[RoleMastertbl] ON 
GO
INSERT [dbo].[RoleMastertbl] ([RoleID], [RoleName]) VALUES (1, N'Admin')
GO
INSERT [dbo].[RoleMastertbl] ([RoleID], [RoleName]) VALUES (2, N'User')
GO
SET IDENTITY_INSERT [dbo].[RoleMastertbl] OFF
GO
SET IDENTITY_INSERT [dbo].[ServiceCity] ON 
GO
INSERT [dbo].[ServiceCity] ([Id], [CityName]) VALUES (1, N'Ahmedabad')
GO
INSERT [dbo].[ServiceCity] ([Id], [CityName]) VALUES (2, N'Mumbai')
GO
INSERT [dbo].[ServiceCity] ([Id], [CityName]) VALUES (3, N'Delhi')
GO
INSERT [dbo].[ServiceCity] ([Id], [CityName]) VALUES (4, N'Pune')
GO
INSERT [dbo].[ServiceCity] ([Id], [CityName]) VALUES (5, N'Banglore')
GO
INSERT [dbo].[ServiceCity] ([Id], [CityName]) VALUES (6, N'Kolkata')
GO
INSERT [dbo].[ServiceCity] ([Id], [CityName]) VALUES (7, N'Kerala')
GO
INSERT [dbo].[ServiceCity] ([Id], [CityName]) VALUES (8, N'Kochi')
GO
INSERT [dbo].[ServiceCity] ([Id], [CityName]) VALUES (9, N'Jammu')
GO
INSERT [dbo].[ServiceCity] ([Id], [CityName]) VALUES (10, N'Pondicherry')
GO
INSERT [dbo].[ServiceCity] ([Id], [CityName]) VALUES (11, N'Udaipur')
GO
INSERT [dbo].[ServiceCity] ([Id], [CityName]) VALUES (12, N'Jaipur')
GO
INSERT [dbo].[ServiceCity] ([Id], [CityName]) VALUES (13, N'Chennai')
GO
INSERT [dbo].[ServiceCity] ([Id], [CityName]) VALUES (14, N'Tamilnadu')
GO
INSERT [dbo].[ServiceCity] ([Id], [CityName]) VALUES (15, N'Rameshvaram')
GO
INSERT [dbo].[ServiceCity] ([Id], [CityName]) VALUES (16, N'Tirumalai')
GO
INSERT [dbo].[ServiceCity] ([Id], [CityName]) VALUES (17, N'Vadodara')
GO
INSERT [dbo].[ServiceCity] ([Id], [CityName]) VALUES (18, N'Nasik')
GO
INSERT [dbo].[ServiceCity] ([Id], [CityName]) VALUES (19, N'Leh')
GO
INSERT [dbo].[ServiceCity] ([Id], [CityName]) VALUES (20, N'Gandhinagar')
GO
SET IDENTITY_INSERT [dbo].[ServiceCity] OFF
GO
SET IDENTITY_INSERT [dbo].[UserMaster] ON 
GO
INSERT [dbo].[UserMaster] ([UserID], [RoleID], [UserName], [Email], [Password], [CreatedOn], [UpdatedOn], [Gender], [Age], [Token]) VALUES (1, 1, NULL, N'admin@gmail.com', N'123', N'May  3 2022  8:01PM', N'May  3 2022  8:01PM', NULL, NULL, NULL)
GO
INSERT [dbo].[UserMaster] ([UserID], [RoleID], [UserName], [Email], [Password], [CreatedOn], [UpdatedOn], [Gender], [Age], [Token]) VALUES (2, 2, NULL, N'User@gmail.com', N'123', N'May  3 2022  8:01PM', N'May  3 2022  8:01PM', NULL, NULL, NULL)
GO
INSERT [dbo].[UserMaster] ([UserID], [RoleID], [UserName], [Email], [Password], [CreatedOn], [UpdatedOn], [Gender], [Age], [Token]) VALUES (3, 2, N'Mital', N'Mital@gmail.com', N'123', N'04-05-2022 11:15:02', N'04-05-2022 11:15:02', NULL, NULL, NULL)
GO
INSERT [dbo].[UserMaster] ([UserID], [RoleID], [UserName], [Email], [Password], [CreatedOn], [UpdatedOn], [Gender], [Age], [Token]) VALUES (4, 2, N'Mital', N'parmarmital@gmail.com', N'12345', N'13-05-2022 20:05:12', N'13-05-2022 20:05:12', N'Female', 22, NULL)
GO
INSERT [dbo].[UserMaster] ([UserID], [RoleID], [UserName], [Email], [Password], [CreatedOn], [UpdatedOn], [Gender], [Age], [Token]) VALUES (5, 2, NULL, N'DHbjadh@gfdgdjfghfdj', N'212313', N'13-05-2022 20:56:04', N'13-05-2022 20:56:04', N'Female', 20, NULL)
GO
INSERT [dbo].[UserMaster] ([UserID], [RoleID], [UserName], [Email], [Password], [CreatedOn], [UpdatedOn], [Gender], [Age], [Token]) VALUES (6, 2, NULL, N'mital1@gmail.com', N'1234', N'16-05-2022 09:08:50', N'16-05-2022 09:08:50', N'Male', 20, NULL)
GO
INSERT [dbo].[UserMaster] ([UserID], [RoleID], [UserName], [Email], [Password], [CreatedOn], [UpdatedOn], [Gender], [Age], [Token]) VALUES (7, 2, NULL, N'test@gmail.com', N'123', N'16-05-2022 10:23:18', N'16-05-2022 10:23:18', N'Male', 25, NULL)
GO
INSERT [dbo].[UserMaster] ([UserID], [RoleID], [UserName], [Email], [Password], [CreatedOn], [UpdatedOn], [Gender], [Age], [Token]) VALUES (8, 2, NULL, N'vikash@gmail.com', N'123', N'16-05-2022 10:26:03', N'16-05-2022 10:26:03', N'Male', 25, NULL)
GO
INSERT [dbo].[UserMaster] ([UserID], [RoleID], [UserName], [Email], [Password], [CreatedOn], [UpdatedOn], [Gender], [Age], [Token]) VALUES (9, 2, NULL, N'test@gmail.com', N'1234', N'20-05-2022 10:37:12', N'20-05-2022 10:37:12', N'Female', -1, NULL)
GO
SET IDENTITY_INSERT [dbo].[UserMaster] OFF
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Inventory] FOREIGN KEY([FlightID])
REFERENCES [dbo].[Inventory] ([ID])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Inventory]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_UserMaster] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserMaster] ([UserID])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_UserMaster]
GO
ALTER TABLE [dbo].[UserMaster]  WITH CHECK ADD  CONSTRAINT [FK_UserMaster_RoleMastertbl] FOREIGN KEY([RoleID])
REFERENCES [dbo].[RoleMastertbl] ([RoleID])
GO
ALTER TABLE [dbo].[UserMaster] CHECK CONSTRAINT [FK_UserMaster_RoleMastertbl]
GO
