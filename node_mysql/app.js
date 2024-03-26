const mysql2 = require('mysql2');
const express = require('express');
const path = require('path');

const conection = mysql2.createConnection(
    {
        host: '127.0.0.1',
        user: 'root',
        password: '',
        port: '3306',
        database: 'moje_db'
    }
);


conection.connect((error) => {
    if(error){
        console.log(error)
    } else {
        console.log("Vše je připraveno");
        conection.query(
            'SELECT * FROM uzivvatel;', (error, data) => {
                if (error) console.log(error);
                else {
                    console.log(data);
                }
            }    
        )
    }
});


const app = express();

app.use(express.static(__dirname));

app.use(express.urlencoded({extended: true}));

app.use(express.json());

app.get("/", (req, res) => {
    res.sendFile(path.join(__dirname, "index.html"));
})

app.post("/uloz-uzivatele", (req, res) => {
    conection.query(
        `INSERT INTO uzivvatel(jmeno, prijmeni) VALUES('${req.body.jmeno}', '${req.body.prijmeni}');`
    , (error, data) => {
        if (error) console.log(error)
    });
    res.redirect("/")
})

app.listen(2900);