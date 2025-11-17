<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LogSign.Master" AutoEventWireup="true" CodeBehind="SetPrice.aspx.cs" Inherits="Thr_fty.Admin.SetPrice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="signUp">
        <div id="signUpForm" class="Relative CenterText">
            <asp:Button ID="Button1" runat="server" Text="X" CssClass="btnClose" CausesValidation="False" PostBackUrl="~/Pages/Index.aspx"  />
            <h1>Set Price</h1>
            <p>What price do you want to list the item for?</p>
            <br />
            <div id="pCon">
                <div id="justTesting">
                <p class="Padding MakeWhite OrangeBack MakeBold">R</p>
                <asp:TextBox ID="txtPrice" runat="server" TextMode="Number" CssClass="NoLBorder CenterText"></asp:TextBox>
                </div>
            </div>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Price is required" ControlToValidate="txtPrice" SetFocusOnError="True" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblRecoPrice" runat="server" Text="" Font-Bold="True" Font-Size="Large"></asp:Label>
            <br />
                <div id="tblFooter">
                    <asp:Button ID="btnBackp3" runat="server" Text="Back" OnClick="btnBackp3_Click" CssClass="BlackButton"/>
                    <div id="progressCont">
                        <div id="p3Details">
                            <p class="Fineprint">details</p>
                        </div>
                        <div id="p3FirstConnector"></div>
                        <div id="p3Picture">
                            <p class="Fineprint">Picture</p>
                        </div>
                        <div id="p3SecondConnector"></div>
                        <div id="p3Price">
                            <p class="Fineprint">Price</p>
                        </div>
                    </div>
                <asp:Button ID="btnSavep3" runat="server" Text="Save" OnClick="btnSavep3_Click" CssClass="OrangeButton"/>
            </div>
            </div>
        </div>
</asp:Content>
