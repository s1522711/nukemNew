<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="nukemNew.register._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="style.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="script.js"></script>
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
                    <button type="button" onclick="location.href = './';" class="btn btn-primary">Sign-up</button>
                </div>
            </div>
        </div>
    </header>




    <div class="container-fluid mt-3 blyat" style="height: 80vh">
        <div class="has-bg-img row d-flex h-100 justify-content-center align-items-center">
            <div class="col-sm-3 mb-2 align-self-center" style="width: 400px">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title">Register</h5>
                    </div>
                    <div class="card-body">
                        <div class="form-row form-floating mb-3">
                            <input type="text" class="form-control" id="usernameInput" name="usernameInput" placeholder="E.g. Germani" value="" minlength="5" required>
                            <label for="usernameInput">Username</label>
                            <div class="invalid-feedback">
                                Please provide a username.
                            </div>
                        </div>
                        <div class="form-row form-floating mb-3">
                            <input type="email" class="form-control" id="emailInput" name="emailInput" placeholder="john@example.com" value="" required>
                            <label for="emailInput">Email address</label>
                            <div class="invalid-feedback">
                                Please provide a proper email.
                            </div>
                        </div>
                        <!-- password pattern: pattern="[A-Za-z!@#0-9]{8,50}" -->
                        <div class="form-row form-floating mb-3">
                            <input type="password" class="form-control check-validity" pattern="[A-Za-z!@.#0-9]{8,50}" title="the password must be alphanumeric and must consist of at least 8 chars" id="passwordInput" name="passwordInput" placeholder="Must be at least 8 characters long!" aria-describedby="passwordHelpBlock" required>
                            <label for="passwordInput" class="form-label">Password</label>
                            <div id="passwordHelpBlock" class="form-text">
                                Your Password must be at least 8 characters long and must contain at least one letter and one number.
                            </div>
                        </div>
                        <div class="form-row form-floating mb-3">
                            <input type="password" class="form-control" pattern="[A-Za-z!@.#0-9]{8,50}" placeholder="Confirm Password" title="the password must be alphanumeric and must consist of at least 8 chars" id="passwordConfirmInput" name="passwordConfirmInput" value="" required>
                            <label for="passwordConfirmInput" class="form-label">Confirm Password</label>
                            <div class="invalid-feedback">
                                Please confirm your password.
                            </div>
                        </div>
                        <div class="form-row form-check mb-3">
                            <input class="form-check-input" type="checkbox" value="" id="termsCheck" name="termsCheck">
                            <label class="form-check-label" for="termsCheck">
                                I agree to the <a href="../terms/" target="_blank">terms and conditions</a>
                            </label>
                        </div>

                        <button type="submit" value="submit"
                            class="btn btn-primary btn-block col-sm-12 mb-2 text-center">
                            Submit
                        </button>
                        <div class="alert alert-danger" role="alert" id="errorMessage" runat="server">
                            ERROR: Invalid username or password.
                        </div>
                        <div class="card-text mt-4">
                            <p class="text-center">Already have an account? <a href="../login/">Login</a></p>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
