# Parser_Combinator_Sprache

Recently I got to know of [Parser combinators](https://en.wikipedia.org/wiki/Parser_combinator) and realized it holds advantages over using regular expressions in certain 
scenarios. Regular expressions look cryptic to me a day after I have written them. They quickly become unreaable as their size grows. They have their use but one should know where
not to use them. Parser combinator has given me a tool that I can use where maintainability of code is important. Although using parser combinator you will spend a little more time than writting a regular expression for a parsing task at hand but that will be less than writting a lexer and parser by hand from scratch. So they are a sweet spot between the two extreme approaches and come with the benefit of being much more readable over regular expression.

I had a problem of parsing a csv that had commas embedded in it as part of actual data. To fix the problem, I had initially used regular expressions. After reading about parser combinators, I tried to solve the problem using [Sprache](https://github.com/sprache/Sprache) library in C#. And am pleasantly surprised with the the way the solution unfolded. As 
I expected, it is much more readable and, hence, maintainable that using regular expressions.
