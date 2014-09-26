IExp
====

An interpreter of simple mathematical expression in c#

EvalEx - Java Expression Evaluator
Introduction

EvalEx is a handy expression evaluator for Java, that allows to evaluate simple mathematical and boolean expressions.

Key Features:

Uses BigDecimal for calculation and result
Single class implementation, very compact
No dependencies to external libraries
Precision and rounding mode can be set
Supports variables
Standard boolean and mathematical operators
Standard basic mathematical and boolean functions
Custom functions and operators can be added at runtime
Examples

 BigDecimal result = null;

 Expression expression = new Expression("1+1/3");
 result = expression.eval():
 expression.setPrecision(2);
 result = expression.eval():

 result = new Expression("(3.4 + -4.1)/2").eval();

 result = new Expression("SQRT(a^2 + b^2").with("a","2.4").and("b","9.253").eval();

 BigDecimal a = new BigDecimal("2.4");
 BigDecimal b = new BigDecimal("9.235");
 result = new Expression("SQRT(a^2 + b^2").with("a",a).and("b",b).eval();

 result = new Expression("2.4/PI").setPrecision(128).setRoundingMode(RoundingMode.UP).eval();

 result = new Expression("random() > 0.5").eval();

 result = new Expression("not(x<7 || sqrt(max(x,9)) <= 3))").with("x","22.9").eval();
Supported Operators

Mathematical Operators
Operator	Description
+	Additive operator
-	Subtraction operator
*	Multiplication operator
/	Division operator
%	Remainder operator (Modulo)
^	Power operator
