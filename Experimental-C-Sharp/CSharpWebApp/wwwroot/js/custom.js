let connection = new signalR.HubConnectionBuilder()
    .withUrl("/custom")
    .build();

//after selfping
/*Use connection.off("ClientHook") to disconnect from a specific signalR hook*/
connection.on("ClientHook", data => console.log('ClientHook', data));

//after triggerfetch
connection.on("client_function_name", data => console.log('client_function_name', data));

connection.start().then(() => {
    console.log("connected")
    connection.send('ServerHook', {id: 1, message: "we've connected"})
});

// call signalR hub function from client
const pingself = () => connection.send('SelfPing')


// promise resolves once sent
const pingAll = () => connection.send('PingAll')

// trigger hub from controller
const triggerFetch = () => fetch('/send')

// call signalR hub function from client
// promise resolves when we get data back from the method we get back
const withReturn = () => connection.invoke('invocation_with_return')
    .then(data => console.log('returned', data))


