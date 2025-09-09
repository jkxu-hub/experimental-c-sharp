let connection = new signalR.HubConnectionBuilder()
    .withUrl("/groups")
    .build();

connection.on('group_message', data => console.log('group_message', data))

connection.start().then(() => console.log("connected"));

const join = () => connection.send('Join')
const leave = () => connection.send('Leave')
const message = () => connection.send('Message')