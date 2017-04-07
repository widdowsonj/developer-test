# Code Review

The existing code base makes some good use of design patterns.  It uses the command pattern to separate the business logic away from the controller.  Although the design can include lots of command and handler classes, it makes the controller alot easier to understand and maintain.

Again there is good separation of concerns with the domain model and the view model via the use of the ModelViewBuilder classes.

The choice of SimpleInjector for the DI container is one of most performant available.

## Improvements

The domain model could be moved into a separate data access layer project and then a service could be used to access this.  The service would then be injected into the controller instead of the DBContext.

The use of AutoMapper could be considered for mapping the properties of domain models to view models.

There are some unit tests but the coverage could be improved, although you could argue if it is throw away code it is not needed.

In production there would need to be general error handling, validation and logging implemented.  For security there would need to be anti forgery tokens added to the controller post actions to prevent cross site request forgeries.  The properties to bind to would also need adding to protect from overposting attacks.
