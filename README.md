# 🎄Advent Of Code
Advent of Code Solutions in C#
https://adventofcode.com

Helping 🎅 save 🎄 one inefficient algorithm at a time.

## Setup
Run `./install-dotnet9.sh` to install the required .NET 9 SDK locally. After running the script, add the following line to your shell profile or execute it in the current session so `dotnet` is available:

```bash
export PATH="$HOME/.dotnet:$PATH"
```

Then restore, build, and test the solution:

```bash
dotnet restore AdventOfCode.sln
dotnet build AdventOfCode.sln --configuration Release
dotnet test AdventOfCode.sln --configuration Release --verbosity normal
```
