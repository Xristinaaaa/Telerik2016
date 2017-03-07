- Select 3 structural design patterns:

1.Decorator
- Decorator pattern allows a user to add new functionality to an existing object without altering its structure. 
  This type of design pattern comes under structural pattern as this pattern acts as a wrapper to existing class.
- This pattern creates a decorator class which wraps the original class and provides additional functionality keeping class methods signature intact.
- Attach additional responsibilities to an object dynamically.
  Decorators provide a flexible alternative to subclassing for extending functionality.
- Client-specified embellishment of a core object by recursively wrapping it.
- Wrapping a gift, putting it in a box, and wrapping the box.
- The Decorator attaches additional responsibilities to an object dynamically. 
- A Decorator can be viewed as a degenerate Composite with only one component. 
- Decorator and Proxy have different purposes but similar structures. 
  Both describe how to provide a level of indirection to another object, and the implementations keep a reference to the object to which they forward requests.
- Decorator lets you change the skin of an object. Strategy lets you change the guts.

2.Adapter
- Convert the interface of a class into another interface clients expect. 
  Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.
- It is especially useful for off-the-shelf code, for toolkits, and for libraries.
- Based on what an adapter does the adapter design pattern is also called wrapper pattern, translator pattern. 
- Wrap an existing class with a new interface.
- Impedance match an old component to a new system
- Adapter is about creating an intermediary abstraction that translates, or maps, the old component to the new system.

3.Flyweight
- Use sharing to support large numbers of fine-grained objects efficiently.
- The Motif GUI strategy of replacing heavy-weight widgets with light-weight gadgets.
- The Flyweight pattern describes how to share objects to allow their use at fine granularity without prohibitive cost.
  Each "flyweight" object is divided into two pieces: the state-dependent (extrinsic) part, and the state-independent (intrinsic) part. 
  Intrinsic state is stored (shared) in the Flyweight object. 
- The Flyweight uses sharing to support large numbers of objects efficiently.
  Extrinsic state is stored or computed by client objects, and passed to the Flyweight when its operations are invoked.
- Flyweight is often combined with Composite to implement shared leaf nodes.
- Flyweight explains when and how State objects can be shared.