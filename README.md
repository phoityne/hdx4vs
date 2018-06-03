# hdx4vs
Haskell Debugger Extension for Visual Studio.

![01_quick_start.gif](https://raw.githubusercontent.com/phoityne/hdx4vs/master/docs/01_quick_start.gif)  

## Announcement
preparing release.

## Features
There are diffrences from VSCode.  
[see details](https://github.com/Microsoft/VSDebugAdapterHost/wiki/Differences-between-Visual-Studio-Code-and-the-Visual-Studio-Debug-Adapter-Host)


## Setup

### Install Debug Adapter Launcher
[see details](https://github.com/Microsoft/VSDebugAdapterHost/wiki)

#### 1. Clone the repo

```
git clone https://github.com/Microsoft/VSDebugAdapterHost.git
```

#### 2. Build the solution

Open and build the solution "VSDebugAdapterHost\src\VSDebugAdapterHostSamples.sln" in Visual Studio. 

#### 3. Install the extension.

Double click EngineLauncher.vsix in __VSDebugAdapterHost\bin\Release__ folder, and install it.

#### 4.  Confirm the menu

Confirm that there is a menu "__Tools -> Launc Debug Adapter__" in Visual Studio.


### Install Haskell Debugger Extension

#### 1. Clone the repo

```
git clone https://github.com/phoityne/hdx4vs.git
```

#### 2. Build the solution

Open and build the solution "hdx4vs\hdx4vs.sln" in Visual Studio. 

#### 3. Install the extension.

Double click hdx4vs.vsix in __hdx4vs\bin\Release__ folder, and install it.

## Start debugging

### 1. Open Haskell project folder.

* Must be installed phoityne-vscode
* Should be install haskell-dap

### 2. Create launch.json.

It is able to use same launch.json file with VSCode.  
But can not use ${workspaceRoot} variable.  
Must specify absolute path.

### 3. Launch debugger.

1. Select the menu "__Tools -> Launc Debug Adapter__" in Visual Studio.
1. Choose "__Haskell Debug Adapter__" for Debug engine.
1. Specify launch.json created in advance.
1. Press OK, then dubug will be started.

