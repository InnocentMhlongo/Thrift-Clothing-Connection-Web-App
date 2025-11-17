<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LogSign.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Thr_fty.Admin.Cart" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="signUp">
        <div id="signUpForm" class="Relative">
            <asp:Button ID="Button1" runat="server" Text="X" CssClass="btnClose" CausesValidation="False" PostBackUrl="~/Pages/Index.aspx"  />
            <h1>Cart</h1>
            <asp:Label ID="lblMessage" runat="server" Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
              <asp:Label ID="lblMessage2" runat="server"  Font-Bold="True" Font-Size="Large"></asp:Label>

             <script type="text/javascript">
              function confirmDelete() {
                  Swal.fire({
                      title: 'Are you sure you want to delete this item ?',
                      text: "You won't be able to revert this!",
                      icon: 'warning',
                      showCancelButton: true,
                      confirmButtonColor: '#F7BF4C',
                      cancelButtonColor: '#000000',
                      confirmButtonText: 'Yes, delete it!'
                  }).then((result) => {
                      if (result.isConfirmed) {  
                          __doPostBack('DeleteButtonPostBack', '');
                      } 
                  });
                 }

                 //function confirmDelete2() {
                 //    Swal.fire({
                 //        title: 'Are you sure you want to Clear everything?',
                 //        text: "You won't be able to revert this!",
                 //        icon: 'warning',
                 //        showCancelButton: true,
                 //        confirmButtonColor: '#F7BF4C',
                 //        cancelButtonColor: '#000000',
                 //        confirmButtonText: 'Yes, delete it!'
                 //    }).then((result) => {
                 //        if (result.isConfirmed) {

                         
                 //        }
                 //    });
                 //}
             </script>
             <asp:ScriptManager ID='ScriptManager1' runat='server' EnablePageMethods='true' />  
            <asp:Button ID="btnClear" runat="server" Text="Clear Cart" onclick="btnClear_Click" CssClass="BlackButton"/>
            <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" BorderStyle="None" GridLines="None" CssClass="CenterText Shadow margin-cell" CellSpacing="10" ShowHeader="False">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="ImgDir" runat="server" ImageUrl='<%# Eval("ImgDir", "~/Images/{0}") %>' Width="100px" Height="117px" CssClass="Shadow"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="productName" runat="server" Text='<%# Eval("ItemName") %>' Font-Bold="True" Width="120px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="productPrice" runat="server" Text='<%# string.Format("R{0}", Eval("Price")) %>' Width="100px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="productSeller" runat="server" Text='<%# Eval("SellerUsername") %>' Width="100px" Visible="False"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="BlackButton"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnRate" runat="server" Text="Send request" Width="105px" OnClick="btnFinilise_Click" CssClass="OrangeButton"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:ImageField>

                    </asp:ImageField>
                    <asp:TemplateField>

                        <HeaderTemplate>
                            <div id="cartContainer">
                                <table>
                                    <tr>
                                        <td style="text-align: center; width: 100px;">Image</td>
                                        <td style="text-align: center; width: 100px;">Product Name</td>
                                        <td style="text-align: center; width: 100px;">Price</td>
                                        
                                    </tr>
                                </table>
                            </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div id="cartContainer">
                                <asp:Image ID="ImgDir" runat="server" ImageUrl='<%# Eval("ImgDir", "~/Images/{0}") %>' Width="100px" Height="117px" />
                                <asp:Label ID="productName" runat="server" Text='<%# Eval("ItemName") %>' Font-Bold="True" Width="120px"></asp:Label>
                                <asp:Label ID="productPrice" runat="server" Text='<%# string.Format("R{0}", Eval("Price")) %>' Width="100px"></asp:Label>
                                <asp:Label ID="productSeller" runat="server" Text='<%# Eval("SellerUsername") %>' Width="100px" Visible="False"></asp:Label>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                                <asp:Button ID="btnRate" runat="server" Text="Send Purchase request" Width="105px" OnClick="btnFinilise_Click" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
            <br />
        
            
            
        </div>
    </div>
    <asp:Button ID="btnContShopping" class="btnContShopping" runat="server" Text="Continue Shopping" PostBackUrl="~/Pages/Index.aspx" CssClass="btnContShopping" style="margin-left: 510px"  />
</asp:Content>
