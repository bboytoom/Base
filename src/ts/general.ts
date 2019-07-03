import { GroupClass } from "./GroupClass";
import Swal from "sweetalert2";

const add_group_btn = (<HTMLInputElement>document.getElementById('add_group_btn'));
const infouser = (<HTMLInputElement>document.getElementById('infohidde')).value;


function EditGroup(value: number) {
    console.log('hola');
}

add_group_btn.addEventListener('click', () => {
    Swal.fire({
        confirmButtonText: 'Guardar',
        cancelButtonText: 'Cancelar',
        showCancelButton: true,
        allowEscapeKey: false,
        allowOutsideClick: false,
        width: '65rem',
        html: ` <div class='row'>
                    <div class='col-12'>
                        <div class='input-group'>
                            <div class='input-group-prepend'>
                                <span class='input-group-text' id='group_label'><i class='fas fa-users'></i></span>
                            </div>
                            <input id='group_name' type='text' class='form-control' placeholder='Nombre del grupo' aria-label='Username' aria-describedby='group_label'>
                        </div>

                        <div class='form-group mt-3'>
                            <textarea id='group_description' class='form-control' rows='3' placeholder='Descripci&oacute;n del grupo'></textarea>
                        </div>
                    </div>
                    <div class='col-md-12 mb-4'>
                        <h4 class='h4 text-muted'>Permisos asignados al grupo</h4>
                    </div>
                    <div class='col-md-4'>
                        <div class='card'>
                            <div class='text-left mdl-typography--title p-3'>Grupo</div>
                            <div class='card-body text-left'>
                                <div class='row'>
                                    <div class='col-md-6 mb-2'>
                                        <div class='custom-control custom-switch'>
                                            <input id='create_group' class='custom-control-input' type='checkbox'>
                                            <label class='custom-control-label' for='create_group'>Crear</label>
                                        </div>
                                    </div>
                                    <div class='col-md-6 mb-2'>
                                        <div class='custom-control custom-switch'>
                                            <input id='update_group' class='custom-control-input' type='checkbox'>
                                            <label class='custom-control-label' for='update_group'>Actualizar</label>
                                        </div>
                                    </div>
                                    <div class='col-md-6 mb-2'>
                                        <div class='custom-control custom-switch'>
                                            <input id='delete_group' class='custom-control-input' type='checkbox'>
                                            <label class='custom-control-label' for='delete_group'>Eliminar</label>
                                        </div>
                                    </div>
                                    <div class='col-md-6 mb-2'>
                                        <div class='custom-control custom-switch'>
                                            <input id='read_group' class='custom-control-input' type='checkbox'>
                                            <label class='custom-control-label' for='read_group'>Mostrar</label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class='col-md-4'>
                        <div class='card'>
                            <div class='text-left mdl-typography--title p-3'>Usuario</div>
                            <div class='card-body text-left'>
                                <div class='row'>
                                    <div class='col-md-6 mb-2'>
                                        <div class='custom-control custom-switch'>
                                            <input id='create_user' class='custom-control-input' type='checkbox'>
                                            <label class='custom-control-label' for='create_user'>Crear</label>
                                        </div>
                                    </div>
                                    <div class='col-md-6 mb-2'>
                                        <div class='custom-control custom-switch'>
                                            <input id='update_user' class='custom-control-input' type='checkbox'>
                                            <label class='custom-control-label' for='update_user'>Actualizar</label>
                                        </div>
                                    </div>
                                    <div class='col-md-6 mb-2'>
                                        <div class='custom-control custom-switch'>
                                            <input id='delete_user' class='custom-control-input' type='checkbox'>
                                            <label class='custom-control-label' for='delete_user'>Eliminar</label>
                                        </div>
                                    </div>
                                    <div class='col-md-6 mb-2'>
                                        <div class='custom-control custom-switch'>
                                            <input id='read_user' class='custom-control-input' type='checkbox'>
                                            <label class='custom-control-label' for='read_user'>Mostrar</label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class='col-md-4'>
                        <div class='card text-left'>
                            <div class='text-left mdl-typography--title p-3'>Permisos</div>
                            <div class='card-body'>
                                <div class='row'>
                                    <div class='col-md-6 mb-2'>
                                        <div class='custom-control custom-switch'>
                                            <input id='create_permission' class='custom-control-input' type='checkbox'>
                                            <label class='custom-control-label' for='create_permission'>Crear</label>
                                        </div>
                                    </div>
                                    <div class='col-md-6 mb-2'>
                                        <div class='custom-control custom-switch'>
                                            <input id='update_permission' class='custom-control-input' type='checkbox'>
                                            <label class='custom-control-label' for='update_permission'>Actualizar</label>
                                        </div>
                                    </div>
                                    <div class='col-md-6 mb-2'>
                                        <div class='custom-control custom-switch'>
                                            <input id='delete_permission' class='custom-control-input' type='checkbox'>
                                            <label class='custom-control-label' for='delete_permission'>Eliminar</label>
                                        </div>
                                    </div>
                                    <div class='col-md-6 mb-2'>
                                        <div class='custom-control custom-switch'>
                                            <input id='read_permission' class='custom-control-input' type='checkbox'>
                                            <label class='custom-control-label' for='read_permission'>Mostrar</label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class='col-md-4 mt-3'>
                        <div class='card'>
                            <div class='text-left mdl-typography--title p-3'>Correo</div>
                            <div class='card-body text-left'>
                                <div class='row'>
                                   <div class='col-md-6 mb-2'>
                                        <div class='custom-control custom-switch'>
                                            <input id='create_email' class='custom-control-input' type='checkbox'>
                                            <label class='custom-control-label' for='create_email'>Crear</label>
                                        </div>
                                    </div>
                                    <div class='col-md-6 mb-2'>
                                        <div class='custom-control custom-switch'>
                                            <input id='update_email' class='custom-control-input' type='checkbox'>
                                            <label class='custom-control-label' for='update_email'>Actualizar</label>
                                        </div>
                                    </div>
                                    <div class='col-md-6 mb-2'>
                                        <div class='custom-control custom-switch'>
                                            <input id='delete_email' class='custom-control-input' type='checkbox'>
                                            <label class='custom-control-label' for='delete_email'>Eliminar</label>
                                        </div>
                                    </div>
                                    <div class='col-md-6 mb-2'>
                                        <div class='custom-control custom-switch'>
                                            <input id='read_email' class='custom-control-input' type='checkbox'>
                                            <label class='custom-control-label' for='read_email'>Mostrar</label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>`,
        preConfirm: () => {
            const group_name = (<HTMLInputElement>document.getElementById('group_name')).value;
            const group_description = (<HTMLInputElement>document.getElementById('group_description')).value;
            const create_group = (<HTMLInputElement>document.getElementById('create_group')).checked;
            const update_group = (<HTMLInputElement>document.getElementById('update_group')).checked;
            const delete_group = (<HTMLInputElement>document.getElementById('delete_group')).checked;
            const read_group = (<HTMLInputElement>document.getElementById('read_group')).checked;
            const create_user = (<HTMLInputElement>document.getElementById('create_user')).checked;
            const update_user = (<HTMLInputElement>document.getElementById('update_user')).checked;
            const delete_user = (<HTMLInputElement>document.getElementById('delete_user')).checked;
            const read_user = (<HTMLInputElement>document.getElementById('read_user')).checked;
            const create_permission = (<HTMLInputElement>document.getElementById('create_permission')).checked;
            const update_permission = (<HTMLInputElement>document.getElementById('update_permission')).checked;
            const delete_permission = (<HTMLInputElement>document.getElementById('delete_permission')).checked;
            const read_permission = (<HTMLInputElement>document.getElementById('read_permission')).checked;
            const create_email = (<HTMLInputElement>document.getElementById('create_email')).checked;
            const update_email = (<HTMLInputElement>document.getElementById('update_email')).checked;
            const delete_email = (<HTMLInputElement>document.getElementById('delete_email')).checked;
            const read_email = (<HTMLInputElement>document.getElementById('read_email')).checked;
            
            let groupclass = new GroupClass.InsertGroup(0, group_name, group_description, read_user, create_user, update_user, delete_user,
                read_group, create_group, update_group, delete_group, read_permission, create_permission, update_permission, delete_permission,
                read_email, create_email, update_email, delete_email, true, parseInt(infouser));

            if (group_name == '') {
                console.log('El campo nombre se encuentra vacio');
            } else {
                if (groupclass.validInsertGroup() == 'datarequired') {
                    console.log('faltan datos necesarios');
                } else if (groupclass.validInsertGroup() == 'fail') {
                    console.log('no cuenta con el numero de caracteres correctos');
                } else {
                    let url = 'http://localhost:50851/wsgroupcreate.svc/group/create';

                    groupclass.Insert(url).then(function (result) {
                        console.log(result);
                    });
                }
            }
        }
    });
});

