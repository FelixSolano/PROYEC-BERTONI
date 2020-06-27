$(document).ready(function () {

    fnListar();
});
var URL_BASE = window.location;
function fnListar() {
    $("#ListaAlbumnes").show();
    $("#ListaFotos").hide();
    $.get(URL_BASE + "Home/ListAlbunes", function (response) {

        var tablaDatos = $("#tbdAlbum");

        var arregloDatos = JSON.parse(response);
         console.log(arregloDatos);

        $.each(arregloDatos, function (index, item) {
            var filaHTML = "<tr><td>";
            filaHTML += item.id + "</td>";
            filaHTML += "<td>" + item["title"] + "</td>";
            filaHTML += "<td>" + "<a class='btn btn-success' href='javascript:fnListarfotos(\"" + item.id + "\");' >Visualizar Album</a>" + "</td>";
            filaHTML += "<td>";
            filaHTML += "</td>";
            filaHTML += "</tr>";
            tablaDatos.append(filaHTML);
        });


    });
}


function fnListarfotos(idalbum) {
    $("#ListaAlbumnes").hide();
    $("#ListaFotos").show();
    $.get(URL_BASE + "Home/listafotos?idalbum=" + idalbum, function (response) {

        var tablaDatos = $("#tbdFotos");
        var arregloDatos = JSON.parse(response);
        
        $.each(arregloDatos, function (index, item) {
            var filaHTML = "<tr><td>";
            filaHTML += item.id + "</td>";
            filaHTML += "<td>" + item["title"] + "</td>";
            filaHTML += "<td>" + "<img src='" + item["url"] + " width='230' height='230''> </img>"+  "</td>";
            filaHTML += "<td>" + "<a class='btn btn-success' href='javascript:fnListarComentarios(\"" + item.id + "\");'>Ver comentarios</a>" + "</td>";
            filaHTML += "</tr>";
            tablaDatos.append(filaHTML);
        });


    });
}

function fnListarComentarios(idfoto) {
    $("#ListaAlbumnes").hide();
    $("#ListaFotos").show();
    $.get(URL_BASE + "Home/listacomentarios?idfoto=" + idfoto, function (response) {
        $("#tbdComentarios").html("");
        var tablaDatos = $("#tbdComentarios");
        var arregloDatos = JSON.parse(response);

        $.each(arregloDatos, function (index, item) {
            cont = index + 1;
            var filaHTML = "<tr><td>";
            filaHTML += cont + "</td>";
            filaHTML += "<td>" + item["name"] + "</td>";
            filaHTML += "<td>" + item["email"]  + "</td>";
            filaHTML += "<td>" + item["body"] + "</td>";
            filaHTML += "</tr>";
            tablaDatos.append(filaHTML);
        });
    });
}



