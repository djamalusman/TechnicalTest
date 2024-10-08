USE [DB_bpkb]
GO
/****** Object:  Table [dbo].[ms_storage_location]    Script Date: 25/08/2024 19.15.44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ms_storage_location](
	[location_id] [int] IDENTITY(1,1) NOT NULL,
	[location_name] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[location_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ms_user]    Script Date: 25/08/2024 19.15.44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ms_user](
	[user_id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](20) NULL,
	[password] [varchar](50) NULL,
	[is_active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TabelCabang]    Script Date: 25/08/2024 19.15.44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TabelCabang](
	[KodeCabang] [int] IDENTITY(1,1) NOT NULL,
	[NamaCabang] [varchar](100) NULL,
 CONSTRAINT [PK_TabelCabang] PRIMARY KEY CLUSTERED 
(
	[KodeCabang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TabelMotor]    Script Date: 25/08/2024 19.15.44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TabelMotor](
	[KodeMotor] [char](3) NOT NULL,
	[NamaMotor] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[KodeMotor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TabelPembayaran]    Script Date: 25/08/2024 19.15.44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TabelPembayaran](
	[NoKontrak] [char](10) NOT NULL,
	[TglBayar] [date] NULL,
	[JumlahBayar] [int] NULL,
	[KodeCabang] [int] NULL,
	[NoKwitansi] [char](12) NULL,
	[KodeMotor] [char](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[NoKontrak] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tr_bpkb]    Script Date: 25/08/2024 19.15.44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tr_bpkb](
	[agreement_number] [varchar](100) NULL,
	[bpkb_no] [varchar](100) NULL,
	[branch_id] [varchar](10) NULL,
	[bpkb_date] [datetime] NULL,
	[faktur_no] [varchar](100) NULL,
	[faktur_date] [datetime] NULL,
	[location_id] [int] NULL,
	[police_no] [varchar](20) NULL,
	[bpkb_date_in] [datetime] NULL,
	[created_by] [varchar](20) NULL,
	[created_on] [datetime] NULL,
	[last_updated_by] [varchar](20) NULL,
	[last_updated_on] [datetime] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ms_storage_location] ON 

INSERT [dbo].[ms_storage_location] ([location_id], [location_name]) VALUES (1, N'Jakarta Selatan')
INSERT [dbo].[ms_storage_location] ([location_id], [location_name]) VALUES (2, N'Jakarta Utara')
INSERT [dbo].[ms_storage_location] ([location_id], [location_name]) VALUES (3, N'Jakarta Barat')
INSERT [dbo].[ms_storage_location] ([location_id], [location_name]) VALUES (4, N'Jakarta Pusat')
SET IDENTITY_INSERT [dbo].[ms_storage_location] OFF
GO
SET IDENTITY_INSERT [dbo].[ms_user] ON 

INSERT [dbo].[ms_user] ([user_id], [user_name], [password], [is_active]) VALUES (1, N'djamal', N'321', 1)
SET IDENTITY_INSERT [dbo].[ms_user] OFF
GO
SET IDENTITY_INSERT [dbo].[TabelCabang] ON 

INSERT [dbo].[TabelCabang] ([KodeCabang], [NamaCabang]) VALUES (1, N'Jakarta')
INSERT [dbo].[TabelCabang] ([KodeCabang], [NamaCabang]) VALUES (2, N'Ciputat')
INSERT [dbo].[TabelCabang] ([KodeCabang], [NamaCabang]) VALUES (3, N'Pandeglang')
INSERT [dbo].[TabelCabang] ([KodeCabang], [NamaCabang]) VALUES (4, N'Bekasi')
SET IDENTITY_INSERT [dbo].[TabelCabang] OFF
GO
INSERT [dbo].[TabelMotor] ([KodeMotor], [NamaMotor]) VALUES (N'001', N'Suzuki')
INSERT [dbo].[TabelMotor] ([KodeMotor], [NamaMotor]) VALUES (N'002', N'Honda')
INSERT [dbo].[TabelMotor] ([KodeMotor], [NamaMotor]) VALUES (N'003', N'Yamaha')
INSERT [dbo].[TabelMotor] ([KodeMotor], [NamaMotor]) VALUES (N'004', N'Kawasaki')
GO
INSERT [dbo].[TabelPembayaran] ([NoKontrak], [TglBayar], [JumlahBayar], [KodeCabang], [NoKwitansi], [KodeMotor]) VALUES (N'1151500001', CAST(N'2014-10-20' AS Date), 200000, 1, N'14102000001 ', N'001')
INSERT [dbo].[TabelPembayaran] ([NoKontrak], [TglBayar], [JumlahBayar], [KodeCabang], [NoKwitansi], [KodeMotor]) VALUES (N'1151500003', CAST(N'2014-10-20' AS Date), 350000, 1, N'14102000003 ', N'003')
INSERT [dbo].[TabelPembayaran] ([NoKontrak], [TglBayar], [JumlahBayar], [KodeCabang], [NoKwitansi], [KodeMotor]) VALUES (N'1451500002', CAST(N'2014-10-20' AS Date), 300000, 3, N'14102000002 ', N'001')
INSERT [dbo].[TabelPembayaran] ([NoKontrak], [TglBayar], [JumlahBayar], [KodeCabang], [NoKwitansi], [KodeMotor]) VALUES (N'1751500004', CAST(N'2014-10-19' AS Date), 500000, 4, N'14101900001 ', N'002')
GO
INSERT [dbo].[tr_bpkb] ([agreement_number], [bpkb_no], [branch_id], [bpkb_date], [faktur_no], [faktur_date], [location_id], [police_no], [bpkb_date_in], [created_by], [created_on], [last_updated_by], [last_updated_on]) VALUES (N'Bcs001', N'AB67567', N'112233', CAST(N'2024-08-25T00:00:00.000' AS DateTime), N'34de', CAST(N'2024-08-15T00:00:00.000' AS DateTime), 4, N'56565613', CAST(N'2024-08-26T00:00:00.000' AS DateTime), N'djamal', CAST(N'2024-08-25T14:34:26.080' AS DateTime), N'djamal', CAST(N'2024-08-25T17:17:16.070' AS DateTime))
INSERT [dbo].[tr_bpkb] ([agreement_number], [bpkb_no], [branch_id], [bpkb_date], [faktur_no], [faktur_date], [location_id], [police_no], [bpkb_date_in], [created_by], [created_on], [last_updated_by], [last_updated_on]) VALUES (N'Bcs002', N'1', N'321', CAST(N'2024-08-12T00:00:00.000' AS DateTime), N'AADD23', CAST(N'2024-07-29T00:00:00.000' AS DateTime), 1, N'as21', CAST(N'2024-08-19T00:00:00.000' AS DateTime), N'djamal', CAST(N'2024-08-25T16:59:41.883' AS DateTime), N'djamal', CAST(N'2024-08-25T17:39:31.423' AS DateTime))
GO
ALTER TABLE [dbo].[TabelPembayaran]  WITH CHECK ADD FOREIGN KEY([KodeMotor])
REFERENCES [dbo].[TabelMotor] ([KodeMotor])
GO
ALTER TABLE [dbo].[tr_bpkb]  WITH CHECK ADD FOREIGN KEY([location_id])
REFERENCES [dbo].[ms_storage_location] ([location_id])
GO
