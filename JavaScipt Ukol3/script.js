class Tvar {
    constructor(x, y, polomer) {
        this.x = x;
        this.y = y;
        this.polomer = polomer;
        this.barva = "blue"; // Změna barvy
    }

    vykresli(ctx) {
        ctx.fillStyle = this.barva;
        ctx.beginPath();
        ctx.arc(this.x, this.y, this.polomer, 0, Math.PI * 2);
        ctx.fill();
    }
}

class Ctverec extends Tvar {
    constructor(x, y, sirka, vyska) {
        super(x, y, 0); // Poloměr není potřeba u čtverce
        this.sirka = sirka;
        this.vyska = vyska;
        this.barva = "red"; // Změna barvy
    }

    vykresli(ctx) {
        ctx.fillStyle = this.barva;
        ctx.fillRect(this.x, this.y, this.sirka, this.vyska);
    }
}

let platno = document.getElementById("platno");
let kontext = platno.getContext("2d");

let kruh = new Tvar(100, 100, 50);
let ctverec = new Ctverec(200, 200, 100, 100);

platno.onmousemove = function(event) {
    kruh.x = event.clientX;
    kruh.y = event.clientY;
}

function nakresli() {
    kontext.clearRect(0, 0, platno.width, platno.height);

    kruh.vykresli(kontext);
    ctverec.vykresli(kontext);

    if (
        kruh.x + kruh.polomer > ctverec.x &&
        kruh.x - kruh.polomer < ctverec.x + ctverec.sirka &&
        kruh.y + kruh.polomer > ctverec.y &&
        kruh.y - kruh.polomer < ctverec.y + ctverec.vyska
    ) {
        kruh.barva = "purple";
    } else {
        kruh.barva = "blue"; 
    }

    requestAnimationFrame(nakresli);
}

nakresli();
