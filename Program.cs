Console.WriteLine($"Вводим числа от 0 до {uint.MaxValue}");
uint LevelsCount = ReadVariable("Колличество этажей");
uint EntryCount = ReadVariable("Колличество подъездов");

uint RoomMax = LevelsCount * EntryCount * 4;

Console.WriteLine($"Всего возможно {RoomMax} квартиры");

uint RoomNumber = ReadVariable("Номер квартиры");

calculate(LevelsCount, RoomMax, RoomNumber);

static void calculate(uint levelscount, uint roommax, uint roomnumber)
{
    string[] somelevel = new string[]
    {
        "ближняя слева",
        "дальняя слева",
        "дальняя справа",
        "ближняя справа"
    };


    if (roomnumber > roommax || roomnumber < 1)
    {
        Console.WriteLine($"Квартиры №{roomnumber} - не существует");
    }
    else
    {
        uint RoomsInEntry = levelscount * 4;
        uint EntryNumber = (uint)Math.Ceiling((double)roomnumber / RoomsInEntry);
        uint LevelNumber = (uint)Math.Ceiling((roomnumber - (EntryNumber - 1) * RoomsInEntry) / 4.0);

        Console.WriteLine($"Квартира №{roomnumber} (из {roommax}) будет {somelevel[(roomnumber - 1) % 4]}");
        Console.WriteLine($"На этаже: {LevelNumber}");
        Console.WriteLine($"В подъезде: {EntryNumber}");
    }
}


uint ReadVariable(string variablename)
{
    Console.WriteLine($"Введите \"{variablename.ToLower()}\":");
    bool result = uint.TryParse(Console.ReadLine(), out uint value);
    if (result == false)
    {
        throw new Exception($"Ошибка при вводе переменной \"{variablename}\"");
    }
    return value;
}

