'use strict';

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }

function _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }

var Strategy =
/*#__PURE__*/
function () {
  function Strategy(ID, USUARIO) {
    _classCallCheck(this, Strategy);

    this._ID = ID;
    this._USUARIO = USUARIO;
  }

  _createClass(Strategy, [{
    key: "peticionCrear",
    value: function peticionCrear(URL, DATA) {
      console.log('Actualizar');
      console.log(URL);
      console.log(this._ID);
      console.log(this._USUARIO);
      console.log(DATA);
      /*$.ajax({
          method: "POST",
          url: URL,
          data: JSON.stringify({ 'Data': DATA }),
          contentType: "application/json",
          dataType: "json",
      })
          .done(function (data, textStatus, xhr) {
              if (data.status == 200)
                  console.log('error 200');
          })
          .fail(function (data, textStatus, xhr) {
              if (data.status == 400)
                  console.log('error 400');
                if (data.status == 404)
                  console.log('error 404');
                if (data.status == 410)
                  console.log('error 410');
          });*/
    }
  }, {
    key: "peticionEliminar",
    value: function peticionEliminar(URL) {
      console.log('Eliminar');
      console.log(URL);
      console.log(this._ID);
      console.log(this._USUARIO);
      /*$.ajax({
          method: "POST",
          url: URL,
          data: JSON.stringify({ 'Id': this._ID, HighUser: this._USUARIO }),
          contentType: "application/json",
          dataType: "json",
      })
          .done(function (data, textStatus, xhr) {
              console.log('error 200');
          })
          .fail(function (data, textStatus, xhr) {
              if (data.status == 400)
                  console.log('error 400');
                if (data.status == 404)
                  console.log('error 404');
          });*/
    }
  }]);

  return Strategy;
}();