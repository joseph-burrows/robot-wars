
# robot-wars Tech Test
This repo contains the source for the robot wars tech test and represents about 3-4 hours of coding. It was written in VS2022 targeting .NET 6 and should be easily buildable from the solution file without any external dependencies (outside of nuget).

Nuget packages used (that weren't already present in the default console project):
- FluentAssertions, which provides LINQ style assertions in the unit tests
- FluentValidation, which allows LINQ style validation rules to be defined on models
- StructureMap, which provides easy dependency injection
- Moq, to allow for mocking in unit tests
- NUnit, to allow the unit tests to work in the first place

 Things I would have added to the solution given more time:
 - Integration tests, whilst we have a pretty good coverage with unit tests it would be good to get some end to end tests in to validate that it works from console -> user
 - Performance tests, how does the current solution handle 100 robots? 1000 robots? 10000? How scalable is it?
 - Tidying up unit tests, whilst generally we tend to put DRY on a backseat when writing tests there are definitely places where code reuse could have been reduced (i.e. verbose object creation) with specific test helper methods. Whether this is more readable or not is debatable!
 - Containerization

Possible extensions (things that might be interesting to explore but weren't a part of the brief):
- How could we adapt the current solution to a non grid-based system (i.e. float coordinates and directions)
- How could we add more functionality for when robots collide? Potentially some sort of damage system to dictate who wins out in a collision?
- How could we adapt the solution to have robots move in parallel? How would this impact collision detection?
- How easy is it to swap out input / output formats? Could we provide a CSV input?
