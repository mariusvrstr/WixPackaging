
$.Spike = function() {
	
	var page = {};
	var ajaxTools = {};
	var menuTools = {};
	var objectFactory = {};
    var utilities = {};

    return {
		page : page,
		ajaxTools: ajaxTools,
		objectFactory: objectFactory,
		menuTools: menuTools,
		utilities: utilities
	}	
}();

$.Spike.menuTools = function() {

    var updateMenuItems = function (serverMenuItems) {
        $.Spike.page.viewModel.menuItems($.Spike.objectFactory.createMenuItems(serverMenuItems));
    };

    return {
        updateMenuItems: updateMenuItems
    }
}();

$.Spike.objectFactory = function () {

    var createMenuItem = function(original) {
        return {
            name: original.Name,
            link: original.Link
        };
    };

    var createMenuItems = function(originals) {
        return ko.utils.arrayMap(originals, createMenuItem);
    }
	
	return {
	    createMenuItem: createMenuItem,
	    createMenuItems: createMenuItems
	}
}();

$.Spike.ajaxTools = function() {

    var defaultErrorFunction = function (serverData) {
        console.log(serverData);
        alert("Server Request Failed");
    };

    var submitAjaxGetRequest = function (targetUrl, successCallback) {
        $.get(targetUrl, successCallback);
    }

    var submitAjaxRequest = function(targetURL, jsonData, successCallback, failureCallback) {

        var jsonString = JSON.stringify(jsonData);

        if (failureCallback == undefined) {
            failureCallback = defaultErrorFunction;
        }

        $.ajax({
            type: "POST",
            url: targetURL,
            data: jsonString,
            success: successCallback,
            error: failureCallback,
            contentType: "application/json",
            dataType: "json"
        });
    }

    var submitAjaxRequestPartialView = function(targetURL, jsonData, successCallback, failureCallback) {

        var jsonString = JSON.stringify(jsonData);

        if (failureCallback == undefined) {
            failureCallback = defaultErrorFunction;
        }

        $.ajax({
            type: "POST",
            url: targetURL,
            data: jsonString,
            success: successCallback,
            error: failureCallback,
            contentType: "application/json",
            dataType: "html"
        });
    };


    return {
        submitAjaxGetRequest: submitAjaxGetRequest,
        submitAjaxRequest: submitAjaxRequest,
        submitAjaxRequestPartialView: submitAjaxRequestPartialView
    };
}();


$.Spike.utilities = function() {

    var toDateString = function (date) {
        date = new Date(parseInt(date.substr(6)));
        var d = date.getDate();
        var m = (date.getMonth()) + 1; // JavaScript months are 0-11
        var y = date.getFullYear();

        return d + "/" + m + "/" + y;
    };

    return {
        toDateString: toDateString
    }
}();