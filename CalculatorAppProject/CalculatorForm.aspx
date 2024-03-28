<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalculatorForm.aspx.cs" Inherits="CalculatorApp.CalculatorForm" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculator App</title>
    <style type="text/css">
        .auto-style1 {
            height: 37px;
            width: 252px;
            margin-left: auto;
            margin-right: auto;
        }
        .auto-style2 {
            height: 299px;
            width: 252px;
            margin-left: auto;
            margin-right: auto;
        }
        .auto-style3 {
            margin-right: auto;
        }

        .buttonNumber{
            cursor: pointer;
            background-color: #8FC93A;
            border-radius: 5px;
        }
        .buttonNumber:hover {background-color: #79b12e;}

        .buttonAction{
            background-color: #FFB347;
            cursor: pointer;
            border-radius: 5px;
        }
        .buttonAction:hover{background-color: #E5A037}

        #btnDeleteOne{
            background-color: #fa2525;
            border-radius: 5px;
        }
        #btnDeleteOne:hover{background-color: #db1818}

        #btnClear{
            background-color :#fa2525;
        }
        #btnClear:hover{background-color: #db1818}

        #btnResult{
            margin-left:192px;
            background-color: #FFB347;
        }
        #btnResult:hover{background-color: #E5A037}
         
        </style>

</head>
<body style="height: 578px; width: 1582px;">
    <form id="form1" runat="server">
        <div class="auto-style1" style="border-style: solid solid none solid; border-color: #000000; background-color: #FFFFFF; border-top-width: medium; border-right-width: medium; border-left-width: medium;">
            <asp:Label ID="lblPanel" runat="server"></asp:Label>
        </div>
        <div class="auto-style2" style="border: medium solid #000000;">
            <asp:Button ID="btn7" class="buttonNumber" runat="server" Height="60px" Text="7" Width="60px"  ForeColor="Black" OnClick="btn7_Click" />
            <asp:Button ID="btn8" class="buttonNumber" runat="server"  Height="60px" Text="8" Width="60px" OnClick="btn8_Click" />
            <asp:Button ID="btn9" class="buttonNumber" runat="server"  Text="9" Height="60px" Width="60px" OnClick="btn9_Click" />
            <asp:Button ID="btnDivide" class="buttonAction" runat="server" Text="/" Height="60px" Width="60px" OnClick="btnDivide_Click"/>
            <br />
            <asp:Button ID="btn4" class="buttonNumber" runat="server" Text="4" Height="60px" Width="60px" OnClick="btn4_Click" />
            <asp:Button ID="btn5" class="buttonNumber" runat="server" Text="5" Height="60px" Width="60px" OnClick="btn5_Click" />
            <asp:Button ID="btn6" class="buttonNumber" runat="server" Text="6" Height="60px" Width="60px" OnClick="btn6_Click" />
            <asp:Button ID="btnMultiply" class="buttonAction" runat="server" Text="*" Height="60px" Width="60px" OnClick="btnMultiply_Click" />
            <br />
            <asp:Button ID="btn1" class="buttonNumber" runat="server" Text="1" Height="60px" Width="60px" OnClick="btn1_Click" />
            <asp:Button ID="btn2" class="buttonNumber" runat="server" Text="2" Height="60px" Width="60px" OnClick="btn2_Click"/>
            <asp:Button ID="btn3" class="buttonNumber" runat="server" Text="3" Height="60px" Width="60px" OnClick="btn3_Click" />
            <asp:Button ID="btnMinus" class="buttonAction" runat="server" Text="-" Height="60px" Width="60px" OnClick="btnMinus_Click" />
            <br />
            <asp:Button ID="btnDeleteOne" class="buttonAction" runat="server" Text="&#9003;" Height="60px" Width="60px" OnClick="btnDeleteOne_Click" />
            <asp:Button ID="btn0" class="buttonNumber" runat="server" Text="0" Height="60px" Width="60px" OnClick="btn0_Click" />
            <asp:Button ID="btnClear" class="buttonAction" runat="server" Text="C" Height="60px" Width="60px" OnClick="btnClear_Click" />
            <asp:Button ID="btnPlus" class="buttonAction" runat="server" Text="+" Height="60px" Width="60px" OnClick="btnPlus_Click" />
            <asp:Button ID="btnResult" class="buttonAction" runat="server" Text="=" Height="60px" Width="60px" OnClick="btnResult_Click" />
        </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
