1.Iterator
- Provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation.
- The C++ and Java standard library abstraction that makes it possible to decouple collection classes and algorithms.
- Promote to "full object status" the traversal of a collection.
- Polymorphic traversal
- An aggregate object such as a list should give you a way to access its elements without exposing its internal structure. 

2.Mediator
- Define an object that encapsulates how a set of objects interact. 
- Mediator promotes loose coupling by keeping objects from referring to each other explicitly, and it lets you vary their interaction independently.
- Design an intermediary to decouple many peers.
- Promote the many-to-many relationships between interacting peers to "full object status".
- Mediator is similar to Facade in that it abstracts functionality of existing classes.
- Mediator abstracts/centralizes arbitrary communication between colleague objects, it routinely "adds value",
  and it is known/referenced by the colleague objects 

3.Observer
- Define a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.
- Encapsulate the core (or common or engine) components in a Subject abstraction, and the variable (or optional or user interface) components in an Observer hierarchy.
- The "View" part of Model-View-Controller.
- Observer distributes communication by introducing "observer" and "subject" objects.

4.Interpreter
- Given a language, define a representation for its grammar along with an interpreter that uses the representation to interpret sentences in the language.
- Map a domain to a language, the language to a grammar, and the grammar to a hierarchical object-oriented design.
- The pattern doesn't address parsing. When the grammar is very complex, other techniques (such as a parser) are more appropriate.