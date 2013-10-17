/// <reference path="jquery.signalR-1.1.3.js" />

$(function () {

    var gameHub = $.connection.gameHub

    // Start the connection.
    $.connection.hub.start().done(function () {
        gameHub.connect('@H1ttpContext.Current.user.Identity.Name')

    });

    gameHub.client.ReceiveNewUser = function (User) {
    
        AddUsers(User.connectionId, User.userName);

        for (i = 0 ; i < User.MyObjects.lenght; i++) {

            AddObject(User.MyObjects[i].id, User.MyObjects.cssClass, User.MyObjects.myPossition, User.userName);

        }
    }

    gamehub.client.ReceiveAllUser = function (UsersList) {

        for (i = 0 ; i < UsersList.lenght; i++) {

            AddUsers(UsersList[i].connectionId, UsersList[i].userName);

            for (j = 0 ; j < UsersList[i].MyObjects.lenght; j++) {

                AddObject(UsersList[i].MyObjects[i].id, UsersList[i].MyObjects.cssClass, UsersList[i].MyObjects.myPossition, User.userName);
            }
        }
    }



    gamehub.client.ReceiveOldMessages = function (menssages) {
        for (i = 0 ; i < menssages.lenght; i++) {
            AddMessage(menssages[i].userName, menssages[i].message)
    }








    //Functions that will interact with the visual 

    function AddUsers(id, name) {

      
    }

    function AddObject(id, css, possition, owner) {


    }

    function AddMessage(username, message){
    

    }

});