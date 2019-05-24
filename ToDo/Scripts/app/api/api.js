
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