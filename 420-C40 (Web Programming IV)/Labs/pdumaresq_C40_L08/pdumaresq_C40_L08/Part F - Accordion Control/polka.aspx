<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="polka.aspx.cs" Inherits="Part_F___Accordion_Control.polka" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/css.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager runat="server" ID="smPolka"></asp:ScriptManager>
        
        <ajaxToolkit:Accordion ID="accPanel1" runat="server" CssClass="accordion" 
            HeaderCssClass="headerClass" HeaderSelectedCssClass="headerSelected" ContentCssClass="contentClass">
            <Panes>
                <ajaxToolkit:AccordionPane runat="server" ID="pane1">
                    <Header>Pane 1</Header>
                    <Content>
                        <asp:Label runat="server" ID="lblLabel" Text="A Label" ></asp:Label>
                        <asp:Button ID="Button1" runat="server" Text="A button" />
                    </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane runat="server" ID="pane2">
                    <Header>Pane 2</Header>
                    <Content>
                        <asp:Calendar ID="calCalendar1" runat="server"></asp:Calendar>
                    </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane runat="server" ID="pane3">
                    <Header>Pane 3</Header>
                    <Content>
                        <ajaxToolkit:PieChart ID="PieChart1" ChartTitle="Random Pie chart" ChartHeight="555" ChartWidth="555"  runat="server">
                            <PieChartValues>
                                <ajaxToolkit:PieChartValue Data="90" PieChartValueColor="red" PieChartValueStrokeColor="blue" Category="Red" />
                            </PieChartValues>
                            <PieChartValues>
                                <ajaxToolkit:PieChartValue Data="10" PieChartValueColor="blue" PieChartValueStrokeColor="red" Category="Blue" />
                            </PieChartValues>
                        </ajaxToolkit:PieChart>
                    </Content>
                </ajaxToolkit:AccordionPane>
            </Panes>
        </ajaxToolkit:Accordion>
        <hr />
        <ajaxToolkit:Accordion ID="accPanel2" runat="server" CssClass="accordion" 
            HeaderCssClass="headerClass" HeaderSelectedCssClass="headerSelected" ContentCssClass="contentClass">

        </ajaxToolkit:Accordion>
    </div>
    </form>
</body>
</html>
