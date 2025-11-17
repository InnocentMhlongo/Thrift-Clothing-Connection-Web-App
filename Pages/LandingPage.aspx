<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site2.Master" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="Thr_fty.Pages.LandingPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Welecome to the home of the Best thrift store
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="hero">
        <div id="mask">
            <div id="heroDetails">
                <h1 id="heroHeader" class="MakeWhite NoSpace">
                    Home of the best thrift ever
                </h1>
                <p id="heroSubheader" class="MakeWhite NoSpace">
                    Shop from hundreds of pre-loved clothing items.
                </p>
                <asp:Button ID="btnShopNowHori" runat="server" Text="Shop now"  CausesValidation="False" ForeColor="Black" Font-Bold="True" BackColor="#F7BF4C" BorderWidth="10px" BorderColor="#F7BF4C" PostBackUrl="~/Pages/LogIn.aspx" />
            </div>
            <div id="coolImg" class="NoSpace">
                <img src="../Images/Mannequin-removebg-preview.png" />
            </div>
            
        </div>
        <%--<div id="heroContainer">
            <h1 id="heroH1">Home Of <br />The Best <br /> Thrift Ever</h1>
            <h1 id="aboutUsP">Shop from hundred's of pre-loved clothes</h1>           
            <div id="ShopNow">
                <asp:Button ID="btnShopNowHori" runat="server" Text="Shop now"  CausesValidation="False" ForeColor="Black" Font-Bold="True" BackColor="#F7BF4C" BorderWidth="10px" BorderColor="#F7BF4C" PostBackUrl="~/Pages/LogIn.aspx" />
            </div>
        </div>--%>
    </div>
</asp:Content>
