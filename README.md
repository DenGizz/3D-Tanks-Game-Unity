# Abstact
          
A common practice in video game development is to develop prototypes to test game designer's hypotheses, run-in game mechanics, and conduct early playtests. The code quality requirements for such projects are often lower, as it is expected to be discarded and completely rewritten. 

 However, in some cases, when a prototype receives positive feedback and has the potential for commercial success, the business may decide not to start development from scratch, but to improve the existing code.

Then such projects face the task of rewriting and refactoring parts of the code to simplify its support and make it easier to add new functions.

This repository demonstrates the process of refactoring and rewriting highly connected and poorly structured code lacking a clear architecture. An open source 3D tank game is used as an example.

The project uses the Service-Oriented Architecture (SOA) approach and Zenject for Dependency Injection (DI). The main goal is to show how the source code can be transformed to become more maintainable and easily extensible to add new features.

# About source project

3D Tanks Game is a 2 player shooter game using one keyboard that uses simple game mechanics, integrating world and screen space UI, as well as game architecture and audio mixing...

[Source repo](https://github.com/choubari/3D-Tanks-Game-Unity)

# Conclusions

Refactoring of this project probably took more time than writing it, it follows from the fact that we had to create the architecture of the project from scratch. 

Although the goal of the prototype is to get an answer to the question of the validity of a particular hypothesis as quickly and inexpensively as possible, if this prototype is not being developed by a game designer who has almost no coding skills and experience, it is worth thinking about a minimum level of architecture.
For example, use the Singleton approach, using interfaces, caching references in the constructor or method Awake(), as well as with the prohibition at the level of skill of the team to use direct calls to Singleton.Instance not from the constructor or method Awake().

In the future, this will make it easy to replace Singleton with services, and to implement DI, since references to the necessary managers and services can be obtained through injection into the constructor or method in the case of MonoBehaviour.

You should also first create tests for the prototyped mechanics, and then start refactoring the code to make it easier to understand whether the rewritten code works correctly relative to the old one.

When refactoring a prototype, you should first of all rewrite the elements that will require interaction with the project architecture, and only then the rest of the code. Some parts can be left unrefactorable until there is a need to change these parts to add new functionality.
