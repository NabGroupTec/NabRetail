
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[AddPayLimitFrosh](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdFactor] [bigint] NOT NULL,
	[Pay] [bigint] NOT NULL,
	[Disc] [nvarchar](max) NULL,
 CONSTRAINT [PK_AddPayLimitFrosh] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[AddPayLimitKharid]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[AddPayLimitKharid](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdFactor] [bigint] NOT NULL,
	[Pay] [bigint] NOT NULL,
	[Disc] [nvarchar](max) NULL,
 CONSTRAINT [PK_AddPayLimitKharid] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Chk_Get_Pay]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Chk_Get_Pay](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GetDate] [nvarchar](max) NOT NULL,
	[PayDate] [nvarchar](max) NOT NULL,
	[MoneyChk] [bigint] NOT NULL,
	[NumChk] [bigint] NOT NULL,
	[Kind] [int] NOT NULL,
	[Current_Kind] [int] NOT NULL,
	[Shobeh] [nvarchar](max) NULL,
	[N_Bank] [nvarchar](max) NULL,
	[Number_N] [nvarchar](max) NULL,
	[Disc] [nvarchar](max) NULL,
	[State] [int] NOT NULL,
	[Current_State] [int] NOT NULL,
	[Activ] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[Number_Type] [bigint] NOT NULL,
	[Current_Type] [int] NOT NULL,
	[Current_Number_Type] [bigint] NOT NULL,
	[Number_Note] [nvarchar](max) NULL,
	[Type_Chk] [bigint] NOT NULL,
	[Current_Type_Chk] [bigint] NOT NULL,
	[IdUser] [bigint] NULL,
 CONSTRAINT [PK_Get_Pay_Chk] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Chk_Id]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Chk_Id](
	[Id] [bigint] NOT NULL,
	[IdPeople] [bigint] NULL,
	[Current_IdPeople] [bigint] NULL,
	[IdBank] [bigint] NULL,
	[D_date] [nvarchar](max) NULL,
	[IdAmval] [bigint] NULL,
	[IdDaramad] [bigint] NULL,
	[Idsarmayeh] [bigint] NULL,
 CONSTRAINT [PK_Chk_IdPeople] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Chk_State]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Chk_State](
	[AutoId] [bigint] IDENTITY(1,1) NOT NULL,
	[Id] [bigint] NOT NULL,
	[D_Date] [nvarchar](max) NULL,
	[Current_State] [int] NOT NULL,
	[Disc] [nvarchar](max) NULL,
	[TmpId] [bigint] NULL,
	[IdUser] [bigint] NULL,
 CONSTRAINT [PK_State_Chk] PRIMARY KEY CLUSTERED 
(
	[AutoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[DB_Info]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[DB_Info](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Version] [varbinary](max) NOT NULL,
	[AllowAdd] [varbinary](max) NOT NULL,
	[OldPeriod] [varbinary](max) NULL,
	[NumberOfUser] [varbinary](max) NULL,
 CONSTRAINT [PK_DB_Info] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_ActivePeople]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_ActivePeople](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Dat] [nvarchar](max) NOT NULL,
	[IdName] [bigint] NOT NULL,
	[StateActive] [bit] NOT NULL,
	[IdUser] [bigint] NOT NULL,
	[IdUserEdit] [bigint] NULL,
	[Disc] [nvarchar](max) NOT NULL,
	[IdVisitor] [bigint] NULL,
 CONSTRAINT [PK_Define_ActivePeople] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_Amval]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_Amval](
	[nam] [nvarchar](max) NULL,
	[discription] [nvarchar](max) NULL,
	[AllMoney] [bigint] NOT NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IdOne] [bigint] NOT NULL,
	[IdCodeTwo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Define_Amval] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_Anbar]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_Anbar](
	[nam] [nvarchar](max) NOT NULL,
	[discription] [nvarchar](max) NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SetDeActiv] [bit] NOT NULL,
 CONSTRAINT [PK_Define_Anbar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_Bank]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_Bank](
	[n_bank] [nvarchar](max) NOT NULL,
	[shobeh] [nvarchar](max) NOT NULL,
	[number_n] [nvarchar](max) NOT NULL,
	[tell] [nvarchar](max) NULL,
	[address] [nvarchar](max) NULL,
	[nam] [nvarchar](max) NOT NULL,
	[AllMoney] [bigint] NOT NULL,
	[State] [nvarchar](max) NOT NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Define_Bank] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_Box]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_Box](
	[nam] [nvarchar](max) NOT NULL,
	[discription] [nvarchar](max) NULL,
	[AllMoney] [bigint] NOT NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Define_Box] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_Car]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_Car](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nam] [nvarchar](max) NOT NULL,
	[Plak] [nvarchar](max) NULL,
	[Disc] [nvarchar](max) NULL,
	[Weight] [bit] NOT NULL,
	[WeightK] [float] NOT NULL,
	[Size] [bit] NOT NULL,
	[WidthK] [float] NOT NULL,
	[HightK] [float] NOT NULL,
	[TopK] [float] NOT NULL,
 CONSTRAINT [PK_Define_Car] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_Charge]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_Charge](
	[nam] [nvarchar](max) NOT NULL,
	[discription] [nvarchar](max) NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCodeTwo] [nvarchar](max) NULL,
	[IdOne] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_Charge] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_Chk]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_Chk](
	[ID] [bigint] NOT NULL,
	[Num1] [bigint] NOT NULL,
	[Num2] [bigint] NOT NULL,
	[State] [bigint] NOT NULL,
	[Aid] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Define_Chk] PRIMARY KEY CLUSTERED 
(
	[Aid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[Define_City]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_City](
	[Code] [bigint] IDENTITY(1,1) NOT NULL,
	[NamCI] [nvarchar](max) NOT NULL,
	[TellCI] [nvarchar](max) NULL,
	[IdOstan] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_Ostan] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_CityCostkala]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_CityCostkala](
	[IdCity] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_CityCostkala] PRIMARY KEY CLUSTERED 
(
	[IdCity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[Define_Company]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_Company](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](max) NULL,
	[IdCompany] [nvarchar](max) NULL,
	[TelFax] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Header] [nvarchar](max) NULL,
	[Footer] [nvarchar](max) NULL,
	[BackUpPath] [nvarchar](max) NULL,
	[CompanyImage] [varbinary](max) NULL,
	[IdUser] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_Company] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_CostKala]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_CostKala](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdKala] [bigint] NOT NULL,
	[IdCity] [bigint] NOT NULL,
	[CostSmalKala] [bigint] NOT NULL,
	[CostBigKala] [bigint] NOT NULL,
	[EndCost] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_CostKala] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[Define_Daramad]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_Daramad](
	[nam] [nvarchar](max) NOT NULL,
	[discription] [nvarchar](max) NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCodeTwo] [nvarchar](max) NULL,
	[IdOne] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_Daramad] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_Driver]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_Driver](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nam] [nvarchar](max) NOT NULL,
	[Tell] [nvarchar](max) NULL,
	[Disc] [nvarchar](max) NULL,
 CONSTRAINT [PK_Define_Driver] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_EditKala]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_EditKala](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Idkala] [bigint] NOT NULL,
	[OKol] [float] NOT NULL,
	[OJoz] [float] NOT NULL,
	[TKol] [float] NOT NULL,
	[TJoz] [float] NOT NULL,
	[IdAnbar] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_EditKala] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[Define_Group_P]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_Group_P](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[nam] [nvarchar](max) NOT NULL,
	[Cash1] [bigint] NOT NULL,
	[Cash2] [bigint] NOT NULL,
	[Cash3] [bigint] NOT NULL,
	[Cash4] [bigint] NOT NULL,
	[Cash5] [bigint] NOT NULL,
	[Cash6] [bigint] NOT NULL,
	[CashP1] [bigint] NOT NULL,
	[CashP2] [bigint] NOT NULL,
	[CashP3] [bigint] NOT NULL,
	[CashP4] [bigint] NOT NULL,
	[CashP5] [bigint] NOT NULL,
	[CashP6] [bigint] NOT NULL,
	[DCash1] [float] NOT NULL,
	[DCash2] [float] NOT NULL,
	[DCash3] [float] NOT NULL,
	[DP1] [float] NOT NULL,
	[DP2] [float] NOT NULL,
	[DP3] [float] NOT NULL,
	[Hajm] [bit] NOT NULL,
	[KalaCash] [bit] NOT NULL,
	[HKalaCash] [bit] NOT NULL,
	[KindCost] [int] NOT NULL,
	[GroupValue] [bit] NOT NULL,
	[GroupValueMon] [bigint] NOT NULL,
	[GroupPeople] [bit] NOT NULL,
	[Chk1] [bigint] NOT NULL,
	[Chk2] [bigint] NOT NULL,
	[Chk3] [bigint] NOT NULL,
	[Chk4] [bigint] NOT NULL,
	[Chk5] [bigint] NOT NULL,
	[Chk6] [bigint] NOT NULL,
	[DChk1] [float] NOT NULL,
	[DChk2] [float] NOT NULL,
	[DChk3] [float] NOT NULL,
	[DCard] [float] NOT NULL,
 CONSTRAINT [PK_Define_Group_P] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_Kala]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_Kala](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCodeOne] [bigint] NOT NULL,
	[IdCodeTwo] [bigint] NOT NULL,
	[IdVahed] [bigint] NOT NULL,
	[Nam] [nvarchar](max) NOT NULL,
	[Ex_Date] [nvarchar](max) NULL,
	[BarCode] [nvarchar](max) NULL,
	[DK] [bit] NOT NULL,
	[DK_KOL] [bigint] NOT NULL,
	[DK_JOZ] [float] NOT NULL,
	[WK] [bit] NOT NULL,
	[WK_KOL] [float] NOT NULL,
	[WK_JOZ] [float] NOT NULL,
	[LF] [bit] NOT NULL,
	[LF_Value] [float] NOT NULL,
	[HF] [bit] NOT NULL,
	[HF_Value] [float] NOT NULL,
	[Activ] [bit] NOT NULL,
	[Cashing] [bit] NOT NULL,
	[Size] [bit] NOT NULL,
	[WidthKala] [float] NOT NULL,
	[HightKala] [float] NOT NULL,
	[TopKala] [float] NOT NULL,
 CONSTRAINT [PK_Define_Kala] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_KalaRate]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_KalaRate](
	[IdKala] [bigint] NOT NULL,
	[BRate] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_KalaRate] PRIMARY KEY CLUSTERED 
(
	[IdKala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[Define_List_Group_P]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_List_Group_P](
	[AzMon] [bigint] NOT NULL,
	[TaMon] [bigint] NOT NULL,
	[Darsad] [float] NOT NULL,
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[LinkId] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_List_Group_P] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[Define_ListKalaRate]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_ListKalaRate](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdGroup] [bigint] NOT NULL,
	[Rate] [bigint] NOT NULL,
	[IdKalaLink] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_ListKalaRate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[Define_OneAmval]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_OneAmval](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NamOne] [nvarchar](max) NOT NULL,
	[IdCodeOne] [nvarchar](max) NULL,
 CONSTRAINT [PK_Define_OneAmval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_OneCharge]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_OneCharge](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NamOne] [nvarchar](max) NOT NULL,
	[IdCodeOne] [nvarchar](max) NULL,
 CONSTRAINT [PK_Define_OneCharge] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_OneDaramad]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_OneDaramad](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NamOne] [nvarchar](max) NOT NULL,
	[IdCodeOne] [nvarchar](max) NULL,
 CONSTRAINT [PK_Define_OneDaramad] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_OneGroup]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_OneGroup](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NamOne] [nvarchar](max) NOT NULL,
	[IdCodeOne] [nvarchar](max) NULL,
 CONSTRAINT [PK_Define_OneGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_OneSarFasl]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_OneSarFasl](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NamOne] [nvarchar](max) NOT NULL,
	[IdCodeOne] [nvarchar](max) NULL,
 CONSTRAINT [PK_Define_OneSarFasl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_OneSarmayeh]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_OneSarmayeh](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NamOne] [nvarchar](max) NOT NULL,
	[IdCodeOne] [nvarchar](max) NULL,
 CONSTRAINT [PK_Define_OneSarmayeh] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_Ostan]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_Ostan](
	[Code] [bigint] IDENTITY(1,1) NOT NULL,
	[NamO] [nvarchar](max) NOT NULL,
	[TellO] [nvarchar](max) NULL,
 CONSTRAINT [PK_Define_Country] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_OtherBank]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_OtherBank](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nam] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Define_OtherBank] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_Part]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_Part](
	[Code] [bigint] IDENTITY(1,1) NOT NULL,
	[NamP] [nvarchar](max) NOT NULL,
	[AddP] [nvarchar](max) NULL,
	[IdOstan] [bigint] NOT NULL,
	[IdCity] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_City] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_PartKala]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_PartKala](
	[nam] [nvarchar](max) NOT NULL,
	[discription] [nvarchar](max) NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Activ] [bit] NOT NULL,
 CONSTRAINT [PK_Define_Part] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_People]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_People](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Nam] [nvarchar](max) NOT NULL,
	[Tell1] [nvarchar](max) NULL,
	[Tell2] [nvarchar](max) NULL,
	[Fax] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Buyer] [bit] NOT NULL,
	[Seller] [bit] NOT NULL,
	[Other] [bit] NOT NULL,
	[GValue] [bit] NOT NULL,
	[GValueMon] [bigint] NOT NULL,
	[AllMoney] [bigint] NOT NULL,
	[State] [nvarchar](max) NOT NULL,
	[Rate] [int] NOT NULL,
	[NamCo] [nvarchar](max) NULL,
	[NamFac] [nvarchar](max) NULL,
	[IdOstan] [bigint] NOT NULL,
	[IdCity] [bigint] NOT NULL,
	[IdPart] [bigint] NOT NULL,
	[Activ] [bit] NOT NULL,
	[ChkIdGroup] [bit] NOT NULL,
	[IdGroup] [bigint] NULL,
	[D_Dat] [nvarchar](max) NOT NULL,
	[MCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_Define_People] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_PrimaryKala]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_PrimaryKala](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IdKala] [bigint] NOT NULL,
	[IdAnbar] [bigint] NOT NULL,
	[Count_Kol] [float] NOT NULL,
	[Count_Joz] [float] NOT NULL,
	[Fe] [bigint] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[D_date] [nvarchar](50) NULL,
	[Iduser] [bigint] NULL,
 CONSTRAINT [PK_Define_PrimaryKala] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[Define_Reciver]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_Reciver](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nam] [nvarchar](max) NOT NULL,
	[Tell] [nvarchar](max) NULL,
	[Disc] [nvarchar](max) NULL,
 CONSTRAINT [PK_Define_Reciver] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_SarFasl]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_SarFasl](
	[nam] [nvarchar](max) NOT NULL,
	[Ref] [nvarchar](max) NOT NULL,
	[discription] [nvarchar](max) NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCodeTwo] [nvarchar](max) NULL,
	[IdOne] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_SarFasl] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_Sarmayeh]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_Sarmayeh](
	[nam] [nvarchar](max) NOT NULL,
	[STAT] [nvarchar](max) NOT NULL,
	[discription] [nvarchar](max) NULL,
	[AllMoney] [bigint] NOT NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCodeTwo] [nvarchar](max) NULL,
	[IdOne] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_Sarmaeh] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_Service]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_Service](
	[nam] [nvarchar](max) NOT NULL,
	[discription] [nvarchar](max) NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Define_Service] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_TwoGroup]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_TwoGroup](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NamTwo] [nvarchar](max) NOT NULL,
	[IdCodeTwo] [nvarchar](max) NULL,
	[IdOne] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_TwoGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_User]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nam] [nvarchar](max) NOT NULL,
	[TypeImage] [int] NOT NULL,
	[Image] [varbinary](max) NULL,
	[Pas] [varbinary](max) NULL,
	[UserLogIn] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Define_Bazaryab] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_UserR]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_UserR](
	[IdUser] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_UserPTF] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[Define_UserRAnbar]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_UserRAnbar](
	[IdUser] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_UserRAnbar] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[Define_UserRBox]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_UserRBox](
	[IdUser] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_UserRBox] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[Define_UserRP]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_UserRP](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdUser] [bigint] NOT NULL,
	[IDP] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_P_UserPTF] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[Define_UserRPAnbar]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_UserRPAnbar](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdUser] [bigint] NOT NULL,
	[IDA] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_UserRPAnbar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[Define_UserRPBox]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_UserRPBox](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdUser] [bigint] NOT NULL,
	[IDB] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_UserRPBox] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[Define_Vahed]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_Vahed](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nam] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Define_Vahed] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_Visitor]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_Visitor](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nam] [nvarchar](max) NOT NULL,
	[Activ] [bit] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[Pas] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Define_Visitor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Define_VisitorR]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_VisitorR](
	[IdVisitor] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_VisitorPTF] PRIMARY KEY CLUSTERED 
