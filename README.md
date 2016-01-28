# SOLIDKatas

This repository contains the source code that can be used as the starting point for the Katas based on each of the SOLID principles.
The katas are written in C# and VS projects are provided.

### Single Responsibility Kata

Within the SRP folder of the project, you will find a `UserController` class providing some simple logic for managing users.
We will use as the base for our SRP katas.

##### Exercise 1
Apply Single Responsibility to the caching logic in the `UserController` class.

We found a bug, and the cache needs to be invalidated when a new user is added.
Let's take this chance to move the caching logic outside the `UserController` into its own class.

- The controller shouldn't worry about the caching
- Makes testing issues with the caching(like this bug) harder than it should be.

1. Add a repository interface
2. Create a new repository decorator, moving the caching logic from the `UserController`
3. Fix the bug in the new decorator class
3. Use the caching interface in the `UserController` class

##### Exercise 2
Apply Single Responsibility to the validation logic

There is a new validation that needs to be implemented: User email is unique. The controller class needs to change due to this requirement.
Let's move the validation logic outside the `UserController`

- The `Add` method still has one too many responsibility
- Testing the validation logic is still harder than it should be.

1. Create a new `IEntityValidator<T>` interface
2. Copy validation logic to a new class `UserValidator` implementing the validation interface for T=User
2. Use the validation interface in the controller class

### Open Closed Kata

Within the OCP folder of the project, you will find an `ActionExecutor` class which provides a method to execute a list of recording actions. Initially the system has only implemented 2 actions, `StartRecordingAction` and `StopRecordingAction`.
We will use it as the basis for the OCP katas.

##### Exercise 1

We have found we need to add a new action for deleting a recording.
Let's apply the Open/Closed principle to close the `ExecuteActions` function against new types of actions.

1. Add a new `IRecordingAction` interface with a method `Execute(platform IPlatform)`, then change DrawShapes to take a list of `IRecordingAction`.
2. Move the code for executing each action from the `ExecuteActions` method to each action class (Create tests for each execute method of each class)
3. Update the `ExecuteActions` method to call execute on each action of the list (Create tests for the ExecuteActions function)
3. Add the `DeleteRecording` action class

##### Exercise 2
We have just learned that some platforms might require actions to be executed in a particular order:

- Some legacy platforms require stop actions to be executed before the delete actions, because they dont know how to delete ongoing recordings
- Some budget platforms require delete actions to be executed before start actions, so they can allocate the space more efficiently

Let's apply the Open/Closed principle to close the ExecuteActions function against changes in the action ordering execution

1. Add a new interface `IActionSorter` with single `IEnumerable<IRecordingAction> Sort(actions IEnumerable<IRecordingAction>)` method.
2. Update the `ActionExecutot` with a new optional dependency on the sorter.
3. Create a sorter implementation `LegacyPlatformActionSorter`
