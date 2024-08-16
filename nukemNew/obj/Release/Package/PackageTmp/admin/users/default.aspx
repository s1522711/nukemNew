<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="nukemNew.admin.users._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <header class="p-3 sticky-top" style="background-color: #111111;">
        <div class="container">
            <div class="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
                <a href="/" class="d-flex align-items-center mb-3 mb-md-0 text-white text-decoration-none">
                    <span class="fs-4">The Nukem Store</span>
                </a>



                <ul class="nav col-12 col-lg-auto mb-2 justify-content-center mb-md-0 mx-auto">
                    <li><a href="../../" class="nav-link px-2 link-light">Home</a></li>
                    <li><a href="../../about/" class="nav-link px-2 link-light" id="aboutBtn" runat="server">About</a></li>
                    <li><a href="../" class="nav-link px-2 link-secondary" id="admin" runat="server">Admin</a></li>
                </ul>


                <!-- these are the buttons that will be displayed when the user is logged in -->
                <div class="me-2 text-end text-white" id="usernameStrDisplay" runat="server">
                    <a href="../../usercp" class="link-success"><%="Welcome! " + Session["userName"] %></a>
                </div>
                <div class="text-end text-white" runat="server" id="logoutBtnDiv">
                    <button type="button" id="logoutBtn" onserverclick="logoutBtn_Click" class="btn btn-outline-danger text-white" runat="server">Logout</button>
                </div>
                <!-- these are the buttons that will be displayed when the user is not logged in -->
                <div class="text-end text-white" runat="server" id="loginRegisterBtn">
                    <button type="button" onclick="location.href = '../../login/';"
                        class="btn btn-outline-primary text-white me-2">
                        Login
                    </button>
                    <button type="button" onclick="location.href = '../../register/';" class="btn btn-primary">Sign-up</button>
                </div>
            </div>
        </div>
    </header>

    <!-- Hero Section -->
    <div class="container-fluid p-4 bg-danger text-white">
        <div class="row justify-content-center">
            <div class="col-7">
                <p class="display-1 text-center">ADMIN PANEL</p>
                <h3 class="text-center">USER LIST</h3>
            </div>

        </div>
    </div>

    <!-- User Table -->
    <div class="container-fluid mt-3">
        <div class="row justify-content-center">
            <div class="col-sm-3 mb-2" style="width: 80%; min-width: 280px;">
                <div class="card border-0">
                    <div class="card-body">

                        <div class="card-text">
                            <asp:Repeater ID="userRepeater" runat="server">
                                <HeaderTemplate>
                                    <table class="table table-striped table-hover">
                                        <thead>
                                            <tr>
                                                <th scope="col">User ID</th>
                                                <th scope="col">Username</th>
                                                <th scope="col">Email</th>
                                                <th scope="col">Password</th>
                                                <th scope="col">Admin</th>
                                                <th scope="col">Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <th scope="row"><%# Eval("userId") %></th>
                                        <th><%# Eval("username") %></th>
                                        <th><%# Eval("email") %></th>
                                        <th><%# Eval("password") %></th>
                                        <th><%# (bool)Eval("admin") ? "Yes" : "No" %></th>
                                        <th>
                                            <asp:Button runat="server" Text='<%# (bool)Eval("admin") ? "Remove Admin" : "Make Admin" %>' CommandArgument='<%# Eval("userId") %>' OnClick="Admin_Click" CssClass='<%# (bool)Eval("admin") ? "btn btn-danger" : "btn btn-success" %>' />
                                        </th>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                        </tbody>
                                    </table>
   
                                </FooterTemplate>
                            </asp:Repeater>

                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