(
	[IdVisitor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[Define_VisitorRP]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Define_VisitorRP](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdVisitor] [bigint] NOT NULL,
	[IDP] [bigint] NOT NULL,
 CONSTRAINT [PK_Define_P_VisitorPTF] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[DefineListPromotion]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[DefineListPromotion](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AzKala] [float] NOT NULL,
	[TaKala] [float] NOT NULL,
	[Fe] [bigint] NOT NULL,
	[Darsad] [float] NOT NULL,
	[IdLink] [bigint] NOT NULL,
 CONSTRAINT [PK_DefineListPromotion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[DefinePromotion]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[DefinePromotion](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdKala] [bigint] NOT NULL,
	[IdGroup] [bigint] NOT NULL,
	[Fe] [bigint] NOT NULL,
 CONSTRAINT [PK_DefinePromotion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ExitFactor]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ExitFactor](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[D_date] [nvarchar](max) NOT NULL,
	[Disc] [nvarchar](max) NULL,
	[IdUser] [bigint] NOT NULL,
	[IdRecive] [bigint] NULL,
	[IdDriver] [bigint] NULL,
	[IdCar] [bigint] NULL,
 CONSTRAINT [PK_ExitFactor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Get_Daramad]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Get_Daramad](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[D_date] [nvarchar](max) NULL,
	[Idname] [bigint] NULL,
	[IdUser] [bigint] NULL,
	[Active] [int] NOT NULL,
	[EditFlag] [int] NOT NULL,
	[Cash] [bigint] NOT NULL,
	[MonHavaleh] [bigint] NOT NULL,
	[IdBankHavaleh] [bigint] NULL,
	[DiscHavaleh] [nvarchar](max) NULL,
	[MonPayChk] [bigint] NOT NULL,
	[DiscChk] [nvarchar](max) NULL,
	[Lend] [bigint] NOT NULL,
	[IdSanadLend] [bigint] NULL,
	[DiscLend] [nvarchar](max) NULL,
	[IdBoxMoein] [bigint] NULL,
	[IdBox] [bigint] NULL,
	[IdBankMoein] [bigint] NULL,
	[AllDisc] [nvarchar](max) NULL,
	[DiscCash] [nvarchar](max) NULL,
	[IdDaramad] [bigint] NOT NULL,
 CONSTRAINT [PK_Get_Daramad] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Get_Pay_Amval]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Get_Pay_Amval](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[D_date] [nvarchar](max) NULL,
	[IdAmval] [bigint] NULL,
	[IdUser] [bigint] NULL,
	[Active] [int] NOT NULL,
	[State] [int] NOT NULL,
	[EditFlag] [int] NOT NULL,
	[Cash] [bigint] NOT NULL,
	[MonHavaleh] [bigint] NOT NULL,
	[IdBankHavaleh] [bigint] NULL,
	[DiscHavaleh] [nvarchar](max) NULL,
	[MonPayChk] [bigint] NOT NULL,
	[MonSellChk] [bigint] NOT NULL,
	[LendP] [bigint] NULL,
	[IdSanadLendP] [bigint] NULL,
	[LendCharge] [bigint] NULL,
	[DiscChk] [nvarchar](max) NULL,
	[DiscSellChk] [nvarchar](max) NULL,
	[IdBoxMoein] [bigint] NULL,
	[IdBox] [bigint] NULL,
	[IdBankMoein] [bigint] NULL,
	[AllDisc] [nvarchar](max) NULL,
	[DiscCash] [nvarchar](max) NULL,
	[DiscLend] [nvarchar](max) NULL,
	[Lend] [bigint] NOT NULL,
 CONSTRAINT [PK_Get_Pay_Amval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Get_Pay_Sanad]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Get_Pay_Sanad](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[D_date] [nvarchar](max) NULL,
	[Idname] [bigint] NULL,
	[IdUser] [bigint] NULL,
	[Active] [int] NOT NULL,
	[State] [int] NOT NULL,
	[EditFlag] [int] NOT NULL,
	[Discount] [bigint] NOT NULL,
	[IdSanadDiscount] [bigint] NULL,
	[Cash] [bigint] NOT NULL,
	[IdSanadCash] [bigint] NULL,
	[MonHavaleh] [bigint] NOT NULL,
	[IdBankHavaleh] [bigint] NULL,
	[DiscHavaleh] [nvarchar](max) NULL,
	[MonPayChk] [bigint] NOT NULL,
	[MonSellChk] [bigint] NOT NULL,
	[IdSanadChk] [bigint] NULL,
	[IdSanadHavaleh] [bigint] NULL,
	[DiscDiscount] [nvarchar](max) NULL,
	[DiscChk] [nvarchar](max) NULL,
	[DiscSellChk] [nvarchar](max) NULL,
	[IdBoxMoein] [bigint] NULL,
	[IdBox] [bigint] NULL,
	[IdBankMoein] [bigint] NULL,
	[AllDisc] [nvarchar](max) NULL,
	[Sanad] [nvarchar](max) NULL,
	[DiscCash] [nvarchar](max) NULL,
 CONSTRAINT [PK_Get_Pay_Sanad] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Get_Pay_Sarmayeh]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Get_Pay_Sarmayeh](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[D_date] [nvarchar](max) NULL,
	[IdSarmayeh] [bigint] NULL,
	[IdUser] [bigint] NULL,
	[Active] [int] NOT NULL,
	[State] [int] NOT NULL,
	[EditFlag] [int] NOT NULL,
	[Cash] [bigint] NOT NULL,
	[MonHavaleh] [bigint] NOT NULL,
	[IdBankHavaleh] [bigint] NULL,
	[DiscHavaleh] [nvarchar](max) NULL,
	[MonPayChk] [bigint] NOT NULL,
	[MonSellChk] [bigint] NOT NULL,
	[LendP] [bigint] NULL,
	[IdSanadLendP] [bigint] NULL,
	[LendCharge] [bigint] NULL,
	[DiscChk] [nvarchar](max) NULL,
	[DiscSellChk] [nvarchar](max) NULL,
	[IdBoxMoein] [bigint] NULL,
	[IdBox] [bigint] NULL,
	[IdBankMoein] [bigint] NULL,
	[AllDisc] [nvarchar](max) NULL,
	[DiscCash] [nvarchar](max) NULL,
	[DiscLend] [nvarchar](max) NULL,
	[Lend] [bigint] NOT NULL,
 CONSTRAINT [PK_Get_Pay_Sarmayeh] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[GetMonQst]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[GetMonQst](
	[AutoId] [bigint] IDENTITY(1,1) NOT NULL,
	[Id] [bigint] NOT NULL,
	[Pay] [bigint] NOT NULL,
	[IdSanad] [bigint] NOT NULL,
 CONSTRAINT [PK_GetMonQst] PRIMARY KEY CLUSTERED 
(
	[AutoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[GetQst]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[GetQst](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdName] [bigint] NOT NULL,
	[Formul] [bigint] NOT NULL,
	[d_date] [nvarchar](max) NOT NULL,
	[Mon] [bigint] NOT NULL,
	[Cnt] [bigint] NOT NULL,
	[Spac] [bigint] NOT NULL,
	[Rat] [bigint] NOT NULL,
	[CusMon] [bigint] NOT NULL,
	[QstMon] [bigint] NOT NULL,
	[RateMon] [bigint] NOT NULL,
	[AllMon] [bigint] NOT NULL,
	[Disc] [nvarchar](max) NULL,
 CONSTRAINT [PK_GetQst] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[GetQstList]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[GetQstList](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[d_date] [nvarchar](max) NOT NULL,
	[Mon] [bigint] NOT NULL,
	[Link] [bigint] NOT NULL,
 CONSTRAINT [PK_GetQstList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Kala_Discount]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Kala_Discount](
	[KolCount] [float] NOT NULL,
	[JozCount] [float] NOT NULL,
	[Idkala] [bigint] NULL,
	[IdService] [bigint] NULL,
	[Kol] [float] NOT NULL,
	[Joz] [float] NOT NULL,
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdKalaLink] [bigint] NOT NULL,
 CONSTRAINT [PK_Kala_Discount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[KalaFactorBackBuy]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[KalaFactorBackBuy](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IdFactor] [bigint] NOT NULL,
	[IdKala] [bigint] NULL,
	[IdService] [bigint] NULL,
	[KolCount] [float] NOT NULL,
	[JozCount] [float] NOT NULL,
	[Fe] [bigint] NOT NULL,
	[DarsadDiscount] [float] NOT NULL,
	[DarsadMon] [bigint] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[IdAnbar] [bigint] NULL,
	[KalaDisc] [nvarchar](max) NULL,
	[Activ] [int] NOT NULL,
 CONSTRAINT [PK_Kala_FactorBackBuy] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[KalaFactorBackSell]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[KalaFactorBackSell](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IdFactor] [bigint] NOT NULL,
	[IdKala] [bigint] NULL,
	[IdService] [bigint] NULL,
	[KolCount] [float] NOT NULL,
	[JozCount] [float] NOT NULL,
	[Fe] [bigint] NOT NULL,
	[DarsadDiscount] [float] NOT NULL,
	[DarsadMon] [bigint] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[IdAnbar] [bigint] NULL,
	[KalaDisc] [nvarchar](max) NULL,
	[Activ] [int] NOT NULL,
 CONSTRAINT [PK_KalaFactorBackSell] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[KalaFactorBuy]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[KalaFactorBuy](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IdFactor] [bigint] NOT NULL,
	[IdKala] [bigint] NULL,
	[IdService] [bigint] NULL,
	[KolCount] [float] NOT NULL,
	[JozCount] [float] NOT NULL,
	[Fe] [bigint] NOT NULL,
	[DarsadDiscount] [float] NOT NULL,
	[DarsadMon] [bigint] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[IdAnbar] [bigint] NULL,
	[KalaDisc] [nvarchar](max) NULL,
	[Activ] [int] NOT NULL,
 CONSTRAINT [PK_Kala_Factor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[KalaFactorCharge]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[KalaFactorCharge](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IdSanad] [bigint] NOT NULL,
	[IdCharge] [bigint] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[CDisc] [nvarchar](max) NULL,
 CONSTRAINT [PK_KalaFactorCharge] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[KalaFactorDamage]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[KalaFactorDamage](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IdFactor] [bigint] NOT NULL,
	[IdKala] [bigint] NULL,
	[KolCount] [float] NOT NULL,
	[JozCount] [float] NOT NULL,
	[Fe] [bigint] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[IdAnbar] [bigint] NULL,
	[KalaDisc] [nvarchar](max) NULL,
	[Activ] [int] NOT NULL,
 CONSTRAINT [PK_KalaFactorDamage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[KalaFactorSell]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[KalaFactorSell](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IdFactor] [bigint] NOT NULL,
	[IdKala] [bigint] NULL,
	[IdService] [bigint] NULL,
	[KolCount] [float] NOT NULL,
	[JozCount] [float] NOT NULL,
	[Fe] [bigint] NOT NULL,
	[DarsadDiscount] [float] NOT NULL,
	[DarsadMon] [bigint] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[IdAnbar] [bigint] NULL,
	[KalaDisc] [nvarchar](max) NULL,
	[Activ] [int] NOT NULL,
 CONSTRAINT [PK_Kala_FactorSell] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[KalaFactorService]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[KalaFactorService](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IdFactor] [bigint] NOT NULL,
	[IdService] [bigint] NOT NULL,
	[KolCount] [float] NOT NULL,
	[Fe] [bigint] NOT NULL,
	[DarsadDiscount] [float] NOT NULL,
	[DarsadMon] [bigint] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[KalaDisc] [nvarchar](max) NULL,
	[Activ] [int] NOT NULL,
 CONSTRAINT [PK_Kala_FactorService] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[KalaKasriFactor]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[KalaKasriFactor](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdR] [bigint] NOT NULL,
	[IdFactor] [bigint] NOT NULL,
	[KolCount] [float] NOT NULL,
	[JozCount] [float] NOT NULL,
	[KalaDisc] [nvarchar](max) NULL,
	[Fe] [bigint] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[DarsadMon] [bigint] NOT NULL,
	[DarsadDiscount] [float] NOT NULL,
	[EndKol] [float] NOT NULL,
	[EndJoz] [float] NOT NULL,
 CONSTRAINT [PK_KalaKasriFactor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[KalaOtherCharge]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[KalaOtherCharge](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IdSanad] [bigint] NOT NULL,
	[IdCharge] [bigint] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[CDisc] [nvarchar](max) NULL,
 CONSTRAINT [PK_KalaOtherCharge] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Lasheh_Chk]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Lasheh_Chk](
	[AutoId] [bigint] IDENTITY(1,1) NOT NULL,
	[Id] [bigint] NOT NULL,
	[NumChk] [bigint] NOT NULL,
 CONSTRAINT [PK_Lasheh_Chk] PRIMARY KEY CLUSTERED 
(
	[AutoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListDarsad]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListDarsad](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Frosh] [float] NOT NULL,
	[Darsad] [float] NOT NULL,
	[IdlinkKala] [bigint] NOT NULL,
	[IdGroup] [bigint] NOT NULL,
 CONSTRAINT [PK_ListDarsad] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListDarsad_G]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListDarsad_G](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Frosh] [float] NOT NULL,
	[Darsad] [float] NOT NULL,
	[IdlinkKala] [bigint] NOT NULL,
	[IdGroup] [bigint] NOT NULL,
 CONSTRAINT [PK_ListDarsad_G] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListDarsad_OG]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListDarsad_OG](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Frosh] [float] NOT NULL,
	[Darsad] [float] NOT NULL,
	[IdlinkKala] [bigint] NOT NULL,
	[IdGroup] [bigint] NOT NULL,
 CONSTRAINT [PK_ListDarsad_OG] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListDarsadU]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListDarsadU](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Frosh] [float] NOT NULL,
	[Darsad] [float] NOT NULL,
	[IdlinkKala] [bigint] NOT NULL,
	[IdGroup] [bigint] NOT NULL,
 CONSTRAINT [PK_ListDarsadU] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListDarsadU_G]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListDarsadU_G](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Frosh] [float] NOT NULL,
	[Darsad] [float] NOT NULL,
	[IdlinkKala] [bigint] NOT NULL,
	[IdGroup] [bigint] NOT NULL,
 CONSTRAINT [PK_ListDarsadU_G] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListDarsadU_OG]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListDarsadU_OG](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Frosh] [float] NOT NULL,
	[Darsad] [float] NOT NULL,
	[IdlinkKala] [bigint] NOT NULL,
	[IdGroup] [bigint] NOT NULL,
 CONSTRAINT [PK_ListDarsadU_OG] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListEditMoein]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListEditMoein](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[D_Date] [nvarchar](max) NOT NULL,
	[IdCharge] [bigint] NULL,
	[IdDaramad] [bigint] NULL,
	[Disc] [nvarchar](max) NULL,
	[Mon] [bigint] NOT NULL,
	[IdSCharge] [bigint] NULL,
	[IdSDaramad] [bigint] NULL,
	[IdUser] [bigint] NOT NULL,
	[EditFlag] [int] NOT NULL,
 CONSTRAINT [PK_ListEditMoein] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[ListEditPMoein]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListEditPMoein](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdP] [bigint] NOT NULL,
	[Emon] [bigint] NOT NULL,
	[IdMoein] [bigint] NOT NULL,
	[IdLink] [bigint] NOT NULL,
 CONSTRAINT [PK_ListEditPMoein] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListExitFactor]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListExitFactor](
	[IdList] [bigint] NOT NULL,
	[IdFactor] [bigint] NOT NULL,
	[Priority] [bigint] NULL,
 CONSTRAINT [PK_ListExitFactor] PRIMARY KEY CLUSTERED 
(
	[IdFactor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListFactorBackBuy]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListFactorBackBuy](
	[IdFactor] [bigint] IDENTITY(1,1) NOT NULL,
	[D_date] [nvarchar](max) NOT NULL,
	[IdName] [bigint] NULL,
	[Part] [bigint] NULL,
	[Sanad] [nvarchar](max) NULL,
	[IdVisitor] [bigint] NULL,
	[IdUser] [bigint] NULL,
	[Disc] [nvarchar](max) NULL,
	[Activ] [int] NOT NULL,
	[MonAdd] [bigint] NOT NULL,
	[IdSanadAdd] [bigint] NULL,
	[MonDec] [bigint] NOT NULL,
	[IdSanadDec] [bigint] NULL,
	[IdSanadDiscountH] [bigint] NULL,
	[Discount] [bigint] NOT NULL,
	[IdSanadDiscountC] [bigint] NULL,
	[Cash] [bigint] NOT NULL,
	[IdSanadCash] [bigint] NULL,
	[MonHavaleh] [bigint] NOT NULL,
	[IdBankHavaleh] [bigint] NULL,
	[DiscHavaleh] [nvarchar](max) NULL,
	[MonPayChk] [bigint] NOT NULL,
	[IdSanadChk] [bigint] NULL,
	[EditFlag] [int] NOT NULL,
	[IdSanadHavaleh] [bigint] NULL,
	[DiscAdd] [nvarchar](max) NULL,
	[DiscDec] [nvarchar](max) NULL,
	[DiscDisH] [nvarchar](max) NULL,
	[DiscDisC] [nvarchar](max) NULL,
	[DiscCash] [nvarchar](max) NULL,
	[DiscChk] [nvarchar](max) NULL,
	[IdBox] [bigint] NULL,
	[IdBanK] [bigint] NULL,
	[IdSanadFactor] [bigint] NULL,
 CONSTRAINT [PK_ListFactorBackBuy] PRIMARY KEY CLUSTERED 
(
	[IdFactor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[ListFactorBackSell]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListFactorBackSell](
	[IdFactor] [bigint] IDENTITY(1,1) NOT NULL,
	[D_date] [nvarchar](max) NOT NULL,
	[IdName] [bigint] NULL,
	[Part] [bigint] NULL,
	[Sanad] [nvarchar](max) NULL,
	[IdVisitor] [bigint] NULL,
	[IdUser] [bigint] NULL,
	[Disc] [nvarchar](max) NULL,
	[Activ] [int] NOT NULL,
	[Stat] [int] NOT NULL,
	[MonAdd] [bigint] NOT NULL,
	[IdSanadAdd] [bigint] NULL,
	[MonDec] [bigint] NOT NULL,
	[IdSanadDec] [bigint] NULL,
	[IdSanadDiscountH] [bigint] NULL,
	[Discount] [bigint] NOT NULL,
	[IdSanadDiscountC] [bigint] NULL,
	[Cash] [bigint] NOT NULL,
	[IdSanadCash] [bigint] NULL,
	[MonHavaleh] [bigint] NOT NULL,
	[IdBankHavaleh] [bigint] NULL,
	[DiscHavaleh] [nvarchar](max) NULL,
	[MonSellChk] [bigint] NOT NULL,
	[MonPayChk] [bigint] NOT NULL,
	[IdSanadChk] [bigint] NULL,
	[EditFlag] [int] NOT NULL,
	[IdSanadHavaleh] [bigint] NULL,
	[DiscAdd] [nvarchar](max) NULL,
	[DiscDec] [nvarchar](max) NULL,
	[DiscDisH] [nvarchar](max) NULL,
	[DiscDisC] [nvarchar](max) NULL,
	[DiscCash] [nvarchar](max) NULL,
	[DiscSellChk] [nvarchar](max) NULL,
	[DiscChk] [nvarchar](max) NULL,
	[IdBox] [bigint] NULL,
	[IdBanK] [bigint] NULL,
	[IdSanadFactor] [bigint] NULL,
	[IdFacSell] [bigint] NULL,
 CONSTRAINT [PK_ListFactorBackSell] PRIMARY KEY CLUSTERED 
(
	[IdFactor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[ListFactorBuy]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListFactorBuy](
	[IdFactor] [bigint] IDENTITY(1,1) NOT NULL,
	[D_date] [nvarchar](max) NOT NULL,
	[IdName] [bigint] NULL,
	[Part] [bigint] NULL,
	[Sanad] [nvarchar](max) NULL,
	[IdVisitor] [bigint] NULL,
	[IdUser] [bigint] NULL,
	[Disc] [nvarchar](max) NULL,
	[Activ] [int] NOT NULL,
	[Stat] [int] NOT NULL,
	[MonAdd] [bigint] NOT NULL,
	[IdSanadAdd] [bigint] NULL,
	[MonDec] [bigint] NOT NULL,
	[IdSanadDec] [bigint] NULL,
	[IdSanadDiscountH] [bigint] NULL,
	[Discount] [bigint] NOT NULL,
	[IdSanadDiscountC] [bigint] NULL,
	[Cash] [bigint] NOT NULL,
	[IdSanadCash] [bigint] NULL,
	[MonHavaleh] [bigint] NOT NULL,
	[IdBankHavaleh] [bigint] NULL,
	[DiscHavaleh] [nvarchar](max) NULL,
	[MonSellChk] [bigint] NOT NULL,
	[MonPayChk] [bigint] NOT NULL,
	[IdSanadChk] [bigint] NULL,
	[EditFlag] [int] NOT NULL,
	[IdSanadHavaleh] [bigint] NULL,
	[DiscAdd] [nvarchar](max) NULL,
	[DiscDec] [nvarchar](max) NULL,
	[DiscDisH] [nvarchar](max) NULL,
	[DiscDisC] [nvarchar](max) NULL,
	[DiscCash] [nvarchar](max) NULL,
	[DiscSellChk] [nvarchar](max) NULL,
	[DiscChk] [nvarchar](max) NULL,
	[IdBox] [bigint] NULL,
	[IdBanK] [bigint] NULL,
	[IdSanadFactor] [bigint] NULL,
 CONSTRAINT [PK_ListFactorBuy] PRIMARY KEY CLUSTERED 
(
	[IdFactor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[ListFactorCharge]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListFactorCharge](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdFactor] [bigint] NOT NULL,
	[D_date] [nvarchar](max) NOT NULL,
	[IdName] [bigint] NULL,
	[IdUser] [bigint] NULL,
	[Disc] [nvarchar](max) NULL,
	[Activ] [int] NOT NULL,
	[Discount] [bigint] NOT NULL,
	[Cash] [bigint] NOT NULL,
	[MonHavaleh] [bigint] NOT NULL,
	[IdBankHavaleh] [bigint] NULL,
	[DiscHavaleh] [nvarchar](max) NULL,
	[MonSellChk] [bigint] NOT NULL,
	[MonPayChk] [bigint] NOT NULL,
	[Lend] [bigint] NOT NULL,
	[IdSanadLend] [bigint] NULL,
	[EditFlag] [int] NOT NULL,
	[DiscDisC] [nvarchar](max) NULL,
	[DiscCash] [nvarchar](max) NULL,
	[DiscSellChk] [nvarchar](max) NULL,
	[DiscChk] [nvarchar](max) NULL,
	[IdBox] [bigint] NULL,
	[IdBoxMoein] [bigint] NULL,
	[IdBanKMoein] [bigint] NULL,
	[DiscLend] [nvarchar](max) NULL,
	[Sanad] [nvarchar](max) NULL,
 CONSTRAINT [PK_ListFactorCharge] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[ListFactorDamage]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListFactorDamage](
	[IdFactor] [bigint] IDENTITY(1,1) NOT NULL,
	[D_date] [nvarchar](max) NOT NULL,
	[Part] [bigint] NULL,
	[Sanad] [nvarchar](max) NULL,
	[IdUser] [bigint] NULL,
	[Disc] [nvarchar](max) NULL,
	[Activ] [int] NOT NULL,
	[EditFlag] [int] NOT NULL,
 CONSTRAINT [PK_ListFactorDamage] PRIMARY KEY CLUSTERED 
(
	[IdFactor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[ListFactorSell]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListFactorSell](
	[IdFactor] [bigint] IDENTITY(1,1) NOT NULL,
	[D_date] [nvarchar](max) NOT NULL,
	[IdName] [bigint] NULL,
	[Part] [bigint] NULL,
	[Sanad] [nvarchar](max) NULL,
	[IdVisitor] [bigint] NULL,
	[IdUser] [bigint] NULL,
	[Disc] [nvarchar](max) NULL,
	[Activ] [int] NOT NULL,
	[Stat] [int] NOT NULL,
	[MonAdd] [bigint] NOT NULL,
	[IdSanadAdd] [bigint] NULL,
	[MonDec] [bigint] NOT NULL,
	[IdSanadDec] [bigint] NULL,
	[IdSanadDiscountH] [bigint] NULL,
	[Discount] [bigint] NOT NULL,
	[IdSanadDiscountC] [bigint] NULL,
	[Cash] [bigint] NOT NULL,
	[IdSanadCash] [bigint] NULL,
	[MonHavaleh] [bigint] NOT NULL,
	[IdBankHavaleh] [bigint] NULL,
	[DiscHavaleh] [nvarchar](max) NULL,
	[MonPayChk] [bigint] NOT NULL,
	[IdSanadChk] [bigint] NULL,
	[EditFlag] [int] NOT NULL,
	[IdSanadHavaleh] [bigint] NULL,
	[DiscAdd] [nvarchar](max) NULL,
	[DiscDec] [nvarchar](max) NULL,
	[DiscDisH] [nvarchar](max) NULL,
	[DiscDisC] [nvarchar](max) NULL,
	[DiscCash] [nvarchar](max) NULL,
	[DiscChk] [nvarchar](max) NULL,
	[IdBox] [bigint] NULL,
	[IdBanK] [bigint] NULL,
	[IdSanadFactor] [bigint] NULL,
	[KindFrosh] [bigint] NULL,
 CONSTRAINT [PK_ListFactorSell] PRIMARY KEY CLUSTERED 
(
	[IdFactor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[ListFactorService]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListFactorService](
	[IdFactor] [bigint] IDENTITY(1,1) NOT NULL,
	[D_date] [nvarchar](max) NOT NULL,
	[IdName] [bigint] NULL,
	[Part] [bigint] NULL,
	[Sanad] [nvarchar](max) NULL,
	[IdVisitor] [bigint] NULL,
	[IdUser] [bigint] NULL,
	[Disc] [nvarchar](max) NULL,
	[Activ] [int] NOT NULL,
	[MonAdd] [bigint] NOT NULL,
	[IdSanadAdd] [bigint] NULL,
	[MonDec] [bigint] NOT NULL,
	[IdSanadDec] [bigint] NULL,
	[IdSanadDiscountH] [bigint] NULL,
	[Discount] [bigint] NOT NULL,
	[IdSanadDiscountC] [bigint] NULL,
	[Cash] [bigint] NOT NULL,
	[IdSanadCash] [bigint] NULL,
	[MonHavaleh] [bigint] NOT NULL,
	[IdBankHavaleh] [bigint] NULL,
	[DiscHavaleh] [nvarchar](max) NULL,
	[MonPayChk] [bigint] NOT NULL,
	[IdSanadChk] [bigint] NULL,
	[EditFlag] [int] NOT NULL,
	[IdSanadHavaleh] [bigint] NULL,
	[DiscAdd] [nvarchar](max) NULL,
	[DiscDec] [nvarchar](max) NULL,
	[DiscDisH] [nvarchar](max) NULL,
	[DiscDisC] [nvarchar](max) NULL,
	[DiscCash] [nvarchar](max) NULL,
	[DiscChk] [nvarchar](max) NULL,
	[IdBox] [bigint] NULL,
	[IdBanK] [bigint] NULL,
	[IdSanadFactor] [bigint] NULL,
 CONSTRAINT [PK_ListFactorService] PRIMARY KEY CLUSTERED 
(
	[IdFactor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Listkala]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Listkala](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Idkala] [bigint] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[Kala] [float] NOT NULL,
	[IdLinkVisitor] [bigint] NOT NULL,
 CONSTRAINT [PK_Listkala] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListKala_Discount]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListKala_Discount](
	[Idkala] [bigint] NOT NULL,
	[Coding] [nvarchar](max) NULL,
	[AutoDiscount] [bit] NOT NULL,
 CONSTRAINT [PK_ListKala_Discount] PRIMARY KEY CLUSTERED 
(
	[Idkala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Listkala_G]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Listkala_G](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Idkala] [bigint] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[Kala] [float] NOT NULL,
	[IdLinkVisitor] [bigint] NOT NULL,
 CONSTRAINT [PK_Listkala_G] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[Listkala_OG]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Listkala_OG](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Idkala] [bigint] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[Kala] [float] NOT NULL,
	[IdLinkVisitor] [bigint] NOT NULL,
 CONSTRAINT [PK_Listkala_OG] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListkalaU]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListkalaU](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Idkala] [bigint] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[Kala] [float] NOT NULL,
	[IdLinkUser] [bigint] NOT NULL,
 CONSTRAINT [PK_ListkalaU] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListkalaU_G]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListkalaU_G](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Idkala] [bigint] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[Kala] [float] NOT NULL,
	[IdLinkUser] [bigint] NOT NULL,
 CONSTRAINT [PK_ListkalaU_G] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListkalaU_OG]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListkalaU_OG](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Idkala] [bigint] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[Kala] [float] NOT NULL,
	[IdLinkUser] [bigint] NOT NULL,
 CONSTRAINT [PK_ListkalaU_OG] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListKasriFactor]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListKasriFactor](
	[IdFactor] [bigint] NOT NULL,
	[IdUser] [bigint] NOT NULL,
	[IdSanad] [bigint] NULL,
	[Disc] [nvarchar](max) NULL,
	[D_date] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ListKasriFactor] PRIMARY KEY CLUSTERED 
(
	[IdFactor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[ListOrderDarsad]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListOrderDarsad](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdGroup] [bigint] NOT NULL,
	[Darsad] [float] NOT NULL,
	[IdLinkVisitor] [bigint] NOT NULL,
 CONSTRAINT [PK_ListOrderDarsad] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListOrderDarsad_G]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListOrderDarsad_G](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdGroup] [bigint] NOT NULL,
	[Darsad] [float] NOT NULL,
	[IdLinkVisitor] [bigint] NOT NULL,
 CONSTRAINT [PK_ListOrderDarsad_G] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListOrderDarsad_OG]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListOrderDarsad_OG](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdGroup] [bigint] NOT NULL,
	[Darsad] [float] NOT NULL,
	[IdLinkVisitor] [bigint] NOT NULL,
 CONSTRAINT [PK_ListOrderDarsad_OG] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListOrderDarsadU]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListOrderDarsadU](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdGroup] [bigint] NOT NULL,
	[Darsad] [float] NOT NULL,
	[IdLinkUser] [bigint] NOT NULL,
 CONSTRAINT [PK_ListOrderDarsadU] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListOrderDarsadU_G]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListOrderDarsadU_G](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdGroup] [bigint] NOT NULL,
	[Darsad] [float] NOT NULL,
	[IdLinkUser] [bigint] NOT NULL,
 CONSTRAINT [PK_ListOrderDarsadU_G] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListOrderDarsadU_OG]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListOrderDarsadU_OG](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdGroup] [bigint] NOT NULL,
	[Darsad] [float] NOT NULL,
	[IdLinkUser] [bigint] NOT NULL,
 CONSTRAINT [PK_ListOrderDarsadU_OG] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListOtherCharge]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListOtherCharge](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[D_date] [nvarchar](max) NOT NULL,
	[IdName] [bigint] NULL,
	[IdUser] [bigint] NULL,
	[Disc] [nvarchar](max) NULL,
	[Activ] [int] NOT NULL,
	[Discount] [bigint] NOT NULL,
	[Cash] [bigint] NOT NULL,
	[MonHavaleh] [bigint] NOT NULL,
	[IdBankHavaleh] [bigint] NULL,
	[DiscHavaleh] [nvarchar](max) NULL,
	[MonSellChk] [bigint] NOT NULL,
	[MonPayChk] [bigint] NOT NULL,
	[Lend] [bigint] NOT NULL,
	[IdSanadLend] [bigint] NULL,
	[EditFlag] [int] NOT NULL,
	[DiscDisC] [nvarchar](max) NULL,
	[DiscCash] [nvarchar](max) NULL,
	[DiscSellChk] [nvarchar](max) NULL,
	[DiscChk] [nvarchar](max) NULL,
	[IdBox] [bigint] NULL,
	[IdBoxMoein] [bigint] NULL,
	[IdBanKMoein] [bigint] NULL,
	[DiscLend] [nvarchar](max) NULL,
	[Sanad] [nvarchar](max) NULL,
 CONSTRAINT [PK_ListOtherCharge] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[ListUser]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListUser](
	[IdUser] [bigint] NOT NULL,
 CONSTRAINT [PK_ListUser] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListUser_G]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListUser_G](
	[IdUser] [bigint] NOT NULL,
 CONSTRAINT [PK_ListUser_G] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListUser_OG]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListUser_OG](
	[IdUser] [bigint] NOT NULL,
 CONSTRAINT [PK_ListUser_OG] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListVisitor]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListVisitor](
	[IdVisitor] [bigint] NOT NULL,
 CONSTRAINT [PK_ListVisitor] PRIMARY KEY CLUSTERED 
(
	[IdVisitor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListVisitor_G]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListVisitor_G](
	[IdVisitor] [bigint] NOT NULL,
 CONSTRAINT [PK_ListVisitor_G] PRIMARY KEY CLUSTERED 
(
	[IdVisitor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[ListVisitor_OG]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ListVisitor_OG](
	[IdVisitor] [bigint] NOT NULL,
 CONSTRAINT [PK_ListVisitor_OG] PRIMARY KEY CLUSTERED 
(
	[IdVisitor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[MessageCenter]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[MessageCenter](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Sender_IdUser] [bigint] NULL,
	[Sender_IdVisitor] [bigint] NULL,
	[Reciver_IdUser] [bigint] NULL,
	[Reciver_IdVisitor] [bigint] NULL,
	[Subject] [nvarchar](max) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[C_Date] [nvarchar](max) NOT NULL,
	[R_Date] [nvarchar](max) NULL,
	[Chk] [bit] NOT NULL,
	[Kind] [int] NOT NULL,
	[Response] [bigint] NULL,
	[RChk] [bit] NULL,
 CONSTRAINT [PK_OutBox] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Mobile_KalaFactorSell]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Mobile_KalaFactorSell](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IdFactor] [bigint] NOT NULL,
	[IdKala] [bigint] NULL,
	[KolCount] [float] NOT NULL,
	[JozCount] [float] NOT NULL,
	[Discount] [float] NULL,
	[Fe] [bigint] NULL,
	[OldFe] [bigint] NULL,
	[IdAnbar] [bigint] NULL,
 CONSTRAINT [PK_Mobile_Kala_FactorSell] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[Mobile_ListFactorSell]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Mobile_ListFactorSell](
	[IdFactor] [bigint] IDENTITY(1,1) NOT NULL,
	[D_date] [nvarchar](max) NOT NULL,
	[T_time] [nvarchar](max) NOT NULL,
	[IdName] [bigint] NULL,
	[IdVisitor] [bigint] NULL,
	[IdUser] [bigint] NULL,
	[Confirm] [int] NOT NULL,
	[Rate] [int] NULL,
	[Kind] [int] NOT NULL,
	[Disc] [nvarchar](max) NULL,
	[IdSell] [bigint] NULL,
	[IdNewPeople] [bigint] NULL,
	[IdAnbar] [bigint] NULL,
 CONSTRAINT [PK_Mobile_ListFactorSell] PRIMARY KEY CLUSTERED 
(
	[IdFactor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Mobile_NewPeople]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Mobile_NewPeople](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Tell1] [nvarchar](max) NULL,
	[Tell2] [nvarchar](max) NULL,
	[D_Date] [nvarchar](max) NOT NULL,
	[T_Time] [nvarchar](max) NOT NULL,
	[IdGroup] [bigint] NOT NULL,
	[IdOstan] [bigint] NOT NULL,
	[IdCity] [bigint] NOT NULL,
	[IdPart] [bigint] NOT NULL,
	[Nam] [nvarchar](max) NOT NULL,
	[IdVisitor] [bigint] NULL,
	[IdUser] [bigint] NULL,
	[Adres] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Mobile_NewPeople] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Mobile_NoSales]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Mobile_NoSales](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdName] [bigint] NOT NULL,
	[Reason] [int] NOT NULL,
	[Disc] [nvarchar](max) NULL,
	[IdVisitor] [bigint] NULL,
	[IdUser] [bigint] NULL,
	[D_date] [nvarchar](max) NOT NULL,
	[T_time] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Mobile_NoSales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Mobile_Setting]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Mobile_Setting](
	[S1] [nvarchar](max) NULL,
	[S2] [nvarchar](max) NULL,
	[S3] [nvarchar](max) NULL,
	[S4] [nvarchar](max) NULL,
	[S5] [nvarchar](max) NULL,
	[S6] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Moein_Bank]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Moein_Bank](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[D_date] [nvarchar](max) NOT NULL,
	[disc] [nvarchar](max) NOT NULL,
	[mon] [bigint] NOT NULL,
	[T] [int] NOT NULL,
	[IDBank] [bigint] NOT NULL,
	[IdUser] [bigint] NULL,
 CONSTRAINT [PK_Moein_Bank] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Moein_Box]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Moein_Box](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[D_date] [nvarchar](max) NOT NULL,
	[disc] [nvarchar](max) NOT NULL,
	[mon] [bigint] NOT NULL,
	[T] [int] NOT NULL,
	[IDBox] [bigint] NOT NULL,
	[IdUser] [bigint] NULL,
 CONSTRAINT [PK_Moein_Box] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Moein_People]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Moein_People](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[D_date] [nvarchar](max) NOT NULL,
	[disc] [nvarchar](max) NOT NULL,
	[mon] [bigint] NOT NULL,
	[T] [int] NOT NULL,
	[IDPeople] [bigint] NOT NULL,
	[IdUser] [bigint] NULL,
	[Type] [bigint] NOT NULL,
	[Number_Type] [bigint] NOT NULL,
	[Type_Sanad] [bigint] NOT NULL,
 CONSTRAINT [PK_Moein_People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[PayLimitFrosh]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[PayLimitFrosh](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdSanad] [bigint] NOT NULL,
	[IdFactor] [bigint] NOT NULL,
	[Pay] [bigint] NOT NULL,
 CONSTRAINT [PK_PayLimitFrosh] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[PayLimitKharid]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[PayLimitKharid](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdSanad] [bigint] NOT NULL,
	[IdFactor] [bigint] NOT NULL,
	[Pay] [bigint] NOT NULL,
 CONSTRAINT [PK_PayLimitKharid] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[Sanad_AddDecBank]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Sanad_AddDecBank](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdBank] [bigint] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[D_Date] [nvarchar](max) NOT NULL,
	[Disc] [nvarchar](max) NULL,
	[Flag] [int] NOT NULL,
	[IdUser] [bigint] NULL,
	[IDsanadBank] [bigint] NULL,
 CONSTRAINT [PK_Sanad_AddDecBank] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Sanad_AddDecBox]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Sanad_AddDecBox](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdBox] [bigint] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[D_Date] [nvarchar](max) NOT NULL,
	[Disc] [nvarchar](max) NULL,
	[Flag] [int] NOT NULL,
	[IdUser] [bigint] NULL,
	[IDsanadBox] [bigint] NULL,
 CONSTRAINT [PK_Sanad_AddDecBox] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Sanad_BankTBank_Bed]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Sanad_BankTBank_Bed](
	[AutoId] [bigint] IDENTITY(1,1) NOT NULL,
	[Id] [bigint] NOT NULL,
	[IdBankBed] [bigint] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[IdSanadBed] [bigint] NULL,
	[Disc] [nvarchar](max) NULL,
 CONSTRAINT [PK_Sanad_BankTBank_Bed] PRIMARY KEY CLUSTERED 
(
	[AutoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Sanad_BankTBank_Bes]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Sanad_BankTBank_Bes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdBankBes] [bigint] NOT NULL,
	[IdUser] [bigint] NOT NULL,
	[Disc] [nvarchar](max) NULL,
	[D_date] [nvarchar](max) NOT NULL,
	[Mon] [bigint] NOT NULL,
	[IdSanadBes] [bigint] NULL,
	[NumChk] [bigint] NULL,
 CONSTRAINT [PK_Sanad_BankTBank_Bes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Sanad_BOXTBOX]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Sanad_BOXTBOX](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdNameBed] [bigint] NOT NULL,
	[IdNameBes] [bigint] NOT NULL,
	[IdUser] [bigint] NOT NULL,
	[Disc] [nvarchar](max) NULL,
	[D_date] [nvarchar](max) NOT NULL,
	[Mon] [bigint] NOT NULL,
	[IdSanadBed] [bigint] NULL,
	[IdSanadBes] [bigint] NULL,
 CONSTRAINT [PK_Sanad_BOXTBOX] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Sanad_ChangeChk]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Sanad_ChangeChk](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdChk] [bigint] NOT NULL,
	[BoxMoein] [bigint] NULL,
	[BankMoein] [bigint] NULL,
	[PeopleMoein] [bigint] NULL,
	[DelayChk] [bigint] NOT NULL,
 CONSTRAINT [PK_Sanad_ChangeChk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[Sanad_PTP]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Sanad_PTP](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdNameBed] [bigint] NOT NULL,
	[IdNameBes] [bigint] NOT NULL,
	[IdUser] [bigint] NOT NULL,
	[Disc] [nvarchar](max) NULL,
	[D_date] [nvarchar](max) NOT NULL,
	[Mon] [bigint] NOT NULL,
	[IdSanadBed] [bigint] NULL,
	[IdSanadBes] [bigint] NULL,
 CONSTRAINT [PK_Sanad_PTP] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Sanad_Translate_BoxBank]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Sanad_Translate_BoxBank](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[D_Date] [nvarchar](max) NOT NULL,
	[IdBox] [bigint] NOT NULL,
	[IdBank] [bigint] NOT NULL,
	[Mon] [bigint] NOT NULL,
	[Stat] [int] NOT NULL,
	[Disc] [nvarchar](max) NULL,
	[IdBoxMoein] [bigint] NULL,
	[IdBankMoein] [bigint] NULL,
	[NumChk] [bigint] NULL,
	[IdUser] [bigint] NULL,
 CONSTRAINT [PK_Sanad_Translate_BoxBank] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[SettingProgram]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[SettingProgram](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FactorPaper] [int] NOT NULL,
	[TypeFactor] [int] NOT NULL,
	[FactorCount] [int] NOT NULL,
	[AnbarCount] [int] NOT NULL,
	[Get_Pay_Count] [int] NOT NULL,
	[FilterKala] [int] NOT NULL,
	[TypeKala] [int] NOT NULL,
	[FilterP] [int] NOT NULL,
	[TypeP] [int] NOT NULL,
	[TypeAll] [int] NOT NULL,
	[MojodyBox] [bit] NOT NULL,
	[MojodyBank] [bit] NOT NULL,
	[MojodyAnbar] [bit] NOT NULL,
	[S1] [nvarchar](max) NULL,
	[S2] [nvarchar](max) NULL,
	[S3] [nvarchar](max) NULL,
	[S4] [nvarchar](max) NULL,
	[S5] [nvarchar](max) NULL,
	[S6] [nvarchar](max) NULL,
	[S7] [nvarchar](max) NULL,
	[S8] [nvarchar](max) NULL,
	[IdUser] [bigint] NOT NULL,
	[Barcode] [bit] NOT NULL,
	[IdAnbar] [bigint] NULL,
	[KalaDup] [bit] NOT NULL,
	[Fish] [bit] NOT NULL,
	[S9] [nvarchar](max) NULL,
	[S10] [nvarchar](max) NULL,
	[S11] [nvarchar](max) NULL,
	[S12] [nvarchar](max) NULL,
	[S13] [nvarchar](max) NULL,
	[S14] [nvarchar](max) NULL,
	[S15] [nvarchar](max) NULL,
	[S16] [nvarchar](max) NULL,
	[S17] [nvarchar](max) NULL,
	[S18] [nvarchar](max) NULL,
	[S19] [nvarchar](max) NULL,
	[S20] [nvarchar](max) NULL,
	[S21] [nvarchar](max) NULL,
	[S22] [nvarchar](max) NULL,
	[S23] [nvarchar](max) NULL,
	[S24] [nvarchar](max) NULL,
	[S25] [nvarchar](max) NULL,
	[S26] [nvarchar](max) NULL,
	[S27] [nvarchar](max) NULL,
	[S28] [nvarchar](max) NULL,
	[S32] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_SettingProgram] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[ShortcutMenu]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ShortcutMenu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Caption] [nvarchar](150) NULL,
	[Active] [int] NULL,
	[IdUser] [int] NULL,
	[Disc] [nvarchar](50) NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_ShortcutMenu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[TimeFrosh]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[TimeFrosh](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdFactor] [bigint] NOT NULL,
	[NewDate] [nvarchar](max) NOT NULL,
	[Disc] [nvarchar](max) NULL,
 CONSTRAINT [PK_TimeFrosh] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[TimeKharid]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[TimeKharid](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdFactor] [bigint] NOT NULL,
	[NewDate] [nvarchar](max) NOT NULL,
	[Disc] [nvarchar](max) NULL,
 CONSTRAINT [PK_TimeKharid] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[TraceUser]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[TraceUser](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdUser] [bigint] NOT NULL,
	[D_Date] [varbinary](max) NOT NULL,
	[T_Time] [varbinary](max) NOT NULL,
	[Form] [varbinary](max) NOT NULL,
	[Action] [varbinary](max) NOT NULL,
	[Disc] [varbinary](max) NULL,
	[SystemDisc] [varbinary](max) NULL,
 CONSTRAINT [PK_TraceUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Tranlate_Anbar]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Tranlate_Anbar](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdOneAnbar] [bigint] NOT NULL,
	[IdTwoAnbar] [bigint] NOT NULL,
	[IdKala] [bigint] NOT NULL,
	[Kol] [float] NOT NULL,
	[Joz] [float] NOT NULL,
	[Disc] [nvarchar](max) NULL,
	[D_date] [nvarchar](max) NOT NULL,
	[IdUser] [bigint] NULL,
 CONSTRAINT [PK_Tranlate_Anbar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[User_Access]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[User_Access](
	[Id] [bigint] NOT NULL,
	[F1] [varbinary](max) NULL,
	[F2] [varbinary](max) NULL,
	[F3] [varbinary](max) NULL,
	[F4] [varbinary](max) NULL,
	[F5] [varbinary](max) NULL,
	[F6] [varbinary](max) NULL,
	[F7] [varbinary](max) NULL,
	[F8] [varbinary](max) NULL,
	[F9] [varbinary](max) NULL,
	[F10] [varbinary](max) NULL,
	[F11] [varbinary](max) NULL,
	[F12] [varbinary](max) NULL,
	[F13] [varbinary](max) NULL,
	[F14] [varbinary](max) NULL,
	[F15] [varbinary](max) NULL,
	[F16] [varbinary](max) NULL,
	[F17] [varbinary](max) NULL,
	[F18] [varbinary](max) NULL,
	[F19] [varbinary](max) NULL,
	[F20] [varbinary](max) NULL,
	[F21] [varbinary](max) NULL,
	[F22] [varbinary](max) NULL,
	[F23] [varbinary](max) NULL,
	[F24] [varbinary](max) NULL,
	[F25] [varbinary](max) NULL,
	[F26] [varbinary](max) NULL,
	[F27] [varbinary](max) NULL,
	[F28] [varbinary](max) NULL,
	[F29] [varbinary](max) NULL,
	[F30] [varbinary](max) NULL,
	[F31] [varbinary](max) NULL,
	[F32] [varbinary](max) NULL,
	[F33] [varbinary](max) NULL,
	[F34] [varbinary](max) NULL,
	[F35] [varbinary](max) NULL,
	[F36] [varbinary](max) NULL,
	[F37] [varbinary](max) NULL,
	[F38] [varbinary](max) NULL,
	[F39] [varbinary](max) NULL,
	[F40] [varbinary](max) NULL,
	[F41] [varbinary](max) NULL,
	[F42] [varbinary](max) NULL,
	[F43] [varbinary](max) NULL,
	[F44] [varbinary](max) NULL,
	[F45] [varbinary](max) NULL,
	[F46] [varbinary](max) NULL,
	[F47] [varbinary](max) NULL,
	[F48] [varbinary](max) NULL,
	[F49] [varbinary](max) NULL,
	[F50] [varbinary](max) NULL,
	[F51] [varbinary](max) NULL,
	[F52] [varbinary](max) NULL,
	[F53] [varbinary](max) NULL,
	[F54] [varbinary](max) NULL,
	[F55] [varbinary](max) NULL,
	[F56] [varbinary](max) NULL,
	[F57] [varbinary](max) NULL,
	[F58] [varbinary](max) NULL,
	[F59] [varbinary](max) NULL,
	[F60] [varbinary](max) NULL,
	[F61] [varbinary](max) NULL,
	[F62] [varbinary](max) NULL,
	[F63] [varbinary](max) NULL,
	[F64] [varbinary](max) NULL,
	[F65] [varbinary](max) NULL,
	[F66] [varbinary](max) NULL,
	[F67] [varbinary](max) NULL,
	[F68] [varbinary](max) NULL,
	[F69] [varbinary](max) NULL,
	[F70] [varbinary](max) NULL,
	[F71] [varbinary](max) NULL,
	[F72] [varbinary](max) NULL,
	[F73] [varbinary](max) NULL,
	[F74] [varbinary](max) NULL,
	[F75] [varbinary](max) NULL,
	[F76] [varbinary](max) NULL,
	[F77] [varbinary](max) NULL,
	[F78] [varbinary](max) NULL,
	[F79] [varbinary](max) NULL,
	[F80] [varbinary](max) NULL,
	[F81] [varbinary](max) NULL,
	[F82] [varbinary](max) NULL,
	[F83] [varbinary](max) NULL,
	[F84] [varbinary](max) NULL,
	[F85] [varbinary](max) NULL,
	[F86] [varbinary](max) NULL,
	[F87] [varbinary](max) NULL,
	[F88] [varbinary](max) NULL,
	[F89] [varbinary](max) NULL,
	[F90] [varbinary](max) NULL,
	[F91] [varbinary](max) NULL,
	[F92] [varbinary](max) NULL,
	[F93] [varbinary](max) NULL,
	[F94] [varbinary](max) NULL,
	[F95] [varbinary](max) NULL,
	[F96] [varbinary](max) NULL,
	[F97] [varbinary](max) NULL,
	[F98] [varbinary](max) NULL,
	[F99] [varbinary](max) NULL,
	[F100] [varbinary](max) NULL,
	[F101] [varbinary](max) NULL,
	[F102] [varbinary](max) NULL,
	[F103] [varbinary](max) NULL,
	[F104] [varbinary](max) NULL,
	[F105] [varbinary](max) NULL,
	[F106] [varbinary](max) NULL,
	[F107] [varbinary](max) NULL,
	[F108] [varbinary](max) NULL,
	[F109] [varbinary](max) NULL,
	[F110] [varbinary](max) NULL,
	[F111] [varbinary](max) NULL,
	[F112] [varbinary](max) NULL,
	[F113] [varbinary](max) NULL,
	[F114] [varbinary](max) NULL,
	[F115] [varbinary](max) NULL,
	[F116] [varbinary](max) NULL,
	[F117] [varbinary](max) NULL,
	[F118] [varbinary](max) NULL,
	[F119] [varbinary](max) NULL,
	[F120] [varbinary](max) NULL,
	[F121] [varbinary](max) NULL,
	[F122] [varbinary](max) NULL,
	[F123] [varbinary](max) NULL,
	[F124] [varbinary](max) NULL,
	[F125] [varbinary](max) NULL,
	[F126] [varbinary](max) NULL,
	[F127] [varbinary](max) NULL,
	[F128] [varbinary](max) NULL,
	[F129] [varbinary](max) NULL,
	[F130] [varbinary](max) NULL,
	[F131] [varbinary](max) NULL,
	[F132] [varbinary](max) NULL,
	[F133] [varbinary](max) NULL,
	[F134] [varbinary](max) NULL,
	[F135] [varbinary](max) NULL,
	[F136] [varbinary](max) NULL,
	[F137] [varbinary](max) NULL,
	[F138] [varbinary](max) NULL,
	[F139] [varbinary](max) NULL,
	[F140] [varbinary](max) NULL,
	[F141] [varbinary](max) NULL,
	[F142] [varbinary](max) NULL,
	[F143] [varbinary](max) NULL,
	[F144] [varbinary](max) NULL,
	[F145] [varbinary](max) NULL,
	[F146] [varbinary](max) NULL,
	[F147] [varbinary](max) NULL,
	[F148] [varbinary](max) NULL,
	[F149] [varbinary](max) NULL,
	[F150] [varbinary](max) NULL,
	[F151] [varbinary](max) NULL,
	[F152] [varbinary](max) NULL,
	[F153] [varbinary](max) NULL,
	[F154] [varbinary](max) NULL,
	[F155] [varbinary](max) NULL,
	[F156] [varbinary](max) NULL,
	[F157] [varbinary](max) NULL,
	[F158] [varbinary](max) NULL,
	[F159] [varbinary](max) NULL,
	[F160] [varbinary](max) NULL,
 CONSTRAINT [PK_User_Access] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Wanted_Frosh]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Wanted_Frosh](
	[IdFactor] [bigint] NOT NULL,
	[Rate] [bigint] NOT NULL,
	[Disc] [nvarchar](max) NULL,
 CONSTRAINT [PK_Wanted_Frosh] PRIMARY KEY CLUSTERED 
(
	[IdFactor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[Wanted_Kharid]    Script Date: 2018/10/05 11:24:56 ب.ظ ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Wanted_Kharid](
	[IdFactor] [bigint] NOT NULL,
	[Rate] [bigint] NOT NULL,
	[Disc] [nvarchar](max) NULL,
 CONSTRAINT [PK_Wanted_Kharid] PRIMARY KEY CLUSTERED 
(
	[IdFactor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


ALTER TABLE [dbo].[Mobile_KalaFactorSell] ADD  DEFAULT ((0)) FOR [Discount]

ALTER TABLE [dbo].[Mobile_KalaFactorSell] ADD  DEFAULT ((0)) FOR [Fe]

ALTER TABLE [dbo].[Mobile_KalaFactorSell] ADD  DEFAULT ((0)) FOR [OldFe]

ALTER TABLE [dbo].[Mobile_NewPeople] ADD  DEFAULT (N'') FOR [Adres]

ALTER TABLE [dbo].[SettingProgram] ADD  CONSTRAINT [DF_SettingProgram_FactorPaper]  DEFAULT ((0)) FOR [FactorPaper]

ALTER TABLE [dbo].[SettingProgram] ADD  CONSTRAINT [DF_SettingProgram_TypeFactor]  DEFAULT ((0)) FOR [TypeFactor]

ALTER TABLE [dbo].[SettingProgram] ADD  CONSTRAINT [DF_SettingProgram_FactorCount]  DEFAULT ((1)) FOR [FactorCount]

ALTER TABLE [dbo].[SettingProgram] ADD  CONSTRAINT [DF_SettingProgram_AnbarCount]  DEFAULT ((1)) FOR [AnbarCount]

ALTER TABLE [dbo].[SettingProgram] ADD  CONSTRAINT [DF_SettingProgram_Get_Pay_Count]  DEFAULT ((1)) FOR [Get_Pay_Count]

ALTER TABLE [dbo].[SettingProgram] ADD  CONSTRAINT [DF_SettingProgram_FilterKala]  DEFAULT ((0)) FOR [FilterKala]

ALTER TABLE [dbo].[SettingProgram] ADD  CONSTRAINT [DF_SettingProgram_TypeKala]  DEFAULT ((0)) FOR [TypeKala]

ALTER TABLE [dbo].[SettingProgram] ADD  CONSTRAINT [DF_SettingProgram_FilterP]  DEFAULT ((0)) FOR [FilterP]

ALTER TABLE [dbo].[SettingProgram] ADD  CONSTRAINT [DF_SettingProgram_TypeP]  DEFAULT ((0)) FOR [TypeP]

ALTER TABLE [dbo].[SettingProgram] ADD  CONSTRAINT [DF_SettingProgram_TypeAll]  DEFAULT ((0)) FOR [TypeAll]

ALTER TABLE [dbo].[SettingProgram] ADD  DEFAULT ((1)) FOR [S32]

ALTER TABLE [dbo].[AddPayLimitFrosh]  WITH CHECK ADD  CONSTRAINT [FK_AddPayLimitFrosh_Wanted_Frosh] FOREIGN KEY([IdFactor])
REFERENCES [dbo].[Wanted_Frosh] ([IdFactor])
ON DELETE CASCADE

ALTER TABLE [dbo].[AddPayLimitFrosh] CHECK CONSTRAINT [FK_AddPayLimitFrosh_Wanted_Frosh]

ALTER TABLE [dbo].[AddPayLimitKharid]  WITH CHECK ADD  CONSTRAINT [FK_AddPayLimitKharid_Wanted_Kharid] FOREIGN KEY([IdFactor])
REFERENCES [dbo].[Wanted_Kharid] ([IdFactor])
ON DELETE CASCADE

ALTER TABLE [dbo].[AddPayLimitKharid] CHECK CONSTRAINT [FK_AddPayLimitKharid_Wanted_Kharid]

ALTER TABLE [dbo].[Chk_Get_Pay]  WITH CHECK ADD  CONSTRAINT [FK_Chk_Get_Pay_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Chk_Get_Pay] CHECK CONSTRAINT [FK_Chk_Get_Pay_Define_User]

ALTER TABLE [dbo].[Chk_Id]  WITH CHECK ADD  CONSTRAINT [FK_Chk_Id_Chk_Get_Pay] FOREIGN KEY([Id])
REFERENCES [dbo].[Chk_Get_Pay] ([ID])

ALTER TABLE [dbo].[Chk_Id] CHECK CONSTRAINT [FK_Chk_Id_Chk_Get_Pay]

ALTER TABLE [dbo].[Chk_Id]  WITH CHECK ADD  CONSTRAINT [FK_Chk_Id_Define_Amval] FOREIGN KEY([IdAmval])
REFERENCES [dbo].[Define_Amval] ([ID])

ALTER TABLE [dbo].[Chk_Id] CHECK CONSTRAINT [FK_Chk_Id_Define_Amval]

ALTER TABLE [dbo].[Chk_Id]  WITH CHECK ADD  CONSTRAINT [FK_Chk_Id_Define_Bank] FOREIGN KEY([IdBank])
REFERENCES [dbo].[Define_Bank] ([ID])

ALTER TABLE [dbo].[Chk_Id] CHECK CONSTRAINT [FK_Chk_Id_Define_Bank]

ALTER TABLE [dbo].[Chk_Id]  WITH CHECK ADD  CONSTRAINT [FK_Chk_Id_Define_Daramad] FOREIGN KEY([IdDaramad])
REFERENCES [dbo].[Define_Daramad] ([ID])

ALTER TABLE [dbo].[Chk_Id] CHECK CONSTRAINT [FK_Chk_Id_Define_Daramad]

ALTER TABLE [dbo].[Chk_Id]  WITH CHECK ADD  CONSTRAINT [FK_Chk_Id_Define_People] FOREIGN KEY([IdPeople])
REFERENCES [dbo].[Define_People] ([ID])

ALTER TABLE [dbo].[Chk_Id] CHECK CONSTRAINT [FK_Chk_Id_Define_People]

ALTER TABLE [dbo].[Chk_Id]  WITH CHECK ADD  CONSTRAINT [FK_Chk_Id_Define_People1] FOREIGN KEY([Current_IdPeople])
REFERENCES [dbo].[Define_People] ([ID])

ALTER TABLE [dbo].[Chk_Id] CHECK CONSTRAINT [FK_Chk_Id_Define_People1]

ALTER TABLE [dbo].[Chk_Id]  WITH CHECK ADD  CONSTRAINT [FK_Chk_Id_Define_Sarmaeh] FOREIGN KEY([Idsarmayeh])
REFERENCES [dbo].[Define_Sarmayeh] ([ID])

ALTER TABLE [dbo].[Chk_Id] CHECK CONSTRAINT [FK_Chk_Id_Define_Sarmaeh]

ALTER TABLE [dbo].[Chk_State]  WITH CHECK ADD  CONSTRAINT [FK_Chk_State_Chk_Get_Pay] FOREIGN KEY([Id])
REFERENCES [dbo].[Chk_Get_Pay] ([ID])

ALTER TABLE [dbo].[Chk_State] CHECK CONSTRAINT [FK_Chk_State_Chk_Get_Pay]

ALTER TABLE [dbo].[Chk_State]  WITH CHECK ADD  CONSTRAINT [FK_Chk_State_Define_Bank] FOREIGN KEY([TmpId])
REFERENCES [dbo].[Define_Bank] ([ID])

ALTER TABLE [dbo].[Chk_State] CHECK CONSTRAINT [FK_Chk_State_Define_Bank]

ALTER TABLE [dbo].[Chk_State]  WITH CHECK ADD  CONSTRAINT [FK_Chk_State_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Chk_State] CHECK CONSTRAINT [FK_Chk_State_Define_User]

ALTER TABLE [dbo].[Define_ActivePeople]  WITH CHECK ADD  CONSTRAINT [FK_Define_ActivePeople_Define_People] FOREIGN KEY([IdName])
REFERENCES [dbo].[Define_People] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[Define_ActivePeople] CHECK CONSTRAINT [FK_Define_ActivePeople_Define_People]

ALTER TABLE [dbo].[Define_ActivePeople]  WITH CHECK ADD  CONSTRAINT [FK_Define_ActivePeople_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Define_ActivePeople] CHECK CONSTRAINT [FK_Define_ActivePeople_Define_User]

ALTER TABLE [dbo].[Define_ActivePeople]  WITH CHECK ADD  CONSTRAINT [FK_Define_ActivePeople_Define_User1] FOREIGN KEY([IdUserEdit])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Define_ActivePeople] CHECK CONSTRAINT [FK_Define_ActivePeople_Define_User1]

ALTER TABLE [dbo].[Define_ActivePeople]  WITH CHECK ADD  CONSTRAINT [FK_Define_ActivePeople_Define_Visitor] FOREIGN KEY([IdVisitor])
REFERENCES [dbo].[Define_Visitor] ([Id])

ALTER TABLE [dbo].[Define_ActivePeople] CHECK CONSTRAINT [FK_Define_ActivePeople_Define_Visitor]

ALTER TABLE [dbo].[Define_Amval]  WITH CHECK ADD  CONSTRAINT [FK_Define_Amval_Define_OneAmval] FOREIGN KEY([IdOne])
REFERENCES [dbo].[Define_OneAmval] ([Id])

ALTER TABLE [dbo].[Define_Amval] CHECK CONSTRAINT [FK_Define_Amval_Define_OneAmval]

ALTER TABLE [dbo].[Define_Charge]  WITH CHECK ADD  CONSTRAINT [FK_Define_Charge_Define_OneCharge] FOREIGN KEY([IdOne])
REFERENCES [dbo].[Define_OneCharge] ([Id])

ALTER TABLE [dbo].[Define_Charge] CHECK CONSTRAINT [FK_Define_Charge_Define_OneCharge]

ALTER TABLE [dbo].[Define_Chk]  WITH CHECK ADD  CONSTRAINT [FK_Define_Chk_Define_Bank] FOREIGN KEY([ID])
REFERENCES [dbo].[Define_Bank] ([ID])

ALTER TABLE [dbo].[Define_Chk] CHECK CONSTRAINT [FK_Define_Chk_Define_Bank]

ALTER TABLE [dbo].[Define_City]  WITH CHECK ADD  CONSTRAINT [FK_Define_City_Define_Ostan] FOREIGN KEY([IdOstan])
REFERENCES [dbo].[Define_Ostan] ([Code])

ALTER TABLE [dbo].[Define_City] CHECK CONSTRAINT [FK_Define_City_Define_Ostan]

ALTER TABLE [dbo].[Define_CityCostkala]  WITH CHECK ADD  CONSTRAINT [FK_Define_CityCostkala_Define_City] FOREIGN KEY([IdCity])
REFERENCES [dbo].[Define_City] ([Code])

ALTER TABLE [dbo].[Define_CityCostkala] CHECK CONSTRAINT [FK_Define_CityCostkala_Define_City]

ALTER TABLE [dbo].[Define_Company]  WITH CHECK ADD  CONSTRAINT [FK_Define_Company_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])
ON DELETE CASCADE

ALTER TABLE [dbo].[Define_Company] CHECK CONSTRAINT [FK_Define_Company_Define_User]

ALTER TABLE [dbo].[Define_CostKala]  WITH CHECK ADD  CONSTRAINT [FK_Define_CostKala_Define_City] FOREIGN KEY([IdCity])
REFERENCES [dbo].[Define_City] ([Code])

ALTER TABLE [dbo].[Define_CostKala] CHECK CONSTRAINT [FK_Define_CostKala_Define_City]

ALTER TABLE [dbo].[Define_CostKala]  WITH CHECK ADD  CONSTRAINT [FK_Define_CostKala_Define_CityCostkala] FOREIGN KEY([IdCity])
REFERENCES [dbo].[Define_CityCostkala] ([IdCity])

ALTER TABLE [dbo].[Define_CostKala] CHECK CONSTRAINT [FK_Define_CostKala_Define_CityCostkala]

ALTER TABLE [dbo].[Define_CostKala]  WITH CHECK ADD  CONSTRAINT [FK_Define_CostKala_Define_Kala] FOREIGN KEY([IdKala])
REFERENCES [dbo].[Define_Kala] ([Id])

ALTER TABLE [dbo].[Define_CostKala] CHECK CONSTRAINT [FK_Define_CostKala_Define_Kala]

ALTER TABLE [dbo].[Define_Daramad]  WITH CHECK ADD  CONSTRAINT [FK_Define_Daramad_Define_OneDaramad] FOREIGN KEY([IdOne])
REFERENCES [dbo].[Define_OneDaramad] ([Id])

ALTER TABLE [dbo].[Define_Daramad] CHECK CONSTRAINT [FK_Define_Daramad_Define_OneDaramad]

ALTER TABLE [dbo].[Define_EditKala]  WITH CHECK ADD  CONSTRAINT [FK_Define_EditKala_Define_Anbar] FOREIGN KEY([IdAnbar])
REFERENCES [dbo].[Define_Anbar] ([ID])

ALTER TABLE [dbo].[Define_EditKala] CHECK CONSTRAINT [FK_Define_EditKala_Define_Anbar]

ALTER TABLE [dbo].[Define_EditKala]  WITH CHECK ADD  CONSTRAINT [FK_Define_EditKala_Define_Kala] FOREIGN KEY([Idkala])
REFERENCES [dbo].[Define_Kala] ([Id])
ON DELETE CASCADE

ALTER TABLE [dbo].[Define_EditKala] CHECK CONSTRAINT [FK_Define_EditKala_Define_Kala]

ALTER TABLE [dbo].[Define_Kala]  WITH CHECK ADD  CONSTRAINT [FK_Define_Kala_Define_OneGroup] FOREIGN KEY([IdCodeOne])
REFERENCES [dbo].[Define_OneGroup] ([Id])

ALTER TABLE [dbo].[Define_Kala] CHECK CONSTRAINT [FK_Define_Kala_Define_OneGroup]

ALTER TABLE [dbo].[Define_Kala]  WITH CHECK ADD  CONSTRAINT [FK_Define_Kala_Define_TwoGroup] FOREIGN KEY([IdCodeTwo])
REFERENCES [dbo].[Define_TwoGroup] ([Id])

ALTER TABLE [dbo].[Define_Kala] CHECK CONSTRAINT [FK_Define_Kala_Define_TwoGroup]

ALTER TABLE [dbo].[Define_Kala]  WITH CHECK ADD  CONSTRAINT [FK_Define_Kala_Define_Vahed] FOREIGN KEY([IdVahed])
REFERENCES [dbo].[Define_Vahed] ([Id])

ALTER TABLE [dbo].[Define_Kala] CHECK CONSTRAINT [FK_Define_Kala_Define_Vahed]

ALTER TABLE [dbo].[Define_KalaRate]  WITH CHECK ADD  CONSTRAINT [FK_Define_KalaRate_Define_Kala] FOREIGN KEY([IdKala])
REFERENCES [dbo].[Define_Kala] ([Id])

ALTER TABLE [dbo].[Define_KalaRate] CHECK CONSTRAINT [FK_Define_KalaRate_Define_Kala]

ALTER TABLE [dbo].[Define_List_Group_P]  WITH CHECK ADD  CONSTRAINT [FK_Define_List_Group_P_Define_Group_P] FOREIGN KEY([LinkId])
REFERENCES [dbo].[Define_Group_P] ([Id])
ON DELETE CASCADE

ALTER TABLE [dbo].[Define_List_Group_P] CHECK CONSTRAINT [FK_Define_List_Group_P_Define_Group_P]

ALTER TABLE [dbo].[Define_ListKalaRate]  WITH CHECK ADD  CONSTRAINT [FK_Define_ListKalaRate_Define_Group_P] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Define_Group_P] ([Id])

ALTER TABLE [dbo].[Define_ListKalaRate] CHECK CONSTRAINT [FK_Define_ListKalaRate_Define_Group_P]

ALTER TABLE [dbo].[Define_ListKalaRate]  WITH CHECK ADD  CONSTRAINT [FK_Define_ListKalaRate_Define_KalaRate] FOREIGN KEY([IdKalaLink])
REFERENCES [dbo].[Define_KalaRate] ([IdKala])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[Define_ListKalaRate] CHECK CONSTRAINT [FK_Define_ListKalaRate_Define_KalaRate]

ALTER TABLE [dbo].[Define_Part]  WITH CHECK ADD  CONSTRAINT [FK_Define_Part_Define_City] FOREIGN KEY([IdCity])
REFERENCES [dbo].[Define_City] ([Code])

ALTER TABLE [dbo].[Define_Part] CHECK CONSTRAINT [FK_Define_Part_Define_City]

ALTER TABLE [dbo].[Define_Part]  WITH CHECK ADD  CONSTRAINT [FK_Define_Part_Define_Ostan] FOREIGN KEY([IdOstan])
REFERENCES [dbo].[Define_Ostan] ([Code])

ALTER TABLE [dbo].[Define_Part] CHECK CONSTRAINT [FK_Define_Part_Define_Ostan]

ALTER TABLE [dbo].[Define_People]  WITH CHECK ADD  CONSTRAINT [FK_Define_People_Define_City] FOREIGN KEY([IdCity])
REFERENCES [dbo].[Define_City] ([Code])

ALTER TABLE [dbo].[Define_People] CHECK CONSTRAINT [FK_Define_People_Define_City]

ALTER TABLE [dbo].[Define_People]  WITH CHECK ADD  CONSTRAINT [FK_Define_People_Define_Group_P] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Define_Group_P] ([Id])

ALTER TABLE [dbo].[Define_People] CHECK CONSTRAINT [FK_Define_People_Define_Group_P]

ALTER TABLE [dbo].[Define_People]  WITH CHECK ADD  CONSTRAINT [FK_Define_People_Define_Ostan] FOREIGN KEY([IdOstan])
REFERENCES [dbo].[Define_Ostan] ([Code])

ALTER TABLE [dbo].[Define_People] CHECK CONSTRAINT [FK_Define_People_Define_Ostan]

ALTER TABLE [dbo].[Define_People]  WITH CHECK ADD  CONSTRAINT [FK_Define_People_Define_Part] FOREIGN KEY([IdPart])
REFERENCES [dbo].[Define_Part] ([Code])

ALTER TABLE [dbo].[Define_People] CHECK CONSTRAINT [FK_Define_People_Define_Part]

ALTER TABLE [dbo].[Define_PrimaryKala]  WITH CHECK ADD  CONSTRAINT [FK_Define_PrimaryKala_Define_Anbar] FOREIGN KEY([IdAnbar])
REFERENCES [dbo].[Define_Anbar] ([ID])

ALTER TABLE [dbo].[Define_PrimaryKala] CHECK CONSTRAINT [FK_Define_PrimaryKala_Define_Anbar]

ALTER TABLE [dbo].[Define_PrimaryKala]  WITH CHECK ADD  CONSTRAINT [FK_Define_PrimaryKala_Define_Kala] FOREIGN KEY([IdKala])
REFERENCES [dbo].[Define_Kala] ([Id])

ALTER TABLE [dbo].[Define_PrimaryKala] CHECK CONSTRAINT [FK_Define_PrimaryKala_Define_Kala]

ALTER TABLE [dbo].[Define_PrimaryKala]  WITH CHECK ADD  CONSTRAINT [FK_Define_PrimaryKala_Define_User] FOREIGN KEY([Iduser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Define_PrimaryKala] CHECK CONSTRAINT [FK_Define_PrimaryKala_Define_User]

ALTER TABLE [dbo].[Define_SarFasl]  WITH CHECK ADD  CONSTRAINT [FK_Define_SarFasl_Define_OneSarFasl] FOREIGN KEY([IdOne])
REFERENCES [dbo].[Define_OneSarFasl] ([Id])

ALTER TABLE [dbo].[Define_SarFasl] CHECK CONSTRAINT [FK_Define_SarFasl_Define_OneSarFasl]

ALTER TABLE [dbo].[Define_Sarmayeh]  WITH CHECK ADD  CONSTRAINT [FK_Define_Sarmaeh_Define_OneSarmayeh] FOREIGN KEY([IdOne])
REFERENCES [dbo].[Define_OneSarmayeh] ([Id])

ALTER TABLE [dbo].[Define_Sarmayeh] CHECK CONSTRAINT [FK_Define_Sarmaeh_Define_OneSarmayeh]

ALTER TABLE [dbo].[Define_TwoGroup]  WITH CHECK ADD  CONSTRAINT [FK_Define_TwoGroup_Define_OneGroup] FOREIGN KEY([IdOne])
REFERENCES [dbo].[Define_OneGroup] ([Id])

ALTER TABLE [dbo].[Define_TwoGroup] CHECK CONSTRAINT [FK_Define_TwoGroup_Define_OneGroup]

ALTER TABLE [dbo].[Define_UserRP]  WITH CHECK ADD  CONSTRAINT [FK_Define_UserRP_Define_People1] FOREIGN KEY([IDP])
REFERENCES [dbo].[Define_People] ([ID])

ALTER TABLE [dbo].[Define_UserRP] CHECK CONSTRAINT [FK_Define_UserRP_Define_People1]

ALTER TABLE [dbo].[Define_UserRP]  WITH CHECK ADD  CONSTRAINT [FK_Define_UserRP_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Define_UserRP] CHECK CONSTRAINT [FK_Define_UserRP_Define_User]

ALTER TABLE [dbo].[Define_UserRP]  WITH CHECK ADD  CONSTRAINT [FK_Define_UserRP_Define_UserR] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_UserR] ([IdUser])

ALTER TABLE [dbo].[Define_UserRP] CHECK CONSTRAINT [FK_Define_UserRP_Define_UserR]

ALTER TABLE [dbo].[Define_UserRPAnbar]  WITH CHECK ADD  CONSTRAINT [FK_Define_UserRPAnbar_Define_Anbar] FOREIGN KEY([IDA])
REFERENCES [dbo].[Define_Anbar] ([ID])

ALTER TABLE [dbo].[Define_UserRPAnbar] CHECK CONSTRAINT [FK_Define_UserRPAnbar_Define_Anbar]

ALTER TABLE [dbo].[Define_UserRPAnbar]  WITH CHECK ADD  CONSTRAINT [FK_Define_UserRPAnbar_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Define_UserRPAnbar] CHECK CONSTRAINT [FK_Define_UserRPAnbar_Define_User]

ALTER TABLE [dbo].[Define_UserRPAnbar]  WITH CHECK ADD  CONSTRAINT [FK_Define_UserRPAnbar_Define_UserRAnbar] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_UserRAnbar] ([IdUser])

