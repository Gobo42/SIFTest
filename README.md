# SIFTest
Test Server and Client for Server Initiated Flows Demo

This is a server and client and illustrates a TCP control session, and a separate server-initiated UDP data session.

The server will listen on port 8080 and will listen for commands.

the client will ask for the IP of the server, and then allow commands. the command "connect <port>" with a port value of >1024 should be used.
The client will then open a UDP server on the requested port (or fail if not possible) and listen for data from the server.
After receiving data, the server will send "EXIT" after which both sides will close the UDP channel and resume on the existing TCP session

