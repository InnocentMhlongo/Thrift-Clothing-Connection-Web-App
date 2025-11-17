<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LogSign.Master" AutoEventWireup="true" CodeBehind="UpdatePersonalDetails.aspx.cs" Inherits="Thr_fty.Admin.UpdatePersonalDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
            function showItemAddedAlert() {
                Swal.fire({
                    title: 'Data has been updated!',
                  
                    icon: 'success',
                    confirmButtonColor: '#F7BF4C',
                    showCancelButton: false,
                    confirmButtonText: 'Ok'
                }).then((result) => {
                    if (result.isConfirmed) {
                        // Redirect to the desired page when "Ok" is clicked
                        window.location.href = 'UpdatePersonalDetails.aspx';
                    }
                });
        }
       
            function showItemAddedAlert2() {
                Swal.fire({
                    title: 'Data update failed!',
                
                    icon: 'error',
                    confirmButtonColor: '#F7BF4C',
                    showCancelButton: false,
                    confirmButtonText: 'Retry'
                }).then((result) => {
                    if (result.isConfirmed) {
                        // Redirect to the desired page when "Ok" is clicked
                        window.location.href = 'UpdatePersonalDetails.aspx';
                    }
                });
        }

        function showItemAddedAlert3() {
            Swal.fire({
                title: 'Password updated!',

                icon: 'success',
                confirmButtonColor: '#F7BF4C',
                showCancelButton: false,
                confirmButtonText: 'Ok'
            }).then((result) => {
                if (result.isConfirmed) {
                    // Redirect to the desired page when "Ok" is clicked
                    window.location.href = 'UpdatePersonalDetails.aspx';
                }
            });
        }

        function showItemAddedAlert4() {
            Swal.fire({
                title: 'Password update failed!',

                icon: 'error',
                confirmButtonColor: '#F7BF4C',
                showCancelButton: false,
                confirmButtonText: 'Retry'
            }).then((result) => {
                if (result.isConfirmed) {
                    // Redirect to the desired page when "Ok" is clicked
                    window.location.href = 'UpdatePersonalDetails.aspx';
                }
            });
        }
    </script>


     <div id="signUp">
         <div id="signUpForm" class="Relative"  >
            <asp:Button ID="Button1" runat="server" Text="X" CssClass="btnClose" CausesValidation="False" PostBackUrl="~/Pages/Index.aspx"/>
            <h1>
                Update Personal details
            </h1>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" style="margin-left: 0px" DataKeyNames="Username" GridLines="None" CellSpacing="25" CssClass="Shadow">
      
       <Columns>
    <asp:TemplateField HeaderText="User Information" ConvertEmptyStringToNull="False">
        <ItemTemplate>
            <table id="personal_details_tbl">
                <tr>
                    <td><strong>Username:</strong></td>
                    <td><asp:Label ID="lblUsername" runat="server" Text='<%# Eval("Username") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td><strong>Mobile Number:</strong></td>
                    <td><asp:Label ID="lblMobileNumber" runat="server" Text='<%# Eval("MobileNumber") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td><strong>Email Address:</strong></td>
                    <td><asp:Label ID="lblEmailAddress" runat="server" Text='<%# Eval("EmailAddress") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td><strong>First Name:</strong></td>
                    <td><asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td><strong>Last Name:</strong></td>
                    <td><asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>'></asp:Label></td>
                </tr>
                
            </table>
        </ItemTemplate>
        <EditItemTemplate>
            <table>
                <tr>
                    <td style="padding-bottom: 10px;"><strong>Username:</strong></td>
                    <td><asp:Label ID="lblUsername" runat="server" Text='<%# Bind("Username") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td style="padding-bottom: 10px;"><strong>Mobile Number:</strong></td>
                    <td><asp:TextBox ID="txtMobileNumber" runat="server" Text='<%# Bind("MobileNumber") %>'></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="padding-bottom: 10px;"><strong>Email Address:</strong></td>
                    <td><asp:TextBox ID="txtEmailAddress" runat="server" Text='<%# Bind("EmailAddress") %>' TextMode="Email"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="padding-bottom: 10px;"><strong>First Name:</strong></td>
                    <td><asp:TextBox ID="txtFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="padding-bottom: 10px;"><strong>Last Name:</strong></td>
                    <td><asp:TextBox ID="txtLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox></td>
                </tr>
            </table>
            <asp:Label ID="lblFeedback" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="First name is required" ControlToValidate="txtFirstName" ForeColor="Red" SetFocusOnError="True" Display="dynamic" ></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Last name is required" ControlToValidate="txtLastName" ForeColor="Red" SetFocusOnError="True" Display="dynamic" ></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Mobile number is required" ControlToValidate="txtMobileNumber" ForeColor="Red" SetFocusOnError="True" ></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email is required" ControlToValidate="txtEmailAddress" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email address" ControlToValidate="txtEmailAddress"  ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
        </EditItemTemplate>
    </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" ControlStyle-BorderStyle="Solid" ControlStyle-BackColor="#F7BF4C" ControlStyle-BorderWidth="0.5px" ControlStyle-CssClass="OrangeButton" ButtonType="Button" />
