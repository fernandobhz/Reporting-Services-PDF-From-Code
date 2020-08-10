Imports System
Imports System.IO
Imports WindowsApplication2
Imports System.Net

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click 
        'Parametros
        Dim p_instrucao As New ReportExecutionService.ParameterValue
        p_instrucao.Name = "cd_instrucao" : p_instrucao.Value = "98"

        Dim p_produto As New ReportExecutionService.ParameterValue
        p_produto.Name = "co_produto" : p_produto.Value = "36420153"

        Dim p_mesano As New ReportExecutionService.ParameterValue
        p_mesano.Name = "mesano" : p_mesano.Value = New Date(2012, 3, 1)

        Dim values As ReportExecutionService.ParameterValue() = New ReportExecutionService.ParameterValue(2) {}
        values(0) = p_instrucao : values(1) = p_produto : values(2) = p_mesano

        Dim rs As New ReportingService2005.ReportingService2005
        Dim rsExec As New ReportExecutionService.ReportExecutionService

        Dim cred As New NetworkCredential("xxxxxxxx", "xxxxxxxxx")
        rs.Credentials = cred
        rsExec.Credentials = cred

        rsExec.LoadReport("xxxxxxx", Nothing)
        rsExec.SetExecutionParameters(values, "pt-BR")
        Dim reportBytes As Byte() = rsExec.Render("pdf", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        Using stream As FileStream = File.OpenWrite("xxxxxxxx")
            stream.Write(reportBytes, 0, reportBytes.Length)
        End Using

        System.Diagnostics.Process.Start("xxxxxxxx")
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        System.Diagnostics.Process.Start("c:\")
    End Sub
End Class
