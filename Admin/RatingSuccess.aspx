<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LogSign.Master" AutoEventWireup="true" CodeBehind="RatingSuccess.aspx.cs" Inherits="Thr_fty.Admin.RatingSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="signUp">
        <div id="signUpForm" class="Relative">
            <asp:Button ID="Button1" runat="server" Text="X" CssClass="btnClose" CausesValidation="False" PostBackUrl="~/Admin/ViewPurchases.aspx"/>
            <h2>Thanks for sharing</h2>
            <img src="../Images/8684393_star_rate_maps_location_placeholder_icon.png" />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Your feedback helps others know who to buy from "></asp:Label>
            <br />
            <asp:Button ID="Button2" runat="server" Text="Rate More" PostBackUrl="~/Admin/ViewPurchases.aspx" Width="100px" />
            <asp:Button ID="Button3" runat="server" Text="Done" PostBackUrl="~/Pages/Index.aspx" Width="100px" />
            </div>
        </div>
</asp:Content>
