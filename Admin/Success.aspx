<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LogSign.Master" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="Thr_fty.Admin.Success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="signUp">
        <div id="signUpForm" class="Relative">
            <h1>Purchase Request</h1>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Label ID="Label1" runat="server" Text="Your request to purchase has been sent, you will hear from the seller" Font-Bold="True"></asp:Label>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnContShopping" class="btnContShopping" runat="server" Text="Continue Shopping" PostBackUrl="~/Admin/Cart.aspx" CssClass="btnContShopping" style="margin-left: 137px" />
            </div>
        </div>
</asp:Content>
