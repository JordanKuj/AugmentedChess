var ViewModel = function ()
{
    var self = this;
    self.games = ko.observableArray();  // list of all games in db
    self.boards = ko.observableArray();  // list of all boardstates in db
    self.error = ko.observable();  // error

    var gamesUri = '/api/games/';
    var boardsUri = '/api/boardstates';

    function ajaxHelper(uri, method, data)
    {
        self.error('');
        return $.ajax(
            {
                type: method,
                url: uri,
                dataType: 'json',
                contentType: 'application/json',
                data: data ? JSON.stringify(data) : null
            }).fail(function (jqXHR, textStatus, errorThrown)
            {
                self.error(errorThrown);
            });
    }

    // function to retrieve all games
    function getAllGames()
    {
        ajaxHelper(gamesUri, 'GET').done(function (data)
        {
            self.games(data);
        });
    }

    // function to retrieve all boardstates
    function getAllBoardstates()
    {
        ajaxHelper(boardsUri,'GET').done(function(data)
        {
            self.boards(data);
        });
    }

    getAllGames();
    getAllBoardstates();
};

ko.applyBindings(new VewModel());