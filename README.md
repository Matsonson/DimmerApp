# DimmerApp

DimmerApp is a Windows Forms application that dims all screens except the default screen when a specific window is active. The application runs in the system tray and provides options to show the main form or exit the application.

## Features

- Dim all screens except the default screen when a specific window is active.
- Configurable settings for window titles, color, and opacity of the overlay.
- Runs in the system tray with options to show the main form or exit the application.
- Edit configuration settings through a configuration editor.

## Requirements

- .NET Framework 4.8
- Visual Studio

## Installation

### From .ZIP
1. Download the latest Release.zip file
2. Unzip the file to the location of your choice
3. Run DimmerApp.exe

### Build from source

1. Clone the repository:
git clone https://github.com/Matsonson/DimmerApp.git

2. Open the solution in Visual Studio.
3. Build the solution to restore the NuGet packages and compile the project.

## Usage

1. Run the application. It will start minimized to the system tray.
2. Right-click the tray icon to show the main form or exit the application.
3. Use the "Edit Config" button in the main form to open the configuration editor and modify settings.
4. The application will automatically dim all screens except the default screen when a window with a specified title is active.

### Run at startup
To run the app on startup, add shortcut to startup folder. (Win+R -> "shell:startup") 

## Configuration

The configuration settings are stored in a `config.json` file. The settings include:

- `DefaultScreen`: The screen that should not be dimmed.
- `WindowTitles`: An array of window titles to match.
- `PartialMatch`: A boolean indicating whether to use partial matching for window titles.
- `Color`: The color of the overlay.
- `Opacity`: The opacity of the overlay.

Example `config.json`:
{ "DefaultScreen": "\\.\DISPLAY1", "WindowTitles": ["Home", "Work"], "PartialMatch": true, "Color": "#000000", "Opacity": 0.5 }

## Code Overview

### MainForm.cs

The `MainForm` class is the main form of the application. It initializes the `NotifyIcon`, context menu, and buttons. It also handles loading the configuration and starting the `OverlayManager`.

### OverlayManager.cs

The `OverlayManager` class manages the overlay forms. It applies and clears overlays based on the active window title. It uses the `Invoke` method to ensure UI updates are performed on the UI thread.

### OverlayForm.cs

The `OverlayForm` class represents the overlay form that dims the screen. It uses P/Invoke to set window styles.

### WindowChecker.cs

The `WindowChecker` class provides methods to get the title of the active window using P/Invoke.

### AppConfig.cs

The `AppConfig` class represents the configuration settings for the application.




