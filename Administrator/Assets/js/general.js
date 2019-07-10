"use strict";

function Edit(ValorId, Tipo) {
  var usuario = parseInt(document.getElementById('infohidde').value);
  var estrategia = new Contexto(Tipo, ValorId, usuario);
  estrategia.ActualizarInterface();
}

function Delete(ValorId, Tipo) {
  var usuario = parseInt(document.getElementById('infohidde').value);
  var estrategia = new Contexto(Tipo, ValorId, usuario);
  estrategia.EliminarInterface();
}

document.getElementById('add_btn').addEventListener('click', function () {
  var usuario = parseInt(document.getElementById('infohidde').value);
  var estrategia = new Contexto(add_btn.name, 0, usuario);
  estrategia.CrearInterface();
});