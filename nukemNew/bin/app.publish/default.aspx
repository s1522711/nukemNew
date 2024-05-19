<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="nukemNew._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Navbar -->
    <header class="p-3 sticky-top" style="background-color: #111111;">
        <div class="container">
            <div class="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
                <a href="./" class="d-flex align-items-center mb-3 mb-md-0 text-white text-decoration-none">
                    <span class="fs-4">The Nukem Store</span>
                </a>



                <ul class="nav col-12 col-lg-auto mb-2 justify-content-center mb-md-0 mx-auto">
                    <li><a href="./" class="nav-link px-2 link-secondary">Home</a></li>
                    <li><a href="./about/" class="nav-link px-2 link-light" id="aboutBtn" runat="server">About</a></li>
                    <li><a href="./admin/" class="nav-link px-2 link-danger" id="admin" runat="server">Admin</a></li>
                </ul>


                <!-- these are the buttons that will be displayed when the user is logged in -->
                <div class="me-2 text-end text-white" id="usernameStrDisplay" runat="server">
                    <a href="./usercp" class="link-success"><%="Welcome! " + Session["userName"] %></a>
                </div>
                <div class="text-end text-white" runat="server" id="logoutBtnDiv">
                    <button type="button" id="logoutBtn" onserverclick="logoutBtn_Click" class="btn btn-outline-danger text-white" runat="server">Logout</button>
                </div>
                <!-- these are the buttons that will be displayed when the user is not logged in -->
                <div class="text-end text-white" runat="server" id="loginRegisterBtn">
                    <button type="button" onclick="location.href = './login';"
                        class="btn btn-outline-primary text-white me-2">
                        Login
                    </button>
                    <button type="button" onclick="location.href = './register';" class="btn btn-primary">Sign-up</button>
                </div>
            </div>
        </div>
    </header>

    <!-- Navbar end -->
    <!-- hero -->

    <div class="container-fluid p-4 bg-primary text-white">
        <div class="row justify-content-center">
            <div class="col-7">
                <p class="display-1 text-center">The Nukem Store</p>
                <h3 class="text-center">here you can buy rockets and nukes!</h3>
            </div>

        </div>
    </div>

    <!-- hero end -->

    <div class="container mt-3" runat="server" id="notLoggedinDiv">
        <div class="row justify-content-center">
            <div class="col-9">
                <div class="alert alert-danger alert-trim display-4 text-center">
                    Error: You are not logged in!<br />
                    Please login to view the products.
                </div>
            </div>
        </div>
    </div>

    <!-- products -->
    <div class="container-fluid mt-3" runat="server" id="productsDiv">
        <div class="row justify-content-center">
            <div class="col-sm-3 mb-2" style="width: 400px">
                <div class="card">
                    <img src="img/index/tsar-bobma.webp" alt="tsar-bobma" height="210" class=" card-img-top ">
                    <div class="card-body">
                        <div class="card-title"><%=GetProductName("TsarBomba") %> <span class="badge bg-secondary">New!</span></div>
                        <div class="card-text">Price: $<%=GetProductPrice("TsarBomba") %></div>

                    </div>
                    <button type="button" runat="server" onserverclick="tsarBombaBtn_Click"
                        class="btn btn-primary btn-block col-sm-11 mb-2 mx-auto">
                        Buy
                    </button>
                </div>
            </div>
            <div class="col-sm-3 mb-2" style="width: 400px">
                <div class="card">
                    <img src="img/index/duke-nukem.jpg" alt="duke nukem cover" height="210" class=" card-img-top ">
                    <div class="card-body">
                        <div class="card-title"><%=GetProductName("DukeNukem") %> <span class="badge bg-primary">Rare!</span></div>
                        <div class="card-text">Price: $<%=GetProductPrice("DukeNukem") %></div>

                    </div>
                    <button type="button" runat="server" onserverclick="dukeNukemBtn_Click"
                        class="btn btn-primary btn-block col-sm-11 mb-2 mx-auto">
                        Buy
                    </button>
                </div>
            </div>
            <div class="col-sm-3 mb-2" style="width: 400px">
                <div class="card">
                    <img src="img/index/cs-bomb.jpeg" alt="tsar-bobma" height="210" class=" card-img-top ">
                    <div class="card-body">
                        <div class="card-title"><%=GetProductName("CS2Bomb") %> <span class="badge bg-secondary">New!</span></div>
                        <div class="card-text">Price: $<%=GetProductPrice("CS2Bomb") %></div>

                    </div>
                    <button type="button" runat="server" onserverclick="csBombBtn_Click"
                        class="btn btn-primary btn-block col-sm-11 mb-2 mx-auto">
                        Buy
                    </button>
                </div>
            </div>
            <div class="col-sm-3 mb-2" style="width: 400px">
                <div class="card">
                    <img src="img/index/gilad.png" alt="tsar-bobma" height="210" class=" card-img-top ">
                    <div class="card-body">
                        <div class="card-title"><%=GetProductName("GiladDoll") %> <span class="badge bg-warning" onclick="location.href='secret/';"><a href="secret/" class=" text-decoration-none text-black">New!</a></span></div>
                        <div class="card-text">Price: $<%=GetProductPrice("GiladDoll") %></div>

                    </div>
                    <button type="button" runat="server" onserverclick="giladDollBtn_Click"
                        class="btn btn-primary btn-block col-sm-11 mb-2 mx-auto">
                        Buy
                    </button>
                </div>
            </div>
            <div class="col-sm-3 mb-2" style="width: 400px">
                <div class="card">
                    <img src="img/index/computer-breaker.jpg" alt="tsar-bobma" height="210" class=" card-img-top ">
                    <div class="card-body">
                        <div class="card-title">
                            <%=GetProductName("CBS") %> <span class="badge bg-secondary">New!</span>
                        </div>
                        <div class="card-text">Price: $<%=GetProductPrice("CBS") %></div>

                    </div>
                    <button type="button" runat="server" onserverclick="breakingServiceBtn_Click"
                        class="btn btn-primary btn-block col-sm-11 mb-2 mx-auto">
                        Buy
                    </button>
                </div>
            </div>
            <div class="col-sm-3 mb-2" style="width: 400px">
                <div class="card">
                    <img src="img/index/tamir-missile.jpg" alt="tsar-bobma" height="210" class=" card-img-top ">
                    <div class="card-body">
                        <div class="card-title"><%=GetProductName("TamirGTA") %> <span class="badge bg-primary">Missile!</span></div>
                        <div class="card-text">Price: $<%=GetProductPrice("TamirGTA") %></div>

                    </div>
                    <button type="button" runat="server" onserverclick="tamirGtaBtn_Click"
                        class="btn btn-primary btn-block col-sm-11 mb-2 mx-auto">
                        Buy
                    </button>
                </div>
            </div>
            <div class="col-sm-3 mb-2" style="width: 400px">
                <div class="card">
                    <img src="img/index/nick.png" alt="tsar-bobma" height="210" class=" card-img-top ">
                    <div class="card-body">
                        <div class="card-title"><%=GetProductName("Nick") %> <span class="badge bg-warning text-black" onclick="location.href='img/index/secret.jpg';"><a href="img/index/secret.jpg" class=" text-decoration-none text-black">Barely used!</a></span></div>
                        <div class="card-text">Price: $<%=GetProductPrice("Nick") %></div>

                    </div>
                    <button type="button" runat="server" onserverclick="nickBtn_Click"
                        class="btn btn-primary btn-block col-sm-11 mb-2 mx-auto">
                        Buy
                    </button>
                </div>
            </div>
            <div class="col-sm-3 mb-2" style="width: 400px">
                <div class="card">
                    <img src="img/index/Little_boy.jpg" alt="tsar-bobma" height="210" class=" card-img-top ">
                    <div class="card-body">
                        <div class="card-title"><%=GetProductName("LittleBoy") %> <span class="badge bg-primary">Rare!</span></div>
                        <div class="card-text">Price: $<%=GetProductPrice("LittleBoy") %></div>

                    </div>
                    <button type="button" runat="server" onserverclick="littleBoyBtn_Click"
                        class="btn btn-primary btn-block col-sm-11 mb-2 mx-auto">
                        Buy
                    </button>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
