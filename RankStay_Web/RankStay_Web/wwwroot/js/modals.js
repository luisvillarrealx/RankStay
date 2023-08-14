$(document).on("click", ".openModal", function () {
    var reviewId = $(this).data('id');
    $("#reviewId").val(reviewId);
});

function DeleteReview() {
    let reviewId = $("#reviewId").val();

    $.ajax({
        type: "POST",
        url: "/Review/DeleteReview",
        data: {
            "ReviewId": reviewId
        },
        success: function () {
            window.location.href = "/Reviews/Review";
        },
        error: function (xhr, status, error) {
            // Handle the error here
            console.log(error);
        }
    });

    $('#confirmationModal').modal('hide');
}

// Attach the function to the "Eliminar" button's click event
$(document).ready(function () {
    $("#confirmDelete").click(function () {
        DeleteReview();
    });
});
