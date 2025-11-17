<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LogSign.Master" AutoEventWireup="true" CodeBehind="ListItemDescription.aspx.cs" Inherits="Thr_fty.Admin.ListItemDescription" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="signUp">
        <div id="signUpForm" class="Relative">
            <asp:Button ID="Button1" runat="server" Text="X" CssClass="btnClose" CausesValidation="False" PostBackUrl="~/Pages/Index.aspx"  />
            <h1>Provide item details</h1>
            <table>
                <tr>
                    <td colspan="6">
                        <h3>Item Name</h3>
                    </td>
                    <td colspan="6">
                        <h3>Brand</h3>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:TextBox ID="txtDescription" runat="server" placeholder="Enter the item's name" CssClass="FluffUp" MaxLength="10"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Item name is required" ControlToValidate="txtDescription" SetFocusOnError="True" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <td colspan="6">
                        <asp:TextBox ID="txtBrand" runat="server" placeholder="Enter the item's brand" CssClass="FluffUp"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Brand is required" ControlToValidate="txtBrand" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <h3>Type</h3>
                    </td>
                    <td colspan="4">
                        <h3>Colour</h3>
                    </td>
                    <td colspan="4">
                        <h3>Size</h3>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:DropDownList ID="dropDownType" runat="server" AutoPostBack="True" CssClass="DropFluff"></asp:DropDownList>
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="txtColour" runat="server" placeholder="Colour" CssClass="FluffUp"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Colour is required" ControlToValidate="txtColour" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td colspan="4">
                        <asp:DropDownList ID="dropDownSize" runat="server" CssClass="DropFluff"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="8">
                        <h3>Description</h3>
                    </td>
                    <td colspan="4">
                        <h3>Condition</h3>
                    </td>
                </tr>
                <tr rowspan="3">
                    <td colspan="8">
                        <asp:TextBox ID="txtAreaCondition" runat="server" TextMode="MultiLine" CssClass="FluffUp"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Item description is required" ControlToValidate="txtAreaCondition" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td colspan="4">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="DropFluff">
                             <asp:ListItem Text="New" Value="New" Selected="True" />
                             <asp:ListItem Text="Excellent" Value="Excellent" />
                             <asp:ListItem Text="Very Good" Value="Very Good" />
                             <asp:ListItem Text="Good" Value="Good" />
                             <asp:ListItem Text="Fair" Value="Fair" />  
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <div id="tblFooter">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="BlackButton"/>
                <div id="progressCont">
                    <div id="p1Details">
                        <p class="Fineprint">details</p>
                    </div>
                    <div id="p1FirstConnector"></div>
                    <div id="p1Picture">
                        <p class="Fineprint">Picture</p>
                    </div>
                    <div id="p1SecondConnector"></div>
                    <div id="p1Price">
                        <p class="Fineprint">Price</p>
                    </div>
                </div>
                <asp:Button ID="btnSavep1" runat="server" Text="Save" OnClick="btnSavep1_Click" CssClass="OrangeButton"/>
            </div>
        </div>
    </div>
</asp:Content>
