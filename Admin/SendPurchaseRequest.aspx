<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LogSign.Master" AutoEventWireup="true" CodeBehind="SendPurchaseRequest.aspx.cs" Inherits="Thr_fty.Admin.SendPurchaseRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <script type="text/javascript">
            function showItemAddedAlert() {
                Swal.fire({
                    title: 'Your purchase request is sent!',
                  text: 'You will here from the seller',
                    icon: 'success',
                    confirmButtonColor: '#F7BF4C',
                    showCancelButton: false,
                    confirmButtonText: 'Ok'
                }).then((result) => {
                    if (result.isConfirmed) {
                        // Redirect to the desired page when "Ok" is clicked
                        window.location.href = 'Cart.aspx';
                    }
                });
            }
       

     </script>

    <div id="signUp">
        <div id="signUpForm" class="Relative">
            <asp:Button ID="Button1" runat="server" Text="X" CssClass="btnClose" CausesValidation="False" PostBackUrl="~/Admin/Cart.aspx"/>
            <h1>Send Purchase Request</h1>
           
            <table>
                <tr>
                    <td>
                        <asp:Image ID="PrequestImg" runat="server" width ="130px" Height="150px" CssClass="Shadow" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPrice" runat="server" Font-Bold="True"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td><h3>Mobile Number : </h3></td>
                    
                </tr>
                <tr>
                    <td><asp:TextBox ID="txtMobile" placeholder="Provide mobile number" runat="server" CssClass="FluffUp" ></asp:TextBox></td>
                   
                </tr>

                <tr>
                    <td><h3>Enter message : </h3></td>
                    
                </tr>

                <tr>
                    <td> <asp:TextBox ID="txtMessage" runat="server" placeholder="Write any message to the seller(optinal)" TextMode="MultiLine" Height="25px" Width="251px" CssClass="FluffUp"></asp:TextBox></td>
                </tr>
            </table>
            <br />
            <asp:Label ID="lblFeedback" runat="server" Text="" Display="Dynamic"></asp:Label>
            <br />
            <asp:Button ID="btnRequest" runat="server" Text="Finilise" OnClick="btnRequest_Click" CssClass="OrangeButton" />
            </div>
        </div>
</asp:Content>
