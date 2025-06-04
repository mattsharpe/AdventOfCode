# AGENTS Instructions

This repository contains C# solutions for multiple years of the Advent of Code challenge.

## Repository layout
- `Advent20XX/` directories: one project per year (`2015` through `2019`). Each project contains:
  - `Solutions/`: C# classes named `DayXX.cs` implementing puzzle solutions.
  - `Tests/`: MSTest unit tests that verify the solutions.
  - `TestData/`: input files embedded as resources. Use `FileReader.ReadFile` to load them.
  - `Utilities/`: helpers shared by the year’s code.
- `AdventOfCode.sln` references all yearly projects.

## Building and testing
1. Restore dependencies: `dotnet restore AdventOfCode.sln`.
2. Build all projects: `dotnet build AdventOfCode.sln --configuration Release`.
3. Run tests: `dotnet test AdventOfCode.sln --configuration Release --verbosity normal`.

Tests depend on embedded resource files. When adding new test data, mark the file as an **Embedded Resource** in the project file.

## Contribution guidelines
- Keep solution and test naming consistent (`DayXX.cs`, `DayXXTests.cs`).
- Place new solutions and tests in the appropriate year folder.
- Follow standard C# formatting and MSTest patterns (`[TestClass]`, `[TestMethod]`, etc.).

