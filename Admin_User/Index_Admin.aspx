<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="Index_Admin.aspx.cs" Inherits="Thr_fty.Admin_User.Index_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="CenterDiv">
         <div id="formCont" class="Relative CenterText Shadow" >
            <h1>All past sales</h1>

              <asp:Label ID="Label1" runat="server" Text="" Font-Bold="True" Font-Size="Large"></asp:Label>
             <br />
             <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" CssClass="DropFluff">
                <asp:ListItem Text="Sort" Value="Sort" Selected="True" />
                <asp:ListItem Text="Newest" Value="1" />
                <asp:ListItem Text="Oldest" Value="2" />
            </asp:DropDownList>

            <asp:Label ID="lblMessage2" runat="server" Text="" Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" BorderStyle="None" GridLines="None" CssClass="CenterText Shadow margin-cell Chin Width75" CellSpacing="10" ShowHeader="true">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="productImg" runat="server" ImageUrl= '<%# Eval("ImgDir","~/Images/{0}")%>' Width="100px" Height="117px" CssClass="Shadow"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="productName" runat="server" Text= '<%# Eval("ItemName")%>' Font-Bold="True" Width="120px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="productPrice" runat="server" Text='<%# string.Format("R{0}", Eval("Price")) %>' Width="100px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Buyer">
                        <ItemTemplate>
                            <asp:Label ID="productBuyer" runat="server" Text='<%# Eval("BuyerUsername")%>' CssClass="MakeOrange MakeBold"  Width="100px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Seller">
                        <ItemTemplate>
                            <asp:Label ID="productSeller" runat="server" Text='<%# Eval("SellerUsername")%>' CssClass="MakeOrange MakeBold"  Width="100px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderStyle="None"  >
                <Columns>
                    <asp:TemplateField >
                        <HeaderTemplate>
                            <div id="cartContainer">
                                <table>
                                    <tr>
                                        <td style="text-align: center; width: 100px;">Image</td>
                                        <td style="text-align: center; width: 100px;">Product Name</td>
                                        <td style="text-align: center; width: 100px;">Price</td>
                                        <td style="text-align: center; width: 100px;">Buyer's Username</td>
                                        <td style="text-align: center; width: 105px;">Seller's User</td>
                                    </tr>
                                </table>
                            </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div id="cartContainer">
                                <asp:Image ID="productImg" runat="server" ImageUrl= '<%# Eval("ImgDir","~/Images/{0}")%>' Width="100px" Height="117px"  />
                                <asp:Label ID="productName" runat="server" Text= '<%# Eval("ItemName")%>' Font-Size="Medium" Font-Bold="True" Width="120px" ></asp:Label>
                                <asp:Label ID="productPrice" runat="server" Text='<%# Eval("Price","R{0}")%>' Width="100px" ></asp:Label>
                                <asp:Label ID="productBuyer" runat="server" Text='<%# Eval("BuyerUsername")%>' Width="100px" ></asp:Label>--%>
                                <%-- <asp:Label ID="Label1" runat="server" Text='<%# Eval("BuyerUsername")%>' Width="100px" ></asp:Label>--%>
                            <%--</div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>--%>
        </div>
     </div>
</asp:Content>
