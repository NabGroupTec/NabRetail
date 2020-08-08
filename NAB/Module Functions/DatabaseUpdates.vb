Imports System.Data.SqlClient
Imports System.Windows.Forms

Module DatabaseUpdates

    '45 Update ---> 
    Public Sub UpdateDB_45()
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using CMDRel As New SqlCommand("ALTER TABLE [dbo].[SettingProgram] ADD [S32] [nvarchar] (MAX) NOT NULL DEFAULT 1", ConectionBank)
                CMDRel.CommandTimeout = 0
                CMDRel.ExecuteNonQuery()
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        End Try
    End Sub

    Public Sub UpdateDB_46()
        Try
            '45 Update --->  اضافه کردن رابطه ویزیتور و طرف حساب
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using CMDRel As New SqlCommand("CREATE TABLE [dbo].[Define_VisitorRP]([Id] [bigint] IDENTITY(1,1) NOT NULL,[IdVisitor] [bigint] NOT NULL,[IDP] [bigint] NOT NULL,CONSTRAINT [PK_Define_P_VisitorPTF] PRIMARY KEY CLUSTERED ([Id] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY];CREATE TABLE [dbo].[Define_VisitorR]([IdVisitor] [bigint] NOT NULL, CONSTRAINT [PK_Define_VisitorPTF] PRIMARY KEY CLUSTERED ([IdVisitor] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]", ConectionBank)
                CMDRel.CommandTimeout = 0
                CMDRel.ExecuteNonQuery()
            End Using

            Using CMDRel As New SqlCommand("ALTER TABLE [dbo].[Define_VisitorRP]  WITH CHECK ADD  CONSTRAINT [FK_Define_VisitorRP_Define_People1] FOREIGN KEY([IDP]) REFERENCES [dbo].[Define_People] ([ID]) ALTER TABLE [dbo].[Define_VisitorRP] CHECK CONSTRAINT [FK_Define_VisitorRP_Define_People1] ALTER TABLE [dbo].[Define_VisitorRP]  WITH CHECK ADD  CONSTRAINT [FK_Define_VisitorRP_Define_Visitor] FOREIGN KEY([IdVisitor]) REFERENCES [dbo].[Define_Visitor] ([Id]) ALTER TABLE [dbo].[Define_VisitorRP] CHECK CONSTRAINT [FK_Define_VisitorRP_Define_Visitor] ALTER TABLE [dbo].[Define_VisitorRP]  WITH CHECK ADD  CONSTRAINT [FK_Define_VisitorRP_Define_VisitorR] FOREIGN KEY([IdVisitor]) REFERENCES [dbo].[Define_VisitorR] ([IdVisitor]) ALTER TABLE [dbo].[Define_VisitorRP] CHECK CONSTRAINT [FK_Define_VisitorRP_Define_VisitorR]", ConectionBank)
                CMDRel.CommandTimeout = 0
                CMDRel.ExecuteNonQuery()
            End Using

            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey

            Using CMD As New SqlCommand("UPDATE dbo.DB_Info SET Version=@Version", ConectionBank)
                CMD.Parameters.AddWithValue("@Version", SqlDbType.VarBinary).Value = Sec.StringEncrypt("6.15", key.CreateEncryptor)
                CMD.ExecuteNonQuery()
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        End Try
    End Sub
End Module
