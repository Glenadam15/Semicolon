
function GetRoles() {
    Get("Role/GetAllRoles", (data) => {
        var html = `<table class="table table-hover">` +
            `<tr><th style="width:50px">Id</th><th>Role Name</th><th></th></tr>`;

        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].id}</td><td>${arr[i].name}</td>`;
            html += `<td><button type="button" class="btn btn-outline-danger" onclick = 'RoleDelete(${arr[i].id})'>Delete</button>
            <button type="button" class="btn btn-outline-primary" onclick= 'RoleUpdate(${arr[i].id},"${arr[i].name}")'>Update</button></td>`;
            html += `</tr>`
        }
        html += `</table>`;

        $("#divRoles").html(html);
    });
}


function NewRole() {
    selectedRoleId = 0;
    $("#inputRoleName").val("");
    $("#roleModal").modal("show");
}

function RoleSave() {
    var role = {
        Id: selectedRoleId,
        Name: $("#inputRoleName").val()
    };
    Post("Role/Save", role, (data) => {
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