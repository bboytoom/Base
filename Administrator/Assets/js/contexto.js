'use strict';

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }

function _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }

function cleanInput(InputEmail) {
  return String(InputEmail).replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;');
}

function valid_Name(Input_name) {
  var clean_input = cleanInput(Input_name);
  if (Input_name == "") return false;
  if (clean_input.length > 3 && clean_input.length < 29) return true;
  return false;
}

var Contexto =
/*#__PURE__*/
function () {
  function Contexto(TIPO, ID, USUARIO) {
    _classCallCheck(this, Contexto);

    if (TIPO === 'Grupos') {
      this.estrategia = new Grupos(ID, USUARIO);
    }
  }

  _createClass(Contexto, [{
    key: "CrearInterface",
    value: function CrearInterface() {
      this.estrategia.crear();
    }
  }, {
    key: "ActualizarInterface",
    value: function ActualizarInterface() {
      this.estrategia.actualizar();
    }
  }, {
    key: "EliminarInterface",
    value: function EliminarInterface() {
      this.estrategia.eliminar();
    }
  }]);

  return Contexto;
}();