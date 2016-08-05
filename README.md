# ExpressionSample
repo for possible .NET core or EFCore Bug

This sample requires the installation of SQL LocalDb.

There are two programs, one called EF7TestHarness and another called EF6TestHarness.  Both programs are console apps that show query times for expressions with the specified number of 'OR' predicates.  The program loops from 1 to 26 predicates in the expression.  In the EF7 sample on my computer, at around 20 predicates, each additional predicate seems to take around double the time of the previous run.  The EF6 sample doesn't show much degradation.   
