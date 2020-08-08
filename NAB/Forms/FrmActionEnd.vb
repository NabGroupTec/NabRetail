Imports System.Data.SqlClient
Imports System.IO
Imports Ionic.Zip
Imports System.Transactions

Public Class FrmActionEnd
    Dim idperiod As Long = 0
    Dim oldDbName As String = ""
    Public People As Integer
    Public kala As Integer

    Public Function SaveAccounting(ByVal IdAccounting As Long, ByVal Namperiod As String) As String
        PDatabase.Minimum = 0
        PDatabase.Maximum = 15
        PDatabase.Value = 0
        Dim Datas1 As String = "Data Source=127.0.0.1;User ID=" & PublicFunction.UserDB & ";Password=" & PublicFunction.PasswordDB & ";Connection Timeout=0"
        Dim Con1 As New SqlClient.SqlConnection(Datas1)
        Dim DataS2 As String = "Data Source=127.0.0.1;Initial Catalog=Manage_Nab;User ID=" & PublicFunction.UserDB & ";Password=" & PublicFunction.PasswordDB & ";Connection Timeout=0"
        Dim Con2 As New SqlClient.SqlConnection(DataS2)

        If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

        Dim sqltransaction As New CommittableTransaction
        Dim sqltransaction2 As New CommittableTransaction
        Dim IdInsert As Long = 0
        Try
            If Con2.State <> ConnectionState.Open Then Con2.Open()
            If Con1.State <> ConnectionState.Open Then Con1.Open()
            Con2.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////
            PDatabase.Value += 1
            Application.DoEvents()
            Dim Db_name As String = String.Format("DBNab_{0}_", IdAccounting)

            Using cmd As New SqlCommand("SELECT COUNT(Id)+1 FROM List_Period WHERE Id=" & IdAccounting, Con2)
                cmd.CommandTimeout = 0
                Db_name &= cmd.ExecuteScalar()
            End Using
            PDatabase.Value += 1
            Application.DoEvents()

            Using Cmd As New SqlCommand("Insert INTO List_Period(Id,PeriodName,NameEnglish) Values(@Id,@PeriodName,@NameEnglish);Select @@IDENTITY", Con2)
                Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = IdAccounting
                Cmd.Parameters.AddWithValue("@PeriodName", SqlDbType.NVarChar).Value = Namperiod
                Cmd.Parameters.AddWithValue("@NameEnglish", SqlDbType.NVarChar).Value = Db_name
                Cmd.CommandTimeout = 0
                idperiod = Cmd.ExecuteScalar
            End Using
            PDatabase.Value += 1
            Application.DoEvents()

            Using cmd As New SqlCommand(String.Format("SELECT COUNT(name) FROM master.dbo.sysdatabases WHERE name=N'{0}'", CStr(Db_name)), Con1)
                If cmd.ExecuteScalar > 0 Then
                    Using delcmd As New SqlCommand("DROP DATABASE " & CStr(Db_name), Con1)
                        delcmd.ExecuteNonQuery()
                    End Using
                End If
            End Using

            Using cmd As New SqlCommand(String.Format("USE [master] CREATE DATABASE {0} ON  PRIMARY ( NAME = N'{1}', FILENAME = N'{2}\{1}.mdf' , SIZE = 64512KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ) LOG ON ( NAME = N'{1}_log', FILENAME = N'{3}\{1}_log.ldf' , SIZE = 35712KB , MAXSIZE = 2048GB , FILEGROWTH = 10%) ALTER DATABASE [{1}] SET COMPATIBILITY_LEVEL = 120 IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled')) begin EXEC [{1}].[dbo].[sp_fulltext_database] @action = 'enable' end ALTER DATABASE [{1}] SET ANSI_NULL_DEFAULT OFF  ALTER DATABASE [{1}] SET ANSI_NULLS OFF  ALTER DATABASE [{1}] SET ANSI_PADDING OFF  ALTER DATABASE [{1}] SET ANSI_WARNINGS OFF  ALTER DATABASE [{1}] SET ARITHABORT OFF  ALTER DATABASE [{1}] SET AUTO_CLOSE OFF  ALTER DATABASE [{1}] SET AUTO_CREATE_STATISTICS ON  ALTER DATABASE [{1}] SET AUTO_SHRINK OFF  ALTER DATABASE [{1}] SET AUTO_UPDATE_STATISTICS ON  ALTER DATABASE [{1}] SET CURSOR_CLOSE_ON_COMMIT OFF  ALTER DATABASE [{1}] SET CURSOR_DEFAULT  GLOBAL  ALTER DATABASE [{1}] SET CONCAT_NULL_YIELDS_NULL OFF  ALTER DATABASE [{1}] SET NUMERIC_ROUNDABORT OFF  ALTER DATABASE [{1}] SET QUOTED_IDENTIFIER OFF  ALTER DATABASE [{1}] SET RECURSIVE_TRIGGERS OFF  ALTER DATABASE [{1}] SET  DISABLE_BROKER  ALTER DATABASE [{1}] SET AUTO_UPDATE_STATISTICS_ASYNC OFF  ALTER DATABASE [{1}] SET DATE_CORRELATION_OPTIMIZATION OFF  ALTER DATABASE [{1}] SET TRUSTWORTHY OFF  ALTER DATABASE [{1}] SET ALLOW_SNAPSHOT_ISOLATION OFF  ALTER DATABASE [{1}] SET PARAMETERIZATION SIMPLE  ALTER DATABASE [{1}] SET READ_COMMITTED_SNAPSHOT OFF  ALTER DATABASE [{1}] SET HONOR_BROKER_PRIORITY OFF  ALTER DATABASE [{1}] SET  READ_WRITE  ALTER DATABASE [{1}] SET RECOVERY FULL  ALTER DATABASE [{1}] SET  MULTI_USER  ALTER DATABASE [{1}] SET PAGE_VERIFY CHECKSUM  ALTER DATABASE [{1}] SET DB_CHAINING OFF ", CStr(Db_name), Db_name, My.Application.Info.DirectoryPath, My.Application.Info.DirectoryPath), Con1)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            PDatabase.Value += 1
            Application.DoEvents()
            Dim str_bank As String = String.Format("USE {0} {1}", CStr(Db_name), My.Resources.Close)

            Using cmd As New SqlCommand(str_bank, Con1)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            PDatabase.Value += 1
            Application.DoEvents()
            Dim DataSource3 As String = "Data Source=127.0.0.1;Initial Catalog=" + CStr(Db_name) + ";User ID=" & PublicFunction.UserDB & ";Password=" & PublicFunction.PasswordDB & ";Connection Timeout=0"
            Dim ConectionBank3 As New SqlClient.SqlConnection(DataSource3)
            If ConectionBank3.State <> ConnectionState.Open Then ConectionBank3.Open()
            PDatabase.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''''''''انتقال User

            Dim DtUser As New DataTable
            Using cmd As New SqlCommand("SELECT * FROM Define_User ORDER By Id ", ConectionBank)
                cmd.CommandTimeout = 0
                DtUser.Load(cmd.ExecuteReader)
            End Using
            PDatabase.Value += 1
            Application.DoEvents()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT Define_User ON;INSERT INTO Define_User(Id,Nam,TypeImage,Image,Pas,UserLogIn) Values(@Id,@Nam,@TypeImage,@Image,@Pas,@UserLogIn)", ConectionBank3)
                For i As Integer = 0 To DtUser.Rows.Count - 1
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = DtUser.Rows(i).Item("Id")
                    cmd.Parameters.AddWithValue("@Nam", SqlDbType.NVarChar).Value = DtUser.Rows(i).Item("Nam")
                    cmd.Parameters.AddWithValue("@TypeImage", SqlDbType.Int).Value = DtUser.Rows(i).Item("TypeImage")
                    If DtUser.Rows(i).Item("Image") Is DBNull.Value Then
                        cmd.Parameters.AddWithValue("@Image", SqlDbType.VarBinary).Value = System.Data.SqlTypes.SqlBinary.Null
                    Else
                        cmd.Parameters.AddWithValue("@Image", SqlDbType.VarBinary).Value = CType(DtUser.Rows(i).Item("Image"), Byte())
                    End If
                    cmd.Parameters.AddWithValue("@Pas", SqlDbType.VarBinary).Value = IIf(DtUser.Rows(i).Item("Pas") Is DBNull.Value, System.Data.SqlTypes.SqlBinary.Null, CType(DtUser.Rows(i).Item("Pas"), Byte()))
                    cmd.Parameters.AddWithValue("@UserLogIn", SqlDbType.VarBinary).Value = IIf(DtUser.Rows(i).Item("UserLogIn") Is DBNull.Value, System.Data.SqlTypes.SqlBinary.Null, CType(DtUser.Rows(i).Item("UserLogIn"), Byte()))
                    cmd.CommandTimeout = 0
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                Next
            End Using
            PDatabase.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''''''''انتقال Define_Company
            Dim DtCompany As New DataTable
            Using cmd As New SqlCommand("SELECT CompanyName,IdCompany,TelFax,[Address],Header,Footer,BackUpPath,CompanyImage,IdUser FROM Define_Company ORDER BY IdUser", ConectionBank)
                cmd.CommandTimeout = 0
                DtCompany.Load(cmd.ExecuteReader)
            End Using
            PDatabase.Value += 1
            Application.DoEvents()
            Using cmd As New SqlCommand("INSERT INTO Define_Company(CompanyName,IdCompany,TelFax,Address,Header,Footer,BackUpPath,CompanyImage,IdUser) Values(@CompanyName,@IdCompany,@TelFax,@Address,@Header,@Footer,@BackUpPath,@CompanyImage,@IdUser)", ConectionBank3)
                For i As Integer = 0 To DtCompany.Rows.Count - 1
                    cmd.Parameters.AddWithValue("@CompanyName", SqlDbType.NVarChar).Value = DtCompany.Rows(i).Item("CompanyName")
                    cmd.Parameters.AddWithValue("@IdCompany", SqlDbType.NVarChar).Value = DtCompany.Rows(i).Item("IdCompany")
                    cmd.Parameters.AddWithValue("@TelFax", SqlDbType.NVarChar).Value = DtCompany.Rows(i).Item("TelFax")
                    cmd.Parameters.AddWithValue("@Address", SqlDbType.NVarChar).Value = DtCompany.Rows(i).Item("Address")
                    cmd.Parameters.AddWithValue("@Header", SqlDbType.NVarChar).Value = DtCompany.Rows(i).Item("Header")
                    cmd.Parameters.AddWithValue("@Footer", SqlDbType.NVarChar).Value = DtCompany.Rows(i).Item("Footer")
                    cmd.Parameters.AddWithValue("@BackUpPath", SqlDbType.NVarChar).Value = DtCompany.Rows(i).Item("BackUpPath")
                    cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = DtCompany.Rows(i).Item("IdUser")
                    cmd.Parameters.AddWithValue("@CompanyImage", SqlDbType.VarBinary).Value = DtCompany.Rows(i).Item("CompanyImage")
                    cmd.CommandTimeout = 0
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                Next
            End Using
            PDatabase.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''''''''انتقال SettingProgram
            Dim DtSetting As New DataTable
            Using cmd As New SqlCommand("SELECT FactorPaper,TypeFactor,FactorCount,AnbarCount,Get_Pay_Count,FilterKala,TypeKala,FilterP,TypeP,TypeAll,MojodyBox,MojodyBank,MojodyAnbar,S1,S2,S3,S4,S5,S6,S7,S8,S9,S10,S11,S12,S13,S14,S15,S16,S17,S18,S19,S20,S21,S22,S23,S24,S25,S26,S27,S28,S32,IdUser,Barcode,IdAnbar,KalaDup,Fish FROM SettingProgram ORDER BY IdUser", ConectionBank)
                cmd.CommandTimeout = 0
                DtSetting.Load(cmd.ExecuteReader)
            End Using
            PDatabase.Value += 1
            Application.DoEvents()
            Using cmd As New SqlCommand("INSERT INTO SettingProgram (FactorPaper,TypeFactor,FactorCount,AnbarCount,Get_Pay_Count,FilterKala,TypeKala,FilterP,TypeP,TypeAll,MojodyBox,MojodyBank,MojodyAnbar,S1,S2,S3,S4,S5,S6,S7,S8,S9,S10,S11,S12,S13,S14,S15,S16,S17,S18,S19,S20,S21,S22,S23,S24,S25,S26,S27,S28,S32,IdUser,Barcode,IdAnbar,KalaDup,Fish) VALUES (@FactorPaper,@TypeFactor,@FactorCount,@AnbarCount,@Get_Pay_Count,@FilterKala,@TypeKala,@FilterP,@TypeP,@TypeAll,@MojodyBox,@MojodyBank,@MojodyAnbar,@S1,@S2,@S3,@S4,@S5,@S6,@S7,@S8,@S9,@S10,@S11,@S12,@S13,@S14,@S15,@S16,@S17,@S18,@S19,@S20,@S21,@S22,@S23,@S24,@S25,@S26,@S27,@S28,@S32,@IdUser,@Barcode,@IdAnbar,@KalaDup,@Fish)", ConectionBank3)
                For i As Integer = 0 To DtSetting.Rows.Count - 1
                    cmd.Parameters.AddWithValue("@FactorPaper", SqlDbType.Int).Value = DtSetting.Rows(i).Item("FactorPaper")
                    cmd.Parameters.AddWithValue("@TypeFactor", SqlDbType.Int).Value = DtSetting.Rows(i).Item("TypeFactor")
                    cmd.Parameters.AddWithValue("@FactorCount", SqlDbType.Int).Value = DtSetting.Rows(i).Item("FactorCount")
                    cmd.Parameters.AddWithValue("@AnbarCount", SqlDbType.Int).Value = DtSetting.Rows(i).Item("AnbarCount")
                    cmd.Parameters.AddWithValue("@Get_Pay_Count", SqlDbType.Int).Value = DtSetting.Rows(i).Item("Get_Pay_Count")
                    cmd.Parameters.AddWithValue("@FilterKala", SqlDbType.Int).Value = DtSetting.Rows(i).Item("FilterKala")
                    cmd.Parameters.AddWithValue("@TypeKala", SqlDbType.Int).Value = DtSetting.Rows(i).Item("TypeKala")
                    cmd.Parameters.AddWithValue("@FilterP", SqlDbType.Int).Value = DtSetting.Rows(i).Item("FilterP")
                    cmd.Parameters.AddWithValue("@TypeP", SqlDbType.Int).Value = DtSetting.Rows(i).Item("TypeP")
                    cmd.Parameters.AddWithValue("@TypeAll", SqlDbType.Int).Value = DtSetting.Rows(i).Item("TypeAll")
                    cmd.Parameters.AddWithValue("@MojodyBox", SqlDbType.Bit).Value = DtSetting.Rows(i).Item("MojodyBox")
                    cmd.Parameters.AddWithValue("@MojodyBank", SqlDbType.Bit).Value = DtSetting.Rows(i).Item("MojodyBank")
                    cmd.Parameters.AddWithValue("@MojodyAnbar", SqlDbType.Bit).Value = DtSetting.Rows(i).Item("MojodyAnbar")
                    cmd.Parameters.AddWithValue("@S1", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S1")
                    cmd.Parameters.AddWithValue("@S2", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S2")
                    cmd.Parameters.AddWithValue("@S3", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S3")
                    cmd.Parameters.AddWithValue("@S4", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S4")
                    cmd.Parameters.AddWithValue("@S5", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S5")
                    cmd.Parameters.AddWithValue("@S6", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S6")
                    cmd.Parameters.AddWithValue("@S7", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S7")
                    cmd.Parameters.AddWithValue("@S8", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S8")
                    cmd.Parameters.AddWithValue("@S9", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S9")
                    cmd.Parameters.AddWithValue("@S10", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S10")
                    cmd.Parameters.AddWithValue("@S11", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S11")
                    cmd.Parameters.AddWithValue("@S12", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S12")
                    cmd.Parameters.AddWithValue("@S13", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S13")
                    cmd.Parameters.AddWithValue("@S14", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S14")
                    cmd.Parameters.AddWithValue("@S15", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S15")
                    cmd.Parameters.AddWithValue("@S16", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S16")
                    cmd.Parameters.AddWithValue("@S17", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S17")
                    cmd.Parameters.AddWithValue("@S18", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S18")
                    cmd.Parameters.AddWithValue("@S19", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S19")
                    cmd.Parameters.AddWithValue("@S20", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S20")
                    cmd.Parameters.AddWithValue("@S21", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S21")
                    cmd.Parameters.AddWithValue("@S22", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S22")
                    cmd.Parameters.AddWithValue("@S23", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S23")
                    cmd.Parameters.AddWithValue("@S24", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S24")
                    cmd.Parameters.AddWithValue("@S25", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S25")
                    cmd.Parameters.AddWithValue("@S26", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S26")
                    cmd.Parameters.AddWithValue("@S27", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S27")
                    cmd.Parameters.AddWithValue("@S28", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S28")
                    cmd.Parameters.AddWithValue("@S32", SqlDbType.NVarChar).Value = DtSetting.Rows(i).Item("S32")
                    cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = DtSetting.Rows(i).Item("IdUser")
                    cmd.Parameters.AddWithValue("@Barcode", SqlDbType.Bit).Value = False
                    cmd.Parameters.AddWithValue("@Idanbar", SqlDbType.BigInt).Value = DBNull.Value
                    cmd.Parameters.AddWithValue("@KalaDup", SqlDbType.Bit).Value = False
                    cmd.Parameters.AddWithValue("@Fish", SqlDbType.Bit).Value = False
                    cmd.CommandTimeout = 0
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                Next
            End Using
            PDatabase.Value += 1
            Application.DoEvents()

            ''''''''''''''''''''''''''افزودن تابع GetCost
            Using CMD As New SqlCommand("IF OBJECT_ID (N'GetCost', N'FN') IS NOT NULL DROP FUNCTION GetCost", ConectionBank3)
                CMD.ExecuteNonQuery()
            End Using

            Using CMD As New SqlCommand("CREATE FUNCTION GetCost (@Idkala Bigint,@co Float,@Str Nvarchar(Max),@Dat1 Nvarchar(Max),@Dat2 Nvarchar(Max),@discount Bit) RETURNS Bigint WITH EXECUTE AS CALLER AS BEGIN DECLARE @Result Bigint IF @co>0 BEGIN DECLARE @count Float DECLARE @Row Bigint DECLARE @Mon bigint DECLARE @DarsadMon bigint DECLARE @TmpMon Float DECLARE @TmpDarsadMon Float DECLARE @Tmpcount Float DECLARE @TmpDiff Float DECLARE @tbl Table(row_num bigint,cnt bigint,JozCount Float,KolCount Float,Mon bigint,DarsadMon Bigint) IF (@Dat1='' AND @Dat2='') BEGIN INSERT INTO @tbl (row_num,cnt,JozCount,KolCount,Mon,DarsadMon) (SELECT row_number() over (order by d_date,Id) row_num,count(*) over () cnt,JozCount,KolCount,Mon,DarsadMon FROM (SELECT KalaFactorBuy.IdFactor As Id,KalaFactorBuy.JozCount, KalaFactorBuy.KolCount, KalaFactorBuy.Mon,KalaFactorBuy.DarsadMon,ListFactorBuy.D_date  FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (Stat =0 and ListFactorBuy.Activ =1 AND IdKala =@Idkala) UNION ALL SELECT ID,Count_Joz AS JozCount,Count_Kol AS KolCount, Mon,DarsadMon=0, D_date FROM Define_PrimaryKala WHERE IdKala =@Idkala) AS listkala) END ELSE IF (@Dat1<>'' AND @Dat2='') BEGIN INSERT INTO @tbl (row_num,cnt,JozCount,KolCount,Mon,DarsadMon) (SELECT row_number() over (order by d_date,Id) row_num,count(*) over () cnt,JozCount,KolCount,Mon,DarsadMon FROM (SELECT KalaFactorBuy.IdFactor As Id,KalaFactorBuy.JozCount, KalaFactorBuy.KolCount, KalaFactorBuy.Mon,KalaFactorBuy.DarsadMon,ListFactorBuy.D_date  FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (Stat =0 and ListFactorBuy.Activ =1 AND IdKala =@Idkala) AND(D_date <@Dat1) UNION ALL SELECT ID,Count_Joz AS JozCount,Count_Kol AS KolCount, Mon,DarsadMon=0, D_date FROM Define_PrimaryKala WHERE IdKala =@Idkala AND (D_date <@Dat1)) AS listkala) END ELSE IF (@Dat1='' AND @Dat2<>'') BEGIN INSERT INTO @tbl (row_num,cnt,JozCount,KolCount,Mon,DarsadMon) (SELECT row_number() over (order by d_date,Id) row_num,count(*) over () cnt,JozCount,KolCount,Mon,DarsadMon FROM (SELECT KalaFactorBuy.IdFactor As Id,KalaFactorBuy.JozCount, KalaFactorBuy.KolCount, KalaFactorBuy.Mon,KalaFactorBuy.DarsadMon,ListFactorBuy.D_date  FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (Stat =0 and ListFactorBuy.Activ =1 AND IdKala =@Idkala) AND(D_date <=@Dat2) UNION ALL SELECT ID,Count_Joz AS JozCount,Count_Kol AS KolCount,Mon,DarsadMon=0, D_date FROM Define_PrimaryKala WHERE IdKala =@Idkala AND (D_date <=@Dat2)) AS listkala) END SET @count =0 SET @Mon =0 SET @DarsadMon =0 SET @Row = (SELECT MAX(cnt) FROM @tbl) WHILE @count <@co AND @Row >0 BEGIN SET @Tmpcount = (SELECT CASE WHEN @Str=N'JOZ' THEN JozCount ELSE KolCount END FROM @tbl WHERE row_num =@Row ) IF ((@Tmpcount+@count)<=@co) BEGIN SET @count =@count + @Tmpcount SET @Mon =@Mon +(SELECT Mon FROM @tbl WHERE row_num =@Row) SET @DarsadMon =@DarsadMon +(SELECT DarsadMon FROM @tbl WHERE row_num =@Row) SET @Row =@Row -1 END ELSE IF ((@Tmpcount+@count)>@co) BEGIN SET @TmpDiff=(@co-@count) SET @count =@count+@TmpDiff SET @Mon =@Mon + ((@TmpDiff*(SELECT Mon FROM @tbl WHERE row_num =@Row ))/@Tmpcount) SET @DarsadMon =@DarsadMon + CASE WHEN (SELECT Mon FROM @tbl WHERE row_num =@Row )=0 THEN 0 ELSE (((@TmpDiff*(SELECT Mon FROM @tbl WHERE row_num =@Row ))/@Tmpcount)*(SELECT DarsadMon FROM @tbl WHERE row_num =@Row)/(SELECT Mon FROM @tbl WHERE row_num =@Row )) END SET @Row =@Row -1 END END SET @Result= (CASE WHEN (@count=0 OR @Mon=0) THEN 0 ELSE ISNULL(ROUND((CASE WHEN @discount='False' THEN @Mon ELSE @Mon-@DarsadMon END)/@count,0),0) END) END ELSE IF @co<0 BEGIN SET @Result=(SELECT ISNULL(ROUND((CASE WHEN @discount='False' THEN Mon ELSE Mon-DarsadMon END)/(CASE WHEN @Str=N'JOZ' THEN (CASE WHEN JozCount=0 THEN 1 ELSE JozCount END) ELSE (CASE WHEN KolCount=0 THEN 1 ELSE KolCount END) END),0),0) AS EndCostKala  FROM (SELECT ISNULL(SUM(KolCount),0) AS KolCount, ISNULL(SUM(JozCount),0) As JozCount, ISNULL(SUM(Mon),0) AS Mon,ISNULL(SUM(DarsadMon),0) AS DarsadMon FROM (SELECT TOP 1 KolCount, JozCount,Mon,DarsadMon FROM (SELECT  KolCount, JozCount, DarsadMon, Mon, D_date FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (Stat =0 and ListFactorBuy.Activ =1 AND Mon >0 AND IdKala =@Idkala) UNION ALL SELECT  Count_Kol as KolCount,Count_Joz as JozCount,DarsadMon=0,Mon ,D_date   FROM Define_PrimaryKala WHERE (Mon >0 AND IdKala =@Idkala))AS CostKala ORDER BY D_date DESC) AS Edata) As E2Data) END ELSE IF @co=0 BEGIN SET @Result=0 END RETURN @Result END", ConectionBank3)
                CMD.ExecuteNonQuery()
            End Using

            ''''''''''''''''''''''''''افزودن تابع RateFactor
            Using CMD As New SqlCommand("IF OBJECT_ID (N'RateFactor', N'FN') IS NOT NULL DROP FUNCTION RateFactor", ConectionBank3)
                CMD.ExecuteNonQuery()
            End Using

            Using CMD As New SqlCommand("CREATE FUNCTION RateFactor (@Idkala Bigint,@IdFac Bigint,@MonFac Bigint,@outp nvarchar(max)) RETURNS Nvarchar(Max) WITH EXECUTE AS CALLER AS BEGIN DECLARE @Result Nvarchar(Max) DECLARE @Ras Nvarchar(Max) DECLARE @count Bigint DECLARE @Row Bigint DECLARE @i Bigint DECLARE @Tmpcount Bigint DECLARE @tbl Table(row_num bigint,D_date Nvarchar(Max),Pay bigint) INSERT INTO @tbl (row_num,D_date,Pay) (SELECT row_number() over (order by D_date) row_num,D_date,Pay FROM (SELECT ISNULL(PayLimitFrosh.Pay,0) AS Pay, Get_Pay_Sanad.D_date FROM PayLimitFrosh INNER JOIN Get_Pay_Sanad ON PayLimitFrosh.IdSanad = Get_Pay_Sanad.Id WHERE PayLimitFrosh.IdFactor =@IdFac AND PayLimitFrosh.Pay>0 UNION ALL SELECT ISNULL((Cash+MonHavaleh +MonPayChk+Discount),0),D_date FROM ListFactorSell WHERE IdFactor=@IdFac AND (Cash+MonHavaleh +MonPayChk+Discount)>0 UNION ALL SELECT AddPayLimitFrosh.Pay , ListFactorSell.D_date FROM AddPayLimitFrosh INNER JOIN ListFactorSell ON AddPayLimitFrosh.IdFactor =ListFactorSell.IdFactor  WHERE  AddPayLimitFrosh.IdFactor =@IdFac UNION ALL SELECT ISNULL(SUM(Mon-DarsadMon),0) AS Pay,D_date FROM KalaKasriFactor INNER JOIN ListKasriFactor ON KalaKasriFactor.IdFactor = ListKasriFactor.IdFactor WHERE ListKasriFactor.IdFactor =@IdFac AND IdR =@Idkala AND Mon-DarsadMon>0 GROUP By D_date UNION ALL SELECT ISNULL(SUM(Mon-DarsadMon),0) AS Pay,D_date FROM KalaFactorbackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE KalaFactorBackSell.IdKala =@Idkala AND ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdFacSell =@IdFac GROUP BY D_date )AS ListRate) SET @count =0 SET @i =1 SET @Row = (SELECT MAX(row_num) FROM @tbl) SET @Ras='' WHILE @count <=@MonFac AND @i <=@Row BEGIN SET @Tmpcount = (SELECT ISNULL(SUM(Pay),0) FROM @tbl WHERE row_num =@i) IF ((@Tmpcount+@count)<@MonFac) BEGIN SET @count =@count + @Tmpcount SET @Ras =@Ras + (SELECT D_date FROM @tbl WHERE row_num =@i) + ',' + CAST(ROUND(@Tmpcount,0) AS Nvarchar(max)) + ';' SET @Tmpcount =0 SET @i =@i+1 END ELSE IF ((@Tmpcount+@count)>=@MonFac) BEGIN SET @Ras =@Ras + (SELECT D_date FROM @tbl WHERE row_num =@i) + ',' + CAST(ROUND(@Tmpcount,0) AS Nvarchar(max)) + ';' Break END END SET @Result= (CASE WHEN @outp='DAT' THEN (SELECT D_date FROM @tbl WHERE row_num =@i)  WHEN @outp='PAY' THEN CAST(ROUND(@Tmpcount+@count,0) AS nvarchar(max)) WHEN @outp='ROW' THEN CAST(@i AS nvarchar(max)) WHEN @outp='RAS' THEN @Ras END) RETURN @Result END", ConectionBank3)
                CMD.ExecuteNonQuery()
            End Using

            ''''''''''''''''''''''''''افزودن تابع GetCostCharge
            Using CMD As New SqlCommand("IF OBJECT_ID (N'GetCostCharge', N'FN') IS NOT NULL DROP FUNCTION GetCostCharge", ConectionBank3)
                CMD.ExecuteNonQuery()
            End Using

            Using CMD As New SqlCommand("CREATE FUNCTION GetCostCharge (@Idkala Bigint,@co Float,@Str Nvarchar(Max),@Dat1 Nvarchar(Max),@Dat2 Nvarchar(Max),@discount Bit) RETURNS Bigint WITH EXECUTE AS CALLER AS BEGIN DECLARE @Result Bigint IF @co>0 BEGIN DECLARE @count Float DECLARE @Row Bigint DECLARE @Mon bigint DECLARE @DarsadMon bigint DECLARE @TmpMon Float DECLARE @TmpDarsadMon Float DECLARE @Tmpcount Float DECLARE @TmpDiff Float DECLARE @tbl Table(row_num bigint,cnt bigint,JozCount Float,KolCount Float,Mon bigint,DarsadMon Bigint) IF (@Dat1='' AND @Dat2='') BEGIN INSERT INTO @tbl (row_num,cnt,JozCount,KolCount,Mon,DarsadMon) (SELECT row_number() over (order by d_date,Id) row_num,count(*) over () cnt,JozCount,KolCount,Mon,DarsadMon FROM (SELECT KalaFactorBuy.IdFactor As Id,KalaFactorBuy.JozCount, KalaFactorBuy.KolCount, KalaFactorBuy.Mon +(CAST(KalaFactorBuy.Mon AS Float) * (SELECT  ISNULL(SUM(Mon),0)  FROM  ListFactorCharge INNER JOIN KalaFactorCharge ON ListFactorCharge.Id = KalaFactorCharge.IdSanad WHERE  ListFactorCharge.IdFactor =ListFactorBuy.IdFactor  AND ListFactorCharge.Activ =1))/((SELECT  ISNULL(SUM(Mon),0)  FROM  KalaFactorBuy  WHERE  KalaFactorBuy.IdFactor =ListFactorBuy.IdFactor  AND KalaFactorBuy.Activ =1)) AS Mon,KalaFactorBuy.DarsadMon,ListFactorBuy.D_date  FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (Stat =0 and ListFactorBuy.Activ =1 AND IdKala =@Idkala) UNION ALL SELECT ID,Count_Joz AS JozCount,Count_Kol AS KolCount, Mon,DarsadMon=0, D_date FROM Define_PrimaryKala WHERE IdKala =@Idkala) AS listkala) END ELSE IF (@Dat1<>'' AND @Dat2='') BEGIN INSERT INTO @tbl (row_num,cnt,JozCount,KolCount,Mon,DarsadMon) (SELECT row_number() over (order by d_date,Id) row_num,count(*) over () cnt,JozCount,KolCount,Mon,DarsadMon FROM (SELECT KalaFactorBuy.IdFactor As Id,KalaFactorBuy.JozCount, KalaFactorBuy.KolCount, KalaFactorBuy.Mon +(CAST(KalaFactorBuy.Mon AS Float) * (SELECT  ISNULL(SUM(Mon),0)  FROM  ListFactorCharge INNER JOIN KalaFactorCharge ON ListFactorCharge.Id = KalaFactorCharge.IdSanad WHERE  ListFactorCharge.IdFactor =ListFactorBuy.IdFactor  AND ListFactorCharge.Activ =1))/((SELECT  ISNULL(SUM(Mon),0)  FROM  KalaFactorBuy  WHERE  KalaFactorBuy.IdFactor =ListFactorBuy.IdFactor  AND KalaFactorBuy.Activ =1)) AS Mon,KalaFactorBuy.DarsadMon,ListFactorBuy.D_date  FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (Stat =0 and ListFactorBuy.Activ =1 AND IdKala =@Idkala) AND(D_date <@Dat1) UNION ALL SELECT ID,Count_Joz AS JozCount,Count_Kol AS KolCount, Mon,DarsadMon=0, D_date FROM Define_PrimaryKala WHERE IdKala =@Idkala AND (D_date <@Dat1)) AS listkala) END ELSE IF (@Dat1='' AND @Dat2<>'') BEGIN INSERT INTO @tbl (row_num,cnt,JozCount,KolCount,Mon,DarsadMon) (SELECT row_number() over (order by d_date,Id) row_num,count(*) over () cnt,JozCount,KolCount,Mon,DarsadMon FROM (SELECT KalaFactorBuy.IdFactor As Id,KalaFactorBuy.JozCount, KalaFactorBuy.KolCount, KalaFactorBuy.Mon +(CAST(KalaFactorBuy.Mon AS Float) * (SELECT  ISNULL(SUM(Mon),0)  FROM  ListFactorCharge INNER JOIN KalaFactorCharge ON ListFactorCharge.Id = KalaFactorCharge.IdSanad WHERE  ListFactorCharge.IdFactor =ListFactorBuy.IdFactor  AND ListFactorCharge.Activ =1))/((SELECT  ISNULL(SUM(Mon),0)  FROM  KalaFactorBuy  WHERE  KalaFactorBuy.IdFactor =ListFactorBuy.IdFactor  AND KalaFactorBuy.Activ =1)) AS Mon,KalaFactorBuy.DarsadMon,ListFactorBuy.D_date  FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (Stat =0 and ListFactorBuy.Activ =1 AND IdKala =@Idkala) AND(D_date <=@Dat2) UNION ALL SELECT ID,Count_Joz AS JozCount,Count_Kol AS KolCount,Mon,DarsadMon=0, D_date FROM Define_PrimaryKala WHERE IdKala =@Idkala AND (D_date <=@Dat2)) AS listkala) END SET @count =0 SET @Mon =0 SET @DarsadMon =0 SET @Row = (SELECT MAX(cnt) FROM @tbl) WHILE @count <@co AND @Row >0 BEGIN SET @Tmpcount = (SELECT CASE WHEN @Str=N'JOZ' THEN JozCount ELSE KolCount END FROM @tbl WHERE row_num =@Row ) IF ((@Tmpcount+@count)<=@co) BEGIN SET @count =@count + @Tmpcount SET @Mon =@Mon +(SELECT Mon FROM @tbl WHERE row_num =@Row ) SET @DarsadMon =@DarsadMon +(SELECT DarsadMon FROM @tbl WHERE row_num =@Row ) SET @Row =@Row -1 END ELSE IF ((@Tmpcount+@count)>@co) BEGIN SET @TmpDiff=(@co-@count) SET @count =@count+@TmpDiff SET @Mon =@Mon + ((@TmpDiff*(SELECT Mon FROM @tbl WHERE row_num =@Row ))/@Tmpcount) SET @DarsadMon =@DarsadMon + CASE WHEN (SELECT Mon FROM @tbl WHERE row_num =@Row )=0 THEN 0 ELSE (((@TmpDiff*(SELECT Mon FROM @tbl WHERE row_num =@Row ))/@Tmpcount)*(SELECT DarsadMon FROM @tbl WHERE row_num =@Row)/(SELECT Mon FROM @tbl WHERE row_num =@Row )) END SET @Row =@Row -1 END END SET @Result= (CASE WHEN (@count=0 OR @Mon=0) THEN 0 ELSE ISNULL(ROUND((CASE WHEN @discount='False' THEN @Mon ELSE @Mon-@DarsadMon END)/@count,0),0) END) END ELSE IF @co<0 BEGIN SET @Result=(SELECT ISNULL(ROUND((CASE WHEN @discount='False' THEN Mon ELSE Mon-DarsadMon END)/(CASE WHEN @Str=N'JOZ' THEN (CASE WHEN JozCount=0 THEN 1 ELSE JozCount END) ELSE (CASE WHEN KolCount=0 THEN 1 ELSE KolCount END) END),0),0) AS EndCostKala  FROM (SELECT ISNULL(SUM(KolCount),0) AS KolCount, ISNULL(SUM(JozCount),0) As JozCount, ISNULL(SUM(Mon),0) AS Mon,ISNULL(SUM(DarsadMon),0) AS DarsadMon FROM (SELECT TOP 1 KolCount, JozCount,Mon,DarsadMon FROM (SELECT  KolCount, JozCount, DarsadMon, KalaFactorBuy.Mon +(KalaFactorBuy.Mon * (SELECT  ISNULL(SUM(Mon),0)  FROM  ListFactorCharge INNER JOIN KalaFactorCharge ON ListFactorCharge.Id = KalaFactorCharge.IdSanad WHERE  ListFactorCharge.IdFactor =ListFactorBuy.IdFactor  AND ListFactorCharge.Activ =1))/((SELECT  ISNULL(SUM(Mon),0)  FROM  KalaFactorBuy  WHERE  KalaFactorBuy.IdFactor =ListFactorBuy.IdFactor  AND KalaFactorBuy.Activ =1)) AS Mon, D_date FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (Stat =0 and ListFactorBuy.Activ =1 AND Mon >0 AND IdKala =@Idkala) UNION ALL SELECT  Count_Kol as KolCount,Count_Joz as JozCount,DarsadMon=0,Mon ,D_date   FROM Define_PrimaryKala WHERE (Mon >0 AND IdKala =@Idkala))AS CostKala ORDER BY D_date DESC) AS Edata) As E2Data) END ELSE IF @co=0 BEGIN SET @Result=0 END RETURN @Result END", ConectionBank3)
                CMD.ExecuteNonQuery()
            End Using

            ''''''''''''''''''''''''''افزودن تابع GetSodFactor
            Using CMD As New SqlCommand("IF OBJECT_ID (N'GetSodFactor', N'FN') IS NOT NULL DROP FUNCTION GetSodFactor", ConectionBank3)
                CMD.ExecuteNonQuery()
            End Using

            Using CMD As New SqlCommand("CREATE FUNCTION GetSodFactor (@IdFactor Bigint,@Str Nvarchar(Max),@Dat1 Nvarchar(Max),@discount Bit) RETURNS Bigint WITH EXECUTE AS CALLER AS BEGIN DECLARE @Result Bigint If @Str='F' BEGIN SET @Result = (SELECT ISNULL(SUM(AllMon),0) AS Sod FROM (SELECT Mon-(CASE WHEN IdService IS NULL THEN dbo .GetCostCharge (ListKala.IdKala ,(Case WHEN ListKala.JozCount >0 THEN ListKala.JozCount ELSE ListKala.KolCount END),(Case WHEN ListKala.JozCount >0 THEN 'Joz' ELSE 'Kol' END),'',@Dat1,'True') * (Case WHEN ListKala.JozCount >0 THEN ListKala.JozCount ELSE ListKala.KolCount END) ELSE 0 END) AS AllMon FROM (SELECT IdKala ,IdService ,KolCount, JozCount ,(CASE WHEN @discount='False' THEN Mon ELSE Mon-DarsadMon END) AS Mon FROM  KalaFactorSell WHERE IdFactor =@IdFactor) AS ListKala) AS AllSod) END ELSE IF @Str='BF' BEGIN SET @Result = (SELECT ISNULL(SUM(AllMon),0) AS Sod FROM (SELECT Mon-dbo.GetCostCharge (ListKala.IdKala ,(Case WHEN ListKala.JozCount >0 THEN ListKala.JozCount ELSE ListKala.KolCount END),(Case WHEN ListKala.JozCount >0 THEN 'Joz' ELSE 'Kol' END),'',@Dat1,'True') * (Case WHEN ListKala.JozCount >0 THEN ListKala.JozCount ELSE ListKala.KolCount END) AS AllMon FROM (SELECT IdKala ,KolCount, JozCount ,(CASE WHEN @discount='False' THEN Mon ELSE Mon-DarsadMon END) AS Mon FROM  KalaFactorBackSell WHERE IdFactor =@IdFactor AND IdService IS NULL) AS ListKala) AS AllSod) END ELSE IF @Str='KF' BEGIN SET @Result = (SELECT ISNULL(SUM(AllMon),0) AS Sod FROM (SELECT Mon-dbo.GetCostCharge (ListKala.IdKala ,(Case WHEN ListKala.JozCount >0 THEN ListKala.JozCount ELSE ListKala.KolCount END),(Case WHEN ListKala.JozCount >0 THEN 'Joz' ELSE 'Kol' END),'',@Dat1,'True') * (Case WHEN ListKala.JozCount >0 THEN ListKala.JozCount ELSE ListKala.KolCount END) AS AllMon FROM (SELECT IdR AS IdKala ,KolCount, JozCount ,(CASE WHEN @discount='False' THEN Mon ELSE Mon-DarsadMon END) AS Mon FROM  KalaKasriFactor WHERE IdFactor =@IdFactor ) AS ListKala) AS AllSod) END RETURN @Result END", ConectionBank3)
                CMD.ExecuteNonQuery()
            End Using

            ''''''''''''''''''''''''''تنظیم DB_Info
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey
            Using CMD As New SqlCommand("INSERT INTO DB_Info(Version,AllowAdd) VALUES (@Version,@AllowAdd)", ConectionBank3)
                CMD.Parameters.AddWithValue("@Version", SqlDbType.VarBinary).Value = Sec.StringEncrypt("6.15", key.CreateEncryptor)
                CMD.Parameters.AddWithValue("@AllowAdd", SqlDbType.VarBinary).Value = Sec.StringEncrypt("0", key.CreateEncryptor)
                CMD.CommandTimeout = 0
                CMD.ExecuteNonQuery()
            End Using
            PDatabase.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''''''''انتقال User_Access
           
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.User_Access  SELECT * FROM " & oldDbName & ".dbo.User_Access", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using

            PDatabase.Value += 1
            Application.DoEvents()

            sqltransaction.Commit()
            sqltransaction.Dispose()

            If Con1.State <> ConnectionState.Closed Then Con1.Close()
            If Con2.State <> ConnectionState.Closed Then Con2.Close()
            If ConectionBank3.State <> ConnectionState.Closed Then ConectionBank3.Close()
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDatabase.Value += 1
            Application.DoEvents()
            Return Db_name
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmActionEnd", "SaveAccounting")
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmActionEnd", "SaveAccounting")
            End If
            If Con1.State <> ConnectionState.Closed Then Con1.Close()
            If Con2.State <> ConnectionState.Closed Then Con2.Close()
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return ""
        End Try
    End Function

    Private Sub FrmActionEnd_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If BtnSave.Enabled = True Then Call BtnSave_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmActionEnd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Dim x() As String = Nothing
        x = DataSource.Split(";")
        For Each s In x
            If s.Contains("Initial Catalog") Then
                oldDbName = s.Replace("Initial Catalog=", "")
                Exit For
            End If
        Next
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        BtnSave.Enabled = False
        '''''''''''''''''''''''غیر فعال کردن کاربران
        If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

        Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
        Dim Sec As New Security()
        key.IV = Sec.Kiv
        key.Key = Sec.Kkey

        Using CMD As New SqlCommand("Update Define_User Set UserLogIn=@UserLogIn", ConectionBank)
            CMD.Parameters.AddWithValue("@UserLogIn", SqlDbType.VarBinary).Value = Sec.StringEncrypt("0", key.CreateEncryptor)
            CMD.CommandTimeout = 0
            CMD.ExecuteNonQuery()
        End Using
        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

        '''''''''''''''''''''''ساخت نسخه پشتیبان 
        PicBackUp.Image = My.Resources.Process
        Application.DoEvents()
        If BackUp() Then
            PicBackUp.Image = My.Resources.Succed
            Application.DoEvents()
        Else
            PicBackUp.Image = My.Resources._Error
            Application.DoEvents()
            Me.Close()
            Exit Sub
        End If
        '''''''''''''''''''''''ساخت دوره مالی 
        PicDatabase.Image = My.Resources.Process
        Application.DoEvents()
        Dim DB_name As String = SaveAccounting(Id_Account, LNam.Text)
        If String.IsNullOrEmpty(DB_name) Then
            PicDatabase.Image = My.Resources._Error
            Application.DoEvents()
            MessageBox.Show("عملیات بستن دوره مالی در بخش ساخت دوره مالی با شکست مواجه شد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Exit Sub
        Else
            PicDatabase.Image = My.Resources.Succed
            Application.DoEvents()
        End If
        '''''''''''''''''''''''تعاریف اولیه 
        PicDefine.Image = My.Resources.Process
        Application.DoEvents()
        If SaveDefine(DB_name) Then
            PicDefine.Image = My.Resources.Succed
            Application.DoEvents()
        Else
            PicDefine.Image = My.Resources._Error
            Application.DoEvents()
            MessageBox.Show("عملیات بستن دوره مالی در بخش انتقال تعاریف اولیه با شکست مواجه شد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Exit Sub
        End If

        '''''''''''''''''''''''کالا 
        PicKala.Image = My.Resources.Process
        Application.DoEvents()
        If SaveKala(DB_name) Then
            PicKala.Image = My.Resources.Succed
            Application.DoEvents()
        Else
            PicKala.Image = My.Resources._Error
            Application.DoEvents()
            MessageBox.Show("عملیات بستن دوره مالی در بخش انتقال کالا با شکست مواجه شد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Exit Sub
        End If

        '''''''''''''''''''''''روابط 
        PicR.Image = My.Resources.Process
        Application.DoEvents()
        If SaveRelation(DB_name) Then
            PicR.Image = My.Resources.Succed
            Application.DoEvents()
        Else
            PicR.Image = My.Resources._Error
            Application.DoEvents()
            MessageBox.Show("عملیات بستن دوره مالی در بخش روابط با شکست مواجه شد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Exit Sub
        End If

        '''''''''''''''''''''''موجودی اولیه کالا
        PicMKala.Image = My.Resources.Process
        Application.DoEvents()
        If SaveMojodyKala(DB_name) Then
            PicMKala.Image = My.Resources.Succed
            Application.DoEvents()
        Else
            PicMKala.Image = My.Resources._Error
            Application.DoEvents()
            MessageBox.Show("عملیات بستن دوره مالی در بخش موجودی اولیه کالا با شکست مواجه شد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Exit Sub
        End If

        '''''''''''''''''''''''موجودی اولیه اسناد
        PicChk.Image = My.Resources.Process
        Application.DoEvents()
        If SaveMojodyChk(DB_name) Then
            PicChk.Image = My.Resources.Succed
            Application.DoEvents()
        Else
            PicChk.Image = My.Resources._Error
            Application.DoEvents()
            MessageBox.Show("عملیات بستن دوره مالی در بخش موجودی اولیه اسناد با شکست مواجه شد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Exit Sub
        End If
        '''''''''''''''''''''''حذف اطلاعات طرف حساب
        If People <> -1 Then
            If Me.DelPeople(DB_name) = False Then
                Application.DoEvents()
                MessageBox.Show("عملیات حذف طرف حساب با شکست مواجه شد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        '''''''''''''''''''''''حذف اطلاعات کالا
        If kala <> -1 Then
            If Me.DelKala(DB_name) = False Then
                Application.DoEvents()
                MessageBox.Show("عملیات حذف کالا با شکست مواجه شد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        MessageBox.Show("عملیات بستن دوره مالی با موفقیت به اتمام رسید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)

        QExit = True
        System.Windows.Forms.Application.Restart()
    End Sub

    Private Function BackUp() As Boolean
        PBackUp.Minimum = 0
        PBackUp.Maximum = 7
        PBackUp.Value = 0
        Dim backPath As String = ""
        If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
        PBackUp.Value += 1
        Application.DoEvents()
        Try

            Using CMD As New SqlCommand("SELECT TOP 1 BackUpPath FROM Define_Company Where IdUser=" & Id_User, ConectionBank)
                backPath = CMD.ExecuteScalar
                If String.IsNullOrEmpty(backPath) Then backPath = "C:\"
            End Using
        Catch ex As Exception
            backPath = "C:\"
        End Try
        PBackUp.Value += 1
        Application.DoEvents()
        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Try
            If Directory.Exists(backPath) Then
                Dim str_path As String = CreatePath(backPath)
                If String.IsNullOrEmpty(str_path) Then
                    MessageBox.Show("مسیر تهیه نسخه پشتیبان قابل ساختن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If

                PBackUp.Value += 1
                Application.DoEvents()

                Dim SqlCon As New SqlConnection("Data Source=LocalHost;User ID=" & PublicFunction.UserDB & ";Password=" & PublicFunction.PasswordDB)
                If SqlCon.State <> ConnectionState.Open Then SqlCon.Open()

                Dim dt As New DataTable
                Using CMDSelect As New SqlCommand("SELECT NameEnglish FROM [Manage_Nab].[dbo].[List_Period]", SqlCon)
                    CMDSelect.CommandTimeout = 0
                    dt.Load(CMDSelect.ExecuteReader)
                End Using
                PBackUp.Value += 1
                Application.DoEvents()

                For i As Integer = 0 To dt.Rows.Count - 1
                    Using CMD As New SqlCommand("BACKUP DATABASE " & dt.Rows(i).Item("NameEnglish") & " TO DISK = N'" & str_path & "\Info" & dt.Rows(i).Item("NameEnglish").ToString.Replace("DBNab", "") & ".BAK'", SqlCon)
                        CMD.CommandTimeout = 0
                        CMD.ExecuteNonQuery()
                    End Using
                Next

                PBackUp.Value += 1
                Application.DoEvents()

                Using CMD As New SqlCommand("BACKUP DATABASE Manage_Nab TO DISK = N'" & str_path & "\Account.BAK'", SqlCon)
                    CMD.CommandTimeout = 0
                    CMD.ExecuteNonQuery()
                End Using

                PBackUp.Value += 1
                Application.DoEvents()

                If SqlCon.State <> ConnectionState.Closed Then SqlCon.Close()

                '''''''''''''''''''''''''''''''''ZipFolder
                Try
                    Using Ziper As ZipFile = New ZipFile
                        Ziper.AddDirectory(str_path)
                        Ziper.ProvisionalAlternateEncoding = System.Text.Encoding.UTF8
                        Ziper.Save(str_path & ".Nab")
                        Directory.Delete(str_path, True)
                    End Using
                Catch ex As Exception
                    Try
                        Directory.Delete(str_path, True)
                    Catch e2 As Exception

                    End Try
                    MessageBox.Show("مشکلی در ساخت نسخه پشتیبان به وجود آمده است لطفا از درایو غیر ویندوز جهت تهیه نسخه پشتیبان استفاده کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End Try
                '''''''''''''''''''''''''''''''''
                PBackUp.Value += 1
                Application.DoEvents()
                Return True

            Else
                MessageBox.Show("مسير مورد نظر جهت ساخت نسخه پشتیبان وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("بانک اطلاعات در حال استفاده میباشد و فعلا عملیات پشتیبان گیری امکان پذیر نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmActionEnd", "BackUp")
            End If
            Return False
        End Try
    End Function

    Private Function CreatePath(ByVal path As String) As String
        Try
            Dim t_time As String = GetDate().Replace("/", "-") & "  " & Date.Now.ToLongTimeString.Replace(":", "-")
            If path(path.Length - 1) <> "\" Then
                Directory.CreateDirectory(path + "\" + t_time)
                Return path + "\" + t_time
            Else
                Directory.CreateDirectory(path + t_time)
                Return path + t_time
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function SaveDefine(ByVal Db_name As String) As Boolean
        Try
            PDefine.Minimum = 0
            PDefine.Maximum = 22
            PDefine.Value = 0
            ''''''''''''''''''''استان
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_Ostan ON;INSERT INTO " & Db_name & ".dbo.Define_Ostan(Code ,NamO ,TellO) SELECT Code ,NamO ,TellO FROM " & oldDbName & ".dbo.Define_Ostan", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''شهرستان
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_City ON;INSERT INTO " & Db_name & ".dbo.Define_City(Code,NamCI,TellCI,IdOstan) SELECT Code,NamCI,TellCI,IdOstan FROM " & oldDbName & ".dbo.Define_City", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''مسیر
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_Part ON;INSERT INTO " & Db_name & ".dbo.Define_Part(Code,NamP,AddP,IdOstan,IdCity) SELECT Code,NamP,AddP,IdOstan,IdCity FROM " & oldDbName & ".dbo.Define_Part", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''گروهای ویژه
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_Group_P ON;INSERT INTO " & Db_name & ".dbo.Define_Group_P (Id,nam,Cash1,Cash2,Cash3,Cash4,Cash5,Cash6,CashP1,CashP2,CashP3,CashP4,CashP5,CashP6,DCash1,DCash2,DCash3,DP1,DP2,DP3,Hajm,KalaCash,HKalaCash,KindCost,GroupValue,GroupValueMon,GroupPeople,Chk1,Chk2,Chk3,Chk4,Chk5,Chk6,DChk1,DChk2,DChk3,DCard) SELECT Id,nam,Cash1,Cash2,Cash3,Cash4,Cash5,Cash6,CashP1,CashP2,CashP3,CashP4,CashP5,CashP6,DCash1,DCash2,DCash3,DP1,DP2,DP3,Hajm,KalaCash,HKalaCash,KindCost,GroupValue,GroupValueMon,GroupPeople,Chk1,Chk2,Chk3,Chk4,Chk5,Chk6,DChk1,DChk2,DChk3,DCard FROM " & oldDbName & ".dbo.Define_Group_P", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_List_Group_P ON;INSERT INTO " & Db_name & ".dbo.Define_List_Group_P (AzMon,TaMon,Darsad,Id,LinkId) SELECT AzMon,TaMon,Darsad,Id,LinkId FROM " & oldDbName & ".dbo.Define_List_Group_P", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''راننده
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_Driver ON;INSERT INTO " & Db_name & ".dbo.Define_Driver (Id,Nam,Tell,Disc) SELECT Id,Nam,Tell,Disc FROM " & oldDbName & ".dbo.Define_Driver", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''مامور توزیع
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_Reciver ON;INSERT INTO " & Db_name & ".dbo.Define_Reciver (Id,Nam,Tell,Disc) SELECT Id,Nam,Tell,Disc FROM " & oldDbName & ".dbo.Define_Reciver", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''وسیله حمل
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_Car ON;INSERT INTO " & Db_name & ".dbo.Define_Car (Id,Nam,Plak,Disc,[Weight],WeightK,Size,WidthK,HightK,TopK) SELECT Id,Nam,Plak,Disc,[Weight],WeightK,Size,WidthK,HightK,TopK FROM " & oldDbName & ".dbo.Define_Car", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''هزینه
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_OneCharge ON;INSERT INTO " & Db_name & ".dbo.Define_OneCharge(Id,NamOne,IdCodeOne) SELECT  Id,NamOne,IdCodeOne FROM [" & oldDbName & "].[dbo].[Define_OneCharge]", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_Charge ON;INSERT INTO " & Db_name & ".dbo.Define_Charge([nam],[discription],[ID],[IdCodeTwo],[IdOne]) SELECT  [nam],[discription],[ID],[IdCodeTwo],[IdOne] FROM [" & oldDbName & "].[dbo].[Define_Charge]", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''درآمد
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_OneDaramad ON;INSERT INTO " & Db_name & ".dbo.Define_OneDaramad(Id,NamOne,IdCodeOne) SELECT Id,NamOne,IdCodeOne FROM [" & oldDbName & "].[dbo].[Define_OneDaramad]", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_Daramad ON;INSERT INTO " & Db_name & ".dbo.Define_Daramad(nam,discription,ID,IdCodeTwo,IdOne) SELECT  nam,discription,ID,IdCodeTwo,IdOne FROM [" & oldDbName & "].[dbo].[Define_Daramad]", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''خدمات
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_Service ON;INSERT INTO " & Db_name & ".dbo.Define_Service(nam,discription,ID) SELECT  nam,discription,ID FROM [" & oldDbName & "].[dbo].[Define_Service]", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''ویزیتور
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_Visitor ON;INSERT INTO " & Db_name & ".dbo.Define_Visitor(Id,Nam,Activ,Mon,Pas) SELECT Id,Nam,Activ,Mon,Pas FROM [" & oldDbName & "].[dbo].[Define_Visitor]", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''طرف حساب
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT [" & Db_name & "].[dbo].[Define_People] ON;INSERT INTO [" & Db_name & "].[dbo].[Define_People] (ID,Nam,Tell1,Tell2,Fax,[Address],Buyer,Seller,Other,GValue,GValueMon,AllMoney,[State],Rate,NamCo,NamFac,IdOstan,IdCity,IdPart,Activ,ChkIdGroup,IdGroup,D_Dat,MCode) SELECT ID,Nam,Tell1,Tell2,Fax,[Address],Buyer,Seller,Other,GValue,GValueMon,AllMoney=ABS(AllMoney),[State]=CASE WHEN AllMoney <0 THEN N'بستانکار' WHEN AllMoney >0 THEN N'بدهکار' ELSE N'بی حساب' END ,Rate,NamCo,NamFac,IdOstan,IdCity,IdPart,Activ,ChkIdGroup,IdGroup,D_Dat,MCode FROM (SELECT ID,Nam,Tell1,Tell2,Fax,[Address],Buyer,Seller,Other,GValue,GValueMon,AllMoney=(SELECT SUM(OnMoney+bed+bes) AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM [" & oldDbName & "].[dbo].Moein_People WHERE IDPeople =ListP.ID AND T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM [" & oldDbName & "].[dbo].Moein_People WHERE IDPeople =ListP.ID AND T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney= CASE [State] WHEN N'بستانکار' THEN Allmoney *(-1) WHEN N'بدهکار' THEN Allmoney Else  0 End FROM [" & oldDbName & "].[dbo].Define_People WHERE Id=ListP.ID )As AllOneMoney )As One),[State],Rate,NamCo,NamFac,IdOstan,IdCity,IdPart,Activ,ChkIdGroup,IdGroup,D_Dat,MCode FROM (SELECT * FROM [" & oldDbName & "].[dbo].[Define_People]) As ListP) As ListP2", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''لیست سایر بانکها
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO [" & Db_name & "].[dbo].[Define_OtherBank] (Nam) SELECT Nam FROM [" & oldDbName & "].[dbo].[Define_OtherBank]", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''صندوق
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT [" & Db_name & "].[dbo].[Define_Box] ON;INSERT INTO [" & Db_name & "].[dbo].[Define_Box] (nam,discription,AllMoney,ID) VALUES (@nam,@discription,@AllMoney,@ID)", ConectionBank)
                For i As Integer = 0 To Tmp_DtBox.Rows.Count - 1
                    cmd.Parameters.AddWithValue("@nam", SqlDbType.NVarChar).Value = Tmp_DtBox.Rows(i).Item("Nam")
                    cmd.Parameters.AddWithValue("@discription", SqlDbType.NVarChar).Value = Tmp_DtBox.Rows(i).Item("discription")
                    cmd.Parameters.AddWithValue("@AllMoney", SqlDbType.BigInt).Value = CDbl(Tmp_DtBox.Rows(i).Item("NewMandeh"))
                    cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = Tmp_DtBox.Rows(i).Item("Id")
                    cmd.CommandTimeout = 0
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                Next
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''بانک
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT [" & Db_name & "].[dbo].[Define_Bank] ON;INSERT INTO [" & Db_name & "].[dbo].[Define_Bank] (n_bank,shobeh,number_n,tell,[address],nam,AllMoney,[State],ID) VALUES (@n_bank,@shobeh,@number_n,@tell,@address,@nam,@AllMoney,@State,@ID)", ConectionBank)
                For i As Integer = 0 To Tmp_DtBank.Rows.Count - 1
                    cmd.Parameters.AddWithValue("@n_bank", SqlDbType.NVarChar).Value = Tmp_DtBank.Rows(i).Item("Nam")
                    cmd.Parameters.AddWithValue("@shobeh", SqlDbType.NVarChar).Value = Tmp_DtBank.Rows(i).Item("shobeh")
                    cmd.Parameters.AddWithValue("@number_n", SqlDbType.NVarChar).Value = Tmp_DtBank.Rows(i).Item("number_n")
                    cmd.Parameters.AddWithValue("@tell", SqlDbType.NVarChar).Value = Tmp_DtBank.Rows(i).Item("tell")
                    cmd.Parameters.AddWithValue("@address", SqlDbType.NVarChar).Value = Tmp_DtBank.Rows(i).Item("address")
                    cmd.Parameters.AddWithValue("@nam", SqlDbType.NVarChar).Value = Tmp_DtBank.Rows(i).Item("NamP")
                    cmd.Parameters.AddWithValue("@AllMoney", SqlDbType.BigInt).Value = CDbl(Tmp_DtBank.Rows(i).Item("NewMandeh"))
                    cmd.Parameters.AddWithValue("@State", SqlDbType.NVarChar).Value = Tmp_DtBank.Rows(i).Item("State")
                    cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = Tmp_DtBank.Rows(i).Item("ID")
                    cmd.CommandTimeout = 0
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                Next
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''اموال
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_OneAmval ON;INSERT INTO " & Db_name & ".dbo.Define_OneAmval(Id,NamOne,IdCodeOne) SELECT Id,NamOne,IdCodeOne FROM [" & oldDbName & "].[dbo].[Define_OneAmval]", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT [" & Db_name & "].[dbo].[Define_Amval] ON;INSERT INTO [" & Db_name & "].[dbo].[Define_Amval] (nam,discription,AllMoney,ID,IdOne,IdCodeTwo) VALUES (@nam,@discription,@AllMoney,@ID,@IdOne,@IdCodeTwo)", ConectionBank)
                For i As Integer = 0 To Tmp_DtAmval.Rows.Count - 1
                    cmd.Parameters.AddWithValue("@nam", SqlDbType.NVarChar).Value = Tmp_DtAmval.Rows(i).Item("Nam")
                    cmd.Parameters.AddWithValue("@discription", SqlDbType.NVarChar).Value = Tmp_DtAmval.Rows(i).Item("discription")
                    cmd.Parameters.AddWithValue("@AllMoney", SqlDbType.BigInt).Value = CDbl(Tmp_DtAmval.Rows(i).Item("NewMandeh"))
                    cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = Tmp_DtAmval.Rows(i).Item("Id")
                    cmd.Parameters.AddWithValue("@IdOne", SqlDbType.BigInt).Value = Tmp_DtAmval.Rows(i).Item("IdOne")
                    cmd.Parameters.AddWithValue("@IdCodeTwo", SqlDbType.BigInt).Value = Tmp_DtAmval.Rows(i).Item("IdCodeTwo")

                    cmd.CommandTimeout = 0
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                Next
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()

            ''''''''''''''''''''سرمایه
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_OneSarmayeh ON;INSERT INTO " & Db_name & ".dbo.Define_OneSarmayeh(Id,NamOne,IdCodeOne) SELECT Id,NamOne,IdCodeOne FROM [" & oldDbName & "].[dbo].[Define_OneSarmayeh]", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT [" & Db_name & "].[dbo].[Define_Sarmayeh] ON;INSERT INTO [" & Db_name & "].[dbo].[Define_Sarmayeh] (nam,STAT,discription,AllMoney,ID,IdCodeTwo,IdOne) VALUES (@nam,@STAT,@discription,@AllMoney,@ID,@IdCodeTwo,@IdOne)", ConectionBank)
                For i As Integer = 0 To Tmp_DtSarmayeh.Rows.Count - 1
                    cmd.Parameters.AddWithValue("@nam", SqlDbType.NVarChar).Value = Tmp_DtSarmayeh.Rows(i).Item("Nam")
                    cmd.Parameters.AddWithValue("@STAT", SqlDbType.NVarChar).Value = If(CDbl(Tmp_DtSarmayeh.Rows(i).Item("NewMandeh")) < 0, "بستانکار", If(CDbl(Tmp_DtSarmayeh.Rows(i).Item("NewMandeh")) > 0, "بدهکار", "بی حساب"))
                    cmd.Parameters.AddWithValue("@discription", SqlDbType.NVarChar).Value = Tmp_DtSarmayeh.Rows(i).Item("discription")
                    cmd.Parameters.AddWithValue("@AllMoney", SqlDbType.BigInt).Value = CDbl(Math.Abs(Tmp_DtSarmayeh.Rows(i).Item("NewMandeh")))
                    cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = Tmp_DtSarmayeh.Rows(i).Item("Id")
                    cmd.Parameters.AddWithValue("@IdOne", SqlDbType.BigInt).Value = Tmp_DtSarmayeh.Rows(i).Item("IdOne")
                    cmd.Parameters.AddWithValue("@IdCodeTwo", SqlDbType.BigInt).Value = Tmp_DtSarmayeh.Rows(i).Item("IdCodeTwo")

                    cmd.CommandTimeout = 0
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                Next
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PDefine.Value += 1
            Application.DoEvents()

            '''''''''''''''''''''''''''''ثبت سند اتوماتیک سرمایه
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using Cmd As New SqlCommand("INSERT [" & oldDbName & "].[dbo].[Get_Pay_Sarmayeh] (D_date,IdSarmayeh,IdUser,Active,State,EditFlag,Cash,MonHavaleh,IdBankHavaleh,DiscHavaleh,MonPayChk,MonSellChk,Lend,LendP,IdSanadLendP,LendCharge,DiscChk,DiscSellChk,IdBoxMoein,IdBox,IdBankMoein,AllDisc,DiscCash,DiscLend) VALUES(@D_date,@IdSarmayeh,@IdUser,@Active,@State,@EditFlag,@Cash,@MonHavaleh,@IdBankHavaleh,@DiscHavaleh,@MonPayChk,@MonSellChk,@Lend,@LendP,@IdSanadLendP,@LendCharge,@DiscChk,@DiscSellChk,@IdBoxMoein,@IdBox,@IdBankMoein,@AllDisc,@DiscCash,@DiscLend)", ConectionBank)
                For i As Integer = 0 To Tmp_DtSarmayeh.Rows.Count - 1
                    If CDbl(Tmp_DtSarmayeh.Rows(i).Item("NewMandeh")) = CDbl(Tmp_DtSarmayeh.Rows(i).Item("Mandeh")) Then
                        Continue For
                    Else
                        Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = GetDate()
                        Cmd.Parameters.AddWithValue("@IdSarmayeh", SqlDbType.BigInt).Value = Tmp_DtSarmayeh.Rows(i).Item("Id")
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                        Cmd.Parameters.AddWithValue("@Active", SqlDbType.Int).Value = 1
                        Cmd.Parameters.AddWithValue("@State", SqlDbType.Int).Value = If(CDbl(Tmp_DtSarmayeh.Rows(i).Item("NewMandeh")) > CDbl(Tmp_DtSarmayeh.Rows(i).Item("Mandeh")), 0, 1) 'If(RdoDec.Checked = True, 0, 1)
                        Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.Int).Value = 1
                        Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = 0
                        Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = 0
                        Cmd.Parameters.AddWithValue("@IdBankHavaleh", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@DiscHavaleh", SqlDbType.NVarChar).Value = ""
                        Cmd.Parameters.AddWithValue("@MonSellChk", SqlDbType.BigInt).Value = 0
                        Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = 0
                        Cmd.Parameters.AddWithValue("@Lend", SqlDbType.BigInt).Value = Me.Ressarmayeh(CDbl(Tmp_DtSarmayeh.Rows(i).Item("NewMandeh")), CDbl(Tmp_DtSarmayeh.Rows(i).Item("Mandeh")))
                        Cmd.Parameters.AddWithValue("@LendP", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@IdSanadLendP", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@LendCharge", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@DiscChk", SqlDbType.NVarChar).Value = ""
                        Cmd.Parameters.AddWithValue("@DiscSellChk", SqlDbType.NVarChar).Value = ""
                        Cmd.Parameters.AddWithValue("@IdBoxMoein", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@AllDisc", SqlDbType.NVarChar).Value = "سند اختتامیه اتوماتیک جهت تقسیم سود"
                        Cmd.Parameters.AddWithValue("@DiscCash", SqlDbType.NVarChar).Value = ""
                        Cmd.Parameters.AddWithValue("@DiscLend", SqlDbType.NVarChar).Value = "سند اختتامیه اتوماتیک جهت تقسیم سود"
                        Cmd.CommandTimeout = 0
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    End If
                Next
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Application.DoEvents()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmActionEnd", "SaveDefine")
            Return False
        End Try
    End Function
    Private Function Ressarmayeh(ByVal Newmandeh As Long, ByVal mandeh As Long) As Long
        If (Newmandeh <= 0 And mandeh <= 0) Or (Newmandeh >= 0 And mandeh >= 0) Then
            Return Math.Abs(Math.Abs(Newmandeh) - Math.Abs(mandeh))
        ElseIf (Newmandeh <= 0 And mandeh <= 0) Then
            Return Math.Abs(Math.Abs(Newmandeh) + Math.Abs(mandeh))
        Else
            Return Math.Abs(Math.Abs(Newmandeh) - Math.Abs(mandeh))
        End If
    End Function
    Private Function DelPeople(ByVal Db_name As String) As Boolean
        Try
            Dim query As String = ""
            If People = 0 Then
                query = "DELETE FROM " & Db_name & ".dbo.Define_UserRP WHERE IDP IN (SELECT ID FROM " & Db_name & ".dbo.Define_People WHERE AllMoney =0 And Activ ='True' AND ID NOT IN (SELECT IdPeople As Idp FROM " & Db_name & ".dbo.Chk_Id WHERE IdPeople IS NOT NULL UNION SELECT Current_IdPeople As Idp FROM " & Db_name & ".dbo.Chk_Id WHERE Current_IdPeople IS NOT NULL));DELETE FROM " & Db_name & ".dbo.Define_UserR WHERE IdUser NOT IN (SELECT DISTINCT IdUser FROM " & Db_name & ".dbo.Define_UserRP);DELETE FROM " & Db_name & ".dbo.Define_People WHERE ID IN (SELECT ID FROM " & Db_name & ".dbo.Define_People WHERE AllMoney =0 And Activ ='True' AND ID NOT IN (SELECT IdPeople As Idp FROM " & Db_name & ".dbo.Chk_Id WHERE IdPeople IS NOT NULL UNION SELECT Current_IdPeople As Idp FROM " & Db_name & ".dbo.Chk_Id WHERE Current_IdPeople IS NOT NULL));"
            ElseIf People = 1 Then
                query = "DELETE FROM " & Db_name & ".dbo.Define_UserRP WHERE IDP IN (SELECT ID FROM " & Db_name & ".dbo.Define_People WHERE AllMoney =0 AND ID NOT IN (SELECT IdPeople As Idp FROM " & Db_name & ".dbo.Chk_Id WHERE IdPeople IS NOT NULL UNION SELECT Current_IdPeople As Idp FROM " & Db_name & ".dbo.Chk_Id WHERE Current_IdPeople IS NOT NULL));DELETE FROM " & Db_name & ".dbo.Define_UserR WHERE IdUser NOT IN (SELECT DISTINCT IdUser FROM " & Db_name & ".dbo.Define_UserRP);DELETE FROM " & Db_name & ".dbo.Define_People WHERE ID IN (SELECT ID FROM " & Db_name & ".dbo.Define_People WHERE AllMoney =0 AND ID NOT IN (SELECT IdPeople As Idp FROM " & Db_name & ".dbo.Chk_Id WHERE IdPeople IS NOT NULL UNION SELECT Current_IdPeople As Idp FROM " & Db_name & ".dbo.Chk_Id WHERE Current_IdPeople IS NOT NULL));"
            ElseIf People = 2 Then
                query = "DELETE FROM " & Db_name & ".dbo.Define_UserRP WHERE IDP IN (SELECT ID FROM " & Db_name & ".dbo.Define_People WHERE  Activ ='True' AND ID NOT IN (SELECT IdPeople As Idp FROM " & Db_name & ".dbo.Chk_Id WHERE IdPeople IS NOT NULL UNION SELECT Current_IdPeople As Idp FROM " & Db_name & ".dbo.Chk_Id WHERE Current_IdPeople IS NOT NULL));DELETE FROM " & Db_name & ".dbo.Define_UserR WHERE IdUser NOT IN (SELECT DISTINCT IdUser FROM " & Db_name & ".dbo.Define_UserRP);DELETE FROM " & Db_name & ".dbo.Define_People WHERE ID IN (SELECT ID FROM " & Db_name & ".dbo.Define_People WHERE  Activ ='True' AND ID NOT IN (SELECT IdPeople As Idp FROM " & Db_name & ".dbo.Chk_Id WHERE IdPeople IS NOT NULL UNION SELECT Current_IdPeople As Idp FROM " & Db_name & ".dbo.Chk_Id WHERE Current_IdPeople IS NOT NULL));"
            ElseIf People = 3 Then
                Dim tmp As String = ""
                For i As Integer = 0 To FactorArray.Length - 1
                    tmp &= FactorArray(i).IdKala & ","
                Next
                tmp = tmp.Substring(0, tmp.Length - 1)
                query = "DELETE FROM " & Db_name & ".dbo.Define_UserRP WHERE IDP IN (SELECT ID FROM " & Db_name & ".dbo.Define_People WHERE  ID IN (" & tmp & ") AND ID NOT IN (SELECT IdPeople As Idp FROM " & Db_name & ".dbo.Chk_Id WHERE IdPeople IS NOT NULL UNION SELECT Current_IdPeople As Idp FROM " & Db_name & ".dbo.Chk_Id WHERE Current_IdPeople IS NOT NULL));DELETE FROM " & Db_name & ".dbo.Define_UserR WHERE IdUser NOT IN (SELECT DISTINCT IdUser FROM " & Db_name & ".dbo.Define_UserRP);DELETE FROM " & Db_name & ".dbo.Define_People WHERE ID IN (SELECT ID FROM " & Db_name & ".dbo.Define_People WHERE  ID IN (" & tmp & ") AND ID NOT IN (SELECT IdPeople As Idp FROM " & Db_name & ".dbo.Chk_Id WHERE IdPeople IS NOT NULL UNION SELECT Current_IdPeople As Idp FROM " & Db_name & ".dbo.Chk_Id WHERE Current_IdPeople IS NOT NULL));"
            End If

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(query, ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            Return True
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmActionEnd", "DelPeople")
            Return False
        End Try
    End Function

    Private Function DelKala(ByVal Db_name As String) As Boolean
        Try
            Dim query As String = ""
            If kala = 0 Then
                query = "DECLARE @tbl TABLE(IdK Bigint) INSERT INTO @tbl SELECT Id FROM (SELECT Id,Kol=(SELECT ISNULL(ROUND(SUM(Count_Kol),2),0) AS Kol FROM " & Db_name & ".dbo.Define_PrimaryKala WHERE " & Db_name & ".dbo.Define_PrimaryKala.IdKala =ListKala.Id ) FROM (SELECT Id FROM  " & Db_name & ".dbo.Define_Kala WHERE Activ ='True') AS ListKala) As ListEndKala WHERE Kol <=0"
            ElseIf kala = 1 Then
                query = "DECLARE @tbl TABLE(IdK Bigint) INSERT INTO @tbl SELECT Id FROM (SELECT Id,Kol=(SELECT ISNULL(ROUND(SUM(Count_Kol),2),0) AS Kol FROM " & Db_name & ".dbo.Define_PrimaryKala WHERE " & Db_name & ".dbo.Define_PrimaryKala.IdKala =ListKala.Id ) FROM (SELECT Id FROM  " & Db_name & ".dbo.Define_Kala) AS ListKala) As ListEndKala WHERE Kol <=0"
            ElseIf kala = 2 Then
                query = "DECLARE @tbl TABLE(IdK Bigint) INSERT INTO @tbl SELECT Id FROM  " & Db_name & ".dbo.Define_Kala WHERE Activ ='True'"
            ElseIf kala = 3 Then
                Dim tmp As String = ""
                For i As Integer = 0 To SFactorArray.Length - 1
                    tmp &= "SELECT " & SFactorArray(i).IdKala & " UNION "
                Next
                tmp = tmp.Substring(0, tmp.Length - 6)
                query = "DECLARE @tbl TABLE(IdK Bigint) INSERT INTO @tbl " & tmp
            End If

            query &= ";DELETE FROM " & Db_name & ".dbo.Define_PrimaryKala WHERE IdKala IN (SELECT IdK FROM @tbl);DELETE FROM " & Db_name & ".dbo.Define_CostKala WHERE IdKala  IN (SELECT IdK FROM @tbl);DELETE FROM " & Db_name & ".dbo.Define_CityCostkala WHERE IdCity NOT IN (SELECT DISTINCT IdCity FROM " & Db_name & ".dbo.Define_CostKala);DELETE FROM " & Db_name & ".dbo.DefinePromotion WHERE IdKala IN (SELECT IdK FROM @tbl);DELETE FROM " & Db_name & ".dbo.ListKala_Discount WHERE Idkala IN (SELECT IdK FROM @tbl);DELETE FROM " & Db_name & ".dbo.Define_KalaRate WHERE IdKala IN (SELECT IdK FROM @tbl);DELETE FROM " & Db_name & ".dbo.Listkala WHERE Idkala IN (SELECT IdK FROM @tbl);DELETE FROM " & Db_name & ".dbo.ListVisitor WHERE IdVisitor NOT IN (SELECT DISTINCT IdLinkVisitor FROM " & Db_name & ".dbo.Listkala);DELETE FROM " & Db_name & ".dbo.ListkalaU WHERE Idkala IN (SELECT IdK FROM @tbl);DELETE FROM " & Db_name & ".dbo.ListUser WHERE IdUser NOT IN (SELECT DISTINCT IdLinkUser FROM " & Db_name & ".dbo.ListkalaU);DELETE FROM " & Db_name & ".dbo.Define_Kala WHERE Id IN (SELECT IdK FROM @tbl);"
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(query, ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            Return True
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmActionEnd", "DelKala")
            Return False
        End Try
    End Function

    Private Function SaveRelation(ByVal Db_name As String) As Boolean
        Try
            PR.Minimum = 0
            PR.Maximum = 38
            PR.Value = 0
            ''''''''''''''''''''رابطه قیمت کالا در شهرستان
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.Define_CityCostkala (IdCity) SELECT IdCity FROM " & oldDbName & ".dbo.Define_CityCostkala", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()


            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.Define_CostKala (IdKala,IdCity,CostSmalKala,CostBigKala,EndCost) SELECT IdKala,IdCity,CostSmalKala,CostBigKala,EndCost FROM " & oldDbName & ".dbo.Define_CostKala", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            ''''''''''''''''''''رابطه کالا و قیمت ویژه
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.DefinePromotion ON;INSERT INTO " & Db_name & ".dbo.DefinePromotion ([Id],[IdKala],[IdGroup],[Fe]) SELECT [Id],[IdKala],[IdGroup],[Fe] FROM " & oldDbName & ".dbo.DefinePromotion", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.DefineListPromotion ([AzKala],[TaKala],[Fe],[Darsad],[IdLink]) SELECT [AzKala],[TaKala],[Fe],[Darsad],[IdLink] FROM " & oldDbName & ".dbo.DefineListPromotion", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            ''''''''''''''''''''رابطه کالا و جایزه
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.ListKala_Discount ([Idkala],[Coding],[AutoDiscount]) SELECT [Idkala],[Coding],[AutoDiscount] FROM " & oldDbName & ".dbo.ListKala_Discount", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.Kala_Discount ([KolCount],[JozCount],[Idkala],[IdService],[Kol],[Joz],[IdKalaLink]) SELECT [KolCount],[JozCount],[Idkala],[IdService],[Kol],[Joz],[IdKalaLink] FROM " & oldDbName & ".dbo.Kala_Discount", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            ''''''''''''''''''''رابطه کالا و وعده تسویه
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.Define_KalaRate ([Idkala],[BRate]) SELECT [Idkala],[BRate] FROM " & oldDbName & ".dbo.Define_KalaRate", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.Define_ListKalaRate ([IdGroup],[Rate],[IdKalaLink]) SELECT [IdGroup],[Rate],[IdKalaLink] FROM " & oldDbName & ".dbo.Define_ListKalaRate", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''رابطه کاربر و طرف حساب
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.Define_UserR (IdUser) SELECT IdUser FROM " & oldDbName & ".dbo.Define_UserR", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.Define_UserRP (IdUser,IDP) SELECT IdUser,IDP FROM " & oldDbName & ".dbo.Define_UserRP", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            ''''''''''''''''''''رابطه ویزیتور و طرف حساب
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.Define_VisitorR (IdVisitor) SELECT IdVisitor FROM " & oldDbName & ".dbo.Define_VisitorR", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            'PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.Define_VisitorRP (IdVisitor,IDP) SELECT IdVisitor,IDP FROM " & oldDbName & ".dbo.Define_VisitorRP", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            'PR.Value += 1
            Application.DoEvents()
            ''''''''''''''''''''رابطه کاربر و صندوق
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.Define_UserRBox (IdUser) SELECT IdUser FROM " & oldDbName & ".dbo.Define_UserRBox", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.Define_UserRPBox (IdUser,IDB) SELECT IdUser,IDB FROM " & oldDbName & ".dbo.Define_UserRPBox", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            ''''''''''''''''''''رابطه کاربر و انبار
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.Define_UserRAnbar (IdUser) SELECT IdUser FROM " & oldDbName & ".dbo.Define_UserRAnbar", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.Define_UserRPAnbar (IdUser,IDA) SELECT IdUser,IDA FROM " & oldDbName & ".dbo.Define_UserRPAnbar", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            ''''''''''''''''''''رابطه ویزیتور و فروش هدف - بر حسب گروه اصلی
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.ListVisitor_OG (IdVisitor) SELECT IdVisitor FROM " & oldDbName & ".dbo.ListVisitor_OG", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Listkala_OG ON;INSERT INTO " & Db_name & ".dbo.Listkala_OG ([Id],[Idkala],[Mon],[Kala],[IdLinkVisitor]) SELECT [Id],[Idkala],[Mon],[Kala],[IdLinkVisitor] FROM " & oldDbName & ".dbo.Listkala_OG", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.ListDarsad_OG ([Frosh],[Darsad],[IdlinkKala],[IdGroup]) SELECT [Frosh],[Darsad],[IdlinkKala],[IdGroup] FROM " & oldDbName & ".dbo.ListDarsad_OG", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.ListOrderDarsad_OG ([IdGroup],[Darsad],[IdLinkVisitor]) SELECT [IdGroup],[Darsad],[IdLinkVisitor] FROM " & oldDbName & ".dbo.ListOrderDarsad_OG", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            ''''''''''''''''''''رابطه ویزیتور و فروش هدف - بر حسب گروه فرعی
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.ListVisitor_G (IdVisitor) SELECT IdVisitor FROM " & oldDbName & ".dbo.ListVisitor_G", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Listkala_G ON;INSERT INTO " & Db_name & ".dbo.Listkala_G ([Id],[Idkala],[Mon],[Kala],[IdLinkVisitor]) SELECT [Id],[Idkala],[Mon],[Kala],[IdLinkVisitor] FROM " & oldDbName & ".dbo.Listkala_G", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.ListDarsad_G ([Frosh],[Darsad],[IdlinkKala],[IdGroup]) SELECT [Frosh],[Darsad],[IdlinkKala],[IdGroup] FROM " & oldDbName & ".dbo.ListDarsad_G", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.ListOrderDarsad_G ([IdGroup],[Darsad],[IdLinkVisitor]) SELECT [IdGroup],[Darsad],[IdLinkVisitor] FROM " & oldDbName & ".dbo.ListOrderDarsad_G", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            ''''''''''''''''''''رابطه ویزیتور و فروش هدف - بر حسب کالا
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.ListVisitor (IdVisitor) SELECT IdVisitor FROM " & oldDbName & ".dbo.ListVisitor", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Listkala ON;INSERT INTO " & Db_name & ".dbo.Listkala ([Id],[Idkala],[Mon],[Kala],[IdLinkVisitor]) SELECT [Id],[Idkala],[Mon],[Kala],[IdLinkVisitor] FROM " & oldDbName & ".dbo.Listkala", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.ListDarsad ([Frosh],[Darsad],[IdlinkKala],[IdGroup]) SELECT [Frosh],[Darsad],[IdlinkKala],[IdGroup] FROM " & oldDbName & ".dbo.ListDarsad", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.ListOrderDarsad ([IdGroup],[Darsad],[IdLinkVisitor]) SELECT [IdGroup],[Darsad],[IdLinkVisitor] FROM " & oldDbName & ".dbo.ListOrderDarsad", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            ''''''''''''''''''''رابطه کاربر و فروش هدف - بر حسب گروه اصلی
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.ListUser_OG (IdUser) SELECT IdUser FROM " & oldDbName & ".dbo.ListUser_OG", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.ListkalaU_OG ON;INSERT INTO " & Db_name & ".dbo.ListkalaU_OG ([Id],[Idkala],[Mon],[Kala],[IdLinkUser]) SELECT [Id],[Idkala],[Mon],[Kala],[IdLinkUser] FROM " & oldDbName & ".dbo.ListkalaU_OG", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.ListDarsadU_OG ([Frosh],[Darsad],[IdlinkKala],[IdGroup]) SELECT [Frosh],[Darsad],[IdlinkKala],[IdGroup] FROM " & oldDbName & ".dbo.ListDarsadU_OG", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.ListOrderDarsadU_OG ([IdGroup],[Darsad],[IdLinkUser]) SELECT [IdGroup],[Darsad],[IdLinkUser] FROM " & oldDbName & ".dbo.ListOrderDarsadU_OG", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            ''''''''''''''''''''رابطه کاربر و فروش هدف - بر حسب گروه فرعی
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.ListUser_G (IdUser) SELECT IdUser FROM " & oldDbName & ".dbo.ListUser_G", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.ListkalaU_G ON;INSERT INTO " & Db_name & ".dbo.ListkalaU_G ([Id],[Idkala],[Mon],[Kala],[IdLinkUser]) SELECT [Id],[Idkala],[Mon],[Kala],[IdLinkUser] FROM " & oldDbName & ".dbo.ListkalaU_G", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.ListDarsadU_G ([Frosh],[Darsad],[IdlinkKala],[IdGroup]) SELECT [Frosh],[Darsad],[IdlinkKala],[IdGroup] FROM " & oldDbName & ".dbo.ListDarsadU_G", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.ListOrderDarsadU_G ([IdGroup],[Darsad],[IdLinkUser]) SELECT [IdGroup],[Darsad],[IdLinkUser] FROM " & oldDbName & ".dbo.ListOrderDarsadU_G", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            ''''''''''''''''''''رابطه کاربر و فروش هدف - بر حسب کالا
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.ListUser (IdUser) SELECT IdUser FROM " & oldDbName & ".dbo.ListUser", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.ListkalaU ON;INSERT INTO " & Db_name & ".dbo.ListkalaU ([Id],[Idkala],[Mon],[Kala],[IdLinkUser]) SELECT [Id],[Idkala],[Mon],[Kala],[IdLinkUser] FROM " & oldDbName & ".dbo.ListkalaU", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.ListDarsadU ([Frosh],[Darsad],[IdlinkKala],[IdGroup]) SELECT [Frosh],[Darsad],[IdlinkKala],[IdGroup] FROM " & oldDbName & ".dbo.ListDarsadU", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO " & Db_name & ".dbo.ListOrderDarsadU ([IdGroup],[Darsad],[IdLinkUser]) SELECT [IdGroup],[Darsad],[IdLinkUser] FROM " & oldDbName & ".dbo.ListOrderDarsadU", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PR.Value += 1
            Application.DoEvents()
            Return True
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmActionEnd", "SaveRelation")
            Return False
        End Try
    End Function
    Private Function SaveMojodyKala(ByVal Db_name As String) As Boolean
        Try
            PMKala.Minimum = 0
            PMKala.Maximum = Tmp_DtKala.Rows.Count + ListEditKala.Length
            PMKala.Value = 0
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO [" & Db_name & "].[dbo].[Define_PrimaryKala] (IdKala,IdAnbar,Count_Kol,Count_Joz,Fe,Mon,D_date,Iduser) VALUES (@IdKala,@IdAnbar,@Count_Kol,@Count_Joz,@Fe,@Mon,@D_date,@Iduser)", ConectionBank)
                For i As Integer = 0 To Tmp_DtKala.Rows.Count - 1
                    If (Tmp_DtKala.Rows(i).Item("Fe") > 0 And Tmp_DtKala.Rows(i).Item("AllMon") > 0) And (Tmp_DtKala.Rows(i).Item("KolCount") > 0) And Not (Tmp_DtKala.Rows(i).Item("KolCount") > 0 And Tmp_DtKala.Rows(i).Item("JozCount") <= 0 And Tmp_DtKala.Rows(i).Item("DK") = True) Then
                        cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = Tmp_DtKala.Rows(i).Item("Id")
                        cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = Tmp_DtKala.Rows(i).Item("IdAnbar")
                        cmd.Parameters.AddWithValue("@Count_Kol", SqlDbType.Float).Value = Tmp_DtKala.Rows(i).Item("KolCount")
                        cmd.Parameters.AddWithValue("@Count_Joz", SqlDbType.Float).Value = Tmp_DtKala.Rows(i).Item("JozCount")
                        cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = Tmp_DtKala.Rows(i).Item("Fe")
                        cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = Tmp_DtKala.Rows(i).Item("AllMon")
                        cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = GetDate()
                        cmd.Parameters.AddWithValue("@Iduser", SqlDbType.BigInt).Value = Id_User
                        cmd.CommandTimeout = 0
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                    PMKala.Value += 1
                    Application.DoEvents()
                Next
            End Using

            If ListEditKala.Length > 0 Then
                Using cmd As New SqlCommand("INSERT INTO [" & Db_name & "].[dbo].[Define_EditKala] (Idkala,OKol,OJoz,TKol,TJoz,IdAnbar) VALUES (@Idkala,@OKol,@OJoz,@TKol,@TJoz,@IdAnbar)", ConectionBank)
                    For i As Integer = 0 To ListEditKala.Length - 1
                        cmd.Parameters.AddWithValue("@Idkala", SqlDbType.BigInt).Value = ListEditKala(i).IdKala
                        cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = ListEditKala(i).IdAnbar
                        cmd.Parameters.AddWithValue("@OKol", SqlDbType.Float).Value = ListEditKala(i).OKol
                        cmd.Parameters.AddWithValue("@OJoz", SqlDbType.Float).Value = ListEditKala(i).Ojoz
                        cmd.Parameters.AddWithValue("@TKol", SqlDbType.Float).Value = ListEditKala(i).TKol
                        cmd.Parameters.AddWithValue("@TJoz", SqlDbType.Float).Value = ListEditKala(i).Tjoz

                        cmd.CommandTimeout = 0
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                        PMKala.Value += 1
                        Application.DoEvents()
                    Next
                End Using
            End If

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmActionEnd", "SaveMojodyKala")
            Return False
        End Try
    End Function

    Private Function SaveMojodyChk(ByVal Db_name As String) As Boolean
        Try
            Dim DtChk As New DataTable
            Dim DtId As New DataTable
            Dim DtState As New DataTable
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using cmd As New SqlCommand("SELECT * FROM Chk_Get_Pay WHERE Activ =1 AND (Current_State =0 OR Current_State =3 OR Current_State =4) ORDER BY Kind,Current_Kind", ConectionBank)
                DtChk.Load(cmd.ExecuteReader())
            End Using

            Using cmd As New SqlCommand("SELECT * FROM Chk_Id WHERE Chk_Id.Id IN (SELECT Chk_Get_Pay.Id  FROM Chk_Get_Pay WHERE Activ =1 AND (Current_State =0 OR Current_State =3 OR Current_State =4))", ConectionBank)
                DtId.Load(cmd.ExecuteReader())
            End Using

            Using cmd As New SqlCommand("SELECT * FROM Chk_State WHERE Chk_State.Id IN (SELECT Chk_Get_Pay.Id  FROM Chk_Get_Pay WHERE Activ =1 AND (Current_State =0 OR Current_State =3 OR Current_State =4))", ConectionBank)
                DtState.Load(cmd.ExecuteReader())
            End Using

            PChk.Minimum = 0
            PChk.Maximum = (DtChk.Rows.Count * 3) + 2
            PChk.Value = 0
            If DtChk.Rows.Count > 0 Then
                PChk.Value += 1
                Application.DoEvents()
                Dim idChk As Long = 0
                Using cmd As New SqlCommand("INSERT INTO [" & Db_name & "].[dbo].[Chk_Get_Pay] ([GetDate],PayDate,MoneyChk,NumChk,Kind,Current_Kind,Shobeh,N_Bank,Number_N,Disc,[State],Current_State,Activ,[Type],Number_Type,Current_Type,Current_Number_Type,Number_Note,Type_Chk,Current_Type_Chk,IdUser) VALUES(@GetDate,@PayDate,@MoneyChk,@NumChk,@Kind,@Current_Kind,@Shobeh,@N_Bank,@Number_N,@Disc,@State,@Current_State,@Activ,@Type,@Number_Type,@Current_Type,@Current_Number_Type,@Number_Note,@Type_Chk,@Current_Type_Chk,@IdUser);SELECT @@IDENTITY", ConectionBank)
                    For i As Integer = 0 To DtChk.Rows.Count - 1
                        cmd.Parameters.AddWithValue("@GetDate", SqlDbType.NVarChar).Value = DtChk.Rows(i).Item("GetDate")
                        cmd.Parameters.AddWithValue("@PayDate", SqlDbType.NVarChar).Value = DtChk.Rows(i).Item("PayDate")
                        cmd.Parameters.AddWithValue("@MoneyChk", SqlDbType.BigInt).Value = DtChk.Rows(i).Item("MoneyChk")
                        cmd.Parameters.AddWithValue("@NumChk", SqlDbType.BigInt).Value = DtChk.Rows(i).Item("NumChk")
                        cmd.Parameters.AddWithValue("@Kind", SqlDbType.BigInt).Value = DtChk.Rows(i).Item("Kind")
                        cmd.Parameters.AddWithValue("@Current_Kind", SqlDbType.BigInt).Value = DtChk.Rows(i).Item("Current_Kind")
                        cmd.Parameters.AddWithValue("@Shobeh", SqlDbType.NVarChar).Value = DtChk.Rows(i).Item("Shobeh")
                        cmd.Parameters.AddWithValue("@N_Bank", SqlDbType.NVarChar).Value = DtChk.Rows(i).Item("N_Bank")
                        cmd.Parameters.AddWithValue("@Number_N", SqlDbType.NVarChar).Value = DtChk.Rows(i).Item("Number_N")
                        cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = DtChk.Rows(i).Item("Disc")
                        cmd.Parameters.AddWithValue("@State", SqlDbType.BigInt).Value = DtChk.Rows(i).Item("State")
                        cmd.Parameters.AddWithValue("@Current_State", SqlDbType.BigInt).Value = DtChk.Rows(i).Item("Current_State")
                        cmd.Parameters.AddWithValue("@Activ", SqlDbType.BigInt).Value = DtChk.Rows(i).Item("Activ")
                        cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 11
                        cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = 0
                        If DtChk.Rows(i).Item("Current_Type") >= 13 Then
                            cmd.Parameters.AddWithValue("@Current_Type", SqlDbType.BigInt).Value = DtChk.Rows(i).Item("Current_Type")
                            cmd.Parameters.AddWithValue("@Current_Number_Type", SqlDbType.BigInt).Value = 0
                        Else
                            cmd.Parameters.AddWithValue("@Current_Type", SqlDbType.BigInt).Value = 11
                            cmd.Parameters.AddWithValue("@Current_Number_Type", SqlDbType.BigInt).Value = 0
                        End If
                        cmd.Parameters.AddWithValue("@Number_Note", SqlDbType.NVarChar).Value = DtChk.Rows(i).Item("Number_Note")
                        cmd.Parameters.AddWithValue("@Type_Chk", SqlDbType.BigInt).Value = DtChk.Rows(i).Item("Type_Chk")
                        cmd.Parameters.AddWithValue("@Current_Type_Chk", SqlDbType.BigInt).Value = DtChk.Rows(i).Item("Current_Type_Chk")
                        cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = DtChk.Rows(i).Item("IdUser")
                        cmd.CommandTimeout = 0
                        idChk = cmd.ExecuteScalar()
                        cmd.Parameters.Clear()
                        PChk.Value += 1
                        Application.DoEvents()

                        Dim row() As DataRow = DtId.Select("Id=" & DtChk.Rows(i).Item("Id"))
                        If row.Length > 0 Then
                            Using CmdID As New SqlCommand("INSERT INTO [" & Db_name & "].[dbo].[Chk_Id] (Id,IdPeople,Current_IdPeople,IdBank,D_date,IdAmval,IdDaramad,Idsarmayeh) VALUES (@Id,@IdPeople,@Current_IdPeople,@IdBank,@D_date,@IdAmval,@IdDaramad,@Idsarmayeh)", ConectionBank)
                                CmdID.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = idChk
                                CmdID.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = row(0).Item("IdPeople")
                                CmdID.Parameters.AddWithValue("@Current_IdPeople", SqlDbType.BigInt).Value = row(0).Item("Current_IdPeople")
                                CmdID.Parameters.AddWithValue("@IdBank", SqlDbType.BigInt).Value = row(0).Item("IdBank")
                                CmdID.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = row(0).Item("D_date")
                                CmdID.Parameters.AddWithValue("@IdAmval", SqlDbType.BigInt).Value = row(0).Item("IdAmval")
                                CmdID.Parameters.AddWithValue("@IdDaramad", SqlDbType.BigInt).Value = row(0).Item("IdDaramad")
                                CmdID.Parameters.AddWithValue("@Idsarmayeh", SqlDbType.BigInt).Value = row(0).Item("Idsarmayeh")
                                CmdID.CommandTimeout = 0
                                CmdID.ExecuteNonQuery()
                            End Using
                        End If
                        PChk.Value += 1
                        Application.DoEvents()

                        Dim rowS() As DataRow = DtState.Select("Id=" & DtChk.Rows(i).Item("Id"))
                        If rowS.Length > 0 Then
                            Using CmdState As New SqlCommand("INSERT INTO [" & Db_name & "].[dbo].[Chk_State] (Id,D_Date,Current_State,Disc,TmpId,IdUser) VALUES (@Id,@D_Date,@Current_State,@Disc,@TmpId,@IdUser)", ConectionBank)
                                For j As Integer = 0 To rowS.Length - 1
                                    CmdState.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = idChk
                                    CmdState.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = rowS(j).Item("D_date")
                                    CmdState.Parameters.AddWithValue("@Current_State", SqlDbType.BigInt).Value = rowS(j).Item("Current_State")
                                    CmdState.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = rowS(j).Item("Disc")
                                    CmdState.Parameters.AddWithValue("@TmpId", SqlDbType.BigInt).Value = rowS(j).Item("TmpId")
                                    CmdState.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = rowS(j).Item("IdUser")
                                    CmdState.CommandTimeout = 0
                                    CmdState.ExecuteNonQuery()
                                    CmdState.Parameters.Clear()
                                Next
                            End Using
                        End If
                        PChk.Value += 1
                        Application.DoEvents()

                    Next
                End Using
            Else
                PChk.Value = 1
                Application.DoEvents()
            End If
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey

            Using CMD As New SqlCommand("UPDATE DB_Info SET AllowAdd=@AllowAdd,OldPeriod=@OldPeriod", ConectionBank)
                CMD.Parameters.AddWithValue("@AllowAdd", SqlDbType.VarBinary).Value = Sec.StringEncrypt("1", key.CreateEncryptor)
                CMD.Parameters.AddWithValue("@OldPeriod", SqlDbType.VarBinary).Value = Sec.StringEncrypt(idperiod, key.CreateEncryptor)
                CMD.CommandTimeout = 0
                CMD.ExecuteNonQuery()
            End Using
            PChk.Value += 1
            Application.DoEvents()
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            Return True
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmActionEnd", "SaveMojodyChk")
            Return False
        End Try
    End Function

    Private Function SaveKala(ByVal Db_name As String) As Boolean
        Try
            PKala.Minimum = 0
            PKala.Maximum = 5
            PKala.Value = 0
            ''''''''''''''''''''انبار
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_Anbar ON;INSERT INTO " & Db_name & ".dbo.Define_Anbar(nam,discription,ID,SetDeActiv) SELECT nam,discription,ID,SetDeActiv FROM " & oldDbName & ".dbo.Define_Anbar", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PKala.Value += 1
            Application.DoEvents()

            ''''''''''''''''''''گروه کالا
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_OneGroup ON;INSERT INTO " & Db_name & ".dbo.Define_OneGroup(Id,NamOne,IdCodeOne) SELECT Id,NamOne,IdCodeOne FROM " & oldDbName & ".dbo.Define_OneGroup", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PKala.Value += 1
            Application.DoEvents()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_TwoGroup ON;INSERT INTO " & Db_name & ".dbo.Define_TwoGroup(Id,NamTwo,IdCodeTwo,IdOne) SELECT Id,NamTwo,IdCodeTwo,IdOne FROM " & oldDbName & ".dbo.Define_TwoGroup", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PKala.Value += 1
            Application.DoEvents()

            ''''''''''''''''''''واحد شمارش
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_Vahed ON;INSERT INTO " & Db_name & ".dbo.Define_Vahed(Id,Nam) SELECT Id,Nam FROM " & oldDbName & ".dbo.Define_Vahed", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PKala.Value += 1
            Application.DoEvents()

            ''''''''''''''''''''کالا
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SET IDENTITY_INSERT " & Db_name & ".dbo.Define_Kala ON;INSERT INTO " & Db_name & ".dbo.Define_Kala([Id],[IdCodeOne],[IdCodeTwo],[IdVahed],[Nam],[Ex_Date],[BarCode],[DK],[DK_KOL],[DK_JOZ],[WK],[WK_KOL],[WK_JOZ],[LF],[LF_Value],[HF],[HF_Value],[Activ],[Cashing],[Size],[WidthKala],[HightKala],[TopKala]) SELECT [Id],[IdCodeOne],[IdCodeTwo],[IdVahed],[Nam],[Ex_Date],[BarCode],[DK],[DK_KOL],[DK_JOZ],[WK],[WK_KOL],[WK_JOZ],[LF],[LF_Value],[HF],[HF_Value],[Activ],[Cashing],[Size],[WidthKala],[HightKala],[TopKala] FROM " & oldDbName & ".dbo.Define_Kala", ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            PKala.Value += 1
            Application.DoEvents()

            Return True
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmActionEnd", "SaveKala")
            Return False
        End Try
    End Function
End Class