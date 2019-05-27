

var StatusController = function (apiController) {

    var statusButton;
    var check = false;

	var statusChange = function () {
		$(".js-status-todo").on("click", toggleStatus);
	}

	var toggleStatus = function (e) {
		statusButton = $(e.target);
		var toDoId = statusButton.attr("data-id-attr");
        check = !check;
		apiController.toggleStatus(toDoId, success);
	}
    
    var textChange = function () {
        if (!check) {
            statusButton.text("Open");
        } else if (check) {
            statusButton.text("Done");
        }
    }

	var success = function () {
        statusButton.parents("tr").toggleClass("new-color");
        textChange();
    }

	return {
		statusChange: statusChange
	}
}(StatusApiController);


var StatusDelete = function(deleteStatus) {
    var deleteButton;

	var deleteToDo = function() {
		$(".js-delete-todo").on("click", deletePrompt);
    }

	var deletePrompt = function(e) {
        deleteButton = $(e.target);
        var buttonAttr = deleteButton.attr("data-id-attr");

		if (confirm("Are you sure you want to delete this ToDo")) {
			deleteStatus.ajaxDelete(buttonAttr, success, failure);
		}
	};

	var failure = function() {
		alert("Something failed");
    };

    var success = function() {
	    deleteButton.closest("tr").remove();
    }

	return {
		deleteToDo: deleteToDo
	}

}(DeleteApiController);




