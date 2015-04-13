

$.Spike.page = function() {
	var viewModel = {};
	var objectFactory = {};
	var dataAccess = {};
	
	
	var init = function() {
	};
	
	return {
		viewModel : viewModel,
		objectFactory : objectFactory,
		dataAccess : dataAccess,
		init : init		
	}	
}();

$.Spike.page.objectFactory = function () {
    var createAuthor = function (original) {
        return converted = {
            id: original.Id,
            name: original.Name,
            birthDay: $.Spike.utilities.toDateString(original.BirthDay)
        };
    };

    var createAuthors = function (originals) {
        return ko.utils.arrayMap(originals, createAuthor);
    };

    return {
        createAuthor: createAuthor,
        createAuthors: createAuthors
    }
}();

$.Spike.page.createViewModel = function (serverData) {
    var convertedAuthors = $.Spike.page.objectFactory.createAuthors(serverData.Authors);
    console.log(convertedAuthors);
	
    var menuItems = ko.observableArray();
    var authorList = ko.observableArray(convertedAuthors);
    var environment = serverData.Environment;
	
	return {
	    menuItems: menuItems,
	    authorList: authorList,
	    environment: environment
	}	
};