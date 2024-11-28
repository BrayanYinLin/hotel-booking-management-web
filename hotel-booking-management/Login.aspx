<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DemoWEB_Sem10.Login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login - Sistema Hotelero</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" />
    <style>
        :root {
            --primary-color: #6366f1;
            --secondary-color: #4f46e5;
            --success-color: #22c55e;
            --background-color: #f8fafc;
        }

        body {
            font-family: 'Poppins', sans-serif;
            background: linear-gradient(135deg, rgba(99, 102, 241, 0.8), rgba(79, 70, 229, 0.9)),
                        url('https://i.postimg.cc/vZNrNsQt/pexels-photo-8543167.jpg');
            background-size: cover;
            background-position: center;
            background-attachment: fixed;
            height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .login-container {
            width: 450px;
            max-width: 500px;
            padding: 1rem;
        }

        .login-card {
            background: rgba(255, 255, 255, 0.9);
            backdrop-filter: blur(10px);
            border-radius: 20px;
            border: 1px solid rgba(255, 255, 255, 0.2);
            box-shadow: 0 20px 40px rgba(0, 0, 0, 0.1);
            overflow: hidden;
            transform: translateY(0);
            transition: all 0.3s ease;
        }

        .login-card:hover {
            transform: translateY(-5px);
            box-shadow: 0 30px 60px rgba(0, 0, 0, 0.2);
        }

        .login-header {
            background: linear-gradient(135deg, var(--primary-color), var(--secondary-color));
            padding: 2rem;
            text-align: center;
            border-radius: 20px 20px 0 0;
        }

        .login-header img {
            width: 180px;
            height: 150px;
            margin-bottom: 0.5rem;
        }

        .login-title {
            color: white;
            font-size: 1.75rem;
            font-weight: 600;
            margin: 0;
        }

        .login-subtitle {
            color: rgba(255, 255, 255, 0.8);
            font-size: 1rem;
            margin-top: 0.5rem;
        }

        .login-body {
            padding: 2rem;
        }

        .form-floating {
            margin-bottom: 1.5rem;
        }

        .form-control {
            border-radius: 10px;
            border: 2px solid #e2e8f0;
            padding: 1rem;
            height: auto;
            font-size: 1rem;
            transition: all 0.3s ease;
        }

        .form-control:focus {
            border-color: var(--primary-color);
            box-shadow: 0 0 0 0.25rem rgba(99, 102, 241, 0.1);
        }

        .floating-label {
            font-size: 0.875rem;
            color: #64748b;
        }

        .btn-login {
            width: 100%;
            padding: 1rem;
            border-radius: 10px;
            background: linear-gradient(135deg, var(--primary-color), var(--secondary-color));
            border: none;
            color: white;
            font-weight: 500;
            text-transform: uppercase;
            letter-spacing: 1px;
            transition: all 0.3s ease;
        }

        .btn-login:hover {
            transform: translateY(-2px);
            box-shadow: 0 10px 20px rgba(99, 102, 241, 0.2);
        }

        .login-footer {
            text-align: center;
            padding: 1rem;
            color: #64748b;
        }

        .social-login {
            display: flex;
            gap: 1rem;
            justify-content: center;
            margin-top: 1.5rem;
        }

        .social-btn {
            width: 40px;
            height: 40px;
            border-radius: 50%;
            display: flex;
            align-items: center;
            justify-content: center;
            background: white;
            border: 2px solid #e2e8f0;
            color: #64748b;
            transition: all 0.3s ease;
        }

        .social-btn:hover {
            background: var(--primary-color);
            color: white;
            border-color: var(--primary-color);
        }

        .error-message {
            background-color: rgba(239, 68, 68, 0.1);
            color: #ef4444;
            padding: 1rem;
            border-radius: 10px;
            margin-bottom: 1rem;
            font-size: 0.875rem;
        }

        @media (max-width: 768px) {
            .login-container {
                padding: 0.5rem;
            }
        }

        .animated {
            animation: slideUp 0.5s ease-out forwards;
            opacity: 0;
        }

        @keyframes slideUp {
            0% {
                transform: translateY(20px);
                opacity: 0;
            }
            100% {
                transform: translateY(0);
                opacity: 1;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container animated">
            <div class="login-card">
                <div class="login-header">
                    <img src="https://i.postimg.cc/fyWYHyhR/logo.png" alt="Logo" class="mb-4" />
                    <h1 class="login-title">Bienvenido</h1>
                    <p class="login-subtitle">Ingresa a tu cuenta</p>
                </div>

                <div class="login-body">
                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False">
                        <div class="error-message" role="alert">
                            <i class="fas fa-exclamation-circle me-2"></i>
                            <span>Mensaje de error aquí</span>
                        </div>
                    </asp:Literal>

                    <asp:Panel ID="LoginPanel" runat="server">
                        <div class="form-floating mb-4">
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Usuario" />
                            <label for="txtUsername" class="floating-label">
                                <i class="fas fa-user me-2"></i>Usuario
                            </label>
                        </div>

                        <div class="form-floating mb-4">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Contraseña" />
                            <label for="txtPassword" class="floating-label">
                                <i class="fas fa-lock me-2"></i>Contraseña
                            </label>
                        </div>

                        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-login" Text="Iniciar Sesión" OnClick="btnLogin_Click" />
                        
                        <div class="login-footer">
                            <div class="form-check mb-3">
                                <input class="form-check-input" type="checkbox" value="" id="rememberMe" />
                                <label class="form-check-label" for="rememberMe">
                                    Recordar sesión
                                </label>
                            </div>
                            <a href="#" class="text-decoration-none">¿Olvidaste tu contraseña?</a>
                            
                            <div class="social-login">
                                <a href="#" class="social-btn">
                                    <i class="fab fa-google"></i>
                                </a>
                                <a href="#" class="social-btn">
                                    <i class="fab fa-facebook-f"></i>
                                </a>
                                <a href="#" class="social-btn">
                                    <i class="fab fa-twitter"></i>
                                </a>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>