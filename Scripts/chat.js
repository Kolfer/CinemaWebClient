function Chat() {

    this.init = function () {

        $('#searchInput').keyup(function (e) {
            var keyword = $('#searchInput').val();
            var searchMessages = $('#searchMessages');
            var loader = $('#loaderId');
            searchMessages.load('SearchMessage?keyword=' + keyword,
                           function (responseTxt, statusTxt, xhr) {
                               if (statusTxt == "success") {
                                   loader.removeClass('loader');
                                   $('#close').show();
                               }
                           });
            $('#chats').hide();
            searchMessages.empty();
            loader.addClass('loader');

        });

        $('#close').click(function () {
            $('#close').hide();
            $('#searchMessages').hide();
            $('#chats').show();
        });

        $(document).on('click', '.item', function () {
            $('.item-active').removeClass('item-active');
            $(this).addClass('item-active');
            var s_id = $(this).attr("id");
            var msgId = parseInt(s_id, 10);
            var msg = $('#msg' + msgId);
            if (msg == undefined) {
                $('#mainchat').load('LoadChat?keyword=' + msgId);
                $('#receiver').load('LoadReceiverInfo?keyword=' + msgId);
                $('#msg' + msgId).focus();
            }
            else {
                msg.focus();
            }
        });
    };
}





