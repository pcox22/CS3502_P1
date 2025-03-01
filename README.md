# CS3502_P1

## Description
A project demonstrating Multi-Threaded Programming and Inter-Process Communication. The final result should include two builds that demonstrate Multi-Threaded Programming and Inter-Process Communication.

## Installation & Instructions
To install, open a terminal of choice and run the following to clone and obtain dependencies:
```bash
git clone https://github.com/pcox22/CS3502_P1.git
npm install
```

1. To run, open your IDE of choice (Solutions built in JetBrains: Rider)
2. Select File > Open and select the Folder inside the Repo for the given Project. (Note: Will need to open the Master Project Folder)
3. For Multi-Threaded Programming (MTP), simply run the program and it should function as intended.
4. For Inter-Process Communication (IPC):
  - Run the solution. There are two projects, and the one containing the server [IPC_Demo_In] is set as the startup program. If there are errors, ensure that it is selected when running.
  - Select the other Project [IPC_Demo_Out] and run it.
5. The two consoles should display messages that a connection is established.
6. Enter any messages into the client console and press enter to send them. The message should be printed out on the server console.
7. If there are any errors when trying to run, ensure that .NET 8.0 is installed, if it was not installed along with the IDE. To do so:
  Ubuntu:
```bash
sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-9.0
```
  Windows: Several Windows IDE's include .NET SDK's by default. If the selected IDE did not, consult: https://learn.microsoft.com/en-us/dotnet/core/install/windows

