using MenuTools.MenuBuilders;
using MenuTools.TableBuilder;


// * * * * * Demonstration Menu Builder * * * * * 

// ~ ~ ~ ~ ~ ~ ~ ~ without limit ~ ~ ~ ~ ~ ~ ~ ~ 

MenuBuilder menu = new(5, 2, false)
{
    ItemsMenu = new()
    {
        "Enter",
        "Settings",
        "Exit"
    },

    PointerColor = ConsoleColor.Yellow,
    ItemColor = ConsoleColor.Green
};

menu.SetCursorVisible(false);
int select = menu.RunMenu(); 

Console.WriteLine($"\n\n -> Selected: {select}");

// ~ ~ ~ ~ ~ ~ ~ ~ ~ with limit ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

MenuBuilder menuLimit = new(5, 9, 2, 1, true)
{
    ItemsMenu = new()
    {
        "Enter",
        "Settings",
        "About",
        "Save",
        "Loading",
        "Exit"
    },

    PointerColor = ConsoleColor.Cyan,
    ItemColor = ConsoleColor.Blue
};

menuLimit.SetCursorVisible(false);
int selectLimit = menuLimit.RunMenu();

Console.WriteLine($"\n\n -> Selected: {selectLimit}");


// * * * * * Demonstration Numeric Builder * * * * * 

// ~ ~ ~ ~ ~ ~ ~ ~ ~ vertical ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

NumericBuilder numericVert = new(7, 19, false)
{
    ItemsRange = (-10, 100),
    NumColor = ConsoleColor.Red,
    ArowColor = ConsoleColor.Magenta,
};

numericVert.SetCursorVisible(false);
int selectVert = numericVert.RunNumeric(Mod.Vertical);

Console.WriteLine($"\n\n -> Selected: {selectVert}");

// ~ ~ ~ ~ ~ ~ ~ ~ ~ horizontal ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

NumericBuilder numericHoriz = new(5, 27, false)
{
    ItemsRange = (1, 15),
    NumColor = ConsoleColor.Blue,
    ArowColor = ConsoleColor.DarkYellow,
};

numericVert.SetCursorVisible(false);
int selectHoriz = numericHoriz.RunNumeric(Mod.Horizontal);

Console.WriteLine($"\n\n -> Selected: {selectHoriz}");


// * * * * * Demonstration Texteric Builder * * * * * 

// ~ ~ ~ ~ ~ ~ ~ ~ ~ vertical ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

TextericBuilder textericVert = new(7, 32, false)
{
    ItemsText = new()
    {
        "Yes",
        "No"
    },
    TextColor = ConsoleColor.Green,
    ArowColor = ConsoleColor.Magenta,
};

textericVert.SetCursorVisible(false);
int selectTextVert = textericVert.RunTexteric(Mod.Vertical);

Console.WriteLine($"\n\n -> Selected: {selectTextVert}");

// ~ ~ ~ ~ ~ ~ ~ ~ ~ horizontal ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

TextericBuilder textericHoriz = new(5, 39, true)
{
    ItemsText = new()
    {
        "Delete",
        "Change",
        "Add",
        "Copy"
    },
    TextColor = ConsoleColor.Blue,
    //ArowColor = default is white color
};

textericHoriz.SetCursorVisible(false);
int selectTextHoriz = textericHoriz.RunTexteric(Mod.Horizontal);

Console.WriteLine($"\n\n -> Selected: {selectTextHoriz}\n");


// * * * * * Demonstration Table Builder * * * * * 

TableBuilder myTable = new(3)
{
    Headers = new string[] { "Name", "Genre", "Release date" },
    ColumnSizes = new int[] { -20, -15, -12 }
};

Console.WriteLine(myTable.AddTopLine());
Console.WriteLine(myTable.AddHeader());
Console.WriteLine(myTable.AddMiddleLine());
Console.WriteLine(myTable.AddRow("The Witcher 3", "action/RPG", "05.02.2013"));
Console.WriteLine(myTable.AddMiddleLine());
Console.WriteLine(myTable.AddRow("Diablo 2", "RPG", "05.07.2002"));
Console.WriteLine(myTable.AddMiddleLine());
Console.WriteLine(myTable.AddRow("Warcraft 3", "TBS", "29.06.2000"));
Console.WriteLine(myTable.AddMiddleLine());
Console.WriteLine(myTable.AddRow("Quake 2", "Shooter", "18.02.1997"));
Console.WriteLine(myTable.AddMiddleLine());
Console.WriteLine(myTable.AddRow("Grand Theft Auto: Vice City", "action-adventure", "27.10.2002"));
Console.WriteLine(myTable.AddCrossSmoothLine());
Console.WriteLine(myTable.AddTextLine("Count: 5", 22));
Console.WriteLine(myTable.AddSmoothEndLine());


// * * * * * Demonstration Table Builder + Menu Builder * * * * * 

// ~ ~ ~ ~ ~ ~ ~ ~ ~ default step = 1 ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

MenuBuilder menuTable = new(1, 60, 3, 1, true)
{
    ItemsMenu = new()
    {
        myTable.AddTopLine(),
        myTable.AddHeader(),
        myTable.AddMiddleLine(),
        myTable.AddRow("The Witcher 3", "action/RPG", "05.02.2013"),
        myTable.AddRow("Diablo 2", "RPG", "05.07.2002"),
        myTable.AddRow("Warcraft 3", "TBS", "29.06.2000"),
        myTable.AddRow("Quake 2", "Shooter", "18.02.1997"),
        myTable.AddRow("Grand Theft Auto: Vice City", "action-adventure", "27.10.2002"),
        myTable.AddEndLine(),
    },

    PointerColor = ConsoleColor.Yellow,
    ItemColor = ConsoleColor.Green
};

menuTable.SetCursorVisible(false);
int selectRow = menuTable.RunMenu();

Console.WriteLine($"\n\n -> Selected: {selectRow}");

// ~ ~ ~ ~ ~ ~ ~ ~ ~ step = 2 ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

MenuBuilder menuStepTable = new(1, 73, 3, 1, 2, true)
{
    ItemsMenu = new()
    {
        myTable.AddTopLine(),
        myTable.AddHeader(),
        myTable.AddMiddleLine(),
        myTable.AddRow("The Witcher 3", "action/RPG", "05.02.2013"),
        myTable.AddMiddleLine(),
        myTable.AddRow("Diablo 2", "RPG", "05.07.2002"),
        myTable.AddMiddleLine(),
        myTable.AddRow("Warcraft 3", "TBS", "29.06.2000"),
        myTable.AddMiddleLine(),
        myTable.AddRow("Quake 2", "Shooter", "18.02.1997"),
        myTable.AddMiddleLine(),
        myTable.AddRow("Grand Theft Auto: Vice City", "action-adventure", "27.10.2002"),
        myTable.AddEndLine(),
    },

    PointerColor = ConsoleColor.Red,
    ItemColor = ConsoleColor.DarkMagenta
};

menuTable.SetCursorVisible(false);
int selectStepRow = menuStepTable.RunMenu();

Console.WriteLine($"\n\n -> Selected: {selectStepRow}");