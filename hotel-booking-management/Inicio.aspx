<%@ Page Title="Bienvenido - Sistema de Gestión de Hotel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="hotel_booking_management.Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <div class="welcome-container">
        <div class="welcome-content">
            <h1 class="welcome-title">Sistema de Gestión Hotelera</h1>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <div class="welcome-container">
        <div class="particles" id="particles"></div>
        <div class="floating-elements" id="floatingElements"></div>
        
        <div class="welcome-content" style="padding-top: 50px; padding-bottom: 50px;">
            <p id="dynamicWelcomePhrase" class="welcome-subtitle"></p>
        </div>
    </div>

    <style>
        .welcome-container {
            width: 100%;
            height: 100%;
            position: relative;
            color: white;
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            perspective: 1000px;
            overflow: hidden;
        }

        .welcome-content {
            text-align: center;
            z-index: 10;
            position: relative;
            margin-top: 150px; 
            margin-bottom: 150px; 
        }

        .welcome-title {
            color: var(--light-color);
        }

        .welcome-subtitle {
            font-size: 2rem;
            font-weight: 500;
            margin-bottom: 30px;
            opacity: 0.9;
            animation: subtitleSlide 1.5s ease-out;
            max-width: 900px;
            line-height: 1.6;
            text-shadow: 0 5px 10px rgba(0,0,0,0.3);
        }

        .floating-elements {
            position: absolute;
            width: 100%;
            height: 100%;
            top: 0;
            left: 0;
            pointer-events: none;
        }

        .floating-element {
            position: absolute;
            border-radius: 50%;
            animation: float 5s infinite alternate;
        }

        @keyframes subtitleSlide {
            from { 
                opacity: 0;
                transform: translateY(50px);
                filter: blur(10px);
            }
            to {
                opacity: 1;
                transform: translateY(0);
                filter: blur(0);
            }
        }

        @keyframes float {
            from { transform: translateY(0) rotate(0deg); }
            to { transform: translateY(-50px) rotate(360deg); }
        }

        .particles {
            position: absolute;
            width: 100%;
            height: 100%;
            top: 0;
            left: 0;
            overflow: hidden;
        }

        .particle {
            position: absolute;
            border-radius: 50%;
            animation: particleMove 10s infinite linear;
        }
    </style>

    <script>
        const welcomePhrases = [
            "En cada habitación, creamos un santuario de comodidad y bienestar donde tus sueños y expectativas se transforman en experiencias inolvidables.",
            "Más allá de un simple alojamiento, somos creadores de momentos mágicos, diseñando cada detalle para que tu viaje sea una historia de inspiración y conexión.",
            "Nuestra pasión va más allá de las paredes: construimos puentes entre culturas, generamos experiencias únicas y convertimos cada estancia en un viaje transformador.",
            "Cada huésped es un artista de sus propias vivencias, y nosotros somos el lienzo donde pintarán recuerdos que perdurarán más allá del tiempo de su estadía.",
            "Innovación, calidez y excelencia: tres pilares que nos impulsan a reinventar constantemente el concepto de hospitalidad, haciendo de cada llegada un nuevo comienzo.",
            "No solo ofrecemos habitaciones, creamos espacios de encuentro, de descanso, de reflexión y de conexión con lo mejor de cada destino y de uno mismo.",
            "Entendemos que viajar es mucho más que moverse: es expandir horizontes, desafiar límites y descubrir la extraordinaria diversidad del mundo y de uno mismo.",
            "Nuestra misión es ser el punto de partida de tus más grandes aventuras, el refugio donde recargas energías y el lugar donde los sueños comienzan a tomar forma.",
            "Combinamos tecnología de vanguardia con el calor humano más tradicional, para que cada momento de tu estancia sea un equilibrio perfecto entre confort e inspiración.",
            "Somos más que un hotel: somos guardianes de tus experiencias, arquitectos de tus recuerdos y compañeros silenciosos en tu viaje de autodescubrimiento."
        ];

        const backgroundGradients = [
            'linear-gradient(135deg, #6a11cb 0%, #2575fc 100%)',
            'linear-gradient(135deg, #ff6a00 0%, #ee0979 100%)',
            'linear-gradient(135deg, #11998e 0%, #38ef7d 100%)',
            'linear-gradient(135deg, #ff5f6d 0%, #ffc371 100%)',
            'linear-gradient(135deg, #834d9b 0%, #d04ed6 100%)',
            'linear-gradient(135deg, #00b4db 0%, #0083b0 100%)',
            'linear-gradient(135deg, #ff4b1f 0%, #ff9068 100%)',
            'linear-gradient(135deg, #8360c3 0%, #2ebf91 100%)',
            'linear-gradient(135deg, #f09819 0%, #ff5858 100%)',
            'linear-gradient(135deg, #3494e6 0%, #ec6ead 100%)'
        ];

        function getRandomIndex(arrayLength) {
            return Math.floor(Math.random() * arrayLength);
        }

        function setupWelcomePage() {
            const phraseIndex = getRandomIndex(welcomePhrases.length);
            const gradientIndex = getRandomIndex(backgroundGradients.length);

            document.getElementById('dynamicWelcomePhrase').textContent = welcomePhrases[phraseIndex];

            document.body.style.background = backgroundGradients[gradientIndex];
            document.body.style.backgroundSize = 'cover';
            document.body.style.backgroundPosition = 'center';
            document.body.style.backgroundAttachment = 'fixed';

            const container = document.getElementById('floatingElements');
            const particlesContainer = document.getElementById('particles');

            container.innerHTML = '';
            particlesContainer.innerHTML = '';

            for (let i = 0; i < 20; i++) {
                const element = document.createElement('div');
                element.classList.add('floating-element');

                const size = Math.random() * 120 + 30;
                element.style.width = `${size}px`;
                element.style.height = `${size}px`;
                element.style.left = `${Math.random() * 100}%`;
                element.style.top = `${Math.random() * 100}%`;
                element.style.animationDelay = `${Math.random() * 5}s`;
                element.style.background = backgroundGradients[getRandomIndex(backgroundGradients.length)];

                container.appendChild(element);
            }

            for (let i = 0; i < 50; i++) {
                const particle = document.createElement('div');
                particle.classList.add('particle');

                const size = Math.random() * 50 + 10;
                particle.style.width = `${size}px`;
                particle.style.height = `${size}px`;
                particle.style.left = `${Math.random() * 100}%`;
                particle.style.top = `${Math.random() * 100}%`;
                particle.style.animationDelay = `${Math.random() * 10}s`;
                particle.style.background = backgroundGradients[getRandomIndex(backgroundGradients.length)];

                particlesContainer.appendChild(particle);
            }

            const contentSpacerTop = document.createElement('div');
            const contentSpacerBottom = document.createElement('div');
            contentSpacerTop.style.height = '100px';
            contentSpacerBottom.style.height = '100px';

            const welcomeContent = document.querySelector('.welcome-content');
            welcomeContent.prepend(contentSpacerTop);
            welcomeContent.append(contentSpacerBottom);
        }

        window.onload = setupWelcomePage;

        window.addEventListener('pageshow', function (event) {
            if (event.persisted) {
                setupWelcomePage();
            }
        });
    </script>
</asp:Content>
