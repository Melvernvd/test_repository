class Main_Menu
{
    public static object account = null;

    //REFACTOR: Modify the menu so that it will show options based on 'field: account = null, Admin or Customer'.
    public static void MainMenu()
    {
        while (true)
        {
            if (account is Admin)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔═══════════════════════════════════════╗");
                Console.WriteLine("║                 Admin                 ║");
                Console.WriteLine("╚═══════════════════════════════════════╝");
                Console.ResetColor();
            }
            else if (account is Customer)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔═══════════════════════════════════════╗");
                Console.WriteLine("║               Customer                ║");
                Console.WriteLine("╚═══════════════════════════════════════╝");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("╔═══════════════════════════════════════╗");
                Console.WriteLine("║             Not Logged in             ║");
                Console.WriteLine("╚═══════════════════════════════════════╝");
            }

            Console.WriteLine();
            Console.WriteLine("╔═══════════════════════════════════════╗");
            Console.WriteLine("║ Welcome to Restaurant Booking System! ║");
            Console.WriteLine("╠═══════════════════════════════════════╣");
            Console.WriteLine("║ 1. Make Account / Login               ║");
            Console.WriteLine("║ 2. View Menu                          ║");
            Console.WriteLine("║ 3. Make Reservation                   ║");
            Console.WriteLine("║ 4. View Past Reservations             ║");
            Console.WriteLine("║ 5. About Restaurant                   ║");
            if (account is Admin) { Console.WriteLine("║ 6. Admin Options                      ║"); }
            Console.WriteLine("║                                       ║");
            Console.WriteLine("║ Enter your choice.                    ║");
            Console.WriteLine("╚═══════════════════════════════════════╝");
            int choice = 0;
            try {choice = int.Parse(Console.ReadLine());}
            catch {Console.WriteLine("Invalid entry");}

            switch (choice)
            {
                case 1:
                    //Console.WriteLine(Account.Option()); (PREVIOUS WAY)
                    Program.ConsoleClear();
                    account = Account.Option();
                    if (account is string) { Console.WriteLine(account); }
                    break;
                case 2:
                    Program.ConsoleClear();
                    MenuManager.ViewMenu();
                    break;
                case 3:
                    Program.ConsoleClear();
                    if (account is Customer) { ReservationSystem.ReservationMenu(account as Account); }
                    else
                    {
                        Console.WriteLine("Only customers can make reservations.");
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }
                    break;
                case 4:
                    Program.ConsoleClear();
                    if (account is Customer) {  }
                    else
                    {
                        Console.WriteLine("Only customers can view past reservations.");
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }
                    // ClassName.ViewPastReservations();
                    break;
                case 5:
                    Program.ConsoleClear();
                    PrintAboutText();
                    break;
                case 6:
                    Program.ConsoleClear();
                    if (account is Admin) { Admin_Menu.AdminMenu(); }
                    else
                    {
                        Console.WriteLine("Invalid choice. Press enter to continue...");
                        Console.ReadLine();
                    }
                    break;
                default:
                    Program.ConsoleClear();
                    Console.WriteLine("Invalid choice. Press enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    public static void PrintAboutText()
    {
        string text = TXT.ReadFromTXT();
        if (text != null)
        {
            Console.WriteLine(text);
        }
    }

    public static void AboutTextAdmin()
    {
        Console.WriteLine("Type 3 lines of information about your restaurant:");
        TXT.WritetoTXT();
        TXT.WritetoTXT();
        TXT.WritetoTXT();
    }
}
