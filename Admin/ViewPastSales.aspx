<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LogSign.Master" AutoEventWireup="true" CodeBehind="ViewPastSales.aspx.cs" Inherits="Thr_fty.Admin.ViewPastSales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="signUp">
         <div id="signUpForm" class="Relative"  >
            <asp:Button ID="Button1" runat="server" Text="X" CssClass="btnClose" CausesValidation="False" PostBackUrl="~/Pages/Index.aspx"  />
            <h1>Your Sales</h1>
            <asp:Label ID="lblMessage2" runat="server" Text="" Font-Bold="True" Font-Size="Large"></asp:Label>
             <br />
             <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" CssClass="DropFluff">
                <asp:ListItem Text="Sort" Value="Sort" Selected="True" />
                <asp:ListItem Text="Newest" Value="1" />
                <asp:ListItem Text="Oldest" Value="2" />
            </asp:DropDownList>
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
                <td style="text-align: center; width: 105px;">Rate The Buyer</td>
            </tr>
        </table>
        </div>
    </HeaderTemplate>
        <ItemTemplate>
           <div id="cartContainer">

                <asp:Image ID="productImg" runat="server" ImageUrl= '<%# Eval("ImgDir","~/Images/{0}")%>' Width="100px" Height="117px"  />
               
                <asp:Label ID="productName" runat="server" Text= '<%# Eval("ItemName")%>' Font-Size="Medium" Font-Bold="True" Width="120px" ></asp:Label>

               <asp:Label ID="productPrice" runat="server" Text='<%# Eval("Price","R{0}")%>' Width="100px" ></asp:Label>

                <asp:Label ID="productBuyer" runat="server" Text='<%# Eval("BuyerUsername")%>' Width="100px" ></asp:Label>

               <asp:Button ID="btnRate" class="btnRate" runat="server" Text="Rate " CssClass="btnRate" Width="105px" OnClick="btnRate_Click" />
                
            </div>
        </ItemTemplate>
        </asp:TemplateField>
                     </Columns>
            </asp:GridView>--%>
            <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" BorderStyle="None" GridLines="None" CssClass="CenterText Shadow margin-cell Chin Width75" CellSpacing="10" ShowHeader="False">
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
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="productBuyer" runat="server" Text='<%# Eval("BuyerUsername")%>' CssClass="MakeOrange MakeBold"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnRate" class="btnRate" runat="server" Text="Rate " CssClass="btnRate OrangeButton" Width="105px" OnClick="btnRate_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        </div>
    <asp:Button ID="btnContShopping" class="btnContShopping" runat="server" Text="Continue Shopping" PostBackUrl="~/Pages/Index.aspx" CssClass="btnContShopping" style="margin-left: 510px"  />
    
</asp:Content>
