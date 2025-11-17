<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LogSign.Master" AutoEventWireup="true" CodeBehind="RateTheBuyer.aspx.cs" Inherits="Thr_fty.Admin.RateTheBuyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
            function showItemAddedAlert() {
                Swal.fire({
                    title: 'Thank you for the feedback!',
                    text: 'It helps others to know who to buy from!',
                    icon: 'success',
                    confirmButtonColor: '#F7BF4C',
                    showCancelButton: false,
                    confirmButtonText: 'Ok'
                }).then((result) => {
                    if (result.isConfirmed) {
                        // Redirect to the desired page when "Ok" is clicked
                        window.location.href = 'ViewPastSales.aspx';
                    }
                });
            }
    </script>

     <div id="signUp">
        <div id="signUpForm" class="Relative">
            <asp:Button ID="Button1" runat="server" Text="X" CssClass="btnClose" CausesValidation="False" PostBackUrl="~/Admin/ViewPurchases.aspx"/>
            <h1>Rate The Buyer</h1>

            <asp:Label ID="lblBuyerUsername" runat="server" Text="" Font-Bold="True"></asp:Label>
            <br />
            <br />
          
            <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="157px" CssClass="DropFluff">
                <asp:ListItem Text="Rate the Buyer here ->" Value="Rate the seller" Selected="True" />
                <asp:ListItem Text="Terrible" Value="1" />
                <asp:ListItem Text="Poor" Value="2" />
                <asp:ListItem Text="Average" Value="3" />
                <asp:ListItem Text="Good" Value="4" />
                <asp:ListItem Text="Excellent" Value="5" />
            </asp:DropDownList>

            <!-- Textarea for users to provide a rating description -->
            <div id="ratingDescription">
                <textarea id="txtRatingDescription" runat="server" style="height: 84px; width: 267px; margin-top: 24px" placeholder="Describe your experience (Optional)" CssClass="FluffUp"></textarea>
            </div>

            <!-- Button to submit the rating -->
            <div id="submitRatingButton">
                <asp:Button ID="btnSubmitRating" class="btnContShopping" runat="server" Text="Submit"  OnClick="btnsubmit_Click" CssClass="OrangeButton" />
            </div>

            <!-- Display average seller rating -->
           <%-- <div id="averageRating">
                <h3>Average Seller Rating: <asp:Label ID="lblAverageSellerRating" runat="server" Text="" /></h3>
            </div>--%>

            </div>
          </div>


</asp:Content>
