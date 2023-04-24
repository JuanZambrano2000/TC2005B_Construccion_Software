// server/index.js
const express = require("express");
const bodyParser = require('body-parser');
const fs = require("fs");
const mysql = require("mysql");
const PORT = process.env.PORT || 3001;
const app = express();
app.use(bodyParser.json());

const connection = mysql.createConnection({
  host: 'localhost',
  user: 'apiuser',
  password: '1234',
  database: 'empresa'
})

connection.connect();

connection.query('SELECT 1 + 1 AS solution', (err, rows, fields) => {
  if (err) throw err

  console.log('The solution is: ', rows[0].solution)
})

app.get("/api/table", (req, res)=>{
  connection.query('SELECT * FROM EMPLOYEE', (err, rows) => {
    if (err) throw err
    res.send(rows);
  })
  connection.end();
});

app.get("/api/hello", (req, res) => {
  res.json({ message: "Hello from server side!", dogsName: "Buddy"});
  connection.end();
});

app.get("/api/pet", (req, res) => {
  fs.readFile( __dirname + "/" + "pets.json", "utf8", (err, data) => {
    console.log( data );
    res.end( data );
  });
  connection.end();
});

app.post("/api/pet", (req, res) => {
  console.log('El cuerpo de la peticion:', req.body);
  connection.end();
});

app.listen(PORT, () => {
  console.log(`Server listening on ${PORT}`);
})