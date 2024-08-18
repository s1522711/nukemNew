<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="nukemNew.admin.items.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="modal-flair-update.js"></script>
    <!-- hide arrows in number input type -->
    <style>
        /* Chrome, Safari, Edge, Opera - hide arrows in number input type */
        input::-webkit-outer-spin-button,
        input::-webkit-inner-spin-button {
            -webkit-appearance: none;
            margin: 0;
        }

        /* Firefox - hide arrows in number input type */
        input[type=number] {
            -moz-appearance: textfield;
        }
    </style>
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
                <h3 class="text-center">ITEM LIST</h3>
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
                            <asp:Repeater ID="itemRepeater" runat="server">
                                <HeaderTemplate>
                                    <div class="d-flex justify-content-between">
                                        <h4>Items</h4>
                                        <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#addItemModal">Add Item</button>
                                    </div>
                                    <table class="table table-striped table-hover">
                                        <thead>
                                            <tr>
                                                <th scope="col">ID</th>
                                                <th scope="col">Item Code</th>
                                                <th scope="col">Item Name</th>
                                                <th scope="col">Price</th>
                                                <th scope="col">image Loc</th>
                                                <th scope="col">Flair Color</th>
                                                <th scope="col">Flair Text Color</th>
                                                <th scope="col">Flair Text</th>
                                                <th scope="col">Flair Link</th>
                                                <th scope="col">Flair Preview</th>
                                                <th scope="col">Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <th scope="row"><%# Eval("Id") %></th>
                                        <th><%# Eval("itemCode") %></th>
                                        <th><%# Eval("itemName") %></th>
                                        <th>$<%# Eval("price") %></th>
                                        <th><a href='<%# Eval("imageLocation") %>' target="_blank"><%# Eval("imageLocation") %></a></th>
                                        <th><%# Eval("flairColorClass") %></th>
                                        <th><%# Eval("flairTextColorClass") %></th>
                                        <th><%# Eval("flairText") %></th>
                                        <th><%# Eval("flairLink") %></th>
                                        <th><span class='badge <%# Eval("flairColorClass") %> <%# Eval("flairTextColorClass") %>' onclick="location.href='<%# Eval("flairLink").ToString() == "n/a" ? "#" : Eval("flairLink") %>';"><a href='<%# Eval("flairLink").ToString() == "n/a" ? "#" : Eval("flairLink") %>' class=' text-decoration-none <%# Eval("flairTextColorClass") %>'><%# Eval("flairText") %></a></span></th>
                                        <th>
                                            <asp:Button runat="server" Text='Delete' CommandArgument='<%# Eval("Id") %>' OnClick="Delete_Click" CssClass='btn btn-danger' CausesValidation="false" formnovalidate="formnovalidate" />
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

    <!-- Modal -->
    <div class="modal fade" id="addItemModal" tabindex="-1" aria-labelledby="addItemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="addItemModalLabel">Add New Item</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="form-row form-floating mb-3">
                        <input required id="itemCode" name="itemCode" type="text" class="form-control mb-2" placeholder="Item Code" />
                        <label for="itemCode">Item Code</label>
                    </div>
                    <div class="form-row form-floating mb-3">
                        <input required id="itemName" name="itemName" type="text" class="form-control mb-2" placeholder="Item Name" />
                        <label for="itemName">Item Name</label>
                    </div>
                    <div class="form-row form-floating mb-3">
                        <input required id="itemPrice" name="itemPrice" type="number" class="form-control mb-2" placeholder="Item Price" />
                        <label for="itemPrice">Item Price</label>
                    </div>
                    <div class="input-row input-group mb-3">
                        <asp:FileUpload ID="imageUpload" required runat="server" CssClass="form-control" accept="image/png,image/jpeg" />
                        <label class="input-group-text" for="imageUpload">Item Image</label>
                    </div>
                    <div class="form-floating mb-3">
                        <select required onchange="updateFlair()" class="form-select" aria-label="Flair color class selection" id="flairColor" name="flairColor">
                            <option selected value="primary">Primary</option>
                            <option value="secondary">Secondary</option>
                            <option value="success">Success</option>
                            <option value="danger">Danger</option>
                            <option value="warning">Warning</option>
                            <option value="info">Info</option>
                            <option value="light">Light</option>
                            <option value="dark">Dark</option>
                        </select>
                        <label for="flairColor" class="form-label">Flair Color</label>
                    </div>
                    <div class="form-floating mb-3">
                        <select required onchange="updateFlair()" class="form-select" aria-label="Flair text color class selection" id="flairTextColor" name="flairTextColor">
                            <option value="primary">Primary</option>
                            <option value="secondary">Secondary</option>
                            <option value="success">Success</option>
                            <option value="danger">Danger</option>
                            <option value="warning">Warning</option>
                            <option value="info">Info</option>
                            <option selected value="light">Light</option>
                            <option value="dark">Dark</option>
                        </select>
                        <label for="flairTextColor" class="form-label">Flair Text Color</label>
                    </div>
                    <div class="form-row form-floating mb-3">
                        <input required oninput="updateFlair()" id="flairText" maxlength="50" name="flairText" type="text" class="form-control mb-2" placeholder="Flair Text" />
                        <label for="flairText">Flair Text</label>
                    </div>
                    <div class="form-row form-floating mb-3">
                        <input id="flairLink" name="flairLink" type="text" class="form-control mb-2" placeholder="Flair Link" />
                        <label for="flairLink">Flair Link (optional)</label>
                    </div>

                    <div class="alert alert-danger" role="alert" id="errorMessage" runat="server">
                        ERROR: Invalid username or password.
                    </div>

                </div>
                <div class="modal-footer justify-content-between">
                    <h6>Flair preview: <span id="previewFlair" class="badge text-bg-primary text-light">Flair</span></h6>
                    <!-- <button type="submit" class="btn btn-primary">Add</button> -->
                    <asp:Button runat="server" CausesValidation="true" Text="Add" OnClick="Create_click" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
