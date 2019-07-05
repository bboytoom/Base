"use strict";

var add_group_btn = document.getElementById('add_group_btn');

function cleanInput(InputEmail) {
    return String(InputEmail).replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;');
}

function valid_Name(Input_name) {
    var clean_input = cleanInput(Input_name);

    if (Input_name == "")
        return false;

    if (clean_input.length > 3 && clean_input.length < 29)
        return true;

    return false;
}

function petitionsGroup(Input_name) {
    var clean_input = cleanInput(Input_name);
    var URL = 'http://localhost:50851/wsgroupcreate.svc/group/create';

    if (valid_Name(Input_name)) {
        console.log('peticion');
    } else {

    }
}

add_group_btn.addEventListener('click', () => {
    $.ajax({
        url: "/grupos/form",
        dataType: 'html',
        success: function (data) {
            Swal.fire({
                confirmButtonText: 'Guardar',
                cancelButtonText: 'Cancelar',
                showCancelButton: true,
                allowEscapeKey: false,
                allowOutsideClick: false,
                width: '65rem',
                html: data,
                preConfirm: () => {
                    var Input_name = document.getElementById('group_name').value;
                    var label_name = document.getElementById('lable_name');

                    petitionsGroup(Input_name);
                    return false;

                    /*if (valid_Name(Input_name)) {
                        petitionsGroup(Input_name);
                    } else {
                        label_name.style.display = 'block';

                        setTimeout(function () {
                            label_name.style.display = 'none';
                        }, 4000);

                        return false;
                    }*/
                }
            });
        }
    });
});