</Columns>

        

    </asp:GridView>
            <br />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" OnRowCancelingEdit="GridView2_RowCancelingEdit" CellSpacing="25" GridLines="None" CssClass="CenterText Chin Shadow">
                 <Columns>
                     <asp:TemplateField HeaderText="Password">
                         <ItemTemplate>
                             <table>
                                 <tr hidden="hidden">
                    <td style="padding-bottom: 10px;"><strong>Username:</strong></td>
                    <td><asp:Label ID="lblUsername" runat="server" Text='<%# Eval("Username") %>'></asp:Label></td>
                </tr>
                                 <tr>
                    <td><strong>Password:</strong></td>
                    <td><asp:Label ID="lblPassword" runat="server" Text="********"></asp:Label></td>

                               </tr>

                             </table>
                         </ItemTemplate>
                         <EditItemTemplate>
                             <table>
                                   <tr>
                    <td style="padding-bottom: 10px;"><strong>Enter Old Password :</strong></td>
                    <td><asp:TextBox ID="txtOldPassword" runat="server" Text="********" TextMode="Password"></asp:TextBox></td>
                </tr>
                                 <tr>
                    <td style="padding-bottom: 10px;"><strong>Enter New Password :</strong></td>
                    <td><asp:TextBox ID="txtPassword" runat="server" Text="********" TextMode="Password"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td style="padding-bottom: 10px;"><strong>Confirm New Password :</strong></td>
                    <td><asp:TextBox ID="txtConPassword" runat="server" Text='<%# Bind("Password") %>' TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr hidden="hidden">
                    <td style="padding-bottom: 10px;"><strong>Username:</strong></td>
                    <td><asp:Label ID="lblUsername" runat="server" Text='<%# Bind("Username") %>'></asp:Label></td>
                </tr>
                                 <br />
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Old password is required" ControlToValidate="txtOldPassword" ForeColor="Red" Display="Static"></asp:RequiredFieldValidator>
                                 <br />
                        <asp:RequiredFieldValidator ID="RequiredPasswordValidator" runat="server" SetFocusOnError="True" ControlToValidate="txtPassword" ForeColor="Red"  ErrorMessage="Password is required" Display="Static"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredCPasswordValidator" runat="server" ControlToValidate="txtConPassword" SetFocusOnError="True" ForeColor="Red" ErrorMessage="Confirming the password is required" Display="Static"></asp:RequiredFieldValidator>
                        <br />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords do not match" ControlToCompare="txtPassword" ControlToValidate="txtConPassword" ForeColor="Red" Display="Static"></asp:CompareValidator>
                             </table>
                         </EditItemTemplate>
                     </asp:TemplateField>
                      <asp:CommandField ShowEditButton="True" EditText="Reset" ControlStyle-BorderStyle="Solid" ControlStyle-BorderWidth="0.5px" ControlStyle-CssClass="BlackButton" ButtonType="Button" />
                 </Columns>
            </asp:GridView>
            <asp:Label ID="lblFeedback" runat="server" Text="" ForeColor="Red" Font-Bold="True"></asp:Label>
        </div>
    </div>
</asp:Content>
