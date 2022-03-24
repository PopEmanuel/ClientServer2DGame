# ClientServer2DGame
 Template for a game with multiple players where one of the players is the server and the other one is client.
## Features
 - The application uses TCP connection to monitor the movement of one player and transmit it to the other because we need accurate messages without data loss
 - Two players can connect and see each other's movement
 - Threads make sure one user can move and also register movement of the other player
 - Layered architecture
## Issues
 - Windows Forms App isn't really good for any dynamic game related things
 - Server can be slow if player moves too fast
 - Screen blips because of buffering
