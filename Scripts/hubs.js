function Hub(nameSender, nameReceiver, chatId, lastDate, lastMsgId)
{
    var chat = $.connection.chatHub;
    var _nameSender = nameSender;
    var _nameReceiver = nameReceiver;
    var _chatId = chatId;
    var _lastMsgId = lastMsgId;
    var _lastDate = lastDate;
    var isTyping = false;
    var host = 'http://localhost:59901/api/';

    chat.client.addMessage = function ( id, message, time, style, float, str_date ) {
        var mainChat = $('#mainchat');
        var lastMsg  = $('.message').last();
        var msgCount = lastMsg.attr("tabindex") + 1;
        mainChat.append(str_date);
        mainChat.append(
                '<div class="row" style="float:' + float + '">'+ 
                '<div id="msg' + id + '" class="' + style +
                ' row" tabindex=' + msgCount +
                '><h6 style="float:left">' + message + '</h6>' +
                '<p class="h7" style="float:left">&nbsp' + time +
                '</p></div></div>' +
                '<div style="clear:both"></div>');
        $('#msg' + msgCount).focus();
    };


    chat.client.typing = function (name) {
        var receiverInfo = $('#currentReceiverInfo');
        receiverInfo.empty();
        receiverInfo.append(name + ' is typing...')
    };


    chat.client.onConnected = function (id, userName, allUsers) {
    }

    chat.client.onNewUserConnected = function (id, name) {

    }

    chat.client.onUserDisconnected = function (id, userName) {
    }

    chat.sendPersonal = function (message) {
        $.ajax({
            url : host + '/Chat/' + _nameSender + _chatId,
            type : 'POST',
            data : { message : message },
            success : function(){
                chat.server.sendPersonal(message, _lastDate, _lastMsgId);
                $('#message').val('');
            },
            error : function(){

            }
        })
    }

    $.connection.hub.start().done(function () {

        $('#sendmessage').click(function () {
                
        });

        $('#message').keypress(function () {
            chat.server.typing($('#nameSender'));
        });

    });
});

