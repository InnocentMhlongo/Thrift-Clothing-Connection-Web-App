<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Thr_fty.Admin.Search" %>
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

<div id="justDiv">
        <asp:DataList ID="ClothingItems" runat="server" RepeatDirection="Horizontal" RepeatColumns="4" OnItemCommand="ClothingItems_ItemCommand">
        <ItemTemplate>
            <div id="itemContainer">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl= '<%# Eval("Image_dir","~/Images/{0}")%>' Width="201px" Height="251px" CommandArgument='<%# Eval("Image_dir") %>' CommandName="GetItemDetails"/>
                <br />
                <div id="descPrice">
                    <asp:Label ID="productName" runat="server" Text= '<%# Eval("Item_name")%>' Font-Size="Medium" Font-Bold="True" Font-Names="Arial" CssClass="FloatLeft Padding"></asp:Label>
                    <asp:Label ID="productPrice" runat="server" Text='<%# Eval("Item_Price","R{0}")%>' CssClass="FloatRight Padding"></asp:Label>
                </div>
                <asp:Button ID="addToCart"  runat="server" Text="+" CommandArgument='<%# Eval("Image_dir") %>' CommandName="AddToCart" CssClass="BtnAddToCartHome" />
            </div>
        </ItemTemplate>
    </asp:DataList>
    </div>  
</asp:Content>
