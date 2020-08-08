Module Calculate_Wam
    Public TmpK, TmpA, TmpR1, TmpR2, TmpSoodAzGhest, TmpAslAzGhest, Tmp1, Tmp2, Tmp3 As Double
   
    Public Function K(ByVal N As Double, ByVal m As Double) As Double
        Try
            TmpK = N \ m
            Return TmpK
        Catch ex As Exception
        End Try
    End Function
    Public Function R1(ByVal P As Double, ByVal r As Double, ByVal Mohlat As Double) As Double
        Try
            Mohlat = Mohlat * 30    'تبدیل ماه به روز
            Tmp1 = P * r * Mohlat
            TmpR1 = Tmp1 / 36500
            Return TmpR1
        Catch ex As Exception
        End Try
    End Function
    Public Function A(ByVal P As Double, ByVal r As Double, ByVal m As Double) As Double
        Try
            Tmp1 = r * m / 1200
            Tmp2 = Math.Pow(1 + Tmp1, TmpK)
            TmpA = P * Tmp1 * Tmp2 / (Tmp2 - 1)
            Return TmpA
        Catch ex As Exception
        End Try
    End Function
    Public Function R2(ByVal P As Double) As Double
        Try
            TmpR2 = (TmpK * TmpA) - P
            Return TmpR2
        Catch ex As Exception
        End Try
    End Function
    Public Function SoodAzGhest(ByVal P As Double, ByVal ShomareGhest As Double) As Double
        Try
            ' Tmp2 = Math.Pow(1 + Tmp1, TmpK - 1)
            Tmp2 = Math.Pow(1 + Tmp1, ShomareGhest - 1)
            Tmp3 = P * Tmp1 - TmpA
            SoodAzGhest = Tmp2 * Tmp3
            SoodAzGhest = SoodAzGhest + TmpA
            Return SoodAzGhest
        Catch ex As Exception
        End Try
    End Function
    Public Function AslAzGhest(ByVal P As Double, ByVal ShomareGhest As Double) As Double
        Try
            'Tmp2 = Math.Pow(1 + Tmp1, TmpK - 1)
            Tmp2 = Math.Pow(1 + Tmp1, ShomareGhest - 1)
            Tmp3 = TmpA - P * Tmp1
            AslAzGhest = Tmp2 * Tmp3
            AslAzGhest = AslAzGhest
            Return AslAzGhest
        Catch ex As Exception
        End Try
    End Function
End Module
