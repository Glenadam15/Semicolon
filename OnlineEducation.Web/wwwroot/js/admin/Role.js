
function GetRoles() {
    Get("Role/GetAllRoles", (data) => {
        var html = `<table class="table table-hover">` +
            `<tr><th style="width:50px">Id</th><th>Rol Adı</th><th></th></tr>`;

        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].id}</td><td>${arr[i].name}</td>`;
            html += `<td><i class="bi bi-trash text-danger" onclick='RoleDelete(${arr[i].id})'></i><i class="bi bi-pencil-square" onclick='RoleUpdate(${arr[i].id},"${arr[i].name}")'></i></td>`;
            html += `</tr>`
        }
        html += `</table>`;

        $("#divRoles").html(html);
    });
}

let selectedRoleId = 0;

function NewRole() {
    selectedRoleId = 0;
    $("#inputRoleName").val("");
    $("#roleModal").modal("show");
}
function RolSave() {
    var role = {
        Id: selectedRoleId,
        Name: $("#inputRoleName").val()
    };
    Post("Role/Save", rol, (data) => {
        GetRoles();
        $("#roleModal").modal("hide");
    });
}


function RoleDelete(id) {
    Delete(`Role/Delete?id=${id}`, (data) => {
        GetRoles();
    });
}

function RoleUpdate(id, name) {
    selectedRoleId = id;
    $("#inputRoleName").val(name);
    $("#roleModal").modal("show");
}

$(document).ready(function () {
    GetRoles();
});