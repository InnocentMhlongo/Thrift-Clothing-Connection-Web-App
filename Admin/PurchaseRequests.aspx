<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LogSign.Master" AutoEventWireup="true" CodeBehind="PurchaseRequests.aspx.cs" Inherits="Thr_fty.Admin.PurchaseRequests"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <script type="text/javascript">
            function showItemAddedAlert() {
                Swal.fire({
                    title: 'Thank you for the feedback!',
                    text: 'It helps to manage the sales and purchases!',
                    icon: 'success',
                    confirmButtonColor: '#F7BF4C',
                    showCancelButton: false,
                    confirmButtonText: 'Ok'
                }).then((result) => {
                    if (result.isConfirmed) {
                        // Redirect to the desired page when "Ok" is clicked
                        window.location.href = 'PurchaseRequests.aspx';
                    }
                });
            }
     </script>

    <div id="signUp">
        <div id="signUpForm" class="Relative">
            <asp:Button ID="Button1" runat="server" Text="X" CssClass="btnClose" CausesValidation="False" PostBackUrl="~/Pages/Index.aspx"/>
            <h1>Purchase Requests</h1>
            <asp:Label ID="lblMessage2" runat="server" Text="" Font-Bold="true" Font-Size="Large"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" CssClass="DropFluff">
                <asp:ListItem Text="Sort" Value="Sort" Selected="True" />
                <asp:ListItem Text="Newest" Value="1" />
                <asp:ListItem Text="Oldest" Value="2" />
            </asp:DropDownList>
            <br />
            <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" BorderStyle="None" GridLines="None" CssClass="Shadow margin-cell Chin" CellSpacing="10" ShowHeader="False">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="productImg" runat="server" ImageUrl= '<%# Eval("ImgDir","~/Images/{0}")%>' Width="100px" Height="117px"  />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div id="reqContent">
                                <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("BuyerUsername")%>' CssClass="MakeBold"></asp:Label>
                                <br />
                               <asp:Label ID="productName" runat="server" Text='<%# Eval("ItemName")%>' Visible="False"></asp:Label>
                                <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price")%>' Visible="False"></asp:Label>
                                <br />
                                <asp:Label ID="lblMessage" runat="server" Text='<%# Eval("Message")%>'></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("Mobile")%>' CssClass="MakeBold MakeOrange"></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" Text="Purchased" onClick="btnPurchased_Click" CssClass="OrangeButton"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="Button2" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="BlackButton"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        </div>
    <asp:Button ID="btnContShopping" class="btnContShopping" runat="server" Text="Continue Shopping" PostBackUrl="~/Pages/Index.aspx" CssClass="btnContShopping" style="margin-left: 510px"  />
</asp:Content>
