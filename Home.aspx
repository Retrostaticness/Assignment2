<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Assignment2.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" /><style>
    body {
        background-color: #f8f9fa;
    }

    .navbar {
        background-color: #007bff !important;
    }

    .navbar-brand, .navbar-nav .nav-link {
        color: #ffffff !important;
    }

    .container {
        margin-top: 20px;
    }

    .card {
        transition: transform 0.3s;
    }

    .card:hover {
        transform: scale(1.05);
    }

    .card-title {
        font-size: 18px;
        font-weight: bold;
    }

    .card-text {
        color: #6c757d;
    }

    .btn-primary {
        background-color: #007bff;
        border-color: #007bff;
    }

    .btn-primary:hover {
        background-color: #0056b3;
        border-color: #0056b3;
    }
</style>
</head>
<body>  
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        
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
            <h2>Available Items</h2>
            <div class="row">
                <asp:Repeater ID="rptFlowerItems" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 mb-3">
                            <div class="card">
                                <img src='<%# Eval("ImagePath") %>' class="card-img-top" alt='<%# Eval("ItemName") %>' />
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("ItemName") %></h5>
                                    <p class="card-text"><%# Eval("Price", "{0:C}") %></p>
                                    <button type="button" class="btn btn-primary" onclick='<%# "addToCart(" + Eval("ItemID") + ");" %>'>Add to Cart</button>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

        <script>
            function addToCart(itemID) {
                PageMethods.AddToCart(itemID, onSuccess, onFailure);
            }

            function onSuccess(result) {
                alert(result); // You can display the success message in a better way
            }

            function onFailure(error) {
                alert("An error occurred: " + error.get_message());
            }
        </script>

        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    </form>
</body>
</html>