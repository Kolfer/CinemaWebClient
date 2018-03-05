function Users(userName, currentUser, chatId) {

    var url = 'http://localhost:59901/api/User/'

    this.init = function () {

        $('#editProfile').click(function (e) {
            window.location.href = url + userName + '/Edit';
        });
     
        $('body').on('click', '#addFriend', function (e) {
            $.ajax({
                url: url + currentUser + '/AddFriend',
                type: 'POST',
                data: { userName: userName },
                success: function () {
                    $('#addFriend').replaceWith('<button id="cancelRequest" class="btn">' +
                                                'Cancel request</button>');
                }
            })
        });

        $('body').on('click', '#cancelRequest', function (e) {
            $.ajax({
                url: url + currentUser + '/CancelRequest',
                type: 'POST',
                data: { userName: userName },
                success: function () {
                    $('#cancelRequest').replaceWith('<button id="addFriend" class="btn btn-primary">' +
                                                    'Add as friend</button>');
                }
            })
        });
        
        $('#sendMessage').click(function () {
            window.location.href = "/Chat/" + chatId;
        });

        $('#removeFriend').click(function (e) {
            $.ajax({
                url: url + currentUser + '/RemoveFriend',
                type: 'POST',
                data: { userName: userName },
                success: function () {
                    $('#removeFriend').replaceWith('<button id="addFriend" class="btn btn-primary">' + 
                                                   'Add as friend</button>');
                }
            })
        });
    }

}