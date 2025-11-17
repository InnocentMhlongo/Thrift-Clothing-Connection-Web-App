<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="ViewItem.aspx.cs" Inherits="Thr_fty.Admin.ViewItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <script type="text/javascript">
       
        function showItemAddedAlert() {
            let timerInterval
            Swal.fire({
                title: 'Item added to cart',
               
                timer: 600,
               
                didOpen: () => {
                    Swal.showLoading()
                    const b = Swal.getHtmlContainer().querySelector('b')
                    timerInterval = setInterval(() => {
                        b.textContent = Swal.getTimerLeft()
                    }, 100)
                },
                willClose: () => {
                    clearInterval(timerInterval)
                }
            }).then((result) => {
             
                if (result.dismiss === Swal.DismissReason.timer) {
                    console.log('I was closed by the timer')
                }
            })
        }
     </script>

    <div id="signUp">
        <div id="signUpForm" class="Relative">
            <asp:Button ID="Button1" runat="server" Text="X" CssClass="btnClose" CausesValidation="False" PostBackUrl="~/Pages/Index.aspx"  />
            <h1>Item details</h1>

           <div id="detailia">
        <div id="detailsCont">
        <div id="imgDetailsCont">
            <asp:Image ID="imgProduct" runat="server" width ="250px" Height="310px"/>
        </div>
        <div id="productDetails">
            <div>
                <div>
                    <asp:Label ID="productName" runat="server" Width="412.5px" CssClass="MakeH1"></asp:Label>
                    <br />
                    <asp:Label ID="productPrice" runat="server" CssClass="MakeH2"></asp:Label>
                </div>
                <table id="trivia">
                    <tr>
                        <td><h3 class="MakeH3">Brand:</h3></td>
                        <td><asp:Label ID="productBrand" runat="server" CssClass="BlackBoldText"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><h3 class="MakeH3">Size:</h3></td>
                        <td><asp:Label ID="productSize" runat="server" CssClass="BlackBoldText"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><h3 class="MakeH3">Condition:</h3></td>
                        <td><asp:Label ID="productCondition" runat="server" CssClass="BlackBoldText"></asp:Label></td>
                    </tr>
                </table>
                <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CssClass="OrangeButton" OnClick="btnAddToCart_Click"/>
            </div>
        </div>
    </div>
    <div id="descCont">
        <asp:Label ID="lblDescr" runat="server" Text="Label"></asp:Label>
    </div>
    </div>
            </div>
        </div>
</asp:Content>
