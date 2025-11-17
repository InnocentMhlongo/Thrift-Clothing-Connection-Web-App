<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LogSign.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Thr_fty.Pages.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function showItemAddedAlert() {
            let timerInterval;
            Swal.fire({
                title: 'Sign up successfull',
                html: 'Redirecting you to log in <b></b> milliseconds.',
                icon: 'success',
                timer: 25000,
                timerProgressBar: true,
               
                didOpen: () => {
                    Swal.showLoading();
                    const b = Swal.getHtmlContainer().querySelector('b');
                    timerInterval = setInterval(() => {
                        b.textContent = Swal.getTimerLeft();
                    }, 100);
                },
                willClose: () => {
                    clearInterval(timerInterval);
                }
            }).then((result) => {
                if (result.dismiss === Swal.DismissReason.timer) {
                    console.log('I was closed by the timer');
                    // Redirect to the desired page after the timer has finished
                    window.location.href = 'LogIn.aspx';
                }
            });
        }
    </script>


     <div id="signUp">
        <div id="signUpForm" class="Relative">
            <asp:Button ID="Button1" runat="server" Text="X" CssClass="btnClose" CausesValidation="False" PostBackUrl="~/Pages/LandingPage.aspx"  />
            <h1>
                Sign Up
            </h1>
            <table id="signUpTable">
                <tr>
                    <td class="LinkLeft">First Name</td>
                    <td class="LinkLeft">Last Name</td>
                </tr>

                <tr >
                    <td >
                        <asp:TextBox class="FluffUp" ID="txtFirstname" runat="server" CssClass="FluffUp" placeholder="Janine" ></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="First name is required" ControlToValidate="txtFirstname" ForeColor="Red" SetFocusOnError="True" Display="static" ></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox class="FluffUp" ID="txtLastname" placeholder="Nel" runat="server" ></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Last name is required" ControlToValidate="txtLastname" ForeColor="Red" SetFocusOnError="True" Display="Static" ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="LinkLeft">Username</td>
                    <td class="LinkLeft">Mobile number</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox class="FluffUp" ID="txtUsername" runat="server" CssClass="FluffUp" placeholder="JanineNel02"  ></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  runat="server" ErrorMessage="Username is required" ControlToValidate="txtUsername" ForeColor="Red" SetFocusOnError="True" Display="Static" ></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox class="FluffUp" ID="txtMobile" runat="server" CssClass="FluffUp" placeholder="0712345678" TextMode="Phone"  ></asp:TextBox>
                         <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Mobile number is required" ControlToValidate="txtMobile" ForeColor="Red" SetFocusOnError="True" Display="Static" ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="LinkLeft" colspan="2">Email Address</td>
                </tr>
                <tr >
                    <td colspan="2" >
                        <asp:TextBox class="FluffUp" ID="txtEmail" runat="server" TextMode="Email" CssClass="FluffUp" placeholder="nelganine@gmail.com" Width="391px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email is required" ControlToValidate="txtEmail" ForeColor="Red" SetFocusOnError="True" Display="Dynamic" ></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email address" ControlToValidate="txtEmail"  ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" ></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="LinkLeft">Password</td>
                     <td class="LinkLeft">Confirm password</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox class="FluffUp" ID="txtPassword" runat="server" TextMode="Password" ></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredPasswordValidator" runat="server" SetFocusOnError="True" ControlToValidate="txtPassword" ForeColor="Red"  ErrorMessage="Password is required" Display="Dynamic" ></asp:RequiredFieldValidator>
                        <br />
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Passwords do not match" ControlToCompare="txtPassword" ControlToValidate="txtConPassword" ForeColor="Red" Display="dynamic" ></asp:CompareValidator>
                    </td>
                    <td>
                        <asp:TextBox class="FluffUp" ID="txtConPassword" runat="server" TextMode="Password" ></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredCPasswordValidator" runat="server" ControlToValidate="txtConPassword" SetFocusOnError="True" ForeColor="Red" ErrorMessage="Confirming the password is required" Display="static" ></asp:RequiredFieldValidator>
                        <br />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords do not match" ControlToCompare="txtPassword" ControlToValidate="txtConPassword" ForeColor="Red" Display="Dynamic" ></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="AlignLeft">
                        <asp:Button class="btnCancel" ID="btnCancel" runat="server" Text="Cancel" CausesValidation="False" PostBackUrl="~/Pages/LogIn.aspx" CssClass="BlackButton FloatLeft"/>
                    </td>
                    <td class="AlignRight">
                        <asp:Button class="btnStyleS" ID="btnSignUp" runat="server" Text="Sign up" OnClick="btnSignUp_Click" CssClass="OrangeButton FloatRight"/>

                    </td>
                    </tr>
                <tr>
                    <td colspan="2">
                        <p>Already have an account ? <a href="LogIn.aspx">Log in</a></p>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                           <asp:Label ID="lblFeedback" runat="server" Text=" " BorderStyle="None" ForeColor="Red" ></asp:Label>
                        
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
