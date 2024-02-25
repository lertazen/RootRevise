var issueTable;

const IssueStatus = {
   0: "Open",
   1: "InProgress",
   2: "Closed"
}

const PriorityLevel = {
   0: "Low",
   1: "Medium",
   2: "High"
}

$(document).ready(function () {
   LoadDataTable();
});

function LoadDataTable() {
   issueTable = $('#issueTable').DataTable({
      "ajax": { url: '/issue/getallissues' },
      "columns": [
         { data: 'title' },
         { data: 'status.name' },
         { data: 'priority.name' },
         { data: 'project.name' },
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
         { data: 'reporter.name', },
         {
            data: 'assignee.name',
            "render": function (data) {
               return data ? data : 'Not assigned';
            }
         },
         {
            data: 'issueId',
            "render": function (data) {
               if (isAdmin === "False") {
                  return `
                   <a href="/issue/upsert?id=${data}" class="btn btn-info ms-2 disabled">
                      <i class="bi bi-pencil-square me-1"></i>Edit
                   </a>
                   <a onClick=DeleteIssue("/issue/delete/${data}") class="btn btn-danger ms-2 disabled">
                      <i class="bi bi-trash me-1"></i>Delete
                   </a>
                   <a href="/issue/details?issueId=${data}" class="btn btn-info ms-2">
                      <i class="bi bi-ticket-detailed me-1"></i>Details
                   </a>
                  `
               } else {
                  return `
                   <a href="/issue/upsert?id=${data}" class="btn btn-info ms-2">
                      <i class="bi bi-pencil-square me-1"></i>Edit
                   </a>
                   <a onClick=DeleteIssue("/issue/delete/${data}") class="btn btn-danger ms-2">
                      <i class="bi bi-trash me-1"></i>Delete
                   </a>
                   <a href="/issue/details?issueId=${data}" class="btn btn-info ms-2">
                      <i class="bi bi-ticket-detailed me-1"></i>Details
                   </a>
                  `
               }
            }
         }
      ]
   })
}

function DeleteIssue(url) {
   Swal.fire({
      title: "Are you sure?",
      text: "You won't be able to revert this!",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Yes, delete it!"
   }).then((result) => {
      if (result.isConfirmed) {
         $.ajax({
            url: url,
            type: "DELETE",
            success: function (data) {
               console.log(data)
               issueTable.ajax.reload();
               toastr.success(data.message);
            }
         })
      }
   });
}