<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="BestSellers_Admin.aspx.cs" Inherits="Thr_fty.Admin_User.BestSellers_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="CenterDiv">
         <div id="formCont" class="Relative CenterText Shadow" >
            <h1>Best sellers</h1>
            <asp:Label ID="lblMessage2" runat="server" Text="" Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" CssClass="DropFluff">
                <asp:ListItem Text="Sort by amount" Value="Sort" Selected="True" />
                <asp:ListItem Text="Best" Value="1" />
                <asp:ListItem Text="Least" Value="2" />
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true" CssClass="DropFluff">
                <asp:ListItem Text="Sort by rating" Value="Sort" Selected="True" />
                <asp:ListItem Text="Best" Value="1" />
                <asp:ListItem Text="Least" Value="2" />
            </asp:DropDownList>
            <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" BorderStyle="None" GridLines="None" CssClass="Shadow margin-cell Chin" CellSpacing="10" ShowHeader="true">
                <Columns>
                    <asp:TemplateField HeaderText="Username">
                        <ItemTemplate>
                            <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("Username") %>' Font-Bold="True" Width="120px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Amount Accumulated">
                        <ItemTemplate>
                            <asp:Label ID="lblAmmount" runat="server" Text='<%# string.Format("R{0}", Eval("Amount")) %>' Width="100px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rating">
                        <ItemTemplate>
                            <asp:Label ID="lblRating" runat="server" Text='<%# Eval("Rating") %>' Width="120px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        </div>

    
    <%-- <div id="signUp">
        <div id="signUpForm" class="Relative">
           
            <h1>Sellers Accumulated amount</h1>
           <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="Sort by amount" Value="Sort" Selected="True" />
                <asp:ListItem Text="Best" Value="1" />
                <asp:ListItem Text="Least" Value="2" />
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="Sort by rating" Value="Sort" Selected="True" />
                <asp:ListItem Text="Best" Value="1" />
                <asp:ListItem Text="Least" Value="2" />
            </asp:DropDownList>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderStyle="None" OnRowDataBound="GridView_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <div id="cartContainer">
                                <table>
                                    <tr>
                                        <td style="text-align: center; width: 100px;">Username</td>
                                        <td style="text-align: center; width: 100px;">Amount Accumulated</td>
                                        <td style="text-align: center; width: 100px;">Rating</td>
                                    </tr>
                                </table>
                            </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                                <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("Username") %>' Font-Bold="True" Width="120px"></asp:Label>
                                <asp:Label ID="lblAmmount" runat="server" Text='<%# string.Format("R{0}", Eval("Amount")) %>' Width="100px"></asp:Label>
                            <asp:Label ID="lblRating" runat="server" Text='<%# Eval("Rating") %>' Width="120px"></asp:Label>
                                
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>--%>

</asp:Content>