ALTER TABLE [dbo].[Define_UserRPAnbar] CHECK CONSTRAINT [FK_Define_UserRPAnbar_Define_UserRAnbar]

ALTER TABLE [dbo].[Define_UserRPBox]  WITH CHECK ADD  CONSTRAINT [FK_Define_UserRPBox_Define_Box] FOREIGN KEY([IDB])
REFERENCES [dbo].[Define_Box] ([ID])

ALTER TABLE [dbo].[Define_UserRPBox] CHECK CONSTRAINT [FK_Define_UserRPBox_Define_Box]

ALTER TABLE [dbo].[Define_UserRPBox]  WITH CHECK ADD  CONSTRAINT [FK_Define_UserRPBox_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Define_UserRPBox] CHECK CONSTRAINT [FK_Define_UserRPBox_Define_User]

ALTER TABLE [dbo].[Define_UserRPBox]  WITH CHECK ADD  CONSTRAINT [FK_Define_UserRPBox_Define_UserRBox] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_UserRBox] ([IdUser])

ALTER TABLE [dbo].[Define_UserRPBox] CHECK CONSTRAINT [FK_Define_UserRPBox_Define_UserRBox]

ALTER TABLE [dbo].[Define_VisitorRP]  WITH CHECK ADD  CONSTRAINT [FK_Define_VisitorRP_Define_People1] FOREIGN KEY([IDP])
REFERENCES [dbo].[Define_People] ([ID])

