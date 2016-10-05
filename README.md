# BrainfuckTextGenerator
My version of a Brainfuck (esoteric programming language) text generator.

It's more *efficient* (output length is shorter) than other generators like [copy.sh's](https://copy.sh/brainfuck/text.html), and it's "Hello World!" output is even shorter than Wikipedia's (althogh they *do* say it's not the shortest).

I included the executable, but if you want to compile it yourself, set the main method to the **BFWork.StringGenerator** class (or delete the Main method form the other file).

`csc /nologo BFSPathfinder.cs BFSGenerator.cs /main:BFWork.StringGenerator`

It's split into two because I first wrote the "Pathfinder" (excuse my awkward naming schemes) to help me figure out a better way to write my own text in Brainfuck manually.
