<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="unlockupdate._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <style type="text/css" >
        .box 
        { border-left: 1px solid #dadccf;
            border-right: 1px solid #dadccf;
            border-top: 2px solid #FFCC66;
            border-bottom: 1px solid #dadccf;
width:340px; 
            margin:0 auto;
        	     vertical-align:top; }

    </style>
        <script type="text/javascript">

            function radio_yes() {
                if (document.getElementById("cbOutlet").checked == true) {
                // document.getElementById('<%=txtOutlet.ClientID%>').style.visibility = "visible";
                document.getElementById('<%=txtBranchCode.ClientID%>').style.visibility = "hidden";
                document.getElementById('<%=lblBranchCode.ClientID%>').style.visibility = "hidden";
            }
            else {
               // document.getElementById('<%=txtOutlet.ClientID%>').style.visibility = "hidden";
                document.getElementById('<%=txtBranchCode.ClientID%>').style.visibility = "hidden";
                document.getElementById('<%=lblBranchCode.ClientID%>').style.visibility = "hidden";
                }
            }
        </script>

      <div  class="box">
        <img alt="Afghanistan International Bank" src="images/aiblogo.jpg" 
            style="width: 244px; height: 49px" /><br />
        <br />
        User Name:
        <asp:Label ID="lblUser" Font-Bold="true" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="txt1" runat="server"></asp:TextBox>
        <br />
        <asp:CheckBoxList ID="clbSystem" runat="server" Font-Names="Bahnschrift">
            <asp:ListItem>Flexcube</asp:ListItem>
            <asp:ListItem>CAMS</asp:ListItem>
            <asp:ListItem>Fileup</asp:ListItem>
           
            <asp:ListItem>TFL</asp:ListItem>
           
        </asp:CheckBoxList>

        <asp:TextBox ID="txtUserID" runat="server" Enabled=false Visible=false Width=100> </asp:TextBox>
        <asp:Label ID="lblusername" runat="server" Text=":Username" Visible=false></asp:Label>
        <!--
        <table >
         <tr><td><input id="cbOutlet" runat="server" onclick="radio_yes();radio_uncheck();"  type="checkbox"  /> Flexbranch:</td>
       <td>
       <asp:TextBox ID="txtOutlet" style=" visibility:hidden" runat="server" ></asp:TextBox>
       </td>
       </tr>
      
        <tr><td  align="right">
           <asp:Label ID="lblBranchCode" runat="server" style=" visibility:hidden" Text="Branch Code:"></asp:Label> </td>
       <td><asp:TextBox ID="txtBranchCode" style=" visibility:hidden" runat="server" ></asp:TextBox></td></tr>
       </table> 
        -->
        <br />
        <asp:Button ID="btnUnlock" runat="server" Text="Unlock Selected Accounts" 
            onclick="btnUnlock_Click1" /><br />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Text=""></asp:Label>
    </div>

</asp:Content>
