
var StatusApiController = function () {
    var statusAjaxCall = function (toDoId, result) {
        $.ajax({
                url: "/api/toDos/" + toDoId,
                method: "PUT"
            })
            .done(result);
    }

    return {
        toggleStatus: statusAjaxCall
    }
}();

var DeleteApiController = function () {

	var ajaxDelete = function (buttonAttr, success, failure) {
		$.ajax({
				url: "/api/toDos/" + buttonAttr,
				method: "DELETE"
			})
			.done(success)
			.fail(failure);
	};

	return {
		ajaxDelete: ajaxDelete
	}
}();