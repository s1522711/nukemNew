<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="nukemNew.checkout.confirmed._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Nukem Store Confirmation</title>
    <link rel="canonical" href="https://getbootstrap.com/docs/5.3/examples/checkout/">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@docsearch/css@3">
    <link href="../checkout.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <main>
            <div class="py-5 text-center">
                <h1>Nukem Checkout form</h1>
                <br />
                <h3>Thank you for your purchase!</h3>
                <div id="orderData" runat="server">
                    <p class="lead">Your order number is: <strong>#534534</strong></p>
                    <p class="lead">You purchased: <strong>something</strong></p>
                    <p class="lead">Your total was: <strong>$264</strong></p>
                </div>
                <p class="lead">Your order will arrive in 3-5 business years.</p>
                <button type="button" onclick="location.href = '/usercp/';" class="btn btn-success">View order in user panel!</button>
                <button type="button" onclick="location.href = '/';" class="btn btn-primary">Back to the main page!</button>
            </div>
        </main>
    </div>
</asp:Content>
