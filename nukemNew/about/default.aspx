<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="nukemNew.about._default" %>

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
                    <li><a href="./" class="nav-link px-2 link-secondary" id="aboutBtn" runat="server">About</a></li>
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
                    <button type="button" onclick="location.href = '../login/';"
                        class="btn btn-outline-primary text-white me-2">
                        Login
                    </button>
                    <button type="button" onclick="location.href = '../register/';" class="btn btn-primary">Sign-up</button>
                </div>
            </div>
        </div>
    </header>


    <div class="container-fluid p-4 bg-primary text-white">
        <div class="row justify-content-center">
            <div class="col-7">
                <p class="display-1 text-center">About</p>
                <h3 class="text-center">A little something about us!</h3>
            </div>

        </div>
    </div>

    <div class="container-fluid mt-3">
        <div class="row justify-content-center">
            <div class="col-sm-3 mb-2" style="width: 50%; min-width: 280px;">
                <div class="card border-0">
                    <div class="card-title text-center">
                        <h3>How we started?</h3>
                    </div>
                    <div class="card-body">

                        <div class="card-text text-center">
                            <p>
                                It all started when we were playing a game of Civilization 5. We were playing as Russia and we were
                            trying to get a science victory. We were so close to winning, but then we got nuked by the Americans. We
                            were so mad that we decided to make a store where you can buy nukes and rockets. We hope you enjoy our
                            store!
                            </p>
                            <p>
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. In id felis fermentum, aliquet libero sed,
                            euismod lacus. Nunc sed nisi elit. Suspendisse ut laoreet nunc. Aliquam vehicula semper tortor, nec
                            sagittis turpis venenatis sit amet. Aenean commodo vitae massa a volutpat. Integer bibendum tincidunt
                            lectus quis dignissim. Proin bibendum lorem vitae purus dignissim, ut volutpat arcu imperdiet.
                            Pellentesque eu tincidunt odio. Suspendisse pretium leo sed aliquam dapibus. Nulla facilisi. Duis porta
                            a tortor sit amet posuere.
                            </p>
                            <p>
                                Mauris malesuada blandit dictum. Ut sagittis eros tortor, a interdum nunc egestas ac. Donec id feugiat
                            eros. Nam tempus tempus est ut iaculis. Integer sit amet tempus est. Integer in lacus non quam
                            scelerisque hendrerit non dictum lorem. Fusce luctus laoreet commodo. Aliquam pretium efficitur dui at
                            feugiat. Donec maximus vulputate dignissim. Nullam non interdum leo. Vestibulum ante ipsum primis in
                            faucibus orci luctus et ultrices posuere cubilia curae;
                            </p>
                            <p>
                                Mauris rhoncus, nibh et euismod tempor, orci purus fringilla lorem, nec posuere lectus est eget urna.
                            Proin vestibulum dui eget dictum convallis. Vestibulum fringilla aliquam placerat. Etiam congue eu ante
                            id euismod. Donec magna elit, porttitor ut sapien mollis, venenatis aliquet quam. In semper convallis
                            ornare. Integer ac ullamcorper nibh, vitae lobortis est.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-3 mb-2" style="width: 50%; min-width: 280px;">
                <div class="card border-0">
                    <div class="card-title text-center">
                        <h3>Why nukes?</h3>
                    </div>
                    <div class="card-body">

                        <div class="card-text text-center">
                            <p>
                                It all started when we were playing a game of Civilization 5. We were playing as Russia and we were
                            trying to get a science victory. We were so close to winning, but then we got nuked by the Americans. We
                            were so mad that we decided to make a store where you can buy nukes and rockets. We hope you enjoy our
                            store!
                            </p>
                            <p>
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. In id felis fermentum, aliquet libero sed,
                            euismod lacus. Nunc sed nisi elit. Suspendisse ut laoreet nunc. Aliquam vehicula semper tortor, nec
                            sagittis turpis venenatis sit amet. Aenean commodo vitae massa a volutpat. Integer bibendum tincidunt
                            lectus quis dignissim. Proin bibendum lorem vitae purus dignissim, ut volutpat arcu imperdiet.
                            Pellentesque eu tincidunt odio. Suspendisse pretium leo sed aliquam dapibus. Nulla facilisi. Duis porta
                            a tortor sit amet posuere.
                            </p>
                            <p>
                                Mauris malesuada blandit dictum. Ut sagittis eros tortor, a interdum nunc egestas ac. Donec id feugiat
                            eros. Nam tempus tempus est ut iaculis. Integer sit amet tempus est. Integer in lacus non quam
                            scelerisque hendrerit non dictum lorem. Fusce luctus laoreet commodo. Aliquam pretium efficitur dui at
                            feugiat. Donec maximus vulputate dignissim. Nullam non interdum leo. Vestibulum ante ipsum primis in
                            faucibus orci luctus et ultrices posuere cubilia curae;
                            </p>
                            <p>
                                Mauris rhoncus, nibh et euismod tempor, orci purus fringilla lorem, nec posuere lectus est eget urna.
                            Proin vestibulum dui eget dictum convallis. Vestibulum fringilla aliquam placerat. Etiam congue eu ante
                            id euismod. Donec magna elit, porttitor ut sapien mollis, venenatis aliquet quam. In semper convallis
                            ornare. Integer ac ullamcorper nibh, vitae lobortis est.
                            </p>
                        </div>
                    </div>
                </div>

            </div>

        </div>
    </div>
</asp:Content>
