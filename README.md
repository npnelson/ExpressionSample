# ExpressionSample
repo for possible EntityFramework Core Bug

<b>This sample requires the installation of SQL LocalDb</b>.  I used SQL2016 LocalDb.

You may have to uninstall/reinstall EF6 from the EF6TestHarness to get EF6 loaded

There are two programs, one called <b>EF7TestHarness</b> and another called <b>EF6TestHarness</b>.  Both programs are console apps that show query times for expressions with the specified number of 'OR' predicates.  The program loops from 1 to 26 predicates in the expression.  In the EF7 sample on my computer, at around 20 predicates, each additional predicate seems to take around double the time of the previous run.  The EF6 sample doesn't show any degradation.   
