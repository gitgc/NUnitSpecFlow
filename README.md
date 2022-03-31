NUnitSpecFlow
=============
Example project demonstrating some best practice DotNet build management (globally inherited StyleCop and dependency config etc) with NUnit and SpecFlow for BDD. Example project uses Gherkin feature file to run Youtube search.

Note the use of `Directory.Build.Props`, to facilitate easy addition of more test projects, as well as the parent `StyleCopRules.cs` rule definition file inherited by projects.