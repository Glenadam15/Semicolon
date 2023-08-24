﻿
function GetCategories() {
    Get("Category/GetAllCategoriesWithoutCache", (data) => {
        var html = `<table class="table table-hover">` +
            `<tr><th style="width:50px">Id</th><th>Category Name</th><th></th></tr>`;

        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].id}</td><td>${arr[i].name}</td>`;
            html += `<td><i class="bi bi-trash text-danger" onclick='CategoryDelete(${arr[i].id})' style="padding-right: 10px;"></i><i class="bi-pencil-square" onclick='CategoryUpdate(${arr[i].id},"${arr[i].name}")'></i></td>`;
            html += `</tr>`
        }
        html += `</table>`;

        $("#divCategories").html(html);
    });
}


function NewCategory() {
    selectedCategoryId = 0;
    $("#inputCategoryName").val("");
    $("#categoryModal").modal("show");
}

function CategorySave() {
    var category = {
        Id: selectedCategoryId,
        Name: $("#inputCategoryName").val()     
    };
    Post("Category/Save", category, (data) => {
        GetCategories();        
        $("#categoryModal").modal("hide");
    });
}


function CategoryDelete(id) {
    Delete(`Category/Delete?id=${id}`, (data) => {
        GetCategories();        
    });
}

function CategoryUpdate(id, name) {
    selectedCategoryId = id;
    $("#inputCategoryName").val(name);
    $("#categoryModal").modal("show");
}

$(document).ready(function () {
    GetCategories();    
});