ALTER TABLE [dbo].[Define_VisitorRP] CHECK CONSTRAINT [FK_Define_VisitorRP_Define_People1]

ALTER TABLE [dbo].[Define_VisitorRP]  WITH CHECK ADD  CONSTRAINT [FK_Define_VisitorRP_Define_Visitor] FOREIGN KEY([IdVisitor])
REFERENCES [dbo].[Define_Visitor] ([Id])

ALTER TABLE [dbo].[Define_VisitorRP] CHECK CONSTRAINT [FK_Define_VisitorRP_Define_Visitor]

ALTER TABLE [dbo].[Define_VisitorRP]  WITH CHECK ADD  CONSTRAINT [FK_Define_VisitorRP_Define_VisitorR] FOREIGN KEY([IdVisitor])
REFERENCES [dbo].[Define_VisitorR] ([IdVisitor])

ALTER TABLE [dbo].[Define_VisitorRP] CHECK CONSTRAINT [FK_Define_VisitorRP_Define_VisitorR]

ALTER TABLE [dbo].[DefineListPromotion]  WITH CHECK ADD  CONSTRAINT [FK_DefineListPromotion_DefinePromotion] FOREIGN KEY([IdLink])
REFERENCES [dbo].[DefinePromotion] ([Id])
ON DELETE CASCADE

