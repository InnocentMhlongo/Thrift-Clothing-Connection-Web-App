<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LogSign.Master" AutoEventWireup="true" CodeBehind="MyRequests.aspx.cs" Inherits="Thr_fty.Admin.MyRequests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="signUp">
        <div id="signUpForm" class="Relative">
            <asp:Button ID="Button1" runat="server" Text="X" CssClass="btnClose" CausesValidation="False" PostBackUrl="~/Pages/Index.aspx"  />
            <h1>Purchase Requested</h1>
            <br />
            <asp:Label ID="lblMessage2" runat="server" Text="" Font-Bold="true" Font-Size="Large" Visible="false"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" CssClass="DropFluff">
                <asp:ListItem Text="Sort" Value="Sort" Selected="True" />
                <asp:ListItem Text="Newest" Value="1" />
                <asp:ListItem Text="Oldest" Value="2" />
            </asp:DropDownList>
            <br />
            <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" BorderStyle="None" GridLines="None" CssClass="CenterText Shadow margin-cell Chin" CellSpacing="10" ShowHeader="False">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="productImg" runat="server" ImageUrl= '<%# Eval("ImgDir","~/Images/{0}")%>' Width="100px" Height="117px"  />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="productName" runat="server" Text= '<%# Eval("ItemName")%>' Font-Bold="True" Width="120px" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("SellerUsername")%>' CssClass="MakeOrange MakeBold"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" onClick="btnDelete_Click" CssClass="BlackButton"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
<%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderStyle="None" >
                 <Columns>
    <asp:TemplateField >
         <HeaderTemplate>
        <div id="cartContainer">
            <table>
            <tr>
                <td style="text-align: center; width: 100px;">Image</td>
                <td style="text-align: center; width: 100px;">Product Name</td>
               <td style="text-align: center; width: 100px;">Seller Username</td>
                
            </tr>
        </table>
        </div>
    </HeaderTemplate>
        <ItemTemplate>
           <div id="cartContainer">

                <asp:Image ID="productImg" runat="server" ImageUrl= '<%# Eval("ImgDir","~/Images/{0}")%>' Width="100px" Height="117px"  />
               
                <asp:Label ID="productName" runat="server" Text= '<%# Eval("ItemName")%>' Font-Bold="True" Width="120px" ></asp:Label>

               <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("SellerUsername")%>' Width="100px" ></asp:Label>

               <asp:Button ID="btnDelete" runat="server" Text="Delete request" onClick="btnDelete_Click"/>

               
                
            </div>
        </ItemTemplate>
        </asp:TemplateField>
                     </Columns>
            </asp:GridView>--%>
        </div>
        </div>
    <asp:Button ID="btnContShopping" class="btnContShopping" runat="server" Text="Continue Shopping" PostBackUrl="~/Pages/Index.aspx" CssClass="btnContShopping" style="margin-left: 510px"  />
</asp:Content>
