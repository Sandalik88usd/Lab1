namespace LB1;

class Parking
    {
        public static int CountOfPlaces;
        private List<string> _places = new List<string>(CountOfPlaces);

        public Parking(int countOfPlaces)
        {
            CountOfPlaces = countOfPlaces;
        }

        public void StartWork()
        {
            while (Parking.CountOfPlaces < 1)
            {
                Console.Write("Введіть кількість парковочних місць: ");
                Parking.CountOfPlaces = int.Parse(Console.ReadLine());
                if (Parking.CountOfPlaces < 1)
                {
                    Console.WriteLine("Некоректна кількість місць.");
                    Console.ReadKey();
                    Console.Clear();
                }
                ParkingWork();
            }
        }
        public void ParkingWork()
        {
            int operation;
            bool programWork = true;
            CleanParking();
            while (programWork)
            {
                Console.WriteLine("\nВиберіть задачу:\n1. Зайняти перше вільне місце." +
                                  "\n2. Обрати місце яке хочете зайняти." +
                                  "\n3. Вибрати місце яке звільнити.\n4. Показати список місць на парковці.");
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        CarArrived();
                        break;
                    case 2:
                        Console.WriteLine("Оберіть місце яке хочете зайняти: ");
                        ChoosePlace(int.Parse(Console.ReadLine()));
                        break;
                    case 3:
                        Console.WriteLine("Оберіть місце яке звільнилось: ");
                        ChooseCarToLeave(int.Parse(Console.ReadLine()));
                        break;
                    case 4:
                        ShowList();
                        break;
                }
                if (operation > 4 || operation < 1)
                    Console.WriteLine("Такої операції не існує.\n");
                Console.WriteLine("Бажаєте завершити роботу? (y)");
                if (Console.ReadLine() == "y")
                    programWork = false;
                Console.Clear();
            }
        }

        public void ShowList()
        {
            for (int place = 0; place < CountOfPlaces; place++)
            {

                Console.WriteLine(place + 1 + ". " + _places[place]);
            }
        }

        public void CleanParking()
        {
            for (int place = 0; place < CountOfPlaces; place++)
            {

                _places.Add("Free place");
            }
        }

        public void CarArrived()
        {
            for (int place = 0; place < CountOfPlaces; place++)
            {
                if (_places[place] == "Free place")
                {
                    _places[place] = "Place is taken";
                    break;
                }
                else if(place + 1 == CountOfPlaces && _places[place] == "Place is taken")
                {
                    Console.WriteLine("Всі місця на парковці зайняті.\n");
                }
            }
        }

        public void ChoosePlace(int place)
        {
            if (place > _places.Count || place < 1)
                Console.WriteLine("Такого місця не існує");
            else if (_places[place-1] == "Place is taken")
                Console.WriteLine("Це місце вже зайняте.");
            else
                _places.Insert(place - 1,"Place is taken");

        }

        public void ChooseCarToLeave(int place)
        {
            if (place > _places.Count || place < 1)
                Console.WriteLine("Такого місця не існує");
            else if (_places[place-1] == "Free place")
                Console.WriteLine("Це місце вже вільне.");
            else
                _places.Insert(place - 1, "Free place");
            
        }
    }