ALTER TABLE [dbo].[DefineListPromotion] CHECK CONSTRAINT [FK_DefineListPromotion_DefinePromotion]

ALTER TABLE [dbo].[DefinePromotion]  WITH CHECK ADD  CONSTRAINT [FK_DefinePromotion_Define_Group_P] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Define_Group_P] ([Id])

ALTER TABLE [dbo].[DefinePromotion] CHECK CONSTRAINT [FK_DefinePromotion_Define_Group_P]

ALTER TABLE [dbo].[DefinePromotion]  WITH CHECK ADD  CONSTRAINT [FK_DefinePromotion_Define_Kala] FOREIGN KEY([IdKala])
REFERENCES [dbo].[Define_Kala] ([Id])

ALTER TABLE [dbo].[DefinePromotion] CHECK CONSTRAINT [FK_DefinePromotion_Define_Kala]

ALTER TABLE [dbo].[ExitFactor]  WITH CHECK ADD  CONSTRAINT [FK_ExitFactor_Define_Car] FOREIGN KEY([IdCar])
REFERENCES [dbo].[Define_Car] ([Id])

ALTER TABLE [dbo].[ExitFactor] CHECK CONSTRAINT [FK_ExitFactor_Define_Car]

ALTER TABLE [dbo].[ExitFactor]  WITH CHECK ADD  CONSTRAINT [FK_ExitFactor_Define_Driver] FOREIGN KEY([IdDriver])
REFERENCES [dbo].[Define_Driver] ([Id])

ALTER TABLE [dbo].[ExitFactor] CHECK CONSTRAINT [FK_ExitFactor_Define_Driver]

ALTER TABLE [dbo].[ExitFactor]  WITH CHECK ADD  CONSTRAINT [FK_ExitFactor_Define_Reciver] FOREIGN KEY([IdRecive])
REFERENCES [dbo].[Define_Reciver] ([Id])

ALTER TABLE [dbo].[ExitFactor] CHECK CONSTRAINT [FK_ExitFactor_Define_Reciver]

ALTER TABLE [dbo].[ExitFactor]  WITH CHECK ADD  CONSTRAINT [FK_ExitFactor_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[ExitFactor] CHECK CONSTRAINT [FK_ExitFactor_Define_User]

ALTER TABLE [dbo].[Get_Daramad]  WITH CHECK ADD  CONSTRAINT [FK_Get_Daramad_Define_Bank] FOREIGN KEY([IdBankHavaleh])
REFERENCES [dbo].[Define_Bank] ([ID])

ALTER TABLE [dbo].[Get_Daramad] CHECK CONSTRAINT [FK_Get_Daramad_Define_Bank]

ALTER TABLE [dbo].[Get_Daramad]  WITH CHECK ADD  CONSTRAINT [FK_Get_Daramad_Define_Box] FOREIGN KEY([IdBox])
REFERENCES [dbo].[Define_Box] ([ID])

ALTER TABLE [dbo].[Get_Daramad] CHECK CONSTRAINT [FK_Get_Daramad_Define_Box]

ALTER TABLE [dbo].[Get_Daramad]  WITH CHECK ADD  CONSTRAINT [FK_Get_Daramad_Define_Daramad] FOREIGN KEY([IdDaramad])
REFERENCES [dbo].[Define_Daramad] ([ID])

ALTER TABLE [dbo].[Get_Daramad] CHECK CONSTRAINT [FK_Get_Daramad_Define_Daramad]

ALTER TABLE [dbo].[Get_Daramad]  WITH CHECK ADD  CONSTRAINT [FK_Get_Daramad_Define_People] FOREIGN KEY([Idname])
REFERENCES [dbo].[Define_People] ([ID])

ALTER TABLE [dbo].[Get_Daramad] CHECK CONSTRAINT [FK_Get_Daramad_Define_People]

ALTER TABLE [dbo].[Get_Daramad]  WITH CHECK ADD  CONSTRAINT [FK_Get_Daramad_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Get_Daramad] CHECK CONSTRAINT [FK_Get_Daramad_Define_User]

ALTER TABLE [dbo].[Get_Daramad]  WITH CHECK ADD  CONSTRAINT [FK_Get_Daramad_Moein_Bank1] FOREIGN KEY([IdBankMoein])
REFERENCES [dbo].[Moein_Bank] ([Id])

ALTER TABLE [dbo].[Get_Daramad] CHECK CONSTRAINT [FK_Get_Daramad_Moein_Bank1]

ALTER TABLE [dbo].[Get_Daramad]  WITH CHECK ADD  CONSTRAINT [FK_Get_Daramad_Moein_Box1] FOREIGN KEY([IdBoxMoein])
REFERENCES [dbo].[Moein_Box] ([Id])

ALTER TABLE [dbo].[Get_Daramad] CHECK CONSTRAINT [FK_Get_Daramad_Moein_Box1]

ALTER TABLE [dbo].[Get_Daramad]  WITH CHECK ADD  CONSTRAINT [FK_Get_Daramad_Moein_People] FOREIGN KEY([IdSanadLend])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[Get_Daramad] CHECK CONSTRAINT [FK_Get_Daramad_Moein_People]

ALTER TABLE [dbo].[Get_Pay_Amval]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Amval_Define_Amval] FOREIGN KEY([IdAmval])
REFERENCES [dbo].[Define_Amval] ([ID])

ALTER TABLE [dbo].[Get_Pay_Amval] CHECK CONSTRAINT [FK_Get_Pay_Amval_Define_Amval]

ALTER TABLE [dbo].[Get_Pay_Amval]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Amval_Define_Bank] FOREIGN KEY([IdBankHavaleh])
REFERENCES [dbo].[Define_Bank] ([ID])

ALTER TABLE [dbo].[Get_Pay_Amval] CHECK CONSTRAINT [FK_Get_Pay_Amval_Define_Bank]

ALTER TABLE [dbo].[Get_Pay_Amval]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Amval_Define_Box] FOREIGN KEY([IdBox])
REFERENCES [dbo].[Define_Box] ([ID])

ALTER TABLE [dbo].[Get_Pay_Amval] CHECK CONSTRAINT [FK_Get_Pay_Amval_Define_Box]

ALTER TABLE [dbo].[Get_Pay_Amval]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Amval_Define_Charge] FOREIGN KEY([LendCharge])
REFERENCES [dbo].[Define_Charge] ([ID])

ALTER TABLE [dbo].[Get_Pay_Amval] CHECK CONSTRAINT [FK_Get_Pay_Amval_Define_Charge]

ALTER TABLE [dbo].[Get_Pay_Amval]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Amval_Define_People] FOREIGN KEY([LendP])
REFERENCES [dbo].[Define_People] ([ID])

ALTER TABLE [dbo].[Get_Pay_Amval] CHECK CONSTRAINT [FK_Get_Pay_Amval_Define_People]

ALTER TABLE [dbo].[Get_Pay_Amval]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Amval_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Get_Pay_Amval] CHECK CONSTRAINT [FK_Get_Pay_Amval_Define_User]

ALTER TABLE [dbo].[Get_Pay_Amval]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Amval_Moein_Box] FOREIGN KEY([IdBoxMoein])
REFERENCES [dbo].[Moein_Box] ([Id])

ALTER TABLE [dbo].[Get_Pay_Amval] CHECK CONSTRAINT [FK_Get_Pay_Amval_Moein_Box]

ALTER TABLE [dbo].[Get_Pay_Amval]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Amval_Moein_People] FOREIGN KEY([IdSanadLendP])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[Get_Pay_Amval] CHECK CONSTRAINT [FK_Get_Pay_Amval_Moein_People]

ALTER TABLE [dbo].[Get_Pay_Sanad]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Sanad_Define_Bank] FOREIGN KEY([IdBankHavaleh])
REFERENCES [dbo].[Define_Bank] ([ID])

ALTER TABLE [dbo].[Get_Pay_Sanad] CHECK CONSTRAINT [FK_Get_Pay_Sanad_Define_Bank]

ALTER TABLE [dbo].[Get_Pay_Sanad]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Sanad_Define_Box] FOREIGN KEY([IdBox])
REFERENCES [dbo].[Define_Box] ([ID])

ALTER TABLE [dbo].[Get_Pay_Sanad] CHECK CONSTRAINT [FK_Get_Pay_Sanad_Define_Box]

ALTER TABLE [dbo].[Get_Pay_Sanad]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Sanad_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Get_Pay_Sanad] CHECK CONSTRAINT [FK_Get_Pay_Sanad_Define_User]

ALTER TABLE [dbo].[Get_Pay_Sanad]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Sanad_Moein_Bank1] FOREIGN KEY([IdBankMoein])
REFERENCES [dbo].[Moein_Bank] ([Id])

ALTER TABLE [dbo].[Get_Pay_Sanad] CHECK CONSTRAINT [FK_Get_Pay_Sanad_Moein_Bank1]

ALTER TABLE [dbo].[Get_Pay_Sanad]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Sanad_Moein_Box] FOREIGN KEY([IdBoxMoein])
REFERENCES [dbo].[Moein_Box] ([Id])

ALTER TABLE [dbo].[Get_Pay_Sanad] CHECK CONSTRAINT [FK_Get_Pay_Sanad_Moein_Box]

ALTER TABLE [dbo].[Get_Pay_Sanad]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Sanad_Moein_People5] FOREIGN KEY([IdSanadCash])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[Get_Pay_Sanad] CHECK CONSTRAINT [FK_Get_Pay_Sanad_Moein_People5]

ALTER TABLE [dbo].[Get_Pay_Sanad]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Sanad_Moein_People6] FOREIGN KEY([IdSanadChk])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[Get_Pay_Sanad] CHECK CONSTRAINT [FK_Get_Pay_Sanad_Moein_People6]

ALTER TABLE [dbo].[Get_Pay_Sanad]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Sanad_Moein_People7] FOREIGN KEY([IdSanadHavaleh])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[Get_Pay_Sanad] CHECK CONSTRAINT [FK_Get_Pay_Sanad_Moein_People7]

ALTER TABLE [dbo].[Get_Pay_Sanad]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Sanad_Moein_People8] FOREIGN KEY([IdSanadDiscount])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[Get_Pay_Sanad] CHECK CONSTRAINT [FK_Get_Pay_Sanad_Moein_People8]

ALTER TABLE [dbo].[Get_Pay_Sarmayeh]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Sarmayeh_Define_Bank] FOREIGN KEY([IdBankHavaleh])
REFERENCES [dbo].[Define_Bank] ([ID])

ALTER TABLE [dbo].[Get_Pay_Sarmayeh] CHECK CONSTRAINT [FK_Get_Pay_Sarmayeh_Define_Bank]

ALTER TABLE [dbo].[Get_Pay_Sarmayeh]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Sarmayeh_Define_Box] FOREIGN KEY([IdBox])
REFERENCES [dbo].[Define_Box] ([ID])

ALTER TABLE [dbo].[Get_Pay_Sarmayeh] CHECK CONSTRAINT [FK_Get_Pay_Sarmayeh_Define_Box]

ALTER TABLE [dbo].[Get_Pay_Sarmayeh]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Sarmayeh_Define_Charge] FOREIGN KEY([LendCharge])
REFERENCES [dbo].[Define_Charge] ([ID])

ALTER TABLE [dbo].[Get_Pay_Sarmayeh] CHECK CONSTRAINT [FK_Get_Pay_Sarmayeh_Define_Charge]

ALTER TABLE [dbo].[Get_Pay_Sarmayeh]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Sarmayeh_Define_People] FOREIGN KEY([LendP])
REFERENCES [dbo].[Define_People] ([ID])

ALTER TABLE [dbo].[Get_Pay_Sarmayeh] CHECK CONSTRAINT [FK_Get_Pay_Sarmayeh_Define_People]

ALTER TABLE [dbo].[Get_Pay_Sarmayeh]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Sarmayeh_Define_Sarmayeh] FOREIGN KEY([IdSarmayeh])
REFERENCES [dbo].[Define_Sarmayeh] ([ID])

ALTER TABLE [dbo].[Get_Pay_Sarmayeh] CHECK CONSTRAINT [FK_Get_Pay_Sarmayeh_Define_Sarmayeh]

ALTER TABLE [dbo].[Get_Pay_Sarmayeh]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Sarmayeh_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Get_Pay_Sarmayeh] CHECK CONSTRAINT [FK_Get_Pay_Sarmayeh_Define_User]

ALTER TABLE [dbo].[Get_Pay_Sarmayeh]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Sarmayeh_Moein_Bank] FOREIGN KEY([IdBankMoein])
REFERENCES [dbo].[Moein_Bank] ([Id])

ALTER TABLE [dbo].[Get_Pay_Sarmayeh] CHECK CONSTRAINT [FK_Get_Pay_Sarmayeh_Moein_Bank]

ALTER TABLE [dbo].[Get_Pay_Sarmayeh]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Sarmayeh_Moein_Box] FOREIGN KEY([IdBoxMoein])
REFERENCES [dbo].[Moein_Box] ([Id])

ALTER TABLE [dbo].[Get_Pay_Sarmayeh] CHECK CONSTRAINT [FK_Get_Pay_Sarmayeh_Moein_Box]

ALTER TABLE [dbo].[Get_Pay_Sarmayeh]  WITH CHECK ADD  CONSTRAINT [FK_Get_Pay_Sarmayeh_Moein_People] FOREIGN KEY([IdSanadLendP])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[Get_Pay_Sarmayeh] CHECK CONSTRAINT [FK_Get_Pay_Sarmayeh_Moein_People]

ALTER TABLE [dbo].[GetMonQst]  WITH CHECK ADD  CONSTRAINT [FK_GetMonQst_Get_Pay_Sanad] FOREIGN KEY([IdSanad])
REFERENCES [dbo].[Get_Pay_Sanad] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[GetMonQst] CHECK CONSTRAINT [FK_GetMonQst_Get_Pay_Sanad]

ALTER TABLE [dbo].[GetMonQst]  WITH CHECK ADD  CONSTRAINT [FK_GetMonQst_GetQstList] FOREIGN KEY([Id])
REFERENCES [dbo].[GetQstList] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[GetMonQst] CHECK CONSTRAINT [FK_GetMonQst_GetQstList]

ALTER TABLE [dbo].[GetQstList]  WITH CHECK ADD  CONSTRAINT [FK_GetQstList_GetQst] FOREIGN KEY([Link])
REFERENCES [dbo].[GetQst] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[GetQstList] CHECK CONSTRAINT [FK_GetQstList_GetQst]

ALTER TABLE [dbo].[Kala_Discount]  WITH CHECK ADD  CONSTRAINT [FK_Kala_Discount_Define_Kala] FOREIGN KEY([Idkala])
REFERENCES [dbo].[Define_Kala] ([Id])

ALTER TABLE [dbo].[Kala_Discount] CHECK CONSTRAINT [FK_Kala_Discount_Define_Kala]

ALTER TABLE [dbo].[Kala_Discount]  WITH CHECK ADD  CONSTRAINT [FK_Kala_Discount_Define_Service] FOREIGN KEY([IdService])
REFERENCES [dbo].[Define_Service] ([ID])

ALTER TABLE [dbo].[Kala_Discount] CHECK CONSTRAINT [FK_Kala_Discount_Define_Service]

ALTER TABLE [dbo].[Kala_Discount]  WITH CHECK ADD  CONSTRAINT [FK_Kala_Discount_ListKala_Discount] FOREIGN KEY([IdKalaLink])
REFERENCES [dbo].[ListKala_Discount] ([Idkala])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[Kala_Discount] CHECK CONSTRAINT [FK_Kala_Discount_ListKala_Discount]

ALTER TABLE [dbo].[KalaFactorBackBuy]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorBackBuy_Define_Anbar] FOREIGN KEY([IdAnbar])
REFERENCES [dbo].[Define_Anbar] ([ID])

ALTER TABLE [dbo].[KalaFactorBackBuy] CHECK CONSTRAINT [FK_KalaFactorBackBuy_Define_Anbar]

ALTER TABLE [dbo].[KalaFactorBackBuy]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorBackBuy_Define_Kala] FOREIGN KEY([IdKala])
REFERENCES [dbo].[Define_Kala] ([Id])

ALTER TABLE [dbo].[KalaFactorBackBuy] CHECK CONSTRAINT [FK_KalaFactorBackBuy_Define_Kala]

ALTER TABLE [dbo].[KalaFactorBackBuy]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorBackBuy_Define_Service] FOREIGN KEY([IdService])
REFERENCES [dbo].[Define_Service] ([ID])

ALTER TABLE [dbo].[KalaFactorBackBuy] CHECK CONSTRAINT [FK_KalaFactorBackBuy_Define_Service]

ALTER TABLE [dbo].[KalaFactorBackBuy]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorBackBuy_ListFactorBackBuy] FOREIGN KEY([IdFactor])
REFERENCES [dbo].[ListFactorBackBuy] ([IdFactor])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[KalaFactorBackBuy] CHECK CONSTRAINT [FK_KalaFactorBackBuy_ListFactorBackBuy]

ALTER TABLE [dbo].[KalaFactorBackSell]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorBackSell_Define_Anbar] FOREIGN KEY([IdAnbar])
REFERENCES [dbo].[Define_Anbar] ([ID])

ALTER TABLE [dbo].[KalaFactorBackSell] CHECK CONSTRAINT [FK_KalaFactorBackSell_Define_Anbar]

ALTER TABLE [dbo].[KalaFactorBackSell]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorBackSell_Define_Kala] FOREIGN KEY([IdKala])
REFERENCES [dbo].[Define_Kala] ([Id])

ALTER TABLE [dbo].[KalaFactorBackSell] CHECK CONSTRAINT [FK_KalaFactorBackSell_Define_Kala]

ALTER TABLE [dbo].[KalaFactorBackSell]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorBackSell_Define_Service] FOREIGN KEY([IdService])
REFERENCES [dbo].[Define_Service] ([ID])

ALTER TABLE [dbo].[KalaFactorBackSell] CHECK CONSTRAINT [FK_KalaFactorBackSell_Define_Service]

ALTER TABLE [dbo].[KalaFactorBackSell]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorBackSell_ListFactorBackSell] FOREIGN KEY([IdFactor])
REFERENCES [dbo].[ListFactorBackSell] ([IdFactor])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[KalaFactorBackSell] CHECK CONSTRAINT [FK_KalaFactorBackSell_ListFactorBackSell]

ALTER TABLE [dbo].[KalaFactorBuy]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorBuy_Define_Anbar] FOREIGN KEY([IdAnbar])
REFERENCES [dbo].[Define_Anbar] ([ID])

ALTER TABLE [dbo].[KalaFactorBuy] CHECK CONSTRAINT [FK_KalaFactorBuy_Define_Anbar]

ALTER TABLE [dbo].[KalaFactorBuy]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorBuy_Define_Kala] FOREIGN KEY([IdKala])
REFERENCES [dbo].[Define_Kala] ([Id])

ALTER TABLE [dbo].[KalaFactorBuy] CHECK CONSTRAINT [FK_KalaFactorBuy_Define_Kala]

ALTER TABLE [dbo].[KalaFactorBuy]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorBuy_Define_Service] FOREIGN KEY([IdService])
REFERENCES [dbo].[Define_Service] ([ID])

ALTER TABLE [dbo].[KalaFactorBuy] CHECK CONSTRAINT [FK_KalaFactorBuy_Define_Service]

ALTER TABLE [dbo].[KalaFactorBuy]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorBuy_ListFactorBuy] FOREIGN KEY([IdFactor])
REFERENCES [dbo].[ListFactorBuy] ([IdFactor])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[KalaFactorBuy] CHECK CONSTRAINT [FK_KalaFactorBuy_ListFactorBuy]

ALTER TABLE [dbo].[KalaFactorCharge]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorCharge_Define_Charge] FOREIGN KEY([IdCharge])
REFERENCES [dbo].[Define_Charge] ([ID])

ALTER TABLE [dbo].[KalaFactorCharge] CHECK CONSTRAINT [FK_KalaFactorCharge_Define_Charge]

ALTER TABLE [dbo].[KalaFactorCharge]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorCharge_ListFactorCharge] FOREIGN KEY([IdSanad])
REFERENCES [dbo].[ListFactorCharge] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[KalaFactorCharge] CHECK CONSTRAINT [FK_KalaFactorCharge_ListFactorCharge]

ALTER TABLE [dbo].[KalaFactorDamage]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorDamage_Define_Anbar] FOREIGN KEY([IdAnbar])
REFERENCES [dbo].[Define_Anbar] ([ID])

ALTER TABLE [dbo].[KalaFactorDamage] CHECK CONSTRAINT [FK_KalaFactorDamage_Define_Anbar]

ALTER TABLE [dbo].[KalaFactorDamage]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorDamage_Define_Kala] FOREIGN KEY([IdKala])
REFERENCES [dbo].[Define_Kala] ([Id])

ALTER TABLE [dbo].[KalaFactorDamage] CHECK CONSTRAINT [FK_KalaFactorDamage_Define_Kala]

ALTER TABLE [dbo].[KalaFactorDamage]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorDamage_ListFactorDamage] FOREIGN KEY([IdFactor])
REFERENCES [dbo].[ListFactorDamage] ([IdFactor])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[KalaFactorDamage] CHECK CONSTRAINT [FK_KalaFactorDamage_ListFactorDamage]

ALTER TABLE [dbo].[KalaFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorSell_Define_Anbar] FOREIGN KEY([IdAnbar])
REFERENCES [dbo].[Define_Anbar] ([ID])

ALTER TABLE [dbo].[KalaFactorSell] CHECK CONSTRAINT [FK_KalaFactorSell_Define_Anbar]

ALTER TABLE [dbo].[KalaFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorSell_Define_Kala] FOREIGN KEY([IdKala])
REFERENCES [dbo].[Define_Kala] ([Id])

ALTER TABLE [dbo].[KalaFactorSell] CHECK CONSTRAINT [FK_KalaFactorSell_Define_Kala]

ALTER TABLE [dbo].[KalaFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorSell_Define_Service] FOREIGN KEY([IdService])
REFERENCES [dbo].[Define_Service] ([ID])

ALTER TABLE [dbo].[KalaFactorSell] CHECK CONSTRAINT [FK_KalaFactorSell_Define_Service]

ALTER TABLE [dbo].[KalaFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorSell_ListFactorSell] FOREIGN KEY([IdFactor])
REFERENCES [dbo].[ListFactorSell] ([IdFactor])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[KalaFactorSell] CHECK CONSTRAINT [FK_KalaFactorSell_ListFactorSell]

ALTER TABLE [dbo].[KalaFactorService]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorService_Define_Service] FOREIGN KEY([IdService])
REFERENCES [dbo].[Define_Service] ([ID])

ALTER TABLE [dbo].[KalaFactorService] CHECK CONSTRAINT [FK_KalaFactorService_Define_Service]

ALTER TABLE [dbo].[KalaFactorService]  WITH CHECK ADD  CONSTRAINT [FK_KalaFactorService_ListFactorService] FOREIGN KEY([IdFactor])
REFERENCES [dbo].[ListFactorService] ([IdFactor])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[KalaFactorService] CHECK CONSTRAINT [FK_KalaFactorService_ListFactorService]

ALTER TABLE [dbo].[KalaKasriFactor]  WITH CHECK ADD  CONSTRAINT [FK_KalaKasriFactor_Define_Kala] FOREIGN KEY([IdR])
REFERENCES [dbo].[Define_Kala] ([Id])

ALTER TABLE [dbo].[KalaKasriFactor] CHECK CONSTRAINT [FK_KalaKasriFactor_Define_Kala]

ALTER TABLE [dbo].[KalaKasriFactor]  WITH CHECK ADD  CONSTRAINT [FK_KalaKasriFactor_ListKasriFactor] FOREIGN KEY([IdFactor])
REFERENCES [dbo].[ListKasriFactor] ([IdFactor])
ON DELETE CASCADE

ALTER TABLE [dbo].[KalaKasriFactor] CHECK CONSTRAINT [FK_KalaKasriFactor_ListKasriFactor]

