<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LogSign.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Thr_fty.Pages.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="login">
        <div id="loginForm" class="Relative" >
            <asp:Button ID="Button1"  runat="server" Text="X" CssClass="btnClose" CausesValidation="False" PostBackUrl="~/Pages/LandingPage.aspx"  />
            <h1>
                Log in
            </h1>
            <table>
                <tr><td class="LinkLeft">Username</td></tr>
                <tr>
                    <td class="LinkLeft">
                        <asp:TextBox class="FluffUp" ID="txtUsername" runat="server" CssClass="FluffUp"></asp:TextBox>
                    </td>
                </tr>
                <tr><td class="LinkLeft">Password</td></tr>
                <tr>
                    <td class="LinkLeft">
                        <asp:TextBox class="FluffUp" ID="txtPassword" runat="server" TextMode="Password" CssClass="FluffUp" ForeColor="Black"></asp:TextBox>
                        
                    </td>
                </tr>
                
                <tr>
                    <td class="LinkLeft">
                        <asp:Button class="btnStyleS" ID="btnLogInSubmit" runat="server" Text="Login" CssClass="OrangeButton Small_margin" CausesValidation="True" OnClick="btnLogInSubmit_Click"  />
                    </td>
                </tr>
                <tr>
                    <td>
                          <asp:CheckBox ID="CheckBox1" runat="server" text=" Remember me" Checked="True" />
                    </td>
                </tr>
              
                <tr>
                    <td class="LinkLeft">
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="LinkGrey"  CausesValidation="False" PostBackUrl="~/Pages/SignUp.aspx" >Create an account</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFeedback" runat="server" Text=" " ForeColor="Red"></asp:Label>
                        <td>
                            </tr>
                <tr>
                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Username is required" ControlToValidate="txtUsername" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                <tr>
                        <td><asp:RequiredFieldValidator ID="RequiredPasswordValidator" runat="server" SetFocusOnError="True" ControlToValidate="txtPassword" ForeColor="Red"  ErrorMessage="Password is required"></asp:RequiredFieldValidator>

                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
