function RecipesViewModel() {
    var self = this;

    self.searchTerm = ko.observable("");
    self.searchResults = ko.observableArray();
    self.currentPage = ko.observable(0);
    self.pageCount = ko.observable(-1);
    self.pageSize = 5;

    self.canPrevPage = ko.computed(function () {
        return self.currentPage() > 0;
    });

    self.canNextPage = ko.computed(function () {
        return self.pageCount() > 0 && self.pageCount() > self.currentPage() + 1;
    });

    self.prevPage = function () {
        if (self.canPrevPage()) {
            self.currentPage(self.currentPage() - 1);
            self.search();
        }
    };

    self.nextPage = function () {
        if (self.canNextPage()) {
            self.currentPage(self.currentPage() + 1);
            self.search();
        }
    };

    self.search = function () {
        $.ajax({
            method: "GET",
            url: "/recipes/search",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                q: self.searchTerm,
                page: self.currentPage,
                pageSize: self.pageSize
            },
            success: function (data) {
                data.recipes.forEach(function (entry) {
                    entry.editUrl = "/recipes/edit/?recipeId=" + entry.id;
                });
                self.searchResults(data.recipes);
                self.pageCount(data.pageCount)
            }
        });
    };

    self.search();

    return self;
}

ko.applyBindings(new RecipesViewModel());