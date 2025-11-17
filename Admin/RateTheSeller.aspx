<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LogSign.Master" AutoEventWireup="true" CodeBehind="RateTheSeller.aspx.cs" Inherits="Thr_fty.Admin.RateTheSeller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <script type="text/javascript">
            function showItemAddedAlert() {
                Swal.fire({
                    title: 'Thank you for the feedback!',
                    text: 'It helps others to know who to sell to!',
                    icon: 'success',
                    confirmButtonColor: '#F7BF4C',
                    showCancelButton: false,
                    confirmButtonText: 'Ok'
                }).then((result) => {
                    if (result.isConfirmed) {
                        // Redirect to the desired page when "Ok" is clicked
                        window.location.href = 'ViewPurchases.aspx';
                    }
                });
            }
        </script>



    <div id="signUp">
        <div id="signUpForm" class="Relative">
            <asp:Button ID="Button1" runat="server" Text="X" CssClass="btnClose" CausesValidation="False" PostBackUrl="~/Admin/ViewPurchases.aspx"/>
            <h1>Rate The Seller</h1>

            <asp:Label ID="lblSellerUsername" runat="server" Text="" Font-Bold="True"></asp:Label>
            <br />
            <br />
           <%-- <div class="star-rating">
                <asp:LinkButton ID="star1" runat="server" CssClass="star" CommandName="Rate" CommandArgument="1" OnClientClick="return rateSeller(this);">&#9733;</asp:LinkButton>
                <asp:LinkButton ID="star2" runat="server" CssClass="star" CommandName="Rate" CommandArgument="2" OnClientClick="return rateSeller(this);">&#9733;</asp:LinkButton>
                <asp:LinkButton ID="star3" runat="server" CssClass="star" CommandName="Rate" CommandArgument="3" OnClientClick="return rateSeller(this);">&#9733;</asp:LinkButton>
                <asp:LinkButton ID="star4" runat="server" CssClass="star" CommandName="Rate" CommandArgument="4" OnClientClick="return rateSeller(this);">&#9733;</asp:LinkButton>
                <asp:LinkButton ID="star5" runat="server" CssClass="star" CommandName="Rate" CommandArgument="5" OnClientClick="return rateSeller(this);">&#9733;</asp:LinkButton>
            </div>--%>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="157px" CssClass="DropFluff">
                <asp:ListItem Text="Rate the seller here ->" Value="Rate the seller" Selected="True" />
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

            <!-- HiddenField to store the selected rating value -->
           <%-- <asp:HiddenField ID="hfRating" runat="server" />--%>

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

<%--    <script type="text/javascript">
        function rateSeller(starButton) {
            // Change the color of the clicked star and revert the color of others
            var rating = parseInt(starButton.getAttribute('CommandArgument'));
            var stars = document.getElementsByClassName('star');

            for (var i = 0; i < stars.length; i++) {
                var star = stars[i];
                var starRating = parseInt(star.getAttribute('CommandArgument'));

                if (starRating <= rating) {
                    star.style.color = 'gold'; // Change color for clicked stars
                } else {
                    star.style.color = 'black'; // Revert color for other stars
                }
            }

            // Set the hidden field value to the rating for server-side retrieval
            var hfRating = document.getElementById('<%= hfRating.ClientID %>');
            hfRating.value = rating;

            return true; // Continue with server-side click event
        }
    </script>--%>
</asp:Content>
