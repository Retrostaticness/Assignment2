<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="Assignment2.ViewCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Cart</title>
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
                    <li class="nav-item">
                        <a class="nav-link" href="ViewCart.aspx">View Cart</a>
                    </li>
                </ul>
            </div>
        </nav>

        <div class="container mt-3">
            <h2>View Cart</h2>
            <asp:Repeater ID="rptCartItems" runat="server">
                <ItemTemplate>
                    <div>
                        <h4><%# Eval("ItemName") %></h4>
                        <p>Price: <%# Eval("Price", "{0:C}") %></p>
                        <p>Quantity: <%# Eval("Quantity") %></p>
                        <hr />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div>
                <h4>Total Price: <asp:Literal ID="litTotalPrice" runat="server"></asp:Literal></h4>
                <asp:Button ID="btnConfirmOrder" runat="server" Text="Confirm Order" OnClick="btnConfirmOrder_Click" />
            </div>
        </div>

        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    </form>
</body>
</html>