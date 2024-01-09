function vytvoritTabulku() {
    let pocetRadku = document.getElementById("pocet-radku").value;
    let pocetSloupcu = document.getElementById("pocet-sloupcu").value;

    let tabulka = document.createElement("table");
    tabulka.id = "vytvorena-tabulka"; 

    for (let i = 0; i < pocetRadku; i++) {
        let radek = tabulka.insertRow(i);

        for (let j = 0; j < pocetSloupcu; j++) {
            let bunka = radek.insertCell(j);
            bunka.textContent = (i * pocetSloupcu) + j + 1;
        }
    }

    document.body.appendChild(tabulka);
}