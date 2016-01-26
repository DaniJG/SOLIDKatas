# SOLIDKatas

---------------------------------------------------------------------------------------------
+ Single Responsibility Kata
---------------------------------------------------------------------------------------------
Controller class with 3 methods: Find, FindAll, Add
It uses a repository with GetById, GetAll, Add methods. There is no dependency injection in place
The Add method includes validation logic
The Find, FindAll methods include caching logic

STEP 1
Apply Single Responsibility to the caching logic

We found a bug, and the cache needs to be invalidated when a new user is added.
Right now, it looks like the controller shouldn't worry about the caching, and the way things are right now, fixing this bug will be hard to test.
Let's move the caching logic outside the controller into its own class
1. Add a repository interface
2. Create a new repository decorator, moving the caching logic from the controller
3. Fix the bug in the new decorator class
3. Use the caching interface in the controller class (Will require adding a constructor for testing)

STEP 2
Apply Single Responsibility to the validation logic

There is a new validation that needs to be implemented (User email is unique). The controller class needs to change due to this requirement.
It is still painful to use TDD with the controller Add method, because still has too many responsibilities.
Let's move the validation logic outside the controller
1. Create a new IEntityValidator<T> interface
2. Copy validation logic to a new class UserValidator implementing the validation interface for T=User
2. Use the validation interface in the controller class

---------------------------------------------------------------------------------------------
+ Open Closed Kata
---------------------------------------------------------------------------------------------
Based on the DrawShapes function from the Agile Principles, Patterns and Practices books, Open Closed principle

Start with an ExecuteActions function that takes a list of "RecordingsActions" and in a main loop executes them all.
It will be made of if/elses to execute each action, and actions are concrete classes with no interfaces

STEP 1
A new action for deleting a recording needs to be added.
Apply Open/Closed to close the ExecuteActions function against new types of actions.
1. Add IRecordingAction interface with an execute function that receives a platform, change DrawShapes to take list of IRecordingAction
	
2. Move the code for executing each action from the ExecuteActions method to each class
	Create tests for each execute method of each class

3. Update the ExecuteActions method to call execute on each action
	Create tests for the ExecuteActions function

3. Add the DeleteRecording action class

STEP 2
We have just learned that some platforms might require actions to be executed in a particular order.
	Some legacy platforms require stop actions to be executed before the delete actions, because they dont know how to delete ongoing recordings
	Some budget platforms require delete actions to be executed before start actions, so they can allocate the space more efficiently
Apply Open/Closed to close the ExecuteActions function against changes in the action ordering execution

1. Add a new interface "IActionOrderer" with single Sort method and use it for adding optional parameter to ExecuteActions function

2. Update the ExecuteActions function to use the orderer when provided

3. Create an orderer implementation "LegacyPlatformActionOrderer"