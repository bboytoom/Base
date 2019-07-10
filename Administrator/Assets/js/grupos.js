'use strict';

function _typeof(obj) { if (typeof Symbol === "function" && typeof Symbol.iterator === "symbol") { _typeof = function _typeof(obj) { return typeof obj; }; } else { _typeof = function _typeof(obj) { return obj && typeof Symbol === "function" && obj.constructor === Symbol && obj !== Symbol.prototype ? "symbol" : typeof obj; }; } return _typeof(obj); }

function _defineProperty(obj, key, value) { if (key in obj) { Object.defineProperty(obj, key, { value: value, enumerable: true, configurable: true, writable: true }); } else { obj[key] = value; } return obj; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }

function _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }

function _possibleConstructorReturn(self, call) { if (call && (_typeof(call) === "object" || typeof call === "function")) { return call; } return _assertThisInitialized(self); }

function _assertThisInitialized(self) { if (self === void 0) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return self; }

function _get(target, property, receiver) { if (typeof Reflect !== "undefined" && Reflect.get) { _get = Reflect.get; } else { _get = function _get(target, property, receiver) { var base = _superPropBase(target, property); if (!base) return; var desc = Object.getOwnPropertyDescriptor(base, property); if (desc.get) { return desc.get.call(receiver); } return desc.value; }; } return _get(target, property, receiver || target); }

function _superPropBase(object, property) { while (!Object.prototype.hasOwnProperty.call(object, property)) { object = _getPrototypeOf(object); if (object === null) break; } return object; }

function _getPrototypeOf(o) { _getPrototypeOf = Object.setPrototypeOf ? Object.getPrototypeOf : function _getPrototypeOf(o) { return o.__proto__ || Object.getPrototypeOf(o); }; return _getPrototypeOf(o); }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function"); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, writable: true, configurable: true } }); if (superClass) _setPrototypeOf(subClass, superClass); }

function _setPrototypeOf(o, p) { _setPrototypeOf = Object.setPrototypeOf || function _setPrototypeOf(o, p) { o.__proto__ = p; return o; }; return _setPrototypeOf(o, p); }

