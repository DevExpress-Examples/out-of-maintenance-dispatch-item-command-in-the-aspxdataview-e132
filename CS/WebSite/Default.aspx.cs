using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using DevExpress.Web.ASPxDataView;
using System.Text;


public partial class ASPxperience_DataView_ItemCommand : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }
    protected void OnItemCommand(object source, DataViewItemCommandEventArgs e) {
        // Message inside item
        DataViewItemTemplateContainer templateContainer = GetTemplateContainer(e.CommandSource as Control);
        WebControl commandInfo = new WebControl(HtmlTextWriterTag.P);
        commandInfo.Style.Add(HtmlTextWriterStyle.Color, "#6FBF45");
        commandInfo.Controls.Add(new LiteralControl(string.Format("Command received (\"{0}\", \"{1}\")", 
            e.CommandName, e.CommandArgument)));
        templateContainer.Controls.Add(commandInfo);
        
        // External label
        DataRowView row = e.Item.DataItem as DataRowView;
        StringBuilder labelText = new StringBuilder("Command sender data:<br />");
        labelText.AppendFormat("[EmployeeID] = {0}<br />", row["EmployeeID"]);
        labelText.AppendFormat("[FirstName] = {0}<br />", row["FirstName"]);
        labelText.AppendFormat("[LastName] = {0}<br />", row["LastName"]);
        labelText.AppendFormat("[Country] = {0}<br />", row["Country"]);
        lblExternalLabel.Text = labelText.ToString();
    }

    private DataViewItemTemplateContainer GetTemplateContainer(Control innerControl) {
        Control container = innerControl.Parent;
        while(!(container is DataViewItemTemplateContainer) && container.Parent != null)
            container = container.Parent;
        return container as DataViewItemTemplateContainer;
    }
}