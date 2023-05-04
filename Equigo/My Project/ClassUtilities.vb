Public Class ClassUtilities
    Shared Function PrepSQLDecimalNull(val As Object, Optional nullIfZero As Boolean = False) As String
        If val Is DBNull.Value Then Return "0"
        Dim c As Decimal
        If Not Decimal.TryParse(CStr(val), c) Then Return "0"
        If nullIfZero AndAlso CDec(val) = 0 Then Return "0"
        Return CDec(val).ToString("0.000000", Globalization.CultureInfo.InvariantCulture)
    End Function
End Class
