'use strict';

function Delete(ValorId, Tipo) {
    var usuario = parseInt(document.getElementById('infohidde').value);
    var estrategia = new Contexto(Tipo, ValorId, usuario);
    estrategia.EliminarInterface();
}

function Edit(ValorId, Tipo) {
    var usuario = parseInt(document.getElementById('infohidde').value);
    var main = parseInt(document.getElementById('mainhidde').value);
    var estrategia = new Contexto(Tipo, ValorId, usuario);
    estrategia.ActualizarInterface();
}

document.getElementById('add_btn').addEventListener('click', () => {
    var usuario = parseInt(document.getElementById('infohidde').value);
    var main = parseInt(document.getElementById('mainhidde').value);
    var estrategia = new Contexto(add_btn.name, 0, usuario);
    estrategia.CrearInterface();
});
