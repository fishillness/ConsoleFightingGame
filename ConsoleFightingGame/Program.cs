using System;

namespace ConsoleFightingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Объявление переменных
            int playerHealth = 100;
            int playerEnergy = 100;

            int enemyHealth = 100;
            int enemyEnergy = 100;

            int action = -1;
            Random rnd = new Random();

            while (true)
            {
                //Отображение статов и скилов
                Console.Clear();

                Console.WriteLine(@"    Жизни: {0}                  Жизни вируса: {1}", playerHealth, enemyHealth);
                Console.WriteLine(@"    Энергия: {0}                Энергия вируса: {1}", playerEnergy, enemyEnergy);

                Console.WriteLine();


                Console.WriteLine("1. Почистить папку Temp (20 урона, -10 энергии)");
                Console.WriteLine("2. Использовать Касперского (30 урона, -40 энергии)");
                Console.WriteLine("3. Выпить кофе (+20 энергии)");
                Console.WriteLine("4. Заказать доставку пиццы (+30 жизни, -20 энергии)");

                Console.WriteLine();

                //Определение поражения
                if (playerHealth <= 0)
                {
                    Console.WriteLine("Вирус выиграл!");
                    break;
                }
                
                //Получение действий от игрока
                action = int.Parse(Console.ReadLine());
                if (action < 1 || action > 4)
                    action = 5;
                
                //Описание скиллов игрока
                if (action == 1)
                {
                    if (playerEnergy >= 10)
                    {
                        enemyHealth -= 20;
                        playerEnergy -= 10;
                    }
                    else
                    {
                        Console.WriteLine("Не достаточно энергии. Пропуск хода.");
                        Console.ReadLine();
                    }
                }

                if (action == 2)
                {
                    if (playerEnergy >= 40)
                    {
                        enemyHealth -= 30;
                        playerEnergy -= 40;
                    }
                    else
                    {
                        Console.WriteLine("Не достаточно энергии. Пропуск хода.");
                        Console.ReadLine();
                    }
                }

                if (action == 3)
                {
                    playerEnergy += 20;
                }

                if (action == 4)
                {
                    if (playerEnergy >= 20)
                    {
                        playerHealth += 30;
                        playerEnergy -= 20;
                    }
                    else
                    {
                        Console.WriteLine("Не достаточно энергии. Пропуск хода.");
                        Console.ReadLine();
                    }
                }
                if (action == 5)
                    Console.WriteLine("Такого действия не существует. Вы пропускаете ход.");

                //Определение победы 
                if (enemyHealth <= 0)
                {
                    Console.WriteLine("Вы выиграли!");
                    break;
                }

                //Получение действия от противника
                action = rnd.Next(1, 5);

                if (enemyHealth <= 15 && enemyEnergy>=10)
                    action = 2;
                else
                {
                    if (enemyEnergy <= 20)
                        action = 4;
                }

                //Описание работы скиллов противника
                if (action == 1)
                {
                    if (enemyEnergy >= 10)
                    {
                        playerHealth -= 20;
                        enemyEnergy -= 10;
                        Console.WriteLine("Вас атаковал вирус. Жизнь уменьшится на 20.");
                    }
                    else
                        Console.WriteLine("Вирус промахнулся.");
                }
                if (action == 2)
                {
                    enemyHealth += 20;
                    enemyEnergy -= 10;
                    Console.WriteLine("Вирус поднял себе здоровье.");
                }
                if (action == 3)
                {
                    if (enemyEnergy >= 40)
                    {
                        playerHealth -= 30;
                        enemyEnergy -= 40;
                        Console.WriteLine("Вас атаковал вирус. Жизнь уменьшится на 30.");
                    }
                    else
                        Console.WriteLine("Вирус промахнулся.");
                }
                if (action == 4)
                {
                    enemyEnergy += 20;
                    Console.WriteLine("Вирус набрался сил.");
                }

                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}
