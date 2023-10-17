
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

class Program
{
    static List<Note> notes = new List<Note>();

    static void Main(string[] args)
    {
        
        notes.Add(new Note("Заметка 1 \n 12.03.2023 \n коснитесь Enter", " ", new DateTime(2023, 3, 12), new DateTime(2023, 3, 15)));
        notes.Add(new Note("Заметка 2 \n 13.03.2023 \n коснитесь Enter", "Описание заметки 2", new DateTime(2023, 3, 13), new DateTime(2023, 3, 18)));
        notes.Add(new Note("Заметка 3 \n 14.03.2023 \n коснитесь Enter", "Описание заметки 3", new DateTime(2023, 3, 14), new DateTime(2023, 3, 20)));

        int selectedIndex = 0; 
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();

            ShowNoteTitle(selectedIndex);

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    selectedIndex = (selectedIndex - 1 + notes.Count) % notes.Count;
                    break;
                case ConsoleKey.RightArrow:
                    selectedIndex = (selectedIndex + 1) % notes.Count;
                    break;
                case ConsoleKey.Enter:
                    ShowNoteDetails(selectedIndex);
                    break;
                case ConsoleKey.Escape:
                    isRunning = false;
                    break;
            }
        }
    }


    static void ShowNoteTitle(int index)
    {
        Console.WriteLine("--------------");
        Console.WriteLine("Ежедневник");
        Console.WriteLine("--------------");

        Console.WriteLine(notes[index].Title);
    }

    static void ShowNoteDetails(int index)
    {
        Console.Clear();
        Note note = notes[index];
        Console.WriteLine($"Дата: {note.Date.ToShortDateString()}");
        Console.WriteLine($"Дата выполнения: {note.DueDate.ToShortDateString()}");

        Console.WriteLine();
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться к списку заметок.");

        Console.WriteLine("--------------");
        Console.WriteLine("Подробная информация");
        Console.WriteLine("--------------");



        Console.WriteLine($"Название: {note.Title}");
        Console.WriteLine($"Описание: {note.Description}");
        Console.WriteLine(" список дел на сегодня:");
        Console.WriteLine("  пойти на пары");
        Console.WriteLine("  сходить в магазин");
        Console.WriteLine("  приготовить пирог");
        Console.WriteLine("  начать делать практосы");
        Console.WriteLine("  прибраться в комнате");



        int pos = 75;
        int[] a = new int[] {};
        foreach (int i in a)
        {
            Console.WriteLine("  " + i);
        }
        ConsoleKeyInfo key;

         do
        {
            Console.SetCursorPosition(0, pos);
            Console.WriteLine("->");
            key = Console.ReadKey();
            Console.SetCursorPosition(0, pos);
            Console.WriteLine(" ");

            if (key.Key == ConsoleKey.UpArrow)
            {
                pos--;
                if (pos == 79)
                    pos = a.Length;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                pos++;
                if (pos == a.Length + 1)
                    pos = 75;
            }
            Console.ReadKey();
        }
        while (key.Key != ConsoleKey.Enter);
    if (pos == 75)
        {
            Console.Clear;
            Console.WriteLine("  удачного рабочего дня ");
        }
     if (pos == 76)
        {
            Console.Clear;
            Console.WriteLine(" не забудь список покупок ");
        }
        if (pos == 77)
        {
            Console.Clear;
            Console.WriteLine("  приятного аппетита ");
        }
        if (pos == 78)
        {
            Console.Clear;
            Console.WriteLine("  обязательно отдохни потом ");
        }

    }
    class Note
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }

        public Note(string title, string description, DateTime date, DateTime dueDate)
        {
            Title = title;
            Description = description;
            Date = date;
            DueDate = dueDate;
        }
    }
}



