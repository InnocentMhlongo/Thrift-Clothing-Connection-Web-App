<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LogSign.Master" AutoEventWireup="true" CodeBehind="NewSubmit.aspx.cs" Inherits="Thr_fty.Admin.NewSubmit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Submit the items picture
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="signUp">
        <div id="signUpForm" class="Relative CenterText">
            <asp:Button ID="Button1" runat="server" Text="X" CssClass="btnClose" CausesValidation="False" PostBackUrl="~/Pages/Index.aspx"  />
            <h1>Submit Picture</h1>
            <br />
            <asp:FileUpload class="File" ID="FileUpload1" runat="server" ForeColor="Black" onchange="previewImage();" BackColor="#CCCCCC"/>
            <br />
            <asp:Image ID="imgPreview" runat="server" Visible="true" />
            <br />
            <asp:ImageButton ID="ImageButton1" runat="server" ImageURL="../Images/Trash.png" OnClick="ImageButton1_Click"/>
            <br />
            <asp:Label ID="lblFeedback" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
            <br />
            <div id="tblFooter">
                <asp:Button ID="btnCancel" runat="server" Text="Back" OnClick="btnCancel_Click" CssClass="BlackButton"/>
                <div id="progressCont">
                    <div id="p2Details">
                        <p class="Fineprint">details</p>
                    </div>
                    <div id="p2FirstConnector"></div>
                    <div id="p2Picture">
                        <p class="Fineprint">Picture</p>
                    </div>
                    <div id="p2SecondConnector"></div>
                    <div id="p2Price">
                        <p class="Fineprint">Price</p>
                    </div>
                </div>
                <asp:Button ID="Button2" runat="server" Text="Save" OnClick="Button2_Click" CssClass="OrangeButton"/>
            </div>
        </div>
    </div>
</asp:Content>
