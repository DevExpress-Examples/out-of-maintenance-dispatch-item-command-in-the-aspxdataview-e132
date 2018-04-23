Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Collections
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports DevExpress.Web.ASPxDataView
Imports System.Text


Partial Public Class ASPxperience_DataView_ItemCommand
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub OnItemCommand(ByVal source As Object, ByVal e As DataViewItemCommandEventArgs)
		' Message inside item
		Dim templateContainer As DataViewItemTemplateContainer = GetTemplateContainer(TryCast(e.CommandSource, Control))
		Dim commandInfo As WebControl = New WebControl(HtmlTextWriterTag.P)
		commandInfo.Style.Add(HtmlTextWriterStyle.Color, "#6FBF45")
		commandInfo.Controls.Add(New LiteralControl(String.Format("Command received (""{0}"", ""{1}"")", e.CommandName, e.CommandArgument)))
		templateContainer.Controls.Add(commandInfo)

		' External label
		Dim row As DataRowView = TryCast(e.Item.DataItem, DataRowView)
		Dim labelText As StringBuilder = New StringBuilder("Command sender data:<br />")
		labelText.AppendFormat("[EmployeeID] = {0}<br />", row("EmployeeID"))
		labelText.AppendFormat("[FirstName] = {0}<br />", row("FirstName"))
		labelText.AppendFormat("[LastName] = {0}<br />", row("LastName"))
		labelText.AppendFormat("[Country] = {0}<br />", row("Country"))
		lblExternalLabel.Text = labelText.ToString()
	End Sub

	Private Function GetTemplateContainer(ByVal innerControl As Control) As DataViewItemTemplateContainer
		Dim container As Control = innerControl.Parent
		Do While Not(TypeOf container Is DataViewItemTemplateContainer) AndAlso Not container.Parent Is Nothing
			container = container.Parent
		Loop
		Return TryCast(container, DataViewItemTemplateContainer)
	End Function
End Class