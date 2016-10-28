=> Select 3 creational design patterns.

1.Singleton
- Design pattern that restricts the instantiation of a class to one object.
- This pattern involves a single class which is responsible to create an object while making sure that only single object gets created. 
- This class provides a way to access its only object which can be accessed directly without need to instantiate the object of the class.
- Singletons are often preferred to global variables because:
	They do not pollute the global namespace with unnecessary variables.
	They permit lazy allocation and initialization, whereas global variables in many languages will always consume resources.

- Most commonly, singletons don't allow any parameters to be specified when creating the instance.
- A single constructor, which is private and parameterless. This prevents other classes from instantiating it. Note that it also prevents subclassing. 
- The class is sealed. 
- A static variable which holds a reference to the single created instance, if any.
- A public static means of getting the reference to the single created instance, creating one if necessary.

-Common uses:
	The abstract factory, builder, and prototype patterns can use Singletons in their implementation.
	Facade objects are often singletons because only one Facade object is required.
	State objects are often singletons.
-Implementation:
	An implementation of the singleton pattern must:
		Ensure that only one instance of the singleton class ever exists and provide global access to that instance.
		Typically, this is achieved by declaring all constructors of the class to be private and providing a static method that returns a reference to the instance.

2.Factory method
- Creational pattern that uses factory methods to deal with the problem of creating objects without having to specify the exact class of the object that will be created. 
  This is done by creating objects by calling a factory method—either specified in an interface and implemented by child classes, or implemented in a base class and optionally overridden by derived classes—rather than by calling a constructor.
- "Define an interface for creating an object, but let subclasses decide which class to instantiate. The Factory method lets a class defer instantiation it uses to subclasses."
- Relies on inheritance, as object creation is delegated to subclasses that implement the factory method to create objects.
- The Factory Method instantiates the appropriate subclass based on information supplied by the client or extracted from the current state.

3.Builder
- An object creation software design pattern
- Unlike the abstract factory pattern and the factory method pattern whose intention is to enable polymorphism, the intention of the builder pattern is to find a solution to the telescoping constructor anti-pattern.
- Instead of using numerous constructors, the builder pattern uses another object, a builder, that receives each initialization parameter step by step and then returns the resulting constructed object at once.
- It can be used for objects that contain flat data, that is to say, data that can't be easily edited.
- The intent of the Builder design pattern is to separate the construction of a complex object from its representation. 
  By doing so the same construction process can create different representations.

-Advantages:
	Allows you to vary a product’s internal representation.
	Encapsulates code for construction and representation.
	Provides control over steps of construction process.
-Disadvantages:
	Requires creating a separate ConcreteBuilder for each different type of Product.