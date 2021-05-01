# Code Coverage Collector

Short user instruction of the Code Cover Collector (CCC).

[Git Project URL](https://github.com/TESTARtool/CoverageProcessor)

## Introduction and purpose

To make it easier to use the data obtained from the experiments and to make this data more
transparent. It collects the data in the CVS files produced by TESTAR, and writes separate text files.
So that this data can be easily copied and entered into a data processing program such as Excel.
In addition, some functions have been added, such as displaying the obtained data in various graphs
and options for a quick test.

The program was specially written for an experiment in computer science at the open university of the Netherlands.
The CCC consists of a number of modules, each targeting a particular task or file produced by
TESTAR.

At the moment the CCC has 4 modules:

### 1 - TestRun coverage

Under TestRun coverage it is possible to read out an individual file with coverage per action,
obtained during one test run consisting of several sequences.

It can produce diverse files with separated info about the instruction coverage, branch coverage and
number of actions.These files will be saved in the same map as the original file which was.

It helps to study the data by ordering the data in the text area, write the data ordered by type to disc
and show the corresponding graphs of the sequences. This module specially deals with coverage per
sequence.

### 2 - Merge coverage: Runtotal type

Under Merge coverage: Runtotal type it is possible to select and read a folder with the generated
merged Coverage files that come out of TESTAR. In the folder it will read the file with a specific name.


It orders the data into samples with final merged coverage. This module reads the values of the total
merged coverage reached during each test run. It is possible to display the merged data orderly as
samples, and write it ordered to disc so it can be imported into statistical applications.These file will
be saved in the same map as the original file.

It is also possible to display the merged data orderly as a sample, write it ordered to disc so it can be
imported into statistical applications, and produce a Box-Plot graph from the sample which can be
saved to local storage.

### Quick Reference Testing

The Quick Reference Testing is an extension of the Merge coverage: Runtotal type module. It is
possible to choose a second folder from which also a sample, consisting out of the values of the
reached merged code coverage, is generated.

After this, it is in this module possible to perform a Welch T-Test and a Mann-Whitney U-Test on this
sample and the already produced. This can be done on instruction coverage, branch coverage as well
on the number of actions taken during the test run.

In addition to calculating the p-value and other test related data , it is also possible to obtain a
graphical comparison of the two samples in a line graph and a box-plot.

### 3 - Merged Coverage: Single File

Merged Coverage: Single File reads the special generated files with merged coverage data, and gives
the possibility to display the graph with merged code coverage of the different sequences in the file.
It is also possible to show a graph with data of more than one test-.

The internal structure of this file follow another convention than that of the files used in the first two
modules. Here, the data does not consist of the reached final merged coverage, but of the achieved
merged coverage after each action within a test run.

For quick reference this module has two other functions which server as an indication of the course
of the coverage, one that calculates the differentiate of the graph of the test run and one that
calculate the integral of the graph of the test run.

### 4 - Merged Coverage: Folder

Merged Coverage: Folder offers the possibility to select a folder containing files with merged code
coverage.

The module can be used to display the graphs of the progression of the merged coverage. These
graphs consists out of the merged coverage values plotted again the used action during a test run. It
is also possible to plot a graph of the average of the merged data after an action of the whole trial.

Further is is possible to choose only the first actions of a test run. And we can save the merged
instruction and branch coverage to disc.

### Extension of the Merged Coverage: Folder

In Merged Coverage: Folder there is also the possibility to show the Graphs of the Differentiate and
Integrate of the graphs with merged code coverage. This to more closely study the speed in coverage
growth during a trial. For this it is possible to select the type of graph and the horizontal as well the
vertical shown range of the differentiate and integral graphs. Also it is also possible to get a
calculation of the differentiate and integrate value in one point (this is actually an action number in
the test) in the graph.
