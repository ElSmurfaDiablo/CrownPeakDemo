I chose to use exercise #4 Game Of Life. I chose a webforms approach as it what I am most familiar with.
The default.aspx page is where all neighbourhoods are evolved and displayed.
The project was built using Visual Studio 2017(community edition) using a webform application template so there is some extra framework kruft included that I might not have cleaned out.

There are two ways to test the functionality of the game rules:
1 - Open the Default.aspx page directly - where the application will gather an initial game board and column/row counts from the web.config file.
	This is the current start page.
or

2 - Open EnterGameBoard.aspx page where a game board of most any size(up to 20 columns) can be entered.
	Rows are entered in separate fields using the 'Add Row' button.
	It will check that the number of columns entered in each row are the same count to alleviate issues later.
	It checks to be sure only 1's or 0's are entered in the fields. (spaces are also allowed, and are trimmed by the default page.)

While there is a little work being done in the default.aspx page load function such as getting the living values and row/column counts most work is being done in the GOL.cs file/class.
I took an approach where each cell has left/right values(height/width), a bool to indicate living or not and a neighbour count value.
I used a List to contain the cells to help make the number of cells available flexible.
I then used methods to adjust counts and living status as needed.


Recommended additions:
	A way to perpetuate the "New Neighbourhood" to be "evolved". Currently copy paste to a new form is required.
	
Known issues:
	When entering a new game board, spaces get counted so "1 1 1"(length=5) is not the same as "111"(length=3) when counting the length of the fields being entered.

The description for the exersize is below:
-Exercise 4-
Write some code that evolves generations through the "Game of
Life". The input will be a game board of cells, either alive (1) or dead (0).
 
The code should take this board and create a new board for the
next generation based on the following rules:

1) Any live cell with fewer than two live neighbours dies (underpopulation)
2) Any live cell with two or three live neighbours lives on to
the next generation (survival)
3) Any live cell with more than three live neighbours dies
(overcrowding)
4) Any dead cell with exactly three live neighbours becomes a
live cell (reproduction)
 
As an example, this game board as input:
0 1 0 0 0
1 0 0 1 1
1 1 0 0 1
0 1 0 0 0
1 0 0 0 1
 

Will have a subsequent generation of:
0 0 0 0 0
1 0 1 1 1
1 1 1 1 1
0 1 0 0 0
0 0 0 0 0