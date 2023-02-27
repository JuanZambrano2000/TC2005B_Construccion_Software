function loadHDoc() {
  const xhttp = new XMLHttpRequest();
  xhttp.onload = function() {
    document.getElementById("demo").innerHTML =
    this.responseText;
  }
  xhttp.open("GET", "ajax.txt");
  xhttp.send();
}

function cargarImagen() {
  const xhttp = new XMLHttpRequest();
  xhttp.onload = function() {
    const objetoUrl = URL.createObjectURL(xhttp.response);
    const imgElement = document.getElementById("mi-imagen");
    imgElement.src = objetoUrl;
    
  };
  xhttp.open("GET", "bebe.gif");
  xhttp.responseType = "blob";
  xhttp.send();
}

function cargarHTML(){
    const xhr = new XMLHttpRequest();
    xhr.onload = function() {
      const divElement = document.getElementById("mi-html");
      divElement.innerHTML = xhr.responseText;
    };
    xhr.open("GET", "howto.html");
    xhr.send();
}
  