ALTER TABLE [dbo].[KalaOtherCharge]  WITH CHECK ADD  CONSTRAINT [FK_KalaOtherCharge_Define_Charge] FOREIGN KEY([IdCharge])
REFERENCES [dbo].[Define_Charge] ([ID])

ALTER TABLE [dbo].[KalaOtherCharge] CHECK CONSTRAINT [FK_KalaOtherCharge_Define_Charge]

ALTER TABLE [dbo].[KalaOtherCharge]  WITH CHECK ADD  CONSTRAINT [FK_KalaOtherCharge_ListOtherCharge] FOREIGN KEY([IdSanad])
REFERENCES [dbo].[ListOtherCharge] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[KalaOtherCharge] CHECK CONSTRAINT [FK_KalaOtherCharge_ListOtherCharge]

ALTER TABLE [dbo].[Lasheh_Chk]  WITH CHECK ADD  CONSTRAINT [FK_Lasheh_Chk_Define_Chk] FOREIGN KEY([Id])
REFERENCES [dbo].[Define_Chk] ([Aid])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[Lasheh_Chk] CHECK CONSTRAINT [FK_Lasheh_Chk_Define_Chk]

ALTER TABLE [dbo].[ListDarsad]  WITH CHECK ADD  CONSTRAINT [FK_ListDarsad_Define_Group_P] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Define_Group_P] ([Id])

ALTER TABLE [dbo].[ListDarsad] CHECK CONSTRAINT [FK_ListDarsad_Define_Group_P]

ALTER TABLE [dbo].[ListDarsad]  WITH CHECK ADD  CONSTRAINT [FK_ListDarsad_Listkala] FOREIGN KEY([IdlinkKala])
REFERENCES [dbo].[Listkala] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[ListDarsad] CHECK CONSTRAINT [FK_ListDarsad_Listkala]

ALTER TABLE [dbo].[ListDarsad_G]  WITH CHECK ADD  CONSTRAINT [FK_ListDarsad_G_Define_Group_P] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Define_Group_P] ([Id])

ALTER TABLE [dbo].[ListDarsad_G] CHECK CONSTRAINT [FK_ListDarsad_G_Define_Group_P]

ALTER TABLE [dbo].[ListDarsad_G]  WITH CHECK ADD  CONSTRAINT [FK_ListDarsad_G_Listkala_G] FOREIGN KEY([IdlinkKala])
REFERENCES [dbo].[Listkala_G] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[ListDarsad_G] CHECK CONSTRAINT [FK_ListDarsad_G_Listkala_G]

ALTER TABLE [dbo].[ListDarsad_OG]  WITH CHECK ADD  CONSTRAINT [FK_ListDarsad_OG_Define_Group_P] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Define_Group_P] ([Id])

ALTER TABLE [dbo].[ListDarsad_OG] CHECK CONSTRAINT [FK_ListDarsad_OG_Define_Group_P]

ALTER TABLE [dbo].[ListDarsad_OG]  WITH CHECK ADD  CONSTRAINT [FK_ListDarsad_OG_Listkala_OG] FOREIGN KEY([IdlinkKala])
REFERENCES [dbo].[Listkala_OG] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[ListDarsad_OG] CHECK CONSTRAINT [FK_ListDarsad_OG_Listkala_OG]

ALTER TABLE [dbo].[ListDarsadU]  WITH CHECK ADD  CONSTRAINT [FK_ListDarsadU_Define_Group_P] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Define_Group_P] ([Id])

ALTER TABLE [dbo].[ListDarsadU] CHECK CONSTRAINT [FK_ListDarsadU_Define_Group_P]

ALTER TABLE [dbo].[ListDarsadU]  WITH CHECK ADD  CONSTRAINT [FK_ListDarsadU_ListkalaU] FOREIGN KEY([IdlinkKala])
REFERENCES [dbo].[ListkalaU] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[ListDarsadU] CHECK CONSTRAINT [FK_ListDarsadU_ListkalaU]

ALTER TABLE [dbo].[ListDarsadU_G]  WITH CHECK ADD  CONSTRAINT [FK_ListDarsadU_G_Define_Group_P] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Define_Group_P] ([Id])

ALTER TABLE [dbo].[ListDarsadU_G] CHECK CONSTRAINT [FK_ListDarsadU_G_Define_Group_P]

ALTER TABLE [dbo].[ListDarsadU_G]  WITH CHECK ADD  CONSTRAINT [FK_ListDarsadU_G_ListkalaU_G] FOREIGN KEY([IdlinkKala])
REFERENCES [dbo].[ListkalaU_G] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[ListDarsadU_G] CHECK CONSTRAINT [FK_ListDarsadU_G_ListkalaU_G]

ALTER TABLE [dbo].[ListDarsadU_OG]  WITH CHECK ADD  CONSTRAINT [FK_ListDarsadU_OG_Define_Group_P] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Define_Group_P] ([Id])

ALTER TABLE [dbo].[ListDarsadU_OG] CHECK CONSTRAINT [FK_ListDarsadU_OG_Define_Group_P]

ALTER TABLE [dbo].[ListDarsadU_OG]  WITH CHECK ADD  CONSTRAINT [FK_ListDarsadU_OG_ListkalaU_OG] FOREIGN KEY([IdlinkKala])
REFERENCES [dbo].[ListkalaU_OG] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[ListDarsadU_OG] CHECK CONSTRAINT [FK_ListDarsadU_OG_ListkalaU_OG]

ALTER TABLE [dbo].[ListEditMoein]  WITH CHECK ADD  CONSTRAINT [FK_ListEditMoein_Define_Charge] FOREIGN KEY([IdCharge])
REFERENCES [dbo].[Define_Charge] ([ID])

ALTER TABLE [dbo].[ListEditMoein] CHECK CONSTRAINT [FK_ListEditMoein_Define_Charge]

ALTER TABLE [dbo].[ListEditMoein]  WITH CHECK ADD  CONSTRAINT [FK_ListEditMoein_Define_Daramad] FOREIGN KEY([IdDaramad])
REFERENCES [dbo].[Define_Daramad] ([ID])

ALTER TABLE [dbo].[ListEditMoein] CHECK CONSTRAINT [FK_ListEditMoein_Define_Daramad]

ALTER TABLE [dbo].[ListEditMoein]  WITH CHECK ADD  CONSTRAINT [FK_ListEditMoein_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[ListEditMoein] CHECK CONSTRAINT [FK_ListEditMoein_Define_User]

ALTER TABLE [dbo].[ListEditMoein]  WITH CHECK ADD  CONSTRAINT [FK_ListEditMoein_Get_Daramad] FOREIGN KEY([IdSDaramad])
REFERENCES [dbo].[Get_Daramad] ([Id])

ALTER TABLE [dbo].[ListEditMoein] CHECK CONSTRAINT [FK_ListEditMoein_Get_Daramad]

ALTER TABLE [dbo].[ListEditMoein]  WITH CHECK ADD  CONSTRAINT [FK_ListEditMoein_ListOtherCharge] FOREIGN KEY([IdSCharge])
REFERENCES [dbo].[ListOtherCharge] ([Id])

ALTER TABLE [dbo].[ListEditMoein] CHECK CONSTRAINT [FK_ListEditMoein_ListOtherCharge]

ALTER TABLE [dbo].[ListEditPMoein]  WITH CHECK ADD  CONSTRAINT [FK_ListEditPMoein_Define_People] FOREIGN KEY([IdP])
REFERENCES [dbo].[Define_People] ([ID])

ALTER TABLE [dbo].[ListEditPMoein] CHECK CONSTRAINT [FK_ListEditPMoein_Define_People]

ALTER TABLE [dbo].[ListEditPMoein]  WITH CHECK ADD  CONSTRAINT [FK_ListEditPMoein_ListEditMoein] FOREIGN KEY([IdLink])
REFERENCES [dbo].[ListEditMoein] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[ListEditPMoein] CHECK CONSTRAINT [FK_ListEditPMoein_ListEditMoein]

ALTER TABLE [dbo].[ListEditPMoein]  WITH CHECK ADD  CONSTRAINT [FK_ListEditPMoein_Moein_People] FOREIGN KEY([IdMoein])
REFERENCES [dbo].[Moein_People] ([Id])
ON DELETE CASCADE

ALTER TABLE [dbo].[ListEditPMoein] CHECK CONSTRAINT [FK_ListEditPMoein_Moein_People]

ALTER TABLE [dbo].[ListExitFactor]  WITH CHECK ADD  CONSTRAINT [FK_ListExitFactor_ExitFactor] FOREIGN KEY([IdList])
REFERENCES [dbo].[ExitFactor] ([Id])
ON DELETE CASCADE

ALTER TABLE [dbo].[ListExitFactor] CHECK CONSTRAINT [FK_ListExitFactor_ExitFactor]

ALTER TABLE [dbo].[ListExitFactor]  WITH CHECK ADD  CONSTRAINT [FK_ListExitFactor_ListFactorSell] FOREIGN KEY([IdFactor])
REFERENCES [dbo].[ListFactorSell] ([IdFactor])

ALTER TABLE [dbo].[ListExitFactor] CHECK CONSTRAINT [FK_ListExitFactor_ListFactorSell]

ALTER TABLE [dbo].[ListFactorBackBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackBuy_Define_Bank] FOREIGN KEY([IdBankHavaleh])
REFERENCES [dbo].[Define_Bank] ([ID])

ALTER TABLE [dbo].[ListFactorBackBuy] CHECK CONSTRAINT [FK_ListFactorBackBuy_Define_Bank]

ALTER TABLE [dbo].[ListFactorBackBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackBuy_Define_PartKala] FOREIGN KEY([Part])
REFERENCES [dbo].[Define_PartKala] ([ID])

ALTER TABLE [dbo].[ListFactorBackBuy] CHECK CONSTRAINT [FK_ListFactorBackBuy_Define_PartKala]

ALTER TABLE [dbo].[ListFactorBackBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackBuy_Define_People] FOREIGN KEY([IdName])
REFERENCES [dbo].[Define_People] ([ID])

ALTER TABLE [dbo].[ListFactorBackBuy] CHECK CONSTRAINT [FK_ListFactorBackBuy_Define_People]

ALTER TABLE [dbo].[ListFactorBackBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackBuy_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[ListFactorBackBuy] CHECK CONSTRAINT [FK_ListFactorBackBuy_Define_User]

ALTER TABLE [dbo].[ListFactorBackBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackBuy_Define_Visitor] FOREIGN KEY([IdVisitor])
REFERENCES [dbo].[Define_Visitor] ([Id])

ALTER TABLE [dbo].[ListFactorBackBuy] CHECK CONSTRAINT [FK_ListFactorBackBuy_Define_Visitor]

ALTER TABLE [dbo].[ListFactorBackBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackBuy_Moein_Bank] FOREIGN KEY([IdBanK])
REFERENCES [dbo].[Moein_Bank] ([Id])

ALTER TABLE [dbo].[ListFactorBackBuy] CHECK CONSTRAINT [FK_ListFactorBackBuy_Moein_Bank]

ALTER TABLE [dbo].[ListFactorBackBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackBuy_Moein_Box] FOREIGN KEY([IdBox])
REFERENCES [dbo].[Moein_Box] ([Id])

ALTER TABLE [dbo].[ListFactorBackBuy] CHECK CONSTRAINT [FK_ListFactorBackBuy_Moein_Box]

ALTER TABLE [dbo].[ListFactorBackBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackBuy_Moein_People] FOREIGN KEY([IdSanadAdd])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBackBuy] CHECK CONSTRAINT [FK_ListFactorBackBuy_Moein_People]

ALTER TABLE [dbo].[ListFactorBackBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackBuy_Moein_People1] FOREIGN KEY([IdSanadDec])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBackBuy] CHECK CONSTRAINT [FK_ListFactorBackBuy_Moein_People1]

ALTER TABLE [dbo].[ListFactorBackBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackBuy_Moein_People2] FOREIGN KEY([IdSanadDiscountH])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBackBuy] CHECK CONSTRAINT [FK_ListFactorBackBuy_Moein_People2]

ALTER TABLE [dbo].[ListFactorBackBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackBuy_Moein_People3] FOREIGN KEY([IdSanadDiscountC])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBackBuy] CHECK CONSTRAINT [FK_ListFactorBackBuy_Moein_People3]

ALTER TABLE [dbo].[ListFactorBackBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackBuy_Moein_People4] FOREIGN KEY([IdSanadCash])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBackBuy] CHECK CONSTRAINT [FK_ListFactorBackBuy_Moein_People4]

ALTER TABLE [dbo].[ListFactorBackBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackBuy_Moein_People5] FOREIGN KEY([IdSanadChk])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBackBuy] CHECK CONSTRAINT [FK_ListFactorBackBuy_Moein_People5]

ALTER TABLE [dbo].[ListFactorBackBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackBuy_Moein_People6] FOREIGN KEY([IdSanadHavaleh])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBackBuy] CHECK CONSTRAINT [FK_ListFactorBackBuy_Moein_People6]

ALTER TABLE [dbo].[ListFactorBackBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackBuy_Moein_People7] FOREIGN KEY([IdSanadFactor])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBackBuy] CHECK CONSTRAINT [FK_ListFactorBackBuy_Moein_People7]

ALTER TABLE [dbo].[ListFactorBackSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackSell_Define_Bank] FOREIGN KEY([IdBankHavaleh])
REFERENCES [dbo].[Define_Bank] ([ID])

ALTER TABLE [dbo].[ListFactorBackSell] CHECK CONSTRAINT [FK_ListFactorBackSell_Define_Bank]

ALTER TABLE [dbo].[ListFactorBackSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackSell_Define_PartKala] FOREIGN KEY([Part])
REFERENCES [dbo].[Define_PartKala] ([ID])

ALTER TABLE [dbo].[ListFactorBackSell] CHECK CONSTRAINT [FK_ListFactorBackSell_Define_PartKala]

ALTER TABLE [dbo].[ListFactorBackSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackSell_Define_People] FOREIGN KEY([IdName])
REFERENCES [dbo].[Define_People] ([ID])

ALTER TABLE [dbo].[ListFactorBackSell] CHECK CONSTRAINT [FK_ListFactorBackSell_Define_People]

ALTER TABLE [dbo].[ListFactorBackSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackSell_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[ListFactorBackSell] CHECK CONSTRAINT [FK_ListFactorBackSell_Define_User]

ALTER TABLE [dbo].[ListFactorBackSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackSell_Define_Visitor] FOREIGN KEY([IdVisitor])
REFERENCES [dbo].[Define_Visitor] ([Id])

ALTER TABLE [dbo].[ListFactorBackSell] CHECK CONSTRAINT [FK_ListFactorBackSell_Define_Visitor]

ALTER TABLE [dbo].[ListFactorBackSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackSell_ListFactorSell] FOREIGN KEY([IdFacSell])
REFERENCES [dbo].[ListFactorSell] ([IdFactor])

ALTER TABLE [dbo].[ListFactorBackSell] CHECK CONSTRAINT [FK_ListFactorBackSell_ListFactorSell]

ALTER TABLE [dbo].[ListFactorBackSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackSell_Moein_Bank] FOREIGN KEY([IdBanK])
REFERENCES [dbo].[Moein_Bank] ([Id])

ALTER TABLE [dbo].[ListFactorBackSell] CHECK CONSTRAINT [FK_ListFactorBackSell_Moein_Bank]

ALTER TABLE [dbo].[ListFactorBackSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackSell_Moein_Box] FOREIGN KEY([IdBox])
REFERENCES [dbo].[Moein_Box] ([Id])

ALTER TABLE [dbo].[ListFactorBackSell] CHECK CONSTRAINT [FK_ListFactorBackSell_Moein_Box]

ALTER TABLE [dbo].[ListFactorBackSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackSell_Moein_People] FOREIGN KEY([IdSanadAdd])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBackSell] CHECK CONSTRAINT [FK_ListFactorBackSell_Moein_People]

ALTER TABLE [dbo].[ListFactorBackSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackSell_Moein_People1] FOREIGN KEY([IdSanadDec])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBackSell] CHECK CONSTRAINT [FK_ListFactorBackSell_Moein_People1]

ALTER TABLE [dbo].[ListFactorBackSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackSell_Moein_People2] FOREIGN KEY([IdSanadDiscountH])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBackSell] CHECK CONSTRAINT [FK_ListFactorBackSell_Moein_People2]

ALTER TABLE [dbo].[ListFactorBackSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackSell_Moein_People3] FOREIGN KEY([IdSanadDiscountC])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBackSell] CHECK CONSTRAINT [FK_ListFactorBackSell_Moein_People3]

ALTER TABLE [dbo].[ListFactorBackSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackSell_Moein_People4] FOREIGN KEY([IdSanadCash])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBackSell] CHECK CONSTRAINT [FK_ListFactorBackSell_Moein_People4]

ALTER TABLE [dbo].[ListFactorBackSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackSell_Moein_People5] FOREIGN KEY([IdSanadChk])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBackSell] CHECK CONSTRAINT [FK_ListFactorBackSell_Moein_People5]

ALTER TABLE [dbo].[ListFactorBackSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackSell_Moein_People6] FOREIGN KEY([IdSanadHavaleh])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBackSell] CHECK CONSTRAINT [FK_ListFactorBackSell_Moein_People6]

ALTER TABLE [dbo].[ListFactorBackSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBackSell_Moein_People7] FOREIGN KEY([IdSanadFactor])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBackSell] CHECK CONSTRAINT [FK_ListFactorBackSell_Moein_People7]

ALTER TABLE [dbo].[ListFactorBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBuy_Define_PartKala] FOREIGN KEY([Part])
REFERENCES [dbo].[Define_PartKala] ([ID])

ALTER TABLE [dbo].[ListFactorBuy] CHECK CONSTRAINT [FK_ListFactorBuy_Define_PartKala]

ALTER TABLE [dbo].[ListFactorBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBuy_Define_People] FOREIGN KEY([IdName])
REFERENCES [dbo].[Define_People] ([ID])

ALTER TABLE [dbo].[ListFactorBuy] CHECK CONSTRAINT [FK_ListFactorBuy_Define_People]

ALTER TABLE [dbo].[ListFactorBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBuy_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[ListFactorBuy] CHECK CONSTRAINT [FK_ListFactorBuy_Define_User]

ALTER TABLE [dbo].[ListFactorBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBuy_Define_Visitor] FOREIGN KEY([IdVisitor])
REFERENCES [dbo].[Define_Visitor] ([Id])

ALTER TABLE [dbo].[ListFactorBuy] CHECK CONSTRAINT [FK_ListFactorBuy_Define_Visitor]

ALTER TABLE [dbo].[ListFactorBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBuy_Moein_Bank] FOREIGN KEY([IdBanK])
REFERENCES [dbo].[Moein_Bank] ([Id])

ALTER TABLE [dbo].[ListFactorBuy] CHECK CONSTRAINT [FK_ListFactorBuy_Moein_Bank]

ALTER TABLE [dbo].[ListFactorBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBuy_Moein_Box] FOREIGN KEY([IdBox])
REFERENCES [dbo].[Moein_Box] ([Id])

ALTER TABLE [dbo].[ListFactorBuy] CHECK CONSTRAINT [FK_ListFactorBuy_Moein_Box]

ALTER TABLE [dbo].[ListFactorBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBuy_Moein_People] FOREIGN KEY([IdSanadAdd])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBuy] CHECK CONSTRAINT [FK_ListFactorBuy_Moein_People]

ALTER TABLE [dbo].[ListFactorBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBuy_Moein_People1] FOREIGN KEY([IdSanadDec])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBuy] CHECK CONSTRAINT [FK_ListFactorBuy_Moein_People1]

ALTER TABLE [dbo].[ListFactorBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBuy_Moein_People2] FOREIGN KEY([IdSanadDiscountH])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBuy] CHECK CONSTRAINT [FK_ListFactorBuy_Moein_People2]

ALTER TABLE [dbo].[ListFactorBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBuy_Moein_People3] FOREIGN KEY([IdSanadDiscountC])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBuy] CHECK CONSTRAINT [FK_ListFactorBuy_Moein_People3]

ALTER TABLE [dbo].[ListFactorBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBuy_Moein_People4] FOREIGN KEY([IdSanadCash])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBuy] CHECK CONSTRAINT [FK_ListFactorBuy_Moein_People4]

ALTER TABLE [dbo].[ListFactorBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBuy_Moein_People5] FOREIGN KEY([IdSanadChk])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBuy] CHECK CONSTRAINT [FK_ListFactorBuy_Moein_People5]

ALTER TABLE [dbo].[ListFactorBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBuy_Moein_People6] FOREIGN KEY([IdSanadHavaleh])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBuy] CHECK CONSTRAINT [FK_ListFactorBuy_Moein_People6]

ALTER TABLE [dbo].[ListFactorBuy]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorBuy_Moein_People7] FOREIGN KEY([IdSanadFactor])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorBuy] CHECK CONSTRAINT [FK_ListFactorBuy_Moein_People7]

ALTER TABLE [dbo].[ListFactorCharge]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorCharge_Define_Bank] FOREIGN KEY([IdBankHavaleh])
REFERENCES [dbo].[Define_Bank] ([ID])

ALTER TABLE [dbo].[ListFactorCharge] CHECK CONSTRAINT [FK_ListFactorCharge_Define_Bank]

ALTER TABLE [dbo].[ListFactorCharge]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorCharge_Define_Box] FOREIGN KEY([IdBox])
REFERENCES [dbo].[Define_Box] ([ID])

ALTER TABLE [dbo].[ListFactorCharge] CHECK CONSTRAINT [FK_ListFactorCharge_Define_Box]

ALTER TABLE [dbo].[ListFactorCharge]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorCharge_Define_People] FOREIGN KEY([IdName])
REFERENCES [dbo].[Define_People] ([ID])

ALTER TABLE [dbo].[ListFactorCharge] CHECK CONSTRAINT [FK_ListFactorCharge_Define_People]

ALTER TABLE [dbo].[ListFactorCharge]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorCharge_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[ListFactorCharge] CHECK CONSTRAINT [FK_ListFactorCharge_Define_User]

ALTER TABLE [dbo].[ListFactorCharge]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorCharge_ListFactorBuy] FOREIGN KEY([IdFactor])
REFERENCES [dbo].[ListFactorBuy] ([IdFactor])

ALTER TABLE [dbo].[ListFactorCharge] CHECK CONSTRAINT [FK_ListFactorCharge_ListFactorBuy]

ALTER TABLE [dbo].[ListFactorCharge]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorCharge_Moein_Bank] FOREIGN KEY([IdBanKMoein])
REFERENCES [dbo].[Moein_Bank] ([Id])

ALTER TABLE [dbo].[ListFactorCharge] CHECK CONSTRAINT [FK_ListFactorCharge_Moein_Bank]

ALTER TABLE [dbo].[ListFactorCharge]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorCharge_Moein_Box] FOREIGN KEY([IdBoxMoein])
REFERENCES [dbo].[Moein_Box] ([Id])

ALTER TABLE [dbo].[ListFactorCharge] CHECK CONSTRAINT [FK_ListFactorCharge_Moein_Box]

ALTER TABLE [dbo].[ListFactorCharge]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorCharge_Moein_People] FOREIGN KEY([IdSanadLend])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorCharge] CHECK CONSTRAINT [FK_ListFactorCharge_Moein_People]

ALTER TABLE [dbo].[ListFactorDamage]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorDamage_Define_PartKala] FOREIGN KEY([Part])
REFERENCES [dbo].[Define_PartKala] ([ID])

ALTER TABLE [dbo].[ListFactorDamage] CHECK CONSTRAINT [FK_ListFactorDamage_Define_PartKala]

ALTER TABLE [dbo].[ListFactorDamage]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorDamage_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[ListFactorDamage] CHECK CONSTRAINT [FK_ListFactorDamage_Define_User]

