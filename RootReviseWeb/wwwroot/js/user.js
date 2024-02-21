var userTable;

$(document).ready(function () {
   LoadDataTable();
});

function LoadDataTable() {
   userTable = $('#userTable').DataTable({
      "ajax": { url: "/user/getallusers" },
      "columns": [
         { data: 'name'},
         { data: 'userName' },
         { data: 'email' },
         { data: 'role' },
         {
            data: 'id',
            "render": function (data) {
               return `
                   <a href="/user/edit?userId=${data}" class="btn btn-info ms-2">
                      <i class="bi bi-pencil-square"></i>Edit
                   </a>
               `;
            }
         },
      ]
   })
}
