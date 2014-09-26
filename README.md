IExp
====

##Introduction

<b>IExp</b> is an interpreter, written in <b>c#</b>, for simple mathematical expressions.

It is really simple to use. You need just to run it and it will appear a Windows Form.<br />
It contains a menu containing the items:
 - <b>File</b> → containing OpenFile that allow you to open the file that you want to interpreter
 - <b>Interpreter</b> → interpreter the opened file
 - <b>?</b> → containing a Help button

The Help button says what you should do in order to have you expression file interpeter.<br />
I report here the steps:<br />
 1. Click on File → Open File
 2. Select a text file with the same format of <i>try.txt</i>
 3. Click on Execute -> Iterpreter
 4. See the result on the TextArea
 5. Try to click on the nodes of the tree<br />
Where <i>try.txt</i> is an example file provided to you.

####Key Features:

- Simple to use
- Full of comments
- Supports Sandcastle Documentation
- Standard mathematical operators
- Graphical interface of the Abstract Syntax Tree
- No dependencies to external libraries

##Examples
```c#
  // Initialize the Scanner.
  Scanner scanner = new Scanner("(10+2*(7-1+3-5)+8/4-4/2*-5*(3-1))/(1--3)");
  
  try
  {
    // Create the collection of Token that can be enumerated.
    IEnumerable<Token> tokens = scanner.Tokenize();
    
    // Write the collection on the Console.
    foreach (var token in tokens)
      System.Console.Write("   -   " + token + "\n");
  }
  catch (System.LexicalException ex)
  {
    // Write the LexicalException on the Console.
    System.Console.Write(ex.Message + "\n");
  }
  
  try
  {
    // Initialize the Parser.
    Parser parser = new Parser(fileContent);
    
    // Create the Abstract Syntax Tree.
    root = parser.ParseTree();
    
    // Get the result of visiting the Abstract Syntax Tree and write it on the Console.
    int result = root.GetValue();
    System.Console.Write("Il risultato dell'espressione = " + result + "\n");
  }
  catch (System.Exception ex)
  {
    // Write the LexicalException/ParserException/ParseTreeException on the Console.
    System.Console.Write(ex.Message + "\n");
  }
```

##Mathematical Supported Operators

| Operator	|       Description       |
|:--------:|:-----------------------:|
|    +     |	Additive operator       |
|    -     |	Subtraction operator    |
|    *     |	Multiplication operator |
|    ÷     |	Division operator       |