ALTER TABLE [dbo].[ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorSell_Define_Bank] FOREIGN KEY([IdBankHavaleh])
REFERENCES [dbo].[Define_Bank] ([ID])

ALTER TABLE [dbo].[ListFactorSell] CHECK CONSTRAINT [FK_ListFactorSell_Define_Bank]

ALTER TABLE [dbo].[ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorSell_Define_PartKala] FOREIGN KEY([Part])
REFERENCES [dbo].[Define_PartKala] ([ID])

ALTER TABLE [dbo].[ListFactorSell] CHECK CONSTRAINT [FK_ListFactorSell_Define_PartKala]

ALTER TABLE [dbo].[ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorSell_Define_People] FOREIGN KEY([IdName])
REFERENCES [dbo].[Define_People] ([ID])

ALTER TABLE [dbo].[ListFactorSell] CHECK CONSTRAINT [FK_ListFactorSell_Define_People]

ALTER TABLE [dbo].[ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorSell_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[ListFactorSell] CHECK CONSTRAINT [FK_ListFactorSell_Define_User]

ALTER TABLE [dbo].[ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorSell_Define_Visitor] FOREIGN KEY([IdVisitor])
REFERENCES [dbo].[Define_Visitor] ([Id])

ALTER TABLE [dbo].[ListFactorSell] CHECK CONSTRAINT [FK_ListFactorSell_Define_Visitor]

ALTER TABLE [dbo].[ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorSell_Moein_Bank] FOREIGN KEY([IdBanK])
REFERENCES [dbo].[Moein_Bank] ([Id])

ALTER TABLE [dbo].[ListFactorSell] CHECK CONSTRAINT [FK_ListFactorSell_Moein_Bank]

ALTER TABLE [dbo].[ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorSell_Moein_Box] FOREIGN KEY([IdBox])
REFERENCES [dbo].[Moein_Box] ([Id])

ALTER TABLE [dbo].[ListFactorSell] CHECK CONSTRAINT [FK_ListFactorSell_Moein_Box]

ALTER TABLE [dbo].[ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorSell_Moein_People] FOREIGN KEY([IdSanadAdd])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorSell] CHECK CONSTRAINT [FK_ListFactorSell_Moein_People]

ALTER TABLE [dbo].[ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorSell_Moein_People1] FOREIGN KEY([IdSanadDec])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorSell] CHECK CONSTRAINT [FK_ListFactorSell_Moein_People1]

ALTER TABLE [dbo].[ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorSell_Moein_People2] FOREIGN KEY([IdSanadDiscountH])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorSell] CHECK CONSTRAINT [FK_ListFactorSell_Moein_People2]

ALTER TABLE [dbo].[ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorSell_Moein_People3] FOREIGN KEY([IdSanadDiscountC])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorSell] CHECK CONSTRAINT [FK_ListFactorSell_Moein_People3]

ALTER TABLE [dbo].[ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorSell_Moein_People4] FOREIGN KEY([IdSanadCash])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorSell] CHECK CONSTRAINT [FK_ListFactorSell_Moein_People4]

ALTER TABLE [dbo].[ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorSell_Moein_People5] FOREIGN KEY([IdSanadChk])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorSell] CHECK CONSTRAINT [FK_ListFactorSell_Moein_People5]

ALTER TABLE [dbo].[ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorSell_Moein_People6] FOREIGN KEY([IdSanadHavaleh])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorSell] CHECK CONSTRAINT [FK_ListFactorSell_Moein_People6]

ALTER TABLE [dbo].[ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorSell_Moein_People7] FOREIGN KEY([IdSanadFactor])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorSell] CHECK CONSTRAINT [FK_ListFactorSell_Moein_People7]

ALTER TABLE [dbo].[ListFactorService]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorService_Define_Bank] FOREIGN KEY([IdBankHavaleh])
REFERENCES [dbo].[Define_Bank] ([ID])

ALTER TABLE [dbo].[ListFactorService] CHECK CONSTRAINT [FK_ListFactorService_Define_Bank]

ALTER TABLE [dbo].[ListFactorService]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorService_Define_PartKala] FOREIGN KEY([Part])
REFERENCES [dbo].[Define_PartKala] ([ID])

ALTER TABLE [dbo].[ListFactorService] CHECK CONSTRAINT [FK_ListFactorService_Define_PartKala]

ALTER TABLE [dbo].[ListFactorService]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorService_Define_People] FOREIGN KEY([IdName])
REFERENCES [dbo].[Define_People] ([ID])

ALTER TABLE [dbo].[ListFactorService] CHECK CONSTRAINT [FK_ListFactorService_Define_People]

ALTER TABLE [dbo].[ListFactorService]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorService_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[ListFactorService] CHECK CONSTRAINT [FK_ListFactorService_Define_User]

ALTER TABLE [dbo].[ListFactorService]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorService_Define_Visitor] FOREIGN KEY([IdVisitor])
REFERENCES [dbo].[Define_Visitor] ([Id])

ALTER TABLE [dbo].[ListFactorService] CHECK CONSTRAINT [FK_ListFactorService_Define_Visitor]

ALTER TABLE [dbo].[ListFactorService]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorService_Moein_Bank] FOREIGN KEY([IdBanK])
REFERENCES [dbo].[Moein_Bank] ([Id])

ALTER TABLE [dbo].[ListFactorService] CHECK CONSTRAINT [FK_ListFactorService_Moein_Bank]

ALTER TABLE [dbo].[ListFactorService]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorService_Moein_Box] FOREIGN KEY([IdBox])
REFERENCES [dbo].[Moein_Box] ([Id])

ALTER TABLE [dbo].[ListFactorService] CHECK CONSTRAINT [FK_ListFactorService_Moein_Box]

ALTER TABLE [dbo].[ListFactorService]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorService_Moein_People] FOREIGN KEY([IdSanadAdd])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorService] CHECK CONSTRAINT [FK_ListFactorService_Moein_People]

ALTER TABLE [dbo].[ListFactorService]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorService_Moein_People1] FOREIGN KEY([IdSanadDec])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorService] CHECK CONSTRAINT [FK_ListFactorService_Moein_People1]

ALTER TABLE [dbo].[ListFactorService]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorService_Moein_People2] FOREIGN KEY([IdSanadDiscountH])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorService] CHECK CONSTRAINT [FK_ListFactorService_Moein_People2]

ALTER TABLE [dbo].[ListFactorService]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorService_Moein_People3] FOREIGN KEY([IdSanadDiscountC])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorService] CHECK CONSTRAINT [FK_ListFactorService_Moein_People3]

ALTER TABLE [dbo].[ListFactorService]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorService_Moein_People4] FOREIGN KEY([IdSanadCash])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorService] CHECK CONSTRAINT [FK_ListFactorService_Moein_People4]

ALTER TABLE [dbo].[ListFactorService]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorService_Moein_People5] FOREIGN KEY([IdSanadChk])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorService] CHECK CONSTRAINT [FK_ListFactorService_Moein_People5]

ALTER TABLE [dbo].[ListFactorService]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorService_Moein_People6] FOREIGN KEY([IdSanadHavaleh])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorService] CHECK CONSTRAINT [FK_ListFactorService_Moein_People6]

ALTER TABLE [dbo].[ListFactorService]  WITH CHECK ADD  CONSTRAINT [FK_ListFactorService_Moein_People7] FOREIGN KEY([IdSanadFactor])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListFactorService] CHECK CONSTRAINT [FK_ListFactorService_Moein_People7]

ALTER TABLE [dbo].[Listkala]  WITH CHECK ADD  CONSTRAINT [FK_Listkala_Define_Kala] FOREIGN KEY([Idkala])
REFERENCES [dbo].[Define_Kala] ([Id])

ALTER TABLE [dbo].[Listkala] CHECK CONSTRAINT [FK_Listkala_Define_Kala]

ALTER TABLE [dbo].[Listkala]  WITH CHECK ADD  CONSTRAINT [FK_Listkala_ListVisitor] FOREIGN KEY([IdLinkVisitor])
REFERENCES [dbo].[ListVisitor] ([IdVisitor])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[Listkala] CHECK CONSTRAINT [FK_Listkala_ListVisitor]

ALTER TABLE [dbo].[ListKala_Discount]  WITH CHECK ADD  CONSTRAINT [FK_ListKala_Discount_Define_Kala] FOREIGN KEY([Idkala])
REFERENCES [dbo].[Define_Kala] ([Id])

ALTER TABLE [dbo].[ListKala_Discount] CHECK CONSTRAINT [FK_ListKala_Discount_Define_Kala]

ALTER TABLE [dbo].[Listkala_G]  WITH CHECK ADD  CONSTRAINT [FK_Listkala_G_Define_TwoGroup] FOREIGN KEY([Idkala])
REFERENCES [dbo].[Define_TwoGroup] ([Id])

ALTER TABLE [dbo].[Listkala_G] CHECK CONSTRAINT [FK_Listkala_G_Define_TwoGroup]

ALTER TABLE [dbo].[Listkala_G]  WITH CHECK ADD  CONSTRAINT [FK_Listkala_G_ListVisitor_G] FOREIGN KEY([IdLinkVisitor])
REFERENCES [dbo].[ListVisitor_G] ([IdVisitor])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[Listkala_G] CHECK CONSTRAINT [FK_Listkala_G_ListVisitor_G]

ALTER TABLE [dbo].[Listkala_OG]  WITH CHECK ADD  CONSTRAINT [FK_Listkala_OG_Define_OneGroup] FOREIGN KEY([Idkala])
REFERENCES [dbo].[Define_OneGroup] ([Id])

ALTER TABLE [dbo].[Listkala_OG] CHECK CONSTRAINT [FK_Listkala_OG_Define_OneGroup]

ALTER TABLE [dbo].[Listkala_OG]  WITH CHECK ADD  CONSTRAINT [FK_Listkala_OG_ListVisitor_OG] FOREIGN KEY([IdLinkVisitor])
REFERENCES [dbo].[ListVisitor_OG] ([IdVisitor])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[Listkala_OG] CHECK CONSTRAINT [FK_Listkala_OG_ListVisitor_OG]

ALTER TABLE [dbo].[ListkalaU]  WITH CHECK ADD  CONSTRAINT [FK_ListkalaU_Define_Kala] FOREIGN KEY([Idkala])
REFERENCES [dbo].[Define_Kala] ([Id])

ALTER TABLE [dbo].[ListkalaU] CHECK CONSTRAINT [FK_ListkalaU_Define_Kala]

ALTER TABLE [dbo].[ListkalaU]  WITH CHECK ADD  CONSTRAINT [FK_ListkalaU_ListUser] FOREIGN KEY([IdLinkUser])
REFERENCES [dbo].[ListUser] ([IdUser])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[ListkalaU] CHECK CONSTRAINT [FK_ListkalaU_ListUser]

ALTER TABLE [dbo].[ListkalaU_G]  WITH CHECK ADD  CONSTRAINT [FK_ListkalaU_G_Define_TwoGroup] FOREIGN KEY([Idkala])
REFERENCES [dbo].[Define_TwoGroup] ([Id])

ALTER TABLE [dbo].[ListkalaU_G] CHECK CONSTRAINT [FK_ListkalaU_G_Define_TwoGroup]

ALTER TABLE [dbo].[ListkalaU_G]  WITH CHECK ADD  CONSTRAINT [FK_ListkalaU_G_ListUser_G] FOREIGN KEY([IdLinkUser])
REFERENCES [dbo].[ListUser_G] ([IdUser])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[ListkalaU_G] CHECK CONSTRAINT [FK_ListkalaU_G_ListUser_G]

ALTER TABLE [dbo].[ListkalaU_OG]  WITH CHECK ADD  CONSTRAINT [FK_ListkalaU_OG_Define_OneGroup] FOREIGN KEY([Idkala])
REFERENCES [dbo].[Define_OneGroup] ([Id])

ALTER TABLE [dbo].[ListkalaU_OG] CHECK CONSTRAINT [FK_ListkalaU_OG_Define_OneGroup]

ALTER TABLE [dbo].[ListkalaU_OG]  WITH CHECK ADD  CONSTRAINT [FK_ListkalaU_OG_ListUser_OG] FOREIGN KEY([IdLinkUser])
REFERENCES [dbo].[ListUser_OG] ([IdUser])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[ListkalaU_OG] CHECK CONSTRAINT [FK_ListkalaU_OG_ListUser_OG]

ALTER TABLE [dbo].[ListKasriFactor]  WITH CHECK ADD  CONSTRAINT [FK_ListKasriFactor_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[ListKasriFactor] CHECK CONSTRAINT [FK_ListKasriFactor_Define_User]

ALTER TABLE [dbo].[ListKasriFactor]  WITH CHECK ADD  CONSTRAINT [FK_ListKasriFactor_ListFactorSell] FOREIGN KEY([IdFactor])
REFERENCES [dbo].[ListFactorSell] ([IdFactor])

ALTER TABLE [dbo].[ListKasriFactor] CHECK CONSTRAINT [FK_ListKasriFactor_ListFactorSell]

ALTER TABLE [dbo].[ListKasriFactor]  WITH CHECK ADD  CONSTRAINT [FK_ListKasriFactor_Moein_People] FOREIGN KEY([IdSanad])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListKasriFactor] CHECK CONSTRAINT [FK_ListKasriFactor_Moein_People]

ALTER TABLE [dbo].[ListOrderDarsad]  WITH CHECK ADD  CONSTRAINT [FK_ListOrderDarsad_Define_Group_P] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Define_Group_P] ([Id])

ALTER TABLE [dbo].[ListOrderDarsad] CHECK CONSTRAINT [FK_ListOrderDarsad_Define_Group_P]

ALTER TABLE [dbo].[ListOrderDarsad]  WITH CHECK ADD  CONSTRAINT [FK_ListOrderDarsad_ListVisitor] FOREIGN KEY([IdLinkVisitor])
REFERENCES [dbo].[ListVisitor] ([IdVisitor])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[ListOrderDarsad] CHECK CONSTRAINT [FK_ListOrderDarsad_ListVisitor]

ALTER TABLE [dbo].[ListOrderDarsad_G]  WITH CHECK ADD  CONSTRAINT [FK_ListOrderDarsad_G_Define_Group_P] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Define_Group_P] ([Id])

ALTER TABLE [dbo].[ListOrderDarsad_G] CHECK CONSTRAINT [FK_ListOrderDarsad_G_Define_Group_P]

ALTER TABLE [dbo].[ListOrderDarsad_G]  WITH CHECK ADD  CONSTRAINT [FK_ListOrderDarsad_G_ListVisitor_G] FOREIGN KEY([IdLinkVisitor])
REFERENCES [dbo].[ListVisitor_G] ([IdVisitor])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[ListOrderDarsad_G] CHECK CONSTRAINT [FK_ListOrderDarsad_G_ListVisitor_G]

ALTER TABLE [dbo].[ListOrderDarsad_OG]  WITH CHECK ADD  CONSTRAINT [FK_ListOrderDarsad_OG_Define_Group_P] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Define_Group_P] ([Id])

ALTER TABLE [dbo].[ListOrderDarsad_OG] CHECK CONSTRAINT [FK_ListOrderDarsad_OG_Define_Group_P]

ALTER TABLE [dbo].[ListOrderDarsad_OG]  WITH CHECK ADD  CONSTRAINT [FK_ListOrderDarsad_OG_ListVisitor_OG] FOREIGN KEY([IdLinkVisitor])
REFERENCES [dbo].[ListVisitor_OG] ([IdVisitor])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[ListOrderDarsad_OG] CHECK CONSTRAINT [FK_ListOrderDarsad_OG_ListVisitor_OG]

ALTER TABLE [dbo].[ListOrderDarsadU]  WITH CHECK ADD  CONSTRAINT [FK_ListOrderDarsadU_Define_Group_P] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Define_Group_P] ([Id])

ALTER TABLE [dbo].[ListOrderDarsadU] CHECK CONSTRAINT [FK_ListOrderDarsadU_Define_Group_P]

ALTER TABLE [dbo].[ListOrderDarsadU]  WITH CHECK ADD  CONSTRAINT [FK_ListOrderDarsadU_ListUser] FOREIGN KEY([IdLinkUser])
REFERENCES [dbo].[ListUser] ([IdUser])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[ListOrderDarsadU] CHECK CONSTRAINT [FK_ListOrderDarsadU_ListUser]

ALTER TABLE [dbo].[ListOrderDarsadU_G]  WITH CHECK ADD  CONSTRAINT [FK_ListOrderDarsadU_G_Define_Group_P] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Define_Group_P] ([Id])

ALTER TABLE [dbo].[ListOrderDarsadU_G] CHECK CONSTRAINT [FK_ListOrderDarsadU_G_Define_Group_P]

ALTER TABLE [dbo].[ListOrderDarsadU_G]  WITH CHECK ADD  CONSTRAINT [FK_ListOrderDarsadU_G_ListUser_G] FOREIGN KEY([IdLinkUser])
REFERENCES [dbo].[ListUser_G] ([IdUser])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[ListOrderDarsadU_G] CHECK CONSTRAINT [FK_ListOrderDarsadU_G_ListUser_G]

ALTER TABLE [dbo].[ListOrderDarsadU_OG]  WITH CHECK ADD  CONSTRAINT [FK_ListOrderDarsadU_OG_Define_Group_P] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Define_Group_P] ([Id])

ALTER TABLE [dbo].[ListOrderDarsadU_OG] CHECK CONSTRAINT [FK_ListOrderDarsadU_OG_Define_Group_P]

ALTER TABLE [dbo].[ListOrderDarsadU_OG]  WITH CHECK ADD  CONSTRAINT [FK_ListOrderDarsadU_OG_ListUser_OG] FOREIGN KEY([IdLinkUser])
REFERENCES [dbo].[ListUser_OG] ([IdUser])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[ListOrderDarsadU_OG] CHECK CONSTRAINT [FK_ListOrderDarsadU_OG_ListUser_OG]

ALTER TABLE [dbo].[ListOtherCharge]  WITH CHECK ADD  CONSTRAINT [FK_ListOtherCharge_Define_Bank] FOREIGN KEY([IdBankHavaleh])
REFERENCES [dbo].[Define_Bank] ([ID])

ALTER TABLE [dbo].[ListOtherCharge] CHECK CONSTRAINT [FK_ListOtherCharge_Define_Bank]

ALTER TABLE [dbo].[ListOtherCharge]  WITH CHECK ADD  CONSTRAINT [FK_ListOtherCharge_Define_Box] FOREIGN KEY([IdBox])
REFERENCES [dbo].[Define_Box] ([ID])

ALTER TABLE [dbo].[ListOtherCharge] CHECK CONSTRAINT [FK_ListOtherCharge_Define_Box]

ALTER TABLE [dbo].[ListOtherCharge]  WITH CHECK ADD  CONSTRAINT [FK_ListOtherCharge_Define_People] FOREIGN KEY([IdName])
REFERENCES [dbo].[Define_People] ([ID])

ALTER TABLE [dbo].[ListOtherCharge] CHECK CONSTRAINT [FK_ListOtherCharge_Define_People]

