var commentTable;

$(document).ready(function () {
   LoadDataTable();

   $("#addCommentForm").on("submit", function (e) {
      e.preventDefault();

      var formData = $(this).serialize();

      $.ajax({
         type: "POST",
         url: "/comment/addcomment",
         data: formData,
         success: function (response) {
            if (response.success) {
               $("#commentTable").DataTable().ajax.reload();
               toastr.success(response.message);
            } else {
               toastr.error(response.message);
            }
         }
      })
   })
});

function LoadDataTable() {
   issueTable = $('#commentTable').DataTable({
      "ajax": { url: `/comment/getcommentsbyissueid?issueId=${issueId}` },
      "columns": [
         { data: 'author.userName'},
         { data: 'commentText' },
         {
            data: 'dateCreated',
            "render": function (data) {
               if (data) {
                  var date = new Date(data);
                  return date.toLocaleDateString();
               }
               return "N/A";
            }
         },
      ]
   })
}
