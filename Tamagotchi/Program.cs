//Задача: отсортировать входную строку по алфавиту любым методом 
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Pet
    {
        private string name;
        private short health;
        private short hygiene;
        private short happiness;
        private short peppiness;
        private short satiety;

        //Конструктор
        public Pet(string name)
        {
            this.name = name;
            health = 100;
            hygiene = 100;
            happiness = 100;
            peppiness = 100;
            satiety = 100;
            Console.WriteLine("Ваш питомец " + this.name + " успешно создан!\n");
        }

        //Справка
        static public void Reference()
        {
            Console.WriteLine(
                "0:  Выход\n" +
                "1:  Добавить питомца\n" +
                "2:  Выбросить питомца\n" +
                "3:  Посмотреть питомцев\n" +
                "4:  Поговорить с питомцем\n" +
                "5:  Покормить питомца\n" +
                "6:  Играть с питомцем\n" +
                "7:  Гулять с питомцем\n" +
                "8:  Отправить питомца купаться\n" +
                "9:  Отправить питомца чистить зубы\n" +
                "10: Отправить питомца спать\n" +
                "11: Отправить питомца к врачу\n" +
                "12: Переименовать питомца\n" +
                "13: Вывести справку\n");
        }

        //Проверка для исключения дубликатов 
        static public bool Without_backup(List<Pet> list_animals, string name)
        {
            foreach (var i in list_animals)
            {
                if (i.Pet_name == name)
                {
                    Console.WriteLine("Такой питомец уже есть, придумайте другое имя");
                    return false;
                }
            }
            return true;
        }

        //Вывод списка питомцев 
        static public void Write_list_name(List<Pet> list_animals)
        {
            Console.WriteLine("У вас есть:");
            foreach (var i in list_animals)
            {
                Console.WriteLine(i.Pet_name);
            }
        }

        //Возвращает ссылку на экземпляр по значению поля name 
        static public Pet Chek_name_pet(List<Pet> list_animals, string search_name)
        {
            foreach (var i in list_animals)
            {

                if (i.Pet_name == search_name)
                {
                    return i;
                }
            }
            return null;
        }

        //Вывод текста title и возвращает ввод с консоли
        static public string Read_name_from_console(List<Pet> list_animals, string title)
        {
            Pet.Write_list_name(list_animals);
            Console.Write(title);
            return Console.ReadLine().Trim();
        }

        //Функция вывода сообщения об отсутсвии питомца
        static public void Not_pet()
        {
            Console.WriteLine("Питомец с заданым именем не найден");
        }

        //Св-во для получения или изменения name экземпляра класса 
        public string Pet_name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        //Обновление полей
        private void Renwe_health(short health)
        {
            if (this.health + health >= 100)
            {
                this.health = 100;
            }
            else if (25 <= this.health + health && this.health + health < 100)
            {
                this.health += health;
            }
            else if (0 <= this.health + health && this.health + health < 25)
            {
                this.health += health;
                Renew_happiness(-20);
            }
            else if (this.health + health < 0)
            {
                this.health = 0;
                Renew_happiness(-20);
            }
        }

        private void Renew_hygiene(short hygiene)
        {
            if (this.hygiene + hygiene >= 100)
            {
                this.hygiene = 100;
            }
            else if (25 <= this.hygiene + hygiene && this.hygiene + hygiene < 100)
            {
                this.hygiene += hygiene;
            }
            else if (0 < this.hygiene + hygiene && this.hygiene + hygiene < 25)
            {
                this.hygiene += hygiene;
                Renwe_health(-5);
            }
            else if (this.hygiene + hygiene <= 0)
            {
                this.hygiene = 0;
                Renwe_health(-10);
            }
        }

        private void Renew_satiety(short satiety)
        {
            if (this.satiety + satiety >= 100)
            {
                this.satiety = 100;
            }
            else if (25 <= this.satiety + satiety && this.satiety + satiety < 100)
            {
                this.satiety += satiety;
            }
            else if (0 < this.satiety + satiety && this.satiety + satiety < 25)
            {
                this.satiety += satiety;
                Renew_happiness(-10);
                Renwe_health(-5);
            }
            else if (this.satiety + satiety <= 0)
            {
                this.satiety = 0;
                Renew_happiness(-10);
                Renwe_health(-10);
            }
        }

        private void Renew_happiness(short happiness)
        {
            if (this.happiness + happiness >= 100)
            {
                this.happiness = 100;
            }
            else if (0 < this.happiness + happiness && this.happiness + happiness < 100)
            {
                this.happiness += happiness;
            }
            else if (this.happiness + happiness <= 0)
            {
                this.happiness = 0;
            }
        }

        private void Renew_peppiness(short peppiness)
        {
            if (this.peppiness + peppiness >= 100)
            {
                this.peppiness = 100;
            }
            else if (25 <= this.peppiness + peppiness && this.peppiness + peppiness < 100)
            {
                this.peppiness += peppiness;
            }
            else if (0 < this.peppiness + peppiness && this.peppiness + peppiness < 25)
            {
                this.peppiness += peppiness;
                Renwe_health(-5);
            }
            else if (this.peppiness + peppiness <= 0)
            {
                this.peppiness = 0;
                Renwe_health(-5);
            }
        }

        //Действия
        public void Talk()
        {
            Renew_happiness(5);
            Renew_peppiness(-5);

            Console.WriteLine($"Имя питомца: {this.name}");
            Console.WriteLine($"Здоровье питомца: {this.health}");
            Console.WriteLine($"Гигиена питомца: {this.hygiene}");
            Console.WriteLine($"Счастье питомца: {this.happiness}");
            Console.WriteLine($"Сытость питомца: {this.satiety}");
            Console.WriteLine($"Усталость питомца: {this.peppiness}");
        }

        public void Feed()
        {
            Renew_satiety(40);
            Renwe_health(15);
            Renew_happiness(15);
            Renew_peppiness(-15);
        }

        public void Play()
        {
            Renew_happiness(15);
            Renew_peppiness(-20);
            Renew_satiety(-10);
        }

        public void Walk()
        {
            Renew_happiness(60);
            Renew_peppiness(-30);
            Renew_satiety(-20);
        }

        public void Bathe()
        {
            Renew_hygiene(45);
            Renew_peppiness(-10);
            Renew_satiety(-5);
        }

        public void Brush_teeth()
        {
            Renew_hygiene(30);
            Renew_peppiness(-10);
            Renew_satiety(-5);
        }

        public void Sleep()
        {
            Renew_peppiness(80);
            Renew_satiety(-60);
            Renew_hygiene(40);
        }

        public void Visit_doctor()
        {
            if (this.health < 20)
            {
                Renwe_health(60);
                Renew_satiety(-30);
                Renew_peppiness(-20);
            }
            else
            {
                Renwe_health(30);
                Renew_satiety(-10);
                Renew_peppiness(-20);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Список экземпляров класса
            List<Pet> list_animals = new List<Pet>();
            //Буферная переменная для хранения ссылки на экземпляр класса по выбранному критерию 
            Pet result;
            //Переменная для хранения выбранной команды 
            byte command = 1;
            //Буферные переменные
            string name, new_name, buff;
            //Массив строк интерфейса 
            string[] interface_strings =
            {
                "Выберите имя питомца которого хотите выборосить: ",
                "Выберите имя питомца с которым хотите поговорить: ",
                "Выберите имя питомца которого хотите покормить: ",
                "Выберите имя питомца с которым хотите поиграть: ",
                "Выберите имя питомца с которым хотите погулять: ",
                "Выберите имя питомца которого хотите отправить купаться: ",
                "Выберите имя питомца которого хотите отправить чистить зубы: ",
                "Выберите имя питомца которого хотите отправить спать: ",
                "Выберите имя питомца которого хотите отправить к врачу: ",
                "Выберите имя питомца которого хотите переименовать: "
            };

            Console.Write("Введите имя вашего нового питомца: ");
            name = Console.ReadLine().Trim();
            //Добавление первого питомца 
            list_animals.Add(new Pet(name));

            while (true)
            {
                //Вывод справки
                Pet.Reference();
                Console.Write("Выберите действие: ");
                //Считывание команды
                command = Convert.ToByte(Console.ReadLine());

                if (command == 0)
                {
                    break;
                }
                else if (command == 1)
                {
                    //Добавление питомца

                    Console.Write("Введите имя вашего нового питомца: ");
                    new_name = Console.ReadLine().Trim();

                    if (Pet.Without_backup(list_animals, new_name))
                    {
                        list_animals.Add(new Pet(new_name));
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (command == 2)
                {
                    //Выбросить питомца 
                    if (list_animals.Remove(Pet.Chek_name_pet(list_animals, Pet.Read_name_from_console(list_animals, interface_strings[0]))))
                    {
                        Console.WriteLine("Вы жестокий человек...");
                    }
                    else
                    {
                        Pet.Not_pet();
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (command == 3)
                {
                    Pet.Write_list_name(list_animals);
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (command == 4)
                {
                    //Поговорить
                    result = Pet.Chek_name_pet(list_animals, Pet.Read_name_from_console(list_animals, interface_strings[1]));
                    if (result != null)
                    {
                        result.Talk();
                    }
                    else
                    {
                        Pet.Not_pet();
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (command == 5)
                {
                    //Покормить
                    result = Pet.Chek_name_pet(list_animals, Pet.Read_name_from_console(list_animals, interface_strings[2]));

                    if (result != null)
                    {
                        result.Feed();
                    }
                    else
                    {
                        Pet.Not_pet();
                    }
                    Console.Clear();
                }
                else if (command == 6)
                {
                    //Поиграть
                    result = Pet.Chek_name_pet(list_animals, Pet.Read_name_from_console(list_animals, interface_strings[3]));

                    if (result != null)
                    {
                        result.Play();
                    }
                    else
                    {
                        Pet.Not_pet();
                    }
                    Console.Clear();
                }
                else if (command == 7)
                {
                    //Погулять
                    result = Pet.Chek_name_pet(list_animals, Pet.Read_name_from_console(list_animals, interface_strings[4]));

                    if (result != null)
                    {
                        result.Walk();
                    }
                    else
                    {
                        Pet.Not_pet();
                    }
                    Console.Clear();
                }
                else if (command == 8)
                {
                    //Купаться 
                    result = Pet.Chek_name_pet(list_animals, Pet.Read_name_from_console(list_animals, interface_strings[5]));

                    if (result != null)
                    {
                        result.Bathe();
                    }
                    else
                    {
                        Pet.Not_pet();
                    }
                    Console.Clear();
                }
                else if (command == 9)
                {
                    //Чистить зубы
                    result = Pet.Chek_name_pet(list_animals, Pet.Read_name_from_console(list_animals, interface_strings[6]));

                    if (result != null)
                    {
                        result.Brush_teeth();
                    }
                    else
                    {
                        Pet.Not_pet();
                    }
                    Console.Clear();
                }
                else if (command == 10)
                {
                    //Спать
                    result = Pet.Chek_name_pet(list_animals, Pet.Read_name_from_console(list_animals, interface_strings[7]));

                    if (result != null)
                    {
                        result.Sleep();
                    }
                    else
                    {
                        Pet.Not_pet();
                    }
                    Console.Clear();
                }
                else if (command == 11)
                {
                    //Посетить доктора
                    result = Pet.Chek_name_pet(list_animals, Pet.Read_name_from_console(list_animals, interface_strings[8]));

                    if (result != null)
                    {
                        result.Visit_doctor();
                    }
                    else
                    {
                        Pet.Not_pet();
                    }
                    Console.Clear();
                }
                else if (command == 12)
                {
                    //Переименовать
                    result = Pet.Chek_name_pet(list_animals, Pet.Read_name_from_console(list_animals, interface_strings[9]));

                    if (result != null)
                    {
                        Console.Write("Введите новое имя питомца: ");
                        buff = Console.ReadLine().Trim();

                        if (Pet.Without_backup(list_animals, buff))
                        {
                            result.Pet_name = buff;
                            Console.WriteLine("Питомец успешно переименован");
                        }
                    }
                    else
                    {
                        Pet.Not_pet();
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (command == 13)
                {
                    Pet.Reference();
                }
                else
                {
                    Console.WriteLine("Команда не распознана");
                }
            }

            Console.WriteLine("Пока-пока");
            Console.ReadKey();
        }
    }
}