ALTER TABLE [dbo].[ListOtherCharge]  WITH CHECK ADD  CONSTRAINT [FK_ListOtherCharge_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[ListOtherCharge] CHECK CONSTRAINT [FK_ListOtherCharge_Define_User]

ALTER TABLE [dbo].[ListOtherCharge]  WITH CHECK ADD  CONSTRAINT [FK_ListOtherCharge_Moein_Bank] FOREIGN KEY([IdBanKMoein])
REFERENCES [dbo].[Moein_Bank] ([Id])

ALTER TABLE [dbo].[ListOtherCharge] CHECK CONSTRAINT [FK_ListOtherCharge_Moein_Bank]

ALTER TABLE [dbo].[ListOtherCharge]  WITH CHECK ADD  CONSTRAINT [FK_ListOtherCharge_Moein_Box] FOREIGN KEY([IdBoxMoein])
REFERENCES [dbo].[Moein_Box] ([Id])

ALTER TABLE [dbo].[ListOtherCharge] CHECK CONSTRAINT [FK_ListOtherCharge_Moein_Box]

ALTER TABLE [dbo].[ListOtherCharge]  WITH CHECK ADD  CONSTRAINT [FK_ListOtherCharge_Moein_People] FOREIGN KEY([IdSanadLend])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[ListOtherCharge] CHECK CONSTRAINT [FK_ListOtherCharge_Moein_People]

ALTER TABLE [dbo].[ListUser]  WITH CHECK ADD  CONSTRAINT [FK_ListUser_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[ListUser] CHECK CONSTRAINT [FK_ListUser_Define_User]

ALTER TABLE [dbo].[ListUser_G]  WITH CHECK ADD  CONSTRAINT [FK_ListUser_G_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[ListUser_G] CHECK CONSTRAINT [FK_ListUser_G_Define_User]

ALTER TABLE [dbo].[ListUser_OG]  WITH CHECK ADD  CONSTRAINT [FK_ListUser_OG_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[ListUser_OG] CHECK CONSTRAINT [FK_ListUser_OG_Define_User]

ALTER TABLE [dbo].[ListVisitor]  WITH CHECK ADD  CONSTRAINT [FK_ListVisitor_Define_Visitor] FOREIGN KEY([IdVisitor])
REFERENCES [dbo].[Define_Visitor] ([Id])

ALTER TABLE [dbo].[ListVisitor] CHECK CONSTRAINT [FK_ListVisitor_Define_Visitor]

ALTER TABLE [dbo].[ListVisitor_G]  WITH CHECK ADD  CONSTRAINT [FK_ListVisitor_G_Define_Visitor] FOREIGN KEY([IdVisitor])
REFERENCES [dbo].[Define_Visitor] ([Id])

ALTER TABLE [dbo].[ListVisitor_G] CHECK CONSTRAINT [FK_ListVisitor_G_Define_Visitor]

ALTER TABLE [dbo].[ListVisitor_OG]  WITH CHECK ADD  CONSTRAINT [FK_ListVisitor_OG_Define_Visitor] FOREIGN KEY([IdVisitor])
REFERENCES [dbo].[Define_Visitor] ([Id])

ALTER TABLE [dbo].[ListVisitor_OG] CHECK CONSTRAINT [FK_ListVisitor_OG_Define_Visitor]

ALTER TABLE [dbo].[MessageCenter]  WITH CHECK ADD  CONSTRAINT [FK_MessageCenter_Define_User] FOREIGN KEY([Sender_IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[MessageCenter] CHECK CONSTRAINT [FK_MessageCenter_Define_User]

ALTER TABLE [dbo].[MessageCenter]  WITH CHECK ADD  CONSTRAINT [FK_MessageCenter_Define_User1] FOREIGN KEY([Reciver_IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[MessageCenter] CHECK CONSTRAINT [FK_MessageCenter_Define_User1]

ALTER TABLE [dbo].[MessageCenter]  WITH CHECK ADD  CONSTRAINT [FK_MessageCenter_Define_Visitor] FOREIGN KEY([Sender_IdVisitor])
REFERENCES [dbo].[Define_Visitor] ([Id])

ALTER TABLE [dbo].[MessageCenter] CHECK CONSTRAINT [FK_MessageCenter_Define_Visitor]

ALTER TABLE [dbo].[MessageCenter]  WITH CHECK ADD  CONSTRAINT [FK_MessageCenter_Define_Visitor1] FOREIGN KEY([Reciver_IdVisitor])
REFERENCES [dbo].[Define_Visitor] ([Id])

ALTER TABLE [dbo].[MessageCenter] CHECK CONSTRAINT [FK_MessageCenter_Define_Visitor1]

ALTER TABLE [dbo].[Mobile_KalaFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_Mobile_KalaFactorSell_Define_Anbar] FOREIGN KEY([IdAnbar])
REFERENCES [dbo].[Define_Anbar] ([ID])

ALTER TABLE [dbo].[Mobile_KalaFactorSell] CHECK CONSTRAINT [FK_Mobile_KalaFactorSell_Define_Anbar]

ALTER TABLE [dbo].[Mobile_KalaFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_Mobile_KalaFactorSell_Define_Kala] FOREIGN KEY([IdKala])
REFERENCES [dbo].[Define_Kala] ([Id])

ALTER TABLE [dbo].[Mobile_KalaFactorSell] CHECK CONSTRAINT [FK_Mobile_KalaFactorSell_Define_Kala]

ALTER TABLE [dbo].[Mobile_KalaFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_Mobile_KalaFactorSell_Mobile_ListFactorSell] FOREIGN KEY([IdFactor])
REFERENCES [dbo].[Mobile_ListFactorSell] ([IdFactor])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[Mobile_KalaFactorSell] CHECK CONSTRAINT [FK_Mobile_KalaFactorSell_Mobile_ListFactorSell]

ALTER TABLE [dbo].[Mobile_ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_Mobile_ListFactorSell_Define_Anbar] FOREIGN KEY([IdAnbar])
REFERENCES [dbo].[Define_Anbar] ([ID])

ALTER TABLE [dbo].[Mobile_ListFactorSell] CHECK CONSTRAINT [FK_Mobile_ListFactorSell_Define_Anbar]

ALTER TABLE [dbo].[Mobile_ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_Mobile_ListFactorSell_Define_People] FOREIGN KEY([IdName])
REFERENCES [dbo].[Define_People] ([ID])

ALTER TABLE [dbo].[Mobile_ListFactorSell] CHECK CONSTRAINT [FK_Mobile_ListFactorSell_Define_People]

ALTER TABLE [dbo].[Mobile_ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_Mobile_ListFactorSell_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Mobile_ListFactorSell] CHECK CONSTRAINT [FK_Mobile_ListFactorSell_Define_User]

ALTER TABLE [dbo].[Mobile_ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_Mobile_ListFactorSell_Define_Visitor] FOREIGN KEY([IdVisitor])
REFERENCES [dbo].[Define_Visitor] ([Id])

ALTER TABLE [dbo].[Mobile_ListFactorSell] CHECK CONSTRAINT [FK_Mobile_ListFactorSell_Define_Visitor]

ALTER TABLE [dbo].[Mobile_ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_Mobile_ListFactorSell_ListFactorSell] FOREIGN KEY([IdSell])
REFERENCES [dbo].[ListFactorSell] ([IdFactor])

ALTER TABLE [dbo].[Mobile_ListFactorSell] CHECK CONSTRAINT [FK_Mobile_ListFactorSell_ListFactorSell]

ALTER TABLE [dbo].[Mobile_ListFactorSell]  WITH CHECK ADD  CONSTRAINT [FK_Mobile_ListFactorSell_Mobile_NewPeople] FOREIGN KEY([IdNewPeople])
REFERENCES [dbo].[Mobile_NewPeople] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[Mobile_ListFactorSell] CHECK CONSTRAINT [FK_Mobile_ListFactorSell_Mobile_NewPeople]

ALTER TABLE [dbo].[Mobile_NewPeople]  WITH CHECK ADD  CONSTRAINT [FK_Mobile_NewPeople_Define_City] FOREIGN KEY([IdCity])
REFERENCES [dbo].[Define_City] ([Code])

ALTER TABLE [dbo].[Mobile_NewPeople] CHECK CONSTRAINT [FK_Mobile_NewPeople_Define_City]

ALTER TABLE [dbo].[Mobile_NewPeople]  WITH CHECK ADD  CONSTRAINT [FK_Mobile_NewPeople_Define_Group_P] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Define_Group_P] ([Id])

ALTER TABLE [dbo].[Mobile_NewPeople] CHECK CONSTRAINT [FK_Mobile_NewPeople_Define_Group_P]

ALTER TABLE [dbo].[Mobile_NewPeople]  WITH CHECK ADD  CONSTRAINT [FK_Mobile_NewPeople_Define_Ostan] FOREIGN KEY([IdOstan])
REFERENCES [dbo].[Define_Ostan] ([Code])

ALTER TABLE [dbo].[Mobile_NewPeople] CHECK CONSTRAINT [FK_Mobile_NewPeople_Define_Ostan]

ALTER TABLE [dbo].[Mobile_NewPeople]  WITH CHECK ADD  CONSTRAINT [FK_Mobile_NewPeople_Define_Part] FOREIGN KEY([IdPart])
REFERENCES [dbo].[Define_Part] ([Code])

ALTER TABLE [dbo].[Mobile_NewPeople] CHECK CONSTRAINT [FK_Mobile_NewPeople_Define_Part]

ALTER TABLE [dbo].[Mobile_NewPeople]  WITH CHECK ADD  CONSTRAINT [FK_Mobile_NewPeople_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Mobile_NewPeople] CHECK CONSTRAINT [FK_Mobile_NewPeople_Define_User]

ALTER TABLE [dbo].[Mobile_NewPeople]  WITH CHECK ADD  CONSTRAINT [FK_Mobile_NewPeople_Define_Visitor] FOREIGN KEY([IdVisitor])
REFERENCES [dbo].[Define_Visitor] ([Id])

ALTER TABLE [dbo].[Mobile_NewPeople] CHECK CONSTRAINT [FK_Mobile_NewPeople_Define_Visitor]

ALTER TABLE [dbo].[Mobile_NoSales]  WITH CHECK ADD  CONSTRAINT [FK_Mobile_NoSales_Define_People] FOREIGN KEY([IdName])
REFERENCES [dbo].[Define_People] ([ID])

ALTER TABLE [dbo].[Mobile_NoSales] CHECK CONSTRAINT [FK_Mobile_NoSales_Define_People]

ALTER TABLE [dbo].[Mobile_NoSales]  WITH CHECK ADD  CONSTRAINT [FK_Mobile_NoSales_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Mobile_NoSales] CHECK CONSTRAINT [FK_Mobile_NoSales_Define_User]

ALTER TABLE [dbo].[Mobile_NoSales]  WITH CHECK ADD  CONSTRAINT [FK_Mobile_NoSales_Define_Visitor] FOREIGN KEY([IdVisitor])
REFERENCES [dbo].[Define_Visitor] ([Id])

ALTER TABLE [dbo].[Mobile_NoSales] CHECK CONSTRAINT [FK_Mobile_NoSales_Define_Visitor]

ALTER TABLE [dbo].[Moein_Bank]  WITH CHECK ADD  CONSTRAINT [FK_Moein_Bank_Define_Bank] FOREIGN KEY([IDBank])
REFERENCES [dbo].[Define_Bank] ([ID])

ALTER TABLE [dbo].[Moein_Bank] CHECK CONSTRAINT [FK_Moein_Bank_Define_Bank]

ALTER TABLE [dbo].[Moein_Bank]  WITH CHECK ADD  CONSTRAINT [FK_Moein_Bank_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Moein_Bank] CHECK CONSTRAINT [FK_Moein_Bank_Define_User]

ALTER TABLE [dbo].[Moein_Box]  WITH CHECK ADD  CONSTRAINT [FK_Moein_Box_Define_Box] FOREIGN KEY([IDBox])
REFERENCES [dbo].[Define_Box] ([ID])

ALTER TABLE [dbo].[Moein_Box] CHECK CONSTRAINT [FK_Moein_Box_Define_Box]

ALTER TABLE [dbo].[Moein_Box]  WITH CHECK ADD  CONSTRAINT [FK_Moein_Box_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Moein_Box] CHECK CONSTRAINT [FK_Moein_Box_Define_User]

ALTER TABLE [dbo].[Moein_People]  WITH CHECK ADD  CONSTRAINT [FK_Moein_People_Define_People] FOREIGN KEY([IDPeople])
REFERENCES [dbo].[Define_People] ([ID])

ALTER TABLE [dbo].[Moein_People] CHECK CONSTRAINT [FK_Moein_People_Define_People]

ALTER TABLE [dbo].[Moein_People]  WITH CHECK ADD  CONSTRAINT [FK_Moein_People_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Moein_People] CHECK CONSTRAINT [FK_Moein_People_Define_User]

ALTER TABLE [dbo].[PayLimitFrosh]  WITH CHECK ADD  CONSTRAINT [FK_PayLimitFrosh_Get_Pay_Sanad] FOREIGN KEY([IdSanad])
REFERENCES [dbo].[Get_Pay_Sanad] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[PayLimitFrosh] CHECK CONSTRAINT [FK_PayLimitFrosh_Get_Pay_Sanad]

ALTER TABLE [dbo].[PayLimitFrosh]  WITH CHECK ADD  CONSTRAINT [FK_PayLimitFrosh_ListFactorSell] FOREIGN KEY([IdFactor])
REFERENCES [dbo].[ListFactorSell] ([IdFactor])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[PayLimitFrosh] CHECK CONSTRAINT [FK_PayLimitFrosh_ListFactorSell]

ALTER TABLE [dbo].[PayLimitKharid]  WITH CHECK ADD  CONSTRAINT [FK_PayLimitKharid_Get_Pay_Sanad] FOREIGN KEY([IdSanad])
REFERENCES [dbo].[Get_Pay_Sanad] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[PayLimitKharid] CHECK CONSTRAINT [FK_PayLimitKharid_Get_Pay_Sanad]

ALTER TABLE [dbo].[PayLimitKharid]  WITH CHECK ADD  CONSTRAINT [FK_PayLimitKharid_ListFactorBuy] FOREIGN KEY([IdFactor])
REFERENCES [dbo].[ListFactorBuy] ([IdFactor])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[PayLimitKharid] CHECK CONSTRAINT [FK_PayLimitKharid_ListFactorBuy]

ALTER TABLE [dbo].[Sanad_AddDecBank]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_AddDecBank_Define_Bank] FOREIGN KEY([IdBank])
REFERENCES [dbo].[Define_Bank] ([ID])

ALTER TABLE [dbo].[Sanad_AddDecBank] CHECK CONSTRAINT [FK_Sanad_AddDecBank_Define_Bank]

ALTER TABLE [dbo].[Sanad_AddDecBank]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_AddDecBank_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Sanad_AddDecBank] CHECK CONSTRAINT [FK_Sanad_AddDecBank_Define_User]

ALTER TABLE [dbo].[Sanad_AddDecBank]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_AddDecBank_Moein_Bank] FOREIGN KEY([IDsanadBank])
REFERENCES [dbo].[Moein_Bank] ([Id])

ALTER TABLE [dbo].[Sanad_AddDecBank] CHECK CONSTRAINT [FK_Sanad_AddDecBank_Moein_Bank]

ALTER TABLE [dbo].[Sanad_AddDecBox]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_AddDecBox_Define_Box] FOREIGN KEY([IdBox])
REFERENCES [dbo].[Define_Box] ([ID])

ALTER TABLE [dbo].[Sanad_AddDecBox] CHECK CONSTRAINT [FK_Sanad_AddDecBox_Define_Box]

ALTER TABLE [dbo].[Sanad_AddDecBox]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_AddDecBox_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Sanad_AddDecBox] CHECK CONSTRAINT [FK_Sanad_AddDecBox_Define_User]

ALTER TABLE [dbo].[Sanad_AddDecBox]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_AddDecBox_Moein_Box] FOREIGN KEY([IDsanadBox])
REFERENCES [dbo].[Moein_Box] ([Id])

ALTER TABLE [dbo].[Sanad_AddDecBox] CHECK CONSTRAINT [FK_Sanad_AddDecBox_Moein_Box]

ALTER TABLE [dbo].[Sanad_BankTBank_Bed]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_BankTBank_Bed_Define_Bank] FOREIGN KEY([IdBankBed])
REFERENCES [dbo].[Define_Bank] ([ID])

ALTER TABLE [dbo].[Sanad_BankTBank_Bed] CHECK CONSTRAINT [FK_Sanad_BankTBank_Bed_Define_Bank]

ALTER TABLE [dbo].[Sanad_BankTBank_Bed]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_BankTBank_Bed_Moein_Bank] FOREIGN KEY([IdSanadBed])
REFERENCES [dbo].[Moein_Bank] ([Id])

ALTER TABLE [dbo].[Sanad_BankTBank_Bed] CHECK CONSTRAINT [FK_Sanad_BankTBank_Bed_Moein_Bank]

ALTER TABLE [dbo].[Sanad_BankTBank_Bed]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_BankTBank_Bed_Sanad_BankTBank_Bes] FOREIGN KEY([Id])
REFERENCES [dbo].[Sanad_BankTBank_Bes] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[Sanad_BankTBank_Bed] CHECK CONSTRAINT [FK_Sanad_BankTBank_Bed_Sanad_BankTBank_Bes]

ALTER TABLE [dbo].[Sanad_BankTBank_Bes]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_BankTBank_Bes_Define_Bank] FOREIGN KEY([IdBankBes])
REFERENCES [dbo].[Define_Bank] ([ID])

ALTER TABLE [dbo].[Sanad_BankTBank_Bes] CHECK CONSTRAINT [FK_Sanad_BankTBank_Bes_Define_Bank]

ALTER TABLE [dbo].[Sanad_BankTBank_Bes]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_BankTBank_Bes_Moein_Bank] FOREIGN KEY([IdSanadBes])
REFERENCES [dbo].[Moein_Bank] ([Id])

ALTER TABLE [dbo].[Sanad_BankTBank_Bes] CHECK CONSTRAINT [FK_Sanad_BankTBank_Bes_Moein_Bank]

ALTER TABLE [dbo].[Sanad_BOXTBOX]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_BOXTBOX_Define_Box] FOREIGN KEY([IdNameBed])
REFERENCES [dbo].[Define_Box] ([ID])

ALTER TABLE [dbo].[Sanad_BOXTBOX] CHECK CONSTRAINT [FK_Sanad_BOXTBOX_Define_Box]

ALTER TABLE [dbo].[Sanad_BOXTBOX]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_BOXTBOX_Define_Box1] FOREIGN KEY([IdNameBes])
REFERENCES [dbo].[Define_Box] ([ID])

ALTER TABLE [dbo].[Sanad_BOXTBOX] CHECK CONSTRAINT [FK_Sanad_BOXTBOX_Define_Box1]

ALTER TABLE [dbo].[Sanad_BOXTBOX]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_BOXTBOX_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Sanad_BOXTBOX] CHECK CONSTRAINT [FK_Sanad_BOXTBOX_Define_User]

ALTER TABLE [dbo].[Sanad_BOXTBOX]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_BOXTBOX_Moein_Box] FOREIGN KEY([IdSanadBed])
REFERENCES [dbo].[Moein_Box] ([Id])

ALTER TABLE [dbo].[Sanad_BOXTBOX] CHECK CONSTRAINT [FK_Sanad_BOXTBOX_Moein_Box]

ALTER TABLE [dbo].[Sanad_BOXTBOX]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_BOXTBOX_Moein_Box1] FOREIGN KEY([IdSanadBes])
REFERENCES [dbo].[Moein_Box] ([Id])

ALTER TABLE [dbo].[Sanad_BOXTBOX] CHECK CONSTRAINT [FK_Sanad_BOXTBOX_Moein_Box1]

ALTER TABLE [dbo].[Sanad_ChangeChk]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_ChangeChk_Chk_Get_Pay] FOREIGN KEY([IdChk])
REFERENCES [dbo].[Chk_Get_Pay] ([ID])

ALTER TABLE [dbo].[Sanad_ChangeChk] CHECK CONSTRAINT [FK_Sanad_ChangeChk_Chk_Get_Pay]

ALTER TABLE [dbo].[Sanad_ChangeChk]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_ChangeChk_Moein_Bank] FOREIGN KEY([BankMoein])
REFERENCES [dbo].[Moein_Bank] ([Id])

ALTER TABLE [dbo].[Sanad_ChangeChk] CHECK CONSTRAINT [FK_Sanad_ChangeChk_Moein_Bank]

ALTER TABLE [dbo].[Sanad_ChangeChk]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_ChangeChk_Moein_Box] FOREIGN KEY([BoxMoein])
REFERENCES [dbo].[Moein_Box] ([Id])

ALTER TABLE [dbo].[Sanad_ChangeChk] CHECK CONSTRAINT [FK_Sanad_ChangeChk_Moein_Box]

ALTER TABLE [dbo].[Sanad_ChangeChk]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_ChangeChk_Moein_People] FOREIGN KEY([PeopleMoein])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[Sanad_ChangeChk] CHECK CONSTRAINT [FK_Sanad_ChangeChk_Moein_People]

ALTER TABLE [dbo].[Sanad_PTP]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_PTP_Define_People] FOREIGN KEY([IdNameBed])
REFERENCES [dbo].[Define_People] ([ID])

ALTER TABLE [dbo].[Sanad_PTP] CHECK CONSTRAINT [FK_Sanad_PTP_Define_People]

ALTER TABLE [dbo].[Sanad_PTP]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_PTP_Define_People1] FOREIGN KEY([IdNameBes])
REFERENCES [dbo].[Define_People] ([ID])

ALTER TABLE [dbo].[Sanad_PTP] CHECK CONSTRAINT [FK_Sanad_PTP_Define_People1]

ALTER TABLE [dbo].[Sanad_PTP]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_PTP_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Sanad_PTP] CHECK CONSTRAINT [FK_Sanad_PTP_Define_User]

ALTER TABLE [dbo].[Sanad_PTP]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_PTP_Moein_People] FOREIGN KEY([IdSanadBed])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[Sanad_PTP] CHECK CONSTRAINT [FK_Sanad_PTP_Moein_People]

ALTER TABLE [dbo].[Sanad_PTP]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_PTP_Moein_People1] FOREIGN KEY([IdSanadBes])
REFERENCES [dbo].[Moein_People] ([Id])

ALTER TABLE [dbo].[Sanad_PTP] CHECK CONSTRAINT [FK_Sanad_PTP_Moein_People1]

ALTER TABLE [dbo].[Sanad_Translate_BoxBank]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_Translate_BoxBank_Define_Bank] FOREIGN KEY([IdBank])
REFERENCES [dbo].[Define_Bank] ([ID])

ALTER TABLE [dbo].[Sanad_Translate_BoxBank] CHECK CONSTRAINT [FK_Sanad_Translate_BoxBank_Define_Bank]

ALTER TABLE [dbo].[Sanad_Translate_BoxBank]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_Translate_BoxBank_Define_Box] FOREIGN KEY([IdBox])
REFERENCES [dbo].[Define_Box] ([ID])

ALTER TABLE [dbo].[Sanad_Translate_BoxBank] CHECK CONSTRAINT [FK_Sanad_Translate_BoxBank_Define_Box]

ALTER TABLE [dbo].[Sanad_Translate_BoxBank]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_Translate_BoxBank_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Sanad_Translate_BoxBank] CHECK CONSTRAINT [FK_Sanad_Translate_BoxBank_Define_User]

ALTER TABLE [dbo].[Sanad_Translate_BoxBank]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_Translate_BoxBank_Moein_Bank] FOREIGN KEY([IdBankMoein])
REFERENCES [dbo].[Moein_Bank] ([Id])

ALTER TABLE [dbo].[Sanad_Translate_BoxBank] CHECK CONSTRAINT [FK_Sanad_Translate_BoxBank_Moein_Bank]

ALTER TABLE [dbo].[Sanad_Translate_BoxBank]  WITH CHECK ADD  CONSTRAINT [FK_Sanad_Translate_BoxBank_Moein_Box] FOREIGN KEY([IdBoxMoein])
REFERENCES [dbo].[Moein_Box] ([Id])

ALTER TABLE [dbo].[Sanad_Translate_BoxBank] CHECK CONSTRAINT [FK_Sanad_Translate_BoxBank_Moein_Box]

ALTER TABLE [dbo].[SettingProgram]  WITH CHECK ADD  CONSTRAINT [FK_SettingProgram_Define_Anbar] FOREIGN KEY([IdAnbar])
REFERENCES [dbo].[Define_Anbar] ([ID])

ALTER TABLE [dbo].[SettingProgram] CHECK CONSTRAINT [FK_SettingProgram_Define_Anbar]

ALTER TABLE [dbo].[SettingProgram]  WITH CHECK ADD  CONSTRAINT [FK_SettingProgram_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[SettingProgram] CHECK CONSTRAINT [FK_SettingProgram_Define_User]

ALTER TABLE [dbo].[TimeFrosh]  WITH CHECK ADD  CONSTRAINT [FK_TimeFrosh_Wanted_Frosh] FOREIGN KEY([IdFactor])
REFERENCES [dbo].[Wanted_Frosh] ([IdFactor])
ON DELETE CASCADE

ALTER TABLE [dbo].[TimeFrosh] CHECK CONSTRAINT [FK_TimeFrosh_Wanted_Frosh]

ALTER TABLE [dbo].[TimeKharid]  WITH CHECK ADD  CONSTRAINT [FK_TimeKharid_Wanted_Kharid] FOREIGN KEY([IdFactor])
REFERENCES [dbo].[Wanted_Kharid] ([IdFactor])
ON DELETE CASCADE

ALTER TABLE [dbo].[TimeKharid] CHECK CONSTRAINT [FK_TimeKharid_Wanted_Kharid]

ALTER TABLE [dbo].[TraceUser]  WITH CHECK ADD  CONSTRAINT [FK_TraceUser_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])
ON DELETE CASCADE

ALTER TABLE [dbo].[TraceUser] CHECK CONSTRAINT [FK_TraceUser_Define_User]

ALTER TABLE [dbo].[Tranlate_Anbar]  WITH CHECK ADD  CONSTRAINT [FK_Tranlate_Anbar_Define_Anbar] FOREIGN KEY([IdOneAnbar])
REFERENCES [dbo].[Define_Anbar] ([ID])

ALTER TABLE [dbo].[Tranlate_Anbar] CHECK CONSTRAINT [FK_Tranlate_Anbar_Define_Anbar]

ALTER TABLE [dbo].[Tranlate_Anbar]  WITH CHECK ADD  CONSTRAINT [FK_Tranlate_Anbar_Define_Anbar1] FOREIGN KEY([IdTwoAnbar])
REFERENCES [dbo].[Define_Anbar] ([ID])

ALTER TABLE [dbo].[Tranlate_Anbar] CHECK CONSTRAINT [FK_Tranlate_Anbar_Define_Anbar1]

ALTER TABLE [dbo].[Tranlate_Anbar]  WITH CHECK ADD  CONSTRAINT [FK_Tranlate_Anbar_Define_Kala] FOREIGN KEY([IdKala])
REFERENCES [dbo].[Define_Kala] ([Id])

ALTER TABLE [dbo].[Tranlate_Anbar] CHECK CONSTRAINT [FK_Tranlate_Anbar_Define_Kala]

ALTER TABLE [dbo].[Tranlate_Anbar]  WITH CHECK ADD  CONSTRAINT [FK_Tranlate_Anbar_Define_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Define_User] ([Id])

ALTER TABLE [dbo].[Tranlate_Anbar] CHECK CONSTRAINT [FK_Tranlate_Anbar_Define_User]

ALTER TABLE [dbo].[User_Access]  WITH CHECK ADD  CONSTRAINT [FK_User_Access_Define_User] FOREIGN KEY([Id])
REFERENCES [dbo].[Define_User] ([Id])
ON DELETE CASCADE

ALTER TABLE [dbo].[User_Access] CHECK CONSTRAINT [FK_User_Access_Define_User]

ALTER TABLE [dbo].[Wanted_Frosh]  WITH CHECK ADD  CONSTRAINT [FK_Wanted_Frosh_ListFactorSell] FOREIGN KEY([IdFactor])
REFERENCES [dbo].[ListFactorSell] ([IdFactor])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[Wanted_Frosh] CHECK CONSTRAINT [FK_Wanted_Frosh_ListFactorSell]

ALTER TABLE [dbo].[Wanted_Kharid]  WITH CHECK ADD  CONSTRAINT [FK_Wanted_Kharid_ListFactorBuy] FOREIGN KEY([IdFactor])
REFERENCES [dbo].[ListFactorBuy] ([IdFactor])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[Wanted_Kharid] CHECK CONSTRAINT [FK_Wanted_Kharid_ListFactorBuy]

