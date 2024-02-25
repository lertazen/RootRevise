var issueTable;
var projectIdString = document.getElementById("projectId").innerHTML;
var projectId = parseInt(projectIdString)
$(document).ready(function () {
   LoadDataTable();
});

function LoadDataTable() {
   issueTable = $('#issueTable').DataTable({
      "ajax": { url: `/issue/getissuesbyprojectid?projectId=${projectId}` },
      "columns": [
         { data: 'title' },
         { data: 'description' },
         { data: 'status.name' },
         {
            data: 'dateReported',
            "render": function (data) {
               if (data) {
                  var date = new Date(data);
                  return date.toLocaleDateString();
               }
               return "N/A";
            }
         },
         {
            data: 'issueId',
            "render": function (data) {
                  return `
                      <a href="/issue/details?issueId=${data}" class="btn btn-info ms-2">
                        <i class="bi bi-card-text me-2"></i>More Details
                      </a>
                      `
            }
         }
      ]
   })
}
