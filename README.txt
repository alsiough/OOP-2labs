RegretLab3Solution
==================

This solution contains three projects:
  - Domain (Class Library) - contains entities and interfaces
  - Storage (Class Library) - contains TextFileRepository for file IO
  - ConsoleApp (Console Application) - interactive console menu

How to open and run (Visual Studio 2022 Community):
1. Download and unzip the archive.
2. Open RegretLab3.sln in Visual Studio 2022.
3. Build the solution (Build -> Build Solution).
4. Right-click on ConsoleApp project -> Set as Startup Project.
5. Run (Debug -> Start Debugging or Start Without Debugging).
6. In the console menu you can:
   - Add sample data (creates several Student/Teacher/Musician objects)
   - Save to file: provide a filename like data.txt
   - Load from file: provide the filename to load previously saved data
   - List all, Find by lastname, Find/Delete by StudentID

Alternative: Using dotnet CLI (if you have .NET 7 SDK installed)
1. Open a terminal in the solution folder.
2. Run: dotnet build
3. Run: dotnet run --project ConsoleApp

Notes:
- StudentId expected format: two uppercase letters followed by 6 digits (example: KB123456)
- Names are validated for Ukrainian/Latin letters, apostrophe and hyphen.
- The repository reads/writes the text format required in the lab instructions.

