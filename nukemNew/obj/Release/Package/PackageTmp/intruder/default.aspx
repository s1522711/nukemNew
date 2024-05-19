<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="nukemNew.intruder._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="intruder-script.js"></script>
    <div class="jumbotron d-flex align-items-center bg-danger text-white vh-100" id="mainContainer">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-12">
                    <p class="display-1 text-center">INTRUDER DETECTED!</p>
                    <h3 class="text-center">you really thought im dumb????</h3>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
