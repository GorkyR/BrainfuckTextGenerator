# BrainfuckTextGenerator
My version of a Brainfuck (esoteric programming language) text generator.

It's more *efficient* (output length is shorter) than other generators like [copy.sh's](https://copy.sh/brainfuck/text.html), and it's "Hello World!" output is even shorter than Wikipedia's (althogh they *do* say it's not the shortest).

## The concept
The idea is to pre-set some cells in such a way that if two consecutive characters are more than `x` distance away, instead of writing a bunch of `+`, `-` or doing some clever but awkward multiplication/wraparound, you could shift to a cell closer to the next character, and you never have to increment/decrement more than `x`. `x` in the code would be the `max_branch_distance` variable.

I found that depending on the string length and "complexity" (how distant the characters are from each other), some threshold between 8 and 11 *usually* yielded the shortest output. I don't have the mental fortitude to analize why or how you'd find out everytime, so it just uses brute to find the optimal threshold everytime. \\:D/

Because of the pre-setting of the cells, all outputs are padded with similar headers, which might be considered **"**significant**"** when the input is less than 5 or 10 characters long.
