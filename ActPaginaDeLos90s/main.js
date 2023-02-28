
function changeColor(newColor){
    var elem = document.getElementById('titulo1');
    elem.style.color = newColor;
}

function changeSize(size){
    var elem = document.getElementById('botoncito');
    elem.style.fontSize = size;
}

function cargarImagen() {
    const xhttp = new XMLHttpRequest();
    xhttp.onload = function() {
      const objetoUrl = URL.createObjectURL(xhttp.response);
      const imgElement = document.getElementById("mi-imagen");
      imgElement.src = objetoUrl;
      
    };
    xhttp.open("GET", "gatito.jpeg");
    xhttp.responseType = "blob";
    xhttp.send();
  }