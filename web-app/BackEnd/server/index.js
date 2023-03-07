const express = require("express");
const fs = require("fs");
const bodyParser = require("body-parser");
const { data } = require("jquery");

const PORT = process.env.PORT || 3001;

const app = express();
app.use(bodyParser.json);

app.get("/api", (req,res) =>{
    res.json({message: "Hello from server side"});
});

app.get("/api/pet",(req, res)=>{
    fs.readFile(__dirname + "/pets.json","utf-8",(err,data)=>{
        console.log(data);
        res.end(data);
    });
});

app.post("/api/pet",(req, res)=> {
    console.log("El cuerpo y vida de la peticion: ", req.body);
    res.statusCode(200);
})

app.listen(PORT, () =>{
    console.log(`Server listening on ${PORT}`);
});


