<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/SubmitPicture.Master" AutoEventWireup="true" CodeBehind="SubmitPicture.aspx.cs" Inherits="Thr_fty.Admin.SubmitPicture" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Submit">
        <h1>Submit Picture</h1>
        <br />
        
        <asp:ImageButton ID="ImageButton1" runat="server" ImageURL="../Images/Trash.png" OnClick="ImageButton1_Click"/>

         <hr />
        <asp:Image ID="imgPreview" runat="server" Visible="false" />
        <asp:FileUpload class="File" ID="FileUpload1" runat="server" ForeColor="Black" onchange="previewImage();" />
        <br />
        <asp:Label ID="lblFeedback" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
        <br />
        <asp:Button ID="btnCancel" runat="server" Text="Back" OnClick="btnCancel_Click" />
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
        <asp:Button ID="Button2" runat="server" Text="Save Changes" OnClick="Button2_Click" />

       
    </div>
   
</asp:Content>

