<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="nukemNew.login._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="style.css">
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
                    <button type="button" onclick="location.href = './';"
                        class="btn btn-outline-primary text-white me-2">
                        Login
                    </button>
                    <button type="button" onclick="location.href = '../register/';" class="btn btn-primary">Sign-up</button>
                </div>
            </div>
        </div>
    </header>



    <div class="container-fluid mt-3 blyat" style="height: 80vh">

        <div class="has-bg-img row d-flex h-100 justify-content-center align-items-center">
            <div class="col-sm-3 mb-2 align-self-center" style="width: 400px">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title">Login</h5>
                    </div>
                    <div class="card-body">
                        <div class="form-row mb-3">
                            <div class="form-floating mb-3">
                                <input type="text" class="form-control" id="username" name="username" placeholder="" value="" minlength="5" required>
                                <label for="username">Username</label>
                                <div class="invalid-feedback">
                                    Please provide a proper username.
                                </div>
                            </div>
                        </div>
                        <div class="mb-3">
                            <div class="form-floating mb-3">
                                <!--<input type="password" class="form-control" id="password" placeholder="password" name="passwordInput" pattern="[A-Za-z!@#.$0-9]{8,50}" title="the password must be alphanumeric and must consist of at least 8 chars" value="" required>-->
                                <input type="password" class="form-control" id="password" placeholder="password" name="password" title="the password must be alphanumeric and must consist of at least 8 chars" value="" required>
                                <label for="password" class="form-label">Password</label>
                                <div class="invalid-feedback">
                                    Please provide a password.
                                </div>
                            </div>
                        </div>
                        <button type="submit" class="btn btn-primary btn-block col-sm-12 mb-2 text-center">Submit</button>
                        <div class="alert alert-danger" role="alert" id="errorMessage" runat="server">
                            ERROR: Invalid username or password.
                        </div>

                        <div class="card-text mt-4">
                            <p class="text-center ">Don't have an account? <a href="../register/">Sign-up</a></p>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
