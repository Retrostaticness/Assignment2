<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderConfirmed.aspx.cs" Inherits="Assignment2.OrderConfirmed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order Confirmed</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <a class="navbar-brand" href="#">Assignment2</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="Home.aspx">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Login.aspx">Login</a>
                    </li>
                </ul>
            </div>
        </nav>

        <div class="container mt-3">
            <h2>Order Confirmed</h2>
            <div>
                <asp:Repeater ID="rptConfirmedItems" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 mb-3">
                            <div class="card">
                                <img src='<%# Eval("ImagePath") %>' class="card-img-top" alt='<%# Eval("ItemName") %>'>
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("ItemName") %></h5>
                                    <p class="card-text"><%# Eval("Price", "{0:C}") %></p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <hr />
                <h4>Your order has been confirmed. Thank you for your purchase!</h4>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
</body>
</html>