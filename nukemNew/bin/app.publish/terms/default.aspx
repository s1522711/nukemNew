<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="nukemNew.terms._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <header class="p-3 sticky-top" style="background-color: #111111;">
        <div class="container">
            <div class="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
                <a href="../" class="d-flex align-items-center mb-3 mb-md-0 text-white text-decoration-none">
                    <span class="fs-4">The Nukem Store</span>
                </a>



                <ul class="nav col-12 col-lg-auto mb-2 justify-content-center mb-md-0 mx-auto">
                    <li><a href="../" class="nav-link px-2 link-light">Home</a></li>
                    <li><a href="../about/" class="nav-link px-2 link-light" id="aboutBtn" runat="server">About</a></li>
                    <li><a href="../admin/" class="nav-link px-2 link-danger" id="admin" runat="server">Admin</a></li>
                </ul>


                <!-- these are the buttons that will be displayed when the user is logged in -->
                <div class="me-2 text-end text-white" id="usernameStrDisplay" runat="server">
                    <a href="../usercp" class="link-success"><%="Welcome! " + Session["userName"] %></a>
                </div>
                <div class="text-end text-white" runat="server" id="logoutBtnDiv">
                    <button type="button" id="logoutBtn" onserverclick="logoutBtn_Click" class="btn btn-outline-danger text-white" runat="server">Logout</button>
                </div>
                <!-- these are the buttons that will be displayed when the user is not logged in -->
                <div class="text-end text-white" runat="server" id="loginRegisterBtn">
                    <button type="button" onclick="location.href = '../login';"
                        class="btn btn-outline-primary text-white me-2">
                        Login
                    </button>
                    <button type="button" onclick="location.href = '../register';" class="btn btn-primary">Sign-up</button>
                </div>
            </div>
        </div>
    </header>

    <!-- Hero Section -->
    <div class="container-fluid p-4 bg-primary text-white">
        <div class="row justify-content-center">
            <div class="col-7">
                <p class="display-1 text-center">TERMS AND CONDITIONS</p>
                <!--
                <h3 class="text-center">ORDER LIST</h3>
                -->
            </div>

        </div>
    </div>

    <!-- User Table -->
    <div class="container-fluid mt-3">
        <div class="row justify-content-center">
            <div class="col-sm-3 mb-2" style="width: 80%; min-width: 280px;">
                <div class="card border-0">
                    <div class="card-body">

                        <div class="card-text text-center">
                            <h3>You hereby agree to the following terms and conditions:</h3>
                            <br />
                            <p class="h5">
                                1. You agree to pay the full amount of the order before the order is processed.
                            </p>
                            <p class="h5">
                                2. You agree to provide accurate information when placing an order.
                            </p>
                            <p class="h5">
                                3. You agree to provide accurate information when registering an account.
                            </p>
                            <p class="h5">
                                4. You agree not attempt to hack or exploit the website in any way.
                            </p>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
