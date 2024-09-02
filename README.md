Robot Dodge is an exciting 2D game built using C# and the SplashKit SDK. Players control a character that must dodge various types of robots while shooting them down to survive and score points.

![7 2C](https://github.com/user-attachments/assets/0ddb6b16-e4eb-40cb-ad41-e1accde3ddb3)


## Table of Contents
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [How to Play](#how-to-play)
- [Project Structure](#project-structure)
- [Class Diagram](#class-diagram)
- [Contributing](#contributing)
- [License](#license)

## Features
- Player-controlled character with shooting ability
- Multiple types of enemy robots (Boxy and Roundy)
- Collision detection and off-screen handling
- Score tracking and life system
- Smooth animations and colorful graphics

## Prerequisites
To run this game, you'll need:
- [.NET SDK](https://dotnet.microsoft.com/download) (version 5.0 or later recommended)
- [SplashKit SDK](https://splashkit.io/)
- Visual Studio Code or any preferred C# IDE

## Installation
1. Clone this repository:
   ```
   git clone https://github.com/your-username/robot-dodge.git
   ```
2. Navigate to the project directory:
   ```
   cd robot-dodge
   ```
3. Open the project in Visual Studio Code or your preferred IDE.

## How to Play
1. Build and run the project using your IDE or the following command:
   ```
   dotnet run
   ```
2. Use the arrow keys to move your character (the girl with pigtails).
3. Click the left mouse button to shoot at robots.
4. Dodge the incoming robots (blue squares) and try to survive as long as possible!
5. Your score is displayed in the top-left corner, along with your remaining lives (hearts).
6. The game ends when you run out of lives.

## Project Structure
The game consists of several key classes:
- `Program`: The main entry point of the game.
- `RobotDodgeGame`: Contains the main game logic and update loop.
- `Player`: Defines the player character and its behaviors.
- `Robot`: Base class for robots, with derived classes for different robot types.
- `Bullet`: Defines the bullet object and its behavior.

## Class Diagram
![image](https://github.com/user-attachments/assets/29192ba2-541d-435b-b1df-f356c4626472)

The class diagram shows the relationships between the main classes in the game:
- `Program` creates an instance of `RobotDodgeGame`.
- `RobotDodgeGame` manages the overall game state, including `Player` and multiple `Robot` instances.
- `Player` can shoot `Bullet` objects.
- `Robot` is an abstract base class with derived classes (likely `Boxy` and `Roundy`, based on the game screenshot).

## Contributing
Contributions are welcome! Please feel free to submit a Pull Request.'