var Grupos =
/*#__PURE__*/
function (_Strategy) {
  _inherits(Grupos, _Strategy);

  function Grupos(ID, USUARIO) {
    _classCallCheck(this, Grupos);

    return _possibleConstructorReturn(this, _getPrototypeOf(Grupos).call(this, ID, USUARIO));
  }

  _createClass(Grupos, [{
    key: "crear",
    value: function crear() {
      _get(_getPrototypeOf(Grupos.prototype), "peticionCrear", this).call(this, URL, check_array);

      $.ajax({
        url: "/grupos/form",
        dataType: 'html',
        success: function success(data) {
          Swal.fire(_defineProperty({
            confirmButtonText: 'Guardar',
            cancelButtonText: 'Cancelar',
            showCancelButton: true,
            allowEscapeKey: false,
            allowOutsideClick: false,
            width: '65rem',
            html: data,
            preConfirm: function preConfirm() {
              var Input_name = document.getElementById('group_name').value;
              var label_name = document.getElementById('lable_name');
              var serializer_form_check = document.getElementsByClassName('ckeck__group');
              console.log(USUARIO);

              if (valid_Name(Input_name)) {
                var check_array = {
                  'HighUser': USUARIO,
                  'Name': cleanInput(Input_name),
                  'Description': document.getElementById('group_description').value
                };

                for (var i = 0; i < serializer_form_check.length; i++) {
                  check_array[serializer_form_check[i].name] = serializer_form_check[i].checked;
                }

                var URL = 'http://localhost:50851/wsgroupcreate.svc/group/create';
              } else {
                label_name.style.display = 'block';
                setTimeout(function () {
                  label_name.style.display = 'none';
                }, 4000);
                return false;
              }
            }
          }, "allowOutsideClick", function allowOutsideClick() {
            return !Swal.isLoading();
          })).then(function (result) {
            if (result.value) Swal.fire({
              type: 'success',
              confirmButtonText: 'Cerrar'
            });
          });
        }
      });
    }
  }, {
    key: "actualizar",
    value: function actualizar() {
      _get(_getPrototypeOf(Grupos.prototype), "peticionCrear", this).call(this, URL, check_array);

      $.ajax({
        method: "POST",
        url: "/grupos/read",
        data: JSON.stringify({
          'Id': this.Id
        }),
        contentType: "application/json",
        dataType: 'json',
        success: function success(data) {
          if (data.Status == 200) {
            var datos = data.Respuesta[0];
            $.ajax({
              url: "/grupos/form",
              dataType: 'html',
              success: function success(data) {
                var _this = this;

                Swal.fire(_defineProperty({
                  confirmButtonText: 'Guardar',
                  cancelButtonText: 'Cancelar',
                  showCancelButton: true,
                  allowEscapeKey: false,
                  allowOutsideClick: false,
                  width: '65rem',
                  html: data,
                  preConfirm: function preConfirm() {
                    var Input_name = document.getElementById('group_name').value;
                    var label_name = document.getElementById('lable_name');
                    var serializer_form_check = document.getElementsByClassName('ckeck__group');
                    console.log(USUARIO);

                    if (valid_Name(Input_name)) {
                      var URL = 'http://localhost:50851/wsgroupupdate.svc/group/update';
                      var check_array = {
                        'HighUser': _this.Alta,
                        'Name': cleanInput(Input_name),
                        'Description': document.getElementById('group_description').value,
                        'Id': _this.Id
                      };

                      for (var i = 0; i < serializer_form_check.length; i++) {
                        check_array[serializer_form_check[i].name] = serializer_form_check[i].checked;
                      }
                    } else {
                      label_name.style.display = 'block';
                      setTimeout(function () {
                        label_name.style.display = 'none';
                      }, 4000);
                      return false;
                    }
                  }
                }, "allowOutsideClick", function allowOutsideClick() {
                  return !Swal.isLoading();
                })).then(function (result) {
                  if (result.value) Swal.fire({
                    type: 'success',
                    confirmButtonText: 'Cerrar'
                  });
                });
              }
            });
            setTimeout(function () {
              document.getElementById('group_name').value = datos.Name;
              document.getElementById('group_description').value = datos.Description;
              document.getElementById('create_group').checked = datos.Creategroup;
              document.getElementById('update_group').checked = datos.Updategroup;
              document.getElementById('delete_group').checked = datos.Deletegroup;
              document.getElementById('read_group').checked = datos.Readgroup;
              document.getElementById('create_user').checked = datos.Createuser;
              document.getElementById('update_user').checked = datos.Updateuser;
              document.getElementById('delete_user').checked = datos.Deleteuser;
              document.getElementById('read_user').checked = datos.Readuser;
              document.getElementById('create_permission').checked = datos.Createpermission;
              document.getElementById('update_permission').checked = datos.Updatepermission;
              document.getElementById('delete_permission').checked = datos.Deletepermission;
              document.getElementById('read_permission').checked = datos.Readpermission;
              document.getElementById('create_email').checked = datos.Createemail;
              document.getElementById('update_email').checked = datos.Updateemail;
              document.getElementById('delete_email').checked = datos.Deleteemail;
              document.getElementById('read_email').checked = datos.Reademail;
              document.getElementById('group_status').checked = datos.Status;
            }, 200);
          } else {
            Swal.fire({
              type: 'error',
              text: 'Error al realizar la peticion',
              confirmButtonText: 'Cerrar'
            });
          }
        }
      });
    }
  }, {
    key: "eliminar",
    value: function eliminar() {
      _get(_getPrototypeOf(Grupos.prototype), "peticionEliminar", this).call(this, URL);

      Swal.fire({
        type: 'question',
        text: 'Estas seguro que deseas eliminar el grupo',
        showCloseButton: true,
        showCancelButton: true,
        confirmButtonText: 'Aceptar',
        cancelButtonText: 'Cancelar'
      }).then(function (result) {
        var URL = 'http://localhost:50851/wsgroupdelete.svc/group/delete';
      });
    }
  }]);

  return Grupos;
}(Strategy);