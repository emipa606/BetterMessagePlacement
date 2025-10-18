# GitHub Copilot Instructions for Better Message Placement (Continued)

## Mod Overview and Purpose
Better Message Placement (Continued) is a RimWorld mod adapted from the original mod by Dyrewulfe. Its primary function is to dynamically adjust the location where messages are displayed in the game, ensuring they do not obstruct the colonist bar, thus improving the user interface experience for players.

## Key Features and Systems
- **Dynamic Message Adjustment**: The mod shifts the position of in-game messages to prevent overlap with the colonist bar, allowing for a clearer view of both messages and colonist information.
- **Compatibility Advice**: Users of the "Colony Groups" mod are recommended to use "Dynamic Message Positioning" by pointfeev for enhanced compatibility.

## Coding Patterns and Conventions
The mod follows standard C# coding practices, structured to ensure compatibility with RimWorld's architecture:
- **Naming Conventions**: Classes and methods use PascalCase. For example, `public class Better_Message_Placement` and `public class Messages_MessagesDoGUI`.
- **File Organization**: The project is organized into multiple assembly attribute files indicating framework versions, and key C# files responsible for the dynamic message adjustments.

## XML Integration
- XML can be used to define mod settings, labels, and other customizable properties. Mod configuration files typically include XML to handle user interface settings that may influence how messages are displayed.

## Harmony Patching
- **Harmony**: A library that allows runtime method patching, is an integral part of RimWorld modding for altering existing game functionality.
- **Patch Application**: Patches should be applied to methods responsible for message display, ensuring that the custom positioning logic from `Better_Message_Placement` and `Messages_MessagesDoGUI` classes is implemented effectively.

## Suggestions for Copilot
- **Suggestions for Dynamic Position Functionality**:
  - Implement logic to calculate available space on the screen dynamically and reposition messages accordingly.
  - Consider adding user settings allowing players to customize message positions based on personal preferences or screen sizes.
  
- **Additional Features**:
  - Suggest features that enhance compatibility with other mods, particularly those that modify the UI.
  - Propose unit tests to ensure changes in message placement don't interfere with other game UI elements.

- **Code Efficiency**:
  - Use efficient looping and conditional structures to minimize performance impact during message drawing operations.

These instructions serve as a guideline for Copilot to assist in expanding and refining the Better Message Placement (Continued) mod, ensuring a seamless integration with RimWorld's existing game systems while considering player convenience and mod compatibility.
