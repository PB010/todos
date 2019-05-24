

var StatusController = function (apiController) {

    var statusButton;

    var statusChange = function () {
        $(".js-status-todo").on("click", toggleStatus);
    }

    var toggleStatus = function (e) {
        statusButton = $(e.target);
        var toDoId = statusButton.attr("data-id-attr");

        apiController.toggleStatus(toDoId, success);
    }

    var success = function () {
        var text = (statusButton.text == "Open") ? "Done" : "Open";
        statusButton.parents('tr').toggleClass("new-color");
        statusButton.text(text);
    }

    return {
        statusChange: statusChange
    }
}(StatusApiController);





$(".js-delete-todo").on("click", function (e) {
    var deleteButton = $(e.target);
    if (confirm("Are you sure you want to delete this ToDo")) {
        $.ajax({
                url: "/api/toDos/" + deleteButton.attr("data-id-attr"),
                method: "DELETE"
            })
            .done(function () {
                deleteButton.closest('tr').remove();
            })
            .fail(function () {
                alert("fail");
            });
    }
});