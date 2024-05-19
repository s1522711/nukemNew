<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="nukemNew.userCp._default" %>

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
                    <a href="./" class="link-success"><%="Welcome! " + Session["userName"] %></a>
                </div>
                <div class="text-end text-white" runat="server" id="logoutBtnDiv">
                    <button type="button" id="logoutBtn" onserverclick="logoutBtn_Click" class="btn btn-outline-danger text-white" runat="server">Logout</button>
                </div>
                <!-- these are the buttons that will be displayed when the user is not logged in -->
                <div class="text-end text-white" runat="server" id="loginRegisterBtn">
                    <button type="button" onclick="location.href = '../login/';"
                        class="btn btn-outline-primary text-white me-2">
                        Login
                    </button>
                    <button type="button" onclick="location.href = '../register/';" class="btn btn-primary">Sign-up</button>
                </div>
            </div>
        </div>
    </header>






    <!-- Hero Section -->
    <div class="container-fluid p-4 bg-success text-white">
        <div class="row justify-content-center">
            <div class="col-7">
                <p class="display-1 text-center">Your Profile</p>
                <!-- <h3 class="text-center">MAIN PAGE</h3> -->
            </div>

        </div>
    </div>

    <!-- cards -->
    <div class="container-fluid mt-3" id="collapseGroup">
        <div class="row justify-content-center">
            <div class="col-sm-3 mb-3" style="width: 400px">
                <div class="card">
                    <div class="card-body">
                        <div class="card-title">User info</div>
                    </div>
                    <button type="button" class="btn btn-primary btn-block col-sm-11 mb-2 mx-auto" data-toggle="collapse" data-bs-toggle="collapse" data-bs-target="#userCollapse">
                        View your user info
                    </button>
                </div>
            </div>
            <div class="col-sm-3 mb-3" style="width: 400px">
                <div class="card">
                    <div class="card-body">
                        <div class="card-title" runat="server" id="orderCountDiv">Order list</div>
                    </div>
                    <button type="button" class="btn btn-primary btn-block col-sm-11 mb-2 mx-auto" data-bs-toggle="collapse" data-bs-target="#ordersCollapse">
                        View Orders List
                    </button>
                </div>
            </div>


        </div>

        <div class="collapse justify-content-center" id="ordersCollapse" data-bs-parent="#collapseGroup">
            <div class="card">
                <div class="card-header text-center h5">Your Orders:</div>
                <div class="card-body">
                    <table class="table table-striped table-hover">
                        <thead>
                            <tr>
                                <th scope="col">ID</th>
                                <th scope="col">Name</th>
                                <th scope="col">Email</th>
                                <th scope="col">Product</th>
                                <th scope="col">Price</th>
                                <th scope="col">Country</th>
                                <th scode="col">Address</th>
                                <th scope="col">Zip</th>
                                <th scope="col">Last 4 CC</th>
                            </tr>
                        </thead>
                        <tbody class="table-group-divider" runat="server" id="orderTableBody">
                            <tr>
                                <th scope="row" colspan="9">rip</th>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

        <div class="collapse justify-content-center" id="userCollapse" data-bs-parent="#collapseGroup">
            <div class="card">
                <div class="card-header text-center h5">Your Info:</div>
                <div class="card-body">
                    <dl class="row">
                        <dt class="col-sm-6 text-end">User ID:</dt>
                        <dd class="col-sm-6 text-start" runat="server" id="uidField">#1</dd>

                        <dt class="col-sm-6 text-end">Username:</dt>
                        <dd class="col-sm-6 text-start" runat="server" id="usernameField">snickerV5</dd>

                        <dt class="col-sm-6 text-end">Email:</dt>
                        <dd class="col-sm-6 text-start" runat="server" id="emailField">test@example.com</dd>

                        <dt class="col-sm-6 text-end">Password Hash:</dt>
                        <dd class="col-sm-6 text-start text-truncate" runat="server" id="passhashField">hlkjgfjhlkjlkfgjdhlj906543hkjl</dd>

                        <dt class="col-sm-6 text-end">Admin perms?</dt>
                        <dd class="col-sm-6 text-start" runat="server" id="adminField">False</dd>
                    </dl